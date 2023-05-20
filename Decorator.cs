using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal class Decorator : Shape
    {
        protected Shape shape;
        public Decorator(Shape _shape)
        {
            shape = _shape;
        }
        public override int X
        {
            get
            {
                return shape.X;
            }
        }
        public override int Y
        {
            get
            {
                return shape.Y;
            }
        }
        public override int Width
        {
            get
            {
                return shape.Width;
            }
        }
        public override int Height
        {
            get
            {
                return shape.Height;
            }
        }
        public override Color Color
        {
            set
            {
                shape.Color = value;
            }
        }
        public override void draw() 
        {
            shape.draw();
            g.DrawRectangle(new Pen(Brushes.Firebrick, 2), shape.X - shape.Width / 2, shape.Y - shape.Height / 2, shape.Width, shape.Height);
        }
        public override Shape getRealObj()
        {
            return shape.getRealObj();
        }
        public override bool resize(in bool isIncrease)
        {
            return shape.resize(isIncrease);
        }
        public override void setSize(int _x, int _y, int _width, int _height)
        {
            shape.setSize(_x, _y, _width, _height);
        }
        public override void procKey(in Keys key)
        {
            shape.procKey(key);
        }
        public override bool isOut()
        {
            return shape.isOut();
        }
        public override bool isPosses(int x, int y)
        {
            return shape.isPosses(x, y);
        }
        public override bool isSelected()
        {
            return true;
        }
        public override void save(SavedData savedData)
        {
            StringBuilder line = new StringBuilder();
            line.Append(ToString()).Append(";");
            savedData.Add(line.ToString());
            shape.save(savedData);
        }
        public override void load(StreamReader sr, string[] data, IShapeFactory factory)
        {
            data = sr.ReadLine().Split(';');
            shape = factory.getShape(data[0]);
            shape.load(sr, data, factory);
        }
    }
}
