using Common.Domain.ValueObjects;

namespace UserAccess.Endpoints.Users.Login;

public sealed record LoginRequest(string Email, string Password);