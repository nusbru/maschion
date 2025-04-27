using maschion.API.Domain;
using maschion.API.UseCases.SignIn;
using maschion.API.UseCases.SignUp;

namespace maschion.API.Infrastructure;

public interface ISupabaseRepository
{
    Task<(string, string)> SignIn(Credential credential);
    Task<Profile> SignUp(SupabaseProfile profile);
}