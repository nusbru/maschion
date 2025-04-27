using maschion.API.Common.Dtos;
using maschion.API.Domain;
using maschion.API.Features.SignUp;

namespace maschion.API.Infrastructure;

public interface ISupabaseRepository
{
    Task<(string, string)> SignIn(Credential credential);
    Task<Profile> SignUp(SupabaseProfile profile);
}