using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1.Factories;
using Problem1.Models;

namespace Problem1.Tests;

[TestClass]
public class ToyFactoryTests
{
    private readonly IToyFactory _factory = new ToyFactory();

    [TestMethod]
    public void CreateToyCar_ReturnsConfiguredToyCar()
    {
        ToyCar car = _factory.CreateToyCar(
            14.99m,
            "Zoom Racer",
            "Bright Wheels",
            2025,
            3,
            true,
            0.65,
            4,
            true,
            7.5);

        Assert.AreEqual("Zoom Racer", car.Name);
        Assert.AreEqual(4, car.WheelCount);
        Assert.IsTrue(car.IsRemoteControlled);
    }

    [TestMethod]
    public void CreateDollhouse_WithZeroMinimumAge_IsAllowed()
    {
        Dollhouse dollhouse = _factory.CreateDollhouse(
            79.99m,
            "Tiny Home",
            "PlayTime",
            2024,
            0,
            false,
            4.2,
            6,
            3,
            true);

        Assert.AreEqual(0, dollhouse.MinimumAgeLimit);
        Assert.AreEqual(6, dollhouse.RoomCount);
    }

    [TestMethod]
    public void CreateStuffedAnimal_WithBlankSpecies_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() =>
            _factory.CreateStuffedAnimal(
                19.99m,
                "Snuggle Friend",
                "Cloud Soft",
                2025,
                1,
                false,
                0.45,
                " ",
                "Cotton",
                true));
    }

    [TestMethod]
    public void RainbowStacker_SortRingsBySize_ReturnsReadableResult()
    {
        RainbowStacker stacker = _factory.CreateRainbowStacker(
            24.99m,
            "Color Tower",
            "Little Learners",
            2023,
            1,
            false,
            0.90,
            7,
            12.5,
            true);

        string result = stacker.SortRingsBySize();

        StringAssert.Contains(result, "Color Tower");
        StringAssert.Contains(result, "sorted");
    }
}
