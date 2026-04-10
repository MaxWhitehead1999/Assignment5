using Problem2.Enums;
using Problem2.Models;

namespace Problem2.Builders;

/// <summary>
/// Defines the builder contract used to assemble a computer.
/// </summary>
public interface IComputerBuilder
{
    IComputerBuilder SetHardDrive(HardDrive hardDrive);

    IComputerBuilder ConfigureMotherboard(int memorySlotCount, int pciSlotCount, FormFactor formFactor);

    IComputerBuilder SetCpu(Cpu cpu);

    IComputerBuilder SetMemory(MemoryModule memory);

    IComputerBuilder SetGraphicsCard(GraphicsCard graphicsCard);

    IComputerBuilder SetCase(ComputerCase computerCase);

    Computer Build();

    void Reset();
}
