using Heroes;
using Enemies;

Start();

Hero hero = new Hero(10, 2);
Enemy enemy = new Enemy(15, 1);

//practice battle loop
while (hero.Health > 0 && enemy.Health > 0)
{
    enemy.Health -= hero.Attack;
    if (enemy.Health <= 0) break;
    hero.Health -= enemy.Attack;
}
if (hero.Health < 0) Console.WriteLine("Enemy won");
else Console.WriteLine("Hero won");

void Start()
{
    Console.WriteLine("Hi there. Pick a weapon.");
    string? input;

    do
    {
        Console.WriteLine("Staff, sword or bow?");
        input = Console.ReadLine();
    } while (input != null && !input.Equals("staff") && !input.Equals("bow") && !input.Equals("sword"));
}