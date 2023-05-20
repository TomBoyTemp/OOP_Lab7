using static System.Collections.Specialized.BitVector32;

namespace OOP_LR7
{
    public partial class mainForm : Form
    {
        MyContainer<Shape> container = new MyContainer<Shape>(100);
        Color actualColor;
        Shape actualShape;
        SavedData savedData;
        IShapeFactory factory;
        bool isCreatingShape,
            isCtrl;
        int x_begin, y_begin;
        string fileName;

        public mainForm()
        {
            InitializeComponent();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            Shape.Box = pictureBox;
            actualColor = Color.Black;
            actualShape = rectangleToolStripMenuItem.Tag as Shape;
            rectangleToolStripMenuItem.Checked = true;
            isCreatingShape = false;
            savedData = new SavedData();
            factory = new MyShapeFactory();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Shape.g = e.Graphics;
            for (int i = 0; i < container.Count; i++)
            {
                container[i].draw();
            }
        }
        private void shapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;
            actualShape = obj.Tag as Shape;
            squareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            sectionToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            obj.Checked = true;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isCreatingShape)
            {
                isCreatingShape = true;
                for (int i = 0; i < container.Count; i++)
                {
                    container[i] = container[i].getRealObj();
                }
                Shape tmp = new Decorator(actualShape.clone() as Shape);
                x_begin = e.X;
                y_begin = e.Y;
                tmp.setSize(x_begin, y_begin, 0, 0);
                tmp.Color = actualColor;
                container.add(tmp);
                Refresh();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (container.Count == 0)
                {
                    return;
                }
                if (isCtrl == false)
                {
                    for (int i = 0; i < container.Count; i++)
                    {
                        container[i] = container[i].getRealObj();
                    }
                }
                bool isSelectSomething = isCtrl;
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].isPosses(e.X, e.Y) && !container[i].isSelected())
                    {
                        container[i] = new Decorator(container[i]);
                        isSelectSomething = true;
                        break;
                    }
                }
                if (!isSelectSomething)
                {
                    container[container.Count - 1] = new Decorator(container[container.Count - 1]);
                }
                Refresh();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < container.Count; i++)
                {
                    container[i] = container[i].getRealObj();
                }
                Refresh();
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCreatingShape = false;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCreatingShape)
            {
                container[container.Count - 1].setSize(x_begin, y_begin, e.X - x_begin, e.Y - y_begin);
                Refresh();
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = true;
                return;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].isSelected())
                    {
                        container.remove(i);
                        i--;
                    }
                }
                if (container.Count > 0)
                {
                    container[container.Count - 1] = new Decorator(container[container.Count - 1]);
                }
            }
            else
            {
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].isSelected())
                    {
                        container[i].procKey(e.KeyCode);
                    }
                }
            }
            Refresh();
        }

        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrl = false;
            }
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                actualColor = colorDialog.Color;
            }
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].isSelected())
                {
                    container[i].Color = actualColor;
                }
            }
            Refresh();
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].isOut())
                {
                    int new_X = container[i].X + container[i].Width / 2 + 18,
                        new_Y = container[i].Y + container[i].Height / 2 + 75;
                    if (new_X < Size.Width)
                    {
                        new_X = Size.Width;
                    }
                    if (new_Y < Size.Height)
                    {
                        new_Y = Size.Height;
                    }
                    Size = new Size(new_X, new_Y);
                    return;
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            container.clear();
            if (fileName == null)
            {
                return;
            }
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split(';');
                Shape shape = factory.getShape(data[0]);
                shape.load(sr, data, factory);
                container.add(shape);
            }
            sr.Close();
            Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
            for (int i = 0; i < container.Count; i++)
            {
                container[i].save(savedData);
            }
            savedData.Save(fileName);
            savedData.Clear();
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countMembers = 0;
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].isSelected())
                {
                    countMembers++;
                }
            }
            if (countMembers > 1)
            {
                Group new_group = new Group();
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].isSelected())
                    {
                        new_group.add(container[i].getRealObj());
                        container.remove(i);
                        i--;
                    }
                }
                container.add(new Decorator(new_group));
                Refresh();
            }
        }

        private void ungroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group group;
            int count = container.Count;
            for (int i = 0; i < count; i++)
            {
                if (container[i].isSelected() && container[i].getRealObj() is Group)
                {
                    group = container[i].getRealObj() as Group;
                    container.remove(i);
                    i--;
                    count--;
                    Shape mem = group.takeMember();
                    while (mem != null)
                    {
                        container.add(new Decorator(mem));
                        mem = group.takeMember();
                    }
                }
            }
            Refresh();
        }
    }
}