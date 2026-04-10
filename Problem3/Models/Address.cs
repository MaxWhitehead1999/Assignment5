namespace Problem3.Models;

/// <summary>
/// Represents a postal address.
/// </summary>
public sealed class Address
{
    public Address(string street, string city, string provinceOrState, string postalCode)
    {
        Street = Validate(street, nameof(street));
        City = Validate(city, nameof(city));
        ProvinceOrState = Validate(provinceOrState, nameof(provinceOrState));
        PostalCode = Validate(postalCode, nameof(postalCode));
    }

    public string Street { get; }

    public string City { get; }

    public string ProvinceOrState { get; }

    public string PostalCode { get; }

    private static string Validate(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value is required.", paramName);
        }

        return value.Trim();
    }
}
