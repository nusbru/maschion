using System;

namespace maschion.API.Common.Dtos;

public record SignUpRequest(string Name, string Email, string Password, string PhoneNumber);

