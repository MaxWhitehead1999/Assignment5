namespace Problem2.Models;

/// <summary>
/// Represents a computer case.
/// </summary>
public sealed class ComputerCase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComputerCase"/> class.
    /// </summary>
    public ComputerCase(double lengthInCm, double widthInCm, double heightInCm, int fanCount, int ventCount)
    {
        if (lengthInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lengthInCm), "Length must be greater than zero.");
        }

        if (widthInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(widthInCm), "Width must be greater than zero.");
        }

        if (heightInCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(heightInCm), "Height must be greater than zero.");
        }

        if (fanCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(fanCount), "Fan count cannot be negative.");
        }

        if (ventCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(ventCount), "Vent count cannot be negative.");
        }

        LengthInCm = Math.Round(lengthInCm, 2);
        WidthInCm = Math.Round(widthInCm, 2);
        HeightInCm = Math.Round(heightInCm, 2);
        FanCount = fanCount;
        VentCount = ventCount;
    }

    public double LengthInCm { get; }

    public double WidthInCm { get; }

    public double HeightInCm { get; }

    public int FanCount { get; }

    public int VentCount { get; }
}
