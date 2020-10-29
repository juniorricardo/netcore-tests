using System;

namespace Comparable
{
    public class Keys : IComparable
    {
        protected readonly string value;
        public Keys(string inValue) => value = inValue;

        public int CompareTo(object inKey)
        {
            Keys otherKey = inKey as Keys;

            if (inKey == null) return 1;

            if (otherKey != null)
                return this.value.CompareTo(otherKey.value);
            else
                throw new ArgumentException("Parametro no valido.");
        }
    }
}
