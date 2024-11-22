namespace Heroes;

using Weapons;

public class Hero
{
    protected List<Weapon> weapons = new List<Weapon>();
    public string Name
    {
        get;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            else field = value;
        }
    }
    public int MaxHealth
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            else field = value;
        }
    }

    public int CurrentHealth
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            else field = value;
        }
    }
    public int Attack
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            else field = value;
        }
    }

    public int Speed
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            else field = value;
        }
    }

    public Hero(string name, int health, int attack, int speed)
    {
        this.MaxHealth = health;
        this.CurrentHealth = health;
        this.Attack = attack;
        this.Name = name;
        this.Speed = speed;
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public List<Weapon> GetWeapons()
    {
        return weapons;
    }

}
