namespace Enemies;

public class Enemy
{
    public int Health{get;set;}
    public int Attack{get;set;}

    public Enemy(int health,int attack)
    {
        this.Health = health;
        this.Attack = attack;
    }

}
