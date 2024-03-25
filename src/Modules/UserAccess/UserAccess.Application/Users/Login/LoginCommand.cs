using System.Net.Mail;
using Common.Application.Abstractions.Messaging;
using Common.Domain.ValueObjects;

namespace UserAccess.Application.Users.Login;

public sealed record LoginCommand(Email Email, Password Password) : ICommand<LoginResponse>;