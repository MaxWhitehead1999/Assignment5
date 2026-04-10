using Problem2.Enums;
using Problem2.Models;

namespace Problem2.Builders;

/// <summary>
/// Provides common build recipes for computers.
/// </summary>
public sealed class ComputerDirector
{
    /// <summary>
    /// Builds a gaming computer configuration.
    /// </summary>
    public Computer BuildGamingComputer(IComputerBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return builder
            .SetHardDrive(new HardDrive(2000, HardDriveInterfaceType.Nvme, 7000, 6500))
            .ConfigureMotherboard(4, 3, FormFactor.Atx)
            .SetCpu(new Cpu(4.9, CpuManufacturer.Amd, "AM5", 64, 8))
            .SetMemory(new MemoryModule(6000, 6000, MemoryType.Ddr4, 32))
            .SetGraphicsCard(new GraphicsCard(3, 2.6, 16, 9728))
            .SetCase(new ComputerCase(48, 24, 52, 4, 8))
            .Build();
    }

    /// <summary>
    /// Builds a budget computer configuration.
    /// </summary>
    public Computer BuildBudgetComputer(IComputerBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        return builder
            .SetHardDrive(new HardDrive(512, HardDriveInterfaceType.Sata3, 550, 520))
            .ConfigureMotherboard(2, 1, FormFactor.MicroAtx)
            .SetCpu(new Cpu(3.6, CpuManufacturer.Intel, "LGA1700", 18, 4))
            .SetMemory(new MemoryModule(3200, 3200, MemoryType.Ddr4, 16))
            .SetGraphicsCard(new GraphicsCard(1, 1.8, 8, 2048))
            .SetCase(new ComputerCase(38, 19, 40, 1, 4))
            .Build();
    }
}
