using SQRSSample.Domain.Framework.Entity;

namespace SQRSSample.Domain.UserRegistration.Entities;

public class UserAddress : Entity<int>
{
    public long UserId { get; internal set; }
    public string ZipCode { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string BuildingNo { get; private set; }
    public string PhoneNumber { get; private set; }
    public string CellPhone { get; private set; }

    private UserAddress() { }

    internal UserAddress(
        string zipCode,
        string province,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone)
    {
        if (IsZipCodeNull(zipCode) ||
            IsProvinceNull(province) ||
            IsCityNull(city) ||
            IsBuildingNoNull(buildingNo) ||
            IsPhoneNumberNull(phoneNumber))
            RaiseArgumentException(nameof(zipCode));

        ZipCode = zipCode;
        Province = province;
        City = city;
        BuildingNo = buildingNo;
        PhoneNumber = phoneNumber;
        CellPhone = cellPhone;
    }

    internal void Update(
        string zipCode,
        string province,
        string city,
        string buildingNo,
        string phoneNumber,
        string cellPhone)
    {
        if (IsZipCodeNull(zipCode) ||
            IsProvinceNull(province) ||
            IsCityNull(city) ||
            IsBuildingNoNull(buildingNo) ||
            IsPhoneNumberNull(phoneNumber))
            RaiseArgumentException(nameof(zipCode));

        ZipCode = zipCode;
        Province = province;
        City = city;
        BuildingNo = buildingNo;
        PhoneNumber = phoneNumber;
        CellPhone = cellPhone;
    }

    private bool IsZipCodeNull(string zipCode)
    {
        if (string.IsNullOrEmpty(zipCode)) return true;
        return false;
    }

    private bool IsProvinceNull(string province)
    {
        if (string.IsNullOrEmpty(province)) return true;
        return false;
    }

    private bool IsCityNull(string city)
    {
        if (string.IsNullOrEmpty(city)) return true;
        return false;
    }

    private bool IsBuildingNoNull(string buildingNo)
    {
        if (string.IsNullOrEmpty(buildingNo)) return true;
        return false;
    }

    private bool IsPhoneNumberNull(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) return true;
        return false;
    }

    private void RaiseArgumentException(string arg)
    {
        ArgumentException.ThrowIfNullOrEmpty($"{nameof(arg)} cannot be null or empty!");
    }
}
