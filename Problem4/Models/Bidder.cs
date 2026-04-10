using Problem4.Interfaces;
using Problem4.Services;

namespace Problem4.Models;

/// <summary>
/// Represents a bidder in the auction system.
/// </summary>
public sealed class Bidder : IAuctionObserver
{
    private readonly List<string> _notifications = new();
    private readonly List<AuctionItem> _wonItems = new();

    public Bidder(string name, decimal maximumBidLimit)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Bidder name is required.", nameof(name));
        }

        if (maximumBidLimit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumBidLimit), "Maximum bid limit must be greater than zero.");
        }

        Name = name.Trim();
        MaximumBidLimit = decimal.Round(maximumBidLimit, 2);
    }

    public string Name { get; }

    public decimal MaximumBidLimit { get; }

    public IReadOnlyList<string> Notifications => _notifications.AsReadOnly();

    public IReadOnlyList<AuctionItem> WonItems => _wonItems.AsReadOnly();

    public void PlaceBid(Auctioneer auctioneer, decimal amount)
    {
        if (auctioneer is null)
        {
            throw new ArgumentNullException(nameof(auctioneer));
        }

        auctioneer.PlaceBid(this, amount);
    }

    public void OnAuctionStarted(AuctionItem item)
    {
        _notifications.Add($"Auction started for {item.Name} at {item.StartingBid:C}.");
    }

    public void OnCurrentBidChanged(AuctionItem item, decimal currentBid, string highestBidderName)
    {
        _notifications.Add($"Current bid for {item.Name}: {currentBid:C} by {highestBidderName}.");
    }

    public void OnAuctionClosed(AuctionItem item, string? winnerName, decimal finalBid)
    {
        var winnerText = winnerName ?? "No winner";
        _notifications.Add($"Auction closed for {item.Name}. Winner: {winnerText} at {finalBid:C}.");
    }

    internal void ReceiveItem(AuctionItem item)
    {
        _wonItems.Add(item);
    }
}
