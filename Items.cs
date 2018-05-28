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
            itemBuyValue = 35;
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

    public class LacqueredShield : Item
    {
        public LacqueredShield()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "lacquered shield";
            itemDescription = "It should protect against medium foes";
            itemType = "shield";
            itemBuyValue = 35;
            equippable = true;
            itemBodyLocation = "shield";
            itemStrengthBonus = 0;
            itemDefenseBonus = 15;
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
                   @"/@@\/-#=#|\\_ =@>      ",
                   @"\@@=/##=#/ `-/'        ",
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

    public class MegaSword : Item
    {
        public MegaSword()
        {
            weaponstatName = "beginnings";
            weaponelementName = "neutral";
            itemName = "mega sword";
            itemDescription = "A sword of legendary abilities";
            itemType = "weapon";
            itemBuyValue = 200;
            itemSellValue = 100;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 30;
            itemSpeedBonus = 0;
            itemDefenseBonus = 5;
            itemCharismaBonus = 10;
            itemHPGain = 0;
            itemHitGain = 0;
            sprite = new string[1, 8]
                {
                {
                  @"       ~~~          *  ",
                  @"     ~~~=.\        //  ",
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
            itemDescription = "A decent axe for aspiring adventurers";
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
            itemDescription = "A decent mace for aspiring adventurers";
            itemType = "weapon";
            itemBuyValue = 35;
            itemSellValue = 15;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 15;
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
            itemDescription = "A decent spear for aspiring adventurers";
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
            itemDescription = "A decent bow for aspiring adventurers";
            itemType = "weapon";
            itemBuyValue = 35;
            itemSellValue = 10;
            equippable = true;
            itemBodyLocation = "weapon";
            itemStrengthBonus = 10;
            itemSpeedBonus = 10;
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
            itemHPGain = 6;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class TinyParsnip : Item
    {
        public TinyParsnip()
        {
            itemName = "tiny parsnip";
            itemDescription = "It leaves a lot to be desired.";
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
            itemDescription = "It's just an ordinary carrot.";
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
            itemDescription = "I wonder if these berries grow all year round?";
            itemType = "healthgain";
            itemBuyValue = 2;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 6;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class BagOfOats : Item
    {
        public BagOfOats()
        {
            itemName = "bag of oats";
            itemDescription = "Versatile and full of fibre!";
            itemType = "healthgain";
            itemBuyValue = 5;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 10;
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
            itemHPGain = 10;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Sandwich : Item
    {
        public Sandwich()
        {
            itemName = "sandwich";
            itemDescription = "Text... the best flavour?";
            itemType = "healthgain";
            itemBuyValue = 12;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 20;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Burger : Item
    {
        public Burger()
        {
            itemName = "burger";
            itemDescription = "";
            itemType = "healthgain";
            itemBuyValue = 20;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 30;
            allyTargetBattle = true;
            edibleVerb = "ate";
        }
    }

    public class Fishcake : Item
    {
        public Fishcake()
        {
            itemName = "fishcake";
            itemDescription = "This smells a bit fishy to me.";
            itemType = "healthgain";
            itemBuyValue = 20;
            itemSellValue = 0;
            equippable = false;
            itemHPGain = 30;
            itemMPGain = 30;
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

    public class Mushrooms : Item //awakens
    {
        public Mushrooms()
        {
            itemName = "mushrooms";
            itemDescription = "These don't look like regular mushrooms.";
            itemType = "drug";
            itemBuyValue = 0;
            itemSellValue = 0;
            edibleVerb = "ate";
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
            battleDamage = 10;
            opponentTargetBattle = true;
        }
    }

    public class BatDropping : Item
    {
        public BatDropping()
        {
            itemName = "bat dropping";
            itemDescription = "Gross.";
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
            itemDescription = "It seems to be mechanically powered.";
            itemType = "torch";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Key : Item
    {
        public Key()
        {
            itemName = "key";
            itemDescription = "Which lock does this open?";
            itemType = "key";
            itemBuyValue = 10;
            itemSellValue = 2;
            equippable = false;
            keyItem = true;
        }
    }

    public class Letter : Item
    {
        public Letter()
        {
            itemName = "letter";
            itemDescription = "They keep trying to steal my most prized posession, so I've hidden it! They'll never find it in the forest.";
            itemType = "book";
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
            itemDescription = "It's a grey rock with large white crystals throughout.";
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
            itemDescription = "It's a fairly viscous turquoise liquid that is glowing inside of the vial you collected it in.";
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
            itemDescription = "...The substance known as Protomeebium was recently sourced from one of its rare locations. My colleagues and I have conducted chemical analyses, which concluded that protomeebium is primarily a Carbon-based substance with relatively high traces of Uranium. It is generally unreactive, unless in the presence of an as-of-yet unidentified rock that can be found close to the Protomeebium locality. Under heat and pressure the Protomeebium reacts when exposed to this rock.\n     -Dr. Grell, Eclipse Research Department";
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
            itemDescription = "The village of Rifton was founded over 300 years ago, with its location chosen due to the protective walls of the canyon either side. It is thought that there may have been previous settlements in this location prior to Rifton from archaeological remians, although it is unknown why the area was then abandoned.";
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
            itemDescription = "The Polluted Lands.\nChapter 1.\nThe past 50 years have seen an increase in radioactivity levels in the Terethian subsoils, notably towards the northeast of the continent. A reduction in flora and behavioural changes in fauna in the vicinity of these regions has been documented, and will be discussed further in this book.";
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
            itemDescription = "During the past 30 years environmental surveys have shown an increase in contamination levels of soil in arable land. This has been attributed in part to increased pollution associated with industrious endeavors to create more efficient energy resources, however the full impact of this is still unknown. The contamination appears to decrease with soil depth, and farmers have found that ploughing soil to a deeper level has alleviated the reduction in soil quality somewhat. Ideally, a longer-term solution should be created to prevent further issues arising.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item may be worth examining back at the lab.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
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
            itemDescription = "This item can be used for splicing.";
            itemName = "geyser root";
            elementType = "hydrotherm";
            dropItemLevel = 4;
        }
    }
}
