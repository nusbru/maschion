using maschion.API.Common.Dtos;
using maschion.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace maschion.API.Features.SignIn;

public static class SignInHandler
{
    internal static async Task<IResult> Handle(
        [FromServices] ISupabaseRepository supabaseRepository,
        [FromBody] SignInRequest signInRequest)
    {
        var supabaseProfile = new Credential(signInRequest.Email, signInRequest.Password);
        var (token, refreshToken) = await supabaseRepository.SignIn(supabaseProfile);

        return Results.Ok(new SignInResponse(token, refreshToken));
    }
}
