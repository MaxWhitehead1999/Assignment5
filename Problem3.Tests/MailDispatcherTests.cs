using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem3.Dispatching;
using Problem3.Factories;
using Problem3.Models;
using Problem3.Workers;

namespace Problem3.Tests;

[TestClass]
public class MailDispatcherTests
{
    [TestMethod]
    public async Task DispatchAllAsync_FlaggedLetter_AddsMailToReviewQueue()
    {
        var dispatcher = new MailDispatcher(new MailWorkerFactory());
        dispatcher.RegisterWorker(new LetterWorker("LetterWorker-Seed"));

        var letter = new Letter(
            CreateParty("Alice"),
            CreateParty("Brandon"),
            1.99m,
            0.1,
            true,
            2,
            "Paper",
            false);

        dispatcher.EnqueueMail(letter);
        var results = await dispatcher.DispatchAllAsync();

        Assert.AreEqual(1, results.Count);
        Assert.AreEqual(1, dispatcher.ReviewQueueCount);
    }

    [TestMethod]
    public async Task DispatchAllAsync_UnflaggedPackage_ReturnsPackageMailbox()
    {
        var dispatcher = new MailDispatcher(new MailWorkerFactory());
        dispatcher.RegisterWorker(new PackageWorker("PackageWorker-Seed"));

        var package = new Package(
            CreateParty("Sender"),
            CreateParty("Zelda"),
            8.75m,
            11.5,
            false,
            25,
            18,
            12,
            true);

        dispatcher.EnqueueMail(package);
        var results = await dispatcher.DispatchAllAsync();
        var result = results.Single();

        Assert.AreEqual("PKG-HEAVY", result.MailboxCode);
        Assert.IsFalse(result.SentToReviewQueue);
    }

    [TestMethod]
    public async Task DispatchAllAsync_WhenExistingWorkerIsBusy_ScalesOutAdditionalWorkers()
    {
        var dispatcher = new MailDispatcher(new MailWorkerFactory());
        dispatcher.RegisterWorker(new LetterWorker("LetterWorker-Seed"));

        dispatcher.EnqueueMail(new Letter(CreateParty("A"), CreateParty("B"), 1.10m, 0.1, false, 1, "Paper", false));
        dispatcher.EnqueueMail(new Letter(CreateParty("C"), CreateParty("D"), 1.10m, 0.1, false, 1, "Paper", false));

        var results = await dispatcher.DispatchAllAsync();

        Assert.AreEqual(2, results.Count);
        Assert.AreEqual(2, dispatcher.WorkerCount);
    }

    [TestMethod]
    public void EnqueueMail_WithNullMail_ThrowsArgumentNullException()
    {
        var dispatcher = new MailDispatcher(new MailWorkerFactory());

        Assert.ThrowsException<ArgumentNullException>(() => dispatcher.EnqueueMail(null!));
    }

    private static MailParty CreateParty(string name)
    {
        return new MailParty(
            name,
            new Address("123 Main St", "Hamilton", "ON", "L8P 1A1"));
    }
}
