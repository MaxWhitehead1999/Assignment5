using Problem3.Enums;
using Problem3.Models;

namespace Problem3.Workers;

/// <summary>
/// Defines a worker capable of handling a mail request.
/// </summary>
public interface IMailWorker
{
    string WorkerName { get; }

    MailKind HandledKind { get; }

    bool IsBusy { get; }

    bool TryReserve();

    Task<MailProcessingResult> ProcessReservedAsync(MailItem mail, CancellationToken cancellationToken = default);

    void Release();
}
