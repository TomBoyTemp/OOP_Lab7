using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal class MyShapeFactory : IShapeFactory
    {
        public Shape getShape(string name)
        {
            Shape shape = new Rectangle();
            switch (name)
            {
                case "OOP_LR7.Rectangle":
                    {
                        break;
                    }
                case "OOP_LR7.Square":
                    {
                        shape = new Square();
                        break;
                    }
                case "OOP_LR7.Ellipse":
                    {
                        shape = new Ellipse();
                        break;
                    }
                case "OOP_LR7.Circle":
                    {
                        shape = new Circle();
                        break;
                    }
                case "OOP_LR7.Section":
                    {
                        shape = new Section();
                        break;
                    }
                case "OOP_LR7.Triangle":
                    {
                        shape = new Triangle();
                        break;
                    }
                case "OOP_LR7.Decorator":
                    {
                        shape = new Decorator(null);
                        break;
                    }
                case "OOP_LR7.Group":
                    {
                        shape = new Group();
                        break;
                    }
            }
            return shape;
        }
    }
}
