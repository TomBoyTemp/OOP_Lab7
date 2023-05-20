using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Drawing;
using System.Text;

namespace OOP_LR7
{
    internal abstract class Shape : ICloneable, IDrawable, IMoveable, IResizeable, IViable
    {
        public static PictureBox Box;
        public static Graphics g;
        protected int x, y, height = 10, width = 10;
        protected Color color;
        public virtual int X
        {
            get
            {
                return x;
            }
        }
        public virtual int Y
        {
            get
            {
                return y;
            }
        }
        public virtual int Width
        {
            get
            {
                return width;
            }
        }
        public virtual int Height
        {
            get
            {
                return height;
            }
        }
        public virtual Color Color
        {
            set
            {
                this.color = value;
            }
        }
        public virtual ICloneable clone() { return null; }
        public virtual void draw() { }
        public virtual Shape getRealObj()
        {
            return this;
        }
        public virtual void move(int dx, int dy) 
        {
            x += dx;
            y += dy;
            if (isOut())
            {
                if (dx < 0)
                {
                    x = width / 2;
                }
                else if (dx > 0)
                {
                    x = (int)(Box.Size.Width - width / 2);
                }
                else if (dy < 0)
                {
                    y = height / 2;
                }
                else
                {
                    y = (int)(Box.Size.Height - height / 2);
                }
            }
        }
        public virtual bool resize(in bool isIncrease)
        {
            int _width = width, _height = height;
            if (isIncrease == true)
            {
                width = _width + 25;
                height = _height + 25 * _height / _width;
            }
            else
            {
                width = _width - 25;
                height = _height - 25 * _height / _width;
            }
            if (isOut() || width < 10 || height < 10)
            {
                width = _width;
                height = _height;
                return false;
            }
            return true;
        }
        public virtual void setSize(int _x, int _y, int _width, int _height)
        {
            x = _x + _width / 2;
            y = _y + _height / 2;
            height = _height > 0 ? _height : -_height;
            height = height < 10 ? 10 : height;
            width = _width > 0 ? _width : -_width;
            width = width < 10 ? 10 : width;
            if (x > Box.Size.Width - width / 2)
            {
                width = Box.Size.Width - _x;
                x = _x + width / 2;
            }
            if (y > Box.Size.Height - height / 2)
            {
                height = Box.Size.Height - _y;
                y = _y + height / 2;
            }
        }
        public virtual void procKey(in Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    move(-25, 0);
                    break;
                case Keys.Right:
                    move(25, 0);
                    break;
                case Keys.Down:
                    move(0, 25);
                    break;
                case Keys.Up:
                    move(0, -25);
                    break;
                case Keys.Add:
                    resize(true);
                    break;
                case Keys.Subtract:
                    resize(false);
                    break;
            }
        }
        public virtual bool isOut()
        {
            return !(x >= width / 2
            && x <= Box.Size.Width -  width / 2
            && y <= Box.Size.Height - height / 2 
            && y >= height / 2);
        }
        public virtual bool isPosses(int x, int y)
        {
            return false;
        }
        public virtual bool isSelected()
        {
            return false;
        }
        public virtual void save(SavedData savedData)
        {
            StringBuilder line = new StringBuilder();
            line.Append(ToString()).Append(";");
            line.Append(x.ToString()).Append(";");
            line.Append(y.ToString()).Append(";");
            line.Append(height.ToString()).Append(";");
            line.Append(width.ToString()).Append(";");
            line.Append(color.ToArgb()).Append(";");
            savedData.Add(line.ToString());
        }
        public virtual void load(StreamReader sr, string[] data, IShapeFactory factory)
        {
            x = int.Parse(data[1]);
            y = int.Parse(data[2]);
            height = int.Parse(data[3]);
            width = int.Parse(data[4]);
            color = Color.FromArgb(int.Parse(data[5]));
        }
    }
    internal class Rectangle : Shape
    {
        public override ICloneable clone()
        {
            return new Rectangle();
        }
        public override void draw()
        {
            g.FillRectangle(new SolidBrush(color), x - width / 2, y - height / 2, width, height);
        }
        public override bool isPosses(int _x, int _y)
        {
            return _x >= x - width / 2
                && _x <= x + width / 2
                && _y >= y - height / 2
                && _y <= y + height / 2;
        }
    }
    internal class Square : Rectangle
    {
        public override ICloneable clone()
        {
            return new Square();
        }
        public override void setSize(int _x, int _y, int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                _width = _width > _height ? _width : _height;
                _height = _width;
            }
            else if (_width > 0 && _height < 0)
            {
                _width = _width > -_height ? _width : -_height;
                _height = -_width;
            } 
            else if (_width < 0 && _height > 0)
            {
                _width = -_width > _height ? _width : -_height;
                _height = -_width;
            }
            else
            {
                _width = -_width > -_height ? _width : _height;
                _height = _width;
            }
            base.setSize(_x, _y, _width, _height);
        }
    }
    internal class Ellipse : Shape
    {
        public override ICloneable clone()
        {
            return new Ellipse();
        }
        public override void draw()
        {
            g.FillEllipse(new SolidBrush(color), x - width / 2, y - height / 2, width, height);
        }
        public override bool isPosses(int _x, int _y)
        {
            long dx = _x - x, dy = _y - y;
            long rx = width / 2, ry = height / 2;
            long tmp = dx * dx * ry * ry + dy * dy * rx * rx - rx * rx * ry * ry;
            return tmp <= 0;
        }
    }
    internal class Circle : Ellipse
    {
        public override ICloneable clone()
        {
            return new Circle();
        }
        public override void setSize(int _x, int _y, int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                _width = _width > _height ? _width : _height;
                _height = _width;
            }
            else if (_width > 0 && _height < 0)
            {
                _width = _width > -_height ? _width : -_height;
                _height = -_width;
            }
            else if (_width < 0 && _height > 0)
            {
                _width = -_width > _height ? _width : -_height;
                _height = -_width;
            }
            else
            {
                _width = -_width > -_height ? _width : _height;
                _height = _width;
            }
            base.setSize(_x, _y, _width, _height);
        }
    }
    internal class Section : Shape
    {
        //0 - 1st quarter
        //1 - 2nd _
        //2 - 3rd _
        //3 - 4th _
        int direction;
        public override ICloneable clone()
        {
            return new Section();
        }
        public override void draw()
        {
            switch (direction)
            {
                case 0:
                    g.DrawLine(new Pen(color), x - width / 2, y - height / 2, x + width / 2, y + height / 2);
                    break;
                case 1:
                    g.DrawLine(new Pen(color), x + width / 2, y - height / 2, x - width / 2, y + height / 2);
                    break;
                case 2:
                    g.DrawLine(new Pen(color), x + width / 2, y + height / 2, x - width / 2, y - height / 2);
                    break;
                case 3:
                    g.DrawLine(new Pen(color), x - width / 2, y + height / 2, x + width / 2, y - height / 2);
                    break;
            }
        }
        public override bool isPosses(int _x, int _y)
        {
            return _x >= x - width / 2
                && _x <= x + width / 2
                && _y >= y - height / 2
                && _y <= y + height / 2;
        }
        public override void setSize(int _x, int _y, int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                direction = 0;
            }
            else if (_width < 0 && _height > 0)
            {
                direction = 1;
            }
            else if (_width < 0 && _height < 0)
            {
                direction = 2;
            }
            else
            {
                direction = 3;
            }
            base.setSize(_x, _y, _width, _height);
        }
    }
    internal class Triangle : Shape
    {
        public override ICloneable clone()
        {
            return new Triangle();
        }
        public override void draw()
        {
            Point[] tmp_polygon = new Point[3];
            tmp_polygon[0] = new Point(x, y - height / 2);
            tmp_polygon[1] = new Point(x - width / 2, y + height / 2);
            tmp_polygon[2] = new Point(x + width / 2, y + height / 2);
            g.FillPolygon(new SolidBrush(color), tmp_polygon);
        }
        public override bool isPosses(int _x, int _y)
        {
            int p = vect(x - _x, y - height / 2 - _y, x - width / 2 - x, y + height / 2 - (y - height / 2)),
                q = vect(x - width / 2 - _x, y + height / 2 - _y, x + width / 2 - (x - width / 2), y + height / 2 - (y + height / 2)),
                r = vect(x + width / 2 - _x, y + height / 2 - _y, x - (x + width / 2), y - height / 2 - (y + height / 2));
            return ((p <= 0 && q <= 0 && r <= 0) || (p >= 0 && q >= 0 && r >= 0));
        }
        private int vect(int x1, int y1, int x2, int y2) 
        {
            return x1 * y2 - x2 * y1;
        }
    }
}