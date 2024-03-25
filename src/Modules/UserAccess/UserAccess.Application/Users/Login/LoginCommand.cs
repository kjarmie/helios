using System.Net.Mail;
using Common.Application.Abstractions.Messaging;

namespace UserAccess.Application.Users.Login;

public sealed record LoginCommand(MailAddress Email, string Password) : ICommand<LoginResponse>;