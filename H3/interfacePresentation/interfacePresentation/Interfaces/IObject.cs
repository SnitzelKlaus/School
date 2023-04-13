﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacePresentation.Interfaces
{
    public interface IObject
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        bool IsHitable { get; }
        bool IsFrozen { get; }
        bool IsVisible { get; }
        void Draw(int x, int y);
    }
}