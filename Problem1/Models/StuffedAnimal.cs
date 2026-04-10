using Problem1.Enums;

namespace Problem1.Models;

/// <summary>
/// Represents a stuffed animal toy.
/// </summary>
public sealed class StuffedAnimal : Toy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StuffedAnimal"/> class.
    /// </summary>
    public StuffedAnimal(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        string animalSpecies,
        string materialType,
        bool isMachineWashable)
        : base(price, ToyCategory.Plush, name, brand, yearOfManufacture, minimumAgeLimit, hasChokingHazard, weight)
    {
        AnimalSpecies = ValidateText(animalSpecies, nameof(animalSpecies));
        MaterialType = ValidateText(materialType, nameof(materialType));
        IsMachineWashable = isMachineWashable;
    }

    /// <summary>
    /// Gets the animal species represented by the plush toy.
    /// </summary>
    public string AnimalSpecies { get; }

    /// <summary>
    /// Gets the material type.
    /// </summary>
    public string MaterialType { get; }

    /// <summary>
    /// Gets a value indicating whether the toy is machine washable.
    /// </summary>
    public bool IsMachineWashable { get; }

    /// <summary>
    /// Simulates squeezing the stuffed animal.
    /// </summary>
    public string SqueezePaw()
    {
        return $"{Name} gives a soft squeak when squeezed.";
    }

    /// <summary>
    /// Simulates pretend play.
    /// </summary>
    public string PlayPretend()
    {
        return $"{Name} the {AnimalSpecies} joins pretend play.";
    }

    private static string ValidateText(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value is required.", paramName);
        }

        return value.Trim();
    }
}
