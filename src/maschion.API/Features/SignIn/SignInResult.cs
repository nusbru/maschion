using maschion.API.Helpers.CQS;

namespace maschion.API.Features.SignIn;

public record SignInResult(string Token, string RefreshToken) : IQueryResult;