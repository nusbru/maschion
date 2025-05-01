using maschion.API.Helpers.CQS;

namespace maschion.API.Features.SignUp;

public record SignUpCommand(string Name, string Email, string Password, string PhoneNumber) : ICommand;

