using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GridAdventure1
{
    [JsonObject]
    public class Meeba //also, moves!
    {
        public string name = "Meeba";
        public int ID;
        public string elementType = "Neutral";
        public string description = "The meeba resembles a small fish-like creature, with fins on its dorsal and ventral sides.\nIt has gills near its head, though it appears to breathe perfectly out of water.\n It has an inquisitive look on its face.";
        public int levelTier = 0;
        public int attack = 4;
        public int attackBonus;
        public int currentAttack;
        public int speed = 3;
        public int delugeSpeed = 1000;
        public int speedBonus;
        public int currentSpeed;
        public int defense = 1;
        public int defenseBonus;
        public int currentDef;
        public double hp = 20;
        public int hpBonus;
        public double currentHp = 20;
        public int MP = 30;
        public int currentMP = 30;
        public int hitRange = 60;
        public int PyroclasticFlowCounter = 0;
        public bool lifeLeech = false;
        public int lifeLeechChance = 0;
        public int lifeLeechHeal = 30;
        public bool poisonOne;
        public bool poisonTwo;
        public int poisonChance;
        public List<string> Moves = new List<string>();
        public string newMove;
        public MeebaMoves currentMove = new MeebaMoves();
        public string moveDescription;
        public string HPBar = "HP|////////////////////";
        public string MPBar = "MP|********************";
        public ConsoleColor textColour = ConsoleColor.Gray; //colours for battle sprites
        public bool opponent1Target = false; //is it the target of opponent1?
        public bool opponent2Target = false;
        public bool opponent3Target = false;
        public bool meeba1Target = false;
        public bool meeba2Target = false;
        public bool playerTarget = false;
        public string SpecialChoice;
        public int SpecialChoiceInt;
        public string MoveChoice;
        public bool SpecialChoiceValid = false;
        public double tempSpeed;
        public double tempDefenseStatChange;
        public double tempAccuracy;
        public double tempAttack;
        public bool StatusProtected; 
        public bool DamageProtected;
        public int statusProtectCounterSS;
        public int statusProtectCounterRF;
        public int statusProtectCounterSW;
        public int damageProtectCounter;
        public int CycloneCounter = 0;
        public int DustDevilCounter = 0;
        public int SnowStormCounter = 0;
        public bool validAttackChoice;
        public bool validDefenseChoice;
        public double tempDefense;
        public bool isCurrent;
        public bool hasTakenTurn = false;
        public int battleChoice = 0;
        public bool defensive = false;
        public bool gotMeeba = true;
        public bool isPoisoned = false;
        public bool isPoisonedTwo = false;
        public int poisonTracker = 0;
        public bool isAsleep = false;
        public bool isStunned = false;
        public double LeachingRootsHP = 0; 
        public string[,] sprite = new string[1, 8]  //change based on what animal you chose
                {
                {
                    @"        /\\\\>,        ",
                    @"      /\\~+~+~ '~-._   ",
                    @"     /\-'         @ \  ",
                    @"    /\-       }}}   /  ",
                    @"   /\-    /,,,,,,_-'   ",
                    @"  {\-    //////        ",
                    @"   \\_,  \___.,        ",
                    @"    \_\>_______>       "
                },
                };
        public bool reachedFireTier1 = false;
        public bool reachedFireTier2 = false;
        public bool reachedFireTier3 = false;
        public bool reachedFireTier4 = false;
        public bool reachedPlantTier1 = false;
        public bool reachedPlantTier2 = false;
        public bool reachedPlantTier3 = false;
        public bool reachedPlantTier4 = false;
        public bool reachedEarthTier1 = false;
        public bool reachedEarthTier2 = false;
        public bool reachedEarthTier3 = false;
        public bool reachedEarthTier4 = false;
        public bool reachedAirTier1 = false;
        public bool reachedAirTier2 = false;
        public bool reachedAirTier3 = false;
        public bool reachedAirTier4 = false;
        public bool reachedWaterTier1 = false;
        public bool reachedWaterTier2 = false;
        public bool reachedWaterTier3 = false;
        public bool reachedWaterTier4 = false;
        public bool reachedCharcoalTier1 = false;
        public bool reachedCharcoalTier2 = false;
        public bool reachedCharcoalTier3 = false;
        public bool reachedCharcoalTier4 = false;
        public bool reachedMossTier1 = false;
        public bool reachedMossTier2 = false;
        public bool reachedMossTier3 = false;
        public bool reachedMossTier4 = false;
        public bool reachedDustTier1 = false;
        public bool reachedDustTier2 = false;
        public bool reachedDustTier3 = false;
        public bool reachedDustTier4 = false;
        public bool reachedStormTier1 = false;
        public bool reachedStormTier2 = false;
        public bool reachedStormTier3 = false;
        public bool reachedStormTier4 = false;
        public bool reachedHydrothermTier1 = false;
        public bool reachedHydrothermTier2 = false;
        public bool reachedHydrothermTier3 = false;
        public bool reachedHydrothermTier4 = false;
        public bool radioactiveState = false;

    }

    public class Tinder : Meeba
    {
        public Tinder()
        {
            name = "Tinder Meeba"; //obviously this will change
            elementType = "fire";
            levelTier = 1;
            attackBonus = 9;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Lava Bubble";
            moveDescription = "A small explosion of hot lava"; //CHANGE this should be in meebamoves class
        }
    }

    public class Smoke : Meeba
    {
        public Smoke()
        {
            name = "Smoke Meeba"; //obviously this will change
            elementType = "fire";
            levelTier = 2;
            attackBonus = 20; 
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Phoenix Fire";
        }
    }

    public class Flame : Meeba
    {
        public Flame()
        {
            name = "Flame Meeba"; //obviously this will change
            elementType = "fire";
            levelTier = 3;
            attackBonus = 35;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Pyroclastic Flow";
        }
    }

    public class Infernus : Meeba
    {
        public Infernus()
        {
            name = "Infernus Meeba"; //obviously this will change
            elementType = "fire";
            levelTier = 4;
            attackBonus = 55;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Inferno";
        }
    }

    public class Sprout : Meeba
    {
        public Sprout()
        {
            name = "Sprout Meeba"; //obviously this will change
            elementType = "plant";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 15; //% total hp
            newMove = "Poison Spores";
        }
    }

    public class Grass : Meeba
    {
        public Grass()
        {
            name = "Grass Meeba"; //obviously this will change
            elementType = "plant";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            poisonOne = true;
            poisonChance = 35;
            newMove = "Tangleweed";
        }
    }

    public class Vine : Meeba
    {
        public Vine()
        {
            name = "Vine Meeba"; //obviously this will change
            elementType = "plant";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 25; //% total hp
            newMove = "Slumber Dust";
        }
    }

    public class Forest : Meeba
    {
        public Forest()
        {
            name = "Forest Meeba"; //obviously this will change
            elementType = "plant";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            poisonTwo = true;
            poisonChance = 35;
            newMove = "Thron Grip";
        }
    }

    public class Soil : Meeba
    {
        public Soil()
        {
            name = "Soil Meeba"; //obviously this will change
            elementType = "earth";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 9;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Grainmail";
        }
    }

    public class Boulder : Meeba
    {
        public Boulder()
        {
            name = "Boulder Meeba"; //obviously this will change
            elementType = "earth";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 20;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Quake";
        }
    }

    public class Terra : Meeba
    {
        public Terra()
        {
            name = "Terra Meeba"; //obviously this will change
            elementType = "earth";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 35;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Sand Shroud";
        }
    }

    public class Mount : Meeba
    {
        public Mount()
        {
            name = "Mount Meeba"; //obviously this will change
            elementType = "earth";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 55;
            MP = 120;
            hitRange = 90;
            newMove = "Rock Fort";
        }
    }

    public class Breeze : Meeba
    {
        public Breeze()
        {
            name = "Breeze Meeba"; //obviously this will change
            elementType = "air";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 9;
            defenseBonus = 2;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Static Shock";
        }
    }

    public class Wind : Meeba
    {
        public Wind()
        {
            name = "Wind Meeba"; //obviously this will change
            elementType = "air";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 20;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Windstorm";
        }
    }

    public class Sky : Meeba
    {
        public Sky()
        {
            name = "Sky Meeba"; //obviously this will change
            elementType = "air";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 35;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Tailwind";
        }
    }

    public class Atmos : Meeba
    {
        public Atmos()
        {
            name = "Atmos Meeba"; //obviously this will change
            elementType = "air";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 55;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Cyclone";
        }
    }

    public class Drop : Meeba
    {
        public Drop()
        {
            name = "Drop Meeba"; //obviously this will change
            elementType = "water";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 40;
            MP = 50;
            hitRange = 60;
            newMove = "Tide Pool";
        }
    }

    public class Pond : Meeba
    {
        public Pond()
        {
            name = "Pond Meeba"; //obviously this will change
            elementType = "water";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 60;
            MP = 80;
            hitRange = 70;
            newMove = "Bubble Jet";
        }
    }

    public class Lake : Meeba
    {
        public Lake()
        {
            name = "Lake Meeba"; //obviously this will change
            elementType = "water";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 90;
            MP = 100;
            hitRange = 80;
            newMove = "Deluge";
        }
    }

    public class Ocean : Meeba
    {
        public Ocean()
        {
            name = "Ocean Meeba"; //obviously this will change
            elementType = "water";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 130;
            MP = 120;
            hitRange = 90;
            newMove = "Monsoon";
        }
    }

    public class Cinder : Meeba
    {
        public Cinder()
        {
            name = "Cinder Meeba"; //obviously this will change
            elementType = "charcoal";
            levelTier = 1;
            attackBonus = 6;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            lifeLeech = true;
            lifeLeechChance = 20; //%
            lifeLeechHeal = 15; //% total hp
            newMove = "Bio-Acid";
        }
    }

    public class Ember : Meeba
    {
        public Ember()
        {
            name = "Ember Meeba"; //obviously this will change
            elementType = "charcoal";
            levelTier = 2;
            attackBonus = 11;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            poisonOne = true;
            poisonChance = 20;
            newMove = "Pyriscent Bullets";
        }
    }

    public class Charred : Meeba
    {
        public Charred()
        {
            name = "Charred Meeba"; //obviously this will change
            elementType = "charcoal";
            levelTier = 3;
            attackBonus = 17;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            lifeLeech = true;
            lifeLeechChance = 20; //%
            lifeLeechHeal = 25; //% total hp
            newMove = "Charcoal Smog";
        }
    }

    public class Ash : Meeba
    {
        public Ash()
        {
            name = "Ash Meeba"; //obviously this will change
            elementType = "charcoal";
            levelTier = 4;
            attackBonus = 25;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            poisonTwo = true;
            poisonChance = 20;
            newMove = "Solar Flare";
        }
    }

    public class Algae : Meeba
    {
        public Algae()
        {
            name = "Algae Meeba"; //obviously this will change
            elementType = "moss";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 6;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            lifeLeech = true;
            lifeLeechChance = 20; //%
            lifeLeechHeal = 15; //% total hp
            newMove = "Stonewort";
        }
    }

    public class Lichen : Meeba
    {
        public Lichen()
        {
            name = "Lichen Meeba"; //obviously this will change
            elementType = "moss";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 11;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            poisonOne = true;
            poisonChance = 20;
            newMove = "Thicket Surge";
        }
    }

    public class Bog : Meeba
    {
        public Bog()
        {
            name = "Bog Meeba"; //obviously this will change
            elementType = "moss";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 17;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            lifeLeech = true;
            lifeLeechChance = 20; //%
            lifeLeechHeal = 25; //% total hp
            newMove = "Leaching Roots";
        }
    }

    public class Swamp : Meeba
    {
        public Swamp()
        {
            name = "Swamp Meeba"; //obviously this will change
            elementType = "moss";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 25;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            poisonTwo = true;
            poisonChance = 20;
            newMove = "Toxic Soil";
        }
    }

    public class Sand : Meeba
    {
        public Sand()
        {
            name = "Sand Meeba"; //obviously this will change
            elementType = "dust";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Sandstorm";
        }
    }

    public class Loess : Meeba
    {
        public Loess()
        {
            name = "Loess Meeba"; //obviously this will change
            elementType = "dust";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 11;
            defenseBonus = 11;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Erode";
        }
    }

    public class Dune : Meeba
    {
        public Dune()
        {
            name = "Dune Meeba"; //obviously this will change
            elementType = "dust";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 17;
            defenseBonus = 17;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Landslide";
        }
    }

    public class Desert : Meeba
    {
        public Desert()
        {
            name = "Desert Meeba"; //obviously this will change
            elementType = "dust";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 25;
            defenseBonus = 25;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Dust Devil";
        }
    }

    public class Cloud : Meeba
    {
        public Cloud()
        {
            name = "Cloud Meeba"; //obviously this will change
            elementType = "storm";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 6;
            defenseBonus = 2;
            hpBonus = 20;
            MP = 50;
            hitRange = 60;
            newMove = "Hail";
        }
    }

    public class Hailstone : Meeba
    {
        public Hailstone()
        {
            name = "Hailstone Meeba"; //obviously this will change
            elementType = "storm";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 11;
            defenseBonus = 6;
            hpBonus = 30;
            MP = 80;
            hitRange = 70;
            newMove = "Snowstorm";
        }
    }

    public class Thunder : Meeba
    {
        public Thunder()
        {
            name = "Thunder Meeba"; //obviously this will change
            elementType = "storm";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 17;
            defenseBonus = 10;
            hpBonus = 40;
            MP = 100;
            hitRange = 80;
            newMove = "CureloNimbus";
        }
    }

    public class Lightning : Meeba
    {
        public Lightning()
        {
            name = "Lightning Meeba"; //obviously this will change
            elementType = "storm";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 25;
            defenseBonus = 15;
            hpBonus = 65;
            MP = 120;
            hitRange = 90;
            newMove = "Cloud Burst";
        }
    }

    public class Evapo : Meeba
    {
        public Evapo()
        {
            name = "Evapo Meeba"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 1;
            attackBonus = 6;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 20;
            MP = 50;
            hitRange = 60;
            newMove = "Vaporise";
        }
    }

    public class Vapour : Meeba
    {
        public Vapour()
        {
            name = "Vapour Meeba"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 2;
            attackBonus = 11;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 30;
            MP = 80;
            hitRange = 70;
            newMove = "Hot Spring";
        }
    }

    public class Vent : Meeba
    {
        public Vent()
        {
            name = "Vent Meeba"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 3;
            attackBonus = 17;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 40;
            MP = 100;
            hitRange = 80;
            newMove = "Geyser";
        }
    }

    public class WaterFireTier4 : Meeba
    {
        public WaterFireTier4()
        {
            name = "WaterFireTier4"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 4;
            attackBonus = 25;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 65;
            MP = 120;
            hitRange = 90;
            newMove = "Hydrothermal Blast";
        }
    }
}