using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal interface ICloneable
    {
        ICloneable clone();
    }

    internal interface IDrawable
    {
        void draw();
    }

    internal interface IMoveable
    {
        void move(int dx, int dy);
    }

    internal interface IResizeable
    {
        bool resize(in bool isIncrease);
        void setSize(int _x, int _y, int _width, int _height);
    }

    internal interface IViable
    {
        void save(SavedData savedData);
        void load(StreamReader sr, string[] data, IShapeFactory factory);
    }
    internal interface IShapeFactory
    {
        Shape getShape(string name);
    }
}