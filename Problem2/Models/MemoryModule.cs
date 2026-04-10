using Problem2.Enums;

namespace Problem2.Models;

/// <summary>
/// Represents computer memory.
/// </summary>
public sealed class MemoryModule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MemoryModule"/> class.
    /// </summary>
    public MemoryModule(double readSpeedInMbPerSec, double writeSpeedInMbPerSec, MemoryType type, int amountInGb)
    {
        if (readSpeedInMbPerSec <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(readSpeedInMbPerSec), "Read speed must be greater than zero.");
        }

        if (writeSpeedInMbPerSec <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(writeSpeedInMbPerSec), "Write speed must be greater than zero.");
        }

        if (amountInGb <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amountInGb), "Memory amount must be greater than zero.");
        }

        ReadSpeedInMbPerSec = Math.Round(readSpeedInMbPerSec, 2);
        WriteSpeedInMbPerSec = Math.Round(writeSpeedInMbPerSec, 2);
        Type = type;
        AmountInGb = amountInGb;
    }

    public double ReadSpeedInMbPerSec { get; }

    public double WriteSpeedInMbPerSec { get; }

    public MemoryType Type { get; }

    public int AmountInGb { get; }
}
