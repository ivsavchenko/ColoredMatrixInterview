using System;

namespace PopularGame
{
    public class MatrixColorator : IColorator
    {
        private readonly IGraphTraversal traversal;

        public MatrixColorator(IGraphTraversal t)
        {
            traversal = t;
        }

        public void Color()
        {
            int stepsCount = 0;
            bool colored = false;

            while (!colored)
            {
                stepsCount++;
                colored = traversal.Traverse();
            }

            Console.WriteLine("Matrix was colored in {0} steps", stepsCount);
        }
    }
}
