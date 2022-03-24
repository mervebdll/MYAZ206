using System;
using System.Collections;

namespace DataStructures.Array
{
    public class CustomArrayEnumerator : IEnumerator//implamente ettik.
    {
        private Object[] _array;
        private int index;
        public CustomArrayEnumerator(Object[] array)
        {
            _array = array;
            index = -1;//pozisyon bilgisi.(-1 yapmamızın sebebi moveNext ile başladığından index 1 artacak.)
        }
        public object Current => _array[index];

        public bool MoveNext()
        {
            if (index < _array.Length-1)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = - 1;

        }
    }
}
