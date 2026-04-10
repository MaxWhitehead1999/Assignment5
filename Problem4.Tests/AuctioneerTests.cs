using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem4.Models;
using Problem4.Services;

namespace Problem4.Tests;

[TestClass]
public class AuctioneerTests
{
    [TestMethod]
    public void StartAuction_RegisteredBiddersReceiveAnnouncement()
    {
        var auctioneer = new Auctioneer();
        var bidder = new Bidder("Alice", 500);

        auctioneer.RegisterBidder(bidder);
        auctioneer.StartAuction(new AuctionItem("Vintage Lamp", 50, 1998));

        Assert.AreEqual(1, bidder.Notifications.Count);
        StringAssert.Contains(bidder.Notifications[0], "Auction started");
    }

    [TestMethod]
    public void PlaceBid_OverMaximumLimit_ThrowsInvalidOperationException()
    {
        var auctioneer = new Auctioneer();
        var bidder = new Bidder("Ben", 100);
        auctioneer.RegisterBidder(bidder);
        auctioneer.StartAuction(new AuctionItem("Rare Book", 40, 1985));

        Assert.ThrowsException<InvalidOperationException>(() => auctioneer.PlaceBid(bidder, 150));
    }

    [TestMethod]
    public void PlaceBid_FifthBidClosesAuctionAndAwardsItem()
    {
        var auctioneer = new Auctioneer();
        var bidderA = new Bidder("Alice", 500);
        var bidderB = new Bidder("Bob", 500);

        auctioneer.RegisterBidder(bidderA);
        auctioneer.RegisterBidder(bidderB);
        auctioneer.StartAuction(new AuctionItem("Antique Clock", 100, 1975));

        auctioneer.PlaceBid(bidderA, 110);
        auctioneer.PlaceBid(bidderB, 120);
        auctioneer.PlaceBid(bidderA, 130);
        auctioneer.PlaceBid(bidderB, 140);
        auctioneer.PlaceBid(bidderA, 150);

        Assert.IsFalse(auctioneer.IsAuctionOpen);
        Assert.AreEqual(1, bidderA.WonItems.Count);
        Assert.AreEqual(1, auctioneer.RegisteredBidderCount);
    }

    [TestMethod]
    public void PlaceBid_UnregisteredBidder_ThrowsInvalidOperationException()
    {
        var auctioneer = new Auctioneer();
        var registeredBidder = new Bidder("Registered", 500);
        var unregisteredBidder = new Bidder("Guest", 500);

        auctioneer.RegisterBidder(registeredBidder);
        auctioneer.StartAuction(new AuctionItem("Collector Plate", 25, 2005));

        Assert.ThrowsException<InvalidOperationException>(() => auctioneer.PlaceBid(unregisteredBidder, 30));
    }
}
