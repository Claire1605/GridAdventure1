using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace GridAdventure1
{
    [JsonObject]
    public class WorldMap
    {
        public string mapName; //name of map, e.g. Rifton
        public int mapLocation; //location of map within global map, e.g. Rifton is 0
        public bool mapAccessible; //can you get to that map at the moment?
        public bool mapVisited; //have you previously visited this map?
        public int encounterRate; //(1 in x chance of battle)
        public string cellName; //name of cell, e.g. Your House
        public int cellLocation; //location of cell within map
        public bool accessible; //can you get to that cell?
        public bool visited; //have you previously visited that cell?
        public bool draw = true; //should this be drawn in the map view?
        public int lookArrayNumber = 1; //which variation of 'look' is written?
        public string[] look = new string[6] { "", "", "", "", "", "" }; //array of 'look' variations
        public List<string> gridItems; //basic items found in locations
        public string gridDescription = ""; //e.g. To the North is ...
        public bool secondLook = false; //will second look items/text be written?
        public string regexSecondLevelLook = ""; //regex phrases for looking at second level/take newer items - use for hidden items
        public string secondLevelLookDescription = ""; //used for hidden items/items not apparent from first 'look'
        public List<string> secondLevelLookGridItems = new List<string>() { "" }; //items found in second look
        public Dictionary<string, string> deeperLook = new Dictionary<string, string>(); // use for non-item text and flavour text
        public string regexDeeperLookItems =  "";// use for non-item text
        public List<string> digItems = new List<string>() { "" }; //items found by digging
        public bool Gateway; //leads to another map
        public int newMap; //location of new map from gateway
        public int newLocation; //location of new cell from gateway
        public bool torchVisible; //if location can only be seen with a torch
        public bool cave; //is this location a cave?
        public bool boatUpperDeck; //used on boat to separate boat locations on same map
        public bool boatMiddleDeck; //used on boat to separate boat locations on same map
        public bool boatLowerDeck; //used on boat to separate boat locations on same map
        public bool ellondite; //is there ellondite here?
        public bool shop = false; //is this location a shop?
        [JsonIgnore]
        public WorldMap[][] WorldMapCells = new WorldMap[25][];

        public void CreateMaps()
        {
            string line;
            FileStream aFile = new FileStream(Environment.CurrentDirectory + "\\Maps.csv", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);

            while ((line = sr.ReadLine()) != null)
            {
                line = sr.ReadLine();//start after first row..
                if (line.Contains("ENDFILE"))
                    break;

                for (int i = 0; i < 25; i++)
                {
                    WorldMapCells[i] = new WorldMap[100];
                    for (int j = 0; j < 100; j++)
                    {
                        WorldMapCells[i][j] = new WorldMap();

                        string[] array = line.Split(',');
                        WorldMapCells[i][j].mapName = array[0];
                        WorldMapCells[i][j].mapLocation = Convert.ToInt16(array[1]);
                        WorldMapCells[i][j].mapAccessible = Convert.ToBoolean(array[2]);
                        WorldMapCells[i][j].mapVisited = Convert.ToBoolean(array[3]);
                        WorldMapCells[i][j].encounterRate = Convert.ToInt16(array[4]);
                        WorldMapCells[i][j].cellName = array[5];
                        WorldMapCells[i][j].cellLocation = Convert.ToInt16(array[6]);
                        WorldMapCells[i][j].accessible = Convert.ToBoolean(array[7]);
                        WorldMapCells[i][j].gridDescription = array[8];
                        WorldMapCells[i][j].look = array[9].Split(':');
                        WorldMapCells[i][j].gridItems = array[10].Split(':').ToList();
                        WorldMapCells[i][j].regexSecondLevelLook = array[11]; //regex for secondLevelLookDescription
                        if (array[11] != "")
                        {
                            string temp = "";
                            string[] regexSplit = array[11].Split(':');
                            foreach (var item in regexSplit)
                            {
                                temp += "\\b" + item + "\\b|";
                            }
                            temp = temp.Remove(temp.Length - 1);
                            WorldMapCells[i][j].regexSecondLevelLook = temp;
                        }
                        WorldMapCells[i][j].secondLevelLookDescription = array[12];
                        WorldMapCells[i][j].secondLevelLookGridItems = array[13].Split(':').ToList();
                        WorldMapCells[i][j].regexDeeperLookItems = "";
                        if (array[14] != "")
                        {
                            string temp = "";
                            string[] regexSplit = array[14].Split(':');
                            foreach (var item in regexSplit)
                            {
                                temp += "\\b" + item + "\\b|";
                            }
                            temp = temp.Remove(temp.Length -1);
                            WorldMapCells[i][j].regexDeeperLookItems += temp;
                        }
                        if (array[15] != "")
                            WorldMapCells[i][j].deeperLook = array[15].Split(':').Select(part => part.Split('_')).ToDictionary(sp => sp[0], sp => sp[1]);
                        WorldMapCells[i][j].digItems = array[16].Split(':').ToList();
                        WorldMapCells[i][j].Gateway = Convert.ToBoolean(array[17]);
                        WorldMapCells[i][j].newMap = Convert.ToInt16(array[18]);
                        WorldMapCells[i][j].newLocation = Convert.ToInt16(array[19]);
                        WorldMapCells[i][j].torchVisible = Convert.ToBoolean(array[20]);
                        WorldMapCells[i][j].cave = Convert.ToBoolean(array[21]);
                        WorldMapCells[i][j].boatUpperDeck = Convert.ToBoolean(array[22]);
                        WorldMapCells[i][j].boatMiddleDeck = Convert.ToBoolean(array[23]);
                        WorldMapCells[i][j].boatLowerDeck = Convert.ToBoolean(array[24]);
                        WorldMapCells[i][j].ellondite = Convert.ToBoolean(array[25]);
                        WorldMapCells[i][j].shop = Convert.ToBoolean(array[26]);
                        WorldMapCells[i][j].secondLook = Convert.ToBoolean(array[27]);
                        WorldMapCells[i][j].visited = Convert.ToBoolean(array[28]);
                        WorldMapCells[i][j].draw = Convert.ToBoolean(array[29]);
                        WorldMapCells[i][j].lookArrayNumber = Convert.ToInt16(array[30]); //number of lines different? gets to line 24 when should be on 99 on last row..

                        line = sr.ReadLine();
                    }
                }
            }
            sr.Close();
        }
    }

    //public class KarstBayCaves1Map : WorldMap
    //{
    //    public KarstBayCaves1Map()
    //    {
    //        mapName = "karstbay caves upper level";
    //        mapLocation = 11;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //        cave = true;
    //    }
    //}
    //public class KarstBayCaves1Map0 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map1 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map2 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map3 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map4 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map5 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map6 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map7 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map8 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map9 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map10 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map11 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map11()
    //    {
    //        cellName = "";
    //        cellLocation = 11;
    //        accessible = false;
    //        visited = false;
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 64;
    //    }
    //}
    //public class KarstBayCaves1Map12 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map12()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and a slope leading up to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map13 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map14 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map15 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map16 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map17 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map18 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map19 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map20 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map21 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map22 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map22()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map23 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map24 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map25 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map25()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map26 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map26()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "It appears to be a dead end. The path extends back to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map27 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map28 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map29 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map30 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map31 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map31()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map32 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map32()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map33 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map34 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map35 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map35()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north and to the south";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class KarstBayCaves1Map36 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map37 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map38 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map39 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map40 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map41 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map41()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map42 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map42()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map43 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map43()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map44 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map44()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map45 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map45()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map46 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map47 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map47()
    //    {
    //        cellName = "";
    //        cellLocation = 47;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 46;
    //    }
    //}
    //public class KarstBayCaves1Map48 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map49 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map50 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map51 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map52 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map52()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map53 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map53()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map54 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map54()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map55 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map56 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map57 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map57()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and a slope leading down to the north";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class KarstBayCaves1Map58 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map59 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map60 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map61 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map62 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map62()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map63 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map63()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map64 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map64()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map65 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map65()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to west, and to the east";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class KarstBayCaves1Map66 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map66()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map67 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map67()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the west";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class KarstBayCaves1Map68 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map69 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map70 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map71 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map71()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 71;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map72 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map72()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map73 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map74 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map75 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map76 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map77 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map78 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map79 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map80 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map81 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map81()
    //    {
    //        cellName = "in the upper level of Karstbay caves";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and a slope leading down to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves1Map82 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map83 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map84 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map85 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map86 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map87 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map88 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map89 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map90 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map91 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map91()
    //    {
    //        cellName = "";
    //        cellLocation = 91;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 81;
    //    }
    //}
    //public class KarstBayCaves1Map92 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map93 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map94 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map95 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map96 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map97 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map98 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves1Map99 : KarstBayCaves1Map
    //{
    //    public KarstBayCaves1Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class KarstBayCaves2Map : WorldMap
    //{
    //    public KarstBayCaves2Map()
    //    {
    //        mapName = "karstbay caves middle level";
    //        mapLocation = 12;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //        cave = true;
    //    }
    //}
    //public class KarstBayCaves2Map0 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map1 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map2 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map3 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map4 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map5 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map6 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map7 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map8 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map9 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map10 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map11 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map12 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map12()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the east, and a slope leading down to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map13 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map13()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map14 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map14()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map15 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map16 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map17 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map18 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map19 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map20 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map21 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map22 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map22()
    //    {
    //        cellName = "";
    //        cellLocation = 22;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 13;
    //        newLocation = 12;
    //    }
    //}
    //public class KarstBayCaves2Map23 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map24 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map24()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map25 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map25()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "It appears to be a dead end. You can see a path extending back to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map26 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map27 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map28 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map29 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map30 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map31 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map32 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map33 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map33()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map34 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map34()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map35 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map36 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map37 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map38 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map39 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map40 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map41 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map42 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map42()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map43 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map43()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map44 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map44()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map45 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map45()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west, and to the east. There is a slope leading down to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map46 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map46()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west. There is a slope leading up to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map47 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map47()
    //    {
    //        cellName = "";
    //        cellLocation = 47;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 11;
    //        newLocation = 57;
    //    }
    //}
    //public class KarstBayCaves2Map48 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map49 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map50 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map51 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map52 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map52()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "It appears to be a dead end. You can see a path extending back to the north";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map53 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map54 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map55 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map55()
    //    {
    //        cellName = "";
    //        cellLocation = 55;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 13;
    //        newLocation = 65;
    //    }
    //}
    //public class KarstBayCaves2Map56 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map57 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map58 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map59 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map60 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map61 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map62 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map63 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map64 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map65 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map66 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map67 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map68 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map69 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map70 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map71 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map71()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 71;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "It appears to be a dead end. You can see a path extending back to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map72 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map73 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map74 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map75 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map76 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map76()
    //    {
    //        cellName = "";
    //        cellLocation = 76;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 13;
    //        newLocation = 86;
    //    }
    //}
    //public class KarstBayCaves2Map77 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map77()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east. There is a slope leading down to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map78 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map78()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map79 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map80 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map81 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map81()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the east. There is a slope leading up to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map82 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map82()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the west. There is a slope leading down to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map83 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map83()
    //    {
    //        cellName = "";
    //        cellLocation = 83;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 13;
    //        newLocation = 82;
    //    }
    //}
    //public class KarstBayCaves2Map84 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map85 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map86 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map87 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map87()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map88 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map88()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map89 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map90 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map91 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map91()
    //    {
    //        cellName = "";
    //        cellLocation = 91;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 11;
    //        newLocation = 81;
    //    }
    //}
    //public class KarstBayCaves2Map92 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map92()
    //    {
    //        cellName = "in the middle level of Karstbay caves";
    //        cellLocation = 92;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north. There is a slope leading up to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves2Map93 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map94 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map95 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map96 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map97 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map98 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves2Map99 : KarstBayCaves2Map
    //{
    //    public KarstBayCaves2Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class KarstBayCaves3Map : WorldMap
    //{
    //    public KarstBayCaves3Map()
    //    {
    //        mapName = "karstbay caves lower level";
    //        mapLocation = 13;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //        cave = true;
    //    }
    //}
    //public class KarstBayCaves3Map0 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map1 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map2 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map3 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map4 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map5 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map6 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map7 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map8 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map9 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map10 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map11 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map12 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map12()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the east. There is a slope leading up to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map13 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map13()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map14 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map14()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map15 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map15()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map16 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map17 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map18 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map19 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map20 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map21 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map22 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map22()
    //    {
    //        cellName = "";
    //        cellLocation = 22;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 12;
    //    }
    //}
    //public class KarstBayCaves3Map23 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map23()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, and to the east. There is a slope leading up to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map24 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map24()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the south, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map25 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map25()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map26 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map26()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "It appears to be a dead end. You can see the path extending back to the west";
    //        //digItemsAvailable = true;
    //        digItems = new List<string> { "ellondite, ellondite" };
    //        gridItems = new List<string> { "", "", };
    //        ellondite = true;
    //    }
    //}
    //public class KarstBayCaves3Map27 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map28 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map29 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map30 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map31 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map32 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map33 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map33()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map34 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map34()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map35 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map36 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map37 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map38 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map39 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map40 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map41 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map42 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map43 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map44 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map45 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map46 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map47 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map48 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map49 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map50 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map51 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map52 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map53 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map54 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map55 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map55()
    //    {
    //        cellName = "";
    //        cellLocation = 55;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 45;
    //    }
    //}
    //public class KarstBayCaves3Map56 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map57 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map58 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map59 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map60 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map61 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map62 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map63 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map64 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map64()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map65 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map65()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west. There is a slope leading up to the north";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class KarstBayCaves3Map66 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map67 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map68 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map69 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map70 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map71 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map72 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map73 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map74 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map74()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the south";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map75 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map76 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map76()
    //    {
    //        cellName = "";
    //        cellLocation = 76;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 77;
    //    }
    //}
    //public class KarstBayCaves3Map77 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map78 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map79 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map80 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map81 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map81()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map82 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map82()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south, and to the west. There is a slope leading up to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map83 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map83()
    //    {
    //        cellName = "";
    //        cellLocation = 83;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 12;
    //        newLocation = 82;
    //    }
    //}
    //public class KarstBayCaves3Map84 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map84()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the south. There is a slope leading up to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map85 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map86 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map86()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the south. There is a slope leading up to the north";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map87 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map88 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map89 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map90 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map91 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map91()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 91;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map92 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map92()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 92;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map93 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map93()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 93;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west, and to the east. There is a slope leading up to the north";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map94 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map94()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 94;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map95 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map95()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 95;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the west, and to the east";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map96 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map96()
    //    {
    //        cellName = "in the lower level of Karstbay caves";
    //        cellLocation = 96;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "You can see a path extending to the north, and to the west";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class KarstBayCaves3Map97 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map98 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class KarstBayCaves3Map99 : KarstBayCaves3Map
    //{
    //    public KarstBayCaves3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class FireArea1Map : WorldMap
    //{
    //    public FireArea1Map()
    //    {
    //        mapName = "fire area 1";
    //        mapLocation = 6;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class FireArea1Map0 : FireArea1Map
    //{
    //    public FireArea1Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map1 : FireArea1Map
    //{
    //    public FireArea1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map2 : FireArea1Map
    //{
    //    public FireArea1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map3 : FireArea1Map
    //{
    //    public FireArea1Map3()
    //    {
    //        cellName = "firearea1 4";
    //        cellLocation = 3;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map4 : FireArea1Map
    //{
    //    public FireArea1Map4()
    //    {
    //        cellName = "firearea1 6";
    //        cellLocation = 4;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map5 : FireArea1Map
    //{
    //    public FireArea1Map5()
    //    {
    //        cellName = "firearea1 8";
    //        cellLocation = 5;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map6 : FireArea1Map
    //{
    //    public FireArea1Map6()
    //    {
    //        cellName = "firearea1 10";
    //        cellLocation = 6;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map7 : FireArea1Map
    //{
    //    public FireArea1Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map8 : FireArea1Map
    //{
    //    public FireArea1Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map9 : FireArea1Map
    //{
    //    public FireArea1Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map10 : FireArea1Map
    //{
    //    public FireArea1Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map11 : FireArea1Map
    //{
    //    public FireArea1Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map12 : FireArea1Map
    //{
    //    public FireArea1Map12()
    //    {
    //        cellName = "firearea1 2";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map13 : FireArea1Map
    //{
    //    public FireArea1Map13()
    //    {
    //        cellName = "firearea1 5";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map14 : FireArea1Map
    //{
    //    public FireArea1Map14()
    //    {
    //        cellName = "firearea1 7";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map15 : FireArea1Map
    //{
    //    public FireArea1Map15()
    //    {
    //        cellName = "firearea1 9";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map16 : FireArea1Map
    //{
    //    public FireArea1Map16()
    //    {
    //        cellName = "firearea1 11";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map17 : FireArea1Map
    //{
    //    public FireArea1Map17()
    //    {
    //        cellName = "firearea1 18";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map18 : FireArea1Map
    //{
    //    public FireArea1Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map19 : FireArea1Map
    //{
    //    public FireArea1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map20 : FireArea1Map
    //{
    //    public FireArea1Map20()
    //    {
    //        cellName = "";
    //        cellLocation = 20;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 14;
    //        newLocation = 98;
    //    }
    //}
    //public class FireArea1Map21 : FireArea1Map
    //{
    //    public FireArea1Map21()
    //    {
    //        cellName = "firearea1 1";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map22 : FireArea1Map
    //{
    //    public FireArea1Map22()
    //    {
    //        cellName = "firearea1 3";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map23 : FireArea1Map
    //{
    //    public FireArea1Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map24 : FireArea1Map
    //{
    //    public FireArea1Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map25 : FireArea1Map
    //{
    //    public FireArea1Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map26 : FireArea1Map
    //{
    //    public FireArea1Map26()
    //    {
    //        cellName = "firearea1 12";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map27 : FireArea1Map
    //{
    //    public FireArea1Map27()
    //    {
    //        cellName = "firearea1 19";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map28 : FireArea1Map
    //{
    //    public FireArea1Map28()
    //    {
    //        cellName = "firearea1 25";
    //        cellLocation = 28;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" }; cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map29 : FireArea1Map
    //{
    //    public FireArea1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map30 : FireArea1Map
    //{
    //    public FireArea1Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map31 : FireArea1Map
    //{
    //    public FireArea1Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map32 : FireArea1Map
    //{
    //    public FireArea1Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map33 : FireArea1Map
    //{
    //    public FireArea1Map33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map34 : FireArea1Map
    //{
    //    public FireArea1Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map35 : FireArea1Map
    //{
    //    public FireArea1Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map36 : FireArea1Map
    //{
    //    public FireArea1Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map37 : FireArea1Map
    //{
    //    public FireArea1Map37()
    //    {
    //        cellName = "firearea1 20";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class FireArea1Map38 : FireArea1Map
    //{
    //    public FireArea1Map38()
    //    {
    //        cellName = "firearea1 26";
    //        cellLocation = 38;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map39 : FireArea1Map
    //{
    //    public FireArea1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map40 : FireArea1Map
    //{
    //    public FireArea1Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map41 : FireArea1Map
    //{
    //    public FireArea1Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map42 : FireArea1Map
    //{
    //    public FireArea1Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map43 : FireArea1Map
    //{
    //    public FireArea1Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map44 : FireArea1Map
    //{
    //    public FireArea1Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map45 : FireArea1Map
    //{
    //    public FireArea1Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map46 : FireArea1Map
    //{
    //    public FireArea1Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map47 : FireArea1Map
    //{
    //    public FireArea1Map47()
    //    {
    //        cellName = "firearea1 21";
    //        cellLocation = 47;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map48 : FireArea1Map
    //{
    //    public FireArea1Map48()
    //    {
    //        cellName = "firearea1 27";
    //        cellLocation = 48;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map49 : FireArea1Map
    //{
    //    public FireArea1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map50 : FireArea1Map
    //{
    //    public FireArea1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map51 : FireArea1Map
    //{
    //    public FireArea1Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map52 : FireArea1Map
    //{
    //    public FireArea1Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map53 : FireArea1Map
    //{
    //    public FireArea1Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map54 : FireArea1Map
    //{
    //    public FireArea1Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map55 : FireArea1Map
    //{
    //    public FireArea1Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map56 : FireArea1Map
    //{
    //    public FireArea1Map56()
    //    {
    //        cellName = "firearea1 13";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map57 : FireArea1Map
    //{
    //    public FireArea1Map57()
    //    {
    //        cellName = "firearea1 22";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class FireArea1Map58 : FireArea1Map
    //{
    //    public FireArea1Map58()
    //    {
    //        cellName = "firearea1 28";
    //        cellLocation = 58;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class FireArea1Map59 : FireArea1Map
    //{
    //    public FireArea1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map60 : FireArea1Map
    //{
    //    public FireArea1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map61 : FireArea1Map
    //{
    //    public FireArea1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map62 : FireArea1Map
    //{
    //    public FireArea1Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map63 : FireArea1Map
    //{
    //    public FireArea1Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map64 : FireArea1Map
    //{
    //    public FireArea1Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map65 : FireArea1Map
    //{
    //    public FireArea1Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map66 : FireArea1Map
    //{
    //    public FireArea1Map66()
    //    {
    //        cellName = "firearea1 14";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map67 : FireArea1Map
    //{
    //    public FireArea1Map67()
    //    {
    //        cellName = "firearea1 23";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class FireArea1Map68 : FireArea1Map
    //{
    //    public FireArea1Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map69 : FireArea1Map
    //{
    //    public FireArea1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map70 : FireArea1Map
    //{
    //    public FireArea1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map71 : FireArea1Map
    //{
    //    public FireArea1Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map72 : FireArea1Map
    //{
    //    public FireArea1Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map73 : FireArea1Map
    //{
    //    public FireArea1Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map74 : FireArea1Map
    //{
    //    public FireArea1Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map75 : FireArea1Map
    //{
    //    public FireArea1Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map76 : FireArea1Map
    //{
    //    public FireArea1Map76()
    //    {
    //        cellName = "firearea1 15";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map77 : FireArea1Map
    //{
    //    public FireArea1Map77()
    //    {
    //        cellName = "firearea1 24";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map78 : FireArea1Map
    //{
    //    public FireArea1Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map79 : FireArea1Map
    //{
    //    public FireArea1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map80 : FireArea1Map
    //{
    //    public FireArea1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map81 : FireArea1Map
    //{
    //    public FireArea1Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map82 : FireArea1Map
    //{
    //    public FireArea1Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map83 : FireArea1Map
    //{
    //    public FireArea1Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map84 : FireArea1Map
    //{
    //    public FireArea1Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map85 : FireArea1Map
    //{
    //    public FireArea1Map85()
    //    {
    //        cellName = "firearea1 17";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        firstVisit = true;
    //    }
    //}
    //public class FireArea1Map86 : FireArea1Map
    //{
    //    public FireArea1Map86()
    //    {
    //        cellName = "firearea1 16";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea1Map87 : FireArea1Map
    //{
    //    public FireArea1Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map88 : FireArea1Map
    //{
    //    public FireArea1Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map89 : FireArea1Map
    //{
    //    public FireArea1Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map90 : FireArea1Map
    //{
    //    public FireArea1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map91 : FireArea1Map
    //{
    //    public FireArea1Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map92 : FireArea1Map
    //{
    //    public FireArea1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map93 : FireArea1Map
    //{
    //    public FireArea1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map94 : FireArea1Map
    //{
    //    public FireArea1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map95 : FireArea1Map
    //{
    //    public FireArea1Map95()
    //    {
    //        cellName = "";
    //        cellLocation = 95;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 15;
    //    }
    //}
    //public class FireArea1Map96 : FireArea1Map
    //{
    //    public FireArea1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map97 : FireArea1Map
    //{
    //    public FireArea1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map98 : FireArea1Map
    //{
    //    public FireArea1Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class FireArea1Map99 : FireArea1Map
    //{
    //    public FireArea1Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class FireArea2Map : WorldMap
    //{
    //    public FireArea2Map()
    //    {
    //        mapName = "fire area 2";
    //        mapLocation = 14;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class FireArea2Map0 : FireArea2Map
    //{
    //    public FireArea2Map0()
    //    {
    //        cellName = "";
    //        cellLocation = 0;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 15;
    //        newLocation = 96;

    //    }
    //}
    //public class FireArea2Map1 : FireArea2Map
    //{
    //    public FireArea2Map1()
    //    {
    //        cellName = "FireArea2 1";
    //        cellLocation = 1;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map2 : FireArea2Map
    //{
    //    public FireArea2Map2()
    //    {
    //        cellName = "FireArea2 2";
    //        cellLocation = 2;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map3 : FireArea2Map
    //{
    //    public FireArea2Map3()
    //    {
    //        cellName = "FireArea2 3";
    //        cellLocation = 3;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map4 : FireArea2Map
    //{
    //    public FireArea2Map4()
    //    {
    //        cellName = "FireArea2 4";
    //        cellLocation = 4;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map5 : FireArea2Map
    //{
    //    public FireArea2Map5()
    //    {
    //        cellName = "FireArea2 5";
    //        cellLocation = 5;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map6 : FireArea2Map
    //{
    //    public FireArea2Map6()
    //    {
    //        cellName = "FireArea2 6";
    //        cellLocation = 6;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map7 : FireArea2Map
    //{
    //    public FireArea2Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map8 : FireArea2Map
    //{
    //    public FireArea2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map9 : FireArea2Map
    //{
    //    public FireArea2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map10 : FireArea2Map
    //{
    //    public FireArea2Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map11 : FireArea2Map
    //{
    //    public FireArea2Map11()
    //    {
    //        cellName = "FireArea2 7";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map12 : FireArea2Map
    //{
    //    public FireArea2Map12()
    //    {
    //        cellName = "FireArea2 8";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map13 : FireArea2Map
    //{
    //    public FireArea2Map13()
    //    {
    //        cellName = "FireArea2 9";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map14 : FireArea2Map
    //{
    //    public FireArea2Map14()
    //    {
    //        cellName = "FireArea2 10";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map15 : FireArea2Map
    //{
    //    public FireArea2Map15()
    //    {
    //        cellName = "FireArea2 11";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map16 : FireArea2Map
    //{
    //    public FireArea2Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map17 : FireArea2Map
    //{
    //    public FireArea2Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map18 : FireArea2Map
    //{
    //    public FireArea2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map19 : FireArea2Map
    //{
    //    public FireArea2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map20 : FireArea2Map
    //{
    //    public FireArea2Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map21 : FireArea2Map
    //{
    //    public FireArea2Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map22 : FireArea2Map
    //{
    //    public FireArea2Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = true;
    //    }
    //}
    //public class FireArea2Map23 : FireArea2Map
    //{
    //    public FireArea2Map23()
    //    {
    //        cellName = "FireArea2 12";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map24 : FireArea2Map
    //{
    //    public FireArea2Map24()
    //    {
    //        cellName = "FireArea2 13";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map25 : FireArea2Map
    //{
    //    public FireArea2Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map26 : FireArea2Map
    //{
    //    public FireArea2Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map27 : FireArea2Map
    //{
    //    public FireArea2Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map28 : FireArea2Map
    //{
    //    public FireArea2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map29 : FireArea2Map
    //{
    //    public FireArea2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map30 : FireArea2Map
    //{
    //    public FireArea2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map31 : FireArea2Map
    //{
    //    public FireArea2Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map32 : FireArea2Map
    //{
    //    public FireArea2Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map33 : FireArea2Map
    //{
    //    public FireArea2Map33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map34 : FireArea2Map
    //{
    //    public FireArea2Map34()
    //    {
    //        cellName = "FireArea2 14";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map35 : FireArea2Map
    //{
    //    public FireArea2Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map36 : FireArea2Map
    //{
    //    public FireArea2Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map37 : FireArea2Map
    //{
    //    public FireArea2Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map38 : FireArea2Map
    //{
    //    public FireArea2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map39 : FireArea2Map
    //{
    //    public FireArea2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map40 : FireArea2Map
    //{
    //    public FireArea2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map41 : FireArea2Map
    //{
    //    public FireArea2Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map42 : FireArea2Map
    //{
    //    public FireArea2Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map43 : FireArea2Map
    //{
    //    public FireArea2Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map44 : FireArea2Map
    //{
    //    public FireArea2Map44()
    //    {
    //        cellName = "FireArea2 15";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map45 : FireArea2Map
    //{
    //    public FireArea2Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map46 : FireArea2Map
    //{
    //    public FireArea2Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map47 : FireArea2Map
    //{
    //    public FireArea2Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map48 : FireArea2Map
    //{
    //    public FireArea2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map49 : FireArea2Map
    //{
    //    public FireArea2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map50 : FireArea2Map
    //{
    //    public FireArea2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map51 : FireArea2Map
    //{
    //    public FireArea2Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map52 : FireArea2Map
    //{
    //    public FireArea2Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map53 : FireArea2Map
    //{
    //    public FireArea2Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map54 : FireArea2Map
    //{
    //    public FireArea2Map54()
    //    {
    //        cellName = "FireArea2 16";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map55 : FireArea2Map
    //{
    //    public FireArea2Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map56 : FireArea2Map
    //{
    //    public FireArea2Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map57 : FireArea2Map
    //{
    //    public FireArea2Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map58 : FireArea2Map
    //{
    //    public FireArea2Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map59 : FireArea2Map
    //{
    //    public FireArea2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map60 : FireArea2Map
    //{
    //    public FireArea2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map61 : FireArea2Map
    //{
    //    public FireArea2Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map62 : FireArea2Map
    //{
    //    public FireArea2Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map63 : FireArea2Map
    //{
    //    public FireArea2Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map64 : FireArea2Map
    //{
    //    public FireArea2Map64()
    //    {
    //        cellName = "FireArea2 17";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map65 : FireArea2Map
    //{
    //    public FireArea2Map65()
    //    {
    //        cellName = "FireArea2 18";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map66 : FireArea2Map
    //{
    //    public FireArea2Map66()
    //    {
    //        cellName = "FireArea2 19";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map67 : FireArea2Map
    //{
    //    public FireArea2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map68 : FireArea2Map
    //{
    //    public FireArea2Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map69 : FireArea2Map
    //{
    //    public FireArea2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map70 : FireArea2Map
    //{
    //    public FireArea2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map71 : FireArea2Map
    //{
    //    public FireArea2Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map72 : FireArea2Map
    //{
    //    public FireArea2Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map73 : FireArea2Map
    //{
    //    public FireArea2Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map74 : FireArea2Map
    //{
    //    public FireArea2Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map75 : FireArea2Map
    //{
    //    public FireArea2Map75()
    //    {
    //        cellName = "FireArea2 20";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map76 : FireArea2Map
    //{
    //    public FireArea2Map76()
    //    {
    //        cellName = "FireArea2 21";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map77 : FireArea2Map
    //{
    //    public FireArea2Map77()
    //    {
    //        cellName = "FireArea2 22";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map78 : FireArea2Map
    //{
    //    public FireArea2Map78()
    //    {
    //        cellName = "FireArea2 23";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map79 : FireArea2Map
    //{
    //    public FireArea2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map80 : FireArea2Map
    //{
    //    public FireArea2Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map81 : FireArea2Map
    //{
    //    public FireArea2Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map82 : FireArea2Map
    //{
    //    public FireArea2Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map83 : FireArea2Map
    //{
    //    public FireArea2Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map84 : FireArea2Map
    //{
    //    public FireArea2Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map85 : FireArea2Map
    //{
    //    public FireArea2Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map86 : FireArea2Map
    //{
    //    public FireArea2Map86()
    //    {
    //        cellName = "FireArea2 24";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map87 : FireArea2Map
    //{
    //    public FireArea2Map87()
    //    {
    //        cellName = "FireArea2 25";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map88 : FireArea2Map
    //{
    //    public FireArea2Map88()
    //    {
    //        cellName = "FireArea2 26";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map89 : FireArea2Map
    //{
    //    public FireArea2Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map90 : FireArea2Map
    //{
    //    public FireArea2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map91 : FireArea2Map
    //{
    //    public FireArea2Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map92 : FireArea2Map
    //{
    //    public FireArea2Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map93 : FireArea2Map
    //{
    //    public FireArea2Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map94 : FireArea2Map
    //{
    //    public FireArea2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map95 : FireArea2Map
    //{
    //    public FireArea2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map96 : FireArea2Map
    //{
    //    public FireArea2Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class FireArea2Map97 : FireArea2Map
    //{
    //    public FireArea2Map97()
    //    {
    //        cellName = "FireArea2 27";
    //        cellLocation = 97;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map98 : FireArea2Map
    //{
    //    public FireArea2Map98()
    //    {
    //        cellName = "FireArea2 28";
    //        cellLocation = 98;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea2Map99 : FireArea2Map
    //{
    //    public FireArea2Map99()
    //    {
    //        cellName = "";
    //        cellLocation = 99;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 6;
    //        newLocation = 21;
    //    }
    //}


    //public class FireArea3Map : WorldMap
    //{
    //    public FireArea3Map()
    //    {
    //        mapName = "fire area 3";
    //        mapLocation = 15;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class FireArea3Map0 : FireArea3Map
    //{
    //    public FireArea3Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map1 : FireArea3Map
    //{
    //    public FireArea3Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map2 : FireArea3Map
    //{
    //    public FireArea3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map3 : FireArea3Map
    //{
    //    public FireArea3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map4 : FireArea3Map
    //{
    //    public FireArea3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map5 : FireArea3Map
    //{
    //    public FireArea3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map6 : FireArea3Map
    //{
    //    public FireArea3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map7 : FireArea3Map
    //{
    //    public FireArea3Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map8 : FireArea3Map
    //{
    //    public FireArea3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map9 : FireArea3Map
    //{
    //    public FireArea3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map10 : FireArea3Map
    //{
    //    public FireArea3Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map11 : FireArea3Map
    //{
    //    public FireArea3Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map12 : FireArea3Map
    //{
    //    public FireArea3Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map13 : FireArea3Map
    //{
    //    public FireArea3Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map14 : FireArea3Map
    //{
    //    public FireArea3Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map15 : FireArea3Map
    //{
    //    public FireArea3Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map16 : FireArea3Map
    //{
    //    public FireArea3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map17 : FireArea3Map
    //{
    //    public FireArea3Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map18 : FireArea3Map
    //{
    //    public FireArea3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map19 : FireArea3Map
    //{
    //    public FireArea3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map20 : FireArea3Map
    //{
    //    public FireArea3Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map21 : FireArea3Map
    //{
    //    public FireArea3Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map22 : FireArea3Map
    //{
    //    public FireArea3Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map23 : FireArea3Map
    //{
    //    public FireArea3Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map24 : FireArea3Map
    //{
    //    public FireArea3Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map25 : FireArea3Map
    //{
    //    public FireArea3Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map26 : FireArea3Map
    //{
    //    public FireArea3Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map27 : FireArea3Map
    //{
    //    public FireArea3Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map28 : FireArea3Map
    //{
    //    public FireArea3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map29 : FireArea3Map
    //{
    //    public FireArea3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map30 : FireArea3Map
    //{
    //    public FireArea3Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map31 : FireArea3Map
    //{
    //    public FireArea3Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map32 : FireArea3Map
    //{
    //    public FireArea3Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map33 : FireArea3Map
    //{
    //    public FireArea3Map33()
    //    {
    //        cellName = "";
    //        cellLocation = 33;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 16;
    //        newLocation = 87;
    //    }
    //}
    //public class FireArea3Map34 : FireArea3Map
    //{
    //    public FireArea3Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map35 : FireArea3Map
    //{
    //    public FireArea3Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map36 : FireArea3Map
    //{
    //    public FireArea3Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map37 : FireArea3Map
    //{
    //    public FireArea3Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map38 : FireArea3Map
    //{
    //    public FireArea3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map39 : FireArea3Map
    //{
    //    public FireArea3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map40 : FireArea3Map
    //{
    //    public FireArea3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map41 : FireArea3Map
    //{
    //    public FireArea3Map41()
    //    {
    //        cellName = "FireArea3 26";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map42 : FireArea3Map
    //{
    //    public FireArea3Map42()
    //    {
    //        cellName = "FireArea3 25";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map43 : FireArea3Map
    //{
    //    public FireArea3Map43()
    //    {
    //        cellName = "FireArea3 24";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map44 : FireArea3Map
    //{
    //    public FireArea3Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map45 : FireArea3Map
    //{
    //    public FireArea3Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map46 : FireArea3Map
    //{
    //    public FireArea3Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map47 : FireArea3Map
    //{
    //    public FireArea3Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map48 : FireArea3Map
    //{
    //    public FireArea3Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map49 : FireArea3Map
    //{
    //    public FireArea3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map50 : FireArea3Map
    //{
    //    public FireArea3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map51 : FireArea3Map
    //{
    //    public FireArea3Map51()
    //    {
    //        cellName = "FireArea3 23";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map52 : FireArea3Map
    //{
    //    public FireArea3Map52()
    //    {
    //        cellName = "FireArea3 22";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map53 : FireArea3Map
    //{
    //    public FireArea3Map53()
    //    {
    //        cellName = "FireArea3 21";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map54 : FireArea3Map
    //{
    //    public FireArea3Map54()
    //    {
    //        cellName = "FireArea3 20";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map55 : FireArea3Map
    //{
    //    public FireArea3Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map56 : FireArea3Map
    //{
    //    public FireArea3Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map57 : FireArea3Map
    //{
    //    public FireArea3Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map58 : FireArea3Map
    //{
    //    public FireArea3Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map59 : FireArea3Map
    //{
    //    public FireArea3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map60 : FireArea3Map
    //{
    //    public FireArea3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map61 : FireArea3Map
    //{
    //    public FireArea3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map62 : FireArea3Map
    //{
    //    public FireArea3Map62()
    //    {
    //        cellName = "FireArea3 19";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map63 : FireArea3Map
    //{
    //    public FireArea3Map63()
    //    {
    //        cellName = "FireArea3 18";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map64 : FireArea3Map
    //{
    //    public FireArea3Map64()
    //    {
    //        cellName = "FireArea3 17";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map65 : FireArea3Map
    //{
    //    public FireArea3Map65()
    //    {
    //        cellName = "FireArea3 16";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map66 : FireArea3Map
    //{
    //    public FireArea3Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map67 : FireArea3Map
    //{
    //    public FireArea3Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map68 : FireArea3Map
    //{
    //    public FireArea3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map69 : FireArea3Map
    //{
    //    public FireArea3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map70 : FireArea3Map
    //{
    //    public FireArea3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map71 : FireArea3Map
    //{
    //    public FireArea3Map71()
    //    {
    //        cellName = "FireArea3 15";
    //        cellLocation = 71;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map72 : FireArea3Map
    //{
    //    public FireArea3Map72()
    //    {
    //        cellName = "FireArea3 14";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map73 : FireArea3Map
    //{
    //    public FireArea3Map73()
    //    {
    //        cellName = "FireArea3 13";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map74 : FireArea3Map
    //{
    //    public FireArea3Map74()
    //    {
    //        cellName = "FireArea3 12";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map75 : FireArea3Map
    //{
    //    public FireArea3Map75()
    //    {
    //        cellName = "FireArea3 11";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map76 : FireArea3Map
    //{
    //    public FireArea3Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map77 : FireArea3Map
    //{
    //    public FireArea3Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map78 : FireArea3Map
    //{
    //    public FireArea3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map79 : FireArea3Map
    //{
    //    public FireArea3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map80 : FireArea3Map
    //{
    //    public FireArea3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map81 : FireArea3Map
    //{
    //    public FireArea3Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map82 : FireArea3Map
    //{
    //    public FireArea3Map82()
    //    {
    //        cellName = "FireArea3 10";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map83 : FireArea3Map
    //{
    //    public FireArea3Map83()
    //    {
    //        cellName = "FireArea3 9";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map84 : FireArea3Map
    //{
    //    public FireArea3Map84()
    //    {
    //        cellName = "FireArea3 8";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map85 : FireArea3Map
    //{
    //    public FireArea3Map85()
    //    {
    //        cellName = "FireArea3 7";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map86 : FireArea3Map
    //{
    //    public FireArea3Map86()
    //    {
    //        cellName = "FireArea3 6";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map87 : FireArea3Map
    //{
    //    public FireArea3Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map88 : FireArea3Map
    //{
    //    public FireArea3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map89 : FireArea3Map
    //{
    //    public FireArea3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map90 : FireArea3Map
    //{
    //    public FireArea3Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map91 : FireArea3Map
    //{
    //    public FireArea3Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map92 : FireArea3Map
    //{
    //    public FireArea3Map92()
    //    {
    //        cellName = "FireArea3 5";
    //        cellLocation = 92;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map93 : FireArea3Map
    //{
    //    public FireArea3Map93()
    //    {
    //        cellName = "FireArea3 4";
    //        cellLocation = 93;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map94 : FireArea3Map
    //{
    //    public FireArea3Map94()
    //    {
    //        cellName = "FireArea3 3";
    //        cellLocation = 94;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map95 : FireArea3Map
    //{
    //    public FireArea3Map95()
    //    {
    //        cellName = "FireArea3 2";
    //        cellLocation = 95;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map96 : FireArea3Map
    //{
    //    public FireArea3Map96()
    //    {
    //        cellName = "FireArea3 1";
    //        cellLocation = 96;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class FireArea3Map97 : FireArea3Map
    //{
    //    public FireArea3Map97()
    //    {
    //        cellName = "";
    //        cellLocation = 97;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 14;
    //        newLocation = 1;
    //    }
    //}
    //public class FireArea3Map98 : FireArea3Map
    //{
    //    public FireArea3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class FireArea3Map99 : FireArea3Map
    //{
    //    public FireArea3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class LaharvaMap : WorldMap
    //{
    //    public LaharvaMap()
    //    {
    //        mapName = "laharva";
    //        mapLocation = 16;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 0;
    //    }
    //}
    //public class LaharvaMap0 : LaharvaMap
    //{
    //    public LaharvaMap0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap1 : LaharvaMap
    //{
    //    public LaharvaMap1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap2 : LaharvaMap
    //{
    //    public LaharvaMap2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap3 : LaharvaMap
    //{
    //    public LaharvaMap3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap4 : LaharvaMap
    //{
    //    public LaharvaMap4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap5 : LaharvaMap
    //{
    //    public LaharvaMap5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap6 : LaharvaMap
    //{
    //    public LaharvaMap6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap7 : LaharvaMap
    //{
    //    public LaharvaMap7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap8 : LaharvaMap
    //{
    //    public LaharvaMap8()
    //    {
    //        cellName = "Laharva 22";
    //        cellLocation = 8;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };

    //    }
    //}
    //public class LaharvaMap9 : LaharvaMap
    //{
    //    public LaharvaMap9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap10 : LaharvaMap
    //{
    //    public LaharvaMap10()
    //    {
    //        cellName = "";
    //        cellLocation = 10;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 44;
    //        newLocation = 0; //change
    //    }
    //}
    //public class LaharvaMap11 : LaharvaMap
    //{
    //    public LaharvaMap11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap12 : LaharvaMap
    //{
    //    public LaharvaMap12()
    //    {
    //        cellName = "Laharva 32";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap13 : LaharvaMap
    //{
    //    public LaharvaMap13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap14 : LaharvaMap
    //{
    //    public LaharvaMap14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap15 : LaharvaMap
    //{
    //    public LaharvaMap15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap16 : LaharvaMap
    //{
    //    public LaharvaMap16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap17 : LaharvaMap
    //{
    //    public LaharvaMap17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap18 : LaharvaMap
    //{
    //    public LaharvaMap18()
    //    {
    //        cellName = "Laharva 21";
    //        cellLocation = 18;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap19 : LaharvaMap
    //{
    //    public LaharvaMap19()
    //    {
    //        cellName = "Laharva 20";
    //        cellLocation = 19;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap20 : LaharvaMap
    //{
    //    public LaharvaMap20()
    //    {
    //        cellName = "Laharva 29";
    //        cellLocation = 20;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap21 : LaharvaMap
    //{
    //    public LaharvaMap21()
    //    {
    //        cellName = "Laharva 30";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap22 : LaharvaMap
    //{
    //    public LaharvaMap22()
    //    {
    //        cellName = "Laharva 31";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap23 : LaharvaMap
    //{
    //    public LaharvaMap23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap24 : LaharvaMap
    //{
    //    public LaharvaMap24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap25 : LaharvaMap
    //{
    //    public LaharvaMap25()
    //    {
    //        cellName = "Laharva 19";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap26 : LaharvaMap
    //{
    //    public LaharvaMap26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap27 : LaharvaMap
    //{
    //    public LaharvaMap27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap28 : LaharvaMap
    //{
    //    public LaharvaMap28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap29 : LaharvaMap
    //{
    //    public LaharvaMap29()
    //    {
    //        cellName = "";
    //        cellLocation = 29;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 29;
    //        newLocation = 0;
    //    }
    //}
    //public class LaharvaMap30 : LaharvaMap
    //{
    //    public LaharvaMap30()
    //    {
    //        cellName = "Laharva 27";
    //        cellLocation = 30;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap31 : LaharvaMap
    //{
    //    public LaharvaMap31()
    //    {
    //        cellName = "Laharva 28";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap32 : LaharvaMap
    //{
    //    public LaharvaMap32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap33 : LaharvaMap
    //{
    //    public LaharvaMap33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap34 : LaharvaMap
    //{
    //    public LaharvaMap34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap35 : LaharvaMap
    //{
    //    public LaharvaMap35()
    //    {
    //        cellName = "Laharva 18";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap36 : LaharvaMap
    //{
    //    public LaharvaMap36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap37 : LaharvaMap
    //{
    //    public LaharvaMap37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap38 : LaharvaMap
    //{
    //    public LaharvaMap38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap39 : LaharvaMap
    //{
    //    public LaharvaMap39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap40 : LaharvaMap
    //{
    //    public LaharvaMap40()
    //    {
    //        cellName = "Laharva 25";
    //        cellLocation = 40;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap41 : LaharvaMap
    //{
    //    public LaharvaMap41()
    //    {
    //        cellName = "Laharva 26";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap42 : LaharvaMap
    //{
    //    public LaharvaMap42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap43 : LaharvaMap
    //{
    //    public LaharvaMap43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap44 : LaharvaMap
    //{
    //    public LaharvaMap44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap45 : LaharvaMap
    //{
    //    public LaharvaMap45()
    //    {
    //        cellName = "Laharva 17";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap46 : LaharvaMap
    //{
    //    public LaharvaMap46()
    //    {
    //        cellName = "Laharva 16";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap47 : LaharvaMap
    //{
    //    public LaharvaMap47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap48 : LaharvaMap
    //{
    //    public LaharvaMap48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap49 : LaharvaMap
    //{
    //    public LaharvaMap49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap50 : LaharvaMap
    //{
    //    public LaharvaMap50()
    //    {
    //        cellName = "Laharva 24";
    //        cellLocation = 50;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap51 : LaharvaMap
    //{
    //    public LaharvaMap51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap52 : LaharvaMap
    //{
    //    public LaharvaMap52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap53 : LaharvaMap
    //{
    //    public LaharvaMap53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap54 : LaharvaMap
    //{
    //    public LaharvaMap54()
    //    {
    //        cellName = "Laharva 15";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap55 : LaharvaMap
    //{
    //    public LaharvaMap55()
    //    {
    //        cellName = "Laharva 14";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap56 : LaharvaMap
    //{
    //    public LaharvaMap56()
    //    {
    //        cellName = "Laharva 13";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap57 : LaharvaMap
    //{
    //    public LaharvaMap57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap58 : LaharvaMap
    //{
    //    public LaharvaMap58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap59 : LaharvaMap
    //{
    //    public LaharvaMap59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap60 : LaharvaMap
    //{
    //    public LaharvaMap60()
    //    {
    //        cellName = "Laharva 23";
    //        cellLocation = 60;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap61 : LaharvaMap
    //{
    //    public LaharvaMap61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap62 : LaharvaMap
    //{
    //    public LaharvaMap62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap63 : LaharvaMap
    //{
    //    public LaharvaMap63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap64 : LaharvaMap
    //{
    //    public LaharvaMap64()
    //    {
    //        cellName = "Laharva 12";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap65 : LaharvaMap
    //{
    //    public LaharvaMap65()
    //    {
    //        cellName = "Laharva 11";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap66 : LaharvaMap
    //{
    //    public LaharvaMap66()
    //    {
    //        cellName = "Laharva 10";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap67 : LaharvaMap
    //{
    //    public LaharvaMap67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap68 : LaharvaMap
    //{
    //    public LaharvaMap68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap69 : LaharvaMap
    //{
    //    public LaharvaMap69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap70 : LaharvaMap
    //{
    //    public LaharvaMap70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap71 : LaharvaMap
    //{
    //    public LaharvaMap71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap72 : LaharvaMap
    //{
    //    public LaharvaMap72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap73 : LaharvaMap
    //{
    //    public LaharvaMap73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap74 : LaharvaMap
    //{
    //    public LaharvaMap74()
    //    {
    //        cellName = "Laharva 6";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap75 : LaharvaMap
    //{
    //    public LaharvaMap75()
    //    {
    //        cellName = "Laharva 5";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap76 : LaharvaMap
    //{
    //    public LaharvaMap76()
    //    {
    //        cellName = "Laharva 4";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap77 : LaharvaMap
    //{
    //    public LaharvaMap77()
    //    {
    //        cellName = "Laharva 3";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap78 : LaharvaMap
    //{
    //    public LaharvaMap78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap79 : LaharvaMap
    //{
    //    public LaharvaMap79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap80 : LaharvaMap
    //{
    //    public LaharvaMap80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap81 : LaharvaMap
    //{
    //    public LaharvaMap81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap82 : LaharvaMap
    //{
    //    public LaharvaMap82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap83 : LaharvaMap
    //{
    //    public LaharvaMap83()
    //    {
    //        cellName = "Laharva 8";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap84 : LaharvaMap
    //{
    //    public LaharvaMap84()
    //    {
    //        cellName = "Laharva 7";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap85 : LaharvaMap
    //{
    //    public LaharvaMap85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap86 : LaharvaMap
    //{
    //    public LaharvaMap86()
    //    {
    //        cellName = "Laharva 2";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap87 : LaharvaMap
    //{
    //    public LaharvaMap87()
    //    {
    //        cellName = "Laharva 1";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap88 : LaharvaMap
    //{
    //    public LaharvaMap88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap89 : LaharvaMap
    //{
    //    public LaharvaMap89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap90 : LaharvaMap
    //{
    //    public LaharvaMap90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap91 : LaharvaMap
    //{
    //    public LaharvaMap91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap92 : LaharvaMap
    //{
    //    public LaharvaMap92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap93 : LaharvaMap
    //{
    //    public LaharvaMap93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap94 : LaharvaMap
    //{
    //    public LaharvaMap94()
    //    {
    //        cellName = "Laharva 9";
    //        cellLocation = 94;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class LaharvaMap95 : LaharvaMap
    //{
    //    public LaharvaMap95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap96 : LaharvaMap
    //{
    //    public LaharvaMap96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap97 : LaharvaMap
    //{
    //    public LaharvaMap97()
    //    {
    //        cellName = "";
    //        cellLocation = 97;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 15;
    //        newLocation = 43;
    //    }
    //}
    //public class LaharvaMap98 : LaharvaMap
    //{
    //    public LaharvaMap98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class LaharvaMap99 : LaharvaMap
    //{
    //    public LaharvaMap99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class PlantArea1Map : WorldMap
    //{
    //    public PlantArea1Map()
    //    {
    //        mapName = "plant area 1";
    //        mapLocation = 7;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class PlantArea1Map0 : PlantArea1Map
    //{
    //    public PlantArea1Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map1 : PlantArea1Map
    //{
    //    public PlantArea1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map2 : PlantArea1Map
    //{
    //    public PlantArea1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map3 : PlantArea1Map
    //{
    //    public PlantArea1Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map4 : PlantArea1Map
    //{
    //    public PlantArea1Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map5 : PlantArea1Map
    //{
    //    public PlantArea1Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map6 : PlantArea1Map
    //{
    //    public PlantArea1Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map7 : PlantArea1Map
    //{
    //    public PlantArea1Map7()
    //    {
    //        cellName = "plantarea1 22";
    //        cellLocation = 7;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map8 : PlantArea1Map
    //{
    //    public PlantArea1Map8()
    //    {
    //        cellName = "plantarea1 26";
    //        cellLocation = 8;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map9 : PlantArea1Map
    //{
    //    public PlantArea1Map9()
    //    {
    //        cellName = "";
    //        cellLocation = 9;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 17;
    //        newLocation = 81;
    //    }
    //}
    //public class PlantArea1Map10 : PlantArea1Map
    //{
    //    public PlantArea1Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map11 : PlantArea1Map
    //{
    //    public PlantArea1Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map12 : PlantArea1Map
    //{
    //    public PlantArea1Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map13 : PlantArea1Map
    //{
    //    public PlantArea1Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map14 : PlantArea1Map
    //{
    //    public PlantArea1Map14()
    //    {
    //        cellName = "plantarea1 11";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map15 : PlantArea1Map
    //{
    //    public PlantArea1Map15()
    //    {
    //        cellName = "plantarea1 15";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map16 : PlantArea1Map
    //{
    //    public PlantArea1Map16()
    //    {
    //        cellName = "plantarea1 19";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map17 : PlantArea1Map
    //{
    //    public PlantArea1Map17()
    //    {
    //        cellName = "plantarea1 23";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map18 : PlantArea1Map
    //{
    //    public PlantArea1Map18()
    //    {
    //        cellName = "plantarea1 27";
    //        cellLocation = 18;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map19 : PlantArea1Map
    //{
    //    public PlantArea1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map20 : PlantArea1Map
    //{
    //    public PlantArea1Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map21 : PlantArea1Map
    //{
    //    public PlantArea1Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map22 : PlantArea1Map
    //{
    //    public PlantArea1Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map23 : PlantArea1Map
    //{
    //    public PlantArea1Map23()
    //    {
    //        cellName = "plantarea1 6";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map24 : PlantArea1Map
    //{
    //    public PlantArea1Map24()
    //    {
    //        cellName = "plantarea1 12";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map25 : PlantArea1Map
    //{
    //    public PlantArea1Map25()
    //    {
    //        cellName = "plantarea1 16";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map26 : PlantArea1Map
    //{
    //    public PlantArea1Map26()
    //    {
    //        cellName = "plantarea1 20";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map27 : PlantArea1Map
    //{
    //    public PlantArea1Map27()
    //    {
    //        cellName = "plantarea1 24";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map28 : PlantArea1Map
    //{
    //    public PlantArea1Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map29 : PlantArea1Map
    //{
    //    public PlantArea1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map30 : PlantArea1Map
    //{
    //    public PlantArea1Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map31 : PlantArea1Map
    //{
    //    public PlantArea1Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map32 : PlantArea1Map
    //{
    //    public PlantArea1Map32()
    //    {
    //        cellName = "plantarea1 2";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map33 : PlantArea1Map
    //{
    //    public PlantArea1Map33()
    //    {
    //        cellName = "plantarea1 7";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map34 : PlantArea1Map
    //{
    //    public PlantArea1Map34()
    //    {
    //        cellName = "plantarea1 13";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map35 : PlantArea1Map
    //{
    //    public PlantArea1Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map36 : PlantArea1Map
    //{
    //    public PlantArea1Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map37 : PlantArea1Map
    //{
    //    public PlantArea1Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map38 : PlantArea1Map
    //{
    //    public PlantArea1Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map39 : PlantArea1Map
    //{
    //    public PlantArea1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map40 : PlantArea1Map
    //{
    //    public PlantArea1Map40()
    //    {
    //        cellName = "";
    //        cellLocation = 40;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 26;
    //    }
    //}
    //public class PlantArea1Map41 : PlantArea1Map
    //{
    //    public PlantArea1Map41()
    //    {
    //        cellName = "plantarea1 1";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        firstVisit = true;
    //    }
    //}
    //public class PlantArea1Map42 : PlantArea1Map
    //{
    //    public PlantArea1Map42()
    //    {
    //        cellName = "plantarea1 3";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map43 : PlantArea1Map
    //{
    //    public PlantArea1Map43()
    //    {
    //        cellName = "plantarea1 8";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map44 : PlantArea1Map
    //{
    //    public PlantArea1Map44()
    //    {
    //        cellName = "plantarea1 14";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map45 : PlantArea1Map
    //{
    //    public PlantArea1Map45()
    //    {
    //        cellName = "plantarea1 17";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map46 : PlantArea1Map
    //{
    //    public PlantArea1Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map47 : PlantArea1Map
    //{
    //    public PlantArea1Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map48 : PlantArea1Map
    //{
    //    public PlantArea1Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map49 : PlantArea1Map
    //{
    //    public PlantArea1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map50 : PlantArea1Map
    //{
    //    public PlantArea1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map51 : PlantArea1Map
    //{
    //    public PlantArea1Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map52 : PlantArea1Map
    //{
    //    public PlantArea1Map52()
    //    {
    //        cellName = "plantarea1 4";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map53 : PlantArea1Map
    //{
    //    public PlantArea1Map53()
    //    {
    //        cellName = "plantarea1 9";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map54 : PlantArea1Map
    //{
    //    public PlantArea1Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map55 : PlantArea1Map
    //{
    //    public PlantArea1Map55()
    //    {
    //        cellName = "plantarea1 18";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map56 : PlantArea1Map
    //{
    //    public PlantArea1Map56()
    //    {
    //        cellName = "plantarea1 21";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map57 : PlantArea1Map
    //{
    //    public PlantArea1Map57()
    //    {
    //        cellName = "plantarea1 25";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class PlantArea1Map58 : PlantArea1Map
    //{
    //    public PlantArea1Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map59 : PlantArea1Map
    //{
    //    public PlantArea1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map60 : PlantArea1Map
    //{
    //    public PlantArea1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map61 : PlantArea1Map
    //{
    //    public PlantArea1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map62 : PlantArea1Map
    //{
    //    public PlantArea1Map62()
    //    {
    //        cellName = "plantarea1 5";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map63 : PlantArea1Map
    //{
    //    public PlantArea1Map63()
    //    {
    //        cellName = "plantarea1 10";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea1Map64 : PlantArea1Map
    //{
    //    public PlantArea1Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map65 : PlantArea1Map
    //{
    //    public PlantArea1Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map66 : PlantArea1Map
    //{
    //    public PlantArea1Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map67 : PlantArea1Map
    //{
    //    public PlantArea1Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map68 : PlantArea1Map
    //{
    //    public PlantArea1Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map69 : PlantArea1Map
    //{
    //    public PlantArea1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map70 : PlantArea1Map
    //{
    //    public PlantArea1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map71 : PlantArea1Map
    //{
    //    public PlantArea1Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map72 : PlantArea1Map
    //{
    //    public PlantArea1Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map73 : PlantArea1Map
    //{
    //    public PlantArea1Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map74 : PlantArea1Map
    //{
    //    public PlantArea1Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map75 : PlantArea1Map
    //{
    //    public PlantArea1Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map76 : PlantArea1Map
    //{
    //    public PlantArea1Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map77 : PlantArea1Map
    //{
    //    public PlantArea1Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map78 : PlantArea1Map
    //{
    //    public PlantArea1Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map79 : PlantArea1Map
    //{
    //    public PlantArea1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map80 : PlantArea1Map
    //{
    //    public PlantArea1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map81 : PlantArea1Map
    //{
    //    public PlantArea1Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map82 : PlantArea1Map
    //{
    //    public PlantArea1Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map83 : PlantArea1Map
    //{
    //    public PlantArea1Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map84 : PlantArea1Map
    //{
    //    public PlantArea1Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map85 : PlantArea1Map
    //{
    //    public PlantArea1Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map86 : PlantArea1Map
    //{
    //    public PlantArea1Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map87 : PlantArea1Map
    //{
    //    public PlantArea1Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map88 : PlantArea1Map
    //{
    //    public PlantArea1Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map89 : PlantArea1Map
    //{
    //    public PlantArea1Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map90 : PlantArea1Map
    //{
    //    public PlantArea1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map91 : PlantArea1Map
    //{
    //    public PlantArea1Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map92 : PlantArea1Map
    //{
    //    public PlantArea1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map93 : PlantArea1Map
    //{
    //    public PlantArea1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map94 : PlantArea1Map
    //{
    //    public PlantArea1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map95 : PlantArea1Map
    //{
    //    public PlantArea1Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map96 : PlantArea1Map
    //{
    //    public PlantArea1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map97 : PlantArea1Map
    //{
    //    public PlantArea1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map98 : PlantArea1Map
    //{
    //    public PlantArea1Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea1Map99 : PlantArea1Map
    //{
    //    public PlantArea1Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class PlantArea2Map : WorldMap
    //{
    //    public PlantArea2Map()
    //    {
    //        mapName = "plant area 2";
    //        mapLocation = 17;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class PlantArea2Map0 : PlantArea2Map
    //{
    //    public PlantArea2Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map1 : PlantArea2Map
    //{
    //    public PlantArea2Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map2 : PlantArea2Map
    //{
    //    public PlantArea2Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map3 : PlantArea2Map
    //{
    //    public PlantArea2Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map4 : PlantArea2Map
    //{
    //    public PlantArea2Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map5 : PlantArea2Map
    //{
    //    public PlantArea2Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map6 : PlantArea2Map
    //{
    //    public PlantArea2Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map7 : PlantArea2Map
    //{
    //    public PlantArea2Map7()
    //    {
    //        cellName = "";
    //        cellLocation = 7;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 18;
    //        newLocation = 87;
    //    }
    //}
    //public class PlantArea2Map8 : PlantArea2Map
    //{
    //    public PlantArea2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map9 : PlantArea2Map
    //{
    //    public PlantArea2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map10 : PlantArea2Map
    //{
    //    public PlantArea2Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map11 : PlantArea2Map
    //{
    //    public PlantArea2Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map12 : PlantArea2Map
    //{
    //    public PlantArea2Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map13 : PlantArea2Map
    //{
    //    public PlantArea2Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map14 : PlantArea2Map
    //{
    //    public PlantArea2Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map15 : PlantArea2Map
    //{
    //    public PlantArea2Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map16 : PlantArea2Map
    //{
    //    public PlantArea2Map16()
    //    {
    //        cellName = "PlantArea2 24";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map17 : PlantArea2Map
    //{
    //    public PlantArea2Map17()
    //    {
    //        cellName = "PlantArea2 25";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map18 : PlantArea2Map
    //{
    //    public PlantArea2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map19 : PlantArea2Map
    //{
    //    public PlantArea2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map20 : PlantArea2Map
    //{
    //    public PlantArea2Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map21 : PlantArea2Map
    //{
    //    public PlantArea2Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map22 : PlantArea2Map
    //{
    //    public PlantArea2Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map23 : PlantArea2Map
    //{
    //    public PlantArea2Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map24 : PlantArea2Map
    //{
    //    public PlantArea2Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map25 : PlantArea2Map
    //{
    //    public PlantArea2Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map26 : PlantArea2Map
    //{
    //    public PlantArea2Map26()
    //    {
    //        cellName = "PlantArea2 22";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map27 : PlantArea2Map
    //{
    //    public PlantArea2Map27()
    //    {
    //        cellName = "PlantArea2 23";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map28 : PlantArea2Map
    //{
    //    public PlantArea2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map29 : PlantArea2Map
    //{
    //    public PlantArea2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map30 : PlantArea2Map
    //{
    //    public PlantArea2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map31 : PlantArea2Map
    //{
    //    public PlantArea2Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map32 : PlantArea2Map
    //{
    //    public PlantArea2Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map33 : PlantArea2Map
    //{
    //    public PlantArea2Map33()
    //    {
    //        cellName = "PlantArea2 17";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map34 : PlantArea2Map
    //{
    //    public PlantArea2Map34()
    //    {
    //        cellName = "PlantArea2 18";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map35 : PlantArea2Map
    //{
    //    public PlantArea2Map35()
    //    {
    //        cellName = "PlantArea2 19";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map36 : PlantArea2Map
    //{
    //    public PlantArea2Map36()
    //    {
    //        cellName = "PlantArea2 20";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map37 : PlantArea2Map
    //{
    //    public PlantArea2Map37()
    //    {
    //        cellName = "PlantArea2 21";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class PlantArea2Map38 : PlantArea2Map
    //{
    //    public PlantArea2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map39 : PlantArea2Map
    //{
    //    public PlantArea2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map40 : PlantArea2Map
    //{
    //    public PlantArea2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map41 : PlantArea2Map
    //{
    //    public PlantArea2Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map42 : PlantArea2Map
    //{
    //    public PlantArea2Map42()
    //    {
    //        cellName = "PlantArea2 15";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map43 : PlantArea2Map
    //{
    //    public PlantArea2Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map44 : PlantArea2Map
    //{
    //    public PlantArea2Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map45 : PlantArea2Map
    //{
    //    public PlantArea2Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map46 : PlantArea2Map
    //{
    //    public PlantArea2Map46()
    //    {
    //        cellName = "PlantArea2 16";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map47 : PlantArea2Map
    //{
    //    public PlantArea2Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map48 : PlantArea2Map
    //{
    //    public PlantArea2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map49 : PlantArea2Map
    //{
    //    public PlantArea2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map50 : PlantArea2Map
    //{
    //    public PlantArea2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map51 : PlantArea2Map
    //{
    //    public PlantArea2Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map52 : PlantArea2Map
    //{
    //    public PlantArea2Map52()
    //    {
    //        cellName = "PlantArea2 13";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map53 : PlantArea2Map
    //{
    //    public PlantArea2Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map54 : PlantArea2Map
    //{
    //    public PlantArea2Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map55 : PlantArea2Map
    //{
    //    public PlantArea2Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map56 : PlantArea2Map
    //{
    //    public PlantArea2Map56()
    //    {
    //        cellName = "PlantArea2 14";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map57 : PlantArea2Map
    //{
    //    public PlantArea2Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map58 : PlantArea2Map
    //{
    //    public PlantArea2Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map59 : PlantArea2Map
    //{
    //    public PlantArea2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map60 : PlantArea2Map
    //{
    //    public PlantArea2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map61 : PlantArea2Map
    //{
    //    public PlantArea2Map61()
    //    {
    //        cellName = "PlantArea2 7";
    //        cellLocation = 61;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map62 : PlantArea2Map
    //{
    //    public PlantArea2Map62()
    //    {
    //        cellName = "PlantArea2 8";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map63 : PlantArea2Map
    //{
    //    public PlantArea2Map63()
    //    {
    //        cellName = "PlantArea2 9";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map64 : PlantArea2Map
    //{
    //    public PlantArea2Map64()
    //    {
    //        cellName = "PlantArea2 10";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map65 : PlantArea2Map
    //{
    //    public PlantArea2Map65()
    //    {
    //        cellName = "PlantArea2 11";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map66 : PlantArea2Map
    //{
    //    public PlantArea2Map66()
    //    {
    //        cellName = "PlantArea2 12";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map67 : PlantArea2Map
    //{
    //    public PlantArea2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map68 : PlantArea2Map
    //{
    //    public PlantArea2Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map69 : PlantArea2Map
    //{
    //    public PlantArea2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map70 : PlantArea2Map
    //{
    //    public PlantArea2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map71 : PlantArea2Map
    //{
    //    public PlantArea2Map71()
    //    {
    //        cellName = "PlantArea2 3";
    //        cellLocation = 71;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map72 : PlantArea2Map
    //{
    //    public PlantArea2Map72()
    //    {
    //        cellName = "PlantArea2 4";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map73 : PlantArea2Map
    //{
    //    public PlantArea2Map73()
    //    {
    //        cellName = "PlantArea2 5";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map74 : PlantArea2Map
    //{
    //    public PlantArea2Map74()
    //    {
    //        cellName = "PlantArea2 6";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map75 : PlantArea2Map
    //{
    //    public PlantArea2Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map76 : PlantArea2Map
    //{
    //    public PlantArea2Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map77 : PlantArea2Map
    //{
    //    public PlantArea2Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map78 : PlantArea2Map
    //{
    //    public PlantArea2Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map79 : PlantArea2Map
    //{
    //    public PlantArea2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map80 : PlantArea2Map
    //{
    //    public PlantArea2Map80()
    //    {
    //        cellName = "";
    //        cellLocation = 80;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 7;
    //        newLocation = 8;
    //    }
    //}
    //public class PlantArea2Map81 : PlantArea2Map
    //{
    //    public PlantArea2Map81()
    //    {
    //        cellName = "PlantArea2 1";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map82 : PlantArea2Map
    //{
    //    public PlantArea2Map82()
    //    {
    //        cellName = "PlantArea2 2";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea2Map83 : PlantArea2Map
    //{
    //    public PlantArea2Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map84 : PlantArea2Map
    //{
    //    public PlantArea2Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map85 : PlantArea2Map
    //{
    //    public PlantArea2Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map86 : PlantArea2Map
    //{
    //    public PlantArea2Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map87 : PlantArea2Map
    //{
    //    public PlantArea2Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map88 : PlantArea2Map
    //{
    //    public PlantArea2Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map89 : PlantArea2Map
    //{
    //    public PlantArea2Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map90 : PlantArea2Map
    //{
    //    public PlantArea2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map91 : PlantArea2Map
    //{
    //    public PlantArea2Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map92 : PlantArea2Map
    //{
    //    public PlantArea2Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map93 : PlantArea2Map
    //{
    //    public PlantArea2Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map94 : PlantArea2Map
    //{
    //    public PlantArea2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map95 : PlantArea2Map
    //{
    //    public PlantArea2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map96 : PlantArea2Map
    //{
    //    public PlantArea2Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map97 : PlantArea2Map
    //{
    //    public PlantArea2Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map98 : PlantArea2Map
    //{
    //    public PlantArea2Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea2Map99 : PlantArea2Map
    //{
    //    public PlantArea2Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class PlantArea3Map : WorldMap
    //{
    //    public PlantArea3Map()
    //    {
    //        mapName = "plant area 3";
    //        mapLocation = 18;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class PlantArea3Map0 : PlantArea3Map
    //{
    //    public PlantArea3Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map1 : PlantArea3Map
    //{
    //    public PlantArea3Map1()
    //    {
    //        cellName = "";
    //        cellLocation = 1;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 19;
    //        newLocation = 51;
    //    }
    //}
    //public class PlantArea3Map2 : PlantArea3Map
    //{
    //    public PlantArea3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map3 : PlantArea3Map
    //{
    //    public PlantArea3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map4 : PlantArea3Map
    //{
    //    public PlantArea3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map5 : PlantArea3Map
    //{
    //    public PlantArea3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map6 : PlantArea3Map
    //{
    //    public PlantArea3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map7 : PlantArea3Map
    //{
    //    public PlantArea3Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map8 : PlantArea3Map
    //{
    //    public PlantArea3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map9 : PlantArea3Map
    //{
    //    public PlantArea3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map10 : PlantArea3Map
    //{
    //    public PlantArea3Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map11 : PlantArea3Map
    //{
    //    public PlantArea3Map11()
    //    {
    //        cellName = "PlantArea3 32";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map12 : PlantArea3Map
    //{
    //    public PlantArea3Map12()
    //    {
    //        cellName = "PlantArea3 31";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map13 : PlantArea3Map
    //{
    //    public PlantArea3Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map14 : PlantArea3Map
    //{
    //    public PlantArea3Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map15 : PlantArea3Map
    //{
    //    public PlantArea3Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map16 : PlantArea3Map
    //{
    //    public PlantArea3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map17 : PlantArea3Map
    //{
    //    public PlantArea3Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map18 : PlantArea3Map
    //{
    //    public PlantArea3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map19 : PlantArea3Map
    //{
    //    public PlantArea3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map20 : PlantArea3Map
    //{
    //    public PlantArea3Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map21 : PlantArea3Map
    //{
    //    public PlantArea3Map21()
    //    {
    //        cellName = "PlantArea3 30";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map22 : PlantArea3Map
    //{
    //    public PlantArea3Map22()
    //    {
    //        cellName = "PlantArea3 29";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map23 : PlantArea3Map
    //{
    //    public PlantArea3Map23()
    //    {
    //        cellName = "PlantArea3 28";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map24 : PlantArea3Map
    //{
    //    public PlantArea3Map24()
    //    {
    //        cellName = "PlantArea3 27";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map25 : PlantArea3Map
    //{
    //    public PlantArea3Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map26 : PlantArea3Map
    //{
    //    public PlantArea3Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map27 : PlantArea3Map
    //{
    //    public PlantArea3Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map28 : PlantArea3Map
    //{
    //    public PlantArea3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map29 : PlantArea3Map
    //{
    //    public PlantArea3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map30 : PlantArea3Map
    //{
    //    public PlantArea3Map30()
    //    {
    //        cellName = "PlantArea3 26";
    //        cellLocation = 30;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map31 : PlantArea3Map
    //{
    //    public PlantArea3Map31()
    //    {
    //        cellName = "PlantArea3 25";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map32 : PlantArea3Map
    //{
    //    public PlantArea3Map32()
    //    {
    //        cellName = "PlantArea3 24";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map33 : PlantArea3Map
    //{
    //    public PlantArea3Map33()
    //    {
    //        cellName = "PlantArea3 23";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map34 : PlantArea3Map
    //{
    //    public PlantArea3Map34()
    //    {
    //        cellName = "PlantArea3 22";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map35 : PlantArea3Map
    //{
    //    public PlantArea3Map35()
    //    {
    //        cellName = "PlantArea3 21";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map36 : PlantArea3Map
    //{
    //    public PlantArea3Map36()
    //    {
    //        cellName = "PlantArea3 20";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map37 : PlantArea3Map
    //{
    //    public PlantArea3Map37()
    //    {
    //        cellName = "PlantArea3 19";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class PlantArea3Map38 : PlantArea3Map
    //{
    //    public PlantArea3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map39 : PlantArea3Map
    //{
    //    public PlantArea3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map40 : PlantArea3Map
    //{
    //    public PlantArea3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map41 : PlantArea3Map
    //{
    //    public PlantArea3Map41()
    //    {
    //        cellName = "PlantArea3 18";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map42 : PlantArea3Map
    //{
    //    public PlantArea3Map42()
    //    {
    //        cellName = "PlantArea3 17";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map43 : PlantArea3Map
    //{
    //    public PlantArea3Map43()
    //    {
    //        cellName = "PlantArea3 16";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map44 : PlantArea3Map
    //{
    //    public PlantArea3Map44()
    //    {
    //        cellName = "PlantArea3 15";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map45 : PlantArea3Map
    //{
    //    public PlantArea3Map45()
    //    {
    //        cellName = "PlantArea3 14";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map46 : PlantArea3Map
    //{
    //    public PlantArea3Map46()
    //    {
    //        cellName = "PlantArea3 13";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map47 : PlantArea3Map
    //{
    //    public PlantArea3Map47()
    //    {
    //        cellName = "PlantArea3 12";
    //        cellLocation = 47;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map48 : PlantArea3Map
    //{
    //    public PlantArea3Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map49 : PlantArea3Map
    //{
    //    public PlantArea3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map50 : PlantArea3Map
    //{
    //    public PlantArea3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map51 : PlantArea3Map
    //{
    //    public PlantArea3Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map52 : PlantArea3Map
    //{
    //    public PlantArea3Map52()
    //    {
    //        cellName = "PlantArea3 11";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map53 : PlantArea3Map
    //{
    //    public PlantArea3Map53()
    //    {
    //        cellName = "PlantArea3 10";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map54 : PlantArea3Map
    //{
    //    public PlantArea3Map54()
    //    {
    //        cellName = "PlantArea3 9";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map55 : PlantArea3Map
    //{
    //    public PlantArea3Map55()
    //    {
    //        cellName = "PlantArea3 8";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map56 : PlantArea3Map
    //{
    //    public PlantArea3Map56()
    //    {
    //        cellName = "PlantArea3 7";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map57 : PlantArea3Map
    //{
    //    public PlantArea3Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map58 : PlantArea3Map
    //{
    //    public PlantArea3Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map59 : PlantArea3Map
    //{
    //    public PlantArea3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map60 : PlantArea3Map
    //{
    //    public PlantArea3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map61 : PlantArea3Map
    //{
    //    public PlantArea3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map62 : PlantArea3Map
    //{
    //    public PlantArea3Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map63 : PlantArea3Map
    //{
    //    public PlantArea3Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map64 : PlantArea3Map
    //{
    //    public PlantArea3Map64()
    //    {
    //        cellName = "PlantArea3 6";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map65 : PlantArea3Map
    //{
    //    public PlantArea3Map65()
    //    {
    //        cellName = "PlantArea3 5";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map66 : PlantArea3Map
    //{
    //    public PlantArea3Map66()
    //    {
    //        cellName = "PlantArea3 4";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map67 : PlantArea3Map
    //{
    //    public PlantArea3Map67()
    //    {
    //        cellName = "PlantArea3 3";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class PlantArea3Map68 : PlantArea3Map
    //{
    //    public PlantArea3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map69 : PlantArea3Map
    //{
    //    public PlantArea3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map70 : PlantArea3Map
    //{
    //    public PlantArea3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map71 : PlantArea3Map
    //{
    //    public PlantArea3Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map72 : PlantArea3Map
    //{
    //    public PlantArea3Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map73 : PlantArea3Map
    //{
    //    public PlantArea3Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map74 : PlantArea3Map
    //{
    //    public PlantArea3Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map75 : PlantArea3Map
    //{
    //    public PlantArea3Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map76 : PlantArea3Map
    //{
    //    public PlantArea3Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map77 : PlantArea3Map
    //{
    //    public PlantArea3Map77()
    //    {
    //        cellName = "PlantArea3 2";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map78 : PlantArea3Map
    //{
    //    public PlantArea3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map79 : PlantArea3Map
    //{
    //    public PlantArea3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map80 : PlantArea3Map
    //{
    //    public PlantArea3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map81 : PlantArea3Map
    //{
    //    public PlantArea3Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map82 : PlantArea3Map
    //{
    //    public PlantArea3Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map83 : PlantArea3Map
    //{
    //    public PlantArea3Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map84 : PlantArea3Map
    //{
    //    public PlantArea3Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map85 : PlantArea3Map
    //{
    //    public PlantArea3Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map86 : PlantArea3Map
    //{
    //    public PlantArea3Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map87 : PlantArea3Map
    //{
    //    public PlantArea3Map87()
    //    {
    //        cellName = "PlantArea3 1";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class PlantArea3Map88 : PlantArea3Map
    //{
    //    public PlantArea3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map89 : PlantArea3Map
    //{
    //    public PlantArea3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map90 : PlantArea3Map
    //{
    //    public PlantArea3Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map91 : PlantArea3Map
    //{
    //    public PlantArea3Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map92 : PlantArea3Map
    //{
    //    public PlantArea3Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map93 : PlantArea3Map
    //{
    //    public PlantArea3Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map94 : PlantArea3Map
    //{
    //    public PlantArea3Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map95 : PlantArea3Map
    //{
    //    public PlantArea3Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map96 : PlantArea3Map
    //{
    //    public PlantArea3Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map97 : PlantArea3Map
    //{
    //    public PlantArea3Map97()
    //    {
    //        cellName = "";
    //        cellLocation = 97;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 17;
    //        newLocation = 17;
    //    }
    //}
    //public class PlantArea3Map98 : PlantArea3Map
    //{
    //    public PlantArea3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class PlantArea3Map99 : PlantArea3Map
    //{
    //    public PlantArea3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}



    //public class ArbelleMap : WorldMap
    //{
    //    public ArbelleMap()
    //    {
    //        mapName = "arbelle";
    //        mapLocation = 19;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 0;
    //    }
    //}
    //public class ArbelleMap0 : ArbelleMap
    //{
    //    public ArbelleMap0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap1 : ArbelleMap
    //{
    //    public ArbelleMap1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap2 : ArbelleMap
    //{
    //    public ArbelleMap2()
    //    {
    //        cellName = "Arbelle 8";
    //        cellLocation = 2;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap3 : ArbelleMap
    //{
    //    public ArbelleMap3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap4 : ArbelleMap
    //{
    //    public ArbelleMap4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap5 : ArbelleMap
    //{
    //    public ArbelleMap5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap6 : ArbelleMap
    //{
    //    public ArbelleMap6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap7 : ArbelleMap
    //{
    //    public ArbelleMap7()
    //    {
    //        cellName = "Arbelle 14";
    //        cellLocation = 7;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap8 : ArbelleMap
    //{
    //    public ArbelleMap8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap9 : ArbelleMap
    //{
    //    public ArbelleMap9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap10 : ArbelleMap
    //{
    //    public ArbelleMap10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap11 : ArbelleMap
    //{
    //    public ArbelleMap11()
    //    {
    //        cellName = "Arbelle 6";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap12 : ArbelleMap
    //{
    //    public ArbelleMap12()
    //    {
    //        cellName = "Arbelle 7";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap13 : ArbelleMap
    //{
    //    public ArbelleMap13()
    //    {
    //        cellName = "Arbelle 9";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap14 : ArbelleMap
    //{
    //    public ArbelleMap14()
    //    {
    //        cellName = "Arbelle 10";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap15 : ArbelleMap
    //{
    //    public ArbelleMap15()
    //    {
    //        cellName = "Arbelle 11";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap16 : ArbelleMap
    //{
    //    public ArbelleMap16()
    //    {
    //        cellName = "Arbelle 12";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap17 : ArbelleMap
    //{
    //    public ArbelleMap17()
    //    {
    //        cellName = "Arbelle 13";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap18 : ArbelleMap
    //{
    //    public ArbelleMap18()
    //    {
    //        cellName = "Arbelle 15";
    //        cellLocation = 18;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap19 : ArbelleMap
    //{
    //    public ArbelleMap19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap20 : ArbelleMap
    //{
    //    public ArbelleMap20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap21 : ArbelleMap
    //{
    //    public ArbelleMap21()
    //    {
    //        cellName = "Arbelle 5";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap22 : ArbelleMap
    //{
    //    public ArbelleMap22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap23 : ArbelleMap
    //{
    //    public ArbelleMap23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap24 : ArbelleMap
    //{
    //    public ArbelleMap24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap25 : ArbelleMap
    //{
    //    public ArbelleMap25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap26 : ArbelleMap
    //{
    //    public ArbelleMap26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap27 : ArbelleMap
    //{
    //    public ArbelleMap27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap28 : ArbelleMap
    //{
    //    public ArbelleMap28()
    //    {
    //        cellName = "Arbelle 16";
    //        cellLocation = 28;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" }; 
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap29 : ArbelleMap
    //{
    //    public ArbelleMap29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap30 : ArbelleMap
    //{
    //    public ArbelleMap30()
    //    {
    //        cellName = "Arbelle 4";
    //        cellLocation = 30;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap31 : ArbelleMap
    //{
    //    public ArbelleMap31()
    //    {
    //        cellName = "Arbelle 3";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap32 : ArbelleMap
    //{
    //    public ArbelleMap32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap33 : ArbelleMap
    //{
    //    public ArbelleMap33()
    //    {
    //        cellName = "Arbelle 32";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap34 : ArbelleMap
    //{
    //    public ArbelleMap34()
    //    {
    //        cellName = "Arbelle 33";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap35 : ArbelleMap
    //{
    //    public ArbelleMap35()
    //    {
    //        cellName = "Arbelle 34";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap36 : ArbelleMap
    //{
    //    public ArbelleMap36()
    //    {
    //        cellName = "";
    //        cellLocation = 36;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 32;
    //        newLocation = 0;
    //    }
    //}
    //public class ArbelleMap37 : ArbelleMap
    //{
    //    public ArbelleMap37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap38 : ArbelleMap
    //{
    //    public ArbelleMap38()
    //    {
    //        cellName = "Arbelle 17";
    //        cellLocation = 38;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap39 : ArbelleMap
    //{
    //    public ArbelleMap39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap40 : ArbelleMap
    //{
    //    public ArbelleMap40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap41 : ArbelleMap
    //{
    //    public ArbelleMap41()
    //    {
    //        cellName = "Arbelle 2";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap42 : ArbelleMap
    //{
    //    public ArbelleMap42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap43 : ArbelleMap
    //{
    //    public ArbelleMap43()
    //    {
    //        cellName = "Arbelle 31";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap44 : ArbelleMap
    //{
    //    public ArbelleMap44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap45 : ArbelleMap
    //{
    //    public ArbelleMap45()
    //    {
    //        cellName = "Arbelle 35";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap46 : ArbelleMap
    //{
    //    public ArbelleMap46()
    //    {
    //        cellName = "Arbelle 36";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap47 : ArbelleMap
    //{
    //    public ArbelleMap47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap48 : ArbelleMap
    //{
    //    public ArbelleMap48()
    //    {
    //        cellName = "Arbelle 18";
    //        cellLocation = 48;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap49 : ArbelleMap
    //{
    //    public ArbelleMap49()
    //    {
    //        cellName = "Arbelle 19";
    //        cellLocation = 49;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap50 : ArbelleMap
    //{
    //    public ArbelleMap50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap51 : ArbelleMap
    //{
    //    public ArbelleMap51()
    //    {
    //        cellName = "Arbelle 1";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap52 : ArbelleMap
    //{
    //    public ArbelleMap52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap53 : ArbelleMap
    //{
    //    public ArbelleMap53()
    //    {
    //        cellName = "Arbelle 30";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap54 : ArbelleMap
    //{
    //    public ArbelleMap54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap55 : ArbelleMap
    //{
    //    public ArbelleMap55()
    //    {
    //        cellName = "";
    //        cellLocation = 55;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 32; //change
    //        newLocation = 0;
    //    }
    //}
    //public class ArbelleMap56 : ArbelleMap
    //{
    //    public ArbelleMap56()
    //    {
    //        cellName = "Arbelle 37";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap57 : ArbelleMap
    //{
    //    public ArbelleMap57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap58 : ArbelleMap
    //{
    //    public ArbelleMap58()
    //    {
    //        cellName = "Arbelle 20";
    //        cellLocation = 58;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "", "" };
    //    }
    //}
    //public class ArbelleMap59 : ArbelleMap
    //{
    //    public ArbelleMap59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap60 : ArbelleMap
    //{
    //    public ArbelleMap60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap61 : ArbelleMap
    //{
    //    public ArbelleMap61()
    //    {
    //        cellName = "";
    //        cellLocation = 61;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 18;
    //        newLocation = 11;
    //    }
    //}
    //public class ArbelleMap62 : ArbelleMap
    //{
    //    public ArbelleMap62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap63 : ArbelleMap
    //{
    //    public ArbelleMap63()
    //    {
    //        cellName = "Arbelle 29";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap64 : ArbelleMap
    //{
    //    public ArbelleMap64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap65 : ArbelleMap
    //{
    //    public ArbelleMap65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap66 : ArbelleMap
    //{
    //    public ArbelleMap66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap67 : ArbelleMap
    //{
    //    public ArbelleMap67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap68 : ArbelleMap
    //{
    //    public ArbelleMap68()
    //    {
    //        cellName = "Arbelle 21";
    //        cellLocation = 68;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap69 : ArbelleMap
    //{
    //    public ArbelleMap69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap70 : ArbelleMap
    //{
    //    public ArbelleMap70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap71 : ArbelleMap
    //{
    //    public ArbelleMap71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap72 : ArbelleMap
    //{
    //    public ArbelleMap72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap73 : ArbelleMap
    //{
    //    public ArbelleMap73()
    //    {
    //        cellName = "Arbelle 28";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap74 : ArbelleMap
    //{
    //    public ArbelleMap74()
    //    {
    //        cellName = "Arbelle 27";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap75 : ArbelleMap
    //{
    //    public ArbelleMap75()
    //    {
    //        cellName = "Arbelle 25";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap76 : ArbelleMap
    //{
    //    public ArbelleMap76()
    //    {
    //        cellName = "Arbelle 24";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap77 : ArbelleMap
    //{
    //    public ArbelleMap77()
    //    {
    //        cellName = "Arbelle 23";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap78 : ArbelleMap
    //{
    //    public ArbelleMap78()
    //    {
    //        cellName = "Arbelle 22";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap79 : ArbelleMap
    //{
    //    public ArbelleMap79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap80 : ArbelleMap
    //{
    //    public ArbelleMap80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap81 : ArbelleMap
    //{
    //    public ArbelleMap81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap82 : ArbelleMap
    //{
    //    public ArbelleMap82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap83 : ArbelleMap
    //{
    //    public ArbelleMap83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap84 : ArbelleMap
    //{
    //    public ArbelleMap84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap85 : ArbelleMap
    //{
    //    public ArbelleMap85()
    //    {
    //        cellName = "Arbelle 26";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class ArbelleMap86 : ArbelleMap
    //{
    //    public ArbelleMap86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap87 : ArbelleMap
    //{
    //    public ArbelleMap87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap88 : ArbelleMap
    //{
    //    public ArbelleMap88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap89 : ArbelleMap
    //{
    //    public ArbelleMap89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap90 : ArbelleMap
    //{
    //    public ArbelleMap90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap91 : ArbelleMap
    //{
    //    public ArbelleMap91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap92 : ArbelleMap
    //{
    //    public ArbelleMap92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap93 : ArbelleMap
    //{
    //    public ArbelleMap93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap94 : ArbelleMap
    //{
    //    public ArbelleMap94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap95 : ArbelleMap
    //{
    //    public ArbelleMap95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap96 : ArbelleMap
    //{
    //    public ArbelleMap96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap97 : ArbelleMap
    //{
    //    public ArbelleMap97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap98 : ArbelleMap
    //{
    //    public ArbelleMap98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class ArbelleMap99 : ArbelleMap
    //{
    //    public ArbelleMap99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class EarthArea1Map : WorldMap
    //{
    //    public EarthArea1Map()
    //    {
    //        mapName = "earth area 1";
    //        mapLocation = 8;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class EarthArea1Map0 : EarthArea1Map
    //{
    //    public EarthArea1Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map1 : EarthArea1Map
    //{
    //    public EarthArea1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map2 : EarthArea1Map
    //{
    //    public EarthArea1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map3 : EarthArea1Map
    //{
    //    public EarthArea1Map3()
    //    {
    //        cellName = "eartharea1 5";
    //        cellLocation = 3;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map4 : EarthArea1Map
    //{
    //    public EarthArea1Map4()
    //    {
    //        cellName = "eartharea1 10";
    //        cellLocation = 4;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map5 : EarthArea1Map
    //{
    //    public EarthArea1Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map6 : EarthArea1Map
    //{
    //    public EarthArea1Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map7 : EarthArea1Map
    //{
    //    public EarthArea1Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map8 : EarthArea1Map
    //{
    //    public EarthArea1Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map9 : EarthArea1Map
    //{
    //    public EarthArea1Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map10 : EarthArea1Map
    //{
    //    public EarthArea1Map10()
    //    {
    //        cellName = "";
    //        cellLocation = 10;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 58;
    //    }
    //}
    //public class EarthArea1Map11 : EarthArea1Map
    //{
    //    public EarthArea1Map11()
    //    {
    //        cellName = "eartharea1 1";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        firstVisit = true;
    //    }
    //}
    //public class EarthArea1Map12 : EarthArea1Map
    //{
    //    public EarthArea1Map12()
    //    {
    //        cellName = "eartharea1 2";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map13 : EarthArea1Map
    //{
    //    public EarthArea1Map13()
    //    {
    //        cellName = "eartharea1 6";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map14 : EarthArea1Map
    //{
    //    public EarthArea1Map14()
    //    {
    //        cellName = "eartharea1 11";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map15 : EarthArea1Map
    //{
    //    public EarthArea1Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map16 : EarthArea1Map
    //{
    //    public EarthArea1Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map17 : EarthArea1Map
    //{
    //    public EarthArea1Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map18 : EarthArea1Map
    //{
    //    public EarthArea1Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map19 : EarthArea1Map
    //{
    //    public EarthArea1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map20 : EarthArea1Map
    //{
    //    public EarthArea1Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map21 : EarthArea1Map
    //{
    //    public EarthArea1Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map22 : EarthArea1Map
    //{
    //    public EarthArea1Map22()
    //    {
    //        cellName = "eartharea1 3";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map23 : EarthArea1Map
    //{
    //    public EarthArea1Map23()
    //    {
    //        cellName = "eartharea1 7";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map24 : EarthArea1Map
    //{
    //    public EarthArea1Map24()
    //    {
    //        cellName = "eartharea1 12";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map25 : EarthArea1Map
    //{
    //    public EarthArea1Map25()
    //    {
    //        cellName = "eartharea1 17";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map26 : EarthArea1Map
    //{
    //    public EarthArea1Map26()
    //    {
    //        cellName = "eartharea1 23";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map27 : EarthArea1Map
    //{
    //    public EarthArea1Map27()
    //    {
    //        cellName = "eartharea1 28";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map28 : EarthArea1Map
    //{
    //    public EarthArea1Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map29 : EarthArea1Map
    //{
    //    public EarthArea1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map30 : EarthArea1Map
    //{
    //    public EarthArea1Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map31 : EarthArea1Map
    //{
    //    public EarthArea1Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map32 : EarthArea1Map
    //{
    //    public EarthArea1Map32()
    //    {
    //        cellName = "eartharea1 4";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map33 : EarthArea1Map
    //{
    //    public EarthArea1Map33()
    //    {
    //        cellName = "eartharea1 8";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map34 : EarthArea1Map
    //{
    //    public EarthArea1Map34()
    //    {
    //        cellName = "eartharea1 13";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map35 : EarthArea1Map
    //{
    //    public EarthArea1Map35()
    //    {
    //        cellName = "eartharea1 18";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map36 : EarthArea1Map
    //{
    //    public EarthArea1Map36()
    //    {
    //        cellName = "eartharea1 24";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map37 : EarthArea1Map
    //{
    //    public EarthArea1Map37()
    //    {
    //        cellName = "eartharea1 29";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map38 : EarthArea1Map
    //{
    //    public EarthArea1Map38()
    //    {
    //        cellName = "";
    //        cellLocation = 38;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 20;
    //        newLocation = 21;
    //    }
    //}
    //public class EarthArea1Map39 : EarthArea1Map
    //{
    //    public EarthArea1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map40 : EarthArea1Map
    //{
    //    public EarthArea1Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map41 : EarthArea1Map
    //{
    //    public EarthArea1Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map42 : EarthArea1Map
    //{
    //    public EarthArea1Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map43 : EarthArea1Map
    //{
    //    public EarthArea1Map43()
    //    {
    //        cellName = "eartharea1 9";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map44 : EarthArea1Map
    //{
    //    public EarthArea1Map44()
    //    {
    //        cellName = "plantarea1 14";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map45 : EarthArea1Map
    //{
    //    public EarthArea1Map45()
    //    {
    //        cellName = "eartharea1 19";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map46 : EarthArea1Map
    //{
    //    public EarthArea1Map46()
    //    {
    //        cellName = "eartharea1 25";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map47 : EarthArea1Map
    //{
    //    public EarthArea1Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map48 : EarthArea1Map
    //{
    //    public EarthArea1Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map49 : EarthArea1Map
    //{
    //    public EarthArea1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map50 : EarthArea1Map
    //{
    //    public EarthArea1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map51 : EarthArea1Map
    //{
    //    public EarthArea1Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map52 : EarthArea1Map
    //{
    //    public EarthArea1Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map53 : EarthArea1Map
    //{
    //    public EarthArea1Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map54 : EarthArea1Map
    //{
    //    public EarthArea1Map54()
    //    {
    //        cellName = "eartharea1 15";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map55 : EarthArea1Map
    //{
    //    public EarthArea1Map55()
    //    {
    //        cellName = "eartharea1 20";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map56 : EarthArea1Map
    //{
    //    public EarthArea1Map56()
    //    {
    //        cellName = "eartharea1 27";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map57 : EarthArea1Map
    //{
    //    public EarthArea1Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map58 : EarthArea1Map
    //{
    //    public EarthArea1Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map59 : EarthArea1Map
    //{
    //    public EarthArea1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map60 : EarthArea1Map
    //{
    //    public EarthArea1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map61 : EarthArea1Map
    //{
    //    public EarthArea1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map62 : EarthArea1Map
    //{
    //    public EarthArea1Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map63 : EarthArea1Map
    //{
    //    public EarthArea1Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map64 : EarthArea1Map
    //{
    //    public EarthArea1Map64()
    //    {
    //        cellName = "eartharea1 16";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map65 : EarthArea1Map
    //{
    //    public EarthArea1Map65()
    //    {
    //        cellName = "eartharea1 21";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map66 : EarthArea1Map
    //{
    //    public EarthArea1Map66()
    //    {
    //        cellName = "eartharea1 27";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map67 : EarthArea1Map
    //{
    //    public EarthArea1Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map68 : EarthArea1Map
    //{
    //    public EarthArea1Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map69 : EarthArea1Map
    //{
    //    public EarthArea1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map70 : EarthArea1Map
    //{
    //    public EarthArea1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map71 : EarthArea1Map
    //{
    //    public EarthArea1Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map72 : EarthArea1Map
    //{
    //    public EarthArea1Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map73 : EarthArea1Map
    //{
    //    public EarthArea1Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map74 : EarthArea1Map
    //{
    //    public EarthArea1Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map75 : EarthArea1Map
    //{
    //    public EarthArea1Map75()
    //    {
    //        cellName = "eartharea1 22";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea1Map76 : EarthArea1Map
    //{
    //    public EarthArea1Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map77 : EarthArea1Map
    //{
    //    public EarthArea1Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map78 : EarthArea1Map
    //{
    //    public EarthArea1Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map79 : EarthArea1Map
    //{
    //    public EarthArea1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map80 : EarthArea1Map
    //{
    //    public EarthArea1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map81 : EarthArea1Map
    //{
    //    public EarthArea1Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map82 : EarthArea1Map
    //{
    //    public EarthArea1Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map83 : EarthArea1Map
    //{
    //    public EarthArea1Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map84 : EarthArea1Map
    //{
    //    public EarthArea1Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map85 : EarthArea1Map
    //{
    //    public EarthArea1Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map86 : EarthArea1Map
    //{
    //    public EarthArea1Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map87 : EarthArea1Map
    //{
    //    public EarthArea1Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map88 : EarthArea1Map
    //{
    //    public EarthArea1Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map89 : EarthArea1Map
    //{
    //    public EarthArea1Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map90 : EarthArea1Map
    //{
    //    public EarthArea1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map91 : EarthArea1Map
    //{
    //    public EarthArea1Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map92 : EarthArea1Map
    //{
    //    public EarthArea1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map93 : EarthArea1Map
    //{
    //    public EarthArea1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map94 : EarthArea1Map
    //{
    //    public EarthArea1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map95 : EarthArea1Map
    //{
    //    public EarthArea1Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map96 : EarthArea1Map
    //{
    //    public EarthArea1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map97 : EarthArea1Map
    //{
    //    public EarthArea1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map98 : EarthArea1Map
    //{
    //    public EarthArea1Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea1Map99 : EarthArea1Map
    //{
    //    public EarthArea1Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}



    //public class EarthArea2Map : WorldMap
    //{
    //    public EarthArea2Map()
    //    {
    //        mapName = "earth area 2";
    //        mapLocation = 20;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class EarthArea2Map0 : EarthArea2Map
    //{
    //    public EarthArea2Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map1 : EarthArea2Map
    //{
    //    public EarthArea2Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map2 : EarthArea2Map
    //{
    //    public EarthArea2Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map3 : EarthArea2Map
    //{
    //    public EarthArea2Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map4 : EarthArea2Map
    //{
    //    public EarthArea2Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map5 : EarthArea2Map
    //{
    //    public EarthArea2Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map6 : EarthArea2Map
    //{
    //    public EarthArea2Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map7 : EarthArea2Map
    //{
    //    public EarthArea2Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map8 : EarthArea2Map
    //{
    //    public EarthArea2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map9 : EarthArea2Map
    //{
    //    public EarthArea2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map10 : EarthArea2Map
    //{
    //    public EarthArea2Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map11 : EarthArea2Map
    //{
    //    public EarthArea2Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map12 : EarthArea2Map
    //{
    //    public EarthArea2Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map13 : EarthArea2Map
    //{
    //    public EarthArea2Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map14 : EarthArea2Map
    //{
    //    public EarthArea2Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map15 : EarthArea2Map
    //{
    //    public EarthArea2Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map16 : EarthArea2Map
    //{
    //    public EarthArea2Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map17 : EarthArea2Map
    //{
    //    public EarthArea2Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map18 : EarthArea2Map
    //{
    //    public EarthArea2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map19 : EarthArea2Map
    //{
    //    public EarthArea2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map20 : EarthArea2Map
    //{
    //    public EarthArea2Map20()
    //    {
    //        cellName = "";
    //        cellLocation = 20;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 8;
    //        newLocation = 29;
    //    }
    //}
    //public class EarthArea2Map21 : EarthArea2Map
    //{
    //    public EarthArea2Map21()
    //    {
    //        cellName = "EarthArea2 1";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map22 : EarthArea2Map
    //{
    //    public EarthArea2Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map23 : EarthArea2Map
    //{
    //    public EarthArea2Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map24 : EarthArea2Map
    //{
    //    public EarthArea2Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map25 : EarthArea2Map
    //{
    //    public EarthArea2Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map26 : EarthArea2Map
    //{
    //    public EarthArea2Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map27 : EarthArea2Map
    //{
    //    public EarthArea2Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map28 : EarthArea2Map
    //{
    //    public EarthArea2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map29 : EarthArea2Map
    //{
    //    public EarthArea2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map30 : EarthArea2Map
    //{
    //    public EarthArea2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map31 : EarthArea2Map
    //{
    //    public EarthArea2Map31()
    //    {
    //        cellName = "EarthArea2 2";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map32 : EarthArea2Map
    //{
    //    public EarthArea2Map32()
    //    {
    //        cellName = "EarthArea2 6";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map33 : EarthArea2Map
    //{
    //    public EarthArea2Map33()
    //    {
    //        cellName = "EarthArea2 7";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map34 : EarthArea2Map
    //{
    //    public EarthArea2Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map35 : EarthArea2Map
    //{
    //    public EarthArea2Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map36 : EarthArea2Map
    //{
    //    public EarthArea2Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map37 : EarthArea2Map
    //{
    //    public EarthArea2Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map38 : EarthArea2Map
    //{
    //    public EarthArea2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map39 : EarthArea2Map
    //{
    //    public EarthArea2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map40 : EarthArea2Map
    //{
    //    public EarthArea2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map41 : EarthArea2Map
    //{
    //    public EarthArea2Map41()
    //    {
    //        cellName = "EarthArea2 3";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map42 : EarthArea2Map
    //{
    //    public EarthArea2Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map43 : EarthArea2Map
    //{
    //    public EarthArea2Map43()
    //    {
    //        cellName = "EarthArea2 8";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map44 : EarthArea2Map
    //{
    //    public EarthArea2Map44()
    //    {
    //        cellName = "EarthArea2 9";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map45 : EarthArea2Map
    //{
    //    public EarthArea2Map45()
    //    {
    //        cellName = "EarthArea2 10";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map46 : EarthArea2Map
    //{
    //    public EarthArea2Map46()
    //    {
    //        cellName = "EarthArea2 11";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map47 : EarthArea2Map
    //{
    //    public EarthArea2Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map48 : EarthArea2Map
    //{
    //    public EarthArea2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map49 : EarthArea2Map
    //{
    //    public EarthArea2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map50 : EarthArea2Map
    //{
    //    public EarthArea2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map51 : EarthArea2Map
    //{
    //    public EarthArea2Map51()
    //    {
    //        cellName = "EarthArea2 4";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map52 : EarthArea2Map
    //{
    //    public EarthArea2Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map53 : EarthArea2Map
    //{
    //    public EarthArea2Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map54 : EarthArea2Map
    //{
    //    public EarthArea2Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map55 : EarthArea2Map
    //{
    //    public EarthArea2Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map56 : EarthArea2Map
    //{
    //    public EarthArea2Map56()
    //    {
    //        cellName = "EarthArea2 12";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map57 : EarthArea2Map
    //{
    //    public EarthArea2Map57()
    //    {
    //        cellName = "EarthArea2 13";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map58 : EarthArea2Map
    //{
    //    public EarthArea2Map58()
    //    {
    //        cellName = "EarthArea2 14";
    //        cellLocation = 58;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map59 : EarthArea2Map
    //{
    //    public EarthArea2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map60 : EarthArea2Map
    //{
    //    public EarthArea2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map61 : EarthArea2Map
    //{
    //    public EarthArea2Map61()
    //    {
    //        cellName = "EarthArea2 5";
    //        cellLocation = 61;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map62 : EarthArea2Map
    //{
    //    public EarthArea2Map62()
    //    {
    //        cellName = "EarthArea2 19";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map63 : EarthArea2Map
    //{
    //    public EarthArea2Map63()
    //    {
    //        cellName = "EarthArea2 20";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map64 : EarthArea2Map
    //{
    //    public EarthArea2Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map65 : EarthArea2Map
    //{
    //    public EarthArea2Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map66 : EarthArea2Map
    //{
    //    public EarthArea2Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map67 : EarthArea2Map
    //{
    //    public EarthArea2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map68 : EarthArea2Map
    //{
    //    public EarthArea2Map68()
    //    {
    //        cellName = "EarthArea2 15";
    //        cellLocation = 68;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map69 : EarthArea2Map
    //{
    //    public EarthArea2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map70 : EarthArea2Map
    //{
    //    public EarthArea2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map71 : EarthArea2Map
    //{
    //    public EarthArea2Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map72 : EarthArea2Map
    //{
    //    public EarthArea2Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map73 : EarthArea2Map
    //{
    //    public EarthArea2Map73()
    //    {
    //        cellName = "EarthArea2 21";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map74 : EarthArea2Map
    //{
    //    public EarthArea2Map74()
    //    {
    //        cellName = "EarthArea2 22";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map75 : EarthArea2Map
    //{
    //    public EarthArea2Map75()
    //    {
    //        cellName = "EarthArea2 23";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map76 : EarthArea2Map
    //{
    //    public EarthArea2Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map77 : EarthArea2Map
    //{
    //    public EarthArea2Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map78 : EarthArea2Map
    //{
    //    public EarthArea2Map78()
    //    {
    //        cellName = "EarthArea2 16";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map79 : EarthArea2Map
    //{
    //    public EarthArea2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map80 : EarthArea2Map
    //{
    //    public EarthArea2Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map81 : EarthArea2Map
    //{
    //    public EarthArea2Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map82 : EarthArea2Map
    //{
    //    public EarthArea2Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map83 : EarthArea2Map
    //{
    //    public EarthArea2Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map84 : EarthArea2Map
    //{
    //    public EarthArea2Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map85 : EarthArea2Map
    //{
    //    public EarthArea2Map85()
    //    {
    //        cellName = "EarthArea2 24";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map86 : EarthArea2Map
    //{
    //    public EarthArea2Map86()
    //    {
    //        cellName = "EarthArea2 25";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map87 : EarthArea2Map
    //{
    //    public EarthArea2Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map88 : EarthArea2Map
    //{
    //    public EarthArea2Map88()
    //    {
    //        cellName = "EarthArea2 17";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map89 : EarthArea2Map
    //{
    //    public EarthArea2Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map90 : EarthArea2Map
    //{
    //    public EarthArea2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map91 : EarthArea2Map
    //{
    //    public EarthArea2Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map92 : EarthArea2Map
    //{
    //    public EarthArea2Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map93 : EarthArea2Map
    //{
    //    public EarthArea2Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map94 : EarthArea2Map
    //{
    //    public EarthArea2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map95 : EarthArea2Map
    //{
    //    public EarthArea2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea2Map96 : EarthArea2Map
    //{
    //    public EarthArea2Map96()
    //    {
    //        cellName = "EarthArea2 26";
    //        cellLocation = 96;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map97 : EarthArea2Map
    //{
    //    public EarthArea2Map97()
    //    {
    //        cellName = "EarthArea2 27";
    //        cellLocation = 97;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map98 : EarthArea2Map
    //{
    //    public EarthArea2Map98()
    //    {
    //        cellName = "EarthArea2 18";
    //        cellLocation = 98;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea2Map99 : EarthArea2Map
    //{
    //    public EarthArea2Map99()
    //    {
    //        cellName = "";
    //        cellLocation = 99;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 21;
    //        newLocation = 11;
    //    }
    //}

    //public class EarthArea3Map : WorldMap
    //{
    //    public EarthArea3Map()
    //    {
    //        mapName = "earth area 3";
    //        mapLocation = 21;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class EarthArea3Map0 : EarthArea3Map
    //{
    //    public EarthArea3Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map1 : EarthArea3Map
    //{
    //    public EarthArea3Map1()
    //    {
    //        cellName = "";
    //        cellLocation = 1;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 20;
    //        newLocation = 98;
    //    }
    //}
    //public class EarthArea3Map2 : EarthArea3Map
    //{
    //    public EarthArea3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map3 : EarthArea3Map
    //{
    //    public EarthArea3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map4 : EarthArea3Map
    //{
    //    public EarthArea3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map5 : EarthArea3Map
    //{
    //    public EarthArea3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map6 : EarthArea3Map
    //{
    //    public EarthArea3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map7 : EarthArea3Map
    //{
    //    public EarthArea3Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map8 : EarthArea3Map
    //{
    //    public EarthArea3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map9 : EarthArea3Map
    //{
    //    public EarthArea3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map10 : EarthArea3Map
    //{
    //    public EarthArea3Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map11 : EarthArea3Map
    //{
    //    public EarthArea3Map11()
    //    {
    //        cellName = "EarthArea3 1";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map12 : EarthArea3Map
    //{
    //    public EarthArea3Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map13 : EarthArea3Map
    //{
    //    public EarthArea3Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map14 : EarthArea3Map
    //{
    //    public EarthArea3Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map15 : EarthArea3Map
    //{
    //    public EarthArea3Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map16 : EarthArea3Map
    //{
    //    public EarthArea3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map17 : EarthArea3Map
    //{
    //    public EarthArea3Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map18 : EarthArea3Map
    //{
    //    public EarthArea3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map19 : EarthArea3Map
    //{
    //    public EarthArea3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map20 : EarthArea3Map
    //{
    //    public EarthArea3Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map21 : EarthArea3Map
    //{
    //    public EarthArea3Map21()
    //    {
    //        cellName = "EarthArea3 2";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map22 : EarthArea3Map
    //{
    //    public EarthArea3Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map23 : EarthArea3Map
    //{
    //    public EarthArea3Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map24 : EarthArea3Map
    //{
    //    public EarthArea3Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map25 : EarthArea3Map
    //{
    //    public EarthArea3Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map26 : EarthArea3Map
    //{
    //    public EarthArea3Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map27 : EarthArea3Map
    //{
    //    public EarthArea3Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map28 : EarthArea3Map
    //{
    //    public EarthArea3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map29 : EarthArea3Map
    //{
    //    public EarthArea3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map30 : EarthArea3Map
    //{
    //    public EarthArea3Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map31 : EarthArea3Map
    //{
    //    public EarthArea3Map31()
    //    {
    //        cellName = "EarthArea3 3";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map32 : EarthArea3Map
    //{
    //    public EarthArea3Map32()
    //    {
    //        cellName = "EarthArea3 6";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map33 : EarthArea3Map
    //{
    //    public EarthArea3Map33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map34 : EarthArea3Map
    //{
    //    public EarthArea3Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map35 : EarthArea3Map
    //{
    //    public EarthArea3Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map36 : EarthArea3Map
    //{
    //    public EarthArea3Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map37 : EarthArea3Map
    //{
    //    public EarthArea3Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map38 : EarthArea3Map
    //{
    //    public EarthArea3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map39 : EarthArea3Map
    //{
    //    public EarthArea3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map40 : EarthArea3Map
    //{
    //    public EarthArea3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map41 : EarthArea3Map
    //{
    //    public EarthArea3Map41()
    //    {
    //        cellName = "EarthArea3 4";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map42 : EarthArea3Map
    //{
    //    public EarthArea3Map42()
    //    {
    //        cellName = "EarthArea3 7";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map43 : EarthArea3Map
    //{
    //    public EarthArea3Map43()
    //    {
    //        cellName = "EarthArea3 12";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map44 : EarthArea3Map
    //{
    //    public EarthArea3Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map45 : EarthArea3Map
    //{
    //    public EarthArea3Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map46 : EarthArea3Map
    //{
    //    public EarthArea3Map46()
    //    {
    //        cellName = "EarthArea3 19";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map47 : EarthArea3Map
    //{
    //    public EarthArea3Map47()
    //    {
    //        cellName = "EarthArea3 23";
    //        cellLocation = 47;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map48 : EarthArea3Map
    //{
    //    public EarthArea3Map48()
    //    {
    //        cellName = "EarthArea3 25";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map49 : EarthArea3Map
    //{
    //    public EarthArea3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map50 : EarthArea3Map
    //{
    //    public EarthArea3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map51 : EarthArea3Map
    //{
    //    public EarthArea3Map51()
    //    {
    //        cellName = "EarthArea3 5";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map52 : EarthArea3Map
    //{
    //    public EarthArea3Map52()
    //    {
    //        cellName = "EarthArea3 8";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map53 : EarthArea3Map
    //{
    //    public EarthArea3Map53()
    //    {
    //        cellName = "EarthArea3 13";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map54 : EarthArea3Map
    //{
    //    public EarthArea3Map54()
    //    {
    //        cellName = "EarthArea3 14";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map55 : EarthArea3Map
    //{
    //    public EarthArea3Map55()
    //    {
    //        cellName = "EarthArea3 15";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map56 : EarthArea3Map
    //{
    //    public EarthArea3Map56()
    //    {
    //        cellName = "EarthArea3 20";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map57 : EarthArea3Map
    //{
    //    public EarthArea3Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map58 : EarthArea3Map
    //{
    //    public EarthArea3Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map59 : EarthArea3Map
    //{
    //    public EarthArea3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map60 : EarthArea3Map
    //{
    //    public EarthArea3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map61 : EarthArea3Map
    //{
    //    public EarthArea3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map62 : EarthArea3Map
    //{
    //    public EarthArea3Map62()
    //    {
    //        cellName = "EarthArea3 9";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map63 : EarthArea3Map
    //{
    //    public EarthArea3Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map64 : EarthArea3Map
    //{
    //    public EarthArea3Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map65 : EarthArea3Map
    //{
    //    public EarthArea3Map65()
    //    {
    //        cellName = "EarthArea3 16";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map66 : EarthArea3Map
    //{
    //    public EarthArea3Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map67 : EarthArea3Map
    //{
    //    public EarthArea3Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map68 : EarthArea3Map
    //{
    //    public EarthArea3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map69 : EarthArea3Map
    //{
    //    public EarthArea3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map70 : EarthArea3Map
    //{
    //    public EarthArea3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map71 : EarthArea3Map
    //{
    //    public EarthArea3Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map72 : EarthArea3Map
    //{
    //    public EarthArea3Map72()
    //    {
    //        cellName = "EarthArea3 10";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map73 : EarthArea3Map
    //{
    //    public EarthArea3Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map74 : EarthArea3Map
    //{
    //    public EarthArea3Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map75 : EarthArea3Map
    //{
    //    public EarthArea3Map75()
    //    {
    //        cellName = "EarthArea3 17";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map76 : EarthArea3Map
    //{
    //    public EarthArea3Map76()
    //    {
    //        cellName = "EarthArea3 21";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map77 : EarthArea3Map
    //{
    //    public EarthArea3Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map78 : EarthArea3Map
    //{
    //    public EarthArea3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map79 : EarthArea3Map
    //{
    //    public EarthArea3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map80 : EarthArea3Map
    //{
    //    public EarthArea3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map81 : EarthArea3Map
    //{
    //    public EarthArea3Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map82 : EarthArea3Map
    //{
    //    public EarthArea3Map82()
    //    {
    //        cellName = "EarthArea3 11";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map83 : EarthArea3Map
    //{
    //    public EarthArea3Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map84 : EarthArea3Map
    //{
    //    public EarthArea3Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map85 : EarthArea3Map
    //{
    //    public EarthArea3Map85()
    //    {
    //        cellName = "EarthArea3 18";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map86 : EarthArea3Map
    //{
    //    public EarthArea3Map86()
    //    {
    //        cellName = "EarthArea3 22";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map87 : EarthArea3Map
    //{
    //    public EarthArea3Map87()
    //    {
    //        cellName = "EarthArea3 24";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class EarthArea3Map88 : EarthArea3Map
    //{
    //    public EarthArea3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map89 : EarthArea3Map
    //{
    //    public EarthArea3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map90 : EarthArea3Map
    //{
    //    public EarthArea3Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map91 : EarthArea3Map
    //{
    //    public EarthArea3Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map92 : EarthArea3Map
    //{
    //    public EarthArea3Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map93 : EarthArea3Map
    //{
    //    public EarthArea3Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map94 : EarthArea3Map
    //{
    //    public EarthArea3Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map95 : EarthArea3Map
    //{
    //    public EarthArea3Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map96 : EarthArea3Map
    //{
    //    public EarthArea3Map96()
    //    {
    //        cellName = "";
    //        cellLocation = 96;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 22;
    //        newLocation = 14;
    //    }
    //}
    //public class EarthArea3Map97 : EarthArea3Map
    //{
    //    public EarthArea3Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map98 : EarthArea3Map
    //{
    //    public EarthArea3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class EarthArea3Map99 : EarthArea3Map
    //{
    //    public EarthArea3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class GrabenMap : WorldMap
    //{
    //    public GrabenMap()
    //    {
    //        mapName = "graben";
    //        mapLocation = 22;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 0;
    //    }
    //}
    //public class GrabenMap0 : GrabenMap
    //{
    //    public GrabenMap0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap1 : GrabenMap
    //{
    //    public GrabenMap1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap2 : GrabenMap
    //{
    //    public GrabenMap2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap3 : GrabenMap
    //{
    //    public GrabenMap3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap4 : GrabenMap
    //{
    //    public GrabenMap4()
    //    {
    //        cellName = "";
    //        cellLocation = 4;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 21;
    //        newLocation = 86;
    //    }
    //}
    //public class GrabenMap5 : GrabenMap
    //{
    //    public GrabenMap5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap6 : GrabenMap
    //{
    //    public GrabenMap6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap7 : GrabenMap
    //{
    //    public GrabenMap7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap8 : GrabenMap
    //{
    //    public GrabenMap8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap9 : GrabenMap
    //{
    //    public GrabenMap9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap10 : GrabenMap
    //{
    //    public GrabenMap10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap11 : GrabenMap
    //{
    //    public GrabenMap11()
    //    {
    //        cellName = "Graben 1";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap12 : GrabenMap
    //{
    //    public GrabenMap12()
    //    {
    //        cellName = "Graben 2";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap13 : GrabenMap
    //{
    //    public GrabenMap13()
    //    {
    //        cellName = "Graben 3";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap14 : GrabenMap
    //{
    //    public GrabenMap14()
    //    {
    //        cellName = "Graben 4";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap15 : GrabenMap
    //{
    //    public GrabenMap15()
    //    {
    //        cellName = "Graben 5";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap16 : GrabenMap
    //{
    //    public GrabenMap16()
    //    {
    //        cellName = "Graben 6";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap17 : GrabenMap
    //{
    //    public GrabenMap17()
    //    {
    //        cellName = "Graben 7";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap18 : GrabenMap
    //{
    //    public GrabenMap18()
    //    {
    //        cellName = "Graben 8";
    //        cellLocation = 18;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap19 : GrabenMap
    //{
    //    public GrabenMap19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap20 : GrabenMap
    //{
    //    public GrabenMap20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap21 : GrabenMap
    //{
    //    public GrabenMap21()
    //    {
    //        cellName = "Graben 9";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap22 : GrabenMap
    //{
    //    public GrabenMap22()
    //    {
    //        cellName = "Graben 10";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap23 : GrabenMap
    //{
    //    public GrabenMap23()
    //    {
    //        cellName = "Graben 11";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap24 : GrabenMap
    //{
    //    public GrabenMap24()
    //    {
    //        cellName = "Graben 12";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap25 : GrabenMap
    //{
    //    public GrabenMap25()
    //    {
    //        cellName = "Graben 13";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap26 : GrabenMap
    //{
    //    public GrabenMap26()
    //    {
    //        cellName = "Graben 14";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap27 : GrabenMap
    //{
    //    public GrabenMap27()
    //    {
    //        cellName = "Graben 15";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap28 : GrabenMap
    //{
    //    public GrabenMap28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap29 : GrabenMap
    //{
    //    public GrabenMap29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap30 : GrabenMap
    //{
    //    public GrabenMap30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap31 : GrabenMap
    //{
    //    public GrabenMap31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap32 : GrabenMap
    //{
    //    public GrabenMap32()
    //    {
    //        cellName = "Graben 16";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap33 : GrabenMap
    //{
    //    public GrabenMap33()
    //    {
    //        cellName = "Graben 17";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap34 : GrabenMap
    //{
    //    public GrabenMap34()
    //    {
    //        cellName = "Graben 18";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap35 : GrabenMap
    //{
    //    public GrabenMap35()
    //    {
    //        cellName = "Graben 19";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap36 : GrabenMap
    //{
    //    public GrabenMap36()
    //    {
    //        cellName = "Graben 20";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap37 : GrabenMap
    //{
    //    public GrabenMap37()
    //    {
    //        cellName = "Graben 21";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap38 : GrabenMap
    //{
    //    public GrabenMap38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap39 : GrabenMap
    //{
    //    public GrabenMap39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap40 : GrabenMap
    //{
    //    public GrabenMap40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap41 : GrabenMap
    //{
    //    public GrabenMap41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap42 : GrabenMap
    //{
    //    public GrabenMap42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap43 : GrabenMap
    //{
    //    public GrabenMap43()
    //    {
    //        cellName = "Graben 22";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap44 : GrabenMap
    //{
    //    public GrabenMap44()
    //    {
    //        cellName = "Graben 23";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap45 : GrabenMap
    //{
    //    public GrabenMap45()
    //    {
    //        cellName = "Graben 24";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap46 : GrabenMap
    //{
    //    public GrabenMap46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap47 : GrabenMap
    //{
    //    public GrabenMap47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap48 : GrabenMap
    //{
    //    public GrabenMap48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap49 : GrabenMap
    //{
    //    public GrabenMap49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap50 : GrabenMap
    //{
    //    public GrabenMap50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap51 : GrabenMap
    //{
    //    public GrabenMap51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap52 : GrabenMap
    //{
    //    public GrabenMap52()
    //    {
    //       cellName = "Graben 25";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap53 : GrabenMap
    //{
    //    public GrabenMap53()
    //    {
    //       cellName = "Graben 26";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap54 : GrabenMap
    //{
    //    public GrabenMap54()
    //    {
    //        cellName = "Graben 27";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap55 : GrabenMap
    //{
    //    public GrabenMap55()
    //    {
    //        cellName = "Graben 28";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap56 : GrabenMap
    //{
    //    public GrabenMap56()
    //    {
    //        cellName = "Graben 29";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap57 : GrabenMap
    //{
    //    public GrabenMap57()
    //    {
    //        cellName = "Graben 30";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap58 : GrabenMap
    //{
    //    public GrabenMap58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 35;
    //        newLocation = 0; //change
    //    }
    //}
    //public class GrabenMap59 : GrabenMap
    //{
    //    public GrabenMap59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap60 : GrabenMap
    //{
    //    public GrabenMap60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap61 : GrabenMap
    //{
    //    public GrabenMap61()
    //    {
    //       cellName = "Graben 31";
    //        cellLocation = 61;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap62 : GrabenMap
    //{
    //    public GrabenMap62()
    //    {
    //       cellName = "Graben 32";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap63 : GrabenMap
    //{
    //    public GrabenMap63()
    //    {
    //       cellName = "Graben 33";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap64 : GrabenMap
    //{
    //    public GrabenMap64()
    //    {
    //        cellName = "Graben 34";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap65 : GrabenMap
    //{
    //    public GrabenMap65()
    //    {
    //        cellName = "Graben 35";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap66 : GrabenMap
    //{
    //    public GrabenMap66()
    //    {
    //        cellName = "Graben 36";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap67 : GrabenMap
    //{
    //    public GrabenMap67()
    //    {
    //        cellName = "Graben 37";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class GrabenMap68 : GrabenMap
    //{
    //    public GrabenMap68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap69 : GrabenMap
    //{
    //    public GrabenMap69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap70 : GrabenMap
    //{
    //    public GrabenMap70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap71 : GrabenMap
    //{
    //    public GrabenMap71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap72 : GrabenMap
    //{
    //    public GrabenMap72()
    //    {
    //        cellName = "";
    //        cellLocation = 72;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        newMap = 35;
    //        newLocation = 0; //change
    //    }
    //}
    //public class GrabenMap73 : GrabenMap
    //{
    //    public GrabenMap73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap74 : GrabenMap
    //{
    //    public GrabenMap74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap75 : GrabenMap
    //{
    //    public GrabenMap75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap76 : GrabenMap
    //{
    //    public GrabenMap76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap77 : GrabenMap
    //{
    //    public GrabenMap77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap78 : GrabenMap
    //{
    //    public GrabenMap78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap79 : GrabenMap
    //{
    //    public GrabenMap79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap80 : GrabenMap
    //{
    //    public GrabenMap80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap81 : GrabenMap
    //{
    //    public GrabenMap81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap82 : GrabenMap
    //{
    //    public GrabenMap82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap83 : GrabenMap
    //{
    //    public GrabenMap83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap84 : GrabenMap
    //{
    //    public GrabenMap84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap85 : GrabenMap
    //{
    //    public GrabenMap85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap86 : GrabenMap
    //{
    //    public GrabenMap86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap87 : GrabenMap
    //{
    //    public GrabenMap87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap88 : GrabenMap
    //{
    //    public GrabenMap88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap89 : GrabenMap
    //{
    //    public GrabenMap89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap90 : GrabenMap
    //{
    //    public GrabenMap90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap91 : GrabenMap
    //{
    //    public GrabenMap91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap92 : GrabenMap
    //{
    //    public GrabenMap92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap93 : GrabenMap
    //{
    //    public GrabenMap93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap94 : GrabenMap
    //{
    //    public GrabenMap94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap95 : GrabenMap
    //{
    //    public GrabenMap95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap96 : GrabenMap
    //{
    //    public GrabenMap96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap97 : GrabenMap
    //{
    //    public GrabenMap97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap98 : GrabenMap
    //{
    //    public GrabenMap98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class GrabenMap99 : GrabenMap
    //{
    //    public GrabenMap99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class AirArea1Map : WorldMap
    //{
    //    public AirArea1Map()
    //    {
    //        mapName = "air area 1";
    //        mapLocation = 9;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class AirArea1Map0 : AirArea1Map
    //{
    //    public AirArea1Map0()
    //    {
    //        cellName = "";
    //        cellLocation = 0;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 77;
    //    }
    //}
    //public class AirArea1Map1 : AirArea1Map
    //{
    //    public AirArea1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map2 : AirArea1Map
    //{
    //    public AirArea1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map3 : AirArea1Map
    //{
    //    public AirArea1Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map4 : AirArea1Map
    //{
    //    public AirArea1Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map5 : AirArea1Map
    //{
    //    public AirArea1Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map6 : AirArea1Map
    //{
    //    public AirArea1Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map7 : AirArea1Map
    //{
    //    public AirArea1Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map8 : AirArea1Map
    //{
    //    public AirArea1Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map9 : AirArea1Map
    //{
    //    public AirArea1Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map10 : AirArea1Map
    //{
    //    public AirArea1Map10()
    //    {
    //        cellName = "airarea1 1";
    //        cellLocation = 10;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        firstVisit = true;
    //    }
    //}
    //public class AirArea1Map11 : AirArea1Map
    //{
    //    public AirArea1Map11()
    //    {
    //        cellName = "airarea1 2";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map12 : AirArea1Map
    //{
    //    public AirArea1Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map13 : AirArea1Map
    //{
    //    public AirArea1Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map14 : AirArea1Map
    //{
    //    public AirArea1Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map15 : AirArea1Map
    //{
    //    public AirArea1Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map16 : AirArea1Map
    //{
    //    public AirArea1Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map17 : AirArea1Map
    //{
    //    public AirArea1Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map18 : AirArea1Map
    //{
    //    public AirArea1Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map19 : AirArea1Map
    //{
    //    public AirArea1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map20 : AirArea1Map
    //{
    //    public AirArea1Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map21 : AirArea1Map
    //{
    //    public AirArea1Map21()
    //    {
    //        cellName = "airarea1 3";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map22 : AirArea1Map
    //{
    //    public AirArea1Map22()
    //    {
    //        cellName = "airarea1 7";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map23 : AirArea1Map
    //{
    //    public AirArea1Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map24 : AirArea1Map
    //{
    //    public AirArea1Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map25 : AirArea1Map
    //{
    //    public AirArea1Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map26 : AirArea1Map
    //{
    //    public AirArea1Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map27 : AirArea1Map
    //{
    //    public AirArea1Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map28 : AirArea1Map
    //{
    //    public AirArea1Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map29 : AirArea1Map
    //{
    //    public AirArea1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map30 : AirArea1Map
    //{
    //    public AirArea1Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map31 : AirArea1Map
    //{
    //    public AirArea1Map31()
    //    {
    //        cellName = "airarea1 4";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map32 : AirArea1Map
    //{
    //    public AirArea1Map32()
    //    {
    //        cellName = "airarea1 8";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map33 : AirArea1Map
    //{
    //    public AirArea1Map33()
    //    {
    //        cellLocation = 33;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map34 : AirArea1Map
    //{
    //    public AirArea1Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map35 : AirArea1Map
    //{
    //    public AirArea1Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map36 : AirArea1Map
    //{
    //    public AirArea1Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map37 : AirArea1Map
    //{
    //    public AirArea1Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map38 : AirArea1Map
    //{
    //    public AirArea1Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map39 : AirArea1Map
    //{
    //    public AirArea1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map40 : AirArea1Map
    //{
    //    public AirArea1Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map41 : AirArea1Map
    //{
    //    public AirArea1Map41()
    //    {
    //        cellName = "airarea1 5";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map42 : AirArea1Map
    //{
    //    public AirArea1Map42()
    //    {
    //        cellName = "airarea1 9";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map43 : AirArea1Map
    //{
    //    public AirArea1Map43()
    //    {
    //        cellName = "airarea1 13";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map44 : AirArea1Map
    //{
    //    public AirArea1Map44()
    //    {
    //        cellName = "airarea1 17";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map45 : AirArea1Map
    //{
    //    public AirArea1Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map46 : AirArea1Map
    //{
    //    public AirArea1Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map47 : AirArea1Map
    //{
    //    public AirArea1Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map48 : AirArea1Map
    //{
    //    public AirArea1Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map49 : AirArea1Map
    //{
    //    public AirArea1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map50 : AirArea1Map
    //{
    //    public AirArea1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map51 : AirArea1Map
    //{
    //    public AirArea1Map51()
    //    {
    //        cellName = "airarea1 6";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map52 : AirArea1Map
    //{
    //    public AirArea1Map52()
    //    {
    //        cellName = "airarea1 10";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map53 : AirArea1Map
    //{
    //    public AirArea1Map53()
    //    {
    //        cellName = "airarea1 14";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map54 : AirArea1Map
    //{
    //    public AirArea1Map54()
    //    {
    //        cellName = "airarea1 18";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map55 : AirArea1Map
    //{
    //    public AirArea1Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map56 : AirArea1Map
    //{
    //    public AirArea1Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map57 : AirArea1Map
    //{
    //    public AirArea1Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map58 : AirArea1Map
    //{
    //    public AirArea1Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map59 : AirArea1Map
    //{
    //    public AirArea1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map60 : AirArea1Map
    //{
    //    public AirArea1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map61 : AirArea1Map
    //{
    //    public AirArea1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map62 : AirArea1Map
    //{
    //    public AirArea1Map62()
    //    {
    //        cellName = "airarea1 11";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map63 : AirArea1Map
    //{
    //    public AirArea1Map63()
    //    {
    //        cellName = "airarea1 15";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map64 : AirArea1Map
    //{
    //    public AirArea1Map64()
    //    {
    //        cellName = "airarea1 19";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map65 : AirArea1Map
    //{
    //    public AirArea1Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map66 : AirArea1Map
    //{
    //    public AirArea1Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map67 : AirArea1Map
    //{
    //    public AirArea1Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map68 : AirArea1Map
    //{
    //    public AirArea1Map68()
    //    {
    //        cellName = "airarea1 28";
    //        cellLocation = 68;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map69 : AirArea1Map
    //{
    //    public AirArea1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map70 : AirArea1Map
    //{
    //    public AirArea1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map71 : AirArea1Map
    //{
    //    public AirArea1Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map72 : AirArea1Map
    //{
    //    public AirArea1Map72()
    //    {
    //        cellName = "airarea1 12";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map73 : AirArea1Map
    //{
    //    public AirArea1Map73()
    //    {
    //        cellName = "airarea1 16";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map74 : AirArea1Map
    //{
    //    public AirArea1Map74()
    //    {
    //        cellName = "airarea1 20";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map75 : AirArea1Map
    //{
    //    public AirArea1Map75()
    //    {
    //        cellName = "airarea1 22";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map76 : AirArea1Map
    //{
    //    public AirArea1Map76()
    //    {
    //        cellName = "airarea1 24";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map77 : AirArea1Map
    //{
    //    public AirArea1Map77()
    //    {
    //        cellName = "airarea1 26";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map78 : AirArea1Map
    //{
    //    public AirArea1Map78()
    //    {
    //        cellName = "airarea1 29";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map79 : AirArea1Map
    //{
    //    public AirArea1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map80 : AirArea1Map
    //{
    //    public AirArea1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map81 : AirArea1Map
    //{
    //    public AirArea1Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map82 : AirArea1Map
    //{
    //    public AirArea1Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map83 : AirArea1Map
    //{
    //    public AirArea1Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map84 : AirArea1Map
    //{
    //    public AirArea1Map84()
    //    {
    //        cellName = "airarea1 21";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map85 : AirArea1Map
    //{
    //    public AirArea1Map85()
    //    {
    //        cellName = "airarea1 23";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map86 : AirArea1Map
    //{
    //    public AirArea1Map86()
    //    {
    //        cellName = "airarea1 25";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map87 : AirArea1Map
    //{
    //    public AirArea1Map87()
    //    {
    //        cellName = "airarea1 27";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map88 : AirArea1Map
    //{
    //    public AirArea1Map88()
    //    {
    //        cellName = "airarea1 30";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea1Map89 : AirArea1Map
    //{
    //    public AirArea1Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map90 : AirArea1Map
    //{
    //    public AirArea1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map91 : AirArea1Map
    //{
    //    public AirArea1Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map92 : AirArea1Map
    //{
    //    public AirArea1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map93 : AirArea1Map
    //{
    //    public AirArea1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map94 : AirArea1Map
    //{
    //    public AirArea1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map95 : AirArea1Map
    //{
    //    public AirArea1Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map96 : AirArea1Map
    //{
    //    public AirArea1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map97 : AirArea1Map
    //{
    //    public AirArea1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class AirArea1Map98 : AirArea1Map
    //{
    //    public AirArea1Map98()
    //    {
    //        cellName = "";
    //        cellLocation = 98;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 23;
    //        newLocation = 5;
    //    }
    //}
    //public class AirArea1Map99 : AirArea1Map
    //{
    //    public AirArea1Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class AirArea2Map : WorldMap
    //{
    //    public AirArea2Map()
    //    {
    //        mapName = "air area 2";
    //        mapLocation = 23;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class AirArea2Map0 : AirArea2Map
    //{
    //    public AirArea2Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map1 : AirArea2Map
    //{
    //    public AirArea2Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map2 : AirArea2Map
    //{
    //    public AirArea2Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map3 : AirArea2Map
    //{
    //    public AirArea2Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map4 : AirArea2Map
    //{
    //    public AirArea2Map4()
    //    {
    //        cellName = "";
    //        cellLocation = 4;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 9;
    //        newLocation = 88;
    //    }
    //}
    //public class AirArea2Map5 : AirArea2Map
    //{
    //    public AirArea2Map5()
    //    {
    //        cellName = "AirArea2 1";
    //        cellLocation = 5;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map6 : AirArea2Map
    //{
    //    public AirArea2Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map7 : AirArea2Map
    //{
    //    public AirArea2Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map8 : AirArea2Map
    //{
    //    public AirArea2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map9 : AirArea2Map
    //{
    //    public AirArea2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map10 : AirArea2Map
    //{
    //    public AirArea2Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map11 : AirArea2Map
    //{
    //    public AirArea2Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map12 : AirArea2Map
    //{
    //    public AirArea2Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map13 : AirArea2Map
    //{
    //    public AirArea2Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map14 : AirArea2Map
    //{
    //    public AirArea2Map14()
    //    {
    //        cellName = "AirArea2 2";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map15 : AirArea2Map
    //{
    //    public AirArea2Map15()
    //    {
    //        cellName = "AirArea2 3";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map16 : AirArea2Map
    //{
    //    public AirArea2Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map17 : AirArea2Map
    //{
    //    public AirArea2Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map18 : AirArea2Map
    //{
    //    public AirArea2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map19 : AirArea2Map
    //{
    //    public AirArea2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map20 : AirArea2Map
    //{
    //    public AirArea2Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map21 : AirArea2Map
    //{
    //    public AirArea2Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map22 : AirArea2Map
    //{
    //    public AirArea2Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map23 : AirArea2Map
    //{
    //    public AirArea2Map23()
    //    {
    //        cellName = "AirArea2 4";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map24 : AirArea2Map
    //{
    //    public AirArea2Map24()
    //    {
    //        cellName = "AirArea2 5";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map25 : AirArea2Map
    //{
    //    public AirArea2Map25()
    //    {
    //        cellName = "AirArea2 6";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map26 : AirArea2Map
    //{
    //    public AirArea2Map26()
    //    {
    //        cellName = "AirArea2 7";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map27 : AirArea2Map
    //{
    //    public AirArea2Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map28 : AirArea2Map
    //{
    //    public AirArea2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map29 : AirArea2Map
    //{
    //    public AirArea2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map30 : AirArea2Map
    //{
    //    public AirArea2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map31 : AirArea2Map
    //{
    //    public AirArea2Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map32 : AirArea2Map
    //{
    //    public AirArea2Map32()
    //    {
    //        cellName = "AirArea2 8";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map33 : AirArea2Map
    //{
    //    public AirArea2Map33()
    //    {
    //        cellName = "AirArea2 9";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map34 : AirArea2Map
    //{
    //    public AirArea2Map34()
    //    {
    //        cellName = "AirArea2 10";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map35 : AirArea2Map
    //{
    //    public AirArea2Map35()
    //    {
    //        cellName = "AirArea2 11";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map36 : AirArea2Map
    //{
    //    public AirArea2Map36()
    //    {
    //        cellName = "AirArea2 12";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map37 : AirArea2Map
    //{
    //    public AirArea2Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map38 : AirArea2Map
    //{
    //    public AirArea2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map39 : AirArea2Map
    //{
    //    public AirArea2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map40 : AirArea2Map
    //{
    //    public AirArea2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map41 : AirArea2Map
    //{
    //    public AirArea2Map41()
    //    {
    //        cellName = "AirArea2 13";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map42 : AirArea2Map
    //{
    //    public AirArea2Map42()
    //    {
    //        cellName = "AirArea2 14";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map43 : AirArea2Map
    //{
    //    public AirArea2Map43()
    //    {
    //        cellName = "AirArea2 15";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map44 : AirArea2Map
    //{
    //    public AirArea2Map44()
    //    {
    //        cellName = "AirArea2 16";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map45 : AirArea2Map
    //{
    //    public AirArea2Map45()
    //    {
    //        cellName = "AirArea2 17";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map46 : AirArea2Map
    //{
    //    public AirArea2Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map47 : AirArea2Map
    //{
    //    public AirArea2Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map48 : AirArea2Map
    //{
    //    public AirArea2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map49 : AirArea2Map
    //{
    //    public AirArea2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map50 : AirArea2Map
    //{
    //    public AirArea2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map51 : AirArea2Map
    //{
    //    public AirArea2Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map52 : AirArea2Map
    //{
    //    public AirArea2Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map53 : AirArea2Map
    //{
    //    public AirArea2Map53()
    //    {
    //        cellName = "AirArea2 18";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map54 : AirArea2Map
    //{
    //    public AirArea2Map54()
    //    {
    //        cellName = "AirArea2 19";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map55 : AirArea2Map
    //{
    //    public AirArea2Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map56 : AirArea2Map
    //{
    //    public AirArea2Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map57 : AirArea2Map
    //{
    //    public AirArea2Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map58 : AirArea2Map
    //{
    //    public AirArea2Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map59 : AirArea2Map
    //{
    //    public AirArea2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map60 : AirArea2Map
    //{
    //    public AirArea2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map61 : AirArea2Map
    //{
    //    public AirArea2Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map62 : AirArea2Map
    //{
    //    public AirArea2Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map63 : AirArea2Map
    //{
    //    public AirArea2Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map64 : AirArea2Map
    //{
    //    public AirArea2Map64()
    //    {
    //        cellName = "AirArea2 20";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map65 : AirArea2Map
    //{
    //    public AirArea2Map65()
    //    {
    //        cellName = "AirArea2 21";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map66 : AirArea2Map
    //{
    //    public AirArea2Map66()
    //    {
    //        cellName = "AirArea2 22";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map67 : AirArea2Map
    //{
    //    public AirArea2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map68 : AirArea2Map
    //{
    //    public AirArea2Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map69 : AirArea2Map
    //{
    //    public AirArea2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map70 : AirArea2Map
    //{
    //    public AirArea2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map71 : AirArea2Map
    //{
    //    public AirArea2Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map72 : AirArea2Map
    //{
    //    public AirArea2Map72()
    //    {
    //        cellName = "AirArea2 23";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map73 : AirArea2Map
    //{
    //    public AirArea2Map73()
    //    {
    //        cellName = "AirArea2 24";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map74 : AirArea2Map
    //{
    //    public AirArea2Map74()
    //    {
    //        cellName = "AirArea2 25";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map75 : AirArea2Map
    //{
    //    public AirArea2Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map76 : AirArea2Map
    //{
    //    public AirArea2Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map77 : AirArea2Map
    //{
    //    public AirArea2Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map78 : AirArea2Map
    //{
    //    public AirArea2Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map79 : AirArea2Map
    //{
    //    public AirArea2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map80 : AirArea2Map
    //{
    //    public AirArea2Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map81 : AirArea2Map
    //{
    //    public AirArea2Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map82 : AirArea2Map
    //{
    //    public AirArea2Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map83 : AirArea2Map
    //{
    //    public AirArea2Map83()
    //    {
    //        cellName = "AirArea2 26";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map84 : AirArea2Map
    //{
    //    public AirArea2Map84()
    //    {
    //        cellName = "AirArea2 27";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea2Map85 : AirArea2Map
    //{
    //    public AirArea2Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map86 : AirArea2Map
    //{
    //    public AirArea2Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map87 : AirArea2Map
    //{
    //    public AirArea2Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map88 : AirArea2Map
    //{
    //    public AirArea2Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map89 : AirArea2Map
    //{
    //    public AirArea2Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map90 : AirArea2Map
    //{
    //    public AirArea2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map91 : AirArea2Map
    //{
    //    public AirArea2Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map92 : AirArea2Map
    //{
    //    public AirArea2Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map93 : AirArea2Map
    //{
    //    public AirArea2Map93()
    //    {
    //        cellName = "";
    //        cellLocation = 93;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 24;
    //        newLocation = 17;
    //    }
    //}
    //public class AirArea2Map94 : AirArea2Map
    //{
    //    public AirArea2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map95 : AirArea2Map
    //{
    //    public AirArea2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map96 : AirArea2Map
    //{
    //    public AirArea2Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map97 : AirArea2Map
    //{
    //    public AirArea2Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map98 : AirArea2Map
    //{
    //    public AirArea2Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class AirArea2Map99 : AirArea2Map
    //{
    //    public AirArea2Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}


    //public class AirArea3Map : WorldMap
    //{
    //    public AirArea3Map()
    //    {
    //        mapName = "air area 3";
    //        mapLocation = 24;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class AirArea3Map0 : AirArea3Map
    //{
    //    public AirArea3Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map1 : AirArea3Map
    //{
    //    public AirArea3Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map2 : AirArea3Map
    //{
    //    public AirArea3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map3 : AirArea3Map
    //{
    //    public AirArea3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map4 : AirArea3Map
    //{
    //    public AirArea3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map5 : AirArea3Map
    //{
    //    public AirArea3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map6 : AirArea3Map
    //{
    //    public AirArea3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map7 : AirArea3Map
    //{
    //    public AirArea3Map7()
    //    {
    //        cellName = "";
    //        cellLocation = 7;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 23;
    //        newLocation = 83;
    //    }
    //}
    //public class AirArea3Map8 : AirArea3Map
    //{
    //    public AirArea3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map9 : AirArea3Map
    //{
    //    public AirArea3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map10 : AirArea3Map
    //{
    //    public AirArea3Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map11 : AirArea3Map
    //{
    //    public AirArea3Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map12 : AirArea3Map
    //{
    //    public AirArea3Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map13 : AirArea3Map
    //{
    //    public AirArea3Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map14 : AirArea3Map
    //{
    //    public AirArea3Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map15 : AirArea3Map
    //{
    //    public AirArea3Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map16 : AirArea3Map
    //{
    //    public AirArea3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map17 : AirArea3Map
    //{
    //    public AirArea3Map17()
    //    {
    //        cellName = "AirArea3 1";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map18 : AirArea3Map
    //{
    //    public AirArea3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map19 : AirArea3Map
    //{
    //    public AirArea3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map20 : AirArea3Map
    //{
    //    public AirArea3Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map21 : AirArea3Map
    //{
    //    public AirArea3Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map22 : AirArea3Map
    //{
    //    public AirArea3Map22()
    //    {
    //        cellLocation = 22;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map23 : AirArea3Map
    //{
    //    public AirArea3Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map24 : AirArea3Map
    //{
    //    public AirArea3Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map25 : AirArea3Map
    //{
    //    public AirArea3Map25()
    //    {
    //        cellName = "AirArea3 6";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map26 : AirArea3Map
    //{
    //    public AirArea3Map26()
    //    {
    //        cellName = "AirArea3 4";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map27 : AirArea3Map
    //{
    //    public AirArea3Map27()
    //    {
    //        cellName = "AirArea3 2";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map28 : AirArea3Map
    //{
    //    public AirArea3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map29 : AirArea3Map
    //{
    //    public AirArea3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map30 : AirArea3Map
    //{
    //    public AirArea3Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map31 : AirArea3Map
    //{
    //    public AirArea3Map31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map32 : AirArea3Map
    //{
    //    public AirArea3Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map33 : AirArea3Map
    //{
    //    public AirArea3Map33()
    //    {
    //        cellName = "AirArea3 9";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map34 : AirArea3Map
    //{
    //    public AirArea3Map34()
    //    {
    //        cellName = "AirArea3 8";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map35 : AirArea3Map
    //{
    //    public AirArea3Map35()
    //    {
    //        cellName = "AirArea3 7";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map36 : AirArea3Map
    //{
    //    public AirArea3Map36()
    //    {
    //        cellName = "AirArea3 5";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map37 : AirArea3Map
    //{
    //    public AirArea3Map37()
    //    {
    //        cellName = "AirArea3 3";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map38 : AirArea3Map
    //{
    //    public AirArea3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map39 : AirArea3Map
    //{
    //    public AirArea3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map40 : AirArea3Map
    //{
    //    public AirArea3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map41 : AirArea3Map
    //{
    //    public AirArea3Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map42 : AirArea3Map
    //{
    //    public AirArea3Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map43 : AirArea3Map
    //{
    //    public AirArea3Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map44 : AirArea3Map
    //{
    //    public AirArea3Map44()
    //    {
    //        cellName = "AirArea3 10";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map45 : AirArea3Map
    //{
    //    public AirArea3Map45()
    //    {
    //        cellName = "AirArea3 11";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map46 : AirArea3Map
    //{
    //    public AirArea3Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map47 : AirArea3Map
    //{
    //    public AirArea3Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map48 : AirArea3Map
    //{
    //    public AirArea3Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map49 : AirArea3Map
    //{
    //    public AirArea3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map50 : AirArea3Map
    //{
    //    public AirArea3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map51 : AirArea3Map
    //{
    //    public AirArea3Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map52 : AirArea3Map
    //{
    //    public AirArea3Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map53 : AirArea3Map
    //{
    //    public AirArea3Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map54 : AirArea3Map
    //{
    //    public AirArea3Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map55 : AirArea3Map
    //{
    //    public AirArea3Map55()
    //    {
    //        cellName = "AirArea3 12";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map56 : AirArea3Map
    //{
    //    public AirArea3Map56()
    //    {
    //        cellName = "AirArea3 13";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map57 : AirArea3Map
    //{
    //    public AirArea3Map57()
    //    {
    //        cellName = "AirArea3 14";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map58 : AirArea3Map
    //{
    //    public AirArea3Map58()
    //    {
    //        cellName = "AirArea3 15";
    //        cellLocation = 58;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map59 : AirArea3Map
    //{
    //    public AirArea3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map60 : AirArea3Map
    //{
    //    public AirArea3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map61 : AirArea3Map
    //{
    //    public AirArea3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map62 : AirArea3Map
    //{
    //    public AirArea3Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map63 : AirArea3Map
    //{
    //    public AirArea3Map63()
    //    {
    //        cellName = "AirArea3 16";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map64 : AirArea3Map
    //{
    //    public AirArea3Map64()
    //    {
    //        cellName = "AirArea3 17";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map65 : AirArea3Map
    //{
    //    public AirArea3Map65()
    //    {
    //        cellName = "AirArea3 18";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map66 : AirArea3Map
    //{
    //    public AirArea3Map66()
    //    {
    //        cellName = "AirArea3 19";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map67 : AirArea3Map
    //{
    //    public AirArea3Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map68 : AirArea3Map
    //{
    //    public AirArea3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map69 : AirArea3Map
    //{
    //    public AirArea3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map70 : AirArea3Map
    //{
    //    public AirArea3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map71 : AirArea3Map
    //{
    //    public AirArea3Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map72 : AirArea3Map
    //{
    //    public AirArea3Map72()
    //    {
    //        cellName = "AirArea3 20";
    //        cellLocation = 72;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map73 : AirArea3Map
    //{
    //    public AirArea3Map73()
    //    {
    //        cellName = "AirArea3 21";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map74 : AirArea3Map
    //{
    //    public AirArea3Map74()
    //    {
    //        cellName = "AirArea3 22";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map75 : AirArea3Map
    //{
    //    public AirArea3Map75()
    //    {
    //        cellName = "AirArea3 23";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map76 : AirArea3Map
    //{
    //    public AirArea3Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map77 : AirArea3Map
    //{
    //    public AirArea3Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map78 : AirArea3Map
    //{
    //    public AirArea3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map79 : AirArea3Map
    //{
    //    public AirArea3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map80 : AirArea3Map
    //{
    //    public AirArea3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map81 : AirArea3Map
    //{
    //    public AirArea3Map81()
    //    {
    //        cellName = "AirArea3 24";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map82 : AirArea3Map
    //{
    //    public AirArea3Map82()
    //    {
    //        cellName = "AirArea3 25";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map83 : AirArea3Map
    //{
    //    public AirArea3Map83()
    //    {
    //        cellName = "AirArea3 26";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map84 : AirArea3Map
    //{
    //    public AirArea3Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map85 : AirArea3Map
    //{
    //    public AirArea3Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map86 : AirArea3Map
    //{
    //    public AirArea3Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map87 : AirArea3Map
    //{
    //    public AirArea3Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map88 : AirArea3Map
    //{
    //    public AirArea3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map89 : AirArea3Map
    //{
    //    public AirArea3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map90 : AirArea3Map
    //{
    //    public AirArea3Map90()
    //    {
    //        cellName = "";
    //        cellLocation = 90;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 25;
    //        newLocation = 44;
    //    }
    //}
    //public class AirArea3Map91 : AirArea3Map
    //{
    //    public AirArea3Map91()
    //    {
    //        cellName = "AirArea3 27";
    //        cellLocation = 91;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map92 : AirArea3Map
    //{
    //    public AirArea3Map92()
    //    {
    //        cellName = "AirArea3 28";
    //        cellLocation = 92;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class AirArea3Map93 : AirArea3Map
    //{
    //    public AirArea3Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map94 : AirArea3Map
    //{
    //    public AirArea3Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map95 : AirArea3Map
    //{
    //    public AirArea3Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map96 : AirArea3Map
    //{
    //    public AirArea3Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map97 : AirArea3Map
    //{
    //    public AirArea3Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map98 : AirArea3Map
    //{
    //    public AirArea3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class AirArea3Map99 : AirArea3Map
    //{
    //    public AirArea3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class MesetraMap : WorldMap
    //{
    //    public MesetraMap()
    //    {
    //        mapName = "mesetra";
    //        mapLocation = 25;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 0;
    //    }
    //}
    //public class MesetraMap0 : MesetraMap
    //{
    //    public MesetraMap0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap1 : MesetraMap
    //{
    //    public MesetraMap1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap2 : MesetraMap
    //{
    //    public MesetraMap2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap3 : MesetraMap
    //{
    //    public MesetraMap3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap4 : MesetraMap
    //{
    //    public MesetraMap4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap5 : MesetraMap
    //{
    //    public MesetraMap5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap6 : MesetraMap
    //{
    //    public MesetraMap6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap7 : MesetraMap
    //{
    //    public MesetraMap7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap8 : MesetraMap
    //{
    //    public MesetraMap8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap9 : MesetraMap
    //{
    //    public MesetraMap9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap10 : MesetraMap
    //{
    //    public MesetraMap10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap11 : MesetraMap
    //{
    //    public MesetraMap11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap12 : MesetraMap
    //{
    //    public MesetraMap12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap13 : MesetraMap
    //{
    //    public MesetraMap13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap14 : MesetraMap
    //{
    //    public MesetraMap14()
    //    {
    //        cellName = "Mesetra 1";
    //        cellLocation = 14;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap15 : MesetraMap
    //{
    //    public MesetraMap15()
    //    {
    //        cellName = "Mesetra 2";
    //        cellLocation = 15;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap16 : MesetraMap
    //{
    //    public MesetraMap16()
    //    {
    //        cellName = "Mesetra 3";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap17 : MesetraMap
    //{
    //    public MesetraMap17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap18 : MesetraMap
    //{
    //    public MesetraMap18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap19 : MesetraMap
    //{
    //    public MesetraMap19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap20 : MesetraMap
    //{
    //    public MesetraMap20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap21 : MesetraMap
    //{
    //    public MesetraMap21()
    //    {
    //        cellName = "";
    //        cellLocation = 21;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 38;
    //        newLocation = 0; //change
    //    }
    //}
    //public class MesetraMap22 : MesetraMap
    //{
    //    public MesetraMap22()
    //    {
    //        cellName = "Mesetra 4";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap23 : MesetraMap
    //{
    //    public MesetraMap23()
    //    {
    //        cellName = "Mesetra 5";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap24 : MesetraMap
    //{
    //    public MesetraMap24()
    //    {
    //        cellName = "Mesetra 6";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap25 : MesetraMap
    //{
    //    public MesetraMap25()
    //    {
    //        cellName = "Mesetra 7";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap26 : MesetraMap
    //{
    //    public MesetraMap26()
    //    {
    //        cellName = "Mesetra 8";
    //        cellLocation = 26;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap27 : MesetraMap
    //{
    //    public MesetraMap27()
    //    {
    //        cellName = "Mesetra 9";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap28 : MesetraMap
    //{
    //    public MesetraMap28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap29 : MesetraMap
    //{
    //    public MesetraMap29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap30 : MesetraMap
    //{
    //    public MesetraMap30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap31 : MesetraMap
    //{
    //    public MesetraMap31()
    //    {
    //        cellName = "Mesetra 10";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap32 : MesetraMap
    //{
    //    public MesetraMap32()
    //    {
    //        cellName = "Mesetra 11";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap33 : MesetraMap
    //{
    //    public MesetraMap33()
    //    {
    //        cellName = "Mesetra 12";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap34 : MesetraMap
    //{
    //    public MesetraMap34()
    //    {
    //        cellName = "Mesetra 13";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap35 : MesetraMap
    //{
    //    public MesetraMap35()
    //    {
    //        cellName = "Mesetra 14";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap36 : MesetraMap
    //{
    //    public MesetraMap36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap37 : MesetraMap
    //{
    //    public MesetraMap37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap38 : MesetraMap
    //{
    //    public MesetraMap38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap39 : MesetraMap
    //{
    //    public MesetraMap39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap40 : MesetraMap
    //{
    //    public MesetraMap40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap41 : MesetraMap
    //{
    //    public MesetraMap41()
    //    {
    //        cellName = "Mesetra 15";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap42 : MesetraMap
    //{
    //    public MesetraMap42()
    //    {
    //        cellName = "Mesetra 16";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap43 : MesetraMap
    //{
    //    public MesetraMap43()
    //    {
    //        cellName = "Mesetra 17";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap44 : MesetraMap
    //{
    //    public MesetraMap44()
    //    {
    //        cellName = "Mesetra 18";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap45 : MesetraMap
    //{
    //    public MesetraMap45()
    //    {
    //        cellName = "";
    //        cellLocation = 45;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 24;
    //        newLocation = 91;
    //    }
    //}
    //public class MesetraMap46 : MesetraMap
    //{
    //    public MesetraMap46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap47 : MesetraMap
    //{
    //    public MesetraMap47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap48 : MesetraMap
    //{
    //    public MesetraMap48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap49 : MesetraMap
    //{
    //    public MesetraMap49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap50 : MesetraMap
    //{
    //    public MesetraMap50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap51 : MesetraMap
    //{
    //    public MesetraMap51()
    //    {
    //        cellName = "Mesetra 19";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap52 : MesetraMap
    //{
    //    public MesetraMap52()
    //    {
    //        cellName = "Mesetra 20";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap53 : MesetraMap
    //{
    //    public MesetraMap53()
    //    {
    //        cellName = "Mesetra 21";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap54 : MesetraMap
    //{
    //    public MesetraMap54()
    //    {
    //        cellName = "Mesetra 22";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap55 : MesetraMap
    //{
    //    public MesetraMap55()
    //    {
    //        cellName = "Mesetra 23";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap56 : MesetraMap
    //{
    //    public MesetraMap56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap57 : MesetraMap
    //{
    //    public MesetraMap57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap58 : MesetraMap
    //{
    //    public MesetraMap58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap59 : MesetraMap
    //{
    //    public MesetraMap59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap60 : MesetraMap
    //{
    //    public MesetraMap60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap61 : MesetraMap
    //{
    //    public MesetraMap61()
    //    {
    //        cellName = "";
    //        cellLocation = 61;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 38;
    //        newLocation = 0; //change
    //    }
    //}
    //public class MesetraMap62 : MesetraMap
    //{
    //    public MesetraMap62()
    //    {
    //        cellName = "Mesetra 24";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap63 : MesetraMap
    //{
    //    public MesetraMap63()
    //    {
    //        cellName = "Mesetra 25";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap64 : MesetraMap
    //{
    //    public MesetraMap64()
    //    {
    //        cellName = "Mesetra 26";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap65 : MesetraMap
    //{
    //    public MesetraMap65()
    //    {
    //        cellName = "Mesetra 27";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap66 : MesetraMap
    //{
    //    public MesetraMap66()
    //    {
    //        cellName = "Mesetra 28";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap67 : MesetraMap
    //{
    //    public MesetraMap67()
    //    {
    //        cellName = "Mesetra 29";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap68 : MesetraMap
    //{
    //    public MesetraMap68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap69 : MesetraMap
    //{
    //    public MesetraMap69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap70 : MesetraMap
    //{
    //    public MesetraMap70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap71 : MesetraMap
    //{
    //    public MesetraMap71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap72 : MesetraMap
    //{
    //    public MesetraMap72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap73 : MesetraMap
    //{
    //    public MesetraMap73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap74 : MesetraMap
    //{
    //    public MesetraMap74()
    //    {
    //        cellName = "Mesetra 30";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap75 : MesetraMap
    //{
    //    public MesetraMap75()
    //    {
    //        cellName = "Mesetra 31";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap76 : MesetraMap
    //{
    //    public MesetraMap76()
    //    {
    //        cellName = "Mesetra 32";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class MesetraMap77 : MesetraMap
    //{
    //    public MesetraMap77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap78 : MesetraMap
    //{
    //    public MesetraMap78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap79 : MesetraMap
    //{
    //    public MesetraMap79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap80 : MesetraMap
    //{
    //    public MesetraMap80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap81 : MesetraMap
    //{
    //    public MesetraMap81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap82 : MesetraMap
    //{
    //    public MesetraMap82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap83 : MesetraMap
    //{
    //    public MesetraMap83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap84 : MesetraMap
    //{
    //    public MesetraMap84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap85 : MesetraMap
    //{
    //    public MesetraMap85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap86 : MesetraMap
    //{
    //    public MesetraMap86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap87 : MesetraMap
    //{
    //    public MesetraMap87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap88 : MesetraMap
    //{
    //    public MesetraMap88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap89 : MesetraMap
    //{
    //    public MesetraMap89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap90 : MesetraMap
    //{
    //    public MesetraMap90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap91 : MesetraMap
    //{
    //    public MesetraMap91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap92 : MesetraMap
    //{
    //    public MesetraMap92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap93 : MesetraMap
    //{
    //    public MesetraMap93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap94 : MesetraMap
    //{
    //    public MesetraMap94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap95 : MesetraMap
    //{
    //    public MesetraMap95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap96 : MesetraMap
    //{
    //    public MesetraMap96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap97 : MesetraMap
    //{
    //    public MesetraMap97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap98 : MesetraMap
    //{
    //    public MesetraMap98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class MesetraMap99 : MesetraMap
    //{
    //    public MesetraMap99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    //public class WaterArea1Map : WorldMap
    //{
    //    public WaterArea1Map()
    //    {
    //        mapName = "water area 1";
    //        mapLocation = 10;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class WaterArea1Map0 : WaterArea1Map
    //{
    //    public WaterArea1Map0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map1 : WaterArea1Map
    //{
    //    public WaterArea1Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map2 : WaterArea1Map
    //{
    //    public WaterArea1Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map3 : WaterArea1Map
    //{
    //    public WaterArea1Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map4 : WaterArea1Map
    //{
    //    public WaterArea1Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map5 : WaterArea1Map
    //{
    //    public WaterArea1Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map6 : WaterArea1Map
    //{
    //    public WaterArea1Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map7 : WaterArea1Map
    //{
    //    public WaterArea1Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map8 : WaterArea1Map
    //{
    //    public WaterArea1Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map9 : WaterArea1Map
    //{
    //    public WaterArea1Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map10 : WaterArea1Map
    //{
    //    public WaterArea1Map10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map11 : WaterArea1Map
    //{
    //    public WaterArea1Map11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map12 : WaterArea1Map
    //{
    //    public WaterArea1Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map13 : WaterArea1Map
    //{
    //    public WaterArea1Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map14 : WaterArea1Map
    //{
    //    public WaterArea1Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map15 : WaterArea1Map
    //{
    //    public WaterArea1Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map16 : WaterArea1Map
    //{
    //    public WaterArea1Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map17 : WaterArea1Map
    //{
    //    public WaterArea1Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map18 : WaterArea1Map
    //{
    //    public WaterArea1Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map19 : WaterArea1Map
    //{
    //    public WaterArea1Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map20 : WaterArea1Map
    //{
    //    public WaterArea1Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map21 : WaterArea1Map
    //{
    //    public WaterArea1Map21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map22 : WaterArea1Map
    //{
    //    public WaterArea1Map22()
    //    {
    //        cellName = "waterarea1 7";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map23 : WaterArea1Map
    //{
    //    public WaterArea1Map23()
    //    {
    //        cellName = "waterarea1 6";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map24 : WaterArea1Map
    //{
    //    public WaterArea1Map24()
    //    {
    //        cellName = "waterarea1 8";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map25 : WaterArea1Map
    //{
    //    public WaterArea1Map25()
    //    {
    //        cellName = "waterarea1 9";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map26 : WaterArea1Map
    //{
    //    public WaterArea1Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map27 : WaterArea1Map
    //{
    //    public WaterArea1Map27()
    //    {
    //        cellName = "waterarea1 15";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map28 : WaterArea1Map
    //{
    //    public WaterArea1Map28()
    //    {
    //        cellName = "waterarea1 28";
    //        cellLocation = 28;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map29 : WaterArea1Map
    //{
    //    public WaterArea1Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map30 : WaterArea1Map
    //{
    //    public WaterArea1Map30()
    //    {
    //        cellName = "";
    //        cellLocation = 30;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 26;
    //        newLocation = 88;
    //    }
    //}
    //public class WaterArea1Map31 : WaterArea1Map
    //{
    //    public WaterArea1Map31()
    //    {
    //        cellName = "waterarea1 1";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map32 : WaterArea1Map
    //{
    //    public WaterArea1Map32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map33 : WaterArea1Map
    //{
    //    public WaterArea1Map33()
    //    {
    //        cellName = "waterarea1 5";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map34 : WaterArea1Map
    //{
    //    public WaterArea1Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map35 : WaterArea1Map
    //{
    //    public WaterArea1Map35()
    //    {
    //        cellName = "waterarea1 10";
    //        cellLocation = 35;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map36 : WaterArea1Map
    //{
    //    public WaterArea1Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map37 : WaterArea1Map
    //{
    //    public WaterArea1Map37()
    //    {
    //        cellName = "waterarea1 14";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map38 : WaterArea1Map
    //{
    //    public WaterArea1Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map39 : WaterArea1Map
    //{
    //    public WaterArea1Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map40 : WaterArea1Map
    //{
    //    public WaterArea1Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map41 : WaterArea1Map
    //{
    //    public WaterArea1Map41()
    //    {
    //        cellName = "waterarea1 2";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map42 : WaterArea1Map
    //{
    //    public WaterArea1Map42()
    //    {
    //        cellName = "waterarea1 3";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map43 : WaterArea1Map
    //{
    //    public WaterArea1Map43()
    //    {
    //        cellName = "waterarea1 4";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map44 : WaterArea1Map
    //{
    //    public WaterArea1Map44()
    //    {
    //        cellLocation = 44;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map45 : WaterArea1Map
    //{
    //    public WaterArea1Map45()
    //    {
    //        cellName = "waterarea1 11";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map46 : WaterArea1Map
    //{
    //    public WaterArea1Map46()
    //    {
    //        cellName = "waterarea1 12";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map47 : WaterArea1Map
    //{
    //    public WaterArea1Map47()
    //    {
    //        cellName = "waterarea1 13";
    //        cellLocation = 47;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map48 : WaterArea1Map
    //{
    //    public WaterArea1Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map49 : WaterArea1Map
    //{
    //    public WaterArea1Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map50 : WaterArea1Map
    //{
    //    public WaterArea1Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map51 : WaterArea1Map
    //{
    //    public WaterArea1Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map52 : WaterArea1Map
    //{
    //    public WaterArea1Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map53 : WaterArea1Map
    //{
    //    public WaterArea1Map53()
    //    {
    //        cellLocation = 53;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map54 : WaterArea1Map
    //{
    //    public WaterArea1Map54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map55 : WaterArea1Map
    //{
    //    public WaterArea1Map55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map56 : WaterArea1Map
    //{
    //    public WaterArea1Map56()
    //    {
    //        cellName = "waterarea1 17";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map57 : WaterArea1Map
    //{
    //    public WaterArea1Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map58 : WaterArea1Map
    //{
    //    public WaterArea1Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map59 : WaterArea1Map
    //{
    //    public WaterArea1Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map60 : WaterArea1Map
    //{
    //    public WaterArea1Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map61 : WaterArea1Map
    //{
    //    public WaterArea1Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map62 : WaterArea1Map
    //{
    //    public WaterArea1Map62()
    //    {
    //        cellName = "waterarea1 18";
    //        cellLocation = 62;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map63 : WaterArea1Map
    //{
    //    public WaterArea1Map63()
    //    {
    //        cellName = "waterarea1 19";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map64 : WaterArea1Map
    //{
    //    public WaterArea1Map64()
    //    {
    //        cellName = "waterarea1 24";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map65 : WaterArea1Map
    //{
    //    public WaterArea1Map65()
    //    {
    //        cellName = "waterarea1 35";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map66 : WaterArea1Map
    //{
    //    public WaterArea1Map66()
    //    {
    //        cellName = "waterarea1 26";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map67 : WaterArea1Map
    //{
    //    public WaterArea1Map67()
    //    {
    //        cellName = "waterarea1 27";
    //        cellLocation = 67;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map68 : WaterArea1Map
    //{
    //    public WaterArea1Map68()
    //    {
    //        cellName = "waterarea1 28";
    //        cellLocation = 68;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map69 : WaterArea1Map
    //{
    //    public WaterArea1Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map70 : WaterArea1Map
    //{
    //    public WaterArea1Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map71 : WaterArea1Map
    //{
    //    public WaterArea1Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map72 : WaterArea1Map
    //{
    //    public WaterArea1Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map73 : WaterArea1Map
    //{
    //    public WaterArea1Map73()
    //    {
    //        cellName = "waterarea1 20";
    //        cellLocation = 73;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map74 : WaterArea1Map
    //{
    //    public WaterArea1Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map75 : WaterArea1Map
    //{
    //    public WaterArea1Map75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map76 : WaterArea1Map
    //{
    //    public WaterArea1Map76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map77 : WaterArea1Map
    //{
    //    public WaterArea1Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map78 : WaterArea1Map
    //{
    //    public WaterArea1Map78()
    //    {
    //        cellName = "waterarea1 29";
    //        cellLocation = 78;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map79 : WaterArea1Map
    //{
    //    public WaterArea1Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map80 : WaterArea1Map
    //{
    //    public WaterArea1Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map81 : WaterArea1Map
    //{
    //    public WaterArea1Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map82 : WaterArea1Map
    //{
    //    public WaterArea1Map82()
    //    {
    //        cellName = "waterarea1 21";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map83 : WaterArea1Map
    //{
    //    public WaterArea1Map83()
    //    {
    //        cellName = "waterarea1 22";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map84 : WaterArea1Map
    //{
    //    public WaterArea1Map84()
    //    {
    //        cellName = "waterarea1 23";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map85 : WaterArea1Map
    //{
    //    public WaterArea1Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map86 : WaterArea1Map
    //{
    //    public WaterArea1Map86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map87 : WaterArea1Map
    //{
    //    public WaterArea1Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map88 : WaterArea1Map
    //{
    //    public WaterArea1Map88()
    //    {
    //        cellName = "waterarea1 30";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea1Map89 : WaterArea1Map
    //{
    //    public WaterArea1Map89()
    //    {
    //        cellName = "waterarea1 31";
    //        cellLocation = 89;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        firstVisit = true;
    //    }
    //}
    //public class WaterArea1Map90 : WaterArea1Map
    //{
    //    public WaterArea1Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map91 : WaterArea1Map
    //{
    //    public WaterArea1Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map92 : WaterArea1Map
    //{
    //    public WaterArea1Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map93 : WaterArea1Map
    //{
    //    public WaterArea1Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map94 : WaterArea1Map
    //{
    //    public WaterArea1Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map95 : WaterArea1Map
    //{
    //    public WaterArea1Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map96 : WaterArea1Map
    //{
    //    public WaterArea1Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map97 : WaterArea1Map
    //{
    //    public WaterArea1Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map98 : WaterArea1Map
    //{
    //    public WaterArea1Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea1Map99 : WaterArea1Map
    //{
    //    public WaterArea1Map99()
    //    {
    //        cellName = "";
    //        cellLocation = 99;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 5;
    //        newLocation = 24;
    //    }
    //}
    
    //public class WaterArea2Map : WorldMap
    //{
    //    public WaterArea2Map()
    //    {
    //        mapName = "water area 2";
    //        mapLocation = 26;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class WaterArea2Map0 : WaterArea2Map
    //{
    //    public WaterArea2Map0()
    //    {
    //        cellName = "";
    //        cellLocation = 0;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 27;
    //        newLocation = 86;
    //    }
    //}
    //public class WaterArea2Map1 : WaterArea2Map
    //{
    //    public WaterArea2Map1()
    //    {
    //        cellName = "WaterArea2 28";
    //        cellLocation = 1;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map2 : WaterArea2Map
    //{
    //    public WaterArea2Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map3 : WaterArea2Map
    //{
    //    public WaterArea2Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map4 : WaterArea2Map
    //{
    //    public WaterArea2Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map5 : WaterArea2Map
    //{
    //    public WaterArea2Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map6 : WaterArea2Map
    //{
    //    public WaterArea2Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map7 : WaterArea2Map
    //{
    //    public WaterArea2Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map8 : WaterArea2Map
    //{
    //    public WaterArea2Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map9 : WaterArea2Map
    //{
    //    public WaterArea2Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map10 : WaterArea2Map
    //{
    //    public WaterArea2Map10()
    //    {
    //        cellName = "WaterArea2 27";
    //        cellLocation = 10;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map11 : WaterArea2Map
    //{
    //    public WaterArea2Map11()
    //    {
    //        cellName = "WaterArea2 26";
    //        cellLocation = 11;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map12 : WaterArea2Map
    //{
    //    public WaterArea2Map12()
    //    {
    //        cellName = "WaterArea2 25";
    //        cellLocation = 12;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map13 : WaterArea2Map
    //{
    //    public WaterArea2Map13()
    //    {
    //        cellName = "WaterArea2 24";
    //        cellLocation = 13;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map14 : WaterArea2Map
    //{
    //    public WaterArea2Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map15 : WaterArea2Map
    //{
    //    public WaterArea2Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map16 : WaterArea2Map
    //{
    //    public WaterArea2Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map17 : WaterArea2Map
    //{
    //    public WaterArea2Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map18 : WaterArea2Map
    //{
    //    public WaterArea2Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map19 : WaterArea2Map
    //{
    //    public WaterArea2Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map20 : WaterArea2Map
    //{
    //    public WaterArea2Map20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map21 : WaterArea2Map
    //{
    //    public WaterArea2Map21()
    //    {
    //        cellName = "WaterArea2 23";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map22 : WaterArea2Map
    //{
    //    public WaterArea2Map22()
    //    {
    //        cellName = "WaterArea2 22";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map23 : WaterArea2Map
    //{
    //    public WaterArea2Map23()
    //    {
    //        cellName = "WaterArea2 21";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map24 : WaterArea2Map
    //{
    //    public WaterArea2Map24()
    //    {
    //        cellName = "WaterArea2 20";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map25 : WaterArea2Map
    //{
    //    public WaterArea2Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map26 : WaterArea2Map
    //{
    //    public WaterArea2Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map27 : WaterArea2Map
    //{
    //    public WaterArea2Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map28 : WaterArea2Map
    //{
    //    public WaterArea2Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map29 : WaterArea2Map
    //{
    //    public WaterArea2Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map30 : WaterArea2Map
    //{
    //    public WaterArea2Map30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map31 : WaterArea2Map
    //{
    //    public WaterArea2Map31()
    //    {
    //        cellName = "WaterArea2 19";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map32 : WaterArea2Map
    //{
    //    public WaterArea2Map32()
    //    {
    //        cellName = "WaterArea2 18";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map33 : WaterArea2Map
    //{
    //    public WaterArea2Map33()
    //    {
    //        cellName = "WaterArea2 17";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map34 : WaterArea2Map
    //{
    //    public WaterArea2Map34()
    //    {
    //        cellName = "WaterArea2 16";
    //        cellLocation = 34;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map35 : WaterArea2Map
    //{
    //    public WaterArea2Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map36 : WaterArea2Map
    //{
    //    public WaterArea2Map36()
    //    {
    //        cellName = "WaterArea2 15";
    //        cellLocation = 36;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map37 : WaterArea2Map
    //{
    //    public WaterArea2Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map38 : WaterArea2Map
    //{
    //    public WaterArea2Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map39 : WaterArea2Map
    //{
    //    public WaterArea2Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map40 : WaterArea2Map
    //{
    //    public WaterArea2Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map41 : WaterArea2Map
    //{
    //    public WaterArea2Map41()
    //    {
    //        cellLocation = 41;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map42 : WaterArea2Map
    //{
    //    public WaterArea2Map42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map43 : WaterArea2Map
    //{
    //    public WaterArea2Map43()
    //    {
    //        cellLocation = 43;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map44 : WaterArea2Map
    //{
    //    public WaterArea2Map44()
    //    {
    //        cellName = "WaterArea2 12";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map45 : WaterArea2Map
    //{
    //    public WaterArea2Map45()
    //    {
    //        cellName = "WaterArea2 13";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map46 : WaterArea2Map
    //{
    //    public WaterArea2Map46()
    //    {
    //        cellName = "WaterArea2 14";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map47 : WaterArea2Map
    //{
    //    public WaterArea2Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map48 : WaterArea2Map
    //{
    //    public WaterArea2Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map49 : WaterArea2Map
    //{
    //    public WaterArea2Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map50 : WaterArea2Map
    //{
    //    public WaterArea2Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map51 : WaterArea2Map
    //{
    //    public WaterArea2Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map52 : WaterArea2Map
    //{
    //    public WaterArea2Map52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map53 : WaterArea2Map
    //{
    //    public WaterArea2Map53()
    //    {
    //        cellName = "WaterArea2 11";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map54 : WaterArea2Map
    //{
    //    public WaterArea2Map54()
    //    {
    //        cellName = "WaterArea2 10";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map55 : WaterArea2Map
    //{
    //    public WaterArea2Map55()
    //    {
    //        cellName = "WaterArea2 9";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map56 : WaterArea2Map
    //{
    //    public WaterArea2Map56()
    //    {
    //        cellName = "WaterArea2 8";
    //        cellLocation = 56;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map57 : WaterArea2Map
    //{
    //    public WaterArea2Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map58 : WaterArea2Map
    //{
    //    public WaterArea2Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map59 : WaterArea2Map
    //{
    //    public WaterArea2Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map60 : WaterArea2Map
    //{
    //    public WaterArea2Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map61 : WaterArea2Map
    //{
    //    public WaterArea2Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map62 : WaterArea2Map
    //{
    //    public WaterArea2Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map63 : WaterArea2Map
    //{
    //    public WaterArea2Map63()
    //    {
    //        cellLocation = 63;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map64 : WaterArea2Map
    //{
    //    public WaterArea2Map64()
    //    {
    //        cellLocation = 64;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map65 : WaterArea2Map
    //{
    //    public WaterArea2Map65()
    //    {
    //        cellLocation = 65;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map66 : WaterArea2Map
    //{
    //    public WaterArea2Map66()
    //    {
    //        cellName = "WaterArea2 7";
    //        cellLocation = 66;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map67 : WaterArea2Map
    //{
    //    public WaterArea2Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map68 : WaterArea2Map
    //{
    //    public WaterArea2Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map69 : WaterArea2Map
    //{
    //    public WaterArea2Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map70 : WaterArea2Map
    //{
    //    public WaterArea2Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map71 : WaterArea2Map
    //{
    //    public WaterArea2Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map72 : WaterArea2Map
    //{
    //    public WaterArea2Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map73 : WaterArea2Map
    //{
    //    public WaterArea2Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map74 : WaterArea2Map
    //{
    //    public WaterArea2Map74()
    //    {
    //        cellLocation = 74;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map75 : WaterArea2Map
    //{
    //    public WaterArea2Map75()
    //    {
    //        cellName = "WaterArea2 6";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map76 : WaterArea2Map
    //{
    //    public WaterArea2Map76()
    //    {
    //        cellName = "WaterArea2 5";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map77 : WaterArea2Map
    //{
    //    public WaterArea2Map77()
    //    {
    //        cellName = "WaterArea2 4";
    //        cellLocation = 77;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map78 : WaterArea2Map
    //{
    //    public WaterArea2Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map79 : WaterArea2Map
    //{
    //    public WaterArea2Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map80 : WaterArea2Map
    //{
    //    public WaterArea2Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map81 : WaterArea2Map
    //{
    //    public WaterArea2Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map82 : WaterArea2Map
    //{
    //    public WaterArea2Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map83 : WaterArea2Map
    //{
    //    public WaterArea2Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map84 : WaterArea2Map
    //{
    //    public WaterArea2Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map85 : WaterArea2Map
    //{
    //    public WaterArea2Map85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map86 : WaterArea2Map
    //{
    //    public WaterArea2Map86()
    //    {
    //        cellName = "WaterArea2 3";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map87 : WaterArea2Map
    //{
    //    public WaterArea2Map87()
    //    {
    //        cellName = "WaterArea2 2";
    //        cellLocation = 87;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map88 : WaterArea2Map
    //{
    //    public WaterArea2Map88()
    //    {
    //        cellName = "WaterArea2 1";
    //        cellLocation = 88;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea2Map89 : WaterArea2Map
    //{
    //    public WaterArea2Map89()
    //    {
    //        cellName = "";
    //        cellLocation = 89;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 10;
    //        newLocation = 31;
    //    }
    //}
    //public class WaterArea2Map90 : WaterArea2Map
    //{
    //    public WaterArea2Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map91 : WaterArea2Map
    //{
    //    public WaterArea2Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map92 : WaterArea2Map
    //{
    //    public WaterArea2Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map93 : WaterArea2Map
    //{
    //    public WaterArea2Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map94 : WaterArea2Map
    //{
    //    public WaterArea2Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map95 : WaterArea2Map
    //{
    //    public WaterArea2Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map96 : WaterArea2Map
    //{
    //    public WaterArea2Map96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map97 : WaterArea2Map
    //{
    //    public WaterArea2Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map98 : WaterArea2Map
    //{
    //    public WaterArea2Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea2Map99 : WaterArea2Map
    //{
    //    public WaterArea2Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    
    //public class WaterArea3Map : WorldMap
    //{
    //    public WaterArea3Map()
    //    {
    //        mapName = "water area 3";
    //        mapLocation = 27;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 10;
    //    }
    //}
    //public class WaterArea3Map0 : WaterArea3Map
    //{
    //    public WaterArea3Map0()
    //    {
    //        cellName = "";
    //        cellLocation = 0;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 28;
    //        newLocation = 18;
    //    }
    //}
    //public class WaterArea3Map1 : WaterArea3Map
    //{
    //    public WaterArea3Map1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map2 : WaterArea3Map
    //{
    //    public WaterArea3Map2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map3 : WaterArea3Map
    //{
    //    public WaterArea3Map3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map4 : WaterArea3Map
    //{
    //    public WaterArea3Map4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map5 : WaterArea3Map
    //{
    //    public WaterArea3Map5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map6 : WaterArea3Map
    //{
    //    public WaterArea3Map6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map7 : WaterArea3Map
    //{
    //    public WaterArea3Map7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map8 : WaterArea3Map
    //{
    //    public WaterArea3Map8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map9 : WaterArea3Map
    //{
    //    public WaterArea3Map9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map10 : WaterArea3Map
    //{
    //    public WaterArea3Map10()
    //    {
    //        cellName = "WaterArea3 25";
    //        cellLocation = 10;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map11 : WaterArea3Map
    //{
    //    public WaterArea3Map11()
    //    {
    //        cellName = "WaterArea2 24";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map12 : WaterArea3Map
    //{
    //    public WaterArea3Map12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map13 : WaterArea3Map
    //{
    //    public WaterArea3Map13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map14 : WaterArea3Map
    //{
    //    public WaterArea3Map14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map15 : WaterArea3Map
    //{
    //    public WaterArea3Map15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map16 : WaterArea3Map
    //{
    //    public WaterArea3Map16()
    //    {
    //        cellLocation = 16;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map17 : WaterArea3Map
    //{
    //    public WaterArea3Map17()
    //    {
    //        cellLocation = 17;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map18 : WaterArea3Map
    //{
    //    public WaterArea3Map18()
    //    {
    //        cellLocation = 18;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map19 : WaterArea3Map
    //{
    //    public WaterArea3Map19()
    //    {
    //        cellLocation = 19;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map20 : WaterArea3Map
    //{
    //    public WaterArea3Map20()
    //    {
    //        cellName = "WaterArea3 23";
    //        cellLocation = 20;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map21 : WaterArea3Map
    //{
    //    public WaterArea3Map21()
    //    {
    //        cellName = "WaterArea3 22";
    //        cellLocation = 21;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map22 : WaterArea3Map
    //{
    //    public WaterArea3Map22()
    //    {
    //        cellName = "WaterArea3 21";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map23 : WaterArea3Map
    //{
    //    public WaterArea3Map23()
    //    {
    //        cellLocation = 23;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map24 : WaterArea3Map
    //{
    //    public WaterArea3Map24()
    //    {
    //        cellLocation = 24;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map25 : WaterArea3Map
    //{
    //    public WaterArea3Map25()
    //    {
    //        cellLocation = 25;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map26 : WaterArea3Map
    //{
    //    public WaterArea3Map26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map27 : WaterArea3Map
    //{
    //    public WaterArea3Map27()
    //    {
    //        cellLocation = 27;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map28 : WaterArea3Map
    //{
    //    public WaterArea3Map28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map29 : WaterArea3Map
    //{
    //    public WaterArea3Map29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map30 : WaterArea3Map
    //{
    //    public WaterArea3Map30()
    //    {
    //        cellName = "WaterArea3 20";
    //        cellLocation = 30;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map31 : WaterArea3Map
    //{
    //    public WaterArea3Map31()
    //    {
    //        cellName = "WaterArea3 19";
    //        cellLocation = 31;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map32 : WaterArea3Map
    //{
    //    public WaterArea3Map32()
    //    {
    //        cellName = "WaterArea3 18";
    //        cellLocation = 32;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map33 : WaterArea3Map
    //{
    //    public WaterArea3Map33()
    //    {
    //        cellName = "WaterArea3 17";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map34 : WaterArea3Map
    //{
    //    public WaterArea3Map34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map35 : WaterArea3Map
    //{
    //    public WaterArea3Map35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map36 : WaterArea3Map
    //{
    //    public WaterArea3Map36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map37 : WaterArea3Map
    //{
    //    public WaterArea3Map37()
    //    {
    //        cellLocation = 37;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map38 : WaterArea3Map
    //{
    //    public WaterArea3Map38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map39 : WaterArea3Map
    //{
    //    public WaterArea3Map39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map40 : WaterArea3Map
    //{
    //    public WaterArea3Map40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map41 : WaterArea3Map
    //{
    //    public WaterArea3Map41()
    //    {
    //        cellName = "WaterArea3 16";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map42 : WaterArea3Map
    //{
    //    public WaterArea3Map42()
    //    {
    //        cellName = "WaterArea3 15";
    //        cellLocation = 42;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map43 : WaterArea3Map
    //{
    //    public WaterArea3Map43()
    //    {
    //        cellName = "WaterArea3 14";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map44 : WaterArea3Map
    //{
    //    public WaterArea3Map44()
    //    {
    //        cellName = "WaterArea3 13";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map45 : WaterArea3Map
    //{
    //    public WaterArea3Map45()
    //    {
    //        cellLocation = 45;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map46 : WaterArea3Map
    //{
    //    public WaterArea3Map46()
    //    {
    //        cellLocation = 46;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map47 : WaterArea3Map
    //{
    //    public WaterArea3Map47()
    //    {
    //        cellLocation = 47;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map48 : WaterArea3Map
    //{
    //    public WaterArea3Map48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map49 : WaterArea3Map
    //{
    //    public WaterArea3Map49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map50 : WaterArea3Map
    //{
    //    public WaterArea3Map50()
    //    {
    //        cellLocation = 50;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map51 : WaterArea3Map
    //{
    //    public WaterArea3Map51()
    //    {
    //        cellLocation = 51;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map52 : WaterArea3Map
    //{
    //    public WaterArea3Map52()
    //    {
    //        cellName = "WaterArea3 12";
    //        cellLocation = 52;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map53 : WaterArea3Map
    //{
    //    public WaterArea3Map53()
    //    {
    //        cellName = "WaterArea3 11";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map54 : WaterArea3Map
    //{
    //    public WaterArea3Map54()
    //    {
    //        cellName = "WaterArea3 10";
    //        cellLocation = 54;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map55 : WaterArea3Map
    //{
    //    public WaterArea3Map55()
    //    {
    //        cellName = "WaterArea3 9";
    //        cellLocation = 55;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map56 : WaterArea3Map
    //{
    //    public WaterArea3Map56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map57 : WaterArea3Map
    //{
    //    public WaterArea3Map57()
    //    {
    //        cellLocation = 57;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map58 : WaterArea3Map
    //{
    //    public WaterArea3Map58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map59 : WaterArea3Map
    //{
    //    public WaterArea3Map59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map60 : WaterArea3Map
    //{
    //    public WaterArea3Map60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map61 : WaterArea3Map
    //{
    //    public WaterArea3Map61()
    //    {
    //        cellLocation = 61;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map62 : WaterArea3Map
    //{
    //    public WaterArea3Map62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map63 : WaterArea3Map
    //{
    //    public WaterArea3Map63()
    //    {
    //        cellName = "WaterArea3 8";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map64 : WaterArea3Map
    //{
    //    public WaterArea3Map64()
    //    {
    //        cellName = "WaterArea3 7";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map65 : WaterArea3Map
    //{
    //    public WaterArea3Map65()
    //    {
    //        cellName = "WaterArea3 6";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map66 : WaterArea3Map
    //{
    //    public WaterArea3Map66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map67 : WaterArea3Map
    //{
    //    public WaterArea3Map67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map68 : WaterArea3Map
    //{
    //    public WaterArea3Map68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map69 : WaterArea3Map
    //{
    //    public WaterArea3Map69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map70 : WaterArea3Map
    //{
    //    public WaterArea3Map70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map71 : WaterArea3Map
    //{
    //    public WaterArea3Map71()
    //    {
    //        cellLocation = 71;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map72 : WaterArea3Map
    //{
    //    public WaterArea3Map72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map73 : WaterArea3Map
    //{
    //    public WaterArea3Map73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map74 : WaterArea3Map
    //{
    //    public WaterArea3Map74()
    //    {
    //        cellName = "WaterArea3 5";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map75 : WaterArea3Map
    //{
    //    public WaterArea3Map75()
    //    {
    //        cellName = "WaterArea3 4";
    //        cellLocation = 75;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map76 : WaterArea3Map
    //{
    //    public WaterArea3Map76()
    //    {
    //        cellName = "WaterArea3 3";
    //        cellLocation = 76;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map77 : WaterArea3Map
    //{
    //    public WaterArea3Map77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map78 : WaterArea3Map
    //{
    //    public WaterArea3Map78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map79 : WaterArea3Map
    //{
    //    public WaterArea3Map79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map80 : WaterArea3Map
    //{
    //    public WaterArea3Map80()
    //    {
    //        cellLocation = 80;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map81 : WaterArea3Map
    //{
    //    public WaterArea3Map81()
    //    {
    //        cellLocation = 81;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map82 : WaterArea3Map
    //{
    //    public WaterArea3Map82()
    //    {
    //        cellLocation = 82;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map83 : WaterArea3Map
    //{
    //    public WaterArea3Map83()
    //    {
    //        cellLocation = 83;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map84 : WaterArea3Map
    //{
    //    public WaterArea3Map84()
    //    {
    //        cellLocation = 84;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map85 : WaterArea3Map
    //{
    //    public WaterArea3Map85()
    //    {
    //        cellName = "WaterArea3 2";
    //        cellLocation = 85;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map86 : WaterArea3Map
    //{
    //    public WaterArea3Map86()
    //    {
    //        cellName = "WaterArea3 1";
    //        cellLocation = 86;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class WaterArea3Map87 : WaterArea3Map
    //{
    //    public WaterArea3Map87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map88 : WaterArea3Map
    //{
    //    public WaterArea3Map88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map89 : WaterArea3Map
    //{
    //    public WaterArea3Map89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map90 : WaterArea3Map
    //{
    //    public WaterArea3Map90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map91 : WaterArea3Map
    //{
    //    public WaterArea3Map91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map92 : WaterArea3Map
    //{
    //    public WaterArea3Map92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map93 : WaterArea3Map
    //{
    //    public WaterArea3Map93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map94 : WaterArea3Map
    //{
    //    public WaterArea3Map94()
    //    {
    //        cellLocation = 94;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map95 : WaterArea3Map
    //{
    //    public WaterArea3Map95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map96 : WaterArea3Map
    //{
    //    public WaterArea3Map96()
    //    {
    //        cellName = "";
    //        cellLocation = 96;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 26;
    //        newLocation = 1;
    //    }
    //}
    //public class WaterArea3Map97 : WaterArea3Map
    //{
    //    public WaterArea3Map97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map98 : WaterArea3Map
    //{
    //    public WaterArea3Map98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class WaterArea3Map99 : WaterArea3Map
    //{
    //    public WaterArea3Map99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}

    
    //public class CorallosMap : WorldMap
    //{
    //    public CorallosMap()
    //    {
    //        mapName = "corallos";
    //        mapLocation = 28;
    //        mapAccessible = true;
    //        mapVisited = false;
    //        encounterRate = 0;
    //    }
    //}
    //public class CorallosMap0 : CorallosMap
    //{
    //    public CorallosMap0()
    //    {
    //        cellLocation = 0;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap1 : CorallosMap
    //{
    //    public CorallosMap1()
    //    {
    //        cellLocation = 1;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap2 : CorallosMap
    //{
    //    public CorallosMap2()
    //    {
    //        cellLocation = 2;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap3 : CorallosMap
    //{
    //    public CorallosMap3()
    //    {
    //        cellLocation = 3;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap4 : CorallosMap
    //{
    //    public CorallosMap4()
    //    {
    //        cellLocation = 4;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap5 : CorallosMap
    //{
    //    public CorallosMap5()
    //    {
    //        cellLocation = 5;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap6 : CorallosMap
    //{
    //    public CorallosMap6()
    //    {
    //        cellLocation = 6;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap7 : CorallosMap
    //{
    //    public CorallosMap7()
    //    {
    //        cellLocation = 7;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap8 : CorallosMap
    //{
    //    public CorallosMap8()
    //    {
    //        cellLocation = 8;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap9 : CorallosMap
    //{
    //    public CorallosMap9()
    //    {
    //        cellLocation = 9;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap10 : CorallosMap
    //{
    //    public CorallosMap10()
    //    {
    //        cellLocation = 10;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap11 : CorallosMap
    //{
    //    public CorallosMap11()
    //    {
    //        cellLocation = 11;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap12 : CorallosMap
    //{
    //    public CorallosMap12()
    //    {
    //        cellLocation = 12;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap13 : CorallosMap
    //{
    //    public CorallosMap13()
    //    {
    //        cellLocation = 13;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap14 : CorallosMap
    //{
    //    public CorallosMap14()
    //    {
    //        cellLocation = 14;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap15 : CorallosMap
    //{
    //    public CorallosMap15()
    //    {
    //        cellLocation = 15;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap16 : CorallosMap
    //{
    //    public CorallosMap16()
    //    {
    //        cellName = "Corallos 3";
    //        cellLocation = 16;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap17 : CorallosMap
    //{
    //    public CorallosMap17()
    //    {
    //        cellName = "Corallos 2";
    //        cellLocation = 17;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap18 : CorallosMap
    //{
    //    public CorallosMap18()
    //    {
    //        cellName = "Corallos 1";
    //        cellLocation = 18;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap19 : CorallosMap
    //{
    //    public CorallosMap19()
    //    {
    //        cellName = "";
    //        cellLocation = 19;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 27;
    //        newLocation = 10;
    //    }
    //}
    //public class CorallosMap20 : CorallosMap
    //{
    //    public CorallosMap20()
    //    {
    //        cellLocation = 20;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap21 : CorallosMap
    //{
    //    public CorallosMap21()
    //    {
    //        cellLocation = 21;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap22 : CorallosMap
    //{
    //    public CorallosMap22()
    //    {
    //        cellName = "Corallos 13";
    //        cellLocation = 22;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap23 : CorallosMap
    //{
    //    public CorallosMap23()
    //    {
    //        cellName = "Corallos 14";
    //        cellLocation = 23;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap24 : CorallosMap
    //{
    //    public CorallosMap24()
    //    {
    //        cellName = "Corallos 15";
    //        cellLocation = 24;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap25 : CorallosMap
    //{
    //    public CorallosMap25()
    //    {
    //        cellName = "Corallos 16";
    //        cellLocation = 25;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap26 : CorallosMap
    //{
    //    public CorallosMap26()
    //    {
    //        cellLocation = 26;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap27 : CorallosMap
    //{
    //    public CorallosMap27()
    //    {
    //        cellName = "Corallos 4";
    //        cellLocation = 27;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap28 : CorallosMap
    //{
    //    public CorallosMap28()
    //    {
    //        cellLocation = 28;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap29 : CorallosMap
    //{
    //    public CorallosMap29()
    //    {
    //        cellLocation = 29;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap30 : CorallosMap
    //{
    //    public CorallosMap30()
    //    {
    //        cellLocation = 30;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap31 : CorallosMap
    //{
    //    public CorallosMap31()
    //    {
    //        cellLocation = 31;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap32 : CorallosMap
    //{
    //    public CorallosMap32()
    //    {
    //        cellLocation = 32;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap33 : CorallosMap
    //{
    //    public CorallosMap33()
    //    {
    //        cellName = "Corallos 12";
    //        cellLocation = 33;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap34 : CorallosMap
    //{
    //    public CorallosMap34()
    //    {
    //        cellLocation = 34;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap35 : CorallosMap
    //{
    //    public CorallosMap35()
    //    {
    //        cellLocation = 35;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap36 : CorallosMap
    //{
    //    public CorallosMap36()
    //    {
    //        cellLocation = 36;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap37 : CorallosMap
    //{
    //    public CorallosMap37()
    //    {
    //        cellName = "Corallos 5";
    //        cellLocation = 37;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap38 : CorallosMap
    //{
    //    public CorallosMap38()
    //    {
    //        cellLocation = 38;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap39 : CorallosMap
    //{
    //    public CorallosMap39()
    //    {
    //        cellLocation = 39;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap40 : CorallosMap
    //{
    //    public CorallosMap40()
    //    {
    //        cellLocation = 40;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap41 : CorallosMap
    //{
    //    public CorallosMap41()
    //    {
    //        cellName = "Corallos 30";
    //        cellLocation = 41;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap42 : CorallosMap
    //{
    //    public CorallosMap42()
    //    {
    //        cellLocation = 42;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap43 : CorallosMap
    //{
    //    public CorallosMap43()
    //    {
    //        cellName = "Corallos 11";
    //        cellLocation = 43;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap44 : CorallosMap
    //{
    //    public CorallosMap44()
    //    {
    //        cellName = "Corallos 10";
    //        cellLocation = 44;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap45 : CorallosMap
    //{
    //    public CorallosMap45()
    //    {
    //        cellName = "Corallos 9";
    //        cellLocation = 45;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap46 : CorallosMap
    //{
    //    public CorallosMap46()
    //    {
    //        cellName = "Corallos 8";
    //        cellLocation = 46;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap47 : CorallosMap
    //{
    //    public CorallosMap47()
    //    {
    //        cellName = "Corallos 6";
    //        cellLocation = 47;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap48 : CorallosMap
    //{
    //    public CorallosMap48()
    //    {
    //        cellLocation = 48;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap49 : CorallosMap
    //{
    //    public CorallosMap49()
    //    {
    //        cellLocation = 49;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap50 : CorallosMap
    //{
    //    public CorallosMap50()
    //    {
    //        cellName = "Corallos 29";
    //        cellLocation = 50;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap51 : CorallosMap
    //{
    //    public CorallosMap51()
    //    {
    //        cellName = "Corallos 28";
    //        cellLocation = 51;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap52 : CorallosMap
    //{
    //    public CorallosMap52()
    //    {
    //        cellLocation = 52;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap53 : CorallosMap
    //{
    //    public CorallosMap53()
    //    {
    //        cellName = "Corallos 17";
    //        cellLocation = 53;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap54 : CorallosMap
    //{
    //    public CorallosMap54()
    //    {
    //        cellLocation = 54;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap55 : CorallosMap
    //{
    //    public CorallosMap55()
    //    {
    //        cellLocation = 55;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap56 : CorallosMap
    //{
    //    public CorallosMap56()
    //    {
    //        cellLocation = 56;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap57 : CorallosMap
    //{
    //    public CorallosMap57()
    //    {
    //        cellName = "Corallos 7";
    //        cellLocation = 57;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap58 : CorallosMap
    //{
    //    public CorallosMap58()
    //    {
    //        cellLocation = 58;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap59 : CorallosMap
    //{
    //    public CorallosMap59()
    //    {
    //        cellLocation = 59;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap60 : CorallosMap
    //{
    //    public CorallosMap60()
    //    {
    //        cellLocation = 60;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap61 : CorallosMap
    //{
    //    public CorallosMap61()
    //    {
    //        cellName = "Corallos 27";
    //        cellLocation = 61;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap62 : CorallosMap
    //{
    //    public CorallosMap62()
    //    {
    //        cellLocation = 62;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap63 : CorallosMap
    //{
    //    public CorallosMap63()
    //    {
    //        cellName = "Corallos 18";
    //        cellLocation = 63;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap64 : CorallosMap
    //{
    //    public CorallosMap64()
    //    {
    //        cellName = "Corallos 19";
    //        cellLocation = 64;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap65 : CorallosMap
    //{
    //    public CorallosMap65()
    //    {
    //        cellName = "Corallos 20";
    //        cellLocation = 65;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap66 : CorallosMap
    //{
    //    public CorallosMap66()
    //    {
    //        cellLocation = 66;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap67 : CorallosMap
    //{
    //    public CorallosMap67()
    //    {
    //        cellLocation = 67;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap68 : CorallosMap
    //{
    //    public CorallosMap68()
    //    {
    //        cellLocation = 68;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap69 : CorallosMap
    //{
    //    public CorallosMap69()
    //    {
    //        cellLocation = 69;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap70 : CorallosMap
    //{
    //    public CorallosMap70()
    //    {
    //        cellLocation = 70;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap71 : CorallosMap
    //{
    //    public CorallosMap71()
    //    {
    //        cellName = "Corallos 26";
    //        cellLocation = 71;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap72 : CorallosMap
    //{
    //    public CorallosMap72()
    //    {
    //        cellLocation = 72;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap73 : CorallosMap
    //{
    //    public CorallosMap73()
    //    {
    //        cellLocation = 73;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap74 : CorallosMap
    //{
    //    public CorallosMap74()
    //    {
    //        cellName = "Corallos 21";
    //        cellLocation = 74;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap75 : CorallosMap
    //{
    //    public CorallosMap75()
    //    {
    //        cellLocation = 75;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap76 : CorallosMap
    //{
    //    public CorallosMap76()
    //    {
    //        cellLocation = 76;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap77 : CorallosMap
    //{
    //    public CorallosMap77()
    //    {
    //        cellLocation = 77;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap78 : CorallosMap
    //{
    //    public CorallosMap78()
    //    {
    //        cellLocation = 78;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap79 : CorallosMap
    //{
    //    public CorallosMap79()
    //    {
    //        cellLocation = 79;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap80 : CorallosMap
    //{
    //    public CorallosMap80()
    //    {
    //        cellName = "";
    //        cellLocation = 80;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 41;
    //        newLocation = 0; //change
    //    }
    //}
    //public class CorallosMap81 : CorallosMap
    //{
    //    public CorallosMap81()
    //    {
    //        cellName = "Corallos 25";
    //        cellLocation = 81;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap82 : CorallosMap
    //{
    //    public CorallosMap82()
    //    {
    //        cellName = "Corallos 24";
    //        cellLocation = 82;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap83 : CorallosMap
    //{
    //    public CorallosMap83()
    //    {
    //        cellName = "Corallos 23";
    //        cellLocation = 83;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap84 : CorallosMap
    //{
    //    public CorallosMap84()
    //    {
    //        cellName = "Corallos 22";
    //        cellLocation = 84;
    //        accessible = true;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //    }
    //}
    //public class CorallosMap85 : CorallosMap
    //{
    //    public CorallosMap85()
    //    {
    //        cellLocation = 85;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap86 : CorallosMap
    //{
    //    public CorallosMap86()
    //    {
    //        cellLocation = 86;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap87 : CorallosMap
    //{
    //    public CorallosMap87()
    //    {
    //        cellLocation = 87;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap88 : CorallosMap
    //{
    //    public CorallosMap88()
    //    {
    //        cellLocation = 88;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap89 : CorallosMap
    //{
    //    public CorallosMap89()
    //    {
    //        cellLocation = 89;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap90 : CorallosMap
    //{
    //    public CorallosMap90()
    //    {
    //        cellLocation = 90;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap91 : CorallosMap
    //{
    //    public CorallosMap91()
    //    {
    //        cellLocation = 91;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap92 : CorallosMap
    //{
    //    public CorallosMap92()
    //    {
    //        cellLocation = 92;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap93 : CorallosMap
    //{
    //    public CorallosMap93()
    //    {
    //        cellLocation = 93;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap94 : CorallosMap
    //{
    //    public CorallosMap94()
    //    {
    //        cellName = "";
    //        cellLocation = 94;
    //        accessible = false;
    //        visited = false;
    //        gridDescription = "";
    //        gridItems = new List<string> { "" };
    //        Gateway = true;
    //        newMap = 41;
    //        newLocation = 0; //change
    //    }
    //}
    //public class CorallosMap95 : CorallosMap
    //{
    //    public CorallosMap95()
    //    {
    //        cellLocation = 95;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap96 : CorallosMap
    //{
    //    public CorallosMap96()
    //    {
    //        cellLocation = 96;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap97 : CorallosMap
    //{
    //    public CorallosMap97()
    //    {
    //        cellLocation = 97;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap98 : CorallosMap
    //{
    //    public CorallosMap98()
    //    {
    //        cellLocation = 98;
    //        accessible = false;
    //    }
    //}
    //public class CorallosMap99 : CorallosMap
    //{
    //    public CorallosMap99()
    //    {
    //        cellLocation = 99;
    //        accessible = false;
    //    }
    //}
}