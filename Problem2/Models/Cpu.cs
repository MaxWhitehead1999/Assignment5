using Problem2.Enums;

namespace Problem2.Models;

/// <summary>
/// Represents a CPU.
/// </summary>
public sealed class Cpu
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Cpu"/> class.
    /// </summary>
    public Cpu(double speedInGhz, CpuManufacturer manufacturer, string socketType, double cacheSizeInMb, int coreCount)
    {
        if (speedInGhz <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speedInGhz), "CPU speed must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(socketType))
        {
            throw new ArgumentException("Socket type is required.", nameof(socketType));
        }

        if (cacheSizeInMb < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cacheSizeInMb), "Cache size cannot be negative.");
        }

        if (coreCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(coreCount), "Core count must be greater than zero.");
        }

        SpeedInGhz = Math.Round(speedInGhz, 2);
        Manufacturer = manufacturer;
        SocketType = socketType.Trim();
        CacheSizeInMb = Math.Round(cacheSizeInMb, 2);
        CoreCount = coreCount;
    }

    public double SpeedInGhz { get; }

    public CpuManufacturer Manufacturer { get; }

    public string SocketType { get; }

    public double CacheSizeInMb { get; }

    public int CoreCount { get; }
}
