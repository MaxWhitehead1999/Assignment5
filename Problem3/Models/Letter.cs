using Problem3.Enums;

namespace Problem3.Models;

/// <summary>
/// Represents a letter.
/// </summary>
public sealed class Letter : MailItem
{
    public Letter(
        MailParty sender,
        MailParty receiver,
        decimal postalCost,
        double weightInKg,
        bool isFlagged,
        int pageCount,
        string envelopeMaterial,
        bool hasReturnEnvelope)
        : base(sender, receiver, postalCost, weightInKg, isFlagged, MailKind.Letter)
    {
        if (pageCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageCount), "Page count must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(envelopeMaterial))
        {
            throw new ArgumentException("Envelope material is required.", nameof(envelopeMaterial));
        }

        PageCount = pageCount;
        EnvelopeMaterial = envelopeMaterial.Trim();
        HasReturnEnvelope = hasReturnEnvelope;
    }

    public int PageCount { get; }

    public string EnvelopeMaterial { get; }

    public bool HasReturnEnvelope { get; }
}
