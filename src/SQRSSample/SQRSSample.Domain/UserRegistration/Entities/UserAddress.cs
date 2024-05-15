using SQRSSample.Domain.Entity;

namespace SQRSSample.Domain.UserRegistration.Entities;

public class UserAddress : Entity<int>
{
    public uint ZipCode { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string BuildingNo { get; private set; }
    public string PhoneNumber { get; private set; }
    public string CellPhone { get; private set; }

    private UserAddress() { }

    public UserAddress(
        uint zipCode,
        string prvince,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone)
    {
        ZipCode = zipCode;
        Province = prvince;
        City = city;
        BuildingNo = buildingNo; 
        PhoneNumber = phoneNumber;
        CellPhone = cellPhone;
    }
}
