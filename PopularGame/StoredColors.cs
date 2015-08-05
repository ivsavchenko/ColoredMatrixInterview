using System;
using System.Collections.Generic;

namespace PopularGame
{
    public class StoredColors: Dictionary<short, int>
    {
        public void Add(short color)
        {
            if (base.ContainsKey(color))
            {
                base[color] += 1;
            }
            else
            {
                base[color] = 1;
            }
        }

        [Obsolete]
        public new void Add(short color, int value)
        {
            throw new NotImplementedException();
        }
    }
}
