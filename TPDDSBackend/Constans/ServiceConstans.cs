namespace TPDDSBackend.Constans
{
    public static class ServiceConstans
    {
        public const string MessageSucceded = "Se ha realizado exito";
        public const string MessageSuccessDonation = "Se ha realizado con exito la donacion";
        public const string UpdateDeniedMessage = "Solo puedes actualizar tus contribuciones";
        public const string UpdateDeniedMessageByExpires = "Ya no puede realizar esta accion";
        public const string AddressRequiredMessage = "El colaborador debe tener una direccion registrada";

        public const string StateFoodAvailable = "Disponible";
        public const string StatusFoodExpired = "Vencida";
        public const string StatusFoodDelivered = "Entregada";
        
        public const int RequestExpirationInHours = 3;
    }
}
