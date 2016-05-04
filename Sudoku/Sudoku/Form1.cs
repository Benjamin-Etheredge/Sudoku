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

        private bool gotHint = false;

        public Form1()
        {
            game = new Sudoku(0);
            InitializeComponent_withGridCoordinates();
        }

        /// <summary>
        /// Setup form and reveal pre-locked values
        /// </summary>
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
            restartToolStripMenuItem = new ToolStripMenuItem();
            label5 = new Label();
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
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(trackBar1);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(radioButton2);
            splitContainer1.Panel2.Controls.Add(radioButton1);
            splitContainer1.Size = new Size(215, 345);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 1;
            //
            // boxes
            //
            int xCoord = 30;
            for (int x = 0; x < 9; x++)
            {
                int yCoord = 14;
                for (int y = 0; y < 9; y++)
                {
                    boxes[x, y].Location = new Point(yCoord, xCoord);
                    boxes[x, y].Mask = "0";
                    boxes[x, y].Name = "maskedTextBox9";
                    boxes[x, y].Size = new Size(20, 20);
                    boxes[x, y].TabIndex = 97;
                    if (game.playerBoard[x, y] < 0)
                    {
                        boxes[x, y].Enabled = false;
                        boxes[x, y].Text = (-1 * game.playerBoard[x, y]).ToString();
                    }
                    boxes[x, y].TextChanged += new EventHandler(maskedTextBox_TextChanged);
                    yCoord += 20;
                    if ((y + 1) % 3 == 0) { yCoord += 3; }
                }
                xCoord += 20;
                if ((x + 1) % 3 == 0) { xCoord += 3; }
            }
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(39, 12);
            label5.Name = "label5";
            label5.Size = new Size(136, 13);
            label5.TabIndex = 2;
            label5.Text = "You solved the puzzle!";
            label5.Visible = false;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            restartToolStripMenuItem});
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(152, 22);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += new EventHandler(restartToolStripMenuItem_Click);
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
            trackBar1.Value = 0;
            trackBar1.Scroll += new EventHandler(trackBar1_ValueChanged);
            // 
            // button1
            // 
            button1.Location = new Point(127, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Hint";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(Hint_Click);
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
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 369);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Size = new Size(231, 428);
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

        /// <summary>
        /// Setup a new boxes[,] matrix when difficulty is changed
        /// </summary>
        private void reinitBoxes()
        {
            int xCoord = 30;
            for (int x = 0; x < 9; x++)
            {
                int yCoord = 14;
                for (int y = 0; y < 9; y++)
                {
                    boxes[x, y] = new MaskedTextBox();
                    splitContainer1.Panel1.Controls.Add(boxes[x, y]);
                    boxes[x, y].Location = new Point(yCoord, xCoord);
                    boxes[x, y].Mask = "0";
                    boxes[x, y].Name = "maskedTextBox9";
                    boxes[x, y].Size = new Size(20, 20);
                    boxes[x, y].TabIndex = 97;
                    if (game.playerBoard[x, y] < 0)
                    {
                        boxes[x, y].Enabled = false;
                        boxes[x, y].Text = (-1 * game.playerBoard[x, y]).ToString();
                    }
                    boxes[x, y].TextChanged += new EventHandler(maskedTextBox_TextChanged);
                    yCoord += 20;
                    if ((y + 1) % 3 == 0) { yCoord += 3; }
                }
                xCoord += 20;
                if ((x + 1) % 3 == 0) { xCoord += 3; }
            }
        }
        
        /// <summary>
        /// Refresh the boxes[,] matrix after getting a hint or changing the difficulty
        /// </summary>
        private void RefreshBoard()
        {
            for(int i=0; i<9; i++)
            {
                for (int j=0; j<9; j++)
                {
                    if(game.playerBoard[i,j] < 0)
                    {
                        boxes[i, j].BackColor = SystemColors.MenuBar;
                        boxes[i, j].Enabled = false;
                        boxes[i, j].Text = (game.playerBoard[i, j].Equals(0)) ? string.Empty : game.playerBoard[i, j].ToString();
                    }
                }
            }
            splitContainer1.Panel1.Refresh();
        }

        /// <summary>
        /// Insert a new value into the playerboard
        /// Clearing a box inserts a 0, and doesn't count as a move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!gotHint)
            {
                for (int i = 0; i < 9; i++)
                {
                    bool valueInserted = false;
                    for (int j = 0; j < 9; j++)
                    {
                        if (boxes[i, j].Equals((MaskedTextBox)sender))
                        {
                            int value = (boxes[i, j].Text == string.Empty) ? 0 : Convert.ToInt32(boxes[i, j].Text);
                            //Insert the value
                            valueInserted = game.MakeMove(value, i, j);

                            //If hints are on, show incorrect moves
                            if (showHints && !game.CheckSpot(i, j))
                            {
                                if (!value.Equals(0))
                                {
                                    boxes[i, j].BackColor = Color.OrangeRed;
                                }
                                else
                                {
                                    boxes[i, j].BackColor = Color.White;
                                }
                            }
                            break;
                        }
                    }
                    if (valueInserted) { break; }
                }
            }
                if (game.IsSolved())
            {
                label5.Visible = true;
                splitContainer1.Panel1.Refresh();
                //MessageBox.Show("You solved the puzzle!");
            }
        }

        /// <summary>
        /// Reveal and lock a correct value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hint_Click(object sender, EventArgs e)
        {
            gotHint = true;
            game.Help();
            RefreshBoard();
            gotHint = false;
        }

        /// <summary>
        /// Changing difficulties starts a new game with the new difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            newGame();
        }

        /// <summary>
        /// Start a new game with the same difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        /// <summary>
        /// start a new game with the given difficulty setting
        /// </summary>
        private void newGame()
        {
            game = new Sudoku(trackBar1.Value);
            boxes = new MaskedTextBox[9, 9];
            splitContainer1.Panel1.Controls.Clear();
            reinitBoxes();
            RefreshBoard();
        }

        /// <summary>
        /// Toggle realtime hints on/off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            showHints = !showHints;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //If hints are on, show incorrect moves
                    if (showHints && !game.CheckSpot(i, j))
                    {
                        int value = (boxes[i, j].Text == string.Empty) ? 0 : Convert.ToInt32(boxes[i, j].Text);

                        if (!value.Equals(0))
                        {
                            boxes[i, j].BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            boxes[i, j].BackColor = SystemColors.Window;
                        }
                    }
                    else
                    {
                        if (boxes[i, j].Enabled)
                        {
                            boxes[i, j].BackColor = SystemColors.Window;
                        }
                        else
                        {
                            boxes[i, j].BackColor = SystemColors.MenuBar;
                        }
                    }
                }
            }
        }
    }
}
