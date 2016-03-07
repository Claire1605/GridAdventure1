using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GridAdventure1
{
    [JsonObject]
    public class Enemy
    {
        public string name;
        public List<string> names = new List<string>();
        public double MaxHP;
        public double HP;
        public double MaxMP;
        public double MP;
        public double strength;
        public double defense;
        public double tempDefenseStatChange; //for in-battle stat changes
        public double tempDefense; //for defend mode
        public double speed;
        public double tempSpeedStatChange; //for in-battle stat changes
        public double exp;
        public int hit;
        public double accuracy = 95;
        public double tempAttack;   
        public double tempAccuracy;
        public List<string> area;
        public string[,] animation;
        public List<string> itemDrop;
        public int itemDropRate;
        public string elementType;
        public int choice;
        public string HPBar = "HP|////////////////////";
        public string MPBar = "MP|********************";
        public ConsoleColor textColour = ConsoleColor.Gray; //colours for battle sprites
        public bool meeba1Target = false;
        public bool meeba2Target = false;
        public bool playerTarget = false;
        public bool opponent1Target = false; //is it the target of opponent1?
        public bool opponent2Target = false;
        public bool opponent3Target = false;
        public bool hasTakenTurn = false;
        public bool defensive = false;
        public bool lifeLeech = true;
        public int lifeLeechChance;
        public int lifeLeechHeal;
       // public bool statusProtected = false;
        public double LeachingRootsHP = 0;
        public int ID = 0;
        public bool active = false;
        public bool isPoisoned = false;
        public bool isPoisonedTwo = false;
        public bool isAsleep = false;
        public bool isStunned = false;
        public bool StatusProtected;
        public bool DamageProtected;
        public int statusProtectCounterSS;
        public int statusProtectCounterRF;
        public int statusProtectCounterSW;
        public int damageProtectCounter;
        public int CycloneCounter = 0;
        public int DustDevilCounter = 0;
        public int SnowStormCounter = 0;
        public int PyroclasticFlowCounter = 0;
        public int poisonTracker = 0;
        public int poisonChance;
        public bool poisonOne;
        public bool poisonTwo;
        public bool ranAway = false;
        public int encounterRate;
        public string MoveChoice;
        public MeebaMoves currentMove = new MeebaMoves();
        public List<string> Moves = new List<string>();
        public int money = 0;

    }
    public class Fire1a : Enemy
    {
        public Fire1a()
        {
            name = "";
            names.Add("Embeetle");
            names.Add("Infernant");
            names.Add("Flambug");
            elementType = "Fire";
            MaxHP = 12;
            HP = 12;
            strength = 7;
            defense = 3;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Lava Bubble");
            Moves.Add("Bio Acid");
            area = new List<string>() { "fire area 1", "fire area 2", "rifton cave" };
            itemDrop = new List<string>() { "fire egg", "flame gloop", "coal armour" }; //40% chance of nothing, 1st = 30% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"                       ",
                     @",     ,      ______    ",
                     @" \    |  __ /      \   ",
                     @"  \  _|_/  \'       \  ",
                     @"   |/ | \   \________| ",
                     @"   @  @ /__//\____\__/ ",
                     @"   ;--;'  _/  \_   \_  "
                },
                {
                    @"                       ",
                    @"                       ",
                    @"   ,  ,      ______    ",
                    @"   |  |  __ /      \   ",
                    @"   | _|_/  \'       \  ",
                    @"   |/ | \   \________| ",
                    @"   @  @ /__//\____\__/ ",
                    @"   .;;.'  _/  \_   \_  "

                },
                {
                     @"                       ",
                     @"                       ",
                     @"   ,    ,    ______    ",
                     @"   |   / __ /      \   ",
                     @"   | _/_/  \'       \  ",
                     @"   |/ | \   \________| ",
                     @"   @  @ /__//\____\__/ ",
                     @"   ;--;'  _/  \_   \_  "
                },
                {
                    @"                       ",
                    @"                       ",
                    @"   ,  ,      ______    ",
                    @"   |  |  __ /      \   ",
                    @"   | _|_/  \'       \  ",
                    @"   |/ | \   \________| ",
                    @"   @  @ /__//\____\__/ ",
                    @"   .;;.'  _/  \_   \_  "
                },
                {
                     @"                       ",
                     @"                       ",
                     @"   ,  ,      ______    ",
                     @"   |  |  __ /      \   ",
                     @"   | _|_/  \'       \  ",
                     @"   |/ | \   \________| ",
                     @"   @  @ /__//\____\__/ ",
                     @"   ;--;'  _/  \_   \_  "
                },
                };
        }
    }
    class Fire1b : Enemy
    {
        public Fire1b()
        {
            name = "";
            names.Add("Flame slugger");
            names.Add("Blastropod");
            elementType = "Fire";
            MaxHP = 13;
            HP = 13;
            strength = 9;
            defense = 4;
            speed = 2;
            exp = 3;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Lava Bubble");
            Moves.Add("Vaporise");
            area = new List<string>() {"fire area 1", "fire area 2", "rifton beach"};
            itemDrop = new List<string>() { "flame gloop", "fire egg", "flint" };
            itemDropRate = 1;
            money = 0;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"@    @      _____      ",
                     @" \   |     // __ \     ",
                     @"  \~~|    |/ // \ |    ",
                     @"  {~~~}   || ||\_||    ",
                     @"   {~~~}  \\ \\_/ /    ",
                     @"    {~~~~~'--'\__/~~~, ",
                     @"      {~~~~~~~~~~~~~~  "
                },
                {
                     @"                       ",
                     @" @    @     _____      ",
                     @"  \   |    // __ \     ",
                     @"   \~~|   |/ // \ |    ",
                     @"   {~~~}  || ||\_||    ",
                     @"    {~~~} \\ \\_/ /    ",
                     @"     {~~~~'--'\__/~~,  ",
                     @"       {~~~~~~~~~~~~   "

                },
                {
                     @"                       ",
                     @"  @    @    _____      ",
                     @"   \   |   // __ \     ",
                     @"    \~~|  |/ // \ |    ",
                     @"    {~~~} || ||\_||    ",
                     @"     {~~~}\\ \\_/ /    ",
                     @"      {~~~'--'\__/~,   ",
                     @"        {~~~~~~~~~~    "
                },
                {
                     @"                       ",
                     @"            _____      ",
                     @"           // __ \     ",
                     @"    @    @|/ // \ |    ",
                     @"     \   ||| ||\_||    ",
                     @"      \~~|\\ \\_/ /    ",
                     @"       {~~'--'\__/,    ",
                     @"        {~~~~~~~~~     "
                },
                {
                     @"                       ",
                     @"            _____      ",
                     @"           // __ \     ",
                     @"          |/ // \ |    ",
                     @"     _   _|| ||\_||    ",
                     @"      \  |\\ \\_/ /    ",
                     @"        \~'--'\__/,    ",
                     @"          {~~~~~~~     "
                },
                };
        }
    }
    class Fire2a : Enemy
    {
        public Fire2a()
        {
            name = "";
            names.Add("Coalder");
            names.Add("Goluma");
            elementType = "Fire";
            MaxHP = 35;
            HP = 35;
            strength = 29;
            defense = 10;
            speed = 8;
            exp = 10;
            hit = 70;
            MaxMP = 38;
            MP = 38;
            Moves.Clear();
            Moves.Add("Phoenix Fire");
            Moves.Add("Pyriscent Bullets");
            area = new List<string>() {"fire area 2", "fire area 3"};
            itemDrop = new List<string>() { "coal armour", "flint", "fire fang" };
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Fire2b : Enemy
    {
        public Fire2b()
        {
            name = "";
            names.Add("Blazeard");
            names.Add("Glowcko");
            names.Add("Salascorch");
            elementType = "Fire";
            MaxHP = 35;
            HP = 35;
            strength = 27;
            defense = 10;
            speed = 12;
            exp = 9;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Phoenix Fire");
            Moves.Add("Hot Spring");
            area = new List<string>() {"fire area 2", "fire area 3"};
            itemDrop = new List<string>() { "flint", "coal armour", "burning tail" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Fire3a : Enemy
    {
        public Fire3a()
        {
            name = "";
            names.Add("Pyrena");
            names.Add("Lupusmog");
            elementType = "Fire";
            MaxHP = 56;
            HP = 56;
            strength = 64;
            defense = 20;
            speed = 20;
            exp = 25;
            hit = 80;
            MaxMP = 60;
            MP = 60;
            Moves.Clear();
            Moves.Add("Pyroclastic Flow");
            Moves.Add("Charcoal Smog");
            area = new List<string>() {"fire area 3", "fire area 4"};
            itemDrop = new List<string>() { "fire fang", "burning tail", "infernal scale" };
            itemDropRate = 1;
            money = 8;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Fire3b : Enemy
    {
        public Fire3b()
        {
            name = "";
            names.Add("Rattlebattle");
            names.Add("Emboa");
            names.Add("Coburn");
            elementType = "Fire";
            MaxHP = 53;
            HP = 53;
            strength = 60;
            defense = 19;
            speed = 24;
            exp = 24;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Pyroclastic Flow");
            Moves.Add("Geyser");
            area = new List<string>() {"fire area 3", "fire area 4"};
            itemDrop = new List<string>() { "burning tail", "fire fang", "lava rock" };
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                    @"      __               ",
                    @"    @/ @-\             ",
                    @"     ; /\Z\            ",
                    @"     /'  \Z\       _-> ",
                    @"  >-'    /Z/____  //   ",
                    @"        /Z/x___z\_\\   ",
                    @"       |Z/_____x\_z/   ",
                    @"       \X/X\X/X\/      "
                },
                {
                    @"      __               ",
                    @"    @/ @-\             ",
                    @"     ; /\Z\            ",
                    @"     /'  \Z\      _->  ",
                    @"   >'    /Z/____ //    ",
                    @"        /Z/x___z\\\    ",
                    @"       |Z/_____x\z/    ",
                    @"       \X/X\X/X\/      "

                },
                {
                    @"      __               ",
                    @"    @/ @-\             ",
                    @"     ; /\Z\        >   ",
                    @"     |'  \Z\     _/    ",
                    @"     ^   /Z/____//     ",
                    @"        /Z/x___z\\     ",
                    @"       |Z/_____x\/     ",
                    @"       \X/X\X/X\/      "
                },
                {
                    @"      __               ",
                    @"    @/ @-\             ",
                    @"     ; /\Z\      >     ",
                    @"     \'  \Z\    _|     ",
                    @"      <  /Z/___//      ",
                    @"        /Z/x___z\      ",
                    @"       |Z/_____x |     ",
                    @"       \X/X\X/X\/      "
                },
                {
                    @"      __               ",
                    @"    @/ @-\             ",
                    @"     ; /\Z\    <       ",
                    @"     \'  \Z\    \      ",
                    @"      '< /Z/___//      ",
                    @"        /Z/x___z\      ",
                    @"       |Z/_____x |     ",
                    @"       \X/X\X/X\/      "
                },
                };
        }
    }
    class Fire4a : Enemy
    {
        public Fire4a()
        {
            name = "";
            names.Add("Flambomb");
            names.Add("Lavassault");
            elementType = "Fire";
            MaxHP = 85;
            HP = 85;
            strength = 105;
            defense = 34;
            speed = 40;
            exp = 50;
            hit = 85;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Inferno");
            Moves.Add("Solar Flare");
            area = new List<string>() {"fire area 4"};
            itemDrop = new List<string>() { "fire fang", "infernal scale", "lava rock" };
            itemDropRate = 1;
            money = 0;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Fire4b : Enemy
    {
        public Fire4b()
        {
            name = "";
            names.Add("Confladragon");
            names.Add("Incandrake");
            elementType = "Fire";
            MaxHP = 88;
            HP = 88;
            strength = 115;
            defense = 32;
            speed = 40;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Inferno");
            Moves.Add("Hydrothermal Blast");
            area = new List<string>() {"fire area 4"};
            itemDrop = new List<string>() { "burning tail", "lava rock", "infernal scale" };
            itemDropRate = 1;
            money = 12;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Plant1a : Enemy
    {
        public Plant1a()
        {
            name = "";
            names.Add("Exgerminate");
            names.Add("Kernel");
            elementType = "Plant";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 3;
            speed = 3;
            exp = 1;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            lifeLeech = true;
            lifeLeechChance = 30; //%
            lifeLeechHeal = 15; //% total hp
            Moves.Clear();
            Moves.Add("Poison Spores");
            Moves.Add("Stonewort");
            area = new List<string>() {"plant area 1", "plant area 2", "rifton forest"};
            itemDrop = new List<string>() { "seed", "spore", "grass scale" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                    @"          {{{          ",
                    @"         :  |;         ",
                    @"        ;@  @ ,        ",
                    @"       , |  | '        ",
                    @"      .  |  |  }       ",
                    @"      |  |  |  |;      ",
                    @"      |  |  |  |}      ",
                    @"       '.\__\__/       "
                },
                {
                    @"          {{{          ",
                    @"         :  |;         ",
                    @"        ;_  _ ,        ",
                    @"       , |  | '        ",
                    @"      .  |  |  }       ",
                    @"      |  |  |  |;      ",
                    @"      |  |  |  |}      ",
                    @"       '.\__\__/       "

                },
                {
                    @"          {{{          ",
                    @"         :  |;         ",
                    @"        ; _  _ ,       ",
                    @"        , |  | '       ",
                    @"       .  |  |  }      ",
                    @"       |  |  |  |;     ",
                    @"       |  |  |  |}     ",
                    @"        '.\__\__/      "
                },
                {
                    @"          {{{          ",
                    @"         :  |;         ",
                    @"        ;_  _ ,        ",
                    @"       , |  | '        ",
                    @"      .  |  |  }       ",
                    @"      |  |  |  |;      ",
                    @"      |  |  |  |}      ",
                    @"       '.\__\__/       "
                },
                {
                    @"          {{{          ",
                    @"         :  |;         ",
                    @"        ; _  _ ,       ",
                    @"        , |  | '       ",
                    @"       .  |  |  }      ",
                    @"       |  |  |  |;     ",
                    @"       |  |  |  |}     ",
                    @"        '.\__\__/      "
                },
                };
        }
    }
    class Plant1b : Enemy
    {
        public Plant1b()
        {
            name = "";
            names.Add("Aggrain");
            names.Add("Wheatheart");
            names.Add("Aggrassive");
            elementType = "Plant";
            MaxHP = 13;
            HP = 13;
            strength = 3;
            defense = 2;
            speed = 4;
            exp = 1;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 15; //% total hp
            Moves.Clear();
            Moves.Add("Poison Spores");
            Moves.Add("Bio Acid");
            area = new List<string>() {"plant area 1", "plant area 2", "rifton beach"};
            itemDrop = new List<string>() { "spore", "seed", "pollen fang" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"           {{{         ",
                     @"          {:|;}        ",
                     @"         {;@ @,}       ",
                     @"        \\_\_\//       ",
                     @"       \\_\_/\_//      ",
                     @"       \\_\_/\_//      ",
                     @"        \\\_/\_//      ",
                     @"          \\_//        "
                },
                {
                     @"           {{{         ",
                     @"          {:|;}        ",
                     @"         {;_ _,}       ",
                     @"        /\_\_\/\       ",
                     @"       \\_\_/\_//      ",
                     @"       \\_\_/\_//      ",
                     @"        \\\_/\_//      ",
                     @"          \\_//        "

                },
                {
                     @"           {{{         ",
                     @"          {:|;}        ",
                     @"         {;_ _,}       ",
                     @"        /\_\_\/\       ",
                     @"       /\_\_/\_/\      ",
                     @"       \\_\_/\_//      ",
                     @"        \\\_/\_//      ",
                     @"          \\_//        "
                },
                {
                     @"           {{{         ",
                     @"          {:|;}        ",
                     @"         {;_ _,}       ",
                     @"        \\_\_\//       ",
                     @"       /\_\_/\_/\      ",
                     @"       /\_\_/\_/\      ",
                     @"        \\\_/\_//      ",
                     @"          \\_//        "
                },
                {
                     @"           {{{         ",
                     @"          {:|;}        ",
                     @"         {;_ _,}       ",
                     @"        \\_\_\//       ",
                     @"       \\_\_/\_//      ",
                     @"       /\_\_/\_/\      ",
                     @"        /\\_/\_/\      ",
                     @"          \\_//        "
                },
                };
        }
    }
    public class Plant2a : Enemy
    {
        public Plant2a()
        {
            name = "";
            names.Add("Natrox");
            names.Add("Natrizer");
            elementType = "Plant";
            MaxHP = 27;
            HP = 27;
            strength = 9;
            defense = 8;
            speed = 11;
            exp = 10;
            hit = 70;
            MaxMP = 38;
            MP = 38;
            poisonOne = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Tangleweed");
            Moves.Add("Thicket Surge");
            area = new List<string>() {"plant area 2", "plant area 3"};
            itemDrop = new List<string>() { "grass scale", "pollen fang", "thorn" }; //30% chance of nothing, 1st = 40% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Plant2b : Enemy
    {
        public Plant2b()
        {
            name = "";
            names.Add("Pettle");
            names.Add("Golstem");
            names.Add("Stayman");
            elementType = "Fire";
            MaxHP = 26;
            HP = 26;
            strength = 9;
            defense = 10;
            speed = 8;
            exp = 8;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            poisonOne = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Tangleweed");
            Moves.Add("Pyriscent Bullets");
            area = new List<string>() {"plant area 2", "plant area 3"};
            itemDrop = new List<string>() { "pollen fang", "grass scale", "vine berry" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Plant3a : Enemy
    {
        public Plant3a()
        {
            name = "";
            names.Add("Ivyctor");
            names.Add("Rawthorn");
            names.Add("Grapplejack");
            elementType = "Plant";
            MaxHP = 44;
            HP = 44;
            strength = 18;
            defense = 22;
            speed = 20;
            exp = 25;
            hit = 80;
            MaxMP = 60;
            MP = 60;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 25; //% total hp
            Moves.Clear();
            Moves.Add("Slumber Dust");
            Moves.Add("Leaching Roots");
            area = new List<string>() {"plant area 3", "plant area 4"};
            itemDrop = new List<string>() { "thorn", "vine berry", "rotting branch" };
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Plant3b : Enemy
    {
        public Plant3b()
        {
            name = "";
            names.Add("Berrage");
            names.Add("Trapling");
            names.Add("Chlorroful");
            elementType = "Plant";
            MaxHP = 44;
            HP = 44;
            strength = 19;
            defense = 18;
            speed = 21;
            exp = 22;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 25; //% total hp
            Moves.Clear();
            Moves.Add("Slumber Dust");
            Moves.Add("Charcoal Smog");
            area = new List<string>() {"plant area 3", "plant area 4"};
            itemDrop = new List<string>() { "vine berry", "thorn", "golden leaf" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Plant4a : Enemy
    {
        public Plant4a()
        {
            name = "";
            names.Add("Plantelope");
            names.Add("Bullrush");
            names.Add("Muskedeer");
            elementType = "Plant";
            MaxHP = 77;
            HP = 77;
            strength = 34;
            defense = 40;
            speed = 28;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            poisonTwo = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Thorn Grip");
            Moves.Add("Solar Flare");
            area = new List<string>() {"plant area 4"};
            itemDrop = new List<string>() { "thorn", "rotting branch", "golden leaf" };
            itemDropRate = 1;
            money = 8;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }

    class Plant4b : Enemy
    {
        public Plant4b()
        {
            name = "";
            names.Add("Mahogarmy");
            names.Add("Yggdrakill");
            elementType = "Plant";
            MaxHP = 80;
            HP = 80;
            strength = 40;
            defense = 35;
            speed = 26;
            exp = 48;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            poisonTwo = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Thorn Grip");
            Moves.Add("Toxic Soil");
            area = new List<string>() {"plant area 4"};
            itemDrop = new List<string>() { "vine berry", "golden leaf", "rotting branch" };
            itemDropRate = 1;
            money = 10;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }

    class Earth1a : Enemy
    {
        public Earth1a()
        {
            name = "";
            names.Add("Earthsquirm");
            names.Add("Mookworm");
            names.Add("Raggot");
            elementType = "Earth";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 8;
            speed = 2;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Grainmail");
            Moves.Add("Sandstorm");
            area = new List<string>() {"earth area 1", "earth area 2", "rifton cave"};
            itemDrop = new List<string>() { "mud ball", "granule", "earthy claw" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"    __                 ",
                     @"   / }}}}              ",
                     @"   {_}  {}}            ",
                     @"         {}}      {}   ",
                     @"        {}}      {}    ",
                     @"       {}}      {}}    ",
                     @"      {}}      {}}     ",
                     @"       {}}(  )}}}      "
                },
                {
                    @"    __                 ",
                    @"   / }}}}              ",
                    @"   {}}  {}}            ",
                    @"   {_}   {}}           ",
                    @"        {}}      {}    ",
                    @"       {}}       {}    ",
                    @"      {}}      {}}     ",
                    @"       {}(  )}}}}      "

                },
                {
                     @"    __                 ",
                     @"   / }}}}              ",
                     @"   {}}  {}}            ",
                     @"   {}}   {}}           ",
                     @"   {_}  {}}            ",
                     @"       {}}       {}    ",
                     @"      {}}      {}}     ",
                     @"       {(  )}}}}}      "
                },
                {
                    @"    __                 ",
                    @"   / }}}}              ",
                    @"   {}}  {}}            ",
                    @"   {}}   {}}           ",
                    @"   {}}  {}}            ",
                    @"   {_} {}}             ",
                    @"      {}}       {}     ",
                    @"       (  )}}}}}}      "
                },
                {
                     @"    __                 ",
                     @"   / }}}}              ",
                     @"   {}}  {}}            ",
                     @"   {}}   {}}           ",
                     @"   {}}  {}}            ",
                     @"   {}} {}}             ",
                     @"   {_}{}}              ",
                     @"         )}}}}}}}      "
                },
                };
        }
    }
    class Earth1b : Enemy
    {
        public Earth1b()
        {
            name = "";
            names.Add("Klod");
            names.Add("Soils-O-War");
            names.Add("Muckus");
            elementType = "Earth";
            MaxHP = 14;
            HP = 14;
            strength = 3;
            defense = 10;
            speed = 2;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Grainmail");
            Moves.Add("Stonewort");
            area = new List<string>() {"earth area 1", "earth area 2", "rifton forest"};
            itemDrop = new List<string>() { "granule", "mud ball", "muddy fur" };
            itemDropRate = 1;
            money = 2;
            animation = new string[5, 8] 
                {
                {
                    @"        .-----.,       ",
                    @"      {---   -  ?      ",
                    @"     { @    @  _ '.    ",
                    @"  ,- '   ___    ,__}   ",
                    @" {   _'_          }'\  ",
                    @" 'm/{          \_m}  } ",
                    @"   {---   '___  '__ }  ",
                    @"     ~_____________,~  "
                },
                {
                    @"        .-----.,       ",
                    @"      {---   -  ?      ",
                    @"     {  @    @  _ '.   ",
                    @"  ,- '   ___    ,__}   ",
                    @" {   _'_          }'\  ",
                    @" 'm/{  '___  '_ \_m} } ",
                    @" {---             }    ",
                    @"    ~_____________,~   "

                },
                {
                    @"        .-----.,       ",
                    @"      {---   -  ?      ",
                    @"     { @    @  _ '.    ",
                    @"  ,- '   ___    ,__}   ",
                    @" {   _'_          }'\  ",
                    @" 'm/{          \_m}  } ",
                    @"   {---   '___  '__ }  ",
                    @"     ~_____________,~  "
                },
                {
                    @"        .-----.,       ",
                    @"      {---   -  ?      ",
                    @"     {  @    @  _ '.   ",
                    @"  ,- '   ___    ,__}   ",
                    @" {   _'_          }'\  ",
                    @" 'm/{  '___  '_ \_m} } ",
                    @" {---             }    ",
                    @"    ~_____________,~   "
                },
                {
                    @"         .-----.,      ",
                    @"       {---   -  ?     ",
                    @"     {  @    @  _ '.   ",
                    @"  ,- '   ___    ,__}   ",
                    @" {   _'_          }'\  ",
                    @"'m/{  '___  '_ \_m} }  ",
                    @" {---             }    ",
                    @"     ~_____________,   "
                },
                };
        }
    }
    class Earth2a : Enemy
    {
        public Earth2a()
        {
            name = "";
            names.Add("Borevole");
            names.Add("Iron Pyrat");
            elementType = "Earth";
            MaxHP = 25;
            HP = 25;
            strength = 9;
            defense = 30;
            speed = 9;
            exp = 10;
            hit = 70;
            MaxMP = 38;
            MP = 38;
            Moves.Clear();
            Moves.Add("Quake");
            Moves.Add("Erode");
            area = new List<string>() {"earth area 2", "earth area 3"};
            itemDrop = new List<string>() { "earthy claw", "muddy fur", "old bone" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Earth2b : Enemy
    {
        public Earth2b()
        {
            name = "";
            names.Add("Rabbattle");
            names.Add("Haredevil");
            elementType = "Earth";
            MaxHP = 25;
            HP = 25;
            strength = 10;
            defense = 27;
            speed = 12;
            exp = 11;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Quake");
            Moves.Add("Thicket Surge");
            area = new List<string>() {"earth area 2", "earth area 3"};
            itemDrop = new List<string>() { "muddy fur", "earthy claw", "fossil" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Earth3a : Enemy
    {
        public Earth3a()
        {
            name = "";
            names.Add("Bossil");
            names.Add("Petrifye");
            names.Add("D'composed");
            elementType = "Earth";
            MaxHP = 45;
            HP = 45;
            strength = 20;
            defense = 62;
            speed = 22;
            exp = 25;
            hit = 80;
            MaxMP = 60;
            MP = 60;
            Moves.Clear();
            Moves.Add("Sand Shroud");
            Moves.Add("Leaching Roots");
            area = new List<string>() {"earth area 3", "earth area 4"};
            itemDrop = new List<string>() { "old bone", "fossil", "gritty paw" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    public class Earth3b : Enemy
    {
        public Earth3b()
        {
            name = "";
            names.Add("Rubble-rouser");
            names.Add("Boulderdash");
            elementType = "Earth";
            MaxHP = 45;
            HP = 45;
            strength = 20;
            defense = 65;
            speed = 18;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Sand Shroud");
            Moves.Add("Landslide");
            area = new List<string>() {"earth area 3", "earth area 4"};
            itemDrop = new List<string>() { "fossil", "old bone", "rock slab" }; //30% chance of nothing, 1st = 40% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Earth4a : Enemy
    {
        public Earth4a()
        {
            name = "";
            names.Add("Urthquake");
            names.Add("Melees");
            elementType = "Earth";
            MaxHP = 90;
            HP = 90;
            strength = 40;
            defense = 75;
            speed = 33;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Rock Fort");
            Moves.Add("Toxic Soil");
            area = new List<string>() {"earth area 4"};
            itemDrop = new List<string>() { "old bone", "gritty paw", "rock slab" };
            itemDropRate = 1;
            money = 9;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Earth4b : Enemy
    {
        public Earth4b()
        {
            name = "";
            names.Add("Contimental");
            names.Add("Cragged");
            elementType = "Earth";
            MaxHP = 95;
            HP = 95;
            strength = 35;
            defense = 80;
            speed = 33;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Rock Fort");
            Moves.Add("Dust Devil");
            area = new List<string>() {"earth area 4"};
            itemDrop = new List<string>() { "fossil", "rock slab", "gritty paw" };
            itemDropRate = 1;
            money = 9;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Air1a : Enemy
    {
        public Air1a()
        {
            name = "";
            names.Add("Hubbuzz");
            names.Add("Wevil");
            elementType = "Air";
            MaxHP = 10;
            HP = 10;
            strength = 4;
            defense = 3;
            speed = 9;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Static Shock");
            Moves.Add("Sandstorm");
            area = new List<string>() {"air area 1", "air area 2", "rifton forest"};
            itemDrop = new List<string>() { "chitin wing", "antenna", "light wing" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                    @"                       ",
                    @"                       ",
                    @" , ,                   ",
                    @"  \ \        ,.- - ,   ",
                    @"  | |  _.~'\' ----- \  ",
                    @"   \_'@ \   \________| ",
                    @" .-'~''-./_{}\____\__/ ",
                    @"       _/ _/  \_   \_  "
                },
                {
                    @"                       ",
                    @"                       ",
                    @"  , ,                  ",
                    @"  \ \        ,.- - ,   ",
                    @"  | |  _.~'\' ----- \  ",
                    @"   \_'@ \   \________| ",
                    @" '-'~''-./_{}\____\__/ ",
                    @"        /_ /_ \   _\   "

                },
                {
                    @"                       ",
                    @"                       ",
                    @" , ,                   ",
                    @"  \ \        ,.- - ,   ",
                    @"  | |  _.~'\' ----- \  ",
                    @"   \_'@ \   \________| ",
                    @" .-'~''-./_{}\____\__/ ",
                    @"       _/ _/  \_   \_  "
                },
                {
                    @"                       ",
                    @"                       ",
                    @"  , ,                  ",
                    @"  \ \        ,.- - ,   ",
                    @"  | |  _.~'\' ----- \  ",
                    @"   \_'@ \   \________| ",
                    @" '-'~''-./_{}\____\__/ ",
                    @"        /_ /_ \   _\   "
                },
                {
                    @"                       ",
                    @"                       ",
                    @"  , ,                  ",
                    @"  \ \        ,.- - ,   ",
                    @"  | |  _.~'\' ----- \  ",
                    @"   \_'- \   \________| ",
                    @" '-'~''-./_{}\____\__/ ",
                    @"        /_ /_ \   _\   "
                },
                };
        }
    }
    class Air1b : Enemy
    {
        public Air1b()
        {
            name = "";
            names.Add("Probosperous");
            names.Add("Lepidopterror");
            elementType = "Air";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 3;
            speed = 10;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Static Shock");
            Moves.Add("Hail");
            area = new List<string>() {"air area 1", "air area 2", "rifton beach"};
            itemDrop = new List<string>() { "antenna", "chitin wing", "hooked claw" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"       ?_?   ,.---.,   ",
                     @"     _{@ } ,'/_/_///;  ",
                     @"  ,'   '{}//_/_///,'   ",
                     @" : c',  {}/,. --.'     ",
                     @" '-.-'  {}/__\_ \_'.   ",
                     @"         {}.,\ \__  '. ",
                     @"          {} '. \ \ _: ",
                     @"                ''--,' "
                },
                {
                     @"       ?_?  ,.---.,    ",
                     @"     _{@ } '/_/_///;   ",
                     @"  ,'   '{}/_/_///,'    ",
                     @" :  c,  {},. --.'      ",
                     @" '.,-'  {}/_\_ \_'.    ",
                     @"         {}.\ \__  '.  ",
                     @"          {} ' \ \ _:  ",
                     @"               ''--,'  "

                },
                {
                     @"       ?_?  ,.--.,     ",
                     @"     _{@ } '/_/_//;    ",
                     @"  ,'   '{}/_/_//,'     ",
                     @" :    ,  {},. -.'      ",
                     @" ',   .  {}/_\_ \'.    ",
                     @"   ''    {}.\ \_  '.   ",
                     @"          {} ' \ \_:   ",
                     @"               ''-,'   "
                },
                {
                     @"                       ",
                     @"       ?_?  ,.--.,     ",
                     @"     _{@ } '/_/_/;     ",
                     @"  ,'   '{}/_/_/,'      ",
                     @" :       {},.-.'       ",
                     @" ,       {}/_\_\'.     ",
                     @"  .  ,   {}.\ \_ '.    ",
                     @"   ''     {} '\,\_,    ",
                },
                {
                     @"                       ",
                     @"       ?_?  ,.-.,      ",
                     @"     _{@ } '/_//;      ",
                     @"  ,'   '{}/_//,'       ",
                     @" :       {},..'        ",
                     @" ,       {}/_\_'.      ",
                     @"  .      {}.\ \_'.     ",
                     @"   '._    {} '\,\,     ",
                },
                };
        }
    }
    class Air2a : Enemy
    {
        public Air2a()
        {
            name = "";
            names.Add("Sparrowdy");
            names.Add("Clobbin'");
            names.Add("Knightingale'");
            elementType = "Air";
            MaxHP = 25;
            HP = 25;
            strength = 10;
            defense = 9;
            speed = 31;
            exp = 10;
            hit = 70;
            MaxMP = 38;
            MP = 38;
            Moves.Clear();
            Moves.Add("Windstorm");
            Moves.Add("Snowstorm");
            area = new List<string>() {"air area 2", "air area 3"};
            itemDrop = new List<string>() { "light wing", "hooked claw", "feather" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Air2b : Enemy
    {
        public Air2b()
        {
            name = "";
            names.Add("Battel");
            names.Add("Pipsqueak");
            elementType = "Air";
            HP = 26;
            strength = 9;
            defense = 11;
            speed = 28;
            exp = 11;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Windstorm");
            Moves.Add("Erode");
            area = new List<string>() {"air area 2", "air area 3"};
            itemDrop = new List<string>() { "hooked claw", "light wing", "sharp beak" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Air3a : Enemy
    {
        public Air3a()
        {
            name = "";
            names.Add("Buzzkill");
            names.Add("Vultair");
            elementType = "Air";
            MaxHP = 46;
            HP = 46;
            strength = 19;
            defense = 21;
            speed = 60;
            exp = 25;
            hit = 80;
            MaxMP = 60;
            MP = 60;
            Moves.Clear();
            Moves.Add("Tailwind");
            Moves.Add("Landslide");
            area = new List<string>() {"air area 3", "air area 4"};
            itemDrop = new List<string>() { "feather", "sharp beak", "ventifact scale" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Air3b : Enemy
    {
        public Air3b()
        {
            name = "";
            names.Add("Siroccin'");
            names.Add("Zephirate");
            names.Add("Turbulance");
            elementType = "Air";
            MaxHP = 42;
            HP = 42;
            strength = 15;
            defense = 22;
            speed = 65;
            exp = 23;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Tailwind");
            Moves.Add("Curelonimbus");
            area = new List<string>() {"air area 3", "air area 4"};
            itemDrop = new List<string>() { "sharp beak", "feather", "hollow fang" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Air4a : Enemy
    {
        public Air4a()
        {
            name = "";
            names.Add("Dragairn");
            names.Add("Nagair");
            elementType = "Air";
            MaxHP = 79;
            HP = 79;
            strength = 40;
            defense = 36;
            speed = 105;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Cyclone");
            Moves.Add("Dust Devil");
            area = new List<string>() {"air area 4"};
            itemDrop = new List<string>() { "feather", "ventifact scale", "hollow fang" };
            itemDropRate = 1;
            money = 10;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    public class Air4b : Enemy
    {
        public Air4b()
        {
            name = "";
            names.Add("Cumuloninja");
            names.Add("Ninjastratus");
            names.Add("Cirrusassin");
            elementType = "Air";
            MaxHP = 79;
            HP = 79;
            strength = 34;
            defense = 36;
            speed = 115;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Cyclone");
            Moves.Add("Cloud Burst");
            area = new List<string>() {"air area 4"};
            itemDrop = new List<string>() { "sharp beak", "hollow fang", "ventifact scale" }; //30% chance of nothing, 1st = 40% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 10;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Water1a : Enemy
    {
        public Water1a()
        {
            name = "";
            names.Add("Fight-O-Plankton");
            names.Add("Kriller");
            elementType = "Water";
            MaxHP = 32;
            HP = 32;
            strength = 3;
            defense = 3;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Tide Pool");
            Moves.Add("Vaporise");
            area = new List<string>() {"water area 1", "water area 2", "rifton cave"};
            itemDrop = new List<string>() { "spicule", "sea gloop", "ocean scale" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"           ______      ",
                     @"    {    ,'  \  \ '.   ",
                     @"     \ .@     : :  /\  ",
                     @"     -'.,---.,}..., /| ",
                     @" ~-,_/   / /   {{{ \ | ",
                     @"         { {       / / ",
                     @"                 <__/  "
                },
                {
                    @"                       ",
                    @"           ______      ",
                    @"    |    ,'  \  \ '.   ",
                    @"     \ .@     : :  /\  ",
                    @"     _'.,---.,}..., /| ",
                    @" -,_,/   / /   {}{ \ | ",
                    @"         { \       / / ",
                    @"                  <__/ "

                },
                {
                    @"                       ",
                    @"           ______      ",
                    @"    }    ,'  \  \ '.   ",
                    @"     \ .@     : :  /\  ",
                    @"     -'.,---.,}..., /| ",
                    @" ,_,./   / /   {{{ \ | ",
                    @"         {  \      / / ",
                    @"                 <__/  "
                },
                {
                    @"                       ",
                    @"           ______      ",
                    @"     |   ,'  \  \ '.   ",
                    @"     \ .@     : :  /\  ",
                    @"     _'.,---.,}..., /| ",
                    @" _,.-/   / /   {}{ \ | ",
                    @"         { \       / / ",
                    @"                  <__/ "
                },
                {
                    @"                       ",
                    @"           ______      ",
                    @"     /   ,'  \  \ '.   ",
                    @"     \ .@     : :  /\  ",
                    @"     -'.,---.,}..., /| ",
                    @" ,.-~/   / /   {{{ \ | ",
                    @"         { {       / / ",
                    @"                 <__/  "
                },
                };
        }
    }
    class Water1b : Enemy
    {
        public Water1b()
        {
            name = "";
            names.Add("Anenomy");
            names.Add("Lurchin'");
            names.Add("Sea Slugger");
            elementType = "Water";
            MaxHP = 44;
            HP = 44;
            strength = 3;
            defense = 3;
            speed = 1;
            exp = 3;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Tide Pool");
            Moves.Add("Hail");
            area = new List<string>() {"water area 1", "water area 2", "rifton beach"};
            itemDrop = new List<string>() { "sea gloop", "spicule", "fin" };
            itemDropRate = 1;
            money = 2;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"     \   \    /   /    ",
                     @"      \ \-\--/-/ /     ",
                     @"   '.'    \  /   '.'   ",
                     @"   -.\  \@   @/  /.-   ",
                     @"  -.,   /     \   ,.-  ",
                     @"   __- ' /   \ '  -__  ",
                     @"     /'--_____--'\     "
                },
                {
                     @"    \              /   ",
                     @"     \   \    /   /    ",
                     @"      \ \-\--/-/ /     ",
                     @"   '.'    \  /   '.'   ",
                     @"  --.\  \@   @/  /.--  ",
                     @"  -.,   /     \   ,.-  ",
                     @"   __- ' /   \ '  -__  ",
                     @"     /'--_____--'\     "

                },
                {
                     @"        \      /       ",
                     @"     \   \    /   /    ",
                     @"      \ \-\--/-/ /     ",
                     @"   '.'    \  /   '.'   ",
                     @"   -.\  \@   @/  /.-   ",
                     @"  -.,   /     \   ,.-  ",
                     @"  ___- ' /   \ '  -___ ",
                     @"     /'--_____--'\     "
                },
                {
                     @"                       ",
                     @"     \ \ \    / / /    ",
                     @"  .   \ \-\--/-/ /  .  ",
                     @"   '.'    \  /   '.'   ",
                     @"   -.\  \@   @/  /.-   ",
                     @"  -.,   /     \   ,.-  ",
                     @"   __- ' /   \ '  -__  ",
                     @"     /'--_____--'\     "
                },
                {
                     @"                       ",
                     @"     \   \    /   /    ",
                     @"      \ \-\--/-/ /     ",
                     @"   '.'    \  /   '.'   ",
                     @"   -.\  \@   @/  /.-   ",
                     @" --.,   /     \   ,.-- ",
                     @"   __- ' /   \ '  -__  ",
                     @"    _/'--_____--'\_    "
                },
                };
        }
    }
    class Water2a : Enemy
    {
        public Water2a()
        {
            name = "";
            names.Add("Dorsafin");
            names.Add("Caudafin");
            names.Add("Ventrafin");
            elementType = "Water";
            MaxHP = 105;
            HP = 105;
            strength = 9;
            defense = 9;
            speed = 12;
            exp = 10;
            hit = 70;
            MaxMP = 38;
            MP = 38;
            Moves.Clear();
            Moves.Add("Bubble Jet");
            Moves.Add("Snowstorm");
            area = new List<string>() {"water area 2", "water area 3"};
            itemDrop = new List<string>() { "ocean scale", "fin", "tentacle" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"         /'>           ",
                     @"     .--'-- .,         ",
                     @"   .'          '.      ",
                     @" _/ @  ..-\/ '-.,'     ",
                     @"(__. '           \ \   ",
                     @"                 /mm\  ",
                     @"                       ",
                     @"                       "
                },
                {
                     @"                       ",
                     @"         /'>           ",
                     @"     .--'-- .,         ",
                     @"   .'          '.      ",
                     @" _/ @  ..-\/ '-.,'-,.  ",
                     @"(__. '            '/mm\",
                     @"                       ",
                     @"                       "

                },
                {
                     @"                       ",
                     @"                       ",
                     @"         /'>           ",
                     @"     .--'-- .,         ",
                     @"   .'          '.    /c",
                     @" _/ @  ..-\/ '-.,'.'. c",
                     @"(__. '               \c",
                     @"                       "
                },
                {
                     @"                       ",
                     @"                       ",
                     @"                       ",
                     @"         /'>           ",
                     @"     .--'-- .,      /c ",
                     @"   .'          '.- /cc ",
                     @" _/ @  ..-\/ '-.,-''--/",
                     @"(__. '                 "
                },
                {
                     @"                       ",
                     @"                       ",
                     @"                       ",
                     @"         /'>           ",
                     @"     .--'-- .,    \ww/ ",
                     @"   .'          '.-' /  ",
                     @" _/ @  ..-\/ '- .,-/   ",
                     @"(__. '                 "
                },
                };
        }
    }
    class Water2b : Enemy
    {
        public Water2b()
        {
            name = "";
            names.Add("Terrorpin");
            names.Add("Hurtle");
            elementType = "Water";
            MaxHP = 105;
            HP = 105;
            strength = 9;
            defense = 12;
            speed = 9;
            exp = 10;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Bubble Jet");
            Moves.Add("Hot Spring");
            area = new List<string>() {"water area 2", "water area 3"};
            itemDrop = new List<string>() { "fin", "ocean scale", "biolume" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Water3a : Enemy
    {
        public Water3a()
        {
            name = "";
            names.Add("Boxerjelly");
            names.Add("Manowar");
            names.Add("Smellyfish");
            elementType = "Water";
            MaxHP = 195;
            HP = 195;
            strength = 19;
            defense = 19;
            speed = 19;
            exp = 25;
            hit = 80;
            MaxMP = 60;
            MP = 60;
            Moves.Clear();
            Moves.Add("Deluge");
            Moves.Add("Curelonimbus");
            area = new List<string>() {"water area 3", "water area 4"};
            itemDrop = new List<string>() { "tentacle", "biolume", "seep-sea blubber" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Water3b : Enemy
    {
        public Water3b()
        {
            name = "";
            names.Add("Bathysfear");
            names.Add("Abyssmal");
            elementType = "Water";
            MaxHP = 195;
            HP = 195;
            strength = 19;
            defense = 21;
            speed = 16;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Deluge");
            Moves.Add("Geyser");
            area = new List<string>() {"water area 3", "water area 4"};
            itemDrop = new List<string>() { "biolume", "tentacle", "ocean fin" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Water4a : Enemy
    {
        public Water4a()
        {
            name = "";
            names.Add("Warrus");
            names.Add("Buoyatee");
            names.Add("Dugal");
            elementType = "Water";
            MaxHP = 300;
            HP = 300;
            strength = 35;
            defense = 35;
            speed = 36;
            exp = 48;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Monsoon");
            Moves.Add("Cloud Burst");
            area = new List<string>() {"water area 4"};
            itemDrop = new List<string>() { "tentacle", "deep-sea blubber", "ocean fin" };
            itemDropRate = 1;
            money = 8;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Water4b : Enemy
    {
        public Water4b()
        {
            name = "";
            names.Add("Great Fight Shark");
            names.Add("Hammerfed");
            names.Add("Bluwail");
            elementType = "Water";
            MaxHP = 300;
            HP = 300;
            strength = 36;
            defense = 37;
            speed = 33;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Monsoon");
            Moves.Add("Hydrothermal Blast");
            area = new List<string>() {"water area 4"};
            itemDrop = new List<string>() { "biolume", "ocean fin", "deep-sea blubber" };
            itemDropRate = 1;
            money = 9;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Charcoal1a : Enemy
    {
        public Charcoal1a()
        {
            name = "";
            names.Add("Andisoldier");
            names.Add("Cinderpest");
            names.Add("Tephriot");
            elementType = "Charcoal";
            MaxHP = 12;
            HP = 12;
            strength = 7;
            defense = 3;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 15; //% total hp
            Moves.Clear();
            Moves.Add("Bio Acid");
            Moves.Add("Lava Bubble");
            area = new List<string>() { "fire area 1", "plant area 1", "karstbay caves upper level" };
            itemDrop = new List<string>() { "fire egg", "spore", "coal armour" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"                       ",
                     @"       .-/\--.,        ",
                     @"     <-o\- / - >,      ",
                     @"   .{ @     @ *  <.    ",
                     @"   <'   ' _  K__o_}.   ",
                     @"  { {*<   o -_-} # >   ",
                     @"  '<_oX_<__*___>_o/J   "
                },
                {
                     @"                       ",
                     @"       .-/\--.,        ",
                     @"     <-o\- / - >,      ",
                     @"   .{ @     @ *  <.    ",
                     @"   <'   ' _  K__o_}.   ",
                     @"  { {*<   o -_-} # >   ",
                     @"  '<_oX_<__*___>_o/J   ",
                     @"       '    ,      '   "

                },
                {
                     @"                       ",
                     @"      .-/\--.,         ",
                     @"    <-o\- / - >,       ",
                     @"  .{ @     @ *  <.     ",
                     @"  <'   ' _  K__o_}.    ",
                     @" { {*<   o -_-} # >    ",
                     @" '<_oX_<__*___>_o/J    ",
                     @"       .           .   "
                },
                {
                     @"                       ",
                     @"                       ",
                     @"      .-/\--.,         ",
                     @"  ' <-o\- / - >,'      ",
                     @", .{ >     < *  <.o    ",
                     @"  <'   ' _  K__o_}. .  ",
                     @" { {*<   o -_-} # >    ",
                     @"o'<_oX_<__*___>_o/J-   "
                },
                {
                     @"                       ",
                     @"                       ",
                     @"      .-/\--.,         ",
                     @"    <-o\- / - >,       ",
                     @"  .{ @     @ *  <.     ",
                     @"  <'   ' _  K__o_}.    ",
                     @" { {*<   o -_-} # >    ",
                     @" '<_oX_<__*___>_o/J    "
                },
                };
        }
    }
    class Charcoal1b : Enemy
    {
        public Charcoal1b()
        {
            name = "";
            names.Add("Bryofighter");
            names.Add("Lich'n");
            elementType = "Charcoal";
            MaxHP = 12;
            HP = 12;
            strength = 8;
            defense = 3;
            speed = 2;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 15; //% total hp
            Moves.Clear();
            Moves.Add("Bio Acid");
            Moves.Add("Poison Spores");
            area = new List<string>() { "fire area 1", "plant area 1", "fire area 2", "plant area 2" };
            itemDrop = new List<string>() { "seed", "flame gloop", "flint" };
            itemDropRate = 1;
            money = 0;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"    (O)  oo  (O)       ",
                     @"     \\ ^/\^//}        ",
                     @"     {O}@  @ {O}   {O} ",
                     @"      {{vwwv_}o{} //   ",
                     @"      //{-o o\\{}//    ",
                     @"     (o) {{} o(o){}    ",
                     @"          m^^^m^       "
                },
                {
                     @"                       ",
                     @"    (O)  o   (O)       ",
                     @"     \\ ^/\^//}        ",
                     @"     {O}@  @ {O}       ",
                     @"      {{vwwv_}o{} /{O} ",
                     @"      ||{-o o \\}//    ",
                     @"      (o){{} o (o)}    ",
                     @"          m^^^m^       "

                },
                {
                     @"                       ",
                     @"    (O)  oo  (O)       ",
                     @"     \\ ^/\^//}        ",
                     @"     {O}@  @ {O}   {O} ",
                     @"      {{vwwv_}o{} //   ",
                     @"      //{-o o\\{}//    ",
                     @"     (o) {{} o(o){}    ",
                     @"          m^^^m^       "
                },
                {
                     @"                       ",
                     @"    (O)   o  (O)       ",
                     @"     \\ ^/\^//}        ",
                     @"     {O}@  @ {O}       ",
                     @"      {{vwwv_}o{} /{O} ",
                     @"     // {-o o||{}//    ",
                     @"    (o)  {{} (o) {}    ",
                     @"          m^^^m^       "
                },
                {
                     @"                       ",
                     @"    (O)  oo  (O)       ",
                     @"     \\ ^/\^//}        ",
                     @"     {O}@  @ {O}   {O} ",
                     @"      {{vwwv_}o{} //   ",
                     @"      //{-o o\\{}//    ",
                     @"     (o) {{} o(o){}    ",
                     @"          m^^^m^       "
                },
                };
        }
    }
    class Charcoal2 : Enemy
    {
        public Charcoal2()
        {
            name = "";
            names.Add("Fernbully");
            names.Add("Cybad");
            names.Add("Terridophyte");
            elementType = "Charcoal";
            MaxHP = 27;
            HP = 27;
            strength = 18;
            defense = 9;
            speed = 9;
            exp = 10;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            poisonOne = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Pyriscent Bullets");
            Moves.Add("Tangleweed");
            area = new List<string>() { "fire area 2", "plant area 2", "fire area 3", "plant area 3" };
            itemDrop = new List<string>() { "coal armour", "pollen fang", "fire fang" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Charcoal3 : Enemy
    {
        public Charcoal3()
        {
            name = "";
            names.Add("Haleakilla");
            names.Add("Silversword");
            names.Add("Killauea");
            elementType = "Charcoal";
            MaxHP = 47;
            HP = 47;
            strength = 35;
            defense = 19;
            speed = 19;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 25; //% total hp
            Moves.Clear();
            Moves.Add("Charcoal Smog");
            Moves.Add("Slumber Dust");
            area = new List<string>() { "fire area 3", "plant area 3", "fire area 4", "plant area 4" };
            itemDrop = new List<string>() { "thorn", "burning tail", "infernal scale" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Charcoal4 : Enemy
    {
        public Charcoal4()
        {
            name = "";
            names.Add("Sagurai");
            names.Add("Cactain");
            elementType = "Charcoal";
            MaxHP = 80;
            HP =80;
            strength = 60;
            defense = 35;
            speed = 34;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            poisonTwo = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Solar Flare");
            Moves.Add("Inferno");
            area = new List<string>() {"fire area 4", "plant area 4"};
            itemDrop = new List<string>() { "vine berry", "lava rock", "rotting branch" };
            itemDropRate = 1;
            money = 9;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    public class Moss1a : Enemy
    {
        public Moss1a()
        {
            name = "";
            names.Add("Mosser");
            names.Add("Mosstomp");
            names.Add("Algin");
            elementType = "Moss";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 7;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            poisonOne = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Stonewort");
            Moves.Add("Poison Spores");
            area = new List<string>() { "plant area 1", "earth area 1", "karstbay caves upper level" };
            itemDrop = new List<string>() { "mud ball", "spore", "earthy claw" }; //30% chance of nothing, 1st = 40% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"          W            ",
                     @"       kWkIkWkW        ",
                     @"  nv wWwWwWwWwSwW vn   ",
                     @"    Vxvm@---@mxvxV     ",
                     @"   WwWwWwWwWwWwWwWw    ",
                     @"   vwSwvwmwvwmwvwmw    ",
                     @"    mwmwmwmwmwswmw     ",
                     @"  mmMMWwWw wWwWwMMmm   "
                },
                {
                     @"          W            ",
                     @"       kWkIkWkW        ",
                     @"     wWwWwWwWwSwW vn   ",
                     @"  nvVxvm@---@mxvxV     ",
                     @"   WwWwWwWwWwWwWwWw    ",
                     @"   vwSwvwmwvwmwvwmw    ",
                     @"    mwmwmwmwWwWwMMmm   ",
                     @"  mmMMWwWw             "

                },
                {
                     @"          W            ",
                     @"       kWkIkWkW        ",
                     @"  nv wWwWwWwWwSwW vn   ",
                     @"    Vxvm@---@mxvxV     ",
                     @"   WwWwWwWwWwWwWwWw    ",
                     @"   vwSwvwmwvwmwvwmw    ",
                     @"    mwmwmwmwmwswmw     ",
                     @"  mmMMWwWw wWwWwMMmm   "
                },
                {
                     @"          W            ",
                     @"       kWkIkWkW        ",
                     @"  nv wWwWwWwWwSwW      ",
                     @"    Vxvm@---@mxvxVvn   ",
                     @"   WwWwWwWwWwWwWwWw    ",
                     @"   vwSwvwmwvwmwvwmw    ",
                     @"  mmMMWwWwmwmwswmw     ",
                     @"           wWwWwMMmm   "
                },
                {
                     @"          W            ",
                     @"       kWkIkWkW        ",
                     @"  nv wWwWwWwWwSwW vn   ",
                     @"    Vxvm@---@mxvxV     ",
                     @"   WwWwWwWwWwWwWwWw    ",
                     @"   vwSwvwmwvwmwvwmw    ",
                     @"    mwmwmwmwmwswmw     ",
                     @"  mmMMWwWw wWwWwMMmm   "
                },
                };
        }
    }
    class Moss1b : Enemy
    {
        public Moss1b()
        {
            name = "";
            names.Add("Folirage");
            names.Add("Leafrond");
            elementType = "Moss";
            MaxHP = 14;
            HP = 14;
            strength = 4;
            defense = 7;
            speed = 2;
            exp = 3;
            hit = 60; 
            MaxMP = 20;
            MP = 20;
            poisonOne = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Stonewort");
            Moves.Add("Grainmail");
            area = new List<string>() { "plant area 1", "earth area 1", "plant area 2", "earth area 2" };
            itemDrop = new List<string>() { "seed", "granule", "flint" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"   \>  \>  _/>         ",
                     @"   <\  <\_/_    </     ",
                     @" <\_/>      \/>_/>     ",
                     @"   _\_/>   _/_/ _>_    ",
                     @" </   \___/ ___/   \>  ",
                     @"     _/@ @\/           ",
                     @"  <_/ \___/\__/>       "
                },
                {
                     @"                       ",
                     @"   <\  <\   </         ",
                     @"     \>  \>/_     />   ",
                     @"   \</       </ </     ",
                     @"    _\</    _/_/ </_   ",
                     @"   />  \___/ ___/  <\  ",
                     @"      _/_ _\/          ",
                     @"    >/ \___/\_</       "

                },
                {
                     @"                       ",
                     @"   \>  \>  _/>         ",
                     @"   <\  <\_/_    </     ",
                     @" <\_/>      \/>_/>     ",
                     @"   _\_/>   _/_/ _>_    ",
                     @" </   \___/ ___/   \>  ",
                     @"     _/_ _\/           ",
                     @"  <_/ \___/\__/>       "
                },
                {
                     @"                       ",
                     @"   <\  <\   </         ",
                     @"     \>  \>/_     />   ",
                     @"   \</       </ </     ",
                     @"    _\</    _/_/ </_   ",
                     @"   />  \___/ ___/  <\  ",
                     @"      _/_ _\/          ",
                     @"    >/ \___/\_</       "

                },
                {
                     @"                       ",
                     @"   \>  \>  _/>         ",
                     @"   <\  <\_/_    </     ",
                     @" <\_/>      \/>_/>     ",
                     @"   _\_/>   _/_/ _>_    ",
                     @" </   \___/ ___/   \>  ",
                     @"     _/_ _\/           ",
                     @"  <_/ \___/\__/>       "
                },
                };
        }
    }
    class Moss2 : Enemy
    {
        public Moss2()
        {
            name = "";
            names.Add("Mushtomb");
            names.Add("Festilence");
            elementType = "Moss";
            MaxHP = 27;
            HP = 27;
            strength = 9;
            defense = 18;
            speed = 9;
            exp = 10;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 15; //% total hp
            Moves.Clear();
            Moves.Add("Thicket Surge");
            Moves.Add("Quake");
            area = new List<string>() { "plant area 2", "earth area 2", "plant area 3", "earth area 3" };
            itemDrop = new List<string>() { "earthy claw", "grass scale", "old bone" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Moss3 : Enemy
    {
        public Moss3()
        {
            name = "";
            names.Add("Scrubble");
            names.Add("Shruggery");
            names.Add("Bushwhacker");
            elementType = "Moss";
            MaxHP = 47;
            HP = 47;
            strength = 19;
            defense = 35;
            speed = 19;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            poisonTwo = true;
            poisonChance = 35;
            Moves.Clear();
            Moves.Add("Leaching Roots");
            Moves.Add("Sand Shroud");
            area = new List<string>() { "plant area 3", "earth area 3", "plant area 4", "earth area 4" };
            itemDrop = new List<string>() { "thorn", "fossil", "infernal scale" };
            itemDropRate = 1;
            money = 8;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Moss4 : Enemy
    {
        public Moss4()
        {
            name = "";
            names.Add("Bamboom");
            names.Add("Destquoia");
            elementType = "Moss";
            MaxHP = 80;
            HP = 80;
            strength = 34;
            defense = 60;
            speed = 34;
            exp = 50;
            hit = 90; 
            MaxMP = 90;
            MP = 90;
            lifeLeech = true;
            lifeLeechChance = 35; //%
            lifeLeechHeal = 25; //% total hp
            Moves.Clear();
            Moves.Add("Toxic Soil");
            Moves.Add("Thorn Grip");
            area = new List<string>() {"plant area 4", "earth area 4"};
            itemDrop = new List<string>() { "vine berry", "rock slab", "golden leaf" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Dust1a : Enemy
    {
        public Dust1a()
        {
            name = "";
            names.Add("Sandswarm");
            names.Add("Dustroy");
            elementType = "Dust";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 7;
            speed = 7;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Sandstorm");
            Moves.Add("Grainmail");
            area = new List<string>() { "earth area 1", "air area 1", "karstbay caves middle level" };
            itemDrop = new List<string>() { "chitin wing", "granule", "light wing" };
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                    @"      _  .    ~  *     ",
                    @"    /'&* ~ *    ,      ",
                    @"  {*~'.* ?  ~ '  ~   * ",
                    @" {@\_*_/@ *   *    *   ",
                    @"  ;{___}* # * ~      ~ ",
                    @"  '\*,~ * * /   *      ",
                    @"  Mn   Mm              ",
                    @"                       "
                },
                {

                    @"              ,  *     ",
                    @"      _  . ,    ,      ",
                    @"    /'&* ~    '  ~   * ",
                    @"  {*~'.* ?  ~ *    *   ",
                    @" {@\_*_/@ *   ~      ~ ",
                    @"  ;{___}* # *   *      ",
                    @"  '\*,~ * * /          ",
                    @"  Mn   Mm              "
                },
                {

                    @"                       ",
                    @"      _  .    ~  *     ",
                    @"    /'&* ~ *    ,      ",
                    @"  {*~'.* ?  ~ '  ~   * ",
                    @" {@\_*_/@ *   *    *   ",
                    @"  ;{___}* # * ~      ~ ",
                    @"  '\*,~ * * /   *      ",
                    @"  Mn   Mm              "
                },
                {

                    @"      _  .             ",
                    @"    /'&* ~ *  ~  *     ",
                    @"  {*~'.* ?  ~  ,       ",
                    @" {@\_*_/@ *   '  ~   * ",
                    @"  ;{___}* # * *    *   ",
                    @"  '\*,~ * * / ~      ~ ",
                    @"  Mn   Mm      *       ",
                    @"                       "
                },
                {
                    @"      _  .    ~  *     ",
                    @"    /'&* ~ *    ,      ",
                    @"  {*~'.* ?  ~ '  ~   * ",
                    @" {@\_*_/@ *   *    *   ",
                    @"  ;{___}* # * ~      ~ ",
                    @"  '\*,~ * * /   *      ",
                    @"  Mn   Mm              ",
                    @"                       "
                }
                };
        }
    }
    class Dust1b : Enemy
    {
        public Dust1b()
        {
            name = "";
            names.Add("Dunebug");
            names.Add("Scorperra");
            names.Add("Tarantulair");
            elementType = "Dust";
            MaxHP = 12;
            HP = 12;
            strength = 3;
            defense = 7;
            speed = 7;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Sandstorm");
            Moves.Add("Static Shock");
            area = new List<string>() { "earth area 1", "air area 1", "earth area 2", "air area 2" };
            itemDrop = new List<string>() { "mud ball", "antenna", "muddy fur" };
            itemDropRate = 1;
            money = 4;
            animation = new string[5, 8] 
                {
                {
                     @"             {-}       ",
                     @"           {-}  {-}    ",
                     @"            \/   {-}   ",
                     @"                {-}    ",
                     @"      _____,. {--}     ",
                     @"    /@ \ \ \ \ }       ",
                     @"    v-.\].]--]}'       ",
                     @"  ><OOO// _\  \_       "
                },
                {
                     @"             {-}       ",
                     @"          {-}   {-}    ",
                     @"           \/    {-}   ",
                     @"                 {-}   ",
                     @"       _____,. {--}    ",
                     @"     /@ \ \ \ \ }      ",
                     @"     v-.\].]--]}'      ",
                     @"  ><OOO// _|   _|      "

                },
                {
                     @"             {-}       ",
                     @"          {-}   {-}    ",
                     @"          \/     {-}   ",
                     @"                 {-}   ",
                     @"        _____,. {--}   ",
                     @"      /@ \ \ \ \ }     ",
                     @"      v-.\].]--]}'     ",
                     @"  ><OOO// _/   _/      "
                },
                {
                     @"          {-}{-}       ",
                     @"          \/    {-}    ",
                     @"                 {-}   ",
                     @"                  {-}  ",
                     @"         _____,. {--}  ",
                     @"       /@ \ \ \ \ }    ",
                     @"       v-.\].]--]}'    ",
                     @"  ><OOO// _/   _/      "
                },
                {
                     @"         <{-}{-}       ",
                     @"                {-}    ",
                     @"                  {-}  ",
                     @"                   {-} ",
                     @"         _____,. {--}  ",
                     @"       /@ \ \ \ \ }    ",
                     @"       v-.\].]--]}'    ",
                     @"  ><OOO// _/   _/      "
                },
                };
        }
    }
    class Dust2 : Enemy
    {
        public Dust2()
        {
            name = "";
            names.Add("Gilla");
            names.Add("Chuckwallop");
            elementType = "Dust";
            MaxHP = 27;
            HP = 27;
            strength = 9;
            defense = 18;
            speed = 18;
            exp = 10;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Erode");
            Moves.Add("Windstorm");
            area = new List<string>() { "earth area 2", "air area 2", "earth area 3", "air area 3" };
            itemDrop = new List<string>() { "hooked claw", "muddy fur", "feather" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Dust3 : Enemy
    {
        public Dust3()
        {
            name = "";
            names.Add("Fearcat");
            names.Add("Foxeros");
            elementType = "Dust";
            MaxHP = 47;
            HP = 47;
            strength = 19;
            defense = 35;
            speed = 35;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Landslide");
            Moves.Add("Tailwind");
            area = new List<string>() { "earth area 3", "air area 3", "earth area 4", "air area 4" };
            itemDrop = new List<string>() { "old bone", "sharp beak", "hollow fang" };
            itemDropRate = 1;
            money = 8;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Dust4 : Enemy
    {
        public Dust4()
        {
            name = "";
            names.Add("Dromescary");
            names.Add("Bactrina");
            elementType = "Dust";
            MaxHP = 80;
            HP = 80;
            strength = 34;
            defense = 60;
            speed = 60;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Dust Devil");
            Moves.Add("Rock Fort");
            area = new List<string>() {"earth area 4", "air area 4"};
            itemDrop = new List<string>() { "fossil", "ventifact scale", "gritty paw" };
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    public class Storm1a : Enemy
    {
        public Storm1a()
        {
            name = "";
            names.Add("Sleech");
            names.Add("Shail");
            elementType = "Storm";
            MaxHP = 25;
            HP = 25;
            strength = 3;
            defense = 3;
            speed = 7;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Hail");
            Moves.Add("Static Shock");
            area = new List<string>() { "air area 1", "water area 1", "karstbay caves middle level" };
            itemDrop = new List<string>() { "chitin wing", "sea gloop", "hooked claw" }; //30% chance of nothing, 1st = 40% chance, 2nd = 20% chance, 3rd = 10% chance
            itemDropRate = 1;
            money = 1;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"@    @                 ",
                     @" \   |                 ",
                     @"  \~~|                 ",
                     @"  {~~~~}               ",
                     @"   {~^^~~~~~~~~~       ",
                     @"    {~oooo~~~~~~~~~~~, ",
                     @"      {~oooooooooo~~~  "
                },
                {
                     @"                       ",
                     @"@    @                 ",
                     @" \   |                 ",
                     @"  \~~|                 ",
                     @"  {~~~~}               ",
                     @"   {~^^~~~~~~~~        ",
                     @"    {~oooo~~~~~~~~~~,  ",
                     @"      {~ooooooooo~~~   "

                },
                {
                     @"                       ",
                     @"                       ",
                     @" @   @                 ",
                     @"  \~~|}                ",
                     @"  {~~~~}               ",
                     @"   {~^^~~~~~~~         ",
                     @"    {~oooo~~~~~~~~~,   ",
                     @"      {~oooooooo~~~    "
                },
                {
                     @"                       ",
                     @"                       ",
                     @" @   @                 ",
                     @"  \~~|}                ",
                     @"  {~~~~}               ",
                     @"    {^^~~~~~~          ",
                     @"     {oooo~~~~~~~~,    ",
                     @"       {ooooooo~~~     "
                },
                {
                     @"                       ",
                     @"                       ",
                     @" @   @                 ",
                     @"  \~~|}                ",
                     @"  {~~~~}               ",
                     @"    {^^~~~~~           ",
                     @"     {oooo~~~~~~~,     ",
                     @"       {oooooo~~~      "
                },
                };
        }
    }
    class Storm1b : Enemy
    {
        public Storm1b()
        {
            name = "";
            names.Add("Glacila");
            names.Add("Icimawl");
            elementType = "Storm";
            MaxHP = 25;
            HP = 25;
            strength = 3;
            defense = 3;
            speed = 7;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Hail");
            Moves.Add("Tide Pool");
            area = new List<string>() { "air area 1", "water area 1", "air area 2", "water area 2" };
            itemDrop = new List<string>() { "spicule", "antenna", "hooked claw" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @" n __/_n<<<<<<<<<\     ",
                     @" /#   #\ <<<<<<<<<\    ",
                     @" \q# #q/ <<<<<<<<<<\   ",
                     @" /\# #/     ####<<<>|  ",
                     @"|##\o/###/########\\|  ",
                     @" |#/   \#|        \#|  ",
                     @"  m     m          m   "
                },
                {
                     @"      ___________      ",
                     @" n __/_n<<<<<<<<<\     ",
                     @" /#   #\ <<<<<<<<<\    ",
                     @" \q# #q/ <<<<<<<<<<\   ",
                     @" /\# #/ #   ####<<<>|  ",
                     @"|##\o/###|########\\|  ",
                     @"|#/    \m         \#|  ",
                     @" m                 m   "

                },
                {
                     @"      ___________      ",
                     @" n __/_n<<<<<<<<<\     ",
                     @" \q# #q/ <<<<<<<<<\    ",
                     @"  \# #/  <<<<<<<<<<\   ",
                     @" / \o/  #|  ####<<<>|  ",
                     @"|##\w/#\m|########\\|  ",
                     @"|#/               \#|  ",
                     @" m                 m   "
                },
                {
                     @"      ___________      ",
                     @" n __/_n<<<<<<<<<\     ",
                     @" \q# #q/ <<<<<<<<<\    ",
                     @"  \_o_/  <<<<<<<<<<\   ",
                     @" / www ##|  ####<<<>|  ",
                     @"|##___#\m|########\\|  ",
                     @"|#/               \#|  ",
                     @" m                 m   "
                },
                {
                     @"      ___________      ",
                     @" n __/_n<<<<<<<<<\     ",
                     @" \q# #q/ <<<<<<<<<\    ",
                     @"  \_o_/  <<<<<<<<<<\   ",
                     @" /| j |#|   ####<<<>|  ",
                     @"|##wwwm/##########\\|  ",
                     @"|#/               \#|  ",
                     @" m                 m   "
                },
                };
        }
    }
    class Storm2 : Enemy
    {
        public Storm2()
        {
            name = "";
            names.Add("Auktillery");
            names.Add("Tuffin");
            names.Add("Gormorant");
            elementType = "Storm";
            MaxHP = 55;
            HP = 55;
            strength = 9;
            defense = 9;
            speed = 18;
            exp = 10;
            hit = 70;
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Snowstorm");
            Moves.Add("Bubble Jet");
            area = new List<string>() { "air area 2", "water area 2", "air area 3", "water area 3" };
            itemDrop = new List<string>() { "light wing", "fin", "feather" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Storm3 : Enemy
    {
        public Storm3()
        {
            name = "";
            names.Add("Thunderra");
            names.Add("Boltron");
            names.Add("Electorm");
            elementType = "Storm";
            MaxHP = 95;
            HP = 95;
            strength = 19;
            defense = 19;
            speed = 35;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Deluge");
            Moves.Add("Curelonimbus");
            area = new List<string>() { "air area 3", "water area 3", "air area 4", "water area 4" };
            itemDrop = new List<string>() { "biolume", "sharp beak", "ocean fin" };
            itemDropRate = 1;
            money = 7;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Storm4 : Enemy
    {
        public Storm4()
        {
            name = "";
            names.Add("Hailstrom");
            names.Add("Psychlone");
            names.Add("Warnado");
            elementType = "Storm";
            MaxHP = 160;
            HP = 160;
            strength = 35;
            defense = 35;
            speed = 60;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Cloud Burst");
            Moves.Add("Cyclone");
            area = new List<string>() {"air area 4", "water area 4"};
            itemDrop = new List<string>() { "tentacle", "ventifact scale", "deep-sea blubber" };
            itemDropRate = 1;
            money = 10;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Hydrotherm1a : Enemy
    {
        public Hydrotherm1a()
        {
            name = "";
            names.Add("Clambert");
            names.Add("Shellfire");
            names.Add("Dievalve");
            elementType = "Hydrotherm";
            MaxHP = 25;
            HP = 25;
            strength = 7;
            defense = 3;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 18;
            MP = 18;
            Moves.Clear();
            Moves.Add("Vaporise");
            Moves.Add("Lava Bubble");
            area = new List<string>() { "water area 1", "fire area 1", "karstbay caves lower level" };
            itemDrop = new List<string>() { "fire egg", "sea gloop", "coal armour" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"                       ",
                     @"                       ",
                     @"   _,.-~-~-~-~-.,      ",
                     @" { @\   /@'\~\~\~ ~.   ",
                     @"  '-=======._\ ~\~\~;  ",
                     @"   )____.--~O'>======} ",
                     @" {'-========~/~/~/~/,' ",
                     @"  ' -~-~-~-~-~-~-''    "
                },
                {
                     @"                       ",
                     @"    _,.-~-~-~-~-.,     ",
                     @" { @\   /@'\~\~\~ ~.   ",
                     @"  '-=======._\ ~\~\~;  ",
                     @"    )        \ ~\~\~;  ",
                     @"   )____.--~O'>======} ",
                     @" {'-========~/~/~/~/,' ",
                     @"  ' -~-~-~-~-~-~-''    "

                },
                {
                     @"     _,.-~-~-~-.,      ",
                     @"   {@\===/@ ~\~\~\.    ",
                     @"     )      '~,~\~\.   ",
                     @"      )        \~\~\.  ",
                     @"     )          }~\~;  ",
                     @"   /____.--~O'>======} ",
                     @" {'-========~/~/~/~/,' ",
                     @"  ' -~-~-~-~-~-~-''    "
                },
                {
                     @"                       ",
                     @"    _,.-~-~-~-~-.,     ",
                     @" { @\   /@'\~\~\~ ~.   ",
                     @"  '-=======._\ ~\~\~;  ",
                     @"    )        \ ~\~\~;  ",
                     @"   )____.--~O'>======} ",
                     @" {'-========~/~/~/~/,' ",
                     @"  ' -~-~-~-~-~-~-''    "

                },
                {
                     @"                       ",
                     @"                       ",
                     @"   _,.-~-~-~-~-.,      ",
                     @" { @\   /@'\~\~\~ ~.   ",
                     @"  '-=======._\ ~\~\~;  ",
                     @"   )____.--~O'>======} ",
                     @" {'-========~/~/~/~/,' ",
                     @"  ' -~-~-~-~-~-~-''    "
                },
                };
        }
    }
    class Hydrotherm1b : Enemy
    {
        public Hydrotherm1b()
        {
            name = "";
            names.Add("Anger Fish");
            names.Add("Ventryfish");
            elementType = "Hydrotherm";
            MaxHP = 25;
            HP = 25;
            strength = 7;
            defense = 3;
            speed = 3;
            exp = 2;
            hit = 60;
            MaxMP = 20;
            MP = 20;
            Moves.Clear();
            Moves.Add("Vaporise");
            Moves.Add("Tide Pool");
            area = new List<string>() { "water area 1", "fire area 1", "water area 2", "fire area 2" };
            itemDrop = new List<string>() { "spicule", "flame gloop", "flint" };
            itemDropRate = 1;
            money = 3;
            animation = new string[5, 8] 
                {
                {
                     @"  ,~     _,.~-,        ",
                     @" /  \\ ,'>    >'/      ",
                     @";   _;'     >    '/  <\",
                     @"O   '<@   //  >  > ////",
                     @"       <\\     >    // ",
                     @" ^       <\  >    ,'   ",
                     @" |\_^_^_^_/ >  > '     ",
                     @"  \___________,.'      "
                },
                {
                     @"  ,~     _,.~-,        ",
                     @" /  \\ ,'>    >'/      ",
                     @" ;  _;'     >    '/  <\",
                     @" O  '<@   //  >  > ////",
                     @"       <\\     >    // ",
                     @" ^       <\  >    ,'   ",
                     @" |\_^_^_^_/ >  > '     ",
                     @"  \___________,.'      "

                },
                {
                     @"  ,~     _,.~-,        ",
                     @" /  \\ ,'>    >'/      ",
                     @"  ; _;'     >    '/  <\",
                     @"  O '<@   //  >  > ////",
                     @"       <\\     >    // ",
                     @" ^       <\  >    ,'   ",
                     @" |\_^_^_^_/ >  > '     ",
                     @"  \___________,.'      "
                },
                {
                     @"  ,~     _,.~-,        ",
                     @" /  \\ ,'>    >'/      ",
                     @" ;  _;'     >    '/  <\",
                     @" O  '<@   //  >  > ////",
                     @"       <\\     >    // ",
                     @" ^       <\  >    ,'   ",
                     @" |\_^_^_^_/ >  > '     ",
                     @"  \___________,.'      "
                },
                {
                     @"  ,~     _,.~-,        ",
                     @" ;  \\ ,'>    >'/      ",
                     @" O  _;'     >    '/  <\",
                     @"   |'<@   //  >  > ////",
                     @"   \^^ <\\     >    // ",
                     @"    \  ^ <\  >    ,'   ",
                     @"     \_  ^  >  > '     ",
                     @"       \______,.'      "
                },
                };
        }
    }
    class Hydrotherm2 : Enemy
    {
        public Hydrotherm2()
        {
            name = "";
            names.Add("Hydroworm");
            names.Add("Riftian");
            elementType = "Hydrotherm";
            MaxHP = 55;
            HP = 55;
            strength = 18;
            defense = 9;
            speed = 9;
            exp = 10;
            hit = 70; 
            MaxMP = 40;
            MP = 40;
            Moves.Clear();
            Moves.Add("Hot Spring");
            Moves.Add("Phoenix Fire");
            area = new List<string>() { "water area 2", "fire area 2", "water area 3", "fire area 3" };
            itemDrop = new List<string>() { "flint", "ocean scale", "fire fang" };
            itemDropRate = 1;
            money = 5;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Hydrotherm3 : Enemy
    {
        public Hydrotherm3()
        {
            name = "";
            names.Add("Crabattle");
            names.Add("Maglob");
            names.Add("Crustpunk");
            elementType = "Hydrotherm";
            MaxHP = 95;
            HP = 95;
            strength = 35;
            defense = 19;
            speed = 19;
            exp = 25;
            hit = 80;
            MaxMP = 65;
            MP = 65;
            Moves.Clear();
            Moves.Add("Geyser");
            Moves.Add("Pyroclastic Flow");
            area = new List<string>() { "fire area 3", "water area 3", "water area 4", "fire area 4" };
            itemDrop = new List<string>() { "tentacle", "burning tail", "lava rock" };
            itemDropRate = 1;
            money = 6;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
    class Hydrotherm4 : Enemy
    {
        public Hydrotherm4()
        {
            name = "";
            names.Add("Venusquid");
            names.Add("Thermoctopus");
            names.Add("Cephalopunch");
            elementType = "Hydrotherm";
            MaxHP = 160;
            HP = 160;
            strength = 60;
            defense = 35;
            speed = 35;
            exp = 50;
            hit = 90;
            MaxMP = 90;
            MP = 90;
            Moves.Clear();
            Moves.Add("Hydrothermal Blast");
            Moves.Add("Monsoon");
            area = new List<string>() {"fire area 4", "water area 4"};
            itemDrop = new List<string>() { "biolume", "infernal scale", "deep-sea blubber" };
            itemDropRate = 1;
            money = 9;
            animation = new string[5, 8] 
                {
                {
                     @"      ___________      ",
                     @"     />>>>>>>>>n_\__ n ",
                     @"    />>>>>>>>> /#   #\ ",
                     @"   />>>>>>>>>> \q# #q/ ",
                     @"  |<>>>####     \# #/\ ",
                     @"  |//########\###\o/##|",
                     @"   |#/       |#/    \#|",
                     @"    m         m      m "
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> /#   #\  ",
                     @"  />>>>>>>>>> \q# #q/  ",
                     @" |<>>>####   # \# #/\  ",
                     @" |//########|###\o/##| ",
                     @" |#/        m/    \#|  ",
                     @"  m                m   ",

                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \# #/   ",
                     @" |<>>>####  |## \o/ \  ",
                     @" |//########|m/#\w/##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####  |## www \  ",
                     @" |//#########\m#___##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                {
                     @"     ___________       ",  
                     @"    />>>>>>>>>n_\__ n  ",
                     @"   />>>>>>>>> \q# #q/  ",
                     @"  />>>>>>>>>>  \_o_/   ",
                     @" |<>>>####   |#| j |\  ",
                     @" |//##########\mwww##| ",
                     @"  |#/              \#| ",
                     @"   m                m  ",
                },
                };
        }
    }
}
