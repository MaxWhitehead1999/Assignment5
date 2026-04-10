using Problem2.Enums;

namespace Problem2.Models;

/// <summary>
/// Represents a hard drive.
/// </summary>
public sealed class HardDrive
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HardDrive"/> class.
    /// </summary>
    public HardDrive(double capacityInGb, HardDriveInterfaceType interfaceType, double readSpeedInMbPerSec, double writeSpeedInMbPerSec)
    {
        if (capacityInGb <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacityInGb), "Capacity must be greater than zero.");
        }

        if (readSpeedInMbPerSec <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(readSpeedInMbPerSec), "Read speed must be greater than zero.");
        }

        if (writeSpeedInMbPerSec <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(writeSpeedInMbPerSec), "Write speed must be greater than zero.");
        }

        CapacityInGb = Math.Round(capacityInGb, 2);
        InterfaceType = interfaceType;
        ReadSpeedInMbPerSec = Math.Round(readSpeedInMbPerSec, 2);
        WriteSpeedInMbPerSec = Math.Round(writeSpeedInMbPerSec, 2);
    }

    public double CapacityInGb { get; }

    public HardDriveInterfaceType InterfaceType { get; }

    public double ReadSpeedInMbPerSec { get; }

    public double WriteSpeedInMbPerSec { get; }
}
