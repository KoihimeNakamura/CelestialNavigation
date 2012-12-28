using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPack;

namespace StarSystemGurpsGen
{
    class Dice
    {
            protected MersenneTwister dice = new MersenneTwister((int)DateTime.Now.Ticks/ 10);

            public Dice(){
             }

            public int six()
            {
                return (int)(6 * dice.NextDoublePositive() + 1);
            }

            public int six(int num)
            {
                int total = 0;
                for (int i = 0; i < num; i++)
                {
                    total = total + this.six();
                }

                return total;
            }


            public int six(int num, int mod)
            {
                int total = 0;
                for (int i = 0; i < num; i++)
                {
                    total = total + (this.six() + mod);
                }

                return total;
            }

            public int probablity(int probSize = 100){
                return (int)(probSize * dice.NextDoublePositive() + 1);
            }

            public int gurpsRoll()
            {
                return this.six(3);
            }

 
            public int gurpsRoll(int mod)
            {
                return this.six(3, mod);
            }

            public int anySize(int size)
            {
                return (int)(size * dice.NextDoublePositive() + 1);
            }

            public int anySize(int num, int size)
            {
                int total = 0;
                for (int i = 0; i < num; i++)
                {
                    total = total + this.anySize(size);
                }

                return total;
            }

         
            public int anySize(int num, int size, int mod)
            {
                int total = 0;
                for (int i = 0; i < num; i++)
                {
                    total = total + (this.anySize(size) + mod);
                }

                return total;
            }

            public decimal rollRange(decimal startVal, decimal range){

                return ((decimal)dice.NextDoublePositive()) * range + startVal;
            }

        }


}
