﻿using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class Benefit: Contribution
    {
        public string Description { get; set; }

        public string Category { get; set; }

        public decimal RequiredPoints { get; set; }

        public string ImagePath {  get; set; }

    }
}
