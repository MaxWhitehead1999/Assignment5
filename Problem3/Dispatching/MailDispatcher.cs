using System.Collections.Concurrent;
using Problem3.Enums;
using Problem3.Factories;
using Problem3.Models;
using Problem3.Workers;

namespace Problem3.Dispatching;

/// <summary>
/// Reactor-style dispatcher that accepts incoming mail requests and routes them to workers.
/// </summary>
public sealed class MailDispatcher
{
    private readonly IMailWorkerFactory _workerFactory;
    private readonly ConcurrentQueue<MailItem> _incomingMail = new();
    private readonly ConcurrentQueue<MailItem> _reviewQueue = new();
    private readonly List<IMailWorker> _workers = new();
    private readonly object _syncRoot = new();

    public MailDispatcher(IMailWorkerFactory workerFactory)
    {
        _workerFactory = workerFactory ?? throw new ArgumentNullException(nameof(workerFactory));
    }

    public int PendingMailCount => _incomingMail.Count;

    public int ReviewQueueCount => _reviewQueue.Count;

    public int WorkerCount
    {
        get
        {
            lock (_syncRoot)
            {
                return _workers.Count;
            }
        }
    }

    public IReadOnlyCollection<MailItem> ReviewQueue => _reviewQueue.ToArray();

    public void RegisterWorker(IMailWorker worker)
    {
        if (worker is null)
        {
            throw new ArgumentNullException(nameof(worker));
        }

        lock (_syncRoot)
        {
            _workers.Add(worker);
        }
    }

    public bool UnregisterWorker(string workerName)
    {
        if (string.IsNullOrWhiteSpace(workerName))
        {
            throw new ArgumentException("Worker name is required.", nameof(workerName));
        }

        lock (_syncRoot)
        {
            var worker = _workers.FirstOrDefault(w => string.Equals(w.WorkerName, workerName.Trim(), StringComparison.OrdinalIgnoreCase));
            if (worker is null)
            {
                return false;
            }

            return _workers.Remove(worker);
        }
    }

    public void EnqueueMail(MailItem mail)
    {
        if (mail is null)
        {
            throw new ArgumentNullException(nameof(mail));
        }

        _incomingMail.Enqueue(mail);
    }

    public async Task<IReadOnlyCollection<MailProcessingResult>> DispatchAllAsync(CancellationToken cancellationToken = default)
    {
        var tasks = new List<Task<MailProcessingResult>>();

        while (_incomingMail.TryDequeue(out MailItem? mail))
        {
            cancellationToken.ThrowIfCancellationRequested();
            var worker = AcquireWorker(mail.Kind);
            tasks.Add(DispatchWithWorkerAsync(worker, mail, cancellationToken));
        }

        if (tasks.Count == 0)
        {
            return Array.Empty<MailProcessingResult>();
        }

        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    private IMailWorker AcquireWorker(MailKind kind)
    {
        lock (_syncRoot)
        {
            foreach (var worker in _workers.Where(w => w.HandledKind == kind))
            {
                if (worker.TryReserve())
                {
                    return worker;
                }
            }

            var newWorker = _workerFactory.CreateWorker(kind);
            if (!newWorker.TryReserve())
            {
                throw new InvalidOperationException("A newly created worker could not be reserved.");
            }

            _workers.Add(newWorker);
            return newWorker;
        }
    }

    private async Task<MailProcessingResult> DispatchWithWorkerAsync(IMailWorker worker, MailItem mail, CancellationToken cancellationToken)
    {
        try
        {
            var result = await worker.ProcessReservedAsync(mail, cancellationToken).ConfigureAwait(false);
            if (result.SentToReviewQueue)
            {
                _reviewQueue.Enqueue(mail);
            }

            return result;
        }
        finally
        {
            worker.Release();
        }
    }
}
