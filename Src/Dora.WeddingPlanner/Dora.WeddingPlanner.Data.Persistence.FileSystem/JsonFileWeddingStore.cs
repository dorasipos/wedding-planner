using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;
using System.IO;
using Newtonsoft.Json;

namespace Dora.WeddingPlanner.Data.Persistence.FileSystem
{
    public class JsonFileWeddingStore : ICanStoreWeddings
    {
        private readonly string storageBasePath;

        public JsonFileWeddingStore(string baseFolderPath)
        {
            this.storageBasePath = baseFolderPath;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        public IEnumerable<StorableWedding> All()
        {
            throw new NotImplementedException();
        }

        public Wedding Load(Guid id)
        {
            var filePath = string.Format(@"{0}\{1}.data.json", WeddingFolder(id), id);
            if (!File.Exists(filePath))
            {
                return null;
            }
            var a = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(filePath)).Wedding;
            return a;
        }

        public void Save(StorableWedding wedding)
        {
            string folder = EnsureWeddingFolderFor(wedding.Id);

            File.WriteAllText(string.Format(@"{0}\{1}.data.json", WeddingFolder(wedding.Id), wedding.Id), JsonConvert.SerializeObject(wedding, Formatting.Indented));
            File.WriteAllText(string.Format(@"{0}\{1}.meta.json", WeddingFolder(wedding.Id), wedding.Id), JsonConvert.SerializeObject(MetadataFor(wedding), Formatting.Indented));
        }

        private KeyValuePair<string, string>[] MetadataFor(StorableWedding wedding)
        {
            return new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("Id", wedding.Id.ToString()),
                new KeyValuePair<string, string>("Bride", wedding.Wedding.Bride.ToString()),
                new KeyValuePair<string, string>("Groom", wedding.Wedding.Groom.ToString()),
            };
        }

        private string EnsureWeddingFolderFor(Guid id)
        {
            var weddingFolderPath = WeddingFolder(id);
            if (!Directory.Exists(weddingFolderPath))
            {
                Directory.CreateDirectory(weddingFolderPath);
            }
            return weddingFolderPath;
        }

        private string WeddingFolder(Guid id)
        {
            return string.Format(@"{0}\{1}", this.storageBasePath, id);
        }
    }
}
