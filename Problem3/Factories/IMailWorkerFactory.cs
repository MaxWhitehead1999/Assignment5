using Problem3.Enums;
using Problem3.Workers;

namespace Problem3.Factories;

/// <summary>
/// Defines a factory for creating mail workers.
/// </summary>
public interface IMailWorkerFactory
{
    IMailWorker CreateWorker(MailKind kind);
}
