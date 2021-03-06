﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class WeddingDto
    {
        public PersonDto Bride { get; private set; }
        public PersonDto Groom { get; private set; }

        public WeddingTaskDto[] Tasks { get; private set; }

        public WeddingEventDto[] Events { get; private set; }

        public WeddingGuestDto[] Guests { get; private set; }
    }
}