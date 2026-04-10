using Problem3.Enums;
using Problem3.Models;

namespace Problem3.Workers;

/// <summary>
/// Handles letters.
/// </summary>
public sealed class LetterWorker : MailWorkerBase
{
    public LetterWorker(string workerName)
        : base(workerName, MailKind.Letter)
    {
    }

    protected override string DetermineMailbox(MailItem mail)
    {
        char initial = char.ToUpperInvariant(mail.Receiver.Name[0]);

        return initial switch
        {
            >= 'A' and <= 'I' => "LTR-AI",
            >= 'J' and <= 'R' => "LTR-JR",
            _ => "LTR-SZ"
        };
    }
}
