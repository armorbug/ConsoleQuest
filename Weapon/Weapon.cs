namespace Weapons;

public class Weapon
{
    public string Name { get; set; }
    public int Attack { get; set; }

    public Weapon(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
}
public class Staff : Weapon
{
    public Staff(string name, int attack) : base(name,attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
}

public class Sword : Weapon
{
    public Sword(string name, int attack) : base(name,attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
}

public class Bow : Weapon
{
    public Bow(string name, int attack) : base(name,attack)
    {
        this.Name = name;
        this.Attack = attack; 
    }
}