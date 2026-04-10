using Problem1.Models;

namespace Problem1.Factories;

/// <summary>
/// Defines a factory for building toy instances.
/// </summary>
public interface IToyFactory
{
    ToyCar CreateToyCar(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int wheelCount,
        bool isRemoteControlled,
        double maxSpeedKph);

    Dollhouse CreateDollhouse(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int roomCount,
        int floorCount,
        bool hasWorkingLights);

    StuffedAnimal CreateStuffedAnimal(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        string animalSpecies,
        string materialType,
        bool isMachineWashable);

    RainbowStacker CreateRainbowStacker(
        decimal price,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight,
        int ringCount,
        double largestRingDiameterCm,
        bool hasRoundedBase);
}
