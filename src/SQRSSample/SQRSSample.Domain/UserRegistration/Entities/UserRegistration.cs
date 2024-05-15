using System.Collections.Immutable;

using SQRSSample.Domain.Entity;

namespace SQRSSample.Domain.UserRegistration.Entities;
public class UserRegistration : AggregateRoot<int>
{
    public string FirstName { get; private set; }    

    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public IReadOnlyList<UserAddress> UserAddresses => _userAddresses.ToImmutableList();
    private List<UserAddress> _userAddresses => new();

    private UserRegistration() { }

    private UserRegistration(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}
