using System;
using System.Collections.Generic;

namespace PokemonBattle;
using System;
using System.Collections.Generic;

public class Pokemon : IPokemon
{
    public string Name { get; }
    public int HP { get; set; }
    public int Attack { get; }
    public int Speed { get; }
    public string Type { get; }
    public Dictionary<string, int> Attacks { get; }

    public Pokemon(string name, int hp, int attack, int speed, string type)
    {
        Name = name;
        HP = hp;
        Attack = attack;
        Speed = speed;
        Type = type;
        Attacks = new Dictionary<string, int>();
    }

    public void AddAttack(string attackName, int damage)
    {
        Attacks[attackName] = damage;
    }

    public int AttackPokemon(IPokemon opponent, string attackName)
    {
        if (!Attacks.ContainsKey(attackName))
        {
            throw new ArgumentException("Attack not found.");
        }

        int damage = Attacks[attackName];

        // Check for critical hit
        Random rand = new Random();
        if (rand.Next(1, 25) == 1) // 1 in 24 chance for critical hit
        {
            damage *= 2; // Double damage for critical hit
            Console.WriteLine($"{Name} landed a critical hit!");
        }

        opponent.HP -= damage;
        return damage;
    }

    public void ShowAttacks()
    {
        Console.WriteLine($"{Name}'s Attacks:");
        int i = 1;
        foreach (var attack in Attacks)
        {
            Console.WriteLine($"{i++}. {attack.Key} (Damage: {attack.Value})");
        }
    }
}
