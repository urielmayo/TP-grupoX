﻿namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateBenefitRequest
    {
        public string Description { get; set; }

        public string Category { get; set; }

        public decimal RequiredPoints { get; set; }

        public required string ImagePath {  get; set; }
    }
}
