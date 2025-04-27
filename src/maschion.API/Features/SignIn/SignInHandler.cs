using maschion.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace maschion.API.UseCases.SignIn;

public static class SignInHandler
{
    internal static async Task<IResult> Handle(SupabaseRepository supabaseRepository, [FromBody] SignInRequest request)
    {
        var supabaseProfile = new Credential(request.Email, request.Password);
        var (token, refreshToken) = await supabaseRepository.SignIn(supabaseProfile);

        return Results.Ok(new SignInResponse(token, refreshToken));
    }
}

public record SignInResponse(string Token, string RefreshToken);
