
public abstract class Person
{
    public int Id { get; }
    public string Name { get; protected set; }
    public string Email { get; protected set; }

    protected Person(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public override string ToString() 
    {
        return $"id : {Id}\nName : {Name}\nEmail: {Email}";
    }
}
