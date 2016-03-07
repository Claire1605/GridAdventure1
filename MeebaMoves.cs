using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridAdventure1
{
    public class MeebaMoves
    {
        public string name;
        public string attackType; //"Offensive" gets a target enemy, "OffensiveAll" targets all opponents, "Defensive" gets a target ally, "DefensiveAll" targets all allies, "OffensiveAndDefensive" targets both sides, "OffensiveAndDefensiveAll" targets an opponent and all allies
        public int BMP; //base move power
        public int MP;
        public int currentMp;
        public int accuracy;
        public int poisonChance;
        public int stunChance;
        public int sleepChance;
        public int healChance; 
        public int healAmount; //percentage of maxhp
        public double defIncrease; //multiply by this 
        public int spdChance;
        public double spdIncrease;
        public bool damageProtection;
        public bool statusProtection;
        public double attackIncrease;
        public double oppDefenseDecrease;
        public double oppSpeedDecrease;
        public string moveType;
        //Damage Formula: ((playerStrength/opponent.defense) * BMP * TypeEffect * STAB * Items) * Hit%
    }

    public class MeebaPower : MeebaMoves
    {
        public MeebaPower()
        {
            name = "Meeba Power";
            attackType = "Offensive";
            BMP = 2;
            MP = 0;
            accuracy = 99;
            moveType = "Neutral";
        }
    }

    public class LavaBubble : MeebaMoves
    {
        public LavaBubble()
        {
            name = "Lava Bubble";
            attackType = "OffensiveAll";
            BMP = 5;
            MP = 4;
            accuracy = 85;
            moveType = "Fire";
        }
    }

    public class PhoenixFire : MeebaMoves
    {
        public PhoenixFire()
        {
            name = "Phoenix Fire";
            attackType = "OffensiveAndDefensive";
            BMP = 10;
            MP = 8;
            accuracy = 85;
            healChance = 99; 
            healAmount = 30;
            moveType = "Fire";
        }
    }

    public class PyroclasticFlow : MeebaMoves
    {
        public PyroclasticFlow()
        {
            name = "Pyroclastic Flow";
            attackType = "OffensiveAll";
            BMP = 15;
            MP = 13;
            accuracy = 99;
            moveType = "Fire";
            //delayed until next turn - think of a way to do this!
        }
    }

    public class Inferno : MeebaMoves
    {
        public Inferno()
        {
            name = "Inferno";
            attackType = "Offensive";
            BMP = 23;
            MP = 20;
            accuracy = 70;
            moveType = "Fire";
        }
    }

    public class PoisonSpores : MeebaMoves
    {
        public PoisonSpores ()
        {
            name = "Poison Spores";
            attackType = "Offensive";
            MP = 4;
            accuracy = 85;
            poisonChance = 99;
            moveType = "Plant";
        }
    }

    public class Tangleweed : MeebaMoves
    {
        public Tangleweed()
        {
            name = "Tangleweed";
            attackType = "Offensive";
            BMP = 7;
            MP = 8;
            accuracy = 90;
            stunChance = 50; 
            moveType = "Plant";
        }
    }

    public class SlumberDust : MeebaMoves
    {
        public SlumberDust()
        {
            name = "Slumber Dust";
            attackType = "Offensive";
            MP = 10;
            accuracy = 85;
            sleepChance = 80; 
            moveType = "Plant";
        }
    }

    public class ThornGrip : MeebaMoves
    {
        public ThornGrip()
        {
            name = "Thorn Grip";
            attackType = "Offensive";
            BMP = 20;
            MP = 19;
            accuracy = 80;
            moveType = "Plant";
        }
    }

    public class Grainmail : MeebaMoves
    {
        public Grainmail()
        {
            name = "Grainmail";
            attackType = "Defensive";
            MP = 3;
            accuracy = 99;
            defIncrease = 1.2; //to 3*original maximum
            moveType = "Earth";
        }
    }

    public class Quake : MeebaMoves
    {
        public Quake()
        {
            name = "Quake";
            attackType = "Offensive";
            BMP = 10;
            MP = 8;
            accuracy = 95;
            moveType = "Earth";
        }
    }

    public class SandShroud : MeebaMoves
    {
        public SandShroud()
        {
            name = "Sand Shroud";
            attackType = "Defensive";
            MP = 12;
            accuracy = 99;
            damageProtection = true;
            statusProtection = true; //one ally, one turn
            moveType = "Earth";
        }
    }

    public class RockFort : MeebaMoves
    {
        public RockFort()
        {
            name = "Rock Fort";
            attackType = "DefensiveAll";
            MP = 18;
            accuracy = 99;
            defIncrease = 1.5; //to 3*original maximum
            statusProtection = true; //3 turns, all allies
            moveType = "Earth";
        }
    }

    public class StaticShock : MeebaMoves
    {
        public StaticShock()
        {
            name = "Static Shock";
            attackType = "Defensive";
            MP = 3;
            accuracy = 99;
            spdIncrease = 1.2; //to 3*original maximum, one ally
            moveType = "Air";
        }
    }

    public class Windstorm : MeebaMoves
    {
        public Windstorm()
        {
            name = "Windstorm";
            attackType = "OffensiveAndDefensive";
            BMP = 9;
            MP = 7;
            accuracy = 95;
            spdChance = 20; //self
            spdIncrease = 1.2; //to 3*original maximum
            moveType = "Air";
        }
    }

    public class Tailwind : MeebaMoves
    {
        public Tailwind()
        {
            name = "Tailwind";
            attackType = "DefensiveAll";
            MP = 10;
            accuracy = 99;
            spdIncrease = 1.5; //to 3*original maximum
            moveType = "Air";
        }
    }

    public class Cyclone : MeebaMoves
    {
        public Cyclone()
        {
            name = "Cyclone";
            attackType = "DefensiveAll";
            MP = 20;
            accuracy = 90;
            defIncrease = 1.3; //to 3*original maximum
            spdIncrease = 1.3; //3 turns, all allies
            moveType = "Air";
        }
    }

    public class TidePool : MeebaMoves
    {
        public TidePool()
        {
            name = "Tide Pool";
            attackType = "Defensive";
            MP = 4;
            accuracy = 85;
            healChance = 99;
            healAmount = 20; //one ally
            moveType = "Water";
        }
    }

    public class BubbleJet : MeebaMoves
    {
        public BubbleJet()
        {
            name = "Bubble Jet";
            attackType = "OffensiveAndDefensive";
            BMP = 6;
            MP = 8;
            accuracy = 95;
            healChance = 30;
            healAmount = 10; //self
            moveType = "Water";
        }
    }

    public class Deluge : MeebaMoves
    {
        public Deluge()
        {
            name = "Deluge";
            attackType = "Offensive";
            BMP = 14;
            MP = 12;
            accuracy = 90; 
            moveType = "Water";
        }
    }

    public class Monsoon : MeebaMoves
    {
        public Monsoon()
        {
            name = "Monsoon";
            attackType = "DefensiveAll";
            MP = 20;
            accuracy = 60;
            healChance = 99;
            healAmount = 40;
            moveType = "Water";
        }
    }

    public class BioAcid : MeebaMoves
    {
        public BioAcid()
        {
            name = "Bio Acid";
            attackType = "Offensive";
            BMP = 3;
            MP = 4;
            accuracy = 90;
            poisonChance = 50;
            moveType = "Charcoal";
        }
    }

    public class PyriscentBullets : MeebaMoves
    {
        public PyriscentBullets()
        {
            name = "Pyriscent Bullets";
            attackType = "Offensive";
            BMP = 3; //up to 3 chances - like fury swipes etc.
            MP = 7;
            accuracy = 70;
            moveType = "Charcoal";
        }
    }

    public class CharcoalSmog : MeebaMoves
    {
        public CharcoalSmog()
        {
            name = "Charcoal Smog";
            attackType = "OffensiveAndDefensive";
            MP = 11;
            accuracy = 95;
            sleepChance = 30;
            attackIncrease = 1.2; //self
            moveType = "Charcoal";
        }
    }

    public class SolarFlare : MeebaMoves
    {
        public SolarFlare()
        {
            name = "Solar Flare";
            attackType = "Offensive";
            BMP = 19;
            MP = 18;
            accuracy = 95;
            stunChance = 40;
            moveType = "Charcoal";
        }
    }

    public class Stonewort : MeebaMoves
    {
        public Stonewort()
        {
            name = "Stonewort";
            attackType = "Defensive";
            MP = 3;
            accuracy = 90;
            statusProtection = true; //2 turns, all allies
            moveType = "Moss";
        }
    }

    public class ThicketSurge : MeebaMoves
    {
        public ThicketSurge()
        {
            name = "Thicket Surge";
            attackType = "OffensiveAndDefensive";
            BMP = 7;
            MP = 7;
            accuracy = 90;
            defIncrease = 1.2; //to 3*original maximum, self
            moveType = "Moss";
        }
    }

    public class ToxicSoil : MeebaMoves
    {
        public ToxicSoil()
        {
            name = "Toxic Soil";
            attackType = "OffensiveAndDefensiveAll";
            MP = 12;
            accuracy = 95;
            defIncrease = 1.5; //to 3*original maximum, all allies
            poisonChance = 20;
            moveType = "Moss";
        }
    }

    public class LeachingRoots : MeebaMoves
    {
        public LeachingRoots()
        {
            name = "Leaching Roots";
            attackType = "OffensiveAndDefensive";
            BMP = 20;
            MP = 17;
            accuracy = 95;
            healChance = 99;
            healAmount = 0; //not quite - 40% of damage inflicted on opponent
            moveType = "Moss";
        }
    }

    public class Sandstorm : MeebaMoves
    {
        public Sandstorm()
        {
            name = "Sandstorm";
            attackType = "Offensive";
            MP = 4;
            accuracy = 99;
            oppDefenseDecrease = 0.8; //to 3*original maximum
            stunChance = 30;
            moveType = "Dust";
        }
    }

    public class Erode : MeebaMoves
    {
        public Erode()
        {
            name = "Erode";
            attackType = "OffensiveAndDefensive";
            MP = 6;
            accuracy = 99;
            oppDefenseDecrease = 0.8; //to 3*original maximum
            defIncrease = 1.2; //self
            moveType = "Dust";
        }
    }

    public class Landslide : MeebaMoves
    {
        public Landslide()
        {
            name = "Landslide";
            attackType = "OffensiveAndDefensive";
            BMP = 14;
            MP = 12;
            accuracy = 95;
            spdIncrease = 1.2; //to 3*original maximum
            moveType = "Dust";
        }
    }

    public class DustDevil : MeebaMoves
    {
        public DustDevil()
        {
            name = "Dust Devil";
            attackType = "OffensiveAndDefensiveAll";
            MP = 16;
            accuracy = 99;
            defIncrease = 1.3; //all allies
            oppSpeedDecrease = 0.8; //3 turns
            moveType = "Dust";
        }
    }

    public class Hail : MeebaMoves
    {
        public Hail()
        {
            name = "Hail";
            attackType = "OffensiveAndDefensive";
            BMP = 3;
            MP = 4;
            accuracy = 95;
            spdIncrease = 1.2; //to 3*original maximum
            moveType = "Storm";
        }
    }

    public class Snowstorm : MeebaMoves
    {
        public Snowstorm()
        {
            name = "Snowstorm";
            attackType = "OffensiveAndDefensiveAll";
            BMP = 7;
            MP = 10;
            accuracy = 99;
            healChance = 99;
            healAmount = 10; //self, for 3 turns
            moveType = "Storm";
        }
    }

    public class Curelonimbus : MeebaMoves
    {
        public Curelonimbus()
        {
            name = "Curelonimbus";
            attackType = "Defensive";
            MP = 12;
            accuracy = 99;
            healChance = 99;
            healAmount = 40;
            moveType = "Storm";
        }
    }

    public class CloudBurst : MeebaMoves
    {
        public CloudBurst()
        {
            name = "Cloud Burst";
            attackType = "OffensiveAndDefensiveAll";
            MP = 18;
            accuracy = 90;
            oppSpeedDecrease = 0.8; //to 3*original maximum
            healChance = 99;
            healAmount = 20; //all allies
            moveType = "Storm";
        }
    }

    public class Vaporise : MeebaMoves
    {
        public Vaporise()
        {
            name = "Vaporise";
            attackType = "Offensive";
            BMP = 4;
            MP = 4;
            accuracy = 90;
            moveType = "Hydrotherm";
        }
    }

    public class HotSpring : MeebaMoves
    {
        public HotSpring()
        {
            name = "Hot Spring";
            attackType = "DefensiveAll";
            MP = 8;
            accuracy = 50;
            healChance = 99;
            healAmount = 15; 
            moveType = "Hydrotherm";
        }
    }

    public class Geyser : MeebaMoves
    {
        public Geyser()
        {
            name = "Geyser";
            attackType = "OffensiveAndDefensive";
            BMP = 15;
            MP = 11;
            accuracy = 95;
            healChance = 30;
            healAmount = 20; //self
            moveType = "Hydrotherm";
        }
    }

    public class HydrothermalBlast : MeebaMoves
    {
        public HydrothermalBlast()
        {
            name = "Hydrothermal Blast";
            attackType = "OffensiveAndDefensiveAll";
            BMP = 20;
            MP = 20;
            accuracy = 85;
            healChance = 99;
            healAmount = 20; 
            moveType = "Hydrotherm";
        }
    }
}
