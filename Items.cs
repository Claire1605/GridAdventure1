using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GridAdventure1
{
    [JsonObject]
    public class Item
    {
        public string itemName;
        public string itemDescription;
        public string itemType = "null"; //weapon, armour, healthgain, dropItem, evolveItem, statusChange, key, torch, map, inBattle, book, battleOffensive
        public bool allyTargetBattle;
        public bool opponentTargetBattle;
        public double battleDamage; //bmp of item
        public int itemBuyValue;
        public int itemSellValue;
        public bool equippable;
        public string itemBodyLocation; // "weapon", "armour"
        public int itemStrengthBonus;
        public int itemDefenseBonus;
        public int itemSpeedBonus;
        public int itemCharismaBonus;
        public int itemHPGain;
        public int itemMPGain;
        public bool antidote;
        public bool awaken;
        public int itemHitGain;
        public bool keyItem;
        public string elementType;
        public int dropItemLevel;
        public string weaponAugment;
        public string weaponElement;
        public string weaponstatName;
        public string weaponelementName;
        public string modOption1;
        public string modOption2;
        public string[,] sprite;
        public string edibleVerb;
        public string weaponArmourLocation = "";
    }
    public class Shield : Item
    {
        public Shield()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "shield";
            itemDescription = "It should protect against very weak foes";
            itemType = "shield";
            equippable = true;
            itemBodyLocation = "shield";
            itemStrengthBonus = 0;
            itemDefenseBonus = 5;
            itemSpeedBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            weaponAugment = "";
            weaponElement = "";
            sprite = new string[1, 8] 
                {
                {
                   @"       ~~~             ",
                   @"     ~~~=.\            ",
                   @"    ~~~~ _/            ",
                   @" __  .~~-¬.            ",
                   @"/__\/-#=#|\\_ =@>      ",
                   @"\_@=/##=#/ `-/'        ",
                   @"     |#_/]             ",
                   @"      |_ \_            "
                },
                };
        }
    }

    public class Stick : Item
    {
        public Stick()
        { //if change these - change in downgrade section too
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "stick";
            itemDescription = "It should protect against very weak foes";
            itemType = "weapon";
            equippable = true;
            itemBuyValue = 0;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 2;
            itemDefenseBonus = 0;
            itemSpeedBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            weaponAugment = "";
            weaponElement = "";
            sprite = new string[1, 8] 
                {
                {
                   @"       ~~~             ",
                   @"     ~~~=.\   .I       ",
                   @"    ~~~~ _/   '}'      ",
                   @" __  .~~-¬.    {,      ",
                   @"/__\/-#=#|\\_ =@>      ",
                   @"\_@=/##=#/ `-/'        ",
                   @"     |#_/]             ",
                   @"      |_ \_            "
                },
                };

        }
    }
    public class Sword : Item
    {
        public Sword()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "sword";
            itemDescription = "A decent sword for aspiring adventurers";
            itemType = "weapon";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 5;
            itemSpeedBonus = -2;
            itemDefenseBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8] 
                {
                {
                  @"       ~~~             ",
                  @"     ~~~=.\        /   ",
                  @"    ~~~~ _/       //   ",
                  @" __  .~~-¬.      //    ",
                  @"/__\/-#=#|\\_ =@>>     ",
                  @"\_@=/##=#/ `-/'        ",
                  @"     |#_/]             ",
                  @"      |_ \_            "
                },
                };
        }
    }

    public class Axe : Item
    {
        public Axe()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "axe";
            itemDescription = "";
            itemType = "weapon";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 7;
            itemSpeedBonus = -4;
            itemDefenseBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8] 
                {
                {
                  @"       ~~~    {|=\     ",
                  @"     ~~~=.\   [|__\    ",
                  @"    ~~~~ _/    I       ",
                  @" __  .~~-¬.    I       ",
                  @"/__\/-#=#|\\_ =@>      ",
                  @"\_@=/##=#/ `-/'        ",
                  @"     |#_/]             ",
                  @"      |_ \_            "
                },
                };
        }
    }

    public class Mace : Item
    {
        public Mace()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "mace";
            itemDescription = "";
            itemType = "weapon";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 6;
            itemSpeedBonus = -3;
            itemDefenseBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8] 
                {
                {
                  @"       ~~~     I'.     ",
                  @"     ~~~=.\    I  '*   ",
                  @"    ~~~~ _/    I       ",
                  @" __  .~~-¬.    I       ",
                  @"/__\/-#=#|\\_ =@>      ",
                  @"\_@=/##=#/ `-/'        ",
                  @"     |#_/]             ",
                  @"      |_ \_            "
                },
                };
        }
    }

    public class Spear : Item
    {
        public Spear()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "spear";
            itemDescription = "";
            itemType = "weapon";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 4;
            itemSpeedBonus = 1;
            itemDefenseBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8] 
                {
                {
                 @"       ~~~         /   ",
                 @"     ~~~=.\       /    ",
                 @"    ~~~~ _/      /     ",
                 @" __  .~~-¬.     /      ",
                 @"/__\/-#=#|\\_ =@>      ",
                 @"\_@=/##=#/ `-/'        ",
                 @"     |#_/]  /          ",
                 @"      |_ \_            "
                },
                };
        }
    }

    public class Bow : Item
    {
        public Bow()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "bow";
            itemDescription = "";
            itemType = "weapon";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 3;
            itemSpeedBonus = 3;
            itemDefenseBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8] 
                {
                {
                @"       ~~~   .         ",
                @"     ~~~=.\,' \        ",
                @"    ~~~~ _/    :       ",
                @" __  .~~-¬.    }       ",
                @"/__\/-#=#|\\_ =@>      ",
                @"\_@=/##=#/,`-/':       ",
                @"     |#_/] ', /        ",
                @"      |_ \_  '         "
                },
                };
        }
    }

    public class CottonVest : Item
    {
        public CottonVest()
        {
            itemName = "cotton vest";
            itemDescription = "Very light protection, mainly against the elements.";
            itemType = "armour";
            itemBuyValue = 5;
            itemSellValue = 2;
            equippable = true;
            itemBodyLocation = "armour";
            itemDefenseBonus = 1;
            itemStrengthBonus = 0;
            itemSpeedBonus = 0;
            itemCharismaBonus = 0;
            itemHPGain = 0;
            itemHitGain = 0;
        }
    }
    public class KnittedVest : Item
    {
        public KnittedVest()
        {
            itemName = "knitted vest";
            itemDescription = "A warm cozy vest that provides minimal defense";
            itemType = "armour";
            itemBuyValue = 5;
            itemSellValue = 2;
            equippable = true;
            itemBodyLocation = "armour";
            itemDefenseBonus = 2;
            itemStrengthBonus = 0;
            itemSpeedBonus = 0;
            itemCharismaBonus = 1;
            itemHPGain = 0;
            itemHitGain = 0;
        }
    }
    public class Chainmail : Item
    {
        public Chainmail()
        {
            itemName = "chainmail";
            itemDescription = "Clank!";
            itemType = "armour";
            itemBuyValue = 20;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "armour";
            itemDefenseBonus = 5;
            itemSpeedBonus = -2;
            itemStrengthBonus = 0;
            itemCharismaBonus = 1;
            itemHPGain = 0;
            itemHitGain = 0;
        }
    }
    public class Apple : Item
    {
        public Apple()
        {
            itemName = "apple";
            itemDescription = "Keep those Doctors away";
            itemType = "healthgain";
            itemBuyValue = 2;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 5;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class TinyParsnip : Item
    {
        public TinyParsnip()
        {
            itemName = "tiny parsnip";
            itemDescription = "It could probably just about feed a mouse";
            itemType = "healthgain";
            itemBuyValue = 0;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 3;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Carrot : Item
    {
        public Carrot()
        {
            itemName = "carrot";
            itemDescription = "You feel like you could see in the dark! Maybe best to stick with the flashlight though.";
            itemType = "healthgain";
            itemBuyValue = 0;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 15;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Onion : Item
    {
        public Onion()
        {
            itemName = "onion";
            itemDescription = "They're not tears, it's just the onion!";
            itemType = "healthgain";
            itemBuyValue = 0;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 15;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Potato : Item
    {
        public Potato()
        {
            itemName = "potato";
            itemDescription = "Boil 'em, Mash 'em...";
            itemType = "healthgain";
            itemBuyValue = 0;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 15;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Beans : Item
    {
        public Beans()
        {
            itemName = "beans";
            itemDescription = "Best not to eat too many.";
            itemType = "healthgain";
            itemBuyValue = 0;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 15;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class WildBerries : Item
    {
        public WildBerries()
        {
            itemName = "apple";
            itemDescription = "";
            itemType = "healthgain";
            itemBuyValue = 2;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 2;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Oats : Item
    {
        public Oats()
        {
            itemName = "oats";
            itemDescription = "Versatile and full of fibre!";
            itemType = "healthgain";
            itemBuyValue = 5;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 5;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class DriedFish : Item
    {
        public DriedFish()
        {
            itemName = "dried fish";
            itemDescription = "Tastier than it smells";
            itemType = "mpgain";
            itemBuyValue = 8;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 5;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class RedPiponShake : Item //restores hp
    {
        public RedPiponShake()
        {
            itemName = "red pipon shake";
            itemDescription = "The most revitalising milkshake in the world!";
            itemType = "healthgain";
            itemBuyValue = 20;
            itemSellValue = 0;
            itemHPGain = 10;
            allyTargetBattle = true;
            edibleVerb = "drank";
        }
    }


    public class BluePiponShake : Item //restores mp
    {
        public BluePiponShake()
        {
            itemName = "blue pipon shake";
            itemDescription = "The most magical milkshake in the world!";
            itemType = "mpgain";
            itemBuyValue = 20;
            itemSellValue = 0;
            itemMPGain = 10;
            allyTargetBattle = true;
            edibleVerb = "drank";
        }
    }


    public class GreenPiponShake : Item //antidote
    {
        public GreenPiponShake()
        {
            itemName = "green pipon shake";
            itemDescription = "The most cleansing milkshake in the world!";
            itemType = "antidote";
            itemBuyValue = 20;
            itemSellValue = 0;
            antidote = true;
            allyTargetBattle = true;
            edibleVerb = "drank";
        }
    }


    public class PinkPiponShake : Item //awakens
    {
        public PinkPiponShake()
        {
            itemName = "pink pipon shake";
            itemDescription = "The most stimulating milkshake in the world!";
            itemType = "awakening";
            itemBuyValue = 20;
            itemSellValue = 0;
            awaken = true;
            allyTargetBattle = true;
            edibleVerb = "drank";
        }
    }

    public class FavDrink : Item //full-restore hp
    {
        public FavDrink()
        {
            itemName = "milkshake";
            itemDescription = "There's nothing like your favourite drink to nourish you back to health";
            itemType = "healthgain";
            itemBuyValue = 40;
            itemSellValue = 0;
            itemHPGain = 5000;
            allyTargetBattle = true;
            edibleVerb = "drank";
        }
    }

    public class Rock : Item
    {
        public Rock()
        {
            itemName = "rock";
            itemDescription = "This rocks";
            itemType = "battleOffensive";
            battleDamage = 5;
            opponentTargetBattle = true;
        }
    }

    public class LargeBranch : Item
    {
        public LargeBranch()
        {
            itemName = "large branch";
            itemDescription = "A sturdy log";
            itemType = "branch";
        }
    }

    public class Flashlight : Item
    {
        public Flashlight()
        {
            itemName = "flashlight";
            itemDescription = "The light of my life";
            itemType = "torch";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Detector : Item
    {
        public Detector()
        {
            itemName = "detector";
            itemDescription = "It radiates science";
            itemType = "detector";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Pickaxe : Item
    {
        public Pickaxe()
        {
            itemName = "pickaxe";
            itemDescription = "Can you dig it?";
            itemType = "shovel";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Ellondite : Item
    {
        public Ellondite()
        {
            itemName = "ellondite";
            itemDescription = "";
            itemType = "ellondite";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Protomeebium : Item //cave gloop
    {
        public Protomeebium()
        {
            itemName = "protomeebium";
            itemDescription = "";
            itemType = "protomeebium";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class ProtomeebiumBook : Item //cave gloop
    {
        public ProtomeebiumBook()
        {
            itemName = "protomeebium book";
            itemDescription = "...The substance known as Protomeebium was recently soured from one of its rare locations. My colleagues and I have conducted chemical analyses, which concluded that protomeebium is primarily a Carbon-based substance with relatively high traces of Uranium. It is generally unreactive, unless in the presence of an as of yet unidentified rock that can be found close to the Protomeebium locality. Under heat and pressure the Protomeebium reacts when exposed to this rock.\n     -Dr. Grell, Eclipse Research Department";
            itemType = "book";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class RapidRadiationsHistoryBook : Item 
    {
        public RapidRadiationsHistoryBook()
        {
            itemName = "Rapid evolutionary radiations throughout history";
            itemDescription = "...Fossil remains have shown an unusual pattern of repeated surges in evolutionary diversity occurring every 100 thousand years. These radiations tend to be geographically confined to restricted areas that change with each subsequent event...";
            itemType = "book";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class HistoryRiftonVillageBook : Item //cave gloop
    {
        public HistoryRiftonVillageBook()
        {
            itemName = "history of rifton village";
            itemDescription = "";
            itemType = "book";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class PollutedLandsBook : Item 
    {
        public PollutedLandsBook()
        {
            itemName = "the polluted lands";
            itemDescription = "The Polluted Lands.\nChapter 1.\n";
            itemType = "book";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class GardeningBeginnersBook : Item 
    {
        public GardeningBeginnersBook()
        {
            itemName = "Soil Quality and Gardening";
            itemDescription = "During the past 30 years environmental surveys have shown an increase in contamination levels of soil in arable land.\nThis has been attributed in part to increased pollution associated with industrious endeavors to create more efficient energy resources, however the full impact of this is still unknown.\nThe contamination appears to decrease with soil depth, and farmers have found that ploughing soil to a deeper level has alleviated the reduction in soil quality somewhat.\nIdeally, a longer-term solution should be created to prevent further issues arising.";
            itemType = "book";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Grellite : Item //weapon - atk1
    {
        public Grellite()
        {
            itemName = "grellite"; //item needed to get to this level
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 10;
            weaponstatName = "power";
            weaponArmourLocation = "behind the Industrial Estate. There's a scrap yard inside with a lot of common materials.";
        }
    }

    public class RedMustonite : Item //weapon - atk2
    {
        public RedMustonite()
        {
            itemName = "red mustonite";
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 20;
            weaponstatName = "great power";
            weaponArmourLocation = "near Mesetra. There's an outcrop of rock containing the mineral on the south-west of the city.";
        }
    }

    public class RedCobarite : Item //weapon - atk3
    {
        public RedCobarite()
        {
            itemName = "red cobarite";
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 35;
            weaponstatName = "extreme power";
            weaponArmourLocation = "";
            weaponArmourLocation = "near the Island past Laharva.";
        }
    }

    public class RedSafrostine : Item //weapon - atk4
    {
        public RedSafrostine()
        {
            itemName = "red safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 55;
            weaponstatName = "absolute power";
            weaponArmourLocation = "somewhere near Laharva.";
        }
    }

    public class BlueMustonite : Item //weapon - spd1
    {
        public BlueMustonite()
        {
            itemName = "blue mustonite";
            itemDescription = "";
            itemType = "weaponMod";
            itemSpeedBonus = 10;
            weaponstatName = "swiftness";
            weaponArmourLocation = "near Mesetra. There's an outcrop of rock containing the mineral on the south-west of the city.";
        }
    }

    public class BlueCobarite : Item //weapon - spd2
    {
        public BlueCobarite()
        {
            itemName = "blue cobarite";
            itemDescription = "";
            itemType = "weaponMod";
            itemSpeedBonus = 20;
            weaponstatName = "great swiftness";
            weaponArmourLocation = "on the seabed past Corallos.";
        }
    }

    public class BlueSafrostine : Item //weapon - spd3
    {
        public BlueSafrostine()
        {
            itemName = "blue safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemSpeedBonus = 35;
            weaponstatName = "extreme swiftness";
            weaponArmourLocation = "somewhere near Mesetra.";
        }
    }

    public class GreenCobarite : Item //weapon - hp1
    {
        public GreenCobarite()
        {
            itemName = "green cobarite";
            itemDescription = "";
            itemType = "weaponMod";
            itemHPGain = 30;
            weaponstatName = "vitality";
            weaponArmourLocation = "";
            weaponArmourLocation = "near the Island past Laharva.";
        }
    }

    public class GreenSafrostine : Item //change all these to actual items
    {
        public GreenSafrostine()
        {
            itemName = "green safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemHPGain = 60;
            weaponstatName = "great vitality";
            weaponArmourLocation = "somewhere near Corallos.";
        }
    }

    public class YellowCobarite : Item //weapon - hit1
    {
        public YellowCobarite()
        {
            itemName = "yellow cobarite";
            itemDescription = "";
            itemType = "weaponMod";
            itemHitGain = 3;
            weaponstatName = "accuracy";
            weaponArmourLocation = "on the seabed past Corallos.";
        }
    }

    public class YellowSafrostine : Item //weapon - hit2
    {
        public YellowSafrostine()
        {
            itemName = "yellow safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemHitGain = 7;
            weaponstatName = "great accuracy";
            weaponArmourLocation = "somewhere near Arbelle.";
        }
    }

    public class PinkSafrostine : Item //weapon - cha1
    {
        public PinkSafrostine()
        {
            itemName = "pink safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemCharismaBonus = 15;
            weaponstatName = "wit";
            weaponArmourLocation = "somewhere near Arbelle.";
        }
    }

    public class BrownSafrostine : Item //weapon - atk hp
    {
        public BrownSafrostine()
        {
            itemName = "brown safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 30;
            itemHPGain = 40;
            weaponstatName = "power and vitality";
            weaponArmourLocation = "somewhere near Laharva.";
        }
    }

    public class PurpleSafrostine : Item //weapon - atk spd
    {
        public PurpleSafrostine()
        {
            itemName = "purple safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemStrengthBonus = 30;
            itemSpeedBonus = 30;
            weaponstatName = "power and swiftness";
            weaponArmourLocation = "somewhere near Mesetra.";
        }
    }

    public class LimeSafrostine : Item //weapon - hit hp
    {
        public LimeSafrostine()
        {
            itemName = "lime safrostine";
            itemDescription = "";
            itemType = "weaponMod";
            itemHitGain = 6;
            itemHPGain = 40;
            weaponstatName = "accuracy and vitality";
            weaponArmourLocation = "somewhere near Corallos.";
        }
    }

    public class Quarlite : Item //armour - def1
    {
        public Quarlite()
        {
            itemName = "quarlite";
            itemDescription = "";
            itemType = "armourMod";
            itemDefenseBonus = 10;
            weaponstatName = "resistance";
            weaponArmourLocation = "behind the Industrial Estate. There's a scrap yard inside with a lot of common materials.";
        }
    }

    public class RedTomaline : Item //armour - def2
    {
        public RedTomaline()
        {
            itemName = "red tomaline";
            itemDescription = "";
            itemType = "armourMod";
            itemDefenseBonus = 20;
            weaponstatName = "great resistance";
            weaponArmourLocation = "near Corallos. There's a large rock in the city that has a high amount of Tomaline in it.";
        }
    }

    public class RedCorusite : Item //armour - def3
    {
        public RedCorusite()
        {
            itemName = "red corusite";
            itemDescription = "";
            itemType = "armourMod";
            itemDefenseBonus = 35;
            weaponstatName = "extreme resistance";
            weaponArmourLocation = "in the mountains past Graben.";
        }
    }

    public class RedDirazite : Item //armour - def4
    {
        public RedDirazite()
        {
            itemName = "red dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemDefenseBonus = 55;
            weaponstatName = "absolute resistance";
            weaponArmourLocation = "somewhere near Graben.";
        }
    }

    public class GreenTomaline : Item //armour - hp1
    {
        public GreenTomaline()
        {
            itemName = "green tomaline";
            itemDescription = "";
            itemType = "armourMod";
            itemHPGain = 30;
            weaponstatName = "vitality";
            weaponArmourLocation = "near Corallos. There's a large rock in the city that has a high amount of Tomaline in it.";
        }
    }

    public class GreenCorusite : Item //armour - hp2
    {
        public GreenCorusite()
        {
            itemName = "green corusite";
            itemDescription = "";
            itemType = "armourMod";
            itemHPGain = 40;
            weaponstatName = "great vitality";
            weaponArmourLocation = "in the forest past Arbelle.";
        }
    }

    public class GreenDirazite : Item //armour - hp3
    {
        public GreenDirazite()
        {
            itemName = "green dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemHPGain = 70;
            weaponstatName = "extreme vitality";
            weaponArmourLocation = "somewhere near Graben.";
        }
    }

    public class BlueCorusite : Item //armour - spd1
    {
        public BlueCorusite()
        {
            itemName = "blue corusite";
            itemDescription = "";
            itemType = "armourMod";
            itemSpeedBonus = 10;
            weaponstatName = "swiftness";
            weaponArmourLocation = "in the forest past Arbelle.";
        }
    }

    public class BlueDirazite : Item //armour - spd2
    {
        public BlueDirazite()
        {
            itemName = "blue dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemSpeedBonus = 20;
            weaponstatName = "great swiftness";
            weaponArmourLocation = "somewhere near Laharva.";
        }
    }

    public class YellowCorusite : Item //armour - hit1
    {
        public YellowCorusite()
        {
            itemName = "yellow corusite";
            itemDescription = "";
            itemType = "armourMod";
            itemHitGain = 3;
            weaponstatName = "accuracy";
            weaponArmourLocation = "in the mountains past Graben.";
        }
    }

    public class YellowDirazite : Item //change all these to actual items
    {
        public YellowDirazite()
        {
            itemName = "yellow dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemHitGain = 7;
            weaponstatName = "great accuracy";
            weaponArmourLocation = "somewhere near Arbelle.";
        }
    }

    public class PinkDirazite : Item //armour - cha1
    {
        public PinkDirazite()
        {
            itemName = "pink dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemCharismaBonus = 20;
            weaponstatName = "wit";
            weaponArmourLocation = "somewhere near Arbelle.";
        }
    }

    public class BrownDirazite : Item //armour - hpdef
    {
        public BrownDirazite()
        {
            itemName = "brown dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemDefenseBonus = 30;
            itemHPGain = 40;
            weaponstatName = "resistance and vitality";
            weaponArmourLocation = "somewhere near Graben.";
        }
    }

    public class OrangeDirazite : Item //armour - hitdef
    {
        public OrangeDirazite()
        {
            itemName = "orange dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemHitGain = 6;
            itemDefenseBonus = 30;
            weaponstatName = "resistance and accuracy";
            weaponArmourLocation = "somewhere near Graben.";
        }
    }

    public class AquaDirazite : Item //armour - hpspd
    {
        public AquaDirazite()
        {
            itemName = "aqua dirazite";
            itemDescription = "";
            itemType = "armourMod";
            itemSpeedBonus = 30;
            itemHPGain = 40;
            weaponstatName = "swiftness and vitality";
            weaponArmourLocation = "somewhere near Laharva.";
        }
    }

    class FireEgg : Item
    {
        public FireEgg()
        {
            itemType = "dropItem";
            itemName = "fire egg";
            elementType = "fire";
            dropItemLevel = 1;
        }
    }
    class FlameGloop : Item
    {
        public FlameGloop()
        {
            itemType = "dropItem";
            itemName = "flame gloop";
            elementType = "fire";
            dropItemLevel = 1;
        }
    }
    class CoalArmour : Item
    {
        public CoalArmour()
        {
            itemType = "dropItem";
            itemName = "coal armour";
            elementType = "fire";
            dropItemLevel = 2;
        }
    }
    class Flint : Item
    {
        public Flint()
        {
            itemType = "dropItem";
            itemName = "flint";
            elementType = "fire";
            dropItemLevel = 2;
        }
    }
    class FireFang : Item
    {
        public FireFang()
        {
            itemType = "dropItem";
            itemName = "fire fang";
            elementType = "fire";
            dropItemLevel = 3;
        }
    }
    class BurningTail : Item
    {
        public BurningTail()
        {
            itemType = "dropItem";
            itemName = "burning tail";
            elementType = "fire";
            dropItemLevel = 3;
        }
    }
    class InfernalScale : Item
    {
        public InfernalScale()
        {
            itemType = "dropItem";
            itemName = "infernal scale";
            elementType = "fire";
            dropItemLevel = 4;
        }
    }
    class LavaRock : Item
    {
        public LavaRock()
        {
            itemType = "dropItem";
            itemName = "lava rock";
            elementType = "fire";
            dropItemLevel = 4;
        }
    }
    class Seed : Item
    {
        public Seed()
        {
            itemType = "dropItem";
            itemName = "seed";
            elementType = "plant";
            dropItemLevel = 1;
        }
    }
    class Spore : Item
    {
        public Spore()
        {
            itemType = "dropItem";
            itemName = "spore";
            elementType = "plant";
            dropItemLevel = 1;
        }
    }
    class GrassScale : Item
    {
        public GrassScale()
        {
            itemType = "dropItem";
            itemName = "grass scale";
            elementType = "plant";
            dropItemLevel = 2;
        }
    }
    class PollenFang : Item
    {
        public PollenFang()
        {
            itemType = "dropItem";
            itemName = "pollen fang";
            elementType = "plant";
            dropItemLevel = 2;
        }
    }
    class Thorn : Item
    {
        public Thorn()
        {
            itemType = "dropItem";
            itemName = "thorn";
            elementType = "plant";
            dropItemLevel = 3;
        }
    }
    class VineBerry : Item
    {
        public VineBerry()
        {
            itemType = "dropItem";
            itemName = "vine berry";
            elementType = "plant";
            dropItemLevel = 3;
        }
    }
    class RottingBranch : Item
    {
        public RottingBranch()
        {
            itemType = "dropItem";
            itemName = "rotting branch";
            elementType = "plant";
            dropItemLevel = 4;
        }
    }
    class GoldenLeaf : Item
    {
        public GoldenLeaf()
        {
            itemType = "dropItem";
            itemName = "golden leaf";
            elementType = "plant";
            dropItemLevel = 4;
        }
    }
    class MudBall : Item
    {
        public MudBall()
        {
            itemType = "dropItem";
            itemName = "mud ball";
            elementType = "earth";
            dropItemLevel = 1;
        }
    }
    class Granule : Item
    {
        public Granule()
        {
            itemType = "dropItem";
            itemName = "granule";
            elementType = "earth";
            dropItemLevel = 1;
        }
    }
    class EarthyClaw : Item
    {
        public EarthyClaw()
        {
            itemType = "dropItem";
            itemName = "earthy claw";
            elementType = "earth";
            dropItemLevel = 2;
        }
    }
    class MuddyFur : Item
    {
        public MuddyFur()
        {
            itemType = "dropItem";
            itemName = "muddy fur";
            elementType = "earth";
            dropItemLevel = 2;
        }
    }
    class OldBone : Item
    {
        public OldBone()
        {
            itemType = "dropItem";
            itemName = "old bone";
            elementType = "earth";
            dropItemLevel = 3;
        }
    }
    class Fossil : Item
    {
        public Fossil()
        {
            itemType = "dropItem";
            itemName = "fossil";
            elementType = "earth";
            dropItemLevel = 3;
        }
    }
    class GrittyPaw : Item
    {
        public GrittyPaw()
        {
            itemType = "dropItem";
            itemName = "gritty paw";
            elementType = "earth";
            dropItemLevel = 4;
        }
    }
    class RockSlab : Item
    {
        public RockSlab()
        {
            itemType = "dropItem";
            itemName = "rock slab";
            elementType = "earth";
            dropItemLevel = 4;
        }
    }
    class ChitinWing : Item
    {
        public ChitinWing()
        {
            itemType = "dropItem";
            itemName = "chitin wing";
            elementType = "air";
            dropItemLevel = 1;
        }
    }
    class Antenna : Item
    {
        public Antenna()
        {
            itemType = "dropItem";
            itemName = "antenna";
            elementType = "air";
            dropItemLevel = 1;
        }
    }
    class LightWing : Item
    {
        public LightWing()
        {
            itemType = "dropItem";
            itemName = "light wing";
            elementType = "air";
            dropItemLevel = 2;
        }
    }
    class HookedClaw : Item
    {
        public HookedClaw()
        {
            itemType = "dropItem";
            itemName = "hooked claw";
            elementType = "air";
            dropItemLevel = 2;
        }
    }
    class Feather : Item
    {
        public Feather()
        {
            itemType = "dropItem";
            itemName = "feather";
            elementType = "air";
            dropItemLevel = 3;
        }
    }
    class SharpBeak : Item
    {
        public SharpBeak()
        {
            itemType = "dropItem";
            itemName = "sharp beak";
            elementType = "air";
            dropItemLevel = 3;
        }
    }
    class VentifactScale : Item
    {
        public VentifactScale()
        {
            itemType = "dropItem";
            itemName = "ventifact scale";
            elementType = "air";
            dropItemLevel = 4;
        }
    }
    class HollowFang : Item
    {
        public HollowFang()
        {
            itemType = "dropItem";
            itemName = "hollow fang";
            elementType = "air";
            dropItemLevel = 4;
        }
    }
    class Spicule : Item
    {
        public Spicule()
        {
            itemType = "dropItem";
            itemName = "spicule";
            elementType = "water";
            dropItemLevel = 1;
        }
    }
    class SeaGloop : Item
    {
        public SeaGloop()
        {
            itemType = "dropItem";
            itemName = "sea gloop";
            elementType = "water";
            dropItemLevel = 1;
        }
    }
    class OceanScale : Item
    {
        public OceanScale()
        {
            itemType = "dropItem";
            itemName = "ocean scale";
            elementType = "water";
            dropItemLevel = 2;
        }
    }
    class Fin : Item
    {
        public Fin()
        {
            itemType = "dropItem";
            itemName = "fin";
            elementType = "water";
            dropItemLevel = 2;
        }
    }
    class Tentacle : Item
    {
        public Tentacle()
        {
            itemType = "dropItem";
            itemName = "tentacle";
            elementType = "water";
            dropItemLevel = 3;
        }
    }
    class Biolume : Item
    {
        public Biolume()
        {
            itemType = "dropItem";
            itemName = "biolume";
            elementType = "water";
            dropItemLevel = 3;
        }
    }
    class DeepSeaBlubber : Item
    {
        public DeepSeaBlubber()
        {
            itemType = "dropItem";
            itemName = "deep-sea blubber";
            elementType = "water";
            dropItemLevel = 4;
        }
    }
    class OceanFin : Item
    {
        public OceanFin()
        {
            itemType = "dropItem";
            itemName = "ocean fin";
            elementType = "water";
            dropItemLevel = 4;
        }
    }

    class TinderRoot : Item
    {
        public TinderRoot()
        {
            itemType = "evolveItem";
            itemName = "tinder root";
            elementType = "fire";
            dropItemLevel = 1;
        }
    }
    class SmokeRoot : Item
    {
        public SmokeRoot()
        {
            itemType = "evolveItem";
            itemName = "smoke root";
            elementType = "fire";
            dropItemLevel = 2;
        }
    }
    class FlameRoot : Item
    {
        public FlameRoot()
        {
            itemType = "evolveItem";
            itemName = "flame root";
            elementType = "fire";
            dropItemLevel = 3;
        }
    }
    class InfernoRoot : Item
    {
        public InfernoRoot()
        {
            itemType = "evolveItem";
            itemName = "inferno root";
            elementType = "fire";
            dropItemLevel = 4;
        }
    }
    class SproutRoot : Item
    {
        public SproutRoot()
        {
            itemType = "evolveItem";
            itemName = "sprout root";
            elementType = "plant";
            dropItemLevel = 1;
        }
    }
    class GrassRoot : Item
    {
        public GrassRoot()
        {
            itemType = "evolveItem";
            itemName = "grass root";
            elementType = "plant";
            dropItemLevel = 2;
        }
    }
    class VineRoot : Item
    {
        public VineRoot()
        {
            itemType = "evolveItem";
            itemName = "vine root";
            elementType = "plant";
            dropItemLevel = 3;
        }
    }
    class ForestRoot : Item
    {
        public ForestRoot()
        {
            itemType = "evolveItem";
            itemName = "forest root";
            elementType = "plant";
            dropItemLevel = 4;
        }
    }
    class SoilRoot : Item
    {
        public SoilRoot()
        {
            itemType = "evolveItem";
            itemName = "soil root";
            elementType = "earth";
            dropItemLevel = 1;
        }
    }
    class BoulderRoot : Item
    {
        public BoulderRoot()
        {
            itemType = "evolveItem";
            itemName = "boulder root";
            elementType = "earth";
            dropItemLevel = 2;
        }
    }
    class TerraRoot : Item
    {
        public TerraRoot()
        {
            itemType = "evolveItem";
            itemName = "terra root";
            elementType = "earth";
            dropItemLevel = 3;
        }
    }
    class MountRoot : Item
    {
        public MountRoot()
        {
            itemType = "evolveItem";
            itemName = "mount root";
            elementType = "earth";
            dropItemLevel = 4;
        }
    }
    class BreezeRoot : Item
    {
        public BreezeRoot()
        {
            itemType = "evolveItem";
            itemName = "breeze root";
            elementType = "air";
            dropItemLevel = 1;
        }
    }
    class WindRoot : Item
    {
        public WindRoot()
        {
            itemType = "evolveItem";
            itemName = "wind root";
            elementType = "air";
            dropItemLevel = 2;
        }
    }
    class SkyRoot : Item
    {
        public SkyRoot()
        {
            itemType = "evolveItem";
            itemName = "sky root";
            elementType = "air";
            dropItemLevel = 3;
        }
    }
    class AtmosRoot : Item
    {
        public AtmosRoot()
        {
            itemType = "evolveItem";
            itemName = "atmos root";
            elementType = "air";
            dropItemLevel = 4;
        }
    }
    class DropRoot : Item
    {
        public DropRoot()
        {
            itemType = "evolveItem";
            itemName = "drop root";
            elementType = "water";
            dropItemLevel = 1;
        }
    }
    class PondRoot : Item
    {
        public PondRoot()
        {
            itemType = "evolveItem";
            itemName = "pond root";
            elementType = "water";
            dropItemLevel = 2;
        }
    }
    class LakeRoot : Item
    {
        public LakeRoot()
        {
            itemType = "evolveItem";
            itemName = "lake root";
            elementType = "water";
            dropItemLevel = 3;
        }
    }
    class OceanRoot : Item
    {
        public OceanRoot()
        {
            itemType = "evolveItem";
            itemName = "ocean root";
            elementType = "water";
            dropItemLevel = 4;
        }
    }
    class CinderRoot : Item
    {
        public CinderRoot()
        {
            itemType = "evolveItem";
            itemName = "cinder root";
            elementType = "charcoal";
            dropItemLevel = 1;
        }
    }
    class EmberRoot : Item
    {
        public EmberRoot()
        {
            itemType = "evolveItem";
            itemName = "ember root";
            elementType = "charcoal";
            dropItemLevel = 2;
        }
    }
    class CharredRoot : Item
    {
        public CharredRoot()
        {
            itemType = "evolveItem";
            itemName = "charred root";
            elementType = "charcoal";
            dropItemLevel = 3;
        }
    }
    class AshRoot : Item
    {
        public AshRoot()
        {
            itemType = "evolveItem";
            itemName = "ash root";
            elementType = "charcoal";
            dropItemLevel = 4;
        }
    }
    class AlgaeRoot : Item
    {
        public AlgaeRoot()
        {
            itemType = "evolveItem";
            itemName = "algae root";
            elementType = "moss";
            dropItemLevel = 1;
        }
    }
    class LichenRoot : Item
    {
        public LichenRoot()
        {
            itemType = "evolveItem";
            itemName = "lichen root";
            elementType = "moss";
            dropItemLevel = 2;
        }
    }
    class BogRoot : Item
    {
        public BogRoot()
        {
            itemType = "evolveItem";
            itemName = "bog root";
            elementType = "moss";
            dropItemLevel = 3;
        }
    }
    class SwampRoot : Item
    {
        public SwampRoot()
        {
            itemType = "evolveItem";
            itemName = "swamp root";
            elementType = "moss";
            dropItemLevel = 4;
        }
    }
    class SandRoot : Item
    {
        public SandRoot()
        {
            itemType = "evolveItem";
            itemName = "sand root";
            elementType = "dust";
            dropItemLevel = 1;
        }
    }
    class LoessRoot : Item
    {
        public LoessRoot()
        {
            itemType = "evolveItem";
            itemName = "loess root";
            elementType = "dust";
            dropItemLevel = 2;
        }
    }
    class DuneRoot : Item
    {
        public DuneRoot()
        {
            itemType = "evolveItem";
            itemName = "dune root";
            elementType = "dust";
            dropItemLevel = 3;
        }
    }
    class DesertRoot : Item
    {
        public DesertRoot()
        {
            itemType = "evolveItem";
            itemName = "desert root";
            elementType = "dust";
            dropItemLevel = 4;
        }
    }
    class CloudRoot : Item
    {
        public CloudRoot()
        {
            itemType = "evolveItem";
            itemName = "cloud root";
            elementType = "storm";
            dropItemLevel = 1;
        }
    }
    class HailRoot : Item
    {
        public HailRoot()
        {
            itemType = "evolveItem";
            itemName = "hail root";
            elementType = "storm";
            dropItemLevel = 2;
        }
    }
    class ThunderRoot : Item
    {
        public ThunderRoot()
        {
            itemType = "evolveItem";
            itemName = "thunder root";
            elementType = "storm";
            dropItemLevel = 3;
        }
    }
    class LightningRoot : Item
    {
        public LightningRoot()
        {
            itemType = "evolveItem";
            itemName = "lightning root";
            elementType = "storm";
            dropItemLevel = 4;
        }
    }
    class EvapoRoot : Item
    {
        public EvapoRoot()
        {
            itemType = "evolveItem";
            itemName = "evapo root";
            elementType = "hydrotherm";
            dropItemLevel = 1;
        }
    }
    class VapourRoot : Item
    {
        public VapourRoot()
        {
            itemType = "evolveItem";
            itemName = "vapour root";
            elementType = "hydrotherm";
            dropItemLevel = 2;
        }
    }
    class VentRoot : Item
    {
        public VentRoot()
        {
            itemType = "evolveItem";
            itemName = "vent root";
            elementType = "hydrotherm";
            dropItemLevel = 3;
        }
    }
    class GeyserRoot : Item
    {
        public GeyserRoot()
        {
            itemType = "evolveItem";
            itemName = "geyser root";
            elementType = "hydrotherm";
            dropItemLevel = 4;
        }
    }
}
