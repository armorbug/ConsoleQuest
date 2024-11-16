using Heroes;
using Enemies;
using Weapons;


Hero hero = new Hero("Heroman", 10, 2);
Enemy enemy = new Enemy("Enemydude", 15, 1);

Weapon staff = new Weapon("staff", 10);
Weapon sword = new Weapon("sword", 5);
Weapon bow = new Weapon("bow", 2);

Start();
Battle(hero, enemy);

void Battle(Hero hero, Enemy enemy)
{
    //practice battle loop
    while (hero.Health > 0 && enemy.Health > 0)
    {
        enemy.Health = enemy.Health - hero.Attack < 0 ? 0 : enemy.Health - hero.Attack;
        Console.WriteLine($"{enemy.Name} took {hero.Attack} damage from {hero.Name}. Their health is now {enemy.Health}.");

        if (enemy.Health <= 0) break;

        hero.Health = hero.Health - enemy.Attack < 0 ? 0 : hero.Health - enemy.Attack;
        Console.WriteLine($"{hero.Name} took {enemy.Attack} damage from {enemy.Name}. Their health is now {hero.Health}.");
    }
    if (hero.Health < 0) Console.WriteLine($"{enemy.Name} won...");
    else Console.WriteLine($"{hero.Name} won!");
}

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
