using Problem2.Enums;
using Problem2.Models;

namespace Problem2.Builders;

/// <summary>
/// Concrete builder used to assemble a computer from parts.
/// </summary>
public sealed class ComputerBuilder : IComputerBuilder
{
    private HardDrive? _hardDrive;
    private int? _memorySlotCount;
    private int? _pciSlotCount;
    private FormFactor? _formFactor;
    private Cpu? _cpu;
    private MemoryModule? _memory;
    private GraphicsCard? _graphicsCard;
    private ComputerCase? _case;

    /// <inheritdoc />
    public IComputerBuilder SetHardDrive(HardDrive hardDrive)
    {
        _hardDrive = hardDrive ?? throw new ArgumentNullException(nameof(hardDrive));
        return this;
    }

    /// <inheritdoc />
    public IComputerBuilder ConfigureMotherboard(int memorySlotCount, int pciSlotCount, FormFactor formFactor)
    {
        if (memorySlotCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(memorySlotCount), "Memory slot count must be greater than zero.");
        }

        if (pciSlotCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pciSlotCount), "PCI slot count cannot be negative.");
        }

        _memorySlotCount = memorySlotCount;
        _pciSlotCount = pciSlotCount;
        _formFactor = formFactor;
        return this;
    }

    /// <inheritdoc />
    public IComputerBuilder SetCpu(Cpu cpu)
    {
        _cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        return this;
    }

    /// <inheritdoc />
    public IComputerBuilder SetMemory(MemoryModule memory)
    {
        _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        return this;
    }

    /// <inheritdoc />
    public IComputerBuilder SetGraphicsCard(GraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard ?? throw new ArgumentNullException(nameof(graphicsCard));
        return this;
    }

    /// <inheritdoc />
    public IComputerBuilder SetCase(ComputerCase computerCase)
    {
        _case = computerCase ?? throw new ArgumentNullException(nameof(computerCase));
        return this;
    }

    /// <inheritdoc />
    public Computer Build()
    {
        if (_hardDrive is null)
        {
            throw new InvalidOperationException("A hard drive must be configured before building.");
        }

        if (!_memorySlotCount.HasValue || !_pciSlotCount.HasValue || !_formFactor.HasValue)
        {
            throw new InvalidOperationException("Motherboard configuration must be supplied before building.");
        }

        if (_cpu is null)
        {
            throw new InvalidOperationException("A CPU must be configured before building.");
        }

        if (_memory is null)
        {
            throw new InvalidOperationException("Memory must be configured before building.");
        }

        if (_graphicsCard is null)
        {
            throw new InvalidOperationException("A graphics card must be configured before building.");
        }

        if (_case is null)
        {
            throw new InvalidOperationException("A computer case must be configured before building.");
        }

        var motherboard = new Motherboard(
            _memorySlotCount.Value,
            _pciSlotCount.Value,
            _formFactor.Value,
            _cpu,
            _memory,
            _graphicsCard);

        var computer = new Computer(_hardDrive, motherboard, _case);
        Reset();
        return computer;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _hardDrive = null;
        _memorySlotCount = null;
        _pciSlotCount = null;
        _formFactor = null;
        _cpu = null;
        _memory = null;
        _graphicsCard = null;
        _case = null;
    }
}
