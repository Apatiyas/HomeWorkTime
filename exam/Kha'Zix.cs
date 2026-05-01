using BaseCard;
using BaseEffect;
using PlayerGame;
using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KhaZix_Deck
{
    internal class KhaZix: Unit
    {
        public override string name { get; set; } = "Kha'Zix";
        public override int manaCost { get; set; } = 4;
        public override int hitpoint { get; set; } = 4;
        public override int damage { get; set; } = 4;

        private bool _hasEvolved = false;
        public override void OnPlay(Player owner, Player opponent, GameState state)
        {
            owner.RemoveFromHand(this);
            Console.WriteLine("Выберите позицию от 0-5");
            int position = int.Parse(Console.ReadLine());
            owner.Field.placeEntity(position, this);
        }
        public KhaZix() { }

        public void Evolve(Player owner)
        {
            if (_hasEvolved) return;
            Console.WriteLine("Выберите эволюцию");
            Console.WriteLine("1 - Пробивание");
            Console.WriteLine("2 - Стойкость");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1) { Effects.Add(new TrampleEffect()); }
            else if (choice == 2) { Effects.Add(new ResilienceEffect()); }

            damage += 2;
            hitpoint += 2;
            _hasEvolved = true;
            Console.WriteLine("Kha'Zix эволюционировал!");
        }
    }

    internal class Cockroach : Unit
    {

        public override string name { get; set; } = "Cockroach";
        public override int manaCost { get; set; } = 2;
        public override int hitpoint { get; set; } = 3;
        public override int damage { get; set; } = 2;
        public override void OnPlay(Player owner, Player opponent, GameState state)
        {
            owner.RemoveFromHand(this);
            Console.WriteLine("Выберите позицию от 0-5");
            int position = int.Parse(Console.ReadLine());
            owner.Field.placeEntity(position, this);
        }
    }
}
