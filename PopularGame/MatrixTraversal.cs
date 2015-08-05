using System;
using System.Collections.Generic;
using System.Linq;

namespace PopularGame
{
    public class MatrixTraversal: IGraphTraversal
    {
        private bool[] markedVertices;
        private Queue<int> traversalQueue = new Queue<int>();
        private AdjacencyList adjacencyList;
        private short[] verticesColoring;

        private short[] adjacentColorsCount;

        public MatrixTraversal()
        {
        }

        public MatrixTraversal(AdjacencyList list, short[] clr)
        {
            Initialize(list, clr);
        }

        public void Initialize(AdjacencyList list, short[] clr)
        {
            if (list == null || clr == null)
            {
                throw new ArgumentException("Input parameters shouldn't be null");
            }

            adjacencyList = list;
            // markedVertices = new bool[adjacencyList.Count + 1];
            verticesColoring = new short[clr.Count() + 1];

            // some extra reindexing operation just for comfort
            for (int i = 1; i < verticesColoring.Count(); i++)
            {
                verticesColoring[i] = clr[i - 1];
            }
        }

        public bool Traverse()
        {
            if (adjacencyList == null)
            {
                throw new ArgumentException("Missing initialization arguments");
            }

            markedVertices = new bool[adjacencyList.Count + 1];
            List<int> adjacentWithRootColor = new List<int>();
            StoredColors storedColors = new StoredColors();
            int head = 1;
            traversalQueue.Enqueue(head);
            markedVertices[head] = true;

            short headColor = verticesColoring[head];
            adjacentWithRootColor.Add(head);

            while (traversalQueue.Any())
            {
                int node = traversalQueue.Dequeue();
                Console.WriteLine(node);

                foreach (int tail in adjacencyList[node])
                {
                    if (markedVertices[tail])
                        continue;

                    // if tail has diff color add it to counter 
                    if (verticesColoring[tail] != headColor)
                    {
                        storedColors.Add(verticesColoring[tail]);
                        markedVertices[tail] = true; // it's probably redundant, but in time pressure conditions I'd like to have it there. TODO check
                        continue;
                    }

                    // if tail has same color, then store it for recoloring and continue traversal
                    adjacentWithRootColor.Add(tail);
                    markedVertices[tail] = true;
                    traversalQueue.Enqueue(tail);
                }
            }

            // short winnerColor = storedColors.First(x => x.Value == storedColors.Values.Max()).Key;

            var winnerColor = storedColors.FirstOrDefault(x => x.Value == storedColors.Values.Max());
            if (winnerColor.Equals(default(KeyValuePair<short, int>)))
            {
                return true;
            }

            Console.WriteLine("And the winner color is: {0}", winnerColor.Key);

            // recolor vertices
            foreach (int vertice in adjacentWithRootColor)
            {
                verticesColoring[vertice] = winnerColor.Key;
            }

            return false;
        }
    }
}
