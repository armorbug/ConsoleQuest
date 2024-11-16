﻿namespace Heroes;

public class Hero
{
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
    public int Health
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

    public Hero(string name, int health, int attack)
    {
        this.Health = health;
        this.Attack = attack;
        this.Name = name;
    }


}
