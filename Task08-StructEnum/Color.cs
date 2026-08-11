using System;
using System.Collections.Generic;
using System.Text;

namespace Task08_StructEnum
{
    // A struct is a VALUE TYPE. When you assign one Color to another
    // variable, or pass it into a method, C# copies the whole thing —
    // like photocopying a paper form. The copy and the original become
    // two separate pieces of paper; scribbling on one doesn't touch the other.
    internal struct Color
    {
        public byte R;
        public byte G;
        public byte B;


        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"RGB({R}, {G}, {B})";
        }

    }
}
