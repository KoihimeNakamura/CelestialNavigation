using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    partial class Star : Orbital
    {
        public static decimal stellarMass(int rollA, int rollB)
        {
            decimal[][] numbers = new decimal[][]{
                new decimal[] {0}, //Index 0
                new decimal[] {0}, //Roll 1
                new decimal[] {0}, //Roll 2
                new decimal[] {0,0,0,2m,2m,2m,2m,2m,2m,2m,2m,1.9m,1.9m,1.9m,1.9m,1.9m,1.9m,1.9m,1.9m}, //Roll: 3
                new decimal[] {0,0,0,1.8m,1.8m,1.8m,1.8m,1.8m,1.8m,1.7m,1.7m,1.7m,1.6m,1.6m,1.6m,1.6m,1.6m,1.6m,1.6m}, //Roll: 4
                new decimal[] {0,0,0,1.5m,1.5m,1.5m,1.5m,1.5m,1.45m,1.45m,1.45m,1.4m,1.4m,1.35m,1.35m,1.35m,1.35m,1.35m,1.35m,1.35m}, //Roll:5
                new decimal[] {0,0,0,1.3m,1.3m,1.3m,1.3m,1.3m,1.25m,1.25m,1.2m,1.15m,1.15m,1.1m,1.1m,1.1m,1.1m,1.1m,1.1m}, //Roll: 6
                new decimal[] {0,0,0,1.05m,1.05m,1.05m,1.05m,1.05m,1m,1m,.95m,.9m,.9m,.85m,.85m,.85m,.85m,.85m,.85m}, //Roll: 7
                new decimal[] {0,0,0,.8m,.8m,.8m,.8m,.8m,.8m,.75m,.75m,.7m,.65m,.65m,.6m,.6m,.6m,.6m,.6m,.6m}, //Roll: 8
                new decimal[] {0,0,0.55m,.55m,.55m,.55m,.55m,.55m,.5m,.5m,.5m,.45m,.45m,.45m,.45m,.45m,.45m,.45m}, //Roll: 9
                new decimal[] {0,0,0,.4m,.4m,.4m,.4m,.4m,.4m,.35m,.35m,.35m,.3m,.3m,.3m,.3m,.3m,.3m,.3m}, //Roll: 10
                new decimal[] {0,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m,0.25m}, //Roll 11
                new decimal[] {0,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m,0.2m}, //Roll 12
                new decimal[] {0,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m,0.15m}, //Roll 13
                new decimal[] {0,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m}, //Roll 14
                new decimal[] {0,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m}, //Roll 15
                new decimal[] {0,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m}, //Roll 16
                new decimal[] {0,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m}, //Roll 17
                new decimal[] {0,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m,0.1m}, //Roll 18
            };

            if (rollA > 18 || rollA < 0 || rollB > 18 || rollB < 0) 
                throw new System.ArgumentException("One of the passed dice roll is beyond limits", "original");

            return numbers[rollA][rollB];

  
        }

        public static String getStellarTypeFromMass(decimal mass)
        {
            if (mass <= .125m) return "M7";
            if (.125m < mass && mass <= .175m) return "M6";
            if (.175m < mass && mass <= .225m) return "M5";
            if (.225m < mass && mass <= .325m) return "M4";
            if (.325m < mass && mass <= .375m) return "M3";
            if (.375m < mass && mass <= .425m) return "M2";
            if (.425m < mass && mass <= .475m) return "M1";
            if (.475m < mass && mass <= .525m) return "M0";
            if (.525m < mass && mass <= .575m) return "K8";
            if (.575m < mass && mass <= .625m) return "K6";
            if (.625m < mass && mass <= .675m) return "K5";
            if (.675m < mass && mass <= .725m) return "K4";
            if (.725m < mass && mass <= .775m) return "K2";
            if (.775m < mass && mass <= .825m) return "K0";
            if (.825m < mass && mass <= .875m) return "G8";
            if (.875m < mass && mass <= .925m) return "G6";
            if (.925m < mass && mass <= .975m) return "G4";
            if (.975m < mass && mass <= 1.025m) return "G2";
            if (1.025m < mass && mass <= 1.075m) return "G1";
            if (1.075m < mass && mass <= 1.125m) return "G0";
            if (1.175m < mass && mass <= 1.225m) return "F9";
            if (1.175m < mass && mass <= 1.225m) return "F8";
            if (1.225m < mass && mass <= 1.275m) return "F7";
            if (1.275m < mass && mass <= 1.325m) return "F6";
            if (1.325m < mass && mass <= 1.375m) return "F5";
            if (1.375m < mass && mass <= 1.425m) return "F4";
            if (1.425m < mass && mass <= 1.475m) return "F3";
            if (1.475m < mass && mass <= 1.55m) return "F2";
            if (1.55m < mass && mass <= 1.65m) return "F0";
            if (1.65m < mass && mass <= 1.75m) return "A9";
            if (1.75m < mass && mass <= 1.85m) return "A7";
            if (1.85m < mass && mass <= 1.95m) return "A6";
            if (1.95m < mass && mass <= 2.0m) return "A5";

            return "X0";
        }

        public static String getStellarTypeFromTemp(decimal temp)
        {
            if (temp < 3150m) return "M7";
            if (3150m <= temp && temp < 3175m) return "M6";
            if (3175m <= temp && temp < 3250m) return "M5";
            if (3250m <= temp && temp < 3350m) return "M4";
            if (3350m <= temp && temp < 3450m) return "M3";
            if (3450m <= temp && temp < 3550m) return "M2";
            if (3550m <= temp && temp < 3700m) return "M1";
            if (3700m <= temp && temp < 3900m) return "M0";
            if (3900m <= temp && temp < 4100m) return "K8";
            if (4100m <= temp && temp < 4300m) return "K6";
            if (4300m <= temp && temp < 4500m) return "K5";
            if (4500m <= temp && temp < 4750m) return "K4";
            if (4750m <= temp && temp < 5050m) return "K2";
            if (5050m <= temp && temp < 5300m) return "K0";
            if (5300m <= temp && temp < 5450m) return "G8";
            if (5450m <= temp && temp < 5600m) return "G6";
            if (5600m <= temp && temp < 5750m) return "G4";
            if (5750m <= temp && temp < 5850m) return "G2";
            if (5850m <= temp && temp < 5950m) return "G1";
            if (5950m <= temp && temp < 6050m) return "G0";
            if (6050m <= temp && temp < 6150m) return "F9";
            if (6150m <= temp && temp < 6350m) return "F8";
            if (6350m <= temp && temp < 6450m) return "F7";
            if (6450m <= temp && temp < 6550m) return "F6";
            if (6550m <= temp && temp < 6650m) return "F5";
            if (6650m <= temp && temp < 6750m) return "F4";
            if (6750m <= temp && temp < 6950m) return "F3";
            if (6950m <= temp && temp < 7150m) return "F2";
            if (7150m <= temp && temp < 7400m) return "F0";
            if (7400m <= temp && temp < 7650m) return "A9";
            if (7650m <= temp && temp < 7900m) return "A7";
            if (7900m <= temp && temp < 8100m) return "A6";
            if (8100m <= temp && temp < 8300m) return "A5";

            return "X0";
        }

        public static decimal generateStellarAge(Dice ourBag)
        {
            int roll = ourBag.anySize(1, 10000);
            //roll is 0-10000.
            if (roll < 46) return 0.0m;
            if (roll >= 46 && roll < 926) return ourBag.rollRange(0.1m, 1.9m);
            if (roll >= 926 && roll < 9074) return ourBag.rollRange(2m, 6m);
            if (roll >= 9074 && roll < 9954) return ourBag.rollRange(8m, 2.75m);
            if (roll >= 9954) return ourBag.rollRange(10.75m, 2.95m);

            return 4.60m;

        }

    }
}
