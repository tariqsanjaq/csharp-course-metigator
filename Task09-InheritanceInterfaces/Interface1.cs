using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    internal interface IDrawable
    {
        void Draw();
    }

    internal interface IResizable
    {
        void Resize(double factor);

    }
}
