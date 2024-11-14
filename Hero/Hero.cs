namespace Heroes;

public class Hero
{
    public int Health{get;set;}
    public int Attack{get;set;}

    public Hero(int health,int attack)
    {
        this.Health = health;
        this.Attack = attack;
    }
}
