using Heroes;
using Enemies;
using Weapons;

Random random = new Random();


Hero hero = new Hero("Heroman", 10, 2, 15);


Weapon staff = new Weapon("staff", 4);
Weapon sword = new Weapon("sword", 3);
Weapon bow = new Weapon("bow", 2);

Start(hero);
int enemiesDefeated = 0;

//multiple battles until hero dies
while (hero.CurrentHealth > 0)
{
    //generate random enemies
    Enemy enemy = GenerateRandomEnemy(enemiesDefeated);
    Console.WriteLine($"{enemy.Name}'s stats:\nHealth: {enemy.Health}\nAttack: {enemy.Attack}\nSpeed: {enemy.Speed}\n");
    Battle(hero, enemy);
    if (hero.CurrentHealth > 0) 
    {
        enemiesDefeated++;
        RestoreHealth(hero, enemiesDefeated/5 + 1); //increases by one for every 5 enemies defeated
    }


    Thread.Sleep(1000);

}

if (enemiesDefeated > 0) Console.WriteLine($"Well done! You defeated {enemiesDefeated} enemies in a row!");
else Console.WriteLine("Oh no, you didn't defeat any enemies this time...");

void Battle(Hero hero, Enemy enemy)
{
    int tiebreaker = -1; 
    //practice battle loop
    while (hero.CurrentHealth > 0 && enemy.Health > 0)
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

            hero.CurrentHealth = EnemyAttack(enemy, hero);
        }
        else if (hero.Speed < enemy.Speed || tiebreaker == 1)
        {
            hero.CurrentHealth = EnemyAttack(enemy, hero);

            if (hero.CurrentHealth <= 0) break;

            enemy.Health = HeroAttack(hero, enemy);
        }
    }
    if (hero.CurrentHealth <= 0) Console.WriteLine($"{enemy.Name} won...");
    else Console.WriteLine($"{hero.Name} won!");
    Console.WriteLine();
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
    //Console.WriteLine($"{enemy.Name} took {damage} damage from {hero.Name}. Their health is now {result}.");
    Console.WriteLine($"{hero.Name} dealt {damage} damage to {enemy.Name}. {enemy.Name}'s health is now {result}.");
    return result;
}

int EnemyAttack(Enemy enemy, Hero hero)
{
    int result = hero.CurrentHealth - enemy.Attack < 0 ? 0 : hero.CurrentHealth - enemy.Attack;
    //Console.WriteLine($"{hero.Name} took {enemy.Attack} damage from {enemy.Name}. Their health is now {result}.");
    Console.WriteLine($"{enemy.Name} dealt {enemy.Attack} damage to {hero.Name}. {hero.Name}'s health is now {result}.");
    return result;
}

void RestoreHealth(Hero hero, int amount)
{
    if (hero.CurrentHealth + amount > hero.MaxHealth) hero.CurrentHealth = hero.MaxHealth;
    else hero.CurrentHealth += amount;
    Console.WriteLine($"{hero.Name} restored {amount} health! {hero.Name}'s health is now {hero.CurrentHealth}.\n");

}

Enemy GenerateRandomEnemy(int enemiesDefeated)
{
    string enemyName = string.Format($"Enemydude{enemiesDefeated+1}");
    int enemyHealth = random.Next(5,21) + enemiesDefeated/5;
    int enemyAttack = random.Next(1,4) + enemiesDefeated/5;
    int enemySpeed = random.Next(10,21) + enemiesDefeated/5;

    Enemy enemy = new Enemy(enemyName, enemyHealth, enemyAttack, enemySpeed);

    return enemy;
    
}