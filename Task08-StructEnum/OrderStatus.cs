using System;
using System.Collections.Generic;
using System.Text;

namespace Task08_StructEnum
{
    // [Flags] tells C# (and anyone reading this enum) that these values
    // are meant to be COMBINED with bitwise OR, not used one at a time
    // like a normal enum. That's why each value is a power of 2 —
    // 1, 2, 4, 8, 16 — each one lights up exactly one bit:
    //
    //   Placed    = 0001
    //   Paid      = 0010
    //   Shipped   = 0100
    //   Delivered = 1000
    //
    // Combine them and every flag keeps its own bit, like separate light
    // switches on the same panel that never interfere with each other.
    [Flags]
    public enum OrderStatus
    {
        None = 0,
        Placed = 1,
        Paid = 2,
        Shipped = 4,
        Delivered = 8,
        Cancelled = 16
    }
}
