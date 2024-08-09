using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Validators
{
    public class CommonPasswordValidator : IPasswordValidator<Collaborator>
    {
        private readonly HashSet<string> _commonPasswords;

        public CommonPasswordValidator()
        {
            // Cargar lista de contraseñas comunes desde un archivo o base de datos
            _commonPasswords = new HashSet<string>(File.ReadAllLines("10-million-password-list-top-10000.txt"));
        }

        public Task<IdentityResult> ValidateAsync(UserManager<Collaborator> manager, Collaborator user, string password)
        {
            if (_commonPasswords.Contains(password))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "CommonPassword",
                    Description = "The password you chose is too common."
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
