﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Model
{
    public sealed class WeddingDto
    {
        public PersonDto Bride { get; set; }
        public PersonDto Groom { get; set; }

        public IReadOnlyList<WeddingTaskDto> Tasks { get; set; }
    }
}
