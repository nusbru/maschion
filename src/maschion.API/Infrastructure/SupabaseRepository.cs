using maschion.API.Common.Dtos;
using maschion.API.Domain;
using maschion.API.Features.SignUp;

namespace maschion.API.Infrastructure;

public class SupabaseRepository(Supabase.Client client) : ISupabaseRepository
{
    public async Task<(string, string)> SignIn(SupabaseCredential credential)
    {
        var session = await client.Auth.SignIn(credential.Email, credential.Password);

        if (session is null || session.User is null)
            throw new Exception();
        return new(session.AccessToken ?? string.Empty, session.RefreshToken ?? string.Empty);
    }

    public async Task<Profile> SignUp(SupabaseProfile profile)
    {
        var session = await client.Auth.SignUp(profile.Email, profile.Password);

        if (session is null || session.User is null)
            throw new Exception();

        var user = session.User;

        return new Profile
        {
            Name = user.Email!,
            Email = user.Email!,
            PhoneNumber = string.Empty
        };
    }
}
