using maschion.API.Helpers.CQS;

namespace maschion.API.Features.SignIn;

public record SignInQuery(string Email, string Password) : IQuery;
