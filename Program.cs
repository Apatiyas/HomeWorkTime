using BaseCard;
using BaseEffect;
using KhaZix_Deck;
using PlayerGame;
using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace MainGame
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            // Кладём карты в колоды
            p1.cardInDeck.Add(new KhaZix());      // Kha'Zix 4/4
            p2.cardInDeck.Add(new Cockroach());   // Таракан 2/3

            GameState gm = new GameState(p1, p2);

            // Берём карты
            p1.DrawCards(5);
            p2.DrawCards(5);

            // Находим Kha'Zix в руке p1
            KhaZix khazix = p1.cardInHand.OfType<KhaZix>().FirstOrDefault();
            // Находим Cockroach в руке p2
            Cockroach cockroach = p2.cardInHand.OfType<Cockroach>().FirstOrDefault();

            if (khazix == null || cockroach == null)
            {
                Console.WriteLine("Карты не найдены в руке!");
                return;
            }

            // Разыгрываем
            Console.WriteLine("Разыгрываем Kha'Zix:");
            khazix.OnPlay(p1, p2, gm);

            Console.WriteLine("Разыгрываем Cockroach:");
            cockroach.OnPlay(p2, p1, gm);

            // Выводим поля
            p1.Field.DrawDownField();
            p1.Field.DrawUpField();
            p2.Field.DrawUpField();
            p2.Field.DrawDownField();



            int khazixPos = p1.Field.GetUnitPosition(khazix);
            int cockroachPos = p2.Field.GetUnitPosition(cockroach);

            Console.WriteLine($"p1 здоровье: {p1.hitPoints}, p2 здоровье: {p2.hitPoints}");

            p1.Field.moveToAttack(khazixPos, 0);
            p2.Field.moveToDefend(0, cockroachPos);

            bool killed = p1.Field.Attack(0, 0);

            Console.WriteLine($"p1 здоровье: {p1.hitPoints}, p2 здоровье: {p2.hitPoints}");

            Console.WriteLine("Поле после атаки:");
            p1.Field.DrawDownField();
            p1.Field.DrawUpField();
            p2.Field.DrawUpField();
            p2.Field.DrawDownField();
        }



    }


}
