using maschion.API.Features.SignIn;
using maschion.API.Features.SignUp;

namespace maschion.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/SignUp", SignUpHandler.Handle);
        app.MapPost("/SignIn", SignInHandler.Handle);
    }
}
