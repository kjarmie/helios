using System.Net.Mail;
using Common.Domain;
using Common.Domain.ValueObjects;

namespace UserAccess.Domain.User;

public class User : IUserEntity
{
    public UserId UserId { get; set; }
    public Name FirstName { get; set; }
    public Name LastName { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }

    public User Create(Name firsName, Name lastname, Email email, Password password)
    {

    }
}