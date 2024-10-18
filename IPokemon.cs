using System.Collections.Generic;

namespace PokemonBattle;
public interface IPokemon
{
    string Name { get; }
    int HP { get; set; }
    int Attack { get; }
    int Speed { get; }
    string Type { get; }
    Dictionary<string, int> Attacks { get; }

    void AddAttack(string attackName, int damage);
    int AttackPokemon(IPokemon opponent, string attackName);
    void ShowAttacks();
}
