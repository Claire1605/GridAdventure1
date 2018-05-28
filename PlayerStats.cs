using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GridAdventure1
{
    [JsonObject]
    public class PlayerStats
    {
        public double playerLevel = 1;
        public double playerCurrentExp = 0;
        public int playerMoney = 15;
        public string name = "Red";
        public string favdrink = "milkshake";
        public string vertExpertise = "aves";
        public string vertExpertise2 = "mammalia";
        public string HPBar = "HP|////////////////////";
        public ConsoleColor textColour = ConsoleColor.Gray; //colours for battle sprites
        public string[,] sprite = new string[1, 8] 
                {
                {
                   @"       ~~~             ",
                   @"     ~~~=.\            ",
                   @"    ~~~~ _/            ",
                   @"     .~~-¬.            ",
                   @"    /-#=#|\\_ =@>      ",
                   @"  @=/##=#/ `-/'        ",
                   @"     |#_/]             ",
                   @"      |_ \_            "
                },
                };

        public string armour = "nothing";
        public string weapon = "fists";
        public string shield = "fists";
        public string weaponElement = "neutral";
        public string armourElement = "neutral";
        public string weaponStatName = "beginnings";
        public string armourStatName = "beginnings";

        public int playerHit = 55;
        public int playerArmourDef = 0;
        public int playerWeaponStrength = 1;
        public int playerArmourSpeed = 0;
        public int playerWeaponSpeed = 0;
        public int playerWeaponHP = 0;
        public int playerWeaponHit = 0;
        public int playerWeaponCharisma = 0;
        public int playerShieldDefense = 0;
        public int playerShieldSpeed = 0;
        public int playerShieldHP = 0;
        public int playerShieldCharisma = 0;
        public int playerShieldHit = 0;
        public int playerAccuracy = 95;

        public double tempDefenseStatChange; //semi-permanent stat increases, reset at start of each battle
        public double tempAttack;
        public double tempSpeed;
        public double tempAccuracy;
        public bool opponent1Target = false;
        public bool opponent2Target = false;
        public bool opponent3Target = false;
        public bool meeba1Target = false;
        public bool meeba2Target = false;
        public bool playerTarget = false;
        public bool StatusProtected = false;
        public int statusProtectCounterSS;
        public int statusProtectCounterRF;
        public int statusProtectCounterSW;
        public bool DamageProtected = false;
        public int damageProtectCounter;
        public bool isPoisoned = false;
        public bool isPoisonedTwo = false;
        public int poisonTracker = 0;
        public bool isAsleep = false;
        public bool isStunned = false;
        public bool itemTarget;
        public bool defensive = false;
        public int MoveChoice = 0;
        public int itemChoiceBattle;
        public string itemUserInput;
        public bool hasTakenTurn;
        public double tempDefense;

        public double playerMaxCharisma
        {
            get { return 5 + playerWeaponCharisma + playerShieldCharisma + Math.Round(playerLevel / 4); }
            set
            {
                if (playerMaxCharisma < 0)
                    playerMaxCharisma = 0;
            }
        }

        public double playerMaxHit
        {
            get { return 55 + playerWeaponHit + playerShieldHit + Math.Round(playerLevel / 2); }
            set
            {
                if (playerMaxHit < 0)
                    playerMaxHit = 0;
                if (playerMaxHit > 100)
                    playerMaxHit = 100;
            }
        }

        public double playerMaxHP //currently does not increase with level-up
        {
            get { return 25 + playerWeaponHP + playerShieldHP + Math.Round(playerLevel / 2); } //10 is base hp..
            set
            {
                if (playerMaxHP < 0)
                    playerMaxHP = 0;
            }
        }

        public double playerCurrentHP = 25;

        public double playerMaxStrength
        {
            get { return 8 + playerWeaponStrength + Math.Round(playerLevel / 2); }
            set
            {
                if (playerMaxStrength < 0)
                    playerMaxStrength = 0;
            }
        }

        public double playerMaxDefense
        {
            get { return 10 + playerArmourDef + playerShieldDefense + Math.Round(playerLevel / 2); }
            set
            {
                if (playerMaxDefense < 0)
                    playerMaxDefense = 0;
            }
        }

        public double playerMaxSpeed
        {
            get { return 8 + playerArmourSpeed + playerWeaponSpeed + playerShieldSpeed + Math.Round(playerLevel / 2); }
            set
            {
                if (playerMaxSpeed < 0)
                    playerMaxSpeed = 0;
            }
        }
    } 
}
