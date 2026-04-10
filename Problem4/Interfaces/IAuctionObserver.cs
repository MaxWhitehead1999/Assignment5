using Problem4.Models;

namespace Problem4.Interfaces;

/// <summary>
/// Defines observer methods used by the auctioneer to broadcast updates.
/// </summary>
public interface IAuctionObserver
{
    void OnAuctionStarted(AuctionItem item);

    void OnCurrentBidChanged(AuctionItem item, decimal currentBid, string highestBidderName);

    void OnAuctionClosed(AuctionItem item, string? winnerName, decimal finalBid);
}
