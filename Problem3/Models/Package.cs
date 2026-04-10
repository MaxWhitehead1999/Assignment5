using Problem3.Enums;

namespace Problem3.Models;

/// <summary>
/// Represents a package.
/// </summary>
public sealed class Package : MailItem
{
    public Package(
        MailParty sender,
        MailParty receiver,
        decimal postalCost,
        double weightInKg,
        bool isFlagged,
        double lengthInCm,
        double widthInCm,
        double heightInCm,
        bool requiresSignature)
        : base(sender, receiver, postalCost, weightInKg, isFlagged, MailKind.Package)
    {
        if (lengthInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lengthInCm), "Length must be greater than zero.");
        }

        if (widthInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(widthInCm), "Width must be greater than zero.");
        }

        if (heightInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(heightInCm), "Height must be greater than zero.");
        }

        LengthInCm = Math.Round(lengthInCm, 2);
        WidthInCm = Math.Round(widthInCm, 2);
        HeightInCm = Math.Round(heightInCm, 2);
        RequiresSignature = requiresSignature;
    }

    public double LengthInCm { get; }

    public double WidthInCm { get; }

    public double HeightInCm { get; }

    public bool RequiresSignature { get; }
}
