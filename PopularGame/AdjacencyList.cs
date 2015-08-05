using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PopularGame
{
    public class AdjacencyList : Dictionary<int, List<int>>
    {
        public static AdjacencyList GetInstance => new AdjacencyList();

        private AdjacencyList()
        {
        }

        public AdjacencyList(string fileName)
        {
            var lines = File.ReadLines(fileName).ToList();

            for (int i = 1; i < lines.Count(); i++)
            {
                var splitted = lines[i].Split('\t', ' ').ToList();
                splitted.Remove("");
                List<int> splittedList = splitted.Select(int.Parse).ToList();
                int first = splittedList.First();
                splittedList.Remove(first);
                Add(first, splittedList);
            }
        }
    }
}
