using Problem3.Enums;

namespace Problem3.Models;

/// <summary>
/// Represents common mail data.
/// </summary>
public abstract class MailItem
{
    protected MailItem(MailParty sender, MailParty receiver, decimal postalCost, double weightInKg, bool isFlagged, MailKind kind)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
        Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));

        if (postalCost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(postalCost), "Postal cost cannot be negative.");
        }

        if (weightInKg <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weightInKg), "Weight must be greater than zero.");
        }

        PostalCost = decimal.Round(postalCost, 2);
        WeightInKg = Math.Round(weightInKg, 2);
        IsFlagged = isFlagged;
        Kind = kind;
    }

    public MailParty Sender { get; }

    public MailParty Receiver { get; }

    public decimal PostalCost { get; }

    public double WeightInKg { get; }

    public bool IsFlagged { get; }

    public MailKind Kind { get; }
}
