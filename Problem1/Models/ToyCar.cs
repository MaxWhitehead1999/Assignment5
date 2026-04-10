using Problem1.Enums;

namespace Problem1.Models;

/// <summary>
/// Represents a toy car.
/// </summary>
public sealed class ToyCar : Toy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToyCar"/> class.
    /// </summary>
    public ToyCar(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int wheelCount,
        bool isRemoteControlled,
        double maxSpeedKph)
        : base(price, ToyCategory.Vehicle, name, brand, yearOfManufacture, minimumAgeLimit, hasChokingHazard, weight)
    {
        if (wheelCount < 3)
        {
            throw new ArgumentOutOfRangeException(nameof(wheelCount), "A toy car must have at least three wheels.");
        }

        if (maxSpeedKph <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxSpeedKph), "Maximum speed must be greater than zero.");
        }

        WheelCount = wheelCount;
        IsRemoteControlled = isRemoteControlled;
        MaxSpeedKph = Math.Round(maxSpeedKph, 2);
    }

    /// <summary>
    /// Gets the wheel count.
    /// </summary>
    public int WheelCount { get; }

    /// <summary>
    /// Gets a value indicating whether the toy is remote controlled.
    /// </summary>
    public bool IsRemoteControlled { get; }

    /// <summary>
    /// Gets the maximum speed in KPH.
    /// </summary>
    public double MaxSpeedKph { get; }

    /// <summary>
    /// Simulates rolling the car.
    /// </summary>
    public string RollForward(int distanceInCentimeters)
    {
        if (distanceInCentimeters <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distanceInCentimeters), "Distance must be greater than zero.");
        }

        return $"{Name} rolled forward {distanceInCentimeters} cm.";
    }

    /// <summary>
    /// Simulates the car horn.
    /// </summary>
    public string HonkHorn()
    {
        return $"{Name} honks: beep beep!";
    }
}
