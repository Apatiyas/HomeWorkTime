using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerGame;

namespace State
{
    internal class GameState
    {
        public Player p1 { get; private set; }
        public Player p2 { get; private set; }
        public Player ActivePlayer { get; private set; }

        public GameState(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            ActivePlayer = p1;
        }
        public Player GetOpponent()
        {
            if (ActivePlayer == p1)
            {
                return p2;
            }
            else { return p1; }
        }
        public void SwitchActivePlayer()
        {
            if (ActivePlayer == p1) { ActivePlayer = p2; }
            else { ActivePlayer = p1; }
        }
        public bool IsGameOver()
        {
            if (p1.hitPoints <= 0 || p2.hitPoints <= 0)
            {
                return true;
            }
            return false;
        }
        public Player GetWinner()
        {
            if (p1.hitPoints <= 0 && p2.hitPoints <= 0)
            {
                return null;
            }
            else if (p1.hitPoints <= 0)
            {
                return p2;
            }
            else if (p2.hitPoints <= 0)
            {
                return p1;
            }
            return null;
        }
    }
}
