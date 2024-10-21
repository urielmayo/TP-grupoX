﻿namespace TPDDSBackend.Domain.Entitites
{
    public class Technician : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdDocumentType { get; set; }
        public DocumentType DocumentType { get; set; }
        public string IdNumber { get; set; }
        public string  WorkerIdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int NeighborhoodId {  get; set; }
        public Neighborhood CoverageArea {  get; set; }
    }
}
