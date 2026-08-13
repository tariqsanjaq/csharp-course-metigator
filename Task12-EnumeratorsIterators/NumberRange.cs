using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Task12_EnumeratorsIterators
{
    internal class NumberRange : IEnumerable<int>
    {
        private readonly int _start;
        private readonly int _count;

        public NumberRange(int start, int count)
        {
            _start = start;
            _count = count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NumberRangeEnumerator(_start, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class NumberRangeEnumerator : IEnumerator<int>
        {
            private readonly int _start;
            private readonly int _count;
            private int _index = -1;

            public NumberRangeEnumerator(int start, int count)
            {
                _start = start;
                _count = count;
            }

            public int Current => _start + _index;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // لا موارد تحتاج تنظيف — المدى مجرد أرقام
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _count;
            }

            public void Reset()
            {
                _index = -1;
            }

        }
       
    }


}
