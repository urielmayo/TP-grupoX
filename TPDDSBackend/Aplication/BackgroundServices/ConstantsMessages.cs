using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Telegram.Bot.Types;

namespace TPDDSBackend.Aplication.BackgroundServices
{
    public static class ConstantsMessages
    {
        public const string UnauthenticatedUserMessage = "🔒 Por favor, autentícate para usar el bot.\n" +
                                         "Envía el comando: /autenticar seguido de tu nombre y número de trabajador.\n\n" +
                                         "Por ejemplo: /autenticar Juan 12345 ✏️";
    }
}
