namespace Problem4.Models;

/// <summary>
/// Represents an item being auctioned.
/// </summary>
public sealed class AuctionItem
{
    public AuctionItem(string name, decimal startingBid, int yearOfCreation)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Item name is required.", nameof(name));
        }

        if (startingBid <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startingBid), "Starting bid must be greater than zero.");
        }

        var maximumYear = DateTime.UtcNow.Year;
        if (yearOfCreation < 0 || yearOfCreation > maximumYear)
        {
            throw new ArgumentOutOfRangeException(nameof(yearOfCreation), $"Year of creation must be between 0 and {maximumYear}.");
        }

        Name = name.Trim();
        StartingBid = decimal.Round(startingBid, 2);
        YearOfCreation = yearOfCreation;
    }

    public string Name { get; }

    public decimal StartingBid { get; }

    public int YearOfCreation { get; }
}
