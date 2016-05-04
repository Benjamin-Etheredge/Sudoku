using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private MaskedTextBox[,] boxes = new MaskedTextBox[9,9];
        private bool showHints = false;

        private Sudoku game;

        public Form1()
        {
            game = new Sudoku(0);
            InitializeComponent_withGridCoordinates();
        }

        private void InitializeComponent_withGridCoordinates()
        {
            menuStrip1 = new MenuStrip();
            splitContainer1 = new SplitContainer();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    boxes[x, y] = new MaskedTextBox();
                }
            }
            gameToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            trackBar1 = new TrackBar();
            button1 = new Button();
            label1 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            menuStrip1.SuspendLayout();
            ((ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((ISupportInitialize)(trackBar1)).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] {
            gameToolStripMenuItem});
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(215, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.AppWorkspace;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    splitContainer1.Panel1.Controls.Add(boxes[x, y]);
                }
            }
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(trackBar1);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(radioButton2);
            splitContainer1.Panel2.Controls.Add(radioButton1);
            splitContainer1.Size = new Size(215, 345);
            splitContainer1.SplitterDistance = 209;
            splitContainer1.TabIndex = 1;
            //
            // boxes
            //
            int xCoord = 14;
            for (int x = 0; x < 9; x++)
            {
                int yCoord = 10;
                for (int y = 0; y < 9; y++)
                {
                    boxes[x, y].Location = new Point(yCoord, xCoord);
                    boxes[x, y].Mask = "0";
                    boxes[x, y].Name = "maskedTextBox9";
                    boxes[x, y].Size = new Size(20, 20);
                    boxes[x, y].TabIndex = 97;
                    //if(board[x,y] < 0)
                    //{
                    //    boxes[x, y].Text = board[x, y].ToString();
                    //}
                    boxes[x,y].TextChanged += new EventHandler(maskedTextBox_TextChanged);
                    yCoord += 20;
                    if ((y + 1) % 3 == 0) { yCoord += 3; }
                }
                xCoord += 20;
                if ((x + 1) % 3 == 0) { xCoord += 3; }
            }
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            newToolStripMenuItem,
            restartToolStripMenuItem});
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(152, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(152, 22);
            restartToolStripMenuItem.Text = "Restart";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 98);
            label4.Name = "label4";
            label4.Size = new Size(30, 13);
            label4.TabIndex = 15;
            label4.Text = "Hard";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 98);
            label3.Name = "label3";
            label3.Size = new Size(30, 13);
            label3.TabIndex = 14;
            label3.Text = "Easy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 67);
            label2.Name = "label2";
            label2.Size = new Size(47, 13);
            label2.TabIndex = 13;
            label2.Text = "Difficulty";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(57, 83);
            trackBar1.Maximum = 2;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(127, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Hint";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 5);
            label1.Name = "label1";
            label1.Size = new Size(49, 13);
            label1.TabIndex = 10;
            label1.Text = "Incorrect";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(16, 44);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(47, 17);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Hide";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(16, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(52, 17);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Show";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 369);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Sudoku";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            ((ISupportInitialize)(trackBar1)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        //When a value is inserted into the board
        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (boxes[i, j].Equals((MaskedTextBox)sender))
                    {
                        //set playerBoard[i,j] = input value;
                    }
                }
            }

            if (showHints)
            {
                for(int i=0; i<9; i++)
                {
                    bool foundSpot = false;
                    for(int j=0; j<9; j++)
                    {
                        if (boxes[i, j].Equals((MaskedTextBox)sender))
                        {
                            //if(!checkSpot(i, j))
                            //{
                            boxes[i, j].BackColor = Color.OrangeRed;
                            //}
                            foundSpot = true;
                            break;
                        }
                        if (foundSpot) { break; }
                    }
                }
            }
        }

        //Force reveal a correct value
        private void Hint_Click(object sender, EventArgs e)
        {
            //call backend random hint
            //disable revealed spot
            //call reload playre board
        }

        //changing difficulties starts a new game with the new difficulty
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            game = new Sudoku(trackBar1.Value);
            InitializeComponent_withGridCoordinates();
        }
    }
}
