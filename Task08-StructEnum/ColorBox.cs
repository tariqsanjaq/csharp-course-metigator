using System;
using System.Collections.Generic;
using System.Text;

namespace Task08_StructEnum
{
    // ColorBox holds the exact same data as Color, but as a CLASS —
    // a REFERENCE TYPE. Assigning one ColorBox to another variable does
    // NOT copy the data; it copies the ADDRESS of the same box. Both
    // variables now point at the same physical object — like two people
    // holding remote controls to the same TV. Changing the channel with
    // either remote changes what both people see, because there's really
    // only one TV.
    public class ColorBox
    {
        public byte R;
        public byte G;
        public byte B;

        public ColorBox(byte r, byte g, byte b)
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
