using System.Collections.Generic;
using System.Linq;

namespace FairyField
{
    public class WeightedChooser<T>
    {
        private readonly (T Item, int Weight)[] elements;

        public WeightedChooser(IEnumerable<(T, int)> elements)
        {
            this.elements = elements.ToArray();
        }

        public T GetByOffset(int n)
        {
            while (n > 0)
            {
                foreach (var element in elements)
                {
                    n -= element.Weight;
                    if (n <= 0)
                    {
                        return element.Item;
                    }
                }
            }

            return default(T);
        }
    }
}