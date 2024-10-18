using System;
using System.Linq;
using System.Threading;

namespace PokemonBattle;
using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Solicitar nombre del jugador
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();

        // Obtener la lista de Pokémon
        var pokemon = PokemonManager.GetPokemon();

        // Seleccionar Pokémon
        Console.WriteLine("\nSelect your Pokémon:");
        for (int i = 0; i < pokemon.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemon[i].Name}");
        }
        Console.Write("Enter the number of your choice: ");
        int playerChoice = int.Parse(Console.ReadLine());

        IPokemon playerPokemon = pokemon[playerChoice - 1];

        // Seleccionar Pokémon del oponente (aleatorio)
        Random random = new Random();
        IPokemon opponentPokemon = pokemon[random.Next(pokemon.Count)];
        string opponentName = "Enemy"; // Nombre fijo para el oponente

        Console.WriteLine($"\n{opponentName}'s Pokémon: {opponentPokemon.Name}");

        // Iniciar Batalla
        Console.WriteLine($"\n{playerName}'s {playerPokemon.Name} vs {opponentName}'s {opponentPokemon.Name}!");

        // Bucle de Batalla
        while (playerPokemon.HP > 0 && opponentPokemon.HP > 0)
        {
            // Mostrar vida restante
            Console.WriteLine($"\n{playerPokemon.Name} HP: {playerPokemon.HP} | {opponentPokemon.Name} HP: {opponentPokemon.HP}");

            // Turno del jugador
            playerPokemon.ShowAttacks();
            Console.Write($"Choose an attack for {playerPokemon.Name} (1-{playerPokemon.Attacks.Count}): ");
            int attackChoice;
            while (!int.TryParse(Console.ReadLine(), out attackChoice) || attackChoice < 1 || attackChoice > playerPokemon.Attacks.Count)
            {
                Console.Write("Invalid choice. Please choose an attack (1-{0}): ", playerPokemon.Attacks.Count);
            }

            string attackName = playerPokemon.Attacks.Keys.ElementAt(attackChoice - 1); // Obtener el nombre del ataque por el índice
            int damageDealt = playerPokemon.AttackPokemon(opponentPokemon, attackName);
            Console.WriteLine($"{playerName}'s {playerPokemon.Name} dealt {damageDealt} damage to {opponentPokemon.Name}.");
            Thread.Sleep(1500); // Pausa de 1.5 segundos

            // Frases aleatorias de motivación del jugador
            if (playerPokemon.HP < 20)
            {
                Console.WriteLine(PokemonManager.GetRandomLowHealthMessage(playerPokemon.Name));
            }
            else
            {
                Console.WriteLine(PokemonManager.GetRandomPlayerMotivation());
            }

            // Verificar si el oponente sigue vivo
            if (opponentPokemon.HP <= 0)
            {
                Console.WriteLine($"{opponentPokemon.Name} has fainted!");
                break;
            }

            // Turno del oponente (ataque aleatorio)
            int randomAttackIndex = random.Next(1, opponentPokemon.Attacks.Count + 1);
            string opponentAttackName = opponentPokemon.Attacks.Keys.ElementAt(randomAttackIndex - 1);
            int opponentDamageDealt = opponentPokemon.AttackPokemon(playerPokemon, opponentAttackName);
            Console.WriteLine($"{opponentName}'s {opponentPokemon.Name} dealt {opponentDamageDealt} damage to {playerName}'s {playerPokemon.Name}.");
            Thread.Sleep(1500); // Pausa de 1.5 segundos

            // Frases aleatorias de motivación del oponente
            if (opponentPokemon.HP < 20)
            {
                Console.WriteLine(PokemonManager.GetRandomLowHealthMessage(opponentPokemon.Name));
            }
            else
            {
                Console.WriteLine(PokemonManager.GetRandomOpponentMotivation());
            }
        }

        // Fin de la batalla
        if (playerPokemon.HP <= 0)
        {
            Console.WriteLine($"{playerName}'s {playerPokemon.Name} has fainted. You lost!");
        }
        else
        {
            Console.WriteLine($"{playerName} won the battle!");
        }
    }
}
