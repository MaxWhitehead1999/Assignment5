using System.Threading;
using Problem3.Enums;
using Problem3.Models;

namespace Problem3.Workers;

/// <summary>
/// Provides shared worker functionality.
/// </summary>
public abstract class MailWorkerBase : IMailWorker
{
    private int _busy;

    protected MailWorkerBase(string workerName, MailKind handledKind)
    {
        if (string.IsNullOrWhiteSpace(workerName))
        {
            throw new ArgumentException("Worker name is required.", nameof(workerName));
        }

        WorkerName = workerName.Trim();
        HandledKind = handledKind;
    }

    public string WorkerName { get; }

    public MailKind HandledKind { get; }

    public bool IsBusy => Volatile.Read(ref _busy) == 1;

    public bool TryReserve()
    {
        return Interlocked.CompareExchange(ref _busy, 1, 0) == 0;
    }

    public async Task<MailProcessingResult> ProcessReservedAsync(MailItem mail, CancellationToken cancellationToken = default)
    {
        if (mail is null)
        {
            throw new ArgumentNullException(nameof(mail));
        }

        if (mail.Kind != HandledKind)
        {
            throw new InvalidOperationException($"{WorkerName} cannot process mail of type {mail.Kind}.");
        }

        cancellationToken.ThrowIfCancellationRequested();
        await Task.Yield();

        var mailboxCode = DetermineMailbox(mail);
        return new MailProcessingResult(mail, mailboxCode, mail.IsFlagged, WorkerName);
    }

    public void Release()
    {
        Interlocked.Exchange(ref _busy, 0);
    }

    protected abstract string DetermineMailbox(MailItem mail);
}
