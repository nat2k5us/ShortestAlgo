using System;
using System.Xml;

namespace stoneeagle
{
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;



    class Program
    {
        private static int MapRows { get; set; }
        private static int MapColumns { get; set; }
        public static root Deserialize()
        {
            root rootbase = null;
            string path = @"input1.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(root));

            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            if (reader != null)
            {
                reader.BaseStream.Position = 0;
            }
            rootbase = (root)serializer.Deserialize(reader);
            reader.Close();

            return rootbase;
        }
        public static void LoadXml(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList players = doc.SelectNodes("/root/players/player");
            foreach (XmlNode player in players)
            {
                string name = player.Attributes["name"].Value;
                foreach (XmlNode tile in player.ChildNodes)
                {
                    string code = tile.Attributes["terrain"].Value;
                    int cost = Int32.Parse(tile.Attributes["cost"].Value);
                }
            }
            XmlNodeList rows = doc.SelectNodes("/root/map/row");
            foreach (XmlNode row in rows)
            {
                string mapTiles = row.InnerText;
            }

        }

        public static int GetTileCost(rootPlayer player, string s)
        {
            if (s.Equals("*")) return 0;
            foreach (var rootPlayerTile in player.tile)
            {
                if (rootPlayerTile.terrain.Equals(s))
                {
                    if (Int32.TryParse(rootPlayerTile.cost, out var cost))
                        return cost;
                }
            }

            return 1;
            throw new ArgumentException("Tile not found for player");
        }

        public static int[,] NavigateCost(rootPlayer player, string[] map)
        {
            int[,] mapCost = new int[MapRows, MapColumns];
            int currentRow = 0;
            int currentCol = 0;

            foreach (var s in map)
            {
                foreach (var c in s.ToCharArray())
                {
                    mapCost[currentRow, currentCol] = GetTileCost(player, c.ToString());
                    currentCol++;
                }

                currentCol = 0;
                currentRow++;
            }

            return mapCost;
        }


        static void Main(string[] args)
        {
            var root = Deserialize();
            var players = root.players;
            var map = root.map;
            MapRows = map.Length;
            MapColumns = map[0].Length;
            foreach (var player in players)
            {
                Console.WriteLine($"{player}");
                var costGraph = NavigateCost(player, map);
                Dijkstra.Print2DArray(costGraph);
                Console.WriteLine();

                var res = Dijkstra.minCost(costGraph, 9, 9, player);
                var query = from int item in res select item;
                int start = 0;
                for (int cols = 0; cols < MapColumns; cols++)
                {
                    var rowitems = query.Skip(start).Take(MapColumns);
                    Console.WriteLine($"Total = {rowitems.Sum()}");
                    start += MapColumns;
                }

               
                Dijkstra.Print2DArray(res);
                Console.WriteLine();
                // Dijkstra.DijkstraAlgo(costGraph, 0, 9);

            }

        }
    }
}
