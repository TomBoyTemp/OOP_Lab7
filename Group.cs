using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR7
{
    internal class Group : Shape
    {
        protected MyContainer<Shape> members = new MyContainer<Shape>();
        public Group()
        {
            x = -1;
        }
        protected void updateSize(Shape mem)
        {
            if (x == -1)
            {
                x = mem.X;
                y = mem.Y;
                height = mem.Height;
                width = mem.Width;
            }
            else
            {
                int top = mem.X + mem.Width / 2 > x + width / 2 ? mem.X + mem.Width / 2 : x + width / 2,
                    bottom = mem.X - mem.Width / 2 < x - width / 2 ? mem.X - mem.Width / 2 : x - width / 2;
                x = (top + bottom) / 2;
                width = top - bottom;

                top = mem.Y + mem.Height / 2 > y + height / 2 ? mem.Y + mem.Height / 2 : y + height / 2;
                bottom = mem.Y - mem.Height / 2 < y - height / 2 ? mem.Y - mem.Height / 2 : y - height / 2;
                y = (top + bottom) / 2;
                height = top - bottom;
            }
        }
        public void add(Shape mem)
        {
            members.add(mem);
            updateSize(mem);
        }
        public Shape takeMember()
        {
            if (members.Count > 0)
            {
                return members.remove(0);
            }
            else
            {
                return null;
            }
        }
        public override Color Color
        {
            set
            {
                this.color = value;
                for (int i = 0; i < members.Count; i++)
                {
                    members[i].Color = value;
                }
            }
        }
        public override void draw()
        {
            for (int i = 0; i < members.Count; i++)
            {
                members[i].draw();
            }
        }
        public override void move(int dx, int dy)
        {
            x += dx;
            y += dy;
            if (isOut())
            {
                x -= dx;
                y -= dy;
                if (dx < 0)
                {
                    dx = width / 2 - x;
                }
                else if (dx > 0)
                {
                    dx = (int)(Box.Size.Width - width / 2) - x;
                }
                else if (dy < 0)
                {
                    dy = height / 2 - y;
                }
                else
                {
                    dy = (int)(Box.Size.Height - height / 2) - y;
                }
                x += dx;
                y += dy;
            }
            for (int i = 0; i < members.Count; i++)
            {
                members[i].move(dx, dy);
            }
        }
        public override bool resize(in bool isIncrease)
        {
            int index = -1;
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].resize(isIncrease) == false)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                x = -1;
                for (int i = 0; i < members.Count; i++)
                {
                    updateSize(members[i]);
                }
                return true;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    members[i].resize(!isIncrease);
                }
                return false;
            }
        }
        public override bool isPosses(int x, int y)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].isPosses(x, y))
                {
                    return true;
                }
            }
            return false;
        }
        public override void save(SavedData savedData)
        {
            StringBuilder line = new StringBuilder();
            line.Append(ToString()).Append(";");
            line.Append(members.Count.ToString()).Append(";");
            savedData.Add(line.ToString());
            for (int i = 0; i < members.Count; i++)
            {
                members[i].save(savedData);
            }
        }
        public override void load(StreamReader sr, string[] data, IShapeFactory factory)
        {
            int count = int.Parse(data[1]);
            for (int i = 0; i < count; i++)
            {
                data = sr.ReadLine().Split(';');
                Shape shape = factory.getShape(data[0]);
                shape.load(sr, data, factory);
                add(shape);
            }
        }
    }
}
