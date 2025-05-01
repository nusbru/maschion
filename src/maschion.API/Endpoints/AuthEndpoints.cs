using maschion.API.Common.Dtos;
using maschion.API.Features.SignIn;
using maschion.API.Features.SignUp;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace maschion.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/SignUp", SignUpHandler);
        app.MapPost("/SignIn", SignInHandler);
    }

    internal static async Task<IResult> SignInHandler([FromServices] SignInQueryHandler query, [FromBody] SignInRequest signInRequest)
    {
        var q = new SignInQuery(signInRequest.Email, signInRequest.Password);
        var result = await query.HandleAsync(q);

        return result is null ? Results.BadRequest() : Results.Ok(new SignInResponse(result.Token, result.RefreshToken));
    }

    internal static async Task<IResult> SignUpHandler([FromServices] SignUpCommandHandler command, [FromBody] SignUpRequest signUpRequest)
    {
        var cmd = new SignUpCommand(signUpRequest.Name, signUpRequest.Email, signUpRequest.Password, signUpRequest.PhoneNumber);
        await command.HandleAsync(cmd);

        return Results.Ok(new SignUpResponse(cmd.Email));
    }
}
