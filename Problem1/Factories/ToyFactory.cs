using Problem1.Models;

namespace Problem1.Factories;

/// <summary>
/// Concrete factory used to create toys.
/// </summary>
public sealed class ToyFactory : IToyFactory
{
    /// <inheritdoc />
    public ToyCar CreateToyCar(
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
    {
        return new ToyCar(
            price,
            name,
            brand,
            yearOfManufacture,
            minimumAgeLimit,
            hasChokingHazard,
            weight,
            wheelCount,
            isRemoteControlled,
            maxSpeedKph);
    }

    /// <inheritdoc />
    public Dollhouse CreateDollhouse(
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
    {
        return new Dollhouse(
            price,
            name,
            brand,
            yearOfManufacture,
            minimumAgeLimit,
            hasChokingHazard,
            weight,
            roomCount,
            floorCount,
            hasWorkingLights);
    }

    /// <inheritdoc />
    public StuffedAnimal CreateStuffedAnimal(
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
    {
        return new StuffedAnimal(
            price,
            name,
            brand,
            yearOfManufacture,
            minimumAgeLimit,
            hasChokingHazard,
            weight,
            animalSpecies,
            materialType,
            isMachineWashable);
    }

    /// <inheritdoc />
    public RainbowStacker CreateRainbowStacker(
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
    {
        return new RainbowStacker(
            price,
            name,
            brand,
            yearOfManufacture,
            minimumAgeLimit,
            hasChokingHazard,
            weight,
            ringCount,
            largestRingDiameterCm,
            hasRoundedBase);
    }
}
