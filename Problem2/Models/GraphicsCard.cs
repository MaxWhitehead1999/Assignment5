namespace Problem2.Models;

/// <summary>
/// Represents a graphics card.
/// </summary>
public sealed class GraphicsCard
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphicsCard"/> class.
    /// </summary>
    public GraphicsCard(int fanCount, double speedInGhz, int videoMemoryInGb, int cudaCoreCount)
    {
        if (fanCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(fanCount), "Fan count cannot be negative.");
        }

        if (speedInGhz <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speedInGhz), "Speed must be greater than zero.");
        }

        if (videoMemoryInGb <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(videoMemoryInGb), "Video memory must be greater than zero.");
        }

        if (cudaCoreCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cudaCoreCount), "CUDA core count cannot be negative.");
        }

        FanCount = fanCount;
        SpeedInGhz = Math.Round(speedInGhz, 2);
        VideoMemoryInGb = videoMemoryInGb;
        CudaCoreCount = cudaCoreCount;
    }

    public int FanCount { get; }

    public double SpeedInGhz { get; }

    public int VideoMemoryInGb { get; }

    public int CudaCoreCount { get; }
}
