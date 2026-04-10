using Problem1.Enums;

namespace Problem1.Models;

/// <summary>
/// Represents a rainbow stacker toy.
/// </summary>
public sealed class RainbowStacker : Toy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RainbowStacker"/> class.
    /// </summary>
    public RainbowStacker(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int ringCount,
        double largestRingDiameterCm,
        bool hasRoundedBase)
        : base(price, ToyCategory.Educational, name, brand, yearOfManufacture, minimumAgeLimit, hasChokingHazard, weight)
    {
        if (ringCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(ringCount), "Ring count must be greater than zero.");
        }

        if (largestRingDiameterCm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(largestRingDiameterCm), "Largest ring diameter must be greater than zero.");
        }

        RingCount = ringCount;
        LargestRingDiameterCm = Math.Round(largestRingDiameterCm, 2);
        HasRoundedBase = hasRoundedBase;
    }

    /// <summary>
    /// Gets the ring count.
    /// </summary>
    public int RingCount { get; }

    /// <summary>
    /// Gets the largest ring diameter.
    /// </summary>
    public double LargestRingDiameterCm { get; }

    /// <summary>
    /// Gets a value indicating whether the stacker has a rounded base.
    /// </summary>
    public bool HasRoundedBase { get; }

    /// <summary>
    /// Simulates stacking the rings.
    /// </summary>
    public string StackRings()
    {
        return $"{RingCount} rings were stacked on {Name}.";
    }

    /// <summary>
    /// Simulates sorting rings by size.
    /// </summary>
    public string SortRingsBySize()
    {
        return $"{Name} rings were sorted from largest to smallest.";
    }
}
