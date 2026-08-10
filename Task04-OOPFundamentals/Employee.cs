public class Employee
{
    private readonly int _id;
    private string _name;
    private string _email;
    private decimal _salary;
    private const decimal MaxSalary = 100000m;

    public int Id => _id;

    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }
            if (value > MaxSalary)
            {
                throw new ArgumentException($"Salary cannot exceed{MaxSalary}.");
            }
            _salary = value;
        }

    }


    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            _name = value;
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Invalid email address.");
            }
            _email = value;
        }
    }

    public Employee(int id, string name, string email, decimal salary)
    {
        _id = id;      // assign directly — readonly field, constructor is the one place this is allowed
        Name = name;     // assign through the property, not the field — so validation runs
        Email = email;
        Salary = salary;
    }

    public Employee() : this(0, "Unknown", "unknown@example.com", 0)
    {
    }
    public Employee(Employee other) : this(other._id, other.Name, other.Email, other.Salary)
    {
    }

    public override string ToString()
    {
        return $"id : {Id}\n" +
            $"name : {Name}\n" +
            $"email : {Email}\n" +
            $"salary : {Salary}";
    }


}

