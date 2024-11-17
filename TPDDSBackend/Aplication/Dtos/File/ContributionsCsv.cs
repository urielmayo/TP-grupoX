namespace TPDDSBackend.Aplication.Dtos.File
{
    public class ContributionsCsv
    {
        public TipoDoc TipoDoc { get; set; }
        public long Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public DateTime FechaColaboracion { get; set; }
        public TypeContribution FormaColaboracion { get; set; }
    }
}
