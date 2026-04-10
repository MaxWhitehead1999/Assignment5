namespace Problem3.Models;

/// <summary>
/// Represents a sender or receiver for a mail item.
/// </summary>
public sealed class MailParty
{
    public MailParty(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.", nameof(name));
        }

        Name = name.Trim();
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public string Name { get; }

    public Address Address { get; }
}
