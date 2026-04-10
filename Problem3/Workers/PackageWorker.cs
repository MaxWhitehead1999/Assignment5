using Problem3.Enums;
using Problem3.Models;

namespace Problem3.Workers;

/// <summary>
/// Handles packages.
/// </summary>
public sealed class PackageWorker : MailWorkerBase
{
    public PackageWorker(string workerName)
        : base(workerName, MailKind.Package)
    {
    }

    protected override string DetermineMailbox(MailItem mail)
    {
        return mail.WeightInKg switch
        {
            <= 2 => "PKG-LIGHT",
            <= 10 => "PKG-MEDIUM",
            _ => "PKG-HEAVY"
        };
    }
}
