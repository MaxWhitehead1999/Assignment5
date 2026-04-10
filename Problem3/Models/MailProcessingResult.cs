namespace Problem3.Models;

/// <summary>
/// Represents the result of a worker processing a mail item.
/// </summary>
public sealed class MailProcessingResult
{
    public MailProcessingResult(MailItem mail, string mailboxCode, bool sentToReviewQueue, string workerName)
    {
        Mail = mail ?? throw new ArgumentNullException(nameof(mail));

        if (string.IsNullOrWhiteSpace(mailboxCode))
        {
            throw new ArgumentException("Mailbox code is required.", nameof(mailboxCode));
        }

        if (string.IsNullOrWhiteSpace(workerName))
        {
            throw new ArgumentException("Worker name is required.", nameof(workerName));
        }

        MailboxCode = mailboxCode.Trim();
        SentToReviewQueue = sentToReviewQueue;
        WorkerName = workerName.Trim();
    }

    public MailItem Mail { get; }

    public string MailboxCode { get; }

    public bool SentToReviewQueue { get; }

    public string WorkerName { get; }
}
