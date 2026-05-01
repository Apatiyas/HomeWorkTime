using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using PlayerGame;
using State;
using BaseEffect;

namespace BaseCard
{
    internal abstract class Card
    {
        public virtual string name { get; set; }
        public virtual int manaCost { get; set; }
        public abstract void OnPlay(Player owner, Player opponent, GameState state);


    }

    internal abstract class Entity : Card
    {

      
        
    }
    internal abstract class Action : Card
    {
      
      
    }

    internal abstract class Unit: Entity
    {
       
       public virtual int hitpoint {  get; set; }
       public virtual int damage {  get; set; }
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
    internal abstract class LandMark : Entity
    {
       public virtual Effect effect { get; set; } 
       
    }

    internal abstract class Spell : Action
    {
        public override abstract void OnPlay(Player owner, Player opponent, GameState state);

    }
    internal abstract class Equipment : Action
    {
        public override abstract void OnPlay(Player owner, Player opponent, GameState state);
    }

}
