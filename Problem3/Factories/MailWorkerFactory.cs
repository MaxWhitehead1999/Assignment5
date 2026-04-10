using Problem3.Enums;
using Problem3.Workers;

namespace Problem3.Factories;

/// <summary>
/// Creates workers on demand when volume increases.
/// </summary>
public sealed class MailWorkerFactory : IMailWorkerFactory
{
    private int _letterWorkerCount;
    private int _packageWorkerCount;

    public IMailWorker CreateWorker(MailKind kind)
    {
        return kind switch
        {
            MailKind.Letter => new LetterWorker($"LetterWorker-{++_letterWorkerCount}"),
            MailKind.Package => new PackageWorker($"PackageWorker-{++_packageWorkerCount}"),
            _ => throw new ArgumentOutOfRangeException(nameof(kind), "Unsupported mail kind.")
        };
    }
}
