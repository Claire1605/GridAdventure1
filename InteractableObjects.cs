using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GridAdventure1
{
    [JsonObject]
    public class InteractableObjects
    {      
        public bool NPC;
        public string NPCname;
        public string message;
        public virtual void Use() {}
        
    }
//Quest-related objects
    public class Waterfall : InteractableObjects
    {
        PlayGame game;

        public Waterfall(PlayGame game)
        {
            this.game = game;
        }

        public override void Use()
        {
           if (game.WaterfallQuestBranch1 == false)
           {
               Console.WriteLine("You place the branch carefully at the top of the waterfall. \nA little of the water diverts to the west, weakening the flow of water to the south.\nThe flow still looks too strong to cross though.");
               Thread.Sleep(800);
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               game.inventory.dictionary["large branch"] = game.currentCount - 1;
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               if (game.currentCount == 0)
                   game.inventory.dictionary.Remove("large branch");
               game.WaterfallQuestBranch1 = true;
           }
           else if (game.WaterfallQuestBranch1 == true && game.WaterfallQuestBranch2 == false)
           {
               Console.WriteLine("You place the branch carefully at the top of the waterfall. \nAround half of the water diverts to the west, weakening the flow of water to the south. Maybe one more branch would do it.");
               Thread.Sleep(800);
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               game.inventory.dictionary["large branch"] = game.currentCount - 1;
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               if (game.currentCount == 0)
                   game.inventory.dictionary.Remove("large branch");
               game.WaterfallQuestBranch2 = true;
           }
           else if (game.WaterfallQuestBranch2 == true && game.WaterfallQuestBranch3 == false)
           {
               Console.WriteLine("You place the branch carefully at the top of the waterfall. \nThe water completely diverts to the west, stopping the flow of water to the south.");
               Thread.Sleep(800);
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               game.inventory.dictionary["large branch"] = game.currentCount - 1;
               game.inventory.dictionary.TryGetValue("large branch", out game.currentCount);
               if (game.currentCount == 0)
                   game.inventory.dictionary.Remove("large branch");
               game.WaterfallQuestBranch3 = true;
               game.WorldMapCells[1][72].gridDescNumber = 2;
               game.WorldMapCells[3][0].gridDescNumber = 2;
               game.WorldMapCells[3][1].accessible = true;
               game.WorldMapCells[3][2].accessible = true;
               game.WorldMapCells[3][3].accessible = true;
           }
        }
    }

//Computers
    public class PersonalComputer : InteractableObjects
    {
        PlayGame game;
         public PersonalComputer(PlayGame game) { this.game = game; }
        public override void Use()
        {
            Console.ForegroundColor = game.foregroundColour;
            Console.WriteLine("Your computer is still showing the message you received");
            Thread.Sleep(800);
            Console.ForegroundColor = ConsoleColor.Green;
            message = "WELCOME, " + game.playerStats.name.ToUpper() + "\nFROM YOUR PREVIOUS WORK AND RESEARCH IT HAS BEEN MADE CLEAR YOU ARE READY TO ASSIST OUR RESIDENT BIO-SCIENTIST, DR.DIGBY, IN HIS \nUPCOMING WORK: PROJECT X.\n\n";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(1500);
            message = "PLEASE MAKE YOUR WAY TO THE LAB IN THE NORTH OF THE VILLAGE NOW FOR YOUR OFFICIAL BRIEF.\n";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(1000);
            message = "FOR NOW PLEASE ACCESS YOUR PORTABLE AI SYSTEM BY TYPING 'MENU' FOR ANY QUERIES.\nLOGGING OFF...\n";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(1500);
        }
    }

    public class Computer : InteractableObjects
    {
        PlayGame game; //Dependency Injection

        public Dictionary<string, int> getInvDictionary2()
       {
           return game.inventory.getInvDictionary();
       }

        public Inventory inv //this works, but maybe clean it up and give variables better names
        {
            get
            { return game.inventory; }
            set
            { game.inventory = inv; }
        }

        enum ComputerMenuState { MainMenu, Storage, Grafting, DNA, Exit }
        ComputerMenuState currentComputerMenuState = ComputerMenuState.MainMenu;

        enum ComputerStorageState { MainMenu, Check, Withdraw, Deposit, Exit }
        ComputerStorageState currentComputerStorageState = ComputerStorageState.MainMenu;

        enum ComputerGraftingState { MainMenu, Weapons, Meebas, Exit}
        ComputerGraftingState currentComputerGraftingState = ComputerGraftingState.MainMenu;

        //enum ComputerMusicState { MainMenu, Exit }
        //ComputerMusicState currentComputerMusicState = ComputerMusicState.MainMenu;

        enum ComputerDNAState { MainMenu, Dollogrid, Items, DNA, Exit }
        ComputerDNAState currentComputerDNAState = ComputerDNAState.MainMenu;
     
        public Computer(PlayGame game) { this.game = game; } //Dependency Injection

        public int item1InputInt;
        public string itemGraft1;
        public string itemGraft2;
        public string itemGraft1Element;
        public string itemGraft2Element;
        public string newitemElement;
        public int itemGraft1Level;
        public int itemGraft2Level;
        public int newitemLevel;
        public Item newItem;
        public int currentCount;
        public string message;
        
        public override void Use()
        {
            game.WriteLineText("You logged onto the computer");
            Thread.Sleep(800);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            message = "BOOTING COMP TTO V16.05 .";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Console.Beep(400, 200);
            Thread.Sleep(400); Console.Write(".");
            Console.Beep(600, 200);
            Thread.Sleep(500); Console.Write(".\n");
            Thread.Sleep(300);
            Console.Beep(800, 200);
            message = "READING DISK.";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(600); Console.Write("."); Thread.Sleep(500); Console.Write(".\n"); Thread.Sleep(400);
            DateTime myValue = DateTime.Now;
            message = "CURRENT DATE IS " + myValue.AddYears(1605).ToShortDateString() + "\n" + "CURRENT TIME IS " + myValue.ToShortTimeString();
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(400); Console.Write("."); Thread.Sleep(400); Console.Write("..\n"); Thread.Sleep(300);
            string timeOfDay = "";
            if (myValue.Hour < 12)
                timeOfDay = "MORNING";
            else if (myValue.Hour >= 12 && myValue.Hour < 18)
                timeOfDay = "AFTERNOON";
            else if (myValue.Hour >= 18)
                timeOfDay = "EVENING";
            Console.Beep(800, 200);
            message = "ELIZA SUCCESFULLY BOOTED \n";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            message = "GOOD " + timeOfDay + ", " + game.playerStats.name.ToUpper();
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(game.textSpeed);
            }
            Thread.Sleep(2000);
            currentComputerMenuState = ComputerMenuState.MainMenu;

            do
            {
                switch (currentComputerMenuState)
                {
                    case ComputerMenuState.MainMenu:
                        currentComputerGraftingState = ComputerGraftingState.MainMenu;
                        currentComputerDNAState = ComputerDNAState.MainMenu;
                        //currentComputerMusicState = ComputerMusicState.MainMenu;
                        Console.Clear();
                        message = "PLEASE CHOOSE FROM THE FOLLOWING OPTIONS: \n1: DIGITAL STORAGE \n2: GRAFTING \n3: DNA \n";
                         for (int i = 0; i < message.Length; i++)
                         {
                             Console.Write(message[i]);
                             Thread.Sleep(game.textSpeed);
                         }
                        Console.Write("> ");
                        string computerInput = Console.ReadLine().ToLower().Trim();
                        if (computerInput.Length > 80) //makes input max of 80 chars
                        {
                            double textlength = computerInput.Length;
                            for (int i = 80; i <= textlength; i += 80)
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 1;
                            }
                            computerInput = computerInput.Remove(80);
                        }
                        if (computerInput == "1" || computerInput == "digital storage".ToLower())
                            currentComputerMenuState = ComputerMenuState.Storage;
                        else if (computerInput == "2" || computerInput == "grafting".ToLower())
                            currentComputerMenuState = ComputerMenuState.Grafting;
                        else if (computerInput == "3" || computerInput == "dna".ToLower())
                            currentComputerMenuState = ComputerMenuState.DNA;
                        //else if (computerInput == "4" || computerInput == "music".ToLower())
                        //    currentComputerMenuState = ComputerMenuState.Music;
                        else if (computerInput == "exit")
                        {
                            message = "GOODBYE\n";
                            for (int i = 0; i < message.Length; i++)
                            {
                                Console.Write(message[i]);
                                Thread.Sleep(game.textSpeed);
                            }
                            Console.Beep(800, 200);
                            Console.Beep(600, 200);
                            Console.Beep(400, 200);
                            currentComputerMenuState = ComputerMenuState.Exit;
                            Console.ForegroundColor = game.foregroundColour;
                            Console.BackgroundColor = game.backgroundColour;
                        }
                        break;

                    case ComputerMenuState.Storage:
                        currentComputerMenuState = ComputerMenuState.MainMenu;
                        currentComputerStorageState = ComputerStorageState.MainMenu;
                        do
                        {
                            switch (currentComputerStorageState)
                            {
                                case ComputerStorageState.MainMenu:
                                    message = "WELCOME TO THE STORAGE CENTRE. WHAT WOULD YOU LIKE TO DO? \n1: CHECK STORAGE \n2: WITHDRAW ITEMS \n3: DEPOSIT ITEMS\n";
                                    for (int i = 0; i < message.Length; i++)
                                    {
                                        Console.Write(message[i]);
                                        Thread.Sleep(game.textSpeed);
                                    }
                                    Console.Write("> ");
                                    string computerSecondInput = Console.ReadLine().ToLower().Trim();
                                    if (computerSecondInput.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = computerSecondInput.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        computerSecondInput = computerSecondInput.Remove(80);
                                    }
                                    if (computerSecondInput == "1" || computerSecondInput == "check storage".ToLower())
                                        currentComputerStorageState = ComputerStorageState.Check;
                                    else if (computerSecondInput == "2" || computerSecondInput == "withdraw items".ToLower())
                                        currentComputerStorageState = ComputerStorageState.Withdraw;
                                    else if (computerSecondInput == "3" || computerSecondInput == "deposit items".ToLower())
                                        currentComputerStorageState = ComputerStorageState.Deposit;
                                    else if (computerSecondInput == "exit")
                                    {
                                        message = "RETURNING TO MAIN MENU...\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                        currentComputerStorageState = ComputerStorageState.Exit;
                                    }
                                    break;
                                case ComputerStorageState.Check:
                                    game.AccessComputerStorage();
                                    Console.WriteLine("");
                                    currentComputerStorageState = ComputerStorageState.MainMenu;
                                    Thread.Sleep(800);
                                    break;

                                case ComputerStorageState.Withdraw:
                                    if (game.ComputerStorage.Count == 0)
                                    {
                                        message = "THERE ARE NO ITEMS STORED HERE.\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        currentComputerStorageState = ComputerStorageState.MainMenu;
                                        Thread.Sleep(800);
                                        break;
                                    }
                                    else
                                    {
                                        message = "WHAT WOULD YOU LIKE TO WITHDRAW?\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        game.AccessComputerStorage();
                                        Console.Write("> ");
                                        string withdrawItem = Console.ReadLine().ToLower().Trim();
                                        if (withdrawItem.Length > 80) //makes input max of 80 chars
                                        {
                                            double textlength = withdrawItem.Length;
                                            for (int i = 80; i <= textlength; i += 80)
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                            withdrawItem = withdrawItem.Remove(80);
                                        }
                                        game.ComputerStorage.TryGetValue(withdrawItem, out game.currentCount);
                                        if (game.currentCount != 0 && game.ComputerStorage.ContainsKey(withdrawItem))
                                        {
                                            inv.dictionary[withdrawItem] = game.currentCount;
                                            game.ComputerStorage[withdrawItem] = 0;
                                            message = "YOU SUCCESSFULLY WITHDREW THE " + withdrawItem.ToUpper() + "\n";
                                            for (int i = 0; i < message.Length; i++)
                                            {
                                                Console.Write(message[i]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            Thread.Sleep(800);
                                            if (currentCount == 0)
                                                game.ComputerStorage.Remove(withdrawItem);
                                        }
                                        else if (withdrawItem == "exit")
                                        {
                                            message = "RETURNING TO STORAGE MENU...\n";
                                            for (int i = 0; i < message.Length; i++)
                                            {
                                                Console.Write(message[i]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            Thread.Sleep(800);
                                            currentComputerStorageState = ComputerStorageState.Exit;
                                        }
                                        else
                                        {
                                            message = "YOU DO NOT OWN THAT.\n";
                                            for (int i = 0; i < message.Length; i++)
                                            {
                                                Console.Write(message[i]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            Thread.Sleep(800);
                                        }
                                    }
                                    currentComputerStorageState = ComputerStorageState.MainMenu;
                                    break;

                                case ComputerStorageState.Deposit:
                                    if (inv.dictionary.Count == 0)
                                    {
                                        message = "YOU HAVE NO ITEMS TO DEPOSIT.\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        currentComputerStorageState = ComputerStorageState.MainMenu;
                                        Thread.Sleep(800);
                                        break;
                                    }
                                    message = "WHAT WOULD YOU LIKE TO DEPOSIT?\n";
                                    for (int i = 0; i < message.Length; i++)
                                    {
                                        Console.Write(message[i]);
                                        Thread.Sleep(game.textSpeed);
                                    }
                                    game.AccessInventoryComputer();
                                    Console.Write("> ");
                                    string depositItem = Console.ReadLine().ToLower().Trim();
                                    if (depositItem.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = depositItem.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        depositItem = depositItem.Remove(80);
                                    }
                                    inv.dictionary.TryGetValue(depositItem, out game.currentCount);
                                    if (game.currentCount != 0 && inv.dictionary.ContainsKey(depositItem))
                                    {
                                        game.ComputerStorage[depositItem] = game.currentCount;
                                        inv.dictionary[depositItem] = 0;
                                        message = "YOU SUCCESSFULLY DEPOSITED THE " + depositItem.ToUpper()  + "\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                        if (currentCount == 0)
                                            inv.dictionary.Remove(depositItem);
                                    }
                                    else if (depositItem == "exit")
                                    {
                                        message = "RETURNING TO STORAGE MENU...\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        currentComputerStorageState = ComputerStorageState.Exit;
                                    }
                                    else
                                    {
                                        message = "YOU DO NOT OWN THAT.\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                    }
                                    currentComputerStorageState = ComputerStorageState.MainMenu;
                                    break;

                                case ComputerStorageState.Exit:
                                    currentComputerStorageState = ComputerStorageState.Exit;
                                    break;
                            }
                        } while (currentComputerStorageState != ComputerStorageState.Exit);
                        break;

                    case ComputerMenuState.Grafting:
                        currentComputerMenuState = ComputerMenuState.MainMenu;
                        if (currentComputerGraftingState == ComputerGraftingState.Exit)
                            break;
                        do
                        {
                            switch (currentComputerGraftingState)
                            {
                                case ComputerGraftingState.MainMenu:
                                    Console.Clear();
                                    message = "WELCOME TO THE GRAFTING STATION. WHICH ITEMS WOULD YOU LIKE TO COMBINE? \n1: WEAPONS\n2: OTHER\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                    Thread.Sleep(800);
                                    Console.Write("> ");
                                    string graftingInput = Console.ReadLine().ToLower().Trim();
                                    if (graftingInput.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = graftingInput.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        graftingInput = graftingInput.Remove(80);
                                    }
                                    if (graftingInput == "exit")
                                    {
                                        message = "RETURNING TO MAIN MENU...\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                        currentComputerGraftingState = ComputerGraftingState.Exit;
                                        break;
                                    }
                                    if (graftingInput == "1" || graftingInput == "weapons".ToLower())
                                    {
                                        currentComputerGraftingState = ComputerGraftingState.Weapons;
                                        break;
                                    }
                                    else if (graftingInput == "2" || graftingInput == "other".ToLower())
                                    {
                                        currentComputerGraftingState = ComputerGraftingState.Meebas;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        currentComputerDNAState = ComputerDNAState.MainMenu;
                                    }
                                    break;

                                case ComputerGraftingState.Weapons:
                                    Console.Clear();
                                    message = "WHICH WEAPON WOULD YOU LIKE TO GRAFT?\n";
                                        for (int i = 0; i < message.Length; i++)
                                        {
                                            Console.Write(message[i]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                   
                                    List<string> currentWeaponKeys = new List<string>();
                                    currentWeaponKeys.Clear();
                                    foreach (KeyValuePair<string, int> item in inv.dictionary)
                                    {
                                        game.itemChoice = item.Key;
                                        game.referenceCurrentItem();
                                        if (game.examItem.itemType == "weapon" || game.examItem.itemType == "armour")
                                        {
                                            currentWeaponKeys.Add(item.Key);
                                        }
                                    }
                                    for (int i = 0; i < currentWeaponKeys.Count; i++)
                                    {
                                        game.itemChoice = currentWeaponKeys[i];
                                        game.referenceCurrentItem();
                                        message = (i + 1) + ": " + currentWeaponKeys[i].ToUpper() + "[" + game.examItem.weaponelementName.ToUpper() + game.examItem.itemName.ToUpper() + " OF " + game.examItem.weaponstatName.ToUpper() + "]\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                    }
                                    bool validWeaponGraftChoice = false;
                                    do
                                    {
                                        Console.Write("> ");
                                        string weaponGraftChoice = Console.ReadLine().ToLower().Trim();
                                        if (weaponGraftChoice.Length > 80) //makes input max of 80 chars
                                        {
                                            double textlength = weaponGraftChoice.Length;
                                            for (int i = 80; i <= textlength; i += 80)
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                            weaponGraftChoice = weaponGraftChoice.Remove(80);
                                        }
                                        if (weaponGraftChoice == "exit")
                                        {
                                            message = "RETURNING TO MAIN MENU...\n";
                                            for (int i = 0; i < message.Length; i++)
                                            {
                                                Console.Write(message[i]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            Thread.Sleep(800);
                                            currentComputerGraftingState = ComputerGraftingState.Exit;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (string.IsNullOrEmpty(weaponGraftChoice) || weaponGraftChoice != "1" && weaponGraftChoice != "2" && weaponGraftChoice != "3" && weaponGraftChoice != "4" && weaponGraftChoice != "5" && weaponGraftChoice != "6" && weaponGraftChoice != "7" && weaponGraftChoice != "8" && weaponGraftChoice != "9" && weaponGraftChoice != "10" && weaponGraftChoice != "11" && weaponGraftChoice != "12" && weaponGraftChoice != "13" && weaponGraftChoice != "14" && weaponGraftChoice != "15" && weaponGraftChoice != "16" && weaponGraftChoice != "17" && weaponGraftChoice != "18" && weaponGraftChoice != "19" && weaponGraftChoice != "20" || Convert.ToInt16(weaponGraftChoice) > currentWeaponKeys.Count)
                                        {
                                            Console.Clear();
                                            message = "WHICH WEAPON WOULD YOU LIKE TO GRAFT?\n";
                                            for (int i = 0; i < message.Length; i++)
                                            {
                                                Console.Write(message[i]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            for (int i = 0; i < currentWeaponKeys.Count; i++)
                                            {
                                                game.itemChoice = currentWeaponKeys[i];
                                                game.referenceCurrentItem();
                                                message = (i + 1) + ": " + currentWeaponKeys[i].ToUpper() + "[" + game.examItem.weaponelementName.ToUpper() + game.examItem.itemName.ToUpper() + " OF " + game.examItem.weaponstatName.ToUpper() + "]\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                            }
                                        }   
                                        else
                                        {
                                            int weaponChoiceInt = Convert.ToInt16(weaponGraftChoice);

                                            for (int i = 1; i < (currentWeaponKeys.Count+1); i++)
                                            {
                                                if (weaponChoiceInt == i)
                                                {
                                                    game.itemChoice = currentWeaponKeys[i-1];
                                                    game.referenceCurrentItem();
                                                    message = "YOU CHOSE THE " + game.examItem.itemName.ToUpper() + "\n";
                                                    for (int j = 0; j < message.Length; j++)
                                                    {
                                                        Console.Write(message[j]);
                                                        Thread.Sleep(game.textSpeed);
                                                    }
                                                    Thread.Sleep(1000);
                                                    game.currentGraftWeapon = game.examItem.itemName;
                                                    validWeaponGraftChoice = true;
                                                }
                                            }  
                                        }
                                    } while (validWeaponGraftChoice == false && currentComputerGraftingState != ComputerGraftingState.Exit);
                                    if (currentComputerGraftingState == ComputerGraftingState.Exit)
                                        break;
                                    Console.Clear();
                                    message = "WHAT WOULD YOU LIKE TO GRAFT WITH THE " + game.examItem.itemName.ToUpper() + "\n";
                                     for (int j = 0; j < message.Length; j++)
                                     {
                                         Console.Write(message[j]);
                                         Thread.Sleep(game.textSpeed);
                                     }
                                    List<string> dnaItems = new List<string>();
                                    List<int> dnaItemValues = new List<int>();
                                    dnaItems.Clear();
                                    dnaItemValues.Clear();
                                    foreach (KeyValuePair<string, int> item in game.ComputerDNAItemStorage)
                                    {
                                        if (item.Value != 0)
                                        {
                                            dnaItemValues.Add(item.Value);
                                            dnaItems.Add(item.Key);
                                        }
                                    }
                                    for (int i = 0; i < dnaItems.Count; i++)
                                    {
                                        message = (i + 1) + ": " + dnaItems[i].ToUpper() + " (" + dnaItemValues[i] + ")\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                    }
                                    bool validWeaponGraftChoice2 = false;

                                    do
                                    {
                                        Console.Write("> ");
                                        string weaponGraftChoice2 = Console.ReadLine().ToLower().Trim();
                                        if (weaponGraftChoice2.Length > 80) //makes input max of 80 chars
                                        {
                                            double textlength = weaponGraftChoice2.Length;
                                            for (int i = 80; i <= textlength; i += 80)
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                            weaponGraftChoice2 = weaponGraftChoice2.Remove(80);
                                        }
                                        if (weaponGraftChoice2 == "exit")
                                        {
                                            message = "RETURNING TO MAIN MENU...\n";
                                            for (int j = 0; j < message.Length; j++)
                                            {
                                                Console.Write(message[j]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            Thread.Sleep(800);
                                            currentComputerGraftingState = ComputerGraftingState.Exit;
                                            Console.Clear();
                                            break;
                                        }
                                        else if (string.IsNullOrEmpty(weaponGraftChoice2) || weaponGraftChoice2 != "1" && weaponGraftChoice2 != "2" && weaponGraftChoice2 != "3" && weaponGraftChoice2 != "4" && weaponGraftChoice2 != "5" && weaponGraftChoice2 != "6" && weaponGraftChoice2 != "7" && weaponGraftChoice2 != "8" && weaponGraftChoice2 != "9" && weaponGraftChoice2 != "10" && weaponGraftChoice2 != "11" && weaponGraftChoice2 != "12" && weaponGraftChoice2 != "13" && weaponGraftChoice2 != "14" && weaponGraftChoice2 != "15" && weaponGraftChoice2 != "16" && weaponGraftChoice2 != "17" && weaponGraftChoice2 != "18" && weaponGraftChoice2 != "19" && weaponGraftChoice2 != "20" || Convert.ToInt16(weaponGraftChoice2) > currentWeaponKeys.Count)
                                        {
                                            Console.Clear();
                                            message = "WHAT WOULD YOU LIKE TO GRAFT WITH THE " + game.examItem.itemName.ToUpper() + "\n";
                                            for (int j = 0; j < message.Length; j++)
                                            {
                                                Console.Write(message[j]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            for (int i = 0; i < dnaItems.Count; i++)
                                            {
                                                message = (i + 1) + ": " + dnaItems[i].ToUpper() + " (" + dnaItemValues[i] + ")\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int weaponChoiceInt2 = Convert.ToInt16(weaponGraftChoice2);

                                            for (int i = 1; i < (dnaItems.Count + 1); i++)
                                            {
                                                if (weaponChoiceInt2 == i)
                                                {
                                                    game.itemChoice = dnaItems[i - 1];
                                                    game.referenceCurrentItem();
                                                    message = "YOU CHOSE THE " + game.examItem.itemName.ToUpper() + "\n";
                                                    for (int j = 0; j < message.Length; j++)
                                                    {
                                                        Console.Write(message[j]);
                                                        Thread.Sleep(game.textSpeed);
                                                    }
                                                    Thread.Sleep(1000);
                                                    game.currentGraftWeaponItem = game.examItem.itemName;
                                                    validWeaponGraftChoice2 = true;
                                                    game.ComputerDNAItemStorage.TryGetValue(game.examItem.itemName, out currentCount);
                                                    game.ComputerDNAItemStorage[game.examItem.itemName] = currentCount - 1;
                                                    game.ComputerDNAItemStorage.TryGetValue(game.examItem.itemName, out currentCount); //removes any 0 value items
                                                    if (currentCount == 0)
                                                        game.ComputerDNAItemStorage.Remove(game.examItem.itemName);
                                                }
                                            }
                                        }
                                    } while (validWeaponGraftChoice2 == false);
                                    if (currentComputerGraftingState == ComputerGraftingState.Exit)
                                        break;
                                    game.WeaponArmourGrafting(); //assigns new properties
                                    break;

                                case ComputerGraftingState.Meebas:
                                    bool validItem1 = false;
                                    bool validItem2 = false;
                                    bool validCombination = false;
                                    List<string> dropItemGrafting = new List<string>();
                                    List<int> dropItemGraftingValues = new List<int>();
                                    dropItemGrafting.Clear();
                                    do
                                    {
                                        foreach (var invItem in inv.dictionary)
                                        {
                                            game.itemChoice = invItem.Key.ToLower(); ;
                                            game.referenceCurrentItem();
                                            if (game.examItem.itemType == "dropItem")
                                            {
                                                dropItemGrafting.Add(game.examItem.itemName);
                                                dropItemGraftingValues.Add(invItem.Value);
                                            }
                                        }
                                        message = "PLEASE CHOOSE FIRST ITEM:\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        for (int i = 0; i < dropItemGrafting.Count; i++)
                                        {
                                            message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + dropItemGraftingValues[i] + ")\n";
                                            for (int j = 0; j < message.Length; j++)
                                            {
                                                Console.Write(message[j]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                        }
                                        do
                                        {
                                            Console.Write("> ");
                                            string item1Input = Console.ReadLine().ToLower().Trim();
                                            if (item1Input.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = item1Input.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                item1Input = item1Input.Remove(80);
                                            }
                                            if (item1Input == "exit")
                                            {
                                                message = "RETURNING TO MAIN MENU...\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                Thread.Sleep(800);
                                                currentComputerGraftingState = ComputerGraftingState.Exit;
                                                Console.Clear();
                                                break;
                                            }
                                            if (string.IsNullOrEmpty(item1Input) || item1Input != "1" && item1Input != "2" && item1Input != "3" && item1Input != "4" && item1Input != "5" && item1Input != "6" && item1Input != "7" && item1Input != "8" && item1Input != "9" && item1Input != "10" && item1Input != "11" && item1Input != "12" && item1Input != "13" && item1Input != "14" && item1Input != "15" && item1Input != "16" && item1Input != "17" && item1Input != "18" && item1Input != "19" && item1Input != "20"
                                                || Convert.ToInt32(item1Input) > dropItemGrafting.Count)
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= (2 + dropItemGrafting.Count);
                                                message = "PLEASE CHOOSE FIRST ITEM:\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                for (int i = 0; i < dropItemGrafting.Count; i++)
                                                {
                                                    if (dropItemGraftingValues[i] > 0)
                                                    {
                                                        message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + dropItemGraftingValues[i] + ")\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                item1InputInt = Convert.ToInt32(item1Input);
                                                message = "YOU CHOSE THE " + dropItemGrafting[item1InputInt - 1].ToUpper() + "\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                Thread.Sleep(1000);
                                                itemGraft1 = dropItemGrafting[item1InputInt - 1];
                                                validItem1 = true;
                                            }
                                        } while (validItem1 == false);
                                        do
                                        {
                                            if (currentComputerGraftingState == ComputerGraftingState.Exit)
                                                break;
                                            Console.Clear();
                                            message = "PLEASE CHOOSE SECOND ITEM:\n";
                                            for (int j = 0; j < message.Length; j++)
                                            {
                                                Console.Write(message[j]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            for (int i = 0; i < dropItemGrafting.Count; i++)
                                            {
                                                if (dropItemGrafting[i] == itemGraft1)
                                                    if (dropItemGraftingValues[i] > 1)
                                                    {
                                                        message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + (dropItemGraftingValues[i] - 1) + ")\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (0)\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                    }
                                                else if (dropItemGraftingValues[i] > 0)
                                                {
                                                    message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + dropItemGraftingValues[i] + ")\n";
                                                    for (int j = 0; j < message.Length; j++)
                                                    {
                                                        Console.Write(message[j]);
                                                        Thread.Sleep(game.textSpeed);
                                                    }
                                                }
                                            }
                                            Console.Write("> ");
                                            string item2Input = Console.ReadLine().ToLower().Trim();
                                            if (item2Input.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = item2Input.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                item2Input = item2Input.Remove(80);
                                            }
                                            if (item2Input == "exit")
                                            {
                                                message = "RETURNING TO MAIN MENU...\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                Thread.Sleep(800);
                                                currentComputerGraftingState = ComputerGraftingState.Exit;
                                                Console.Clear();
                                                break;
                                            }
                                            if (string.IsNullOrEmpty(item2Input) || item2Input != "1" && item2Input != "2" && item2Input != "3" && item2Input != "4" && item2Input != "5" && item2Input != "6" && item2Input != "7" && item2Input != "8" && item2Input != "9" && item2Input != "10" && item2Input != "11" && item2Input != "12" && item2Input != "13" && item2Input != "14" && item2Input != "15" && item2Input != "16" && item2Input != "17" && item2Input != "18" && item2Input != "19" && item2Input != "20"
                                                || Convert.ToInt32(item2Input) > dropItemGrafting.Count || Convert.ToInt32(item2Input) == item1InputInt && dropItemGraftingValues[item1InputInt - 1] < 2)
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= (2 + dropItemGrafting.Count);
                                                message = "PLEASE CHOOSE SECOND ITEM:\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                for (int i = 0; i < dropItemGrafting.Count; i++)
                                                {
                                                    if (dropItemGrafting[i] == itemGraft1)
                                                        if (dropItemGraftingValues[i] > 1)
                                                        {
                                                            message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + (dropItemGraftingValues[i] - 1) + ")\n";
                                                            for (int j = 0; j < message.Length; j++)
                                                            {
                                                                Console.Write(message[j]);
                                                                Thread.Sleep(game.textSpeed);
                                                            }
                                                        }
                                                        else
                                                        {
                                                             message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (0)\n";
                                                            for (int j = 0; j < message.Length; j++)
                                                            {
                                                                Console.Write(message[j]);
                                                                Thread.Sleep(game.textSpeed);
                                                            }
                                                        }
                                                    else if (dropItemGraftingValues[i] > 0)
                                                    {
                                                        message = (i + 1) + ": " + dropItemGrafting[i].ToUpper() + " (" + dropItemGraftingValues[i]+ ")\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                int item2InputInt = Convert.ToInt32(item2Input);
                                                message = "YOU CHOSE THE " + dropItemGrafting[item2InputInt - 1].ToUpper() + "\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                Thread.Sleep(1000);
                                                itemGraft2 = dropItemGrafting[item2InputInt - 1];
                                                validItem2 = true;
                                            }
                                        } while (validItem2 == false);
                                        if (currentComputerGraftingState == ComputerGraftingState.Exit)
                                            break;
                                        message = "GRAFTING " + itemGraft1.ToUpper() + " TO " + itemGraft2.ToUpper() + "\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(1000);
                                        validCombination = true;
                                    } while (validCombination == false);
                                    if (currentComputerGraftingState == ComputerGraftingState.Exit)
                                        break;
                                    //REMOVE THOSE ITEMS FROM INVENTORY
                                    inv.dictionary.TryGetValue(itemGraft1, out currentCount);
                                    inv.dictionary[itemGraft1] = currentCount - 1;
                                    inv.dictionary.TryGetValue(itemGraft1, out currentCount);
                                    if (currentCount == 0)
                                        inv.dictionary.Remove(itemGraft1);

                                    inv.dictionary.TryGetValue(itemGraft2, out currentCount);
                                    inv.dictionary[itemGraft2] = currentCount - 1;
                                    inv.dictionary.TryGetValue(itemGraft2, out currentCount);
                                    if (currentCount == 0)
                                        inv.dictionary.Remove(itemGraft2);

                                    game.itemChoice = itemGraft1;
                                    game.referenceCurrentItem();
                                    itemGraft1Element = game.examItem.elementType;
                                    itemGraft1Level = game.examItem.dropItemLevel;

                                    game.itemChoice = itemGraft2;
                                    game.referenceCurrentItem();
                                    itemGraft2Element = game.examItem.elementType;
                                    itemGraft2Level = game.examItem.dropItemLevel;

                                    ItemComboElement();
                                    ItemComboLevel();

                                    List<Item> RootItems = new List<Item>()
                            {
                            new TinderRoot(), new SmokeRoot(), new FlameRoot(), new InfernoRoot(), new SproutRoot(), new GrassRoot(), new VineRoot(), new ForestRoot(), new SoilRoot(), new BoulderRoot(), new TerraRoot(), new MountRoot(), new BreezeRoot(), new WindRoot(), new SkyRoot(), new AtmosRoot(), new DropRoot(), new PondRoot(), new LakeRoot(), new OceanRoot(), new CinderRoot(), new EmberRoot(), new CharredRoot(), new AshRoot(), new AlgaeRoot(), new LichenRoot(), new BogRoot(), new SwampRoot(), new SandRoot(), new LoessRoot(), new DuneRoot(), new DesertRoot(), new CloudRoot(), new HailRoot(), new ThunderRoot(), new LightningRoot(), new EvapoRoot(), new VapourRoot(), new VentRoot(), new GeyserRoot()
                            };

                                    foreach (var item in RootItems)
                                    {
                                        if (item.elementType.ToLower() == newitemElement.ToLower() && item.dropItemLevel == newitemLevel)
                                        {
                                            newItem = item;
                                        }
                                    }
                                    message = "YOU CREATED ONE " + newItem.itemName.ToUpper() + "\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                    Thread.Sleep(800);
                                    game.ComputerDNAItemStorage.TryGetValue(newItem.itemName, out currentCount);
                                    game.ComputerDNAItemStorage[newItem.itemName] = currentCount + 1;
                                    message = "YOU SUCCESSFULLY DEPOSITED THE " + newItem.itemName.ToUpper() + " TO THE DNA STORAGE" + "\n";
                                      for (int j = 0; j < message.Length; j++)
                                      {
                                          Console.Write(message[j]);
                                          Thread.Sleep(game.textSpeed);
                                      }
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    currentComputerMenuState = ComputerMenuState.MainMenu;
                                    break;

                                case ComputerGraftingState.Exit:
                                    currentComputerGraftingState = ComputerGraftingState.Exit;
                                    break;
                            }
                        }
                        while (currentComputerGraftingState != ComputerGraftingState.Exit);
                        break; 

                    case ComputerMenuState.DNA:
                        Console.Clear();
                        do
                        {
                        switch (currentComputerDNAState)
                        {
                            case ComputerDNAState.MainMenu:
                                message = "WELCOME TO THE DNA SEQUENCING AND SPLICING STATION. \nWHAT WOULD YOU LIKE TO DO? \n1: VIEW DOLLOGRID \n2: VIEW ITEMS \n3: SPLICE\n";
                                for (int j = 0; j < message.Length; j++)
                                {
                                    Console.Write(message[j]);
                                    Thread.Sleep(game.textSpeed);
                                }
                                    Console.Write("> ");
                                    string dnaInput = Console.ReadLine().ToLower().Trim();
                                    if (dnaInput.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = dnaInput.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        dnaInput = dnaInput.Remove(80);
                                    }
                                    if (dnaInput == "exit")
                                {
                                    message = "RETURNING TO MAIN MENU...\n";
                                    for (int j = 0; j < message.Length; j++)
                                    {
                                        Console.Write(message[j]);
                                        Thread.Sleep(game.textSpeed);
                                    }
                                    Thread.Sleep(800);
                                    currentComputerDNAState = ComputerDNAState.Exit;
                                    break;
                                }
                                if (dnaInput == "1" || dnaInput == "view dollogrid".ToLower() || dnaInput == "dollogrid".ToLower())
                                {
                                    currentComputerDNAState = ComputerDNAState.Dollogrid;
                                }
                                else if (dnaInput == "2" || dnaInput == "view items".ToLower() || dnaInput == "items".ToLower())
                                {
                                    currentComputerDNAState = ComputerDNAState.Items;
                                }
                                else if (dnaInput == "3" || dnaInput == "splice".ToLower())
                                {
                                    currentComputerDNAState = ComputerDNAState.DNA;
                                }
                                else
                                {
                                    Console.Clear();
                                    currentComputerDNAState = ComputerDNAState.MainMenu;
                                }
                                break;
                            case ComputerDNAState.Dollogrid:
                                //segment Meeba To Fire1 = array [4,5], [3, 5], [2, 5] etc.
                                string[,] dollogrid = new string[38, 60]
                                        { {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "C"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", "_", ",", ".", "-", "-", "'", "'", "O","'", "'", "-", "-", ".", ".", "_", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "'", "'", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", "'", " ", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "#", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", "#", " ", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "F", " ", ".", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", ".", " ", "P", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "O", " ", " ", " ", " ", " ", " ", " ", " ", " ", "_", " ", ".", ".", "-", "-", "'", "'", "|","'", "'", "-", "-", ".", ".", " ", "_", " ", " ", " ", " ", " ", " ", " ", " ", " ", "O", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "'", " ", " ", @"\"," ", " ", " ", " ", ".", ";", " ", "'", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", "'", ";", " ", ".", " ", " ", " ", " ", "/", " ", " ", "'", ".", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", @"\"," ", ".", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", ".", " ", "/", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", "'", " ", " ", " ", " ", " ", " ", ".", "'", " ", @"\"," ", " ", " ", " ", " ", " ", " ", "_", "_", "_", "-", "-", "-", "O","-", "-", "-", "_", "_", "_", " ", " ", " ", " ", " ", " ", " ", "/", " ", "'", ".", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", "'", " ", " ", " ", " ", " ", ".", "'", " ", " ", " ", " ", " ",@"\", " ", " ", ".", "-", "'", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", "'", "-", ".", " ", " ", "/", " ", " ", " ", " ", " ", "'", ".", " ", " ", " ", " ", " ", ";", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", ";", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", "'", " ", " ", " ", " "},
                                          {" ", " ", " ", ";", " ", " ", " ", " ", " ", ",", " ", " ", " ", " ", " ", " ", " ", ".", "'", " ", " ",@"\", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", "'", ",", " ", " ", " ", " ", " ", " ", " ", ",", " ", " ", " ", " ", ";", " ", " ", " "},
                                          {" ", " ", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ",@"\", " ", " ", " ", "_", "_", "-", "-", "O","-", "-", "_", "_", " ", " ", " ", "/", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", " ", " ", " "},
                                          {" ", " ", ";", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "/", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", "'", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", ";", " ", " "},
                                          {"H", " ", "O", "_", "_", "_", "_", "O", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", " ", "'", " ",@"\", " ", " ", " ", " ", "|"," ", " ", " ", " ", "/", " ", "'", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "O", "_", "_", "_", "_", "O", " ", "M"},
                                          {" ", ",", " ", " ", " ", " ", " ", ":",@"\", "_", "_", "_", "_", "_", "O", "_", "_", "_", "_", "_", "_", " ", ";", " ", " ", " ", " ",@"\", " ", " ", "|"," ", " ", "/", " ", " ", " ", " ", ";", " ", "_", "_", "_", "_", "_", "O", "_", "_", "_", "_", "_", "/", ";", " ", " ", " ", " ", " ", ";", " "},
                                          {" ", ";", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", ":", " ", " ", " ", " ", " ", " ", "O", "_", "_", "_", "_", "_", " ",@"\", " ", "|"," ", "/", " ", "_", "_", "_", "_", "_", "O", " ", " ", " ", " ", " ", " ", ",", " ", " ", " ", " ", " ", " ", "'", " ", " ", " ", " ", "'", " "},
                                          {" ", ":", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ",@"\", " ",@"\", "|","/", " ", "/", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", ":", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", ",", " "},
                                          {" ", ".", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", "|", "_", "_", "_", "_", "_", "_", "-", "-", "o","-", "-", "_", "_", "_", "_", "_", "_", "|", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", ".", " "},
                                          {" ", ":", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", " ", " ", ":", "_", "_", "_", "_", "_", "_", "O", " ", " ", " ", " ", " ", " ", " ", "/", "|",@"\"," ", " ", " ", " ", " ", " ", " ", "O", "_", "_", "_", "_", "_", "_", ":", " ", " ", " ", " ", " ", " ", "|", " ", " ", " ", " ", "'", " "},
                                          {" ", ":", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", "/", " ", " ", "|"," ", " ",@"\", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", ":", " "},
                                          {" ", "'", " ", " ", " ", " ", " ", ":", "_", "_", "_", "_", "_", "/", "'", " ", " ", " ", " ", " ", " ", " ", " ", ";", " ", "/", " ", " ", " ", " ", "|"," ", " ", " ", " ",@"\", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", "'",@"\", "_", "_", "_", "_", "_", ":", " ", " ", " ", " ", "'", " "},
                                          {" ", " ", ";", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", "'", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", "/", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", ",", " "},
                                          {" ", " ", "'", "_", "_", "_", "/", " ", ";", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "/", " ", "'", " ", "-", ".", ",", "O",",", ".", "-", " ", "'", " ", " ",@"\", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", ";", " ",@"\", "_", "_", " ", "#", " "},
                                          {" ", "W", " ", "O", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", "/", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ",@"\", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", "O", " ", "E"},
                                          {" ", " ", " ", "'", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " ", " ", ",", " ", "/", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ",@"\", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", ";", " ", " ", " "},
                                          {" ", " ", " ", " ", "'", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "O", " ", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", ".", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", "'", " ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", "/", " ", " ", "*", " ", ".", ",", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", ",", ".", " ", "*", " ", " ", " ",@"\", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", "'", ".", " ", " ", "/", " ", " ", " ", " ", " ", " ", " ", " ", "'", "'", "-", "-", "|","-", "-", "'", "'", " ", " ", " ", " ", " ", " ", " ", " ",@"\", " ", " ", ".", "'", " ", " ", " ", " ", " ", ",", "'", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ",@"\", " ", " "," ", " ", " ", " ", "'", "O", " ", " ",  " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "O", "'", " ", " ", " ", " ", " ", " ", ".", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ";", " "," ", " ", " ", "/", " ", "'", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "'", " ",@"\", " ", " ", " ", " ", " ", ";", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'"," ", " ", "/", " ", " ", " ", "'", "*", ";", ".", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", ";", "'", " ", " ", " ", " ", " ",@"\", " ", " ", ".", "'", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", "'", "-", "-", ".", ",", "_", "|","_", "_", ".", ",", ".", "-", " ", "'", " ", " ", " ", " ", " ", " ", " ", " ", "O", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "S", " ", " ", "'", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", "'", " ", "D", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", "*", ";", ".", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", ".", ";", "*", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "'", "'", "-", "-", ".", ",", "_", "_", "O","_", "_", ".", ",", ".", "-", "-", "'", "'", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                                          {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "A"," ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
                                        };
                                Console.Clear();
                                for (int i = 0; i < 38; i++)
                                {
                                    for (int j = 0; j < 60; j++)
                                    {

                                        if (j == 0)
                                            Console.Write(Environment.NewLine);
                                        if (dollogrid[i, j] == "O" || dollogrid[i, j] == "o" || dollogrid[i, j] == "F" || dollogrid[i, j] == "P" || dollogrid[i, j] == "E" || dollogrid[i, j] == "A" || dollogrid[i, j] == "W" || dollogrid[i, j] == "C" || dollogrid[i, j] == "M" || dollogrid[i, j] == "D" || dollogrid[i, j] == "S" || dollogrid[i, j] == "H")
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(dollogrid[i, j]);
                                            Console.ResetColor();
                                        }
                                        //MeebaNeutral to Fire1 - if firetier1reached = true...
                                        else if (i == 18 && j == 30 || i == 17 && j == 30 || i == 16 && j == 30 || i == 15 && j == 30 || i == 14 && j == 30) //&& meeba1 has evolved to Fire1, separate colour for meeba2
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write(dollogrid[i, j]);
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write(dollogrid[i, j]);
                                            Console.ResetColor();
                                        }
                                    }
                                }
                                Console.Write(Environment.NewLine);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Thread.Sleep(1000);
                                currentComputerDNAState = ComputerDNAState.MainMenu;
                                break;
                            case ComputerDNAState.Items:
                                game.AccessComputerDNAItemStorage();
                                Thread.Sleep(1000);
                                currentComputerDNAState = ComputerDNAState.MainMenu;
                                break;
                            case ComputerDNAState.DNA:
                                if (game.ComputerDNAItemStorage.Count == 0)
                                {
                                    message = "YOU DO NOT HAVE ANYTHING TO SPLICE WITH\n";
                                    for (int j = 0; j < message.Length; j++)
                                    {
                                        Console.Write(message[j]);
                                        Thread.Sleep(game.textSpeed);
                                    }
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    currentComputerDNAState = ComputerDNAState.MainMenu;
                                    break;
                                }
                                if (!inv.dictionary.ContainsKey("ellondite"))
                                {
                                    message = "YOU DO NOT HAVE THE REQUIRED MATERIALS\n";
                                    for (int j = 0; j < message.Length; j++)
                                    {
                                        Console.Write(message[j]);
                                        Thread.Sleep(game.textSpeed);
                                    }
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    currentComputerDNAState = ComputerDNAState.MainMenu;
                                    break;
                                }
                                do
                                {
                                    if (game.meeba.gotMeeba == true && game.meeba2.gotMeeba == true)
                                    {
                                        message = "WHO WOULD YOU LIKE TO SEQUENCE? \n1: " + game.meeba.name.ToUpper() + "\n2: " + game.meeba2.name.ToUpper() + "\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        bool validChoice = false;
                                        do
                                        {
                                                Console.Write("> ");
                                                string dnaMeebaChoice = Console.ReadLine().ToLower().Trim();
                                                if (dnaMeebaChoice.Length > 80) //makes input max of 80 chars
                                                {
                                                    double textlength = dnaMeebaChoice.Length;
                                                    for (int i = 80; i <= textlength; i += 80)
                                                    {
                                                        Console.CursorTop -= 1;
                                                        Console.Write(new string(' ', Console.WindowWidth));
                                                        Console.CursorTop -= 1;
                                                    }
                                                    dnaMeebaChoice = dnaMeebaChoice.Remove(80);
                                                }
                                                if (dnaMeebaChoice == "exit")
                                            {
                                                message = "RETURNING TO MAIN MENU...\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                                Thread.Sleep(800);
                                                currentComputerDNAState = ComputerDNAState.Exit;
                                                break;
                                            }
                                            if (dnaMeebaChoice == "1" || dnaMeebaChoice == game.meeba.name.ToLower())
                                            {
                                                game.currentDNAMeeba = game.meeba;
                                                validChoice = true;
                                            }
                                            else if (dnaMeebaChoice == "2" || dnaMeebaChoice == game.meeba2.name.ToLower())
                                            {
                                                game.currentDNAMeeba = game.meeba2;
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 4;
                                            }

                                        } while (validChoice == false);
                                        if (currentComputerDNAState == ComputerDNAState.Exit)
                                            break;
                                        message = "SEQUENCING " + game.currentDNAMeeba.name.ToUpper() + "'S DNA...\nCURRENT ELEMENT: " + game.currentDNAMeeba.elementType.ToUpper() + "\nCURRENT LEVEL: " + game.currentDNAMeeba.levelTier + "\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                        message = "WHAT ITEM WOULD YOU LIKE TO SPLICE WITH " + game.currentDNAMeeba.name.ToUpper() + "?\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(800);
                                        List<string> dnaItems = new List<string>();
                                        List<int> dnaItemValues = new List<int>();
                                        dnaItems.Clear();
                                        dnaItemValues.Clear();
                                        foreach (KeyValuePair<string, int> item in game.ComputerDNAItemStorage)
                                        {
                                            if (item.Value != 0)
                                            {
                                                dnaItemValues.Add(item.Value);
                                                dnaItems.Add(item.Key);
                                            }
                                               
                                        }
                                        for (int i = 0; i < dnaItems.Count; i++)
                                        {
                                            if (dnaItemValues[i] != 0)
                                            {
                                                message = (i + 1) + ": " + dnaItems[i].ToUpper() + " (" + dnaItemValues[i] + ")\n";
                                                for (int j = 0; j < message.Length; j++)
                                                {
                                                    Console.Write(message[j]);
                                                    Thread.Sleep(game.textSpeed);
                                                }
                                            }   
                                        }
                                        Thread.Sleep(1000);
                                            Console.Write("> ");
                                            string dnaItemChoice = Console.ReadLine().ToLower().Trim();
                                            if (dnaItemChoice.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = dnaItemChoice.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                dnaItemChoice = dnaItemChoice.Remove(80);
                                            }
                                            if (string.IsNullOrEmpty(dnaItemChoice) || dnaItemChoice != "1" && dnaItemChoice != "2" && dnaItemChoice != "3" && dnaItemChoice != "4" && dnaItemChoice != "5" && dnaItemChoice != "6" && dnaItemChoice != "7" && dnaItemChoice != "8" && dnaItemChoice != "9" && dnaItemChoice != "10" && dnaItemChoice != "11" && dnaItemChoice != "12" && dnaItemChoice != "13" && dnaItemChoice != "14" && dnaItemChoice != "15" && dnaItemChoice != "16" && dnaItemChoice != "17" && dnaItemChoice != "18" && dnaItemChoice != "19" && dnaItemChoice != "20" && dnaItemChoice != "21" && dnaItemChoice != "22" && dnaItemChoice != "23" && dnaItemChoice != "24" && dnaItemChoice != "25" && dnaItemChoice != "26" && dnaItemChoice != "27" && dnaItemChoice != "28" && dnaItemChoice != "29" && dnaItemChoice != "30" && dnaItemChoice != "31" && dnaItemChoice != "32" && dnaItemChoice != "33" && dnaItemChoice != "34" && dnaItemChoice != "35" && dnaItemChoice != "36" && dnaItemChoice != "37" && dnaItemChoice != "38" && dnaItemChoice != "39" && dnaItemChoice != "40" || Convert.ToInt32(dnaItemChoice) > game.ComputerDNAItemStorage.Count)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            for (int i = 1; i < (game.ComputerDNAItemStorage.Count + 1); i++)
                                            {
                                                if (game.ComputerDNAItemStorage.Count == i)
                                                    Console.CursorTop -= (i + 2);
                                            }
                                            message = "WHAT ITEM WOULD YOU LIKE TO SPLICE WITH " + game.currentDNAMeeba.name.ToUpper() + "?\n";
                                            for (int j = 0; j < message.Length; j++)
                                            {
                                                Console.Write(message[j]);
                                                Thread.Sleep(game.textSpeed);
                                            }
                                            for (int i = 0; i < dnaItems.Count; i++)
                                            {
                                                if (dnaItemValues[i] != 0)
                                                {
                                                    message = (i + 1) + ": " + dnaItems[i].ToUpper() + " (" + dnaItemValues[i] + ")\n";
                                                    for (int j = 0; j < message.Length; j++)
                                                    {
                                                        Console.Write(message[j]);
                                                        Thread.Sleep(game.textSpeed);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int dnaItemChoiceInt = Convert.ToInt32(dnaItemChoice);
                                            for (int i = 1; i < (game.ComputerDNAItemStorage.Count + 1); i++)
                                            {
                                                if (dnaItemChoiceInt == i)
                                                {
                                                    game.meebaEvolved = false;
                                                    game.itemChoice = dnaItems[dnaItemChoiceInt - 1];
                                                    game.referenceCurrentItem();
                                                    game.MeebaEvolution();
                                                    game.EvolutionSprites();
                                                    if (game.meebaEvolved == true)
                                                    {
                                                        game.ComputerDNAItemStorage[game.itemChoice] -= 1;
                                                        if (game.ComputerDNAItemStorage[game.itemChoice] == 0)
                                                            game.ComputerDNAItemStorage.Remove(game.itemChoice);
                                                        inv.dictionary["ellondite"] -= 1;
                                                        if (inv.dictionary["ellondite"] == 0)
                                                            inv.dictionary.Remove("ellondite");
                                                        message = "THE ELLONDITE CATALYSED THE SYNTHESIS WITH " + game.examItem.itemName.ToUpper() + "\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                        Thread.Sleep(1000);
                                                        message = game.currentDNAMeeba.name.ToUpper() + " WAS CREATED\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                        Thread.Sleep(1500);
                                                        if (game.storyCounter == 3)
                                                        {
                                                            game.storyCounter = 4;
                                                        }
                                                        currentComputerDNAState = ComputerDNAState.Exit;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        message = "INCOMPATIBLE DNA\n";
                                                        for (int j = 0; j < message.Length; j++)
                                                        {
                                                            Console.Write(message[j]);
                                                            Thread.Sleep(game.textSpeed);
                                                        }
                                                    }
                                                    break;
                                                }
                                                //else
                                                //{
                                                //    for (int j = 1; j < (game.ComputerDNAItemStorage.Count + 1); j++)
                                                //    {
                                                //        if (game.ComputerDNAItemStorage.Count == j)
                                                //            Console.CursorTop -= (j + 2);
                                                //    }
                                                //    message = "WHAT ITEM WOULD YOU LIKE TO SPLICE WITH " + game.currentDNAMeeba.name.ToUpper() + "?\n";
                                                //    for (int j = 0; j < message.Length; j++)
                                                //    {
                                                //        Console.Write(message[j]);
                                                //        Thread.Sleep(game.textSpeed);
                                                //    }
                                                //    for (int k = 0; k < dnaItems.Count; k++)
                                                //    {
                                                //        if (dnaItemValues[k] != 0)
                                                //        {
                                                //            message = (k + 1) + ": " + dnaItems[k].ToUpper() + " (" + dnaItemValues[k] + ")\n";
                                                //            for (int j = 0; j < message.Length; j++)
                                                //            {
                                                //                Console.Write(message[j]);
                                                //                Thread.Sleep(game.textSpeed);
                                                //            }
                                                //        }
                                                //    }
                                                //}
                                            }
                                        }
                                    }
                                    else
                                    {
                                        message = "THIS STATION IS NOT READY TO USE YET\n";
                                        for (int j = 0; j < message.Length; j++)
                                        {
                                            Console.Write(message[j]);
                                            Thread.Sleep(game.textSpeed);
                                        }
                                        Thread.Sleep(1000);
                                    }
                                } while (currentComputerDNAState != ComputerDNAState.Exit);
                                break;

                            case ComputerDNAState.Exit:
                                {
                                    Console.Clear();
                                    break;
                                }
                        }
                        } while (currentComputerDNAState != ComputerDNAState.Exit);

                        currentComputerMenuState = ComputerMenuState.MainMenu;
                        break;

                    //case ComputerMenuState.Music:
                    //    int beepFreq = 0;
                    //    int beepDur = 0;
                    //    string tempTrack;
                    //    string track1 = "";
                    //    string track2 = "2en4,2d#4,2en4,2d#4,2en4,1bn4,2dn4,2cn4,1an2,1cn4,1en4,1an4,1bn2,1en4,1an4,1bn4,2cn2,2en4,2d#4,2en4,2d#4,2en4,1bn4,2dn4,2cn4,1an2,1cn4,1en4,1an4,1bn2,1en4,2cn4,1bn4,1an2,1bn4,2cn4,2dn4,2en2,2gn4,2fn4,2en4,2dn2,2en4,2en4,2dn4,2cn2,2en4,2dn4,2cn4,1bn2";
                    //    string track3 = "1a#2,1fn1,1a#4,1a#8,2cn8,2dn8,2d#8,2fn1,2fn8,2fn4,2f#4,2g#4,2a#1,2a#8,2a#4,2g#4,2f#4,2g#4,2f#8,2fn1,2fn2,2d#4,2d#8,2fn4,2f#1,2fn4,2d#4,2c#4,2c#8,2d#4,2fn1,2d#4,2c#4,2cn4,2dn8,2en1,2gn2,2fn4,1fn8,1fn8,1fn4,1fn8,1fn8,1fn4,1fn4,1fn4";
                    //    string test = "2gn2,2en2,2cn2,1gn2,1an4,1bn4,2cn4,1an2,2cn4,1gn1,2dn2,2gn2,2en2,2cn2,1an4,1bn4,2cn4,2dn2,2en4,2dn1,2en4,2fn4,2en4,2dn4,2gn2,2en4,2dn4,2cn1,2dn4,2en2,2cn4,1an4,2cn4,1an4,1gn1,1gn4,2cn2,2en4,2dn2,1gn4,2cn2,2en4,2dn2,2en4,2fn4,2gn4,2en4,2cn4,2dn2,1gn4,2cn1";
                    //    string musicInput = "";

                    //     List<int> musicLengths = new List<int>();
                    //     List<int> musicNotes = new List<int>();

                    //     List<int> savedMusicLengths = new List<int>();
                    //     List<int> savedMusicNotes = new List<int>();
                    //    do
                    //    {
                    //        message = "Write the music to play!\n";
                    //        for (int j = 0; j < message.Length; j++)
                    //        {
                    //            Console.Write(message[j]);
                    //            Thread.Sleep(game.textSpeed);
                    //        }
                    //        Thread.Sleep(800);
                    //        tempTrack = musicInput;
                    //        Console.Write("> ");
                    //        musicInput = Console.ReadLine().ToLower().Trim();
                    //        if (musicInput == "exit".ToLower())
                    //        {
                    //            currentComputerMusicState = ComputerMusicState.Exit;
                    //            currentComputerMenuState = ComputerMenuState.MainMenu;
                    //            break;
                    //        }
                    //        if (musicInput == "track1".ToLower())
                    //            musicInput = track1;
                    //        if (musicInput == "track2".ToLower())
                    //            musicInput = track2;
                    //        if (musicInput == "track3".ToLower())
                    //            musicInput = track3;
                    //        if (musicInput == "test".ToLower())
                    //            musicInput = test;
                    //        if (musicInput == "save".ToLower())
                    //            track1 = tempTrack;
                    //        string musicSubStringLength = "";
                    //        string musicSubStringNote ="";
                    //        musicLengths.Clear();
                    //        musicNotes.Clear();
                    //        for (int i = 0; i < musicInput.Length; i+=5)
                    //        {
                    //            if (musicInput.Length < 4)
                    //            {
                    //                message = "MUSIC NOT IN CORRECT FORMAT\n";
                    //                for (int j = 0; j < message.Length; j++)
                    //                {
                    //                    Console.Write(message[j]);
                    //                    Thread.Sleep(game.textSpeed);
                    //                }
                    //                break;
                    //            }
                    //            musicSubStringLength = musicInput.Substring(i + 3, 1);
                    //            musicSubStringNote = musicInput.Substring(i, 3);
                    //            if (musicSubStringLength == "1")
                    //                beepDur = 1000; //semibreve
                    //            else if (musicSubStringLength == "2")
                    //                beepDur = 500; //minim
                    //            else if (musicSubStringLength == "4")
                    //                beepDur = 250; //crotchet
                    //            else if (musicSubStringLength == "8")
                    //                beepDur = 125; //quaver 
                    //            else if (musicInput != "save" && musicInput != "track1" && musicInput != "track2" && musicInput != "track3")
                    //            {
                    //                message = "MUSIC NOT IN CORRECT FORMAT\n";
                    //                for (int j = 0; j < message.Length; j++)
                    //                {
                    //                    Console.Write(message[j]);
                    //                    Thread.Sleep(game.textSpeed);
                    //                }
                    //                break;
                    //            }
                    //            if (musicSubStringNote == "1Cn".ToLower())
                    //                beepFreq = 262;
                    //            else if (musicSubStringNote == "1C#".ToLower())
                    //                beepFreq = 277;
                    //            else if (musicSubStringNote == "1Dn".ToLower())
                    //                beepFreq = 294;
                    //            else if (musicSubStringNote == "1D#".ToLower())
                    //                beepFreq = 311;
                    //            else if (musicSubStringNote == "1En".ToLower())
                    //                beepFreq = 330;
                    //            else if (musicSubStringNote == "1Fn".ToLower())
                    //                beepFreq = 349;
                    //            else if (musicSubStringNote == "1F#".ToLower())
                    //                beepFreq = 370;
                    //            else if (musicSubStringNote == "1Gn".ToLower())
                    //                beepFreq = 392;
                    //            else if (musicSubStringNote == "1G#".ToLower())
                    //                beepFreq = 415;
                    //            else if (musicSubStringNote == "1An".ToLower())
                    //                beepFreq = 440;
                    //            else if (musicSubStringNote == "1A#".ToLower())
                    //                beepFreq = 466;
                    //            else if (musicSubStringNote == "1Bn".ToLower())
                    //                beepFreq = 494;
                    //            else if (musicSubStringNote == "2Cn".ToLower())
                    //                beepFreq = 523;
                    //            else if (musicSubStringNote == "2C#".ToLower())
                    //                beepFreq = 554;
                    //            else if (musicSubStringNote == "2Dn".ToLower())
                    //                beepFreq = 587;
                    //            else if (musicSubStringNote == "2D#".ToLower())
                    //                beepFreq = 621;
                    //            else if (musicSubStringNote == "2En".ToLower())
                    //                beepFreq = 658;
                    //            else if (musicSubStringNote == "2Fn".ToLower())
                    //                beepFreq = 697;
                    //            else if (musicSubStringNote == "2F#".ToLower())
                    //                beepFreq = 738;
                    //            else if (musicSubStringNote == "2Gn".ToLower())
                    //                beepFreq = 782;
                    //            else if (musicSubStringNote == "2G#".ToLower())
                    //                beepFreq = 829;
                    //            else if (musicSubStringNote == "2An".ToLower())
                    //                beepFreq = 878;
                    //            else if (musicSubStringNote == "2A#".ToLower())
                    //                beepFreq = 930;
                    //            else if (musicSubStringNote == "2Bn".ToLower())
                    //                beepFreq = 985;
                    //            else
                    //            {
                    //                message = "MUSIC NOT IN CORRECT FORMAT\n";
                    //                for (int j = 0; j < message.Length; j++)
                    //                {
                    //                    Console.Write(message[j]);
                    //                    Thread.Sleep(game.textSpeed);
                    //                }
                    //                break;
                    //            }


                    //            musicLengths.Add(beepDur);
                    //            musicNotes.Add(beepFreq);
                    //        }
                    //        Thread.Sleep(400);
                    //        for (int i = 0; i < musicNotes.Count; i++)
                    //        {
                    //            Console.Beep(musicNotes[i], musicLengths[i]);
                    //        }

                    //    } while (currentComputerMusicState != ComputerMusicState.Exit);
                    //    break;
                    case ComputerMenuState.Exit:
                        currentComputerMenuState = ComputerMenuState.MainMenu;
                        break;
                }
            } while (currentComputerMenuState != ComputerMenuState.Exit);
        }

        public void ItemComboElement()
        {
            if (itemGraft1Element == "fire")
            {
                if (itemGraft2Element == "fire")
                    newitemElement = "fire";
                else if (itemGraft2Element == "plant")
                    newitemElement = "charcoal";
                else if (itemGraft2Element == "water")
                    newitemElement = "hydrotherm";
                else if (itemGraft2Element == "air")
                    newitemElement = "water";
                else if (itemGraft2Element == "earth")
                    newitemElement = "plant";
            }
            else if (itemGraft1Element == "plant")
            {
                if (itemGraft2Element == "plant")
                    newitemElement = "plant";
                else if (itemGraft2Element == "earth")
                    newitemElement = "moss";
                else if (itemGraft2Element == "fire")
                    newitemElement = "charcoal";
                else if (itemGraft2Element == "air")
                    newitemElement = "earth";
                else if (itemGraft2Element == "water")
                    newitemElement = "fire";
            } 
            else if (itemGraft1Element == "earth")
            {
                if (itemGraft2Element == "earth")
                    newitemElement = "earth";
                else if (itemGraft2Element == "air")
                    newitemElement = "dust";
                else if (itemGraft2Element == "plant")
                    newitemElement = "moss";
                else if (itemGraft2Element == "water")
                    newitemElement = "air";
                else if (itemGraft2Element == "fire")
                    newitemElement = "plant";
            }
            else if (itemGraft1Element == "air")
            {
                if (itemGraft2Element == "air")
                    newitemElement = "air";
                else if (itemGraft2Element == "water")
                    newitemElement = "storm";
                else if (itemGraft2Element == "earth")
                    newitemElement = "dust";
                else if (itemGraft2Element == "plant")
                    newitemElement = "earth";
                else if (itemGraft2Element == "fire")
                    newitemElement = "water";
            }
            else if (itemGraft1Element == "water")
            {
                if (itemGraft2Element == "water")
                    newitemElement = "water";
                else if (itemGraft2Element == "fire")
                    newitemElement = "hydrotherm";
                else if (itemGraft2Element == "air")
                    newitemElement = "storm";
                else if (itemGraft2Element == "earth")
                    newitemElement = "air";
                else if (itemGraft2Element == "plant")
                    newitemElement = "fire";
            } 
        }

        public void ItemComboLevel()
        {
            if (itemGraft1Level == 1)
            {
                if (itemGraft2Level == 1)
                    newitemLevel = 1;
                else if (itemGraft2Level == 2)
                    newitemLevel = 1;
                else if (itemGraft2Level == 3)
                    newitemLevel = 1;
                else if (itemGraft2Level == 4)
                    newitemLevel = 2;
            }
            else if (itemGraft1Level == 2)
            {
                if (itemGraft2Level == 1)
                    newitemLevel = 1;
                else if (itemGraft2Level == 2)
                    newitemLevel = 2;
                else if (itemGraft2Level == 3)
                    newitemLevel = 2;
                else if (itemGraft2Level == 4)
                    newitemLevel = 2;
            }
            else if (itemGraft1Level == 3)
            {
                if (itemGraft2Level == 1)
                    newitemLevel = 1;
                else if (itemGraft2Level == 2)
                    newitemLevel = 2;
                else if (itemGraft2Level == 3)
                    newitemLevel = 3;
                else if (itemGraft2Level == 4)
                    newitemLevel = 3;
            }
            else if (itemGraft1Level == 4)
            {
                if (itemGraft2Level == 1)
                    newitemLevel = 2;
                else if (itemGraft2Level == 2)
                    newitemLevel = 2;
                else if (itemGraft2Level == 3)
                    newitemLevel = 3;
                else if (itemGraft2Level == 4)
                    newitemLevel = 4;
            }       
        }
    }

//NPCs
//RIFTON

    public class NPCVanyaPetrov : InteractableObjects //Room-mate
    {
        PlayGame game; //Dependency Injection
        public NPCVanyaPetrov(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            if (game.storyCounter == 0)
            {
                game.NPCIdentifier = "NPC0000";
                game.ENDNPCIdentifier = "ENDNPC0000";
                game.NPCName = "Vanya";
                game.NPCConvStage = 3;
                game.NPCTALK();
                Console.Write("> ");
                string favdrink = Console.ReadLine();
                if (favdrink.Length > 15)
                    favdrink = favdrink.Remove(15);
                game.playerStats.favdrink = favdrink.ToLower();
                game.FavDrink.itemName = favdrink.ToLower();
                if (game.torchOn == false)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                else if (game.torchOn == true)
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                game.WriteLineText("       What a great idea, I really like " + game.playerStats.favdrink + " too!");
                game.vanyaTalk = true;
                //QUEST 1: START
                if (!game.questLog.Contains("Speak to Dr. Digby in Rifton Lab in the North of Rifton Village"))
                {
                    game.questLog.Add("Speak to Dr. Digby in Rifton Lab in the North of Rifton Village");
                    Console.ForegroundColor = game.foregroundColour;
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
            }
            if (game.storyCounter > 0)
            {
                game.NPCIdentifier = "NPC0000";
                game.ENDNPCIdentifier = "ENDNPC0000";
                game.NPCConvStage = game.random.Next(3);
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                game.WriteLineText("Vanya resumed her reading");
                Thread.Sleep(800);
            }
        }
    }

    public class NPCRufusDigby : InteractableObjects
    {
        PlayGame game; //Dependency Injection
        public NPCRufusDigby(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0001";
            game.ENDNPCIdentifier = "ENDNPC0001";
            game.NPCName = "Dr. Digby";
            if (game.storyCounter == 0)
            {
                if (!game.inventory.dictionary.ContainsKey("flashlight"))
                {
                    game.NPCConvStage = 0;
                    game.NPCTALK();
                    //QUEST 1: END
                    if (game.questLog.Contains("Speak to Dr. Digby in Rifton Lab in the North of Rifton Village"))
                    {
                        game.questLog.Remove("Speak to Dr. Digby in Rifton Lab in the North of Rifton Village");
                        Console.ForegroundColor = game.foregroundColour;
                        game.WriteLineText("You completed a quest!");
                    }
                    //QUEST 2: START
                    if (!game.questLog.Contains("Find a sample of Protomeebium in Rifton cave"))
                    {
                        game.questLog.Add("Find a sample of Protomeebium in Rifton cave");
                        Console.ForegroundColor = game.foregroundColour;
                        game.WriteLineText("A quest was added to your log - access this using the menu");
                    }
                    if (game.inventory.dictionary.Keys.Count < 20)
                    {
                        if (!game.inventory.dictionary.ContainsKey("flashlight"))
                            game.inventory.dictionary.Add("flashlight", 1);
                        else
                            game.inventory.dictionary["flashlight"] += 1;
                    }
                    else
                    {
                        game.NPCConvStage = 1;
                        game.NPCTALK();

                    }
                }
                else if (game.inventory.dictionary.ContainsKey("flashlight") && !game.inventory.dictionary.ContainsKey("protomeebium"))
                {
                    game.NPCConvStage = 2;
                    game.NPCTALK();
                }
                else if (game.inventory.dictionary.ContainsKey("flashlight") && game.inventory.dictionary.ContainsKey("protomeebium"))
                {
                    game.NPCConvStage = 3;
                    game.NPCTALK();
                    game.storyCounter = 1;
                    //QUEST 2: END
                    if (game.questLog.Contains("Find a sample of Protomeebium in Rifton cave"))
                    {
                        game.questLog.Remove("Find a sample of Protomeebium in Rifton cave");
                        Console.ForegroundColor = game.foregroundColour;
                        game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                        game.inventory.dictionary.Remove("protomeebium");
                        game.playerStats.playerMoney += 100;
                    }
                    //QUEST 3: START
                    if (!game.questLog.Contains("Find the Protomeebium book for Dr.Digby"))
                    {
                        game.questLog.Add("Find the Protomeebium book for Dr.Digby");
                        game.WriteLineText("A quest was added to your log - access this using the menu");
                    }  
                }
            }
            else if (game.inventory.dictionary.ContainsKey("protomeebium book") && game.storyCounter == 1)
            {
                game.NPCConvStage = 4;
                game.NPCTALK();
                game.storyCounter = 2;
                //QUEST 3: END
                if (game.questLog.Contains("Find the Protomeebium book for Dr.Digby"))
                {
                    Console.ForegroundColor = game.foregroundColour;
                    game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                    game.playerStats.playerMoney += 100;
                    game.questLog.Remove("Find the Protomeebium book for Dr.Digby");
                }
            }
            else if (game.storyCounter == 2)
            {
                game.NPCConvStage = 5;
                game.NPCTALK();
            }
            else if (game.storyCounter == 3 && game.inventory.dictionary.ContainsKey("ellondite"))
            {
                game.NPCConvStage = 6;
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                //QUEST 4: END
                if (game.questLog.Contains("Find another source of the radiation"))
                {
                    game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                    game.playerStats.playerMoney += 100;
                    game.questLog.Remove("Find another source of the radiation");
                }
                //QUEST 5: START
                if (!game.questLog.Contains("Use the lab equipment to splice the meeba"))
                {
                    game.questLog.Add("Use the lab equipment to splice the meeba");
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
            }
            else if (game.storyCounter == 4)
            {
                game.NPCConvStage = 7;
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                //QUEST 5: END
                if (game.questLog.Contains("Use the lab equipment to splice the meeba"))
                {
                    game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                    game.playerStats.playerMoney += 100;
                    game.questLog.Remove("Use the lab equipment to splice the meeba");
                }
                //QUEST 6: START
                if (!game.questLog.Contains("Visit Professor Fournier in Karstbay"))
                {
                    game.questLog.Add("Visit Professor Fournier in Karstbay");
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
            }
            else
            {
                game.NPCConvStage = 8;
                game.NPCTALK();
            }
        }
    }

    public class NPCDrTanaka : InteractableObjects //Visiting lab assistant
    {
        PlayGame game;

        public NPCDrTanaka (PlayGame game)
        {
            this.game = game;
            NPC = true;
        }

        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public override void Use()
        {
            game.NPCIdentifier = "NPC0002";
            game.ENDNPCIdentifier = "ENDNPC0002";
            game.NPCName = "Dr. Tanaka";
            if (game.storyCounter ==0)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
            }
            else if (game.storyCounter == 1)
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
            }
            else if (game.storyCounter == 1 && game.inventory.dictionary.ContainsKey("protomeebium book"))
            {
                game.NPCConvStage = 2;
                game.NPCTALK();
            }
            else if (game.storyCounter == 2)
            {
                game.NPCConvStage = 3;
                game.NPCTALK();
                game.storyCounter = 3;
                //QUEST 4: START
                if (!game.questLog.Contains("Find another source of the radiation"))
                {
                    game.questLog.Add("Find another source of the radiation");
                    Console.ForegroundColor = game.foregroundColour;
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
            }
            else if (game.storyCounter == 3)
            {
                game.NPCConvStage = 4;
                game.NPCTALK();
            }
            else if (game.storyCounter == 4)
            {
                game.NPCConvStage = 5;
                game.NPCTALK();
            }
            else
            {
                game.NPCConvStage = 6;
                game.NPCTALK();
            }
        }
    }

    public class NPCLibrarian : InteractableObjects //Library receptionist
    {
        PlayGame game;

        public NPCLibrarian(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }

        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public override void Use()
        {
            game.NPCIdentifier = "NPC0003";
            game.ENDNPCIdentifier = "ENDNPC0003";
            game.NPCName = "Librarian";
            string librarygoodbye = @"\bno\b|\bbye\b|\bgoodbye\b|\bleave\b|\bno thanks\b";
            string libraryhelpplease = @"\byes\b|\byes please\b|\bthanks\b|\bok\b|\bo.k.\b|\bhelp\b";
            string libraryGenericBooks = @"\bbooks\b|\bwhat books do you have\b|\bim looking for a book\b|\bwhat books\b|\bi need a book\b|\btell me what books you have\b";
            string libraryprotomeebium = @"\bprotomeebium\b|\bbooks on protomeebium\b|\bbook on protomeebium\b|\binformation on protomeebium\b|\binfo on protomeebium\b|\bhelp with protomeebium\b";
            if (game.torchOn == false)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (game.torchOn == true)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (game.librarianCounter == 0)
            {
                DateTime myValue = DateTime.Now;
                string timeOfDay = "";
                if (myValue.Hour < 12)
                    timeOfDay = "morning";
                else if (myValue.Hour >= 12 && myValue.Hour < 18)
                    timeOfDay = "afternoon";
                else if (myValue.Hour >= 18)
                    timeOfDay = "evening";
                game.WriteLineText("Good " + timeOfDay + ", " + UppercaseFirst(game.playerStats.name));
                Thread.Sleep(800);
                var randomMember = game.random.Next(4);
                game.NPCConvStage = randomMember;
                game.NPCTALK();
                bool exit = false;
                do
                {
                    Console.Write("> ");
                    string libraryinput = Console.ReadLine().ToLower().Trim();
                    if (libraryinput.Length > 80) //makes input max of 80 chars
                    {
                        double textlength = libraryinput.Length;
                        for (int i = 80; i <= textlength; i += 80)
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        libraryinput = libraryinput.Remove(80);
                    }
                    if (Regex.IsMatch(libraryinput, librarygoodbye, RegexOptions.IgnoreCase))
                    {
                        game.NPCConvStage = 4;
                        game.NPCTALK();
                        exit = true;
                        break;
                    }
                    else if (Regex.IsMatch(libraryinput, libraryhelpplease, RegexOptions.IgnoreCase))
                    {
                        game.NPCConvStage = 5;
                        game.NPCTALK();
                        Console.Write("> ");
                        string libraryinput2 = Console.ReadLine().ToLower().Trim();
                        if (libraryinput2.Length > 80) //makes input max of 80 chars
                        {
                            double textlength = libraryinput2.Length;
                            for (int i = 80; i <= textlength; i += 80)
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 1;
                            }
                            libraryinput2 = libraryinput2.Remove(80);
                        }
                        if (Regex.IsMatch(libraryinput2, libraryprotomeebium, RegexOptions.IgnoreCase) && game.storyCounter > 0)
                        {
                            game.NPCConvStage = 6;
                            game.NPCTALK();
                            game.librarianCounter = 1;
                            game.WorldMapCells[0][13].gridDescNumber = 2;
                        }
                        else if (Regex.IsMatch(libraryinput2, libraryGenericBooks, RegexOptions.IgnoreCase))
                        {
                            game.NPCConvStage = 7;
                            game.NPCTALK();
                            exit = true;
                            break;
                        }
                        else
                        {
                            game.NPCConvStage = 8;
                            game.NPCTALK();
                        }
                    }
                    else if (Regex.IsMatch(libraryinput, libraryprotomeebium, RegexOptions.IgnoreCase) && game.storyCounter > 0)
                    {
                        game.NPCConvStage = 6;
                        game.NPCTALK();
                        game.librarianCounter = 1;
                        game.WorldMapCells[0][13].gridDescNumber = 2;
                    }
                    else if (Regex.IsMatch(libraryinput, libraryGenericBooks, RegexOptions.IgnoreCase))
                    {
                        game.NPCConvStage = 7;
                        game.NPCTALK();
                        exit = true;
                        break;
                    }
                    else
                    {
                        game.NPCConvStage = 8;
                        game.NPCTALK();
                    }
                } while (exit == false);
               
            }
            else if (game.librarianCounter == 1)
            {
                game.NPCConvStage = 9;
                game.NPCTALK();
            }
        }
    }

    public class NPCElderlyLibraryMan : InteractableObjects
    {
        PlayGame game;

        public NPCElderlyLibraryMan(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0004";
            game.ENDNPCIdentifier = "ENDNPC0004";
            game.NPCName = "Elderly Man";
            if (game.libraryoldmanCounter == 0)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
                //QUEST S1: START
                if (!game.questLog.Contains("Find gardening book for elderly man in Library"))
                {
                    Console.ForegroundColor = game.foregroundColour;
                    game.questLog.Add("Find gardening book for elderly man in Library");
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
            }
            else if (game.libraryoldmanCounter == 1)
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
                game.libraryoldmanCounter = 2;
                //QUEST S1: END
                if (game.questLog.Contains("Find gardening book for elderly man in Library"))
                {
                    Console.ForegroundColor = game.foregroundColour;
                    game.questLog.Remove("Find gardening book for elderly man in Library");
                    game.WriteLineText("You completed a quest.");
                }
                //QUEST S2: START
                if (!game.questLog.Contains("Visit the elderly man's wife in Rifton"))
                {
                    game.questLog.Add("Visit the elderly man's wife in Rifton");
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                }
                if (game.librarysketchymanCounter == 2)
                {
                    game.WorldMapCells[0][13].gridDescNumber = 4;
                }
                else if (game.librarysketchymanCounter < 3)
                {
                    game.WorldMapCells[0][13].gridDescNumber = 6;
                }
            }
            else if (game.libraryoldmanCounter == 3)
            {
                game.NPCConvStage = 2;
                game.NPCTALK();
            }
        }
    }

    public class NPCDarkHairedLibraryWoman : InteractableObjects //side-quest -CHANGE - she eventually moves to mesetra and recognises you
    {
        PlayGame game;

        public NPCDarkHairedLibraryWoman(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0005";
            game.ENDNPCIdentifier = "ENDNPC0005";
            game.NPCName = "Dark-haired Woman";
            game.NPCConvStage = 0;
            game.NPCTALK();
        }
    }

    public class NPCSketchyLibraryMan : InteractableObjects //has book on protomeebium - after some time/straight away he should disappear from library
    {
        PlayGame game;

        public NPCSketchyLibraryMan(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0006";
            game.ENDNPCIdentifier = "ENDNPC0006";
            game.NPCName = "Suited Man";
            if (game.librarysketchymanCounter == 0)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
                game.librarysketchymanCounter = 1;
            }
            else if (game.librarysketchymanCounter == 1)
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
                game.librarysketchymanCounter = 2;
            }
            else if (game.librarysketchymanCounter == 2)
            {
                string sketchymanNeverMind = @"\bnothing\b|\bnever mind\b";
                string sketchymanBook = @"\bbook\b|\bthat book\b|\byour book\b|\bcan i have that book\b|\bgive me that book\b|\bi want that book\b";
                game.NPCConvStage = 2;
                game.NPCTALK();
                Console.Write("> ");
                string sketchymanInput = Console.ReadLine().ToLower().Trim();
                if (sketchymanInput.Length > 80) //makes input max of 80 chars
                {
                    double textlength = sketchymanInput.Length;
                    for (int i = 80; i <= textlength; i += 80)
                    {
                        Console.CursorTop -= 1;
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.CursorTop -= 1;
                    }
                    sketchymanInput = sketchymanInput.Remove(80);
                }
                if (Regex.IsMatch(sketchymanInput, sketchymanNeverMind, RegexOptions.IgnoreCase))
                {
                    game.NPCConvStage = 3;
                    game.NPCTALK();
                    game.librarysketchymanCounter = 0;
                }
                else if (Regex.IsMatch(sketchymanInput, sketchymanBook, RegexOptions.IgnoreCase))
                {
                    game.NPCConvStage = 4;
                    game.NPCTALK();
                    bool validChoice = false;
                    do
                    {
                        Console.Write("> ");
                        string input = Console.ReadLine().ToLower().Trim();
                        if (input.Length > 80) //makes input max of 80 chars
                        {
                            double textlength = input.Length;
                            for (int i = 80; i <= textlength; i += 80)
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 1;
                            }
                            input = input.Remove(80);
                        }
                        if (!string.IsNullOrEmpty(input))
                        {
                            validChoice = true;
                            game.NPCConvStage = 5;
                            game.NPCTALK();
                            if (game.inventory.dictionary.Keys.Count < 20)
                            {
                                game.inventory.dictionary.Add("protomeebium book", 1);
                                game.librarysketchymanCounter = 3;
                                game.WorldMapCells[0][13].gridDescNumber = 3;
                                game.NPCConvStage = 6;
                                game.NPCTALK();
                            }
                            else
                            {
                                game.NPCConvStage = 7;
                                game.NPCTALK();
                            }
                        }
                        else
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                    } while (validChoice == false);  
                }
            }
        }
    }

    public class NPCElderlyCottageWoman : InteractableObjects 
    {
        PlayGame game;

        public NPCElderlyCottageWoman(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0007";
            game.ENDNPCIdentifier = "ENDNPC0007";
            game.NPCName = "Elderly Woman";
            if (game.libraryoldmanCounter == 0)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
            }
            else if (game.libraryoldmanCounter == 2)
            {
                bool receivedItems = false;
                game.NPCConvStage = 1;
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                //QUEST S2: END
                if (game.questLog.Contains("Visit the elderly man's wife in Rifton"))
                {
                    game.WriteLineText("You completed a quest.");
                    game.questLog.Remove("Visit the elderly man's wife in Rifton");
                }
                if (game.inventory.dictionary.Count <=15 && receivedItems == false)
                {
                    game.NPCConvStage = 2;
                    game.NPCTALK();
                    receivedItems = true;
                    game.inventory.dictionary.Add("knitted vest", 1);
                    game.libraryoldmanCounter = 3;
                    game.NPCConvStage = 3;
                    game.NPCTALK();
                    game.qrcodes.RiftonArt();
                }
                else
                {
                    game.NPCConvStage = 4;
                    game.NPCTALK();
                }
            }
            else if (game.libraryoldmanCounter == 3)
            {
                game.NPCConvStage = 3;
                game.NPCTALK();
                game.qrcodes.RiftonArt();
            }
        }
    }
    
    public class NPCWeaponsWoman : InteractableObjects //rifton weapons dealer
    {
        PlayGame game;
        public NPCWeaponsWoman (PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0008";
            game.ENDNPCIdentifier = "ENDNPC0008";
            game.NPCName = "Jemma Blacksmith";
            game.NPCConvStage = 0;
            game.NPCTALK();
            string wantWeapons = @"\bweapon\b|\bweapons\b|\bbuy\b";
            Console.Write("> ");
            string choice = Console.ReadLine().ToLower().Trim();
            if (choice.Length > 80) //makes input max of 80 chars
            {
                double textlength = choice.Length;
                for (int i = 80; i <= textlength; i += 80)
                {
                    Console.CursorTop -= 1;
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.CursorTop -= 1;
                }
                choice = choice.Remove(80);
            }
            if (Regex.IsMatch(choice, wantWeapons, RegexOptions.IgnoreCase))
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
            }
            else
            {
                game.NPCConvStage = 2;
                game.NPCTALK();
            }
        }
    }

    public class NPCRiftonShopKeeper : InteractableObjects
    {
        PlayGame game; //Dependency Injection
        public NPCRiftonShopKeeper(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0015";
            game.ENDNPCIdentifier = "ENDNPC0015";
            game.NPCName = "Shop Keeper";
            game.NPCConvStage = 0;
            game.NPCTALK();
        }
    }

    public class NPCFountainMan : InteractableObjects
    {
        PlayGame game; //Dependency Injection
        public NPCFountainMan(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0016";
            game.ENDNPCIdentifier = "ENDNPC0016";
            game.NPCName = "Man";
            if (game.takeCoins == false)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
            }
            else if (game.takeCoins == true)
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
            }
        }
    }

    public class NPCDrinksVendor : InteractableObjects //Rifton park drinks vendor
    {
        PlayGame game; //Dependency Injection
        public NPCDrinksVendor (PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0009";
            game.ENDNPCIdentifier = "ENDNPC0009";
            game.NPCName = "Drinks Vendor";
            string[] weather = new string[]{"chilly", "warm", "hot", "breezy", "cold", "freezing", "rainy", "snowy", "humid"};
            var randomMember = game.random.Next(weather.Length);
            if (game.torchOn == false)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (game.torchOn == true)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            game.WriteLineText("Hi there! On a day as " + weather[randomMember] + " as this, a Pipon Shake is the best thing to make you feel better!");
            Thread.Sleep(800);
            game.NPCConvStage = 0;
            game.NPCTALK();
            string yes = @"\byes\b|\bok\b|\bo.k\b|\bo.k.\b|\byes please\b|\byeah\b|\byep\b";
            string no = @"\bno\b|\bno thanks\b|\bbye\b|\bnever mind\b|\banother time\b";
            bool validChoice = false;
            do
            {
                Console.Write("> ");
                string drinksInput = Console.ReadLine().ToLower().Trim();
                if (drinksInput.Length > 80) //makes input max of 80 chars
                {
                    double textlength = drinksInput.Length;
                    for (int i = 80; i <= textlength; i += 80)
                    {
                        Console.CursorTop -= 1;
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.CursorTop -= 1;
                    }
                    drinksInput = drinksInput.Remove(80);
                }
                if (Regex.IsMatch(drinksInput, no, RegexOptions.IgnoreCase))
                {
                    game.NPCConvStage = 1;
                    game.NPCTALK();
                    validChoice = true;
                    break;
                }
                else if (Regex.IsMatch(drinksInput, yes, RegexOptions.IgnoreCase))
                {
                    game.NPCConvStage = 2;
                    game.NPCTALK();
                    bool validChoice2 = false;
                    bool exit = false;
                    do
                    {
                        Console.Write("> ");
                        string drinksInput2 = Console.ReadLine().ToLower().Trim();
                        if (drinksInput2.Length > 80) //makes input max of 80 chars
                        {
                            double textlength = drinksInput2.Length;
                            for (int i = 80; i <= textlength; i += 80)
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 1;
                            }
                            drinksInput2 = drinksInput2.Remove(80);
                        }
                        if (drinksInput2 == "back" || drinksInput2 == "exit" ||drinksInput2 == "ignore" ||drinksInput2 == "never mind" ||drinksInput2 == "leave")
                        {
                            validChoice2 = true;
                            exit = true;
                            game.NPCConvStage = 1;
                            game.NPCTALK();
                            break;
                        }
                        else if (drinksInput2 == "red pipon shake" || drinksInput2 == "red" || drinksInput2 == "red shake" || drinksInput2 == "red pipon")
                        {
                            game.itemChoice = "red pipon shake";
                            game.referenceCurrentItem();
                            validChoice2 = true;
                        }
                        else if (drinksInput2 == "blue pipon shake" || drinksInput2 == "blue" || drinksInput2 == "blue shake" || drinksInput2 == "blue pipon")
                        {
                            game.itemChoice = "blue pipon shake";
                            game.referenceCurrentItem();
                            validChoice2 = true;
                        }
                        else if (drinksInput2 == "green pipon shake" || drinksInput2 == "green" || drinksInput2 == "green shake" || drinksInput2 == "green pipon")
                        {
                            game.itemChoice = "green pipon shake";
                            game.referenceCurrentItem();
                            validChoice2 = true;
                        }
                        else if (drinksInput2 == "pink pipon shake" || drinksInput2 == "pink" || drinksInput2 == "pink shake" || drinksInput2 == "pink pipon")
                        {
                            game.itemChoice = "pink pipon shake";
                            game.referenceCurrentItem();
                            validChoice2 = true;
                        }
                        else if (drinksInput2.ToLower() == game.playerStats.favdrink.ToLower())
                        {
                            game.itemChoice = game.playerStats.favdrink;
                            game.referenceCurrentItem();
                            validChoice2 = true;
                        }
                        else
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                    } while (validChoice2 == false);
                    if (exit == true)
                        break;
                    if (game.inventory.dictionary.Keys.Count ==20 && !game.inventory.dictionary.ContainsKey(game.examItem.itemName))
                    {
                        game.NPCConvStage = 3;
                        game.NPCTALK();
                        exit = true;
                        break;
                    }
                    if (game.torchOn == false)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else if (game.torchOn == true)
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    game.WriteLineText("               How many would you like? They cost " + game.examItem.itemBuyValue + " Ayu each, and I can make up to 10 for you.");
                    Thread.Sleep(1000);
                    bool validChoice3 = false;
                    do
                    {
                        Console.Write("> ");
                        string drinksInput3 = Console.ReadLine().ToLower().Trim();
                        if (drinksInput3.Length > 80) //makes input max of 80 chars
                        {
                            double textlength = drinksInput3.Length;
                            for (int i = 80; i <= textlength; i += 80)
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 1;
                            }
                            drinksInput3 = drinksInput3.Remove(80);
                        }
                        if (drinksInput3 == "back" || drinksInput3 == "exit" || drinksInput3 == "ignore" || drinksInput3 == "never mind" || drinksInput3 == "leave")
                        {
                            validChoice3 = true;
                            exit = true;
                            game.NPCConvStage = 1;
                            game.NPCTALK();
                            break;
                        }
                        else if (string.IsNullOrEmpty(drinksInput3) || drinksInput3 != "1" && drinksInput3 != "2" && drinksInput3 != "3" && drinksInput3 != "4" && drinksInput3 != "5" && drinksInput3 != "6" && drinksInput3 != "7" && drinksInput3 != "8" && drinksInput3 != "9" && drinksInput3 != "10")
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        else
                        {
                            int drinksInput3Int = Convert.ToInt16(drinksInput3);
                            int moneyAmount = drinksInput3Int * game.examItem.itemBuyValue;
                            if (game.torchOn == false)
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                            else if (game.torchOn == true)
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            game.WriteLineText("               That will cost " + moneyAmount + " Ayu.");
                            Thread.Sleep(1000);
                            if (game.playerStats.playerMoney >=moneyAmount)
                            {
                                game.NPCConvStage = 4;
                                game.NPCTALK();
                                game.playerStats.playerMoney -= moneyAmount;
                                if (game.inventory.dictionary.ContainsKey(game.examItem.itemName))
                                    game.inventory.dictionary[game.examItem.itemName] += drinksInput3Int;
                                else
                                    game.inventory.dictionary.Add(game.examItem.itemName, drinksInput3Int);
                                validChoice3 = true;
                                Console.ForegroundColor = game.foregroundColour;
                                game.WriteLineText("You received " + drinksInput3 + " " + game.FavDrink.itemName + "s. They were added to your inventory.");
                                Thread.Sleep(1000);
                                exit = true;
                                break;
                            }
                            else
                            {
                                game.NPCConvStage = 5;
                                game.NPCTALK();
                                validChoice3 = true;
                                exit = true;
                                break;
                            }
                        }
                    } while (validChoice3 == false);
                    if (exit == true)
                        break;
                }
                else
                {
                    game.NPCConvStage = 6;
                    game.NPCTALK();
                }
            } while (validChoice == false);
        }
    }

    public class NPCGutoMiner : InteractableObjects //Room-mate
    {
        PlayGame game; //Dependency Injection
        public NPCGutoMiner(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0010";
            game.ENDNPCIdentifier = "ENDNPC0010";
            game.NPCName = "Guto";
            if (game.storyCounter <3 || game.minerCounter > 0)
            {
                var randomMember = game.random.Next(5);
                game.NPCConvStage = randomMember;
                game.NPCTALK();
            }
            else if (game.storyCounter == 3 && game.minerCounter == 0)
            {
                game.NPCConvStage = 5;
                game.NPCTALK();
                string bartEllondite = @"\bellondite\b|\bdo you know where i can find ellondite\b|\bi need to find ellondite\b";
                string bartGoodbye = @"\bbye\b|\bgoodbye\b|\bno\b|\bnever mind\b|\bsee you\b|\bsee ya\b";
                bool validinput = false;
                do
                {
                    Console.Write("> ");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (input.Length > 80) //makes input max of 80 chars
                    {
                        double textlength = input.Length;
                        for (int i = 80; i <= textlength; i += 80)
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        input = input.Remove(80);
                    }
                    if (Regex.IsMatch(input, bartGoodbye, RegexOptions.IgnoreCase))
                    {
                        game.NPCConvStage =6;
                        game.NPCTALK();
                        validinput = true;
                    }
                    else if (Regex.IsMatch(input, bartEllondite, RegexOptions.IgnoreCase) && game.minerCounter <1)
                    {
                        game.NPCConvStage = 7;
                        game.NPCTALK();
                        validinput = true;
                        game.minerCounter = 1;
                        game.inventory.dictionary.Add("pickaxe", 1);
                    }
                    else
                    {
                        game.NPCConvStage = 8;
                        game.NPCTALK();
                    }
                } while (validinput == false);
            }
            else 
            {
                game.NPCConvStage = 9;
                game.NPCTALK();
            }
        }
    }

    public class NPCBartMiner : InteractableObjects //Room-mate
    {
        PlayGame game; //Dependency Injection
        public NPCBartMiner(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0011";
            game.ENDNPCIdentifier = "ENDNPC0011";
            game.NPCName = "Bart";
            if (game.storyCounter < 3 || game.minerCounter > 0)
            {
                var randomMember = game.random.Next(4);
                game.NPCConvStage = randomMember;
                game.NPCTALK();
            }
            else if (game.storyCounter == 3)
            {
                game.NPCConvStage = 4;
                game.NPCTALK();
                string bartEllondite = @"\bellondite\b|\bdo you know where i can find ellondite\b|\bi need to find ellondite\b";
                string bartGoodbye = @"\bbye\b|\bgoodbye\b|\bno\b|\bnever mind\b|\bsee you\b|\bsee ya\b";
                bool validinput = false;
                do
                {
                    Console.Write("> ");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (input.Length > 80) //makes input max of 80 chars
                    {
                        double textlength = input.Length;
                        for (int i = 80; i <= textlength; i += 80)
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        input = input.Remove(80);
                    }
                    if (Regex.IsMatch(input, bartGoodbye, RegexOptions.IgnoreCase))
                    {
                        game.NPCConvStage = 5;
                        game.NPCTALK();
                        validinput = true;
                    }
                    else if (Regex.IsMatch(input, bartEllondite, RegexOptions.IgnoreCase) && game.minerCounter <1)
                    {
                        game.NPCConvStage = 6;
                        game.NPCTALK();
                        validinput = true;
                        game.minerCounter = 1;
                    }
                    else
                    {
                        game.NPCConvStage = 7;
                        game.NPCTALK();
                    }
                } while (validinput == false);
            }
            else
            {
                game.NPCConvStage = 8;
                game.NPCTALK();
            }
        }
    }

    public class NPCBoatGuy : InteractableObjects //side-quest -CHANGE
    {
        PlayGame game;

        public NPCBoatGuy(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0012";
            game.ENDNPCIdentifier = "ENDNPC0012";
            game.NPCName = "Sailor";
            if (game.storyCounter <4)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
            }
            else if (game.storyCounter == 4 && game.boatguyCounter == 0)
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
                game.boatguyCounter = 1;
            }
            else if (game.storyCounter == 4 && game.boatguyCounter == 1)
            {
                game.NPCConvStage = 2;
                game.NPCTALK();
                bool validChoice = false;
                do
                {
                    Console.Write("> ");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (input.Length > 80) //makes input max of 80 chars
                    {
                        double textlength = input.Length;
                        for (int i = 80; i <= textlength; i += 80)
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        input = input.Remove(80);
                    }
                    if (input == "no" || input == "n")
                    {
                        game.NPCConvStage = 3;
                        game.NPCTALK();
                        validChoice = true;
                        break;
                    }
                    else if (input == "yes" || input == "y")
                    {
                        game.NPCConvStage = 4;
                        game.NPCTALK();
                        validChoice = true;
                        game.boatguyCounter = 2;
                        break;
                    }
                } while (validChoice == false);
            }
            else if (game.boatguyCounter == 2)
            {
                game.NPCConvStage = 5;
                game.NPCTALK();
            }
            Console.ForegroundColor = game.foregroundColour;
        }
    }

    public class NPCBrigitteFournier : InteractableObjects //
    {
        PlayGame game;

        public NPCBrigitteFournier(PlayGame game)
        {
            this.game = game;
            NPC = true;
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public override void Use()
        {
            game.NPCIdentifier = "NPC0013";
            game.ENDNPCIdentifier = "ENDNPC0013";
            game.NPCName = "Prof. Fournier";
            if (game.storyCounter <5)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                //QUEST 6: END
                if (game.questLog.Contains("Visit Professor Fournier in Karstbay"))
                {
                    game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                    game.playerStats.playerMoney += 100;
                    game.questLog.Remove("Visit Professor Fournier in Karstbay");
                }
                //QUEST 7: START
                if (!game.questLog.Contains("Use the detector to locate the radiation in Karstbay caves"))
                {
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                    game.questLog.Add("Use the detector to locate the radiation in Karstbay caves");
                }
                if (game.inventory.dictionary.Count < 20 && !game.inventory.dictionary.ContainsKey("detector"))
                {
                    game.inventory.dictionary.Add("detector", 1);
                    game.NPCConvStage = 1;
                    game.NPCTALK();
                    game.storyCounter = 5;
                }
                else
                {
                    game.NPCConvStage = 2;
                    game.NPCTALK();
                }
                Console.ForegroundColor = game.foregroundColour;
            }
            else if (game.storyCounter == 5)
            {
                game.NPCConvStage = 3;
                game.NPCTALK();
            }
            else if (game.storyCounter == 6)
            {
                game.NPCConvStage = 4;
                game.NPCTALK();
                Console.ForegroundColor = game.foregroundColour;
                //QUEST 7: END
                if (game.questLog.Contains("Use the detector to locate the radiation in Karstbay caves"))
                {
                    game.WriteLineText("You completed a quest! The Rifton Lab sent you a new paycheck.");
                    game.playerStats.playerMoney += 150;
                    game.questLog.Remove("Use the detector to locate the radiation in Karstbay caves");
                }
                //QUEST 8: START
                if (!game.questLog.Contains("Splice the meeba using Professor Fournier's lab equipment"))
                {
                    game.WriteLineText("A quest was added to your log - access this using the menu");
                    game.questLog.Add("Splice the meeba using Professor Fournier's lab equipment");
                }
                //CHANGE - need to add the next quest!
            }
        }
    }

    public class NPCAntonBlacksmith : InteractableObjects //Rifton Blacksmith
    {
        PlayGame game; //Dependency Injection

        public NPCAntonBlacksmith(PlayGame game)
        {
            this.game = game; //Dependency Injection
            NPC = true;
        }

        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public override void Use()
        {
            game.NPCName = "Anton Blacksmith";
            game.NPCIdentifier = "NPC0014";
            game.ENDNPCIdentifier = "ENDNPC0014";
            if (game.antonCounter == 0)
            {
                game.NPCConvStage = 0;
                game.NPCTALK();
                game.antonCounter = 1;
            }
            else
            {
                game.NPCConvStage = 1;
                game.NPCTALK();
                bool validBlacksmithInput = false;
                bool exit = false;
                do
                {
                    Console.Write("> ");
                    string blacksmithInput = Console.ReadLine().ToLower().Trim();
                    if (blacksmithInput.Length > 80) //makes input max of 80 chars
                    {
                        double textlength = blacksmithInput.Length;
                        for (int i = 80; i <= textlength; i += 80)
                        {
                            Console.CursorTop -= 1;
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.CursorTop -= 1;
                        }
                        blacksmithInput = blacksmithInput.Remove(80);
                    }
                    if (blacksmithInput == "upgrade".ToLower())
                    {
                        game.NPCConvStage = 2;
                        game.NPCTALK();
                        validBlacksmithInput = true;
                        List<string> currentWeaponKeys = new List<string>();
                        currentWeaponKeys.Clear();
                        foreach (KeyValuePair<string, int> item in game.inventory.dictionary)
                        {
                            game.itemChoice = item.Key;
                            game.referenceCurrentItem();
                            if (game.examItem.itemType == "weapon" || game.examItem.itemType == "shield")
                                currentWeaponKeys.Add(item.Key);
                        }
                        for (int i = 0; i < currentWeaponKeys.Count; i++)
                        {
                            game.itemChoice = currentWeaponKeys[i];
                            game.referenceCurrentItem();
                            game.WriteLineText((i + 1) + ": " + UppercaseFirst(currentWeaponKeys[i]) + " [" + UppercaseFirst(game.examItem.weaponelementName) + " " + UppercaseFirst(game.examItem.itemName) + " of " + UppercaseFirst(game.examItem.weaponstatName) + "]");
                        }
                        bool validWeaponGraftChoice = false;
                        do
                        {
                            Console.Write("> ");
                            string weaponGraftChoice = Console.ReadLine().ToLower().Trim();
                            if (weaponGraftChoice.Length > 80) //makes input max of 80 chars
                            {
                                double textlength = weaponGraftChoice.Length;
                                for (int i = 80; i <= textlength; i += 80)
                                {
                                    Console.CursorTop -= 1;
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.CursorTop -= 1;
                                }
                                weaponGraftChoice = weaponGraftChoice.Remove(80);
                            }
                            if (weaponGraftChoice == "back" || weaponGraftChoice == "exit" || weaponGraftChoice == "goodbye" || weaponGraftChoice == "bye")
                            {
                                game.NPCConvStage = 3;
                                game.NPCTALK();
                                validWeaponGraftChoice = true;
                                exit = true;
                                validBlacksmithInput = true;
                                break;
                            }
                            else if (string.IsNullOrEmpty(weaponGraftChoice) || weaponGraftChoice != "1" && weaponGraftChoice != "2" && weaponGraftChoice != "3" && weaponGraftChoice != "4" && weaponGraftChoice != "5" && weaponGraftChoice != "6" && weaponGraftChoice != "7" && weaponGraftChoice != "8" && weaponGraftChoice != "9" && weaponGraftChoice != "10" && weaponGraftChoice != "11" && weaponGraftChoice != "12" && weaponGraftChoice != "13" && weaponGraftChoice != "14" && weaponGraftChoice != "15" && weaponGraftChoice != "16" && weaponGraftChoice != "17" && weaponGraftChoice != "18" && weaponGraftChoice != "19" && weaponGraftChoice != "20" || Convert.ToInt16(weaponGraftChoice) > currentWeaponKeys.Count)
                            {
                                Console.Clear();
                                game.NPCConvStage = 2;
                                game.NPCTALK();
                                for (int i = 0; i < currentWeaponKeys.Count; i++)
                                {
                                    game.itemChoice = currentWeaponKeys[i];
                                    game.referenceCurrentItem();
                                    game.WriteLineText((i + 1) + ": " + UppercaseFirst(currentWeaponKeys[i]) + " [" + UppercaseFirst(game.examItem.weaponelementName) + " " + UppercaseFirst(game.examItem.itemName) + " of " + UppercaseFirst(game.examItem.weaponstatName) + "]");
                                }
                            }
                            else
                            {
                                int weaponChoiceInt = Convert.ToInt16(weaponGraftChoice);
                                for (int i = 1; i < (currentWeaponKeys.Count + 1); i++)
                                {
                                    if (weaponChoiceInt == i)
                                    {
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.itemChoice = currentWeaponKeys[i - 1];
                                        game.referenceCurrentItem();
                                        game.currentGraftWeapon = game.examItem.itemName;
                                        validWeaponGraftChoice = true;
                                    }
                                }
                            }
                        } while (validBlacksmithInput == false && exit == false);
                        if (exit == true)
                            break;
                        //item to mod with
                        Thread.Sleep(800);
                        game.WriteLineText("This is a " + UppercaseFirst(game.examItem.weaponelementName) + " " + UppercaseFirst(game.examItem.itemName) + " of " + UppercaseFirst(game.examItem.weaponstatName));
                        Thread.Sleep(800);

                        string[,] beginnings = new string[2, 3] { { "power", "stronger", "grellite" }, { "", "", "" } };
                        string[,] power = new string[2, 3] { { "great power", "stronger", "red mustonite" }, { "swiftness", "faster", "blue mustonite" } };
                        string[,] greatpower = new string[2, 3] { { "extreme power", "stronger", "red cobarite" }, { "vitality", "more resilient", "green cobarite" } };
                        string[,] extremepower = new string[2, 3] { { "absolute power", "stronger", "red safrostine" }, { "power and vitality", "stronger and more resilient", "brown safrostine" } };
                        string[,] absolutepower = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] powerandvitality = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] vitality = new string[2, 3] { { "great vitality", "more resilient", "green safrostine" }, { "vitality and accuracy", "more resilient and accurate", "lime safrostine" } };
                        string[,] greatvitality = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] vitalityandaccuracy = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] swiftness = new string[2, 3] { { "accuracy", "more accurate", "yellow cobarite" }, { "great swiftness", "faster", "blue cobarite" } };
                        string[,] accuracy = new string[2, 3] { { "great accuracy", "more accurate", "yellow safrostine" }, { "wit", "more charismatic", "pink safrostine" } };
                        string[,] greatswiftness = new string[2, 3] { { "power and swiftness", "stronger and faster", "purple safrostine" }, { "extreme swiftness", "faster", "blue safrostine" } };
                        string[,] greataccuracy = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] wit = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] extremeswiftness = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] powerandswiftness = new string[2, 3] { { "", "", "" }, { "", "", "" } };

                        Dictionary<string, string[,]> weaponUpgrades = new Dictionary<string, string[,]>();
                        weaponUpgrades.Clear();
                        weaponUpgrades.Add("beginnings", beginnings);
                        weaponUpgrades.Add("power", power);
                        weaponUpgrades.Add("great power", greatpower);
                        weaponUpgrades.Add("extreme power", extremepower);
                        weaponUpgrades.Add("absolte power", absolutepower);
                        weaponUpgrades.Add("power and vitality", powerandvitality);
                        weaponUpgrades.Add("vitality", vitality);
                        weaponUpgrades.Add("great vitality", greatvitality);
                        weaponUpgrades.Add("vitality and accuracy", vitalityandaccuracy);
                        weaponUpgrades.Add("swiftness", swiftness);
                        weaponUpgrades.Add("accuracy", accuracy);
                        weaponUpgrades.Add("great swiftness", greatswiftness);
                        weaponUpgrades.Add("great accuracy", greataccuracy);
                        weaponUpgrades.Add("wit", wit);
                        weaponUpgrades.Add("extreme swiftness", extremeswiftness);
                        weaponUpgrades.Add("power and swiftness", powerandswiftness);

                        string[,] beginningsA = new string[2, 3] { { "resistance", "tougher", "quarlite" }, { "", "", "" } };
                        string[,] resistanceA = new string[2, 3] { { "great resistance", "tougher", "red tomaline" }, { "vitality", "more resilient", "green tomaline" } };
                        string[,] greatresistanceA = new string[2, 3] { { "extreme resistance", "tougher", "red corusite" }, { "accuracy", "more accurate", "yellow corusite" } };
                        string[,] extremeresistanceA = new string[2, 3] { { "absolute resistance", "tougher", "red dirazite" }, { "resistance and accuracy", "tougher and more accurate", "orange dirazite" } };
                        string[,] absoluteresistanceA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] resistanceandaccuracyA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] accuracyA = new string[2, 3] { { "great accuracy", "more accurate", "yellow dirazite" }, { "wit", "more charismatic", "pink dirazite" } };
                        string[,] greataccuracyA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] witA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] vitalityA = new string[2, 3] { { "swiftness", "faster", "blue corusite" }, { "great vitality", "more resilient", "green corusite" } };
                        string[,] swiftnessA = new string[2, 3] { { "great swiftness", "faster", "blue dirazite" }, { "swiftness and vitality", "faster and more resilient", "aqua dirazite" } };
                        string[,] greatvitalityA = new string[2, 3] { { "extreme vitality", "more resilient", "green dirazite" }, { "vitality and resistance", "tougher and more resilient", "brown dirazite" } };
                        string[,] greatswiftnessA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] swiftnessandvitalityA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] extremevitalityA = new string[2, 3] { { "", "", "" }, { "", "", "" } };
                        string[,] vitalityandresistanceA = new string[2, 3] { { "", "", "" }, { "", "", "" } };

                        Dictionary<string, string[,]> shieldUpgrades = new Dictionary<string, string[,]>();
                        shieldUpgrades.Clear();
                        shieldUpgrades.Add("beginnings", beginningsA);
                        shieldUpgrades.Add("resistance", resistanceA);
                        shieldUpgrades.Add("great resistance", greatresistanceA);
                        shieldUpgrades.Add("extreme resistance", extremeresistanceA);
                        shieldUpgrades.Add("absolute resistance", absoluteresistanceA);
                        shieldUpgrades.Add("resistance and accuracy", resistanceandaccuracyA);
                        shieldUpgrades.Add("accuracy", accuracyA);
                        shieldUpgrades.Add("great accuracy", greataccuracyA);
                        shieldUpgrades.Add("wit", witA);
                        shieldUpgrades.Add("vitality", vitalityA);
                        shieldUpgrades.Add("swiftness", swiftnessA);
                        shieldUpgrades.Add("great vitality", greatvitalityA);
                        shieldUpgrades.Add("great swiftness", greatswiftnessA);
                        shieldUpgrades.Add("swiftness and vitality", swiftnessandvitalityA);
                        shieldUpgrades.Add("extreme vitality", extremevitalityA);
                        shieldUpgrades.Add("vitality and resistance", vitalityandresistanceA);

                        string neededItem = "";

                        if (game.examItem.itemType == "weapon")
                        {
                            bool next = false;
                            foreach (var item in weaponUpgrades)
                            {
                                if (game.examItem.weaponstatName.ToLower() == item.Key.ToLower())
                                {
                                    if (item.Value[0, 0] == "" && item.Value[1, 0] == "")
                                    {
                                        game.NPCConvStage = 4;
                                        game.NPCTALK();
                                        next = false;
                                        break;
                                    }
                                    else if (item.Key == "beginnings")
                                    {
                                        game.WriteLineText("                  I could make it stronger if I had the right materials?");
                                        Thread.Sleep(800);
                                        bool validChoice = false;
                                        do
                                        {
                                            Console.Write("> ");
                                            string choice = Console.ReadLine().ToLower().Trim();
                                            if (choice.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = choice.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                choice = choice.Remove(80);
                                            }
                                            if (choice == "n" || choice == "no")
                                            {
                                                game.NPCConvStage = 3;
                                                game.NPCTALK();
                                                validBlacksmithInput = true;
                                                next = false;
                                                break;
                                            }
                                            else if (choice == "y" || choice == "yes")
                                            {
                                                next = true;
                                                neededItem = item.Value[0, 2];
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                        } while (validChoice == false);
                                        break;
                                    }
                                    else
                                    {
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.WriteLineText("                  I could make it " + item.Value[0, 1] + ", or " + item.Value[1, 1] + " if I had the right materials?");
                                        game.WriteLineText("                  1: " + UppercaseFirst(item.Value[0, 1]));
                                        game.WriteLineText("                  2: " + UppercaseFirst(item.Value[1, 1]));
                                        Thread.Sleep(800);
                                        bool validChoice = false;
                                        do
                                        {
                                            Console.Write("> ");
                                            string choice = Console.ReadLine().ToLower().Trim();
                                            if (choice.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = choice.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                choice = choice.Remove(80);
                                            }
                                            if (choice == "1" || choice == item.Value[0, 1].ToLower())
                                            {
                                                neededItem = item.Value[0, 2];
                                                validChoice = true;
                                            }
                                            else if (choice == "2" || choice == item.Value[1, 1].ToLower())
                                            {
                                                neededItem = item.Value[1, 2];
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                        } while (validChoice == false);
                                        next = true;
                                        break;
                                    }
                                }
                            }
                            if (next == true) //test all of this when on train
                            {
                                bool validChoice = false;
                                if (game.torchOn == false)
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                else if (game.torchOn == true)
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                game.WriteLineText("                  I would need a " + UppercaseFirst(neededItem) + " for that, do you have one?");
                                Thread.Sleep(800);
                                do
                                {
                                    Console.Write("> ");
                                    string input3 = Console.ReadLine().ToLower().Trim();
                                    if (input3.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = input3.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        input3 = input3.Remove(80);
                                    }
                                    if (input3 == "no" || input3 == "n")
                                    {

                                        game.itemChoice = neededItem;
                                        game.referenceCurrentItem();
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.WriteLineText("                  I can't do anything without it. But I heard you can find it " + game.examItem.weaponArmourLocation);
                                        Thread.Sleep(800);
                                        validChoice = true;
                                        validBlacksmithInput = true;
                                    }
                                    else if (input3 == "yes" || input3 == "y")
                                    {
                                        if (game.inventory.dictionary.ContainsKey(neededItem))
                                        {
                                            Item currentItem = game.examItem;
                                            game.itemChoice = neededItem;
                                            game.referenceCurrentItem();
                                            game.NPCConvStage = 5;
                                            game.NPCTALK();
                                            currentItem.weaponstatName = game.examItem.weaponstatName;
                                            currentItem.itemStrengthBonus += game.examItem.itemStrengthBonus;
                                            currentItem.itemSpeedBonus += game.examItem.itemSpeedBonus;
                                            currentItem.itemDefenseBonus += game.examItem.itemDefenseBonus;
                                            currentItem.itemCharismaBonus += game.examItem.itemCharismaBonus;
                                            currentItem.itemHPGain += game.examItem.itemHPGain;
                                            currentItem.itemHitGain += game.examItem.itemHitGain;
                                            game.inventory.dictionary.TryGetValue(neededItem, out game.currentCount);
                                            game.inventory.dictionary[neededItem] = game.currentCount - 1;
                                            game.inventory.dictionary.TryGetValue(neededItem, out game.currentCount); //removes any 0 value items
                                            if (game.currentCount == 0)
                                                game.inventory.dictionary.Remove(neededItem);
                                            game.WriteLineText("                  All finished. Here is your new " + UppercaseFirst(currentItem.weaponelementName) + " " + UppercaseFirst(currentItem.itemName) + " of " + UppercaseFirst(currentItem.weaponstatName));
                                            Thread.Sleep(1000);
                                            validChoice = true;
                                        }
                                        else
                                        {
                                            game.NPCConvStage = 6;
                                            game.NPCTALK();
                                            validChoice = true;
                                            validBlacksmithInput = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.CursorTop -= 1;
                                        Console.Write(new string(' ', Console.WindowWidth));
                                        Console.CursorTop -= 2;
                                        game.WriteLineText("                  I would need a " + UppercaseFirst(neededItem) + " for that, do you have one?");
                                        Thread.Sleep(800);
                                    }
                                } while (validChoice == false);
                            }
                        }

                        else if (game.examItem.itemType == "shield")
                        {
                            bool next = false;
                            foreach (var item in shieldUpgrades)
                            {
                                if (game.examItem.weaponstatName.ToLower() == item.Key.ToLower())
                                {
                                    if (item.Value[0, 0] == "" && item.Value[1, 0] == "")
                                    {
                                        game.NPCConvStage = 4;
                                        game.NPCTALK();
                                        next = false;
                                        break;
                                    }
                                    else if (item.Key == "beginnings")
                                    {
                                        game.WriteLineText("                  I could make it tougher if I had the right materials?");
                                        Thread.Sleep(800);
                                        bool validChoice = false;
                                        do
                                        {
                                            Console.Write("> ");
                                            string choice = Console.ReadLine().ToLower().Trim();
                                            if (choice.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = choice.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                choice = choice.Remove(80);
                                            }
                                            if (choice == "n" || choice == "no")
                                            {
                                                game.NPCConvStage = 3;
                                                game.NPCTALK();
                                                validBlacksmithInput = true;
                                                validChoice = true;
                                                next = false;
                                                break;
                                            }
                                            else if (choice == "y" || choice == "yes")
                                            {
                                                next = true;
                                                neededItem = item.Value[0, 2];
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                        } while (validChoice == false);
                                        break;
                                    }
                                    else
                                    {
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.WriteLineText("                  I could make it " + item.Value[0, 1] + ", or " + item.Value[1, 1] + " if I had the right materials?");
                                        game.WriteLineText("                  1: " + UppercaseFirst(item.Value[0, 1]));
                                        game.WriteLineText("                  2: " + UppercaseFirst(item.Value[1, 1]));
                                        Thread.Sleep(800);
                                        bool validChoice = false;
                                        do
                                        {
                                            Console.Write("> ");
                                            string choice = Console.ReadLine().ToLower().Trim();
                                            if (choice.Length > 80) //makes input max of 80 chars
                                            {
                                                double textlength = choice.Length;
                                                for (int i = 80; i <= textlength; i += 80)
                                                {
                                                    Console.CursorTop -= 1;
                                                    Console.Write(new string(' ', Console.WindowWidth));
                                                    Console.CursorTop -= 1;
                                                }
                                                choice = choice.Remove(80);
                                            }
                                            if (choice == "1" || choice == item.Value[0, 1].ToLower())
                                            {
                                                neededItem = item.Value[0, 2];
                                                validChoice = true;
                                            }
                                            else if (choice == "2" || choice == item.Value[1, 1].ToLower())
                                            {
                                                neededItem = item.Value[1, 2];
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.CursorTop -= 1;
                                                Console.Write(new string(' ', Console.WindowWidth));
                                                Console.CursorTop -= 1;
                                            }
                                        } while (validChoice == false);
                                        next = true;
                                        break;
                                    }
                                }
                            }
                            if (next == true)
                            {
                                bool validChoice = false;
                                if (game.torchOn == false)
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                else if (game.torchOn == true)
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                game.WriteLineText("                  I would need a " + UppercaseFirst(neededItem) + " for that, do you have one?");
                                Thread.Sleep(800);
                                do
                                {
                                    Console.Write("> ");
                                    string input3 = Console.ReadLine().ToLower().Trim();
                                    if (input3.Length > 80) //makes input max of 80 chars
                                    {
                                        double textlength = input3.Length;
                                        for (int i = 80; i <= textlength; i += 80)
                                        {
                                            Console.CursorTop -= 1;
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.CursorTop -= 1;
                                        }
                                        input3 = input3.Remove(80);
                                    }
                                    if (input3 == "no" || input3 == "n")
                                    {
                                        game.itemChoice = neededItem;
                                        game.referenceCurrentItem();
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.WriteLineText("                  I can't do anything without it. But I heard you can find it " + game.examItem.weaponArmourLocation);
                                        Thread.Sleep(800);
                                        validChoice = true;
                                        validBlacksmithInput = true;
                                    }
                                    else if (input3 == "yes" || input3 == "y")
                                    {
                                        if (game.inventory.dictionary.ContainsKey(neededItem))
                                        {
                                            game.NPCConvStage = 5;
                                            game.NPCTALK();
                                            Item currentItem = game.examItem;
                                            game.itemChoice = neededItem;
                                            game.referenceCurrentItem();
                                            currentItem.weaponstatName = game.examItem.weaponstatName;
                                            currentItem.itemStrengthBonus += game.examItem.itemStrengthBonus;
                                            currentItem.itemSpeedBonus += game.examItem.itemSpeedBonus;
                                            currentItem.itemDefenseBonus += game.examItem.itemDefenseBonus;
                                            currentItem.itemCharismaBonus += game.examItem.itemCharismaBonus;
                                            currentItem.itemHPGain += game.examItem.itemHPGain;
                                            currentItem.itemHitGain += game.examItem.itemHitGain;
                                            game.inventory.dictionary.TryGetValue(neededItem, out game.currentCount);
                                            game.inventory.dictionary[neededItem] = game.currentCount - 1;
                                            game.inventory.dictionary.TryGetValue(neededItem, out game.currentCount); //removes any 0 value items
                                            if (game.currentCount == 0)
                                                game.inventory.dictionary.Remove(neededItem);
                                            game.WriteLineText("                  All finished. Here is your new " + UppercaseFirst(currentItem.weaponelementName) + " " + UppercaseFirst(currentItem.itemName) + " of " + UppercaseFirst(currentItem.weaponstatName));
                                            Thread.Sleep(1000);
                                            validChoice = true;
                                        }
                                        else
                                        {
                                            game.NPCConvStage = 6;
                                            game.NPCTALK();
                                            validChoice = true;
                                            validBlacksmithInput = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.CursorTop -= 1;
                                        Console.Write(new string(' ', Console.WindowWidth));
                                        Console.CursorTop -= 2;
                                        game.WriteLineText("                  I would need a " + UppercaseFirst(neededItem) + " for that, do you have one?");
                                        Thread.Sleep(800);
                                    }
                                } while (validChoice == false);
                            }
                        }
                    }
                    else if (blacksmithInput == "downgrade")
                    {
                        game.NPCConvStage = 7;
                        game.NPCTALK();
                        validBlacksmithInput = true;
                        List<string> currentWeaponKeys = new List<string>();
                        currentWeaponKeys.Clear();
                        foreach (KeyValuePair<string, int> item in game.inventory.dictionary)
                        {
                            game.itemChoice = item.Key;
                            game.referenceCurrentItem();
                            if (game.examItem.itemType == "weapon" || game.examItem.itemType == "shield")
                                currentWeaponKeys.Add(item.Key);
                        }
                        for (int i = 0; i < currentWeaponKeys.Count; i++)
                        {
                            game.itemChoice = currentWeaponKeys[i];
                            game.referenceCurrentItem();
                            game.WriteLineText((i + 1) + ": " + UppercaseFirst(currentWeaponKeys[i]) + " [" + UppercaseFirst(game.examItem.weaponelementName) + " " + UppercaseFirst(game.examItem.itemName) + " of " + UppercaseFirst(game.examItem.weaponstatName) + "]");
                        }
                        bool validWeaponGraftChoice = false;
                        do
                        {
                            Console.Write("> ");
                            string weaponGraftChoice = Console.ReadLine().ToLower().Trim();
                            if (weaponGraftChoice.Length > 80) //makes input max of 80 chars
                            {
                                double textlength = weaponGraftChoice.Length;
                                for (int i = 80; i <= textlength; i += 80)
                                {
                                    Console.CursorTop -= 1;
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.CursorTop -= 1;
                                }
                                weaponGraftChoice = weaponGraftChoice.Remove(80);
                            }
                            if (weaponGraftChoice == "back" || weaponGraftChoice == "exit" || weaponGraftChoice == "goodbye" || weaponGraftChoice == "bye")
                            {
                                game.NPCConvStage = 3;
                                game.NPCTALK();
                                validWeaponGraftChoice = true;
                                exit = true;
                                validBlacksmithInput = true;
                                break;
                            }
                            else if (string.IsNullOrEmpty(weaponGraftChoice) || weaponGraftChoice != "1" && weaponGraftChoice != "2" && weaponGraftChoice != "3" && weaponGraftChoice != "4" && weaponGraftChoice != "5" && weaponGraftChoice != "6" && weaponGraftChoice != "7" && weaponGraftChoice != "8" && weaponGraftChoice != "9" && weaponGraftChoice != "10" && weaponGraftChoice != "11" && weaponGraftChoice != "12" && weaponGraftChoice != "13" && weaponGraftChoice != "14" && weaponGraftChoice != "15" && weaponGraftChoice != "16" && weaponGraftChoice != "17" && weaponGraftChoice != "18" && weaponGraftChoice != "19" && weaponGraftChoice != "20" || Convert.ToInt16(weaponGraftChoice) > currentWeaponKeys.Count)
                            {
                                game.NPCConvStage = 2;
                                game.NPCTALK();
                                for (int i = 0; i < currentWeaponKeys.Count; i++)
                                {
                                    game.itemChoice = currentWeaponKeys[i];
                                    game.referenceCurrentItem();
                                    game.WriteLineText((i + 1) + ": " + UppercaseFirst(currentWeaponKeys[i]) + " [" + UppercaseFirst(game.examItem.weaponelementName) + " " + UppercaseFirst(game.examItem.itemName) + " of " + UppercaseFirst(game.examItem.weaponstatName) + "]");
                                }
                            }
                            else
                            {
                                int weaponChoiceInt = Convert.ToInt16(weaponGraftChoice);
                                for (int i = 1; i < (currentWeaponKeys.Count + 1); i++)
                                {
                                    if (weaponChoiceInt == i)
                                    {
                                        if (game.torchOn == false)
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        else if (game.torchOn == true)
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        game.itemChoice = currentWeaponKeys[i - 1];
                                        game.referenceCurrentItem();
                                        game.currentGraftWeapon = game.examItem.itemName;
                                        validWeaponGraftChoice = true;
                                    }
                                }
                            }
                        } while (validBlacksmithInput == false && exit == false);
                        if (exit == true)
                            break;
                        game.WriteLineText("                  This will reset all modifications to your " + UppercaseFirst(game.currentGraftWeapon) + ", is that what you want?");
                        bool validChoice = false;
                        do
                        {
                            Console.Write("> ");
                            string choice = Console.ReadLine().ToLower().Trim();
                            if (choice.Length > 80) //makes input max of 80 chars
                            {
                                double textlength = choice.Length;
                                for (int i = 80; i <= textlength; i += 80)
                                {
                                    Console.CursorTop -= 1;
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.CursorTop -= 1;
                                }
                                choice = choice.Remove(80);
                            }
                            if (choice == "no" || choice == "n")
                            {
                                game.NPCConvStage = 3;
                                game.NPCTALK();
                                validChoice = true;
                                validBlacksmithInput = true;
                            }
                            else if (choice == "yes" || choice == "y")
                            {
                                game.NPCConvStage = 8;
                                game.NPCTALK();
                                if (game.examItem == game.Stick)
                                {
                                    game.Stick.weaponstatName = "beginnnings";
                                    game.Stick.weaponelementName = "neutral";
                                    game.Stick.itemStrengthBonus = 2;
                                    game.Stick.itemSpeedBonus = 0;
                                    game.Stick.itemDefenseBonus = 0;
                                    game.Stick.itemCharismaBonus = 0;
                                    game.Stick.itemHPGain = 0;
                                    game.Stick.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Sword)
                                {
                                    game.Sword.weaponstatName = "beginnnings";
                                    game.Sword.weaponelementName = "neutral";
                                    game.Sword.itemStrengthBonus = 5;
                                    game.Sword.itemSpeedBonus = -2;
                                    game.Sword.itemDefenseBonus = 0;
                                    game.Sword.itemCharismaBonus = 0;
                                    game.Sword.itemHPGain = 0;
                                    game.Sword.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Axe)
                                {
                                    game.Axe.weaponstatName = "beginnnings";
                                    game.Axe.weaponelementName = "neutral";
                                    game.Axe.itemStrengthBonus = 7;
                                    game.Axe.itemSpeedBonus = -4;
                                    game.Axe.itemDefenseBonus = 0;
                                    game.Axe.itemCharismaBonus = 0;
                                    game.Axe.itemHPGain = 0;
                                    game.Axe.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Mace)
                                {
                                    game.Mace.weaponstatName = "beginnnings";
                                    game.Mace.weaponelementName = "neutral";
                                    game.Mace.itemStrengthBonus = 6;
                                    game.Mace.itemSpeedBonus = -3;
                                    game.Mace.itemDefenseBonus = 0;
                                    game.Mace.itemCharismaBonus = 0;
                                    game.Mace.itemHPGain = 0;
                                    game.Mace.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Spear)
                                {
                                    game.Spear.weaponstatName = "beginnnings";
                                    game.Spear.weaponelementName = "neutral";
                                    game.Spear.itemStrengthBonus = 4;
                                    game.Spear.itemSpeedBonus = 1;
                                    game.Spear.itemDefenseBonus = 0;
                                    game.Spear.itemCharismaBonus = 0;
                                    game.Spear.itemHPGain = 0;
                                    game.Spear.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Bow)
                                {
                                    game.Bow.weaponstatName = "beginnnings";
                                    game.Bow.weaponelementName = "neutral";
                                    game.Bow.itemStrengthBonus = 3;
                                    game.Bow.itemSpeedBonus = 3;
                                    game.Bow.itemDefenseBonus = 0;
                                    game.Bow.itemCharismaBonus = 0;
                                    game.Bow.itemHPGain = 0;
                                    game.Bow.itemHitGain = 0;
                                }
                                else if (game.examItem == game.Shield)
                                {
                                    game.Shield.weaponstatName = "beginnnings";
                                    game.Shield.weaponelementName = "neutral";
                                    game.Shield.itemStrengthBonus = 0;
                                    game.Shield.itemSpeedBonus = 0;
                                    game.Shield.itemDefenseBonus = 5;
                                    game.Shield.itemCharismaBonus = 0;
                                    game.Shield.itemHPGain = 0;
                                    game.Shield.itemHitGain = 0;
                                }
                                game.NPCConvStage = 9;
                                game.NPCTALK();
                                validChoice = true;
                                validBlacksmithInput = true;
                            }
                            else
                            {
                                Console.CursorTop -= 1;
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.CursorTop -= 2;
                                game.WriteLineText("                  This will reset all modifications to your " + UppercaseFirst(game.currentGraftWeapon) + ", is that what you want?");
                            }
                        } while (validChoice == false);
                    }
                    else if (blacksmithInput == "never mind" || blacksmithInput == "no" || blacksmithInput == "leave" || blacksmithInput == "exit" || blacksmithInput == "go away")
                    {
                        game.NPCConvStage = 3;
                        game.NPCTALK();
                        validBlacksmithInput = true;
                    }
                    else
                    {
                        if (game.torchOn == false)
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        else if (game.torchOn == true)
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.CursorTop -= 1;
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.CursorTop -= 6;
                        game.WriteLineText("                  Hi there, would you like me to upgrade your weapons and armour? Or do you need to downgrade them? \n1:Upgrade\n2:Dowgrade\n3:Never mind");
                    }
                } while (validBlacksmithInput == false);
                Console.ForegroundColor = game.foregroundColour;
            }
        }
    }
}