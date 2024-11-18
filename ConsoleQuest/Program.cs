using Heroes;
using Enemies;
using Weapons;


Hero hero = new Hero("Heroman", 10, 2);
Enemy enemy = new Enemy("Enemydude", 15, 1);

Weapon staff = new Weapon("staff", 10);
Weapon sword = new Weapon("sword", 5);
Weapon bow = new Weapon("bow", 2);

Start(hero);
Battle(hero, enemy);

void Battle(Hero hero, Enemy enemy)
{
    //practice battle loop
    while (hero.Health > 0 && enemy.Health > 0)
    {
        enemy.Health = HeroAttack(hero, enemy);

        if (enemy.Health <= 0) break;

        hero.Health = EnemyAttack(enemy, hero);
        
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
    //to-do: add weapon damage 
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