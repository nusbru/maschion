using maschion.API.Data;
using maschion.API.Infrastructure;
using maschion.API.UseCases.CreateNewCustomer;
using Microsoft.AspNetCore.Mvc;
namespace maschion.API.UseCases.SignUp;

public static class SignUpHandler
{
    internal static async Task<IResult> Handle(MaschionDbContext ctx, ISupabaseRepository supabaseRepository, [FromBody] SignUpRequest request)
    {
        var supabaseProfile = new SupabaseProfile(request.Email, request.Password);
        var profile = await supabaseRepository.SignUp(supabaseProfile);

        ctx.Profiles.Add(profile);

        ctx.SaveChanges();

        return Results.Ok(new SignUpResponse(profile.Email));
    }
}

public record SignUpResponse(string Email);

