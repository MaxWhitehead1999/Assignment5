namespace Problem2.Models;

/// <summary>
/// Represents the completed computer product.
/// </summary>
public sealed class Computer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Computer"/> class.
    /// </summary>
    public Computer(HardDrive hardDrive, Motherboard motherboard, ComputerCase @case)
    {
        HardDrive = hardDrive ?? throw new ArgumentNullException(nameof(hardDrive));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        Case = @case ?? throw new ArgumentNullException(nameof(@case));
    }

    public HardDrive HardDrive { get; }

    public Motherboard Motherboard { get; }

    public ComputerCase Case { get; }
}
