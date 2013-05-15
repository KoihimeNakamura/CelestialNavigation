using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPack;

namespace StarSystemGurpsGen
{
    public class Dice
    {
            protected MersenneTwister dice = new MersenneTwister((int)DateTime.Now.Ticks/ 10);

            public Dice(){
             }

             public int probablity(int probSize = 100){
                return (int)(probSize * dice.NextDoublePositive() + 1);
            }

            public int gurpsRoll()
            {
                return this.rng(3,6);
            }

            public int gurpsRoll(int mod)
            {
                return this.rng(3, 6, mod);
            }

            public int rng(int size)
            {
                return (int)(size * dice.NextDoublePositive() + 1);
            }

            public int rng(int num, int size)
            {
                int total = 0;
                for (int i = 0; i < num; i++)
                {
                    total = total + this.rng(size);
                }

                return total;
            }

            public int rng(int num, int size, int mod)
            {
                int total;
                total = this.rng(num, size) + mod;
                return total;
            }


            public double rollRange(double startVal, double range){

                return (dice.NextDoublePositive()) * range + startVal;
            }

            public double rollInRange(double startVal, double endVal)
            {
                double range = endVal - startVal;
                return (dice.NextDoublePositive() * range + startVal);
            }

        }


}
