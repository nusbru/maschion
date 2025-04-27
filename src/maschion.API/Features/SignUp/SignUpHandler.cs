using maschion.API.Data;
using maschion.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace maschion.API.Features.SignUp;

public static class SignUpHandler
{
    internal static async Task<IResult> Handle(MaschionDbContext ctx, [FromServices] ISupabaseRepository supabaseRepository, [FromBody] SignUpRequest signUpRequest)
    {
        var supabaseProfile = new SupabaseProfile(signUpRequest.Email, signUpRequest.Password);
        var profile = await supabaseRepository.SignUp(supabaseProfile);

        ctx.Profiles.Add(profile);

        ctx.SaveChanges();

        return Results.Ok(new SignUpResponse(profile.Email));
    }
}

