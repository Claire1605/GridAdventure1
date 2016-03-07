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
        public double hp = 50;
        public int hpBonus;
        public double currentHp = 50;
        public int MP = 200;
        public int currentMP = 200;
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

    public class FireTier1 : Meeba
    {
        public FireTier1()
        {
            name = "FireTier1"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FireTier2 : Meeba
    {
        public FireTier2()
        {
            name = "FireTier2"; //obviously this will change
            elementType = "fire";
            levelTier = 2;
            attackBonus = 20; 
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Phoenix Fire";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FireTier3 : Meeba
    {
        public FireTier3()
        {
            name = "FireTier3"; //obviously this will change
            elementType = "fire";
            levelTier = 3;
            attackBonus = 35;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Pyroclastic Flow";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FireTier4 : Meeba
    {
        public FireTier4()
        {
            name = "FireTier4"; //obviously this will change
            elementType = "fire";
            levelTier = 4;
            attackBonus = 55;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Inferno";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantTier1 : Meeba
    {
        public PlantTier1()
        {
            name = "PlantTier1"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantTier2 : Meeba
    {
        public PlantTier2()
        {
            name = "PlantTier2"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantTier3 : Meeba
    {
        public PlantTier3()
        {
            name = "PlantTier3"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantTier4 : Meeba
    {
        public PlantTier4()
        {
            name = "PlantTier4"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthTier1 : Meeba
    {
        public EarthTier1()
        {
            name = "EarthTier1"; //obviously this will change
            elementType = "earth";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 9;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Grainmail";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthTier2 : Meeba
    {
        public EarthTier2()
        {
            name = "EarthTier2"; //obviously this will change
            elementType = "earth";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 20;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Quake";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthTier3 : Meeba
    {
        public EarthTier3()
        {
            name = "EarthTier3"; //obviously this will change
            elementType = "earth";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 35;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Sand Shroud";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthTier4 : Meeba
    {
        public EarthTier4()
        {
            name = "EarthTier4"; //obviously this will change
            elementType = "earth";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 55;
            MP = 120;
            hitRange = 90;
            newMove = "Rock Fort";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirTier1 : Meeba
    {
        public AirTier1()
        {
            name = "AirTier1"; //obviously this will change
            elementType = "air";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 9;
            defenseBonus = 2;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Static Shock";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirTier2 : Meeba
    {
        public AirTier2()
        {
            name = "AirTier2"; //obviously this will change
            elementType = "air";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 20;
            defenseBonus = 6;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Windstorm";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirTier3 : Meeba
    {
        public AirTier3()
        {
            name = "AirTier3"; //obviously this will change
            elementType = "air";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 35;
            defenseBonus = 10;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Tailwind";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirTier4 : Meeba
    {
        public AirTier4()
        {
            name = "AirTier4"; //obviously this will change
            elementType = "air";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 55;
            defenseBonus = 15;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Cyclone";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterTier1 : Meeba
    {
        public WaterTier1()
        {
            name = "WaterTier1"; //obviously this will change
            elementType = "water";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 40;
            MP = 50;
            hitRange = 60;
            newMove = "Tide Pool";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterTier2 : Meeba
    {
        public WaterTier2()
        {
            name = "WaterTier2"; //obviously this will change
            elementType = "water";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 60;
            MP = 80;
            hitRange = 70;
            newMove = "Bubble Jet";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterTier3 : Meeba
    {
        public WaterTier3()
        {
            name = "WaterTier3"; //obviously this will change
            elementType = "water";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 90;
            MP = 100;
            hitRange = 80;
            newMove = "Deluge";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterTier4 : Meeba
    {
        public WaterTier4()
        {
            name = "WaterTier4"; //obviously this will change
            elementType = "water";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 15;
            defenseBonus = 15;
            hpBonus = 130;
            MP = 120;
            hitRange = 90;
            newMove = "Monsoon";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FirePlantTier1 : Meeba
    {
        public FirePlantTier1()
        {
            name = "FirePlantTier1"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FirePlantTier2 : Meeba
    {
        public FirePlantTier2()
        {
            name = "FirePlantTier2"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FirePlantTier3 : Meeba
    {
        public FirePlantTier3()
        {
            name = "FirePlantTier3"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class FirePlantTier4 : Meeba
    {
        public FirePlantTier4()
        {
            name = "FirePlantTier4"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantEarthTier1 : Meeba
    {
        public PlantEarthTier1()
        {
            name = "PlantEarthTier1"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantEarthTier2 : Meeba
    {
        public PlantEarthTier2()
        {
            name = "PlantEarthTier2"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantEarthTier3 : Meeba
    {
        public PlantEarthTier3()
        {
            name = "PlantEarthTier3"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class PlantEarthTier4 : Meeba
    {
        public PlantEarthTier4()
        {
            name = "PlantEarthTier4"; //obviously this will change
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthAirTier1 : Meeba
    {
        public EarthAirTier1()
        {
            name = "EarthAirTier1"; //obviously this will change
            elementType = "dust";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 7;
            MP = 50;
            hitRange = 60;
            newMove = "Sandstorm";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthAirTier2 : Meeba
    {
        public EarthAirTier2()
        {
            name = "EarthAirTier2"; //obviously this will change
            elementType = "dust";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 11;
            defenseBonus = 11;
            hpBonus = 15;
            MP = 80;
            hitRange = 70;
            newMove = "Erode";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthAirTier3 : Meeba
    {
        public EarthAirTier3()
        {
            name = "EarthAirTier3"; //obviously this will change
            elementType = "dust";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 17;
            defenseBonus = 17;
            hpBonus = 20;
            MP = 100;
            hitRange = 80;
            newMove = "Landslide";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class EarthAirTier4 : Meeba
    {
        public EarthAirTier4()
        {
            name = "EarthAirTier4"; //obviously this will change
            elementType = "dust";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 25;
            defenseBonus = 25;
            hpBonus = 33;
            MP = 120;
            hitRange = 90;
            newMove = "Dust Devil";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirWaterTier1 : Meeba
    {
        public AirWaterTier1()
        {
            name = "AirWaterTier1"; //obviously this will change
            elementType = "storm";
            levelTier = 1;
            attackBonus = 2;
            speedBonus = 6;
            defenseBonus = 2;
            hpBonus = 20;
            MP = 50;
            hitRange = 60;
            newMove = "Hail";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirWaterTier2 : Meeba
    {
        public AirWaterTier2()
        {
            name = "AirWaterTier2"; //obviously this will change
            elementType = "storm";
            levelTier = 2;
            attackBonus = 6;
            speedBonus = 11;
            defenseBonus = 6;
            hpBonus = 30;
            MP = 80;
            hitRange = 70;
            newMove = "Snowstorm";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirWaterTier3 : Meeba
    {
        public AirWaterTier3()
        {
            name = "AirWaterTier3"; //obviously this will change
            elementType = "storm";
            levelTier = 3;
            attackBonus = 10;
            speedBonus = 17;
            defenseBonus = 10;
            hpBonus = 40;
            MP = 100;
            hitRange = 80;
            newMove = "CureloNimbus";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class AirWaterTier4 : Meeba
    {
        public AirWaterTier4()
        {
            name = "AirWaterTier4"; //obviously this will change
            elementType = "storm";
            levelTier = 4;
            attackBonus = 15;
            speedBonus = 25;
            defenseBonus = 15;
            hpBonus = 65;
            MP = 120;
            hitRange = 90;
            newMove = "Cloud Burst";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterFireTier1 : Meeba
    {
        public WaterFireTier1()
        {
            name = "WaterFireTier1"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 1;
            attackBonus = 6;
            speedBonus = 2;
            defenseBonus = 2;
            hpBonus = 20;
            MP = 50;
            hitRange = 60;
            newMove = "Vaporise";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterFireTier2 : Meeba
    {
        public WaterFireTier2()
        {
            name = "WaterFireTier2"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 2;
            attackBonus = 11;
            speedBonus = 6;
            defenseBonus = 6;
            hpBonus = 30;
            MP = 80;
            hitRange = 70;
            newMove = "Hot Spring";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }

    public class WaterFireTier3 : Meeba
    {
        public WaterFireTier3()
        {
            name = "WaterFireTier3"; //obviously this will change
            elementType = "hydrotherm";
            levelTier = 3;
            attackBonus = 17;
            speedBonus = 10;
            defenseBonus = 10;
            hpBonus = 40;
            MP = 100;
            hitRange = 80;
            newMove = "Geyser";
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
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
            //sprite = new string[1, 8] 
            //    {
            //    {
            //         @"      ___________      ",
            //         @"     />>>>>>>>>n_\__ n ",
            //         @"    />>>>>>>>> /#   #\ ",
            //         @"   />>>>>>>>>> \q# #q/ ",
            //         @"  |<>>>####     \# #/\ ",
            //         @"  |//########\###\o/##|",
            //         @"   |#/       |#/    \#|",
            //         @"    m         m      m "
            //    },
            //    };
        }
    }
}