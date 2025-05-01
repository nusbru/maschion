using maschion.API.Common.Dtos;
using maschion.API.Helpers.CQS;
using maschion.API.Infrastructure;

namespace maschion.API.Features.SignIn;

public class SignInQueryHandler(ISupabaseRepository supabaseRepository) : IQueryAsync<SignInQuery, SignInResult>
{
    public async Task<SignInResult> HandleAsync(SignInQuery query)
    {
        var supabaseProfile = new SupabaseCredential(query.Email, query.Password);
        var (token, refreshToken) = await supabaseRepository.SignIn(supabaseProfile);

        return new(token, refreshToken);
    }
}
