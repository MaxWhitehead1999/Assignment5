using Problem1.Enums;

namespace Problem1.Models;

/// <summary>
/// Represents a dollhouse toy.
/// </summary>
public sealed class Dollhouse : Toy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Dollhouse"/> class.
    /// </summary>
    public Dollhouse(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int roomCount,
        int floorCount,
        bool hasWorkingLights)
        : base(price, ToyCategory.Dollhouse, name, brand, yearOfManufacture, minimumAgeLimit, hasChokingHazard, weight)
    {
        if (roomCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(roomCount), "A dollhouse must contain at least one room.");
        }

        if (floorCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(floorCount), "A dollhouse must contain at least one floor.");
        }

        RoomCount = roomCount;
        FloorCount = floorCount;
        HasWorkingLights = hasWorkingLights;
    }

    /// <summary>
    /// Gets the room count.
    /// </summary>
    public int RoomCount { get; }

    /// <summary>
    /// Gets the floor count.
    /// </summary>
    public int FloorCount { get; }

    /// <summary>
    /// Gets a value indicating whether the dollhouse has working lights.
    /// </summary>
    public bool HasWorkingLights { get; }

    /// <summary>
    /// Simulates opening the front panel.
    /// </summary>
    public string OpenFrontPanel()
    {
        return $"{Name} opens to reveal {RoomCount} rooms.";
    }

    /// <summary>
    /// Simulates arranging the dollhouse furniture.
    /// </summary>
    public string ArrangeFurniture()
    {
        return $"Furniture arranged across {FloorCount} floor(s) in {Name}.";
    }
}
