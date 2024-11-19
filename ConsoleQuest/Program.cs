using Heroes;
using Enemies;
using Weapons;
using System.Runtime.Serialization;

Random random = new Random();


Hero hero = new Hero("Heroman", 10, 2, 15);
Enemy enemy = new Enemy("Enemydude", 15, 2, 15);

Weapon staff = new Weapon("staff", 10);
Weapon sword = new Weapon("sword", 5);
Weapon bow = new Weapon("bow", 2);

Start(hero);
Battle(hero, enemy);

void Battle(Hero hero, Enemy enemy)
{
    int tiebreaker = -1; 
    //practice battle loop
    while (hero.Health > 0 && enemy.Health > 0)
    {
        if (hero.Speed == enemy.Speed)
        {
            //50-50 chance for hero or enemy to move first
            //if tiebreaker is 0, hero moves first
            //if tiebreaker is 1, enemy moves first
            tiebreaker = random.Next(0,2);
        }
        
        if (hero.Speed > enemy.Speed || tiebreaker == 0)
        {
            enemy.Health = HeroAttack(hero, enemy);

            if (enemy.Health <= 0) break;

            hero.Health = EnemyAttack(enemy, hero);
        }
        else if (hero.Speed < enemy.Speed || tiebreaker == 1)
        {
            hero.Health = EnemyAttack(enemy, hero);

            if (hero.Health <= 0) break;

            enemy.Health = HeroAttack(hero, enemy);
        }
    }
    if (hero.Health < 0) Console.WriteLine($"{enemy.Name} won...");
    else Console.WriteLine($"{hero.Name} won!");
}

void Start(Hero hero)
{
    string? input;

    Console.WriteLine("Hi there. Pick a weapon.");
    do
    {
        Console.WriteLine("Staff, sword or bow?");
        input = Console.ReadLine();
    } while (input != null && !input.Equals("staff") && !input.Equals("bow") && !input.Equals("sword"));

    Weapon staff = new Weapon("staff", 5);
    Weapon sword = new Weapon("sword", 4);
    Weapon bow = new Weapon("bow", 3);

    switch (input)
    {
        case "staff":
            hero.AddWeapon(staff);
            break;
        case "sword":
            hero.AddWeapon(sword);
            break;
        case "bow":
            hero.AddWeapon(bow);
            break;
    }
}

int HeroAttack(Hero hero, Enemy enemy)
{
    int damage = hero.Attack;
    foreach (Weapon weapon in hero.GetWeapons())
    {
        damage += weapon.Attack;
    }
    int result = enemy.Health - damage < 0 ? 0 : enemy.Health - damage;
    Console.WriteLine($"{enemy.Name} took {damage} damage from {hero.Name}. Their health is now {result}.");
    return result;
}

int EnemyAttack(Enemy enemy, Hero hero)
{
    int result = hero.Health - enemy.Attack < 0 ? 0 : hero.Health - enemy.Attack;
    Console.WriteLine($"{hero.Name} took {enemy.Attack} damage from {enemy.Name}. Their health is now {result}.");
    return result;
}