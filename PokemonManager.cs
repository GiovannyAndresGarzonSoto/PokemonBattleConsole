using PokemonBattle;
using System;
using System.Collections.Generic;

public static class PokemonManager
{
    public static List<IPokemon> GetPokemon()
    {
        var pikachu = new Pokemon("Pikachu", 35, 55, 90, "Electric");
        pikachu.AddAttack("Thunderbolt", 40);
        pikachu.AddAttack("Quick Attack", 20);
        pikachu.AddAttack("Electro Ball", 30);
        pikachu.AddAttack("Volt Tackle", 50);

        var bulbasaur = new Pokemon("Bulbasaur", 45, 49, 45, "Grass");
        bulbasaur.AddAttack("Vine Whip", 45);
        bulbasaur.AddAttack("Razor Leaf", 55);
        bulbasaur.AddAttack("Seed Bomb", 50);
        bulbasaur.AddAttack("Tackle", 30);

        var charmander = new Pokemon("Charmander", 39, 52, 65, "Fire");
        charmander.AddAttack("Flamethrower", 50);
        charmander.AddAttack("Scratch", 20);
        charmander.AddAttack("Ember", 40);
        charmander.AddAttack("Fire Spin", 30);

        var squirtle = new Pokemon("Squirtle", 44, 48, 43, "Water");
        squirtle.AddAttack("Water Gun", 40);
        squirtle.AddAttack("Bubble", 30);
        squirtle.AddAttack("Tackle", 20);
        squirtle.AddAttack("Aqua Jet", 50);

        var jigglypuff = new Pokemon("Jigglypuff", 115, 45, 20, "Normal");
        jigglypuff.AddAttack("Sing", 0); // Effect attack, can put to sleep
        jigglypuff.AddAttack("Pound", 40);
        jigglypuff.AddAttack("Double-Edge", 100);
        jigglypuff.AddAttack("Rest", 0); // Restores HP but can't attack

        // Agregando más Pokémon
        var mewtwo = new Pokemon("Mewtwo", 106, 110, 130, "Psychic");
        mewtwo.AddAttack("Psystrike", 100);
        mewtwo.AddAttack("Shadow Ball", 80);
        mewtwo.AddAttack("Psycho Cut", 70);
        mewtwo.AddAttack("Aura Sphere", 80);

        var snorlax = new Pokemon("Snorlax", 160, 110, 30, "Normal");
        snorlax.AddAttack("Body Slam", 85);
        snorlax.AddAttack("Rest", 0);
        snorlax.AddAttack("Sleep Talk", 0);
        snorlax.AddAttack("Hyper Beam", 150);

        var gengar = new Pokemon("Gengar", 60, 65, 110, "Ghost");
        gengar.AddAttack("Shadow Ball", 80);
        gengar.AddAttack("Lick", 30);
        gengar.AddAttack("Sludge Bomb", 90);
        gengar.AddAttack("Hex", 65);

        var dragonite = new Pokemon("Dragonite", 91, 134, 80, "Dragon");
        dragonite.AddAttack("Outrage", 120);
        dragonite.AddAttack("Dragon Dance", 0);
        dragonite.AddAttack("Hurricane", 110);
        dragonite.AddAttack("Hyper Beam", 150);

        var gardevoir = new Pokemon("Gardevoir", 68, 65, 80, "Psychic");
        gardevoir.AddAttack("Psychic", 90);
        gardevoir.AddAttack("Moonblast", 95);
        gardevoir.AddAttack("Calm Mind", 0);
        gardevoir.AddAttack("Dazzling Gleam", 80);

        return new List<IPokemon>
        {
            pikachu,
            bulbasaur,
            charmander,
            squirtle,
            jigglypuff,
            mewtwo,
            snorlax,
            gengar,
            dragonite,
            gardevoir
        };
    }

    public static string GetRandomPlayerMotivation()
    {
        string[] motivations = {
            "Your Pokémon is feeling great!",
            "Your Pokémon is full of energy!",
            "Your Pokémon is giving its all!",
            "Your Pokémon is very motivated!"
        };
        Random random = new Random();
        return motivations[random.Next(motivations.Length)];
    }

    public static string GetRandomOpponentMotivation()
    {
        string[] motivations = {
            "The opponent's Pokémon looks fierce!",
            "The opponent's Pokémon is ready to fight!",
            "The opponent's Pokémon is eager for battle!",
            "The opponent's Pokémon is giving its all!"
        };
        Random random = new Random();
        return motivations[random.Next(motivations.Length)];
    }

    public static string GetRandomLowHealthMessage(string pokemonName)
    {
        string[] messages = {
            $"{pokemonName} is giving everything it has!",
            $"{pokemonName} is pushing through the pain!",
            $"{pokemonName} is determined to win!",
            $"{pokemonName} is not giving up!"
        };
        Random random = new Random();
        return messages[random.Next(messages.Length)];
    }
}
