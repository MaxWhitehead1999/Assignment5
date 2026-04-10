using Problem4.Interfaces;
using Problem4.Models;

namespace Problem4.Services;

/// <summary>
/// Represents the auctioneer subject in the observer pattern.
/// </summary>
public sealed class Auctioneer
{
    private const int MaximumBidsPerItem = 5;
    private readonly List<IAuctionObserver> _observers = new();
    private readonly List<Bid> _bidHistory = new();
    private Bidder? _highestBidder;
    private int _bidCount;

    public AuctionItem? CurrentItem { get; private set; }

    public decimal CurrentPrice { get; private set; }

    public bool IsAuctionOpen { get; private set; }

    public int RegisteredBidderCount => _observers.Count;

    public IReadOnlyList<Bid> BidHistory => _bidHistory.AsReadOnly();

    public void RegisterBidder(Bidder bidder)
    {
        if (bidder is null)
        {
            throw new ArgumentNullException(nameof(bidder));
        }

        if (_observers.Contains(bidder))
        {
            return;
        }

        _observers.Add(bidder);
    }

    public void UnregisterBidder(Bidder bidder)
    {
        if (bidder is null)
        {
            throw new ArgumentNullException(nameof(bidder));
        }

        _observers.Remove(bidder);
    }

    public void StartAuction(AuctionItem item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (IsAuctionOpen)
        {
            throw new InvalidOperationException("An auction is already in progress.");
        }

        CurrentItem = item;
        CurrentPrice = item.StartingBid;
        IsAuctionOpen = true;
        _bidCount = 0;
        _bidHistory.Clear();
        _highestBidder = null;

        foreach (var observer in _observers)
        {
            observer.OnAuctionStarted(item);
        }
    }

    public void PlaceBid(Bidder bidder, decimal amount)
    {
        if (bidder is null)
        {
            throw new ArgumentNullException(nameof(bidder));
        }

        if (!IsAuctionOpen || CurrentItem is null)
        {
            throw new InvalidOperationException("No auction is currently active.");
        }

        if (!_observers.Contains(bidder))
        {
            throw new InvalidOperationException("Bidder must be registered before placing a bid.");
        }

        if (amount <= CurrentPrice)
        {
            throw new InvalidOperationException("Bid must be greater than the current price.");
        }

        if (amount > bidder.MaximumBidLimit)
        {
            throw new InvalidOperationException("Bid exceeds the bidder's maximum spending limit.");
        }

        _bidCount++;
        CurrentPrice = decimal.Round(amount, 2);
        _highestBidder = bidder;
        _bidHistory.Add(new Bid(bidder.Name, CurrentPrice, DateTime.UtcNow));

        foreach (var observer in _observers)
        {
            observer.OnCurrentBidChanged(CurrentItem, CurrentPrice, bidder.Name);
        }

        if (_bidCount >= MaximumBidsPerItem)
        {
            CloseAuctionInternal();
        }
    }

    public void CloseAuction()
    {
        if (!IsAuctionOpen)
        {
            throw new InvalidOperationException("There is no active auction to close.");
        }

        CloseAuctionInternal();
    }

    private void CloseAuctionInternal()
    {
        if (CurrentItem is null)
        {
            throw new InvalidOperationException("There is no current item to close.");
        }

        var item = CurrentItem;
        var winnerName = _highestBidder?.Name;
        var finalBid = CurrentPrice;

        IsAuctionOpen = false;

        foreach (var observer in _observers.ToArray())
        {
            observer.OnAuctionClosed(item, winnerName, finalBid);
        }

        if (_highestBidder is not null)
        {
            _highestBidder.ReceiveItem(item);
            UnregisterBidder(_highestBidder);
        }

        CurrentItem = null;
        _highestBidder = null;
        _bidCount = 0;
    }
}
