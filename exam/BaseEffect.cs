using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseEffect
{
    internal abstract class Effect
    {
        protected Effect() { }
    }



    internal class TrampleEffect : Effect
    {
        int CalculateExcessDamage(int damage, int hitpoint)
        {
            return damage-hitpoint;
        }
    }

    internal class ResilienceEffect : Effect
    {
        int ReduceDamage(int damage) {
            if (damage <= 0) { return 0; }
        return damage-1;
        }

    }
}
