using Heroes;
using Enemies;

Hero hero = new Hero(10,2);
Enemy enemy = new Enemy(15,1);

//practice battle loop
while (hero.Health > 0 && enemy.Health > 0)
{
    enemy.Health -= hero.Attack;
    if(enemy.Health <= 0) break;
    hero.Health -= enemy.Attack;
}
if (hero.Health < 0) Console.WriteLine("Enemy won");
else Console.WriteLine("Hero won");