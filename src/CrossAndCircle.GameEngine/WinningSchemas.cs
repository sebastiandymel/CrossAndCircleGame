using System.Collections.Generic;
using System.Linq;

namespace CrossAndCircle.GameEngine
{
    public class WinningSchemas
    {
        private readonly int size;
        private List<int[]> winners;

        public WinningSchemas(int size)
        {
            this.size = size;
            if (size == 3)
            {
                winners = new List<int[]>()
                {
                    new [] {0,1,2},
                    new [] {3,4,5},
                    new [] {6,7,8},
                    new [] {0,3,6},
                    new [] {1,4,7},
                    new [] {2,5,8},
                    new [] {0,4,8},
                    new [] {2,4,6},
                };
            }
            else if (size == 2)
            {
                winners = new List<int[]>()
                {
                    new [] {0,1},
                    new [] {2,3},
                    new [] {0,2},
                    new [] {1,3},
                    new [] {0,3},
                    new [] {1,2}
                };
            }
        }

        public bool Contains(int[] selectedIndexes, out int[] result)
        {
            result = winners.FirstOrDefault(x => x.All(i => selectedIndexes.Contains(i)));
            return 
                selectedIndexes.Length >= this.size && 
                result != null;
        }
    } 
}
