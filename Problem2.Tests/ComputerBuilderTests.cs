using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem2.Builders;
using Problem2.Enums;
using Problem2.Models;

namespace Problem2.Tests;

[TestClass]
public class ComputerBuilderTests
{
    [TestMethod]
    public void BuildGamingComputer_ReturnsExpectedParts()
    {
        var director = new ComputerDirector();
        var builder = new ComputerBuilder();

        Computer computer = director.BuildGamingComputer(builder);

        Assert.AreEqual(2000, computer.HardDrive.CapacityInGb);
        Assert.AreEqual(4, computer.Motherboard.MemorySlotCount);
        Assert.AreEqual(16, computer.Motherboard.GraphicsCard.VideoMemoryInGb);
    }

    [TestMethod]
    public void Cpu_WithZeroSpeed_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            new Cpu(0, CpuManufacturer.Intel, "LGA1700", 16, 8));
    }

    [TestMethod]
    public void Build_WithoutCase_ThrowsInvalidOperationException()
    {
        var builder = new ComputerBuilder();

        builder
            .SetHardDrive(new HardDrive(1000, HardDriveInterfaceType.Nvme, 3500, 3200))
            .ConfigureMotherboard(4, 2, FormFactor.Atx)
            .SetCpu(new Cpu(4.2, CpuManufacturer.Amd, "AM4", 32, 6))
            .SetMemory(new MemoryModule(3600, 3600, MemoryType.Ddr4, 16))
            .SetGraphicsCard(new GraphicsCard(2, 2.1, 12, 4096));

        Assert.ThrowsException<InvalidOperationException>(() => builder.Build());
    }

    [TestMethod]
    public void ComputerCase_WithZeroFans_IsAllowed()
    {
        var computerCase = new ComputerCase(45, 21, 43, 0, 3);

        Assert.AreEqual(0, computerCase.FanCount);
        Assert.AreEqual(3, computerCase.VentCount);
    }
}
