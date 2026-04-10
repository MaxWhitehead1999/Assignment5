namespace Problem4.Models;

/// <summary>
/// Represents a submitted bid.
/// </summary>
public sealed class Bid
{
    public Bid(string bidderName, decimal amount, DateTime timestampUtc)
    {
        if (string.IsNullOrWhiteSpace(bidderName))
        {
            throw new ArgumentException("Bidder name is required.", nameof(bidderName));
        }

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Bid amount must be greater than zero.");
        }

        BidderName = bidderName.Trim();
        Amount = decimal.Round(amount, 2);
        TimestampUtc = timestampUtc;
    }

    public string BidderName { get; }

    public decimal Amount { get; }

    public DateTime TimestampUtc { get; }
}
