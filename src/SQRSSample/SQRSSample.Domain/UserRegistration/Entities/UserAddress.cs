using SQRSSample.Domain.Entity;

namespace SQRSSample.Domain.UserRegistration.Entities;

public class UserAddress : Entity<int>
{
    public string ZipCode { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string BuildingNo { get; private set; }
    public string PhoneNumber { get; private set; }
    public string CellPhone { get; private set; }

    private UserAddress() { }

    private UserAddress(
        string zipCode,
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

    public static UserAddress Create(
        string zipCode,
        string prvince,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone) => new(zipCode, prvince, city, buildingNo, phoneNumber, cellPhone);

    public void Update(
        string zipCode,
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
