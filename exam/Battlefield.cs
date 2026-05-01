using BaseCard;
using KhaZix_Deck;
using PlayerGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlefieldClass
{
    internal class Battlefield
    {


        Entity[] upBoard = new Entity[6];
        Entity[] downBoard = new Entity[6];
        Player _owner;
        public Battlefield(Player owner)
        {
            _owner = owner;
        }

       //проверка позиции
        public bool IsValidPosition(int position)
        {
            if (position < 0 || position > 5) { return false; }
            return true;
        }

        // выставление карт на поле
        public void placeEntity(int position, Entity entity)
        {
            if (IsValidPosition(position) == false) { return; }
            if (downBoard[position] == null)
            {
                downBoard[position] = entity;
            }
            else { return; }
        }

        // удаление карт с поля
        public void removeEntity(int position)
        {
            if (IsValidPosition(position) == false) { return; }
            if (downBoard[position] != null)
            {
                downBoard[position] = null;
            }
            else { return; }
        }

        // выставление в атаку
        public void moveToAttack(int fromPosition, int toPosition)
        {

            if (IsValidPosition(fromPosition) == false) { return; }
            if (IsValidPosition(toPosition) == false) { return; }

            if (downBoard[fromPosition] == null)
            {
                return;
            }
            if (upBoard[toPosition] != null)
            {
                return;
            }
            upBoard[toPosition] = downBoard[fromPosition];
            downBoard[fromPosition] = null;
        }

        // выставление в защиту
        public void moveToDefend(int attackPosition, int defendPosition)
        {
            if (IsValidPosition(attackPosition) == false) { return; }
            if (IsValidPosition(defendPosition) == false) { return; }

            if (downBoard[defendPosition] == null)
            {
                return;
            }
            if (upBoard[attackPosition] != null)
            {
                return;
            }
            upBoard[attackPosition] = downBoard[defendPosition];
            downBoard[defendPosition] = null;
        }

        // возврат карт после атаки/защиты
        public void ReturnToBottom(int fromPosition, int toPosition)
        {
            if (IsValidPosition(fromPosition) == false) { return; }
            if (IsValidPosition(toPosition) == false) { return; }
            if (upBoard[fromPosition] == null)
            {
                return;
            }
            if (downBoard[toPosition] != null)
            {
                return;
            }
            downBoard[toPosition] = upBoard[fromPosition];
            upBoard[fromPosition] = null;
        }

        // дисплей верхнего поля
        public void DrawUpField()
        {

            string line = "";


            for (int i = 0; i < 6; i++)
            {
                if (upBoard[i] == null)
                {
                    line += '#';
                }
                else if (upBoard[i] is Unit)
                {
                    line += '*';
                }
                else if (upBoard[i] is LandMark) { line += '&'; }
            }
            Console.WriteLine(line);
        }

        // дисплей нижнего поля
        public void DrawDownField()
        {

            string line = "";
            for (int i = 0; i < 6; i++)
            {
                if (downBoard[i] == null)
                {
                    line += '#';
                }
                else if (downBoard[i] is Unit)
                {
                    line += '*';
                }
                else if (downBoard[i] is LandMark) { line += '&'; }
            }

            Console.WriteLine(line);
        }


        // атака
        public bool Attack(int attackerRowPosition, int defenderRowPosition)
        {
            if (upBoard[attackerRowPosition] == null) { return false; }
            if (upBoard[defenderRowPosition] == null) { return false; }

            Unit attacker = upBoard[attackerRowPosition] as Unit;
            Unit defender = upBoard[defenderRowPosition] as Unit;

            if (attacker == null || defender == null) { return false; }
            // if (attacker is LandMark || defender is LandMark) { return false; }

            defender.hitpoint -= attacker.damage;
            attacker.hitpoint -= defender.damage;

            if (defender.hitpoint <= 0 && attacker is KhaZix)
            {
                ((KhaZix)attacker).Evolve(_owner);
            }

            if (defender.hitpoint <= 0)
            {
                _owner.AddToGraveyard(defender);
                upBoard[defenderRowPosition] = null;
            }
            if (attacker.hitpoint <= 0)
            {
                _owner.AddToGraveyard(attacker);
                upBoard[attackerRowPosition] = null;
            }


            return defender.hitpoint <= 0;
        }

        // вычесление позиции карт
        public int GetUnitPosition(Unit unit)
        {
            for (int i = 0; i < downBoard.Length; i++)
            {
                if (downBoard[i] == unit)
                    return i;
            }
            return -1;
        }
    }
}
