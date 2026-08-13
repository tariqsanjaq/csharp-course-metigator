using System.Collections;

namespace Task12_EnumeratorsIterators
{
    internal class NumberRangeYield : IEnumerable<int>
    {
        private readonly int _start;
        private readonly int _count;

        public NumberRangeYield(int start, int count)
        {
            _start = start;
            _count = count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return i + _start;  
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}