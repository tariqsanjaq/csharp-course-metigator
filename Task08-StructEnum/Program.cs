using System;

namespace Task08_StructEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Struct vs Class: Value Type vs Reference Type ===\n");

            // --- STRUCT (value type) ---
            Color original = new Color(255, 0, 0);   // red
            Color copy = original;                   // COPY — separate memory
            copy.R = 0;
            copy.G = 255;                             // mutate the copy only

            Console.WriteLine($"Struct -> original: {original}");
            Console.WriteLine($"Struct -> copy:     {copy}");
            Console.WriteLine("Changing 'copy' did NOT affect 'original' — each variable owns its own data.\n");

            // --- CLASS (reference type) ---
            ColorBox originalBox = new ColorBox(255, 0, 0);  // red
            ColorBox copyBox = originalBox;                  // COPY of the REFERENCE, same object
            copyBox.R = 0;
            copyBox.G = 255;

            Console.WriteLine($"Class  -> originalBox: {originalBox}");
            Console.WriteLine($"Class  -> copyBox:     {copyBox}");
            Console.WriteLine("Changing 'copyBox' DID affect 'originalBox' — both variables point to the same object.\n");

            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine("=== [Flags] Enum: Bitwise Operations ===\n");

            // Combine flags with | (bitwise OR) — like flipping on multiple
            // switches on the same panel at once.
            OrderStatus status = OrderStatus.Placed | OrderStatus.Paid;
            Console.WriteLine($"Status after placing and paying: {status}");

            status |= OrderStatus.Shipped;
            Console.WriteLine($"Status after shipping: {status}");

            // Check whether a specific flag is set — two equivalent ways:
            bool isPaid = (status & OrderStatus.Paid) == OrderStatus.Paid;
            bool isDelivered = status.HasFlag(OrderStatus.Delivered);
            Console.WriteLine($"Is paid?      {isPaid}");
            Console.WriteLine($"Is delivered? {isDelivered}");

            // Remove a flag with &= ~flag (bitwise AND with the inverse) —
            // flips off just that one switch, leaves the rest untouched.
            status &= ~OrderStatus.Paid;
            Console.WriteLine($"Status after removing 'Paid': {status}");

            status |= OrderStatus.Cancelled;
            Console.WriteLine($"Status after cancelling: {status}");
        }
    }
}