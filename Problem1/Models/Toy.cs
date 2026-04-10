using Problem1.Enums;

namespace Problem1.Models;

/// <summary>
/// Represents common information shared by all toys.
/// </summary>
public abstract class Toy
{
    private decimal _price;
    private string _name = string.Empty;
    private string _brand = string.Empty;
    private int _yearOfManufacture;
    private int _minimumAgeLimit;
    private double _weight;

    /// <summary>
    /// Initializes a new instance of the <see cref="Toy"/> class.
    /// </summary>
    protected Toy(
        decimal price,
        ToyCategory category,
        string name,
        string brand,
        int yearOfManufacture,
        int minimumAgeLimit,
        bool hasChokingHazard,
        double weight)
    {
        Price = price;
        Category = category;
        Name = name;
        Brand = brand;
        YearOfManufacture = yearOfManufacture;
        MinimumAgeLimit = minimumAgeLimit;
        HasChokingHazard = hasChokingHazard;
        Weight = weight;
    }

    /// <summary>
    /// Gets the toy price.
    /// </summary>
    public decimal Price
    {
        get => _price;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater than zero.");
            }

            _price = decimal.Round(value, 2);
        }
    }

    /// <summary>
    /// Gets the toy category.
    /// </summary>
    public ToyCategory Category { get; }

    /// <summary>
    /// Gets the toy name.
    /// </summary>
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name is required.", nameof(value));
            }

            _name = value.Trim();
        }
    }

    /// <summary>
    /// Gets the toy brand.
    /// </summary>
    public string Brand
    {
        get => _brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Brand is required.", nameof(value));
            }

            _brand = value.Trim();
        }
    }

    /// <summary>
    /// Gets the year of manufacture.
    /// </summary>
    public int YearOfManufacture
    {
        get => _yearOfManufacture;
        private set
        {
            var maximumYear = DateTime.UtcNow.Year + 1;
            if (value < 1900 || value > maximumYear)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Year must be between 1900 and {maximumYear}.");
            }

            _yearOfManufacture = value;
        }
    }

    /// <summary>
    /// Gets the minimum recommended age.
    /// </summary>
    public int MinimumAgeLimit
    {
        get => _minimumAgeLimit;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Minimum age limit cannot be negative.");
            }

            _minimumAgeLimit = value;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the toy contains a choking hazard.
    /// </summary>
    public bool HasChokingHazard { get; }

    /// <summary>
    /// Gets the toy weight in kilograms.
    /// </summary>
    public double Weight
    {
        get => _weight;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight must be greater than zero.");
            }

            _weight = Math.Round(value, 2);
        }
    }

    /// <summary>
    /// Gets a readable description for the toy.
    /// </summary>
    public virtual string Describe()
    {
        return $"{Brand} {Name} is a {Category} toy made in {YearOfManufacture}.";
    }
}
