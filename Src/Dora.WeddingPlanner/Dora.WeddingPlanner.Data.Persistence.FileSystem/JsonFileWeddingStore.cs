using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;
using System.IO;
using Newtonsoft.Json;
using Dora.WeddingPlanner.Model.DTO;
using Dora.WeddingPlanner.Model.DTO.Mapping;
using JsonNet.PrivateSettersContractResolvers;

namespace Dora.WeddingPlanner.Data.Persistence.FileSystem
{
    public class JsonFileWeddingStore : ICanStoreWeddings
    {
        private class SerializableWedding
        {
            [JsonConstructor]
            private SerializableWedding() { }

            public string Id { get; set; }
            public WeddingDto Wedding { get; set; }

            public StorableWedding ToStorableWedding()
            {
                return StorableWedding.Existing(this.Id, this.Wedding.Map());
            }

            public static SerializableWedding FromStorableWedding(StorableWedding wedding)
            {
                return new SerializableWedding
                {
                    Id = wedding.Id,
                    Wedding = wedding.Wedding.Map()
                };
            }
        }

        private readonly string storageBasePath;
        private readonly DirectoryInfo storageDirectory;

        public JsonFileWeddingStore(string baseFolderPath)
        {
            this.storageBasePath = baseFolderPath;
            this.storageDirectory = new DirectoryInfo(baseFolderPath);

            Newtonsoft.Json.

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
        }

        public IEnumerable<StorableWedding> All()
        {
            EnsureStoreFolder();

            return this.storageDirectory
                .EnumerateDirectories()
                .Select(d => StorableWedding.Existing(d.Name, SummaryFor(d.Name)));
        }

        private Wedding SummaryFor(string weddingId)
        {
            var metadata = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(string.Format(@"{0}\{1}.meta.json", WeddingFolder(weddingId), weddingId)));
            return new Wedding(new Person(metadata["Bride"], string.Empty), new Person(metadata["Groom"], string.Empty));
        }

        public Wedding Load(string id)
        {
            var filePath = string.Format(@"{0}\{1}.data.json", WeddingFolder(id), id);
            if (!File.Exists(filePath))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<SerializableWedding>(File.ReadAllText(filePath)).ToStorableWedding().Wedding;
        }

        public void Save(StorableWedding wedding)
        {
            string folder = EnsureWeddingFolderFor(wedding.Id);

            File.WriteAllText(string.Format(@"{0}\{1}.data.json", WeddingFolder(wedding.Id), wedding.Id), JsonConvert.SerializeObject(SerializableWedding.FromStorableWedding(wedding), Formatting.Indented));
            File.WriteAllText(string.Format(@"{0}\{1}.meta.json", WeddingFolder(wedding.Id), wedding.Id), JsonConvert.SerializeObject(MetadataFor(wedding), Formatting.Indented));
        }

        private Dictionary<string, string> MetadataFor(StorableWedding wedding)
        {
            return new Dictionary<string, string>
            {
                { "Id", wedding.Id.ToString() },
                { "Bride", wedding.Wedding.Bride.ToString() },
                { "Groom", wedding.Wedding.Groom.ToString() }
            };
        }

        private string EnsureWeddingFolderFor(string id)
        {
            var weddingFolderPath = WeddingFolder(id);
            if (!Directory.Exists(weddingFolderPath))
            {
                Directory.CreateDirectory(weddingFolderPath);
            }
            return weddingFolderPath;
        }

        private void EnsureStoreFolder()
        {
            if (!this.storageDirectory.Exists)
            {
                this.storageDirectory.Create();
            }
        }

        private string WeddingFolder(string id)
        {
            return string.Format(@"{0}\{1}", this.storageBasePath, id);
        }
    }
}
