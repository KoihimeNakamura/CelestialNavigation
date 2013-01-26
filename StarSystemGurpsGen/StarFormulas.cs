using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    partial class Star : Orbital
    {

        //object arrays.
        public static double[][] starMass = new double[][]{
                 new double[] {0}, //Index 0
                 new double[] {0}, //Roll 1
                 new double[] {0}, //Roll 2
                 new double[] {0,0,0,2,2,2,2,2,2,2,2,1.9,1.9,1.9,1.9,1.9,1.9,1.9,1.9}, //Roll: 3
                 new double[] {0,0,0,1.8,1.8,1.8,1.8,1.8,1.8,1.7,1.7,1.7,1.6,1.6,1.6,1.6,1.6,1.6,1.6}, //Roll: 4
                 new double[] {0,0,0,1.5,1.5,1.5,1.5,1.5,1.45,1.45,1.45,1.4,1.4,1.35,1.35,1.35,1.35,1.35,1.35,1.35}, //Roll:5
                 new double[] {0,0,0,1.3,1.3,1.3,1.3,1.3,1.25,1.25,1.2,1.15,1.15,1.1,1.1,1.1,1.1,1.1,1.1}, //Roll: 6
                 new double[] {0,0,0,1.05,1.05,1.05,1.05,1.05,1,1,.95,.9,.9,.85,.85,.85,.85,.85,.85}, //Roll: 7
                 new double[] {0,0,0,.8,.8,.8,.8,.8,.8,.75,.75,.7,.65,.65,.6,.6,.6,.6,.6,.6}, //Roll: 8
                 new double[] {0,0,0.55,.55,.55,.55,.55,.55,.5,.5,.5,.45,.45,.45,.45,.45,.45,.45}, //Roll: 9
                 new double[] {0,0,0,.4,.4,.4,.4,.4,.4,.35,.35,.35,.3,.3,.3,.3,.3,.3,.3}, //Roll: 10
                 new double[] {0,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25}, //Roll 11
                 new double[] {0,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2}, //Roll 12
                 new double[] {0,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15}, //Roll 13
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 14
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 15
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 16
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 17
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 18
             };


        public static double[][] minLuminTable = new double[34][]{
            new double[2]{.1,.0012},
            new double[2]{.15,.0036},
            new double[2] { .2, .0079 },
            new double[2] { .25, .015 },
            new double[2] { .3, .024 },
            new double[2] { .35, .037 },
            new double[2] { .4, .054 },
            new double[2] { .45, .07 },
            new double[2] { .5, .09 },
            new double[2] { .55, .11 },
            new double[2] { .6, .13 },
            new double[2] { .65, .15 },
            new double[2] { .7, .12 },
            new double[2] { .75, .23 },
            new double[2] { .8, .28 },
            new double[2] { .85, .36 },
            new double[2] { .9, .45 },
            new double[2] { .95, .56 },
            new double[2] { 1, .68 },
            new double[2] { 1.05, .87 },
            new double[2] { 1.1, 1.1 },
            new double[2] { 1.15, 1.4 },
            new double[2] { 1.2, 1.7 },
            new double[2] { 1.25, 2.1 },
            new double[2] { 1.3, 2.5 },
            new double[2] { 1.35, 3.1 },
            new double[2] { 1.4, 3.7 },
            new double[2] { 1.45, 4.3 },
            new double[2] { 1.5, 5.1 },
            new double[2] { 1.6, 6.7 },
            new double[2] { 1.7, 8.6 },
            new double[2] { 1.8, 11 },
            new double[2] { 1.9, 13 },
            new double[2] { 2, 16 },
        };  

        public static double stellarMass(int rollA, int rollB)
        {
           if (rollA > 18 || rollA < 0 || rollB > 18 || rollB < 0) 
                throw new System.ArgumentException("One of the passed dice roll is beyond limits", "original");

            return Star.starMass[rollA][rollB];   
        }

        public static String getStellarTypeFromMass(double mass)
        {
            if (mass <= .125) return "M7";
            if (.125 < mass && mass <= .175) return "M6";
            if (.175 < mass && mass <= .225) return "M5";
            if (.225 < mass && mass <= .325) return "M4";
            if (.325 < mass && mass <= .375) return "M3";
            if (.375 < mass && mass <= .425) return "M2";
            if (.425 < mass && mass <= .475) return "M1";
            if (.475 < mass && mass <= .525) return "M0";
            if (.525 < mass && mass <= .575) return "K8";
            if (.575 < mass && mass <= .625) return "K6";
            if (.625 < mass && mass <= .675) return "K5";
            if (.675 < mass && mass <= .725) return "K4";
            if (.725 < mass && mass <= .775) return "K2";
            if (.775 < mass && mass <= .825) return "K0";
            if (.825 < mass && mass <= .875) return "G8";
            if (.875 < mass && mass <= .925) return "G6";
            if (.925 < mass && mass <= .975) return "G4";
            if (.975 < mass && mass <= 1.025) return "G2";
            if (1.025 < mass && mass <= 1.075) return "G1";
            if (1.075 < mass && mass <= 1.125) return "G0";
            if (1.175 < mass && mass <= 1.20) return "F9";
            if (1.20 < mass && mass <= 1.225) return "F8";
            if (1.225 < mass && mass <= 1.275) return "F7";
            if (1.275 < mass && mass <= 1.325) return "F6";
            if (1.325 < mass && mass <= 1.375) return "F5";
            if (1.375 < mass && mass <= 1.425) return "F4";
            if (1.425 < mass && mass <= 1.475) return "F3";
            if (1.475 < mass && mass <= 1.55) return "F2";
            if (1.55 < mass && mass <= 1.65) return "F0";
            if (1.65 < mass && mass <= 1.75) return "A9";
            if (1.75 < mass && mass <= 1.85) return "A7";
            if (1.85 < mass && mass <= 1.95) return "A6";
            if (1.95 < mass && mass <= 2.0) return "A5";

            return "X0";
        }

        public static String getStellarTypeFromTemp(double temp)
        {
            if (temp < 3150) return "M7";
            if (3150 <= temp && temp < 3175) return "M6";
            if (3175 <= temp && temp < 3250) return "M5";
            if (3250 <= temp && temp < 3350) return "M4";
            if (3350 <= temp && temp < 3450) return "M3";
            if (3450 <= temp && temp < 3550) return "M2";
            if (3550 <= temp && temp < 3700) return "M1";
            if (3700 <= temp && temp < 3900) return "M0";
            if (3900 <= temp && temp < 4100) return "K8";
            if (4100 <= temp && temp < 4300) return "K6";
            if (4300 <= temp && temp < 4500) return "K5";
            if (4500 <= temp && temp < 4750) return "K4";
            if (4750 <= temp && temp < 5050) return "K2";
            if (5050 <= temp && temp < 5300) return "K0";
            if (5300 <= temp && temp < 5450) return "G8";
            if (5450 <= temp && temp < 5600) return "G6";
            if (5600 <= temp && temp < 5750) return "G4";
            if (5750 <= temp && temp < 5850) return "G2";
            if (5850 <= temp && temp < 5950) return "G1";
            if (5950 <= temp && temp < 6050) return "G0";
            if (6050 <= temp && temp < 6150) return "F9";
            if (6150 <= temp && temp < 6350) return "F8";
            if (6350 <= temp && temp < 6450) return "F7";
            if (6450 <= temp && temp < 6550) return "F6";
            if (6550 <= temp && temp < 6650) return "F5";
            if (6650 <= temp && temp < 6750) return "F4";
            if (6750 <= temp && temp < 6950) return "F3";
            if (6950 <= temp && temp < 7150) return "F2";
            if (7150 <= temp && temp < 7400) return "F0";
            if (7400 <= temp && temp < 7650) return "A9";
            if (7650 <= temp && temp < 7900) return "A7";
            if (7900 <= temp && temp < 8100) return "A6";
            if (8100 <= temp && temp < 8300) return "A5";

            return "X0";
        }

        public static double generateStellarAge(Dice ourBag)
        {
            int roll = ourBag.rng(1, 10000);
            //roll is 0-10000.
            if (roll < 46) return 0.0;
            if (roll >= 46 && roll < 926) return ourBag.rollRange(0.1, 1.9);
            if (roll >= 926 && roll < 9074) return ourBag.rollRange(2, 6);
            if (roll >= 9074 && roll < 9954) return ourBag.rollRange(8, 2.75);
            if (roll >= 9954) return ourBag.rollRange(10.75, 2.95);

            return 4.58;

        }

    }
}
