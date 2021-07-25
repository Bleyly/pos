
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using POS.Data;

namespace POS.Tests
{
    public class ColorComparer : IEqualityComparer<Color>
    {
        public bool Equals(Color x, Color y)
        {
            return x.Id.Equals(y.Id) &&
                x.Description.Equals(y.Description) &&
                x.Hexadecimal.Equals(y.Hexadecimal) &&
                x.Name.Equals(y.Name);
        }

        public int GetHashCode([DisallowNull] Color obj)
        {
            return (obj.Id).GetHashCode();
        }
    }
}