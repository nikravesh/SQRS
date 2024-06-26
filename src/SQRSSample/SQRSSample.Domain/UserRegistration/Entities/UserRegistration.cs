﻿using System.Collections.Immutable;

using SQRSSample.Domain.Framework.Entity;
using SQRSSample.Domain.Framework.Exceptions;

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

    public static UserRegistration Create(
        string firstName,
        string lastName,
        string email,
        string password) => new(firstName, lastName, email, password);

    public static UserAddress AddUserAddress(string zipCode,
        string province,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone, UserRegistration user)
    {
        ArgumentNullException.ThrowIfNull($"{nameof(user.Id)} cannot be null!");

        UserAddress address = new(zipCode, province, city, buildingNo, phoneNumber, cellPhone);
        address.UserId = user.Id;

        return address;
    }

    public void UpdatePassword(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty($"{nameof(password)} cannot be null!");

        Password = password;
    }

    public void UpdateEmail(string email)
    {
        ArgumentException.ThrowIfNullOrEmpty($"{nameof(email)} cannot be null!");

        Email = email;
    }

    public void UpdateUserAddress(
        long userAddressId,
        string zipCode,
        string province,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone)
    {
        UserAddress? userAddress = _userAddresses.FirstOrDefault(x => x.Id == userAddressId);

        if (userAddress is null)
            throw new InvalidEntityStateException($"{nameof(userAddressId)} with value {userAddressId} not found!");

        if ((userAddress.PhoneNumber == phoneNumber || userAddress.CellPhone == cellPhone))
            throw new Exception($"user address for phone number : " +
                $"{phoneNumber} and cell phone numebr : {cellPhone} already exist!");

        userAddress.Update(zipCode, province, city, buildingNo, phoneNumber, cellPhone);
    }

    public void DeleteUserAddress(List<long> userAddressList)
    {
        List<UserAddress> prepareUserAddressToDelete = _userAddresses.Where(
            x => userAddressList.Any(u => u == x.Id)).ToList();

        prepareUserAddressToDelete.ForEach(x =>
        {
            _userAddresses.Remove(x);
        });
    }
}
