namespace Weapons;

public class Weapon
{    public string Name
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

    public Weapon(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
}