namespace OOP_LR7
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Square square1 = new Square();
            Circle circle1 = new Circle();
            Ellipse ellipse1 = new Ellipse();
            Section section1 = new Section();
            Rectangle rectangle1 = new Rectangle();
            Triangle triangle1 = new Triangle();
            menuStrip = new MenuStrip();
            shapesToolStripMenuItem = new ToolStripMenuItem();
            squareToolStripMenuItem = new ToolStripMenuItem();
            circleToolStripMenuItem = new ToolStripMenuItem();
            ellipseToolStripMenuItem = new ToolStripMenuItem();
            sectionToolStripMenuItem = new ToolStripMenuItem();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            triangleToolStripMenuItem = new ToolStripMenuItem();
            changeColorToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            groupToolStripMenuItem = new ToolStripMenuItem();
            ungroupToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            pictureBox = new PictureBox();
            saveFileDialog = new SaveFileDialog();
            colorDialog = new ColorDialog();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { shapesToolStripMenuItem, changeColorToolStripMenuItem, saveToolStripMenuItem, loadToolStripMenuItem, groupToolStripMenuItem, ungroupToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(882, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // shapesToolStripMenuItem
            // 
            shapesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { squareToolStripMenuItem, circleToolStripMenuItem, ellipseToolStripMenuItem, sectionToolStripMenuItem, rectangleToolStripMenuItem, triangleToolStripMenuItem });
            shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            shapesToolStripMenuItem.Size = new Size(70, 24);
            shapesToolStripMenuItem.Text = "Shapes";
            // 
            // squareToolStripMenuItem
            // 
            squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            squareToolStripMenuItem.Size = new Size(203, 26);
            squareToolStripMenuItem.Tag = square1;
            squareToolStripMenuItem.Text = "Квадрат";
            squareToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // circleToolStripMenuItem
            // 
            circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            circleToolStripMenuItem.Size = new Size(203, 26);
            circleToolStripMenuItem.Tag = circle1;
            circleToolStripMenuItem.Text = "Круг";
            circleToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // ellipseToolStripMenuItem
            // 
            ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            ellipseToolStripMenuItem.Size = new Size(203, 26);
            ellipseToolStripMenuItem.Tag = ellipse1;
            ellipseToolStripMenuItem.Text = "Овал";
            ellipseToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // sectionToolStripMenuItem
            // 
            sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            sectionToolStripMenuItem.Size = new Size(203, 26);
            sectionToolStripMenuItem.Tag = section1;
            sectionToolStripMenuItem.Text = "Отрезок";
            sectionToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(203, 26);
            rectangleToolStripMenuItem.Tag = rectangle1;
            rectangleToolStripMenuItem.Text = "Прямоугольник";
            rectangleToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // triangleToolStripMenuItem
            // 
            triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            triangleToolStripMenuItem.Size = new Size(203, 26);
            triangleToolStripMenuItem.Tag = triangle1;
            triangleToolStripMenuItem.Text = "Треугольник";
            triangleToolStripMenuItem.Click += shapeToolStripMenuItem_Click;
            // 
            // changeColorToolStripMenuItem
            // 
            changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            changeColorToolStripMenuItem.Size = new Size(111, 24);
            changeColorToolStripMenuItem.Text = "Change color";
            changeColorToolStripMenuItem.Click += changeColorToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(54, 24);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(56, 24);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // groupToolStripMenuItem
            // 
            groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            groupToolStripMenuItem.Size = new Size(64, 24);
            groupToolStripMenuItem.Text = "Group";
            groupToolStripMenuItem.Click += groupToolStripMenuItem_Click;
            // 
            // ungroupToolStripMenuItem
            // 
            ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            ungroupToolStripMenuItem.Size = new Size(81, 24);
            ungroupToolStripMenuItem.Text = "Ungroup";
            ungroupToolStripMenuItem.Click += ungroupToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 28);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(882, 425);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.Paint += panel_Paint;
            pictureBox.MouseDown += panel_MouseDown;
            pictureBox.MouseMove += panel_MouseMove;
            pictureBox.MouseUp += panel_MouseUp;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 453);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Name = "mainForm";
            Text = "Paint";
            Load += mainForm_Load;
            SizeChanged += mainForm_SizeChanged;
            KeyDown += mainForm_KeyDown;
            KeyUp += mainForm_KeyUp;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem shapesToolStripMenuItem;
        private ToolStripMenuItem squareToolStripMenuItem;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem circleToolStripMenuItem;
        private ToolStripMenuItem ellipseToolStripMenuItem;
        private ToolStripMenuItem triangleToolStripMenuItem;
        private ToolStripMenuItem sectionToolStripMenuItem;
        private ToolStripMenuItem changeColorToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem groupToolStripMenuItem;
        private ToolStripMenuItem ungroupToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private PictureBox pictureBox;
        private SaveFileDialog saveFileDialog;
        private ColorDialog colorDialog;
    }
}