using Problem2.Enums;

namespace Problem2.Models;

/// <summary>
/// Represents a motherboard.
/// </summary>
public sealed class Motherboard
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Motherboard"/> class.
    /// </summary>
    public Motherboard(
        int memorySlotCount,
        int pciSlotCount,
        FormFactor formFactor,
        Cpu cpu,
        MemoryModule memory,
        GraphicsCard graphicsCard)
    {
        if (memorySlotCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(memorySlotCount), "Memory slot count must be greater than zero.");
        }

        if (pciSlotCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pciSlotCount), "PCI slot count cannot be negative.");
        }

        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        Memory = memory ?? throw new ArgumentNullException(nameof(memory));
        GraphicsCard = graphicsCard ?? throw new ArgumentNullException(nameof(graphicsCard));
        MemorySlotCount = memorySlotCount;
        PciSlotCount = pciSlotCount;
        FormFactor = formFactor;
    }

    public int MemorySlotCount { get; }

    public int PciSlotCount { get; }

    public FormFactor FormFactor { get; }

    public Cpu Cpu { get; }

    public MemoryModule Memory { get; }

    public GraphicsCard GraphicsCard { get; }
}
