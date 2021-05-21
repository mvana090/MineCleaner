using System;
using System.Collections.Generic;
using System.ComponentModel;   // This top section is always in code
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Label[] lboard = new Label[0];
        private int _width = 10;
        private int _height = 10;
        private int _mines = 10;// This is where I state what variables equal - Example. x = 2;
        private Random myHat = new Random();
        private bool gameFinished = false;
        public const string emptyTileText = "  ";
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(700, 800); //100 * width;
            this.MinimumSize = new Size(700, 800);
            build();
            assign();
        }
        private void UpdateTileColors(int index)
        {
            lboard[index].BackColor = Color.LightGray;
            if (lboard[index].Text == "1")
            {
                lboard[index].ForeColor = Color.Blue;
            }
            if (lboard[index].Text == "2")
            {
                lboard[index].ForeColor = Color.Green;
            }
            if (lboard[index].Text == "3")
            {
                lboard[index].ForeColor = Color.Red;
            }
            if (lboard[index].Text == "4")
            {
                lboard[index].ForeColor = Color.Purple;
            }
            if (lboard[index].Text == "5")
            {
                lboard[index].ForeColor = Color.Yellow;
            }
            if (lboard[index].Text == "6")
            {
                lboard[index].ForeColor = Color.Orange;
            }
            if (lboard[index].Text == "7")
            {
                lboard[index].ForeColor = Color.Black;
            }
            if (lboard[index].Text == "8")
            {
                lboard[index].ForeColor = Color.White;
            }
            if (lboard[index].Text == "B")
            {
                lboard[index].ForeColor = Color.Black;
                lboard[index].BackColor = Color.Red;
            }
        }
        private void bombcheck(int index)
        {
            if (!gameFinished)
            {
                UpdateTileColors(index);
                if (lboard[index].Text == "B")
                {
                    gameFinished = true;
                }
            }
        }
        public void assign()// This section randomly sets up the game. Puts bombs in appropriate locations
        {
            int rand = 0;
            int temp = 0;
            try
            {
                temp = 0;
                for (int i = 0; i < _height * _width; i++)
                {
                    lboard[i].Text = emptyTileText;
                }
                while (true)
                {
                    rand = myHat.Next(0, _width * _height);
                    if (lboard[rand].Text == emptyTileText)
                    {
                        lboard[rand].Text = "B";
                        temp++;
                    }
                    if (temp >= _mines)
                    {
                        break;
                    }
                }
                for (int i = 0; i < _height * _width; i++)
                {
                    temp = 0;
                    if (lboard[i].Text != "B")
                    {
                        if (i >= _width)//up 3
                        {
                            if (i % _width != 0)
                            {
                                if (lboard[i - 1 - _width].Text == "B")
                                {
                                    temp++;
                                }
                            }
                            if (lboard[i - _width].Text == "B")
                            {
                                temp++;
                            }
                            if ((i + 1) % _width != 0 && i != _width * _height - 1)
                            {
                                if (lboard[i + 1 - _width].Text == "B")
                                {
                                    temp++;
                                }
                            }
                        }
                        if (i != _height * _width - 1)
                        {
                            if ((i + 1) % _width != 0)//right
                            {
                                if (lboard[i + 1].Text == "B")
                                {
                                    temp++;
                                }
                            }
                        }
                        if (i < _height * _width - _width)//added -1//<=?//down 3
                        {
                            if (i % _width != 0)//i != 0 safety
                            {
                                if (lboard[i - 1 + _width].Text == "B")
                                {
                                    temp++;
                                }
                            }
                            if (lboard[i + _width].Text == "B")
                            {
                                temp++;
                            }
                            if ((i + 1) % _width != 0)//fix
                            {
                                if (lboard[i + 1 + _width].Text == "B")
                                {
                                    temp++;
                                }
                            }
                        }
                        if (i % _width != 0 && i - 1 >= 0)//left
                        {
                            if (lboard[i - 1].Text == "B")
                            {
                                temp++;
                            }
                        }
                        if (temp != 0)
                        {
                            lboard[i].Text = Convert.ToString(temp);
                        }
                    }
                }
                temp = 0;
            }
            catch
            {
                MessageBox.Show("!An error has occured!");
            }
        }
        public void build()// This section makes the grid for the game
        {
            try
            {
                gameFinished = false;
                Array.Resize(ref lboard, 0);
                Array.Resize(ref lboard, _width * _height);
                //if (lboard.Length > 1)
                //{
                //    for (int i = 0; i < lboard.Length && i < ; i++)
                //    {
                //        lboard[i].Visible = false;
                //    }
                //}
                this.MaximumSize = new Size(_width * 15 + _width + 40, _height * 15 + 100 + _height);
                this.MinimumSize = new Size(_width * 15 + _width + 40, _height * 15 + 100 + _height);
                for (int i = 0; i < lboard.Length; i++)
                {
                    int index = i;
                    lboard[i] = new Label();
                    if (i == 0)
                    {
                        lboard[i].Height = 15;
                        lboard[i].Width = 15;
                        lboard[i].Left = 50 / 5;//width * height/2;//Convert.ToInt16(this.Width - (this.Width / 1.1));
                        lboard[i].Top = 50;
                    }
                    if (i != 0)
                    {
                        lboard[i].Left = lboard[i - 1].Right + 1;
                        lboard[i].Top = lboard[i - 1].Top;
                        lboard[i].Width = lboard[i - 1].Width;
                        lboard[i].Height = lboard[i - 1].Height;
                    }
                    if (i % _width == 0 && i != 0)
                    {
                        lboard[i].Left = lboard[i - _width].Left;
                        lboard[i].Top = lboard[i - _width].Bottom + 1;
                    }
                    lboard[i].Font = new Font("Ariel Black", 8, FontStyle.Bold);
                    lboard[i].BackColor = Color.Gray;
                    lboard[i].AutoSize = false;
                    Controls.Add(lboard[i]);
                    lboard[i].BringToFront();
                    lboard[i].Tag = i;
                    lboard[i].Click += new EventHandler(Form1_Click);
                    lboard[i].Text = "0";
                    lboard[i].Visible = true;
                    lboard[i].ForeColor = Color.Gray;//gray
                    lboard[i].BackColor = Color.Gray;
                }
                tbnull.Left = -100;
                tbnull.Top = -100;
                lreset.Left = 0;//lboard[0].Left;
                lreset.Top = 0;//this.Top + 10;
                lreset.AutoSize = true;
                lreset.BringToFront();
                tbwidth.Left = lreset.Right + 1;
                tbwidth.Top = lreset.Top;
                tbwidth.Width = Convert.ToInt16((this.Width - lreset.Width) / 3);
                tbwidth.BringToFront();
                tbheight.Left = tbwidth.Right + 1;
                tbheight.Top = tbwidth.Top;
                tbheight.Width = tbwidth.Width;
                tbheight.BringToFront();
                tbmines.Left = tbheight.Right + 1;
                tbmines.Top = tbheight.Top;
                tbmines.Width = this.Width - tbheight.Right - 20;
                tbmines.BringToFront();
                linfo.Left = lreset.Left;
                linfo.Top = lreset.Bottom;
                linfo.BringToFront();
            }
            catch
            {
                MessageBox.Show("!There was a build error!");
            }
        }
        void Form1_Click(object sender, EventArgs e)// This section runs when you click a square
        {
            this.ActiveControl = null;
            Label p = (Label)sender;
            int index = Convert.ToInt16(p.Tag);
            int temp = 0;
            index++;
            if (!gameFinished)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    temp = 0;
                    if (lboard[index - 1].BackColor == Color.Gray)
                    {
                        lboard[index - 1].BackColor = Color.Yellow;
                        lboard[index - 1].ForeColor = Color.Yellow;
                        temp++;
                    }

                    if (temp != 1 && lboard[index - 1].BackColor == Color.Yellow)
                    {
                        lboard[index - 1].BackColor = Color.Gray;
                        lboard[index - 1].ForeColor = Color.Gray;
                    }
                }
                if (me.Button == MouseButtons.Left)
                {
                    if (lboard[index - 1].Text == emptyTileText)
                    {
                        bool continueRevealing = false;
                        do
                        {
                            continueRevealing = false;
                            for (int i = 0; i < lboard.Length; i++)
                            {
                                if (lboard[i].Text == emptyTileText && (lboard[i].BackColor == Color.LightGray || i == index - 1))
                                {
                                    if (i >= _width)//up 3
                                    {
                                        if (i % _width != 0)
                                        {
                                            if (lboard[i - 1 - _width].BackColor != Color.LightGray)
                                            {
                                                continueRevealing = true;
                                                bombcheck(i - _width - 1);
                                            }
                                        }
                                        if (lboard[i - _width].BackColor != Color.LightGray)
                                        {
                                            continueRevealing = true;
                                            bombcheck(i - _width);
                                        }
                                        if ((i + 1) % _width != 0 && i != _width * _height - 1)
                                        {
                                            if (lboard[i + 1 - _width].BackColor != Color.LightGray)
                                            {
                                                continueRevealing = true;
                                                bombcheck(i + 1 - _width);
                                            }
                                        }
                                    }
                                    if (i != _height * _width - 1)
                                    {
                                        if ((i + 1) % _width != 0)//right
                                        {
                                            if (lboard[i + 1].BackColor != Color.LightGray)
                                            {
                                                continueRevealing = true;
                                                bombcheck(i + 1);
                                            }
                                        }
                                    }
                                    if (i < _height * _width - _width)//added -1//<=?//down 3
                                    {
                                        if (i % _width != 0)//i != 0 safety
                                        {
                                            if (lboard[i - 1 + _width].BackColor != Color.LightGray)
                                            {
                                                continueRevealing = true;
                                                bombcheck(i - 1 + _width);
                                            }
                                        }
                                        if (lboard[i + _width].BackColor != Color.LightGray)
                                        {
                                            continueRevealing = true;
                                            bombcheck(i + _width);
                                        }
                                        if ((i + 1) % _width != 0)//fix
                                        {
                                            if (lboard[i + 1 + _width].BackColor != Color.LightGray)
                                            {
                                                continueRevealing = true;
                                                bombcheck(i + 1 + _width);
                                            }
                                        }
                                    }
                                    if (i % _width != 0 && i - 1 >= 0)//left
                                    {
                                        if (lboard[i - 1].BackColor != Color.LightGray)
                                        {
                                            continueRevealing = true;
                                            bombcheck(i - 1);
                                        }
                                    }
                                }
                            }
                        } while (continueRevealing);
                    }
                    bombcheck(index - 1);
                    temp = 0;
                    for (int i = 0; i < _width * _height; i++)
                    {
                        if (lboard[i].BackColor == Color.LightGray)
                        {
                            temp++;
                        }
                    }
                    if (temp == (_height * _width) - _mines)
                    {
                        for (int i = 0; i < _width * _height; i++)
                        {
                            if (lboard[i].BackColor == Color.LightGray)
                            {
                                lboard[i].Text = "W";
                                lboard[i].ForeColor = Color.Blue;
                            }
                            if (lboard[i].BackColor != Color.LightGray)
                            {
                                lboard[i].ForeColor = Color.Black;
                                lboard[i].BackColor = Color.LightGray;
                            }
                        }
                        gameFinished = true;
                    }
                }
            }
        }

        /// <summary>
        /// This is to reset the board by regenerating all the bombs, the board using the width. height, and number of bombs specified.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lreset_Click(object sender, EventArgs e)
        {
            int h = 0;
            int w = 0;
            int m = 0;
            int.TryParse(tbheight.Text, out h);
            int.TryParse(tbwidth.Text, out w);
            int.TryParse(tbmines.Text, out m);
            if (ResetIsValid(h, w, m, out string errorMessage))
            {
                _height = h;
                _width = w;
                _mines = m;
                build();
                assign();
            }
            else
            {
                MessageBox.Show(errorMessage, "Invalid Input!");
            }
        }

        /// <summary>
        /// Determines if it si ok to reset with th einput provided by the user.
        /// </summary>
        /// <param name="h">Height</param>
        /// <param name="w">Width</param>
        /// <param name="m">Mines</param>
        /// <param name="errorMessage">If invalid, this will probably be a non empty string to display to the used.</param>
        /// <returns>Whether valid user input.</returns>
        private bool ResetIsValid(in int h, in int w, in int m, out string errorMessage)
        {
            bool isValid = false;
            errorMessage = string.Empty;
            int maxTileCount = 781;

            if (h * w < 2)
            {
                errorMessage = "There must be at least 2 tiles in the grid.";
            }
            else if ((h * w) - m < 1)
            {
                errorMessage = $"Too many Mines (max of {Convert.ToString((w * h) - 1)}).";
            }
            else if (h * w > maxTileCount)
            {
                errorMessage = $"To big of width / height for current load times.\nInput:({Convert.ToString(w * h)}) vs CurrentMax({maxTileCount}).";
            }
            else if (m < 1)
            {
                errorMessage = "There must be at least one mine.";
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// This appears when the question mark is clicked. It is the rules of the game to read.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Minecleaner is a similar game to mine sweeper where you search for bombs.");
            sb.AppendLine("The numbers correspond to how many bombs are touching it if any.");
            sb.AppendLine("A blank spot equals 0.");
            sb.AppendLine("One wins by revealing all of the tiles that are not bombs (B's).");
            sb.AppendLine("A right click toggles a flag to help remember where bombs may be.");
            sb.AppendLine("Lastly press reset to restart the game with the same bounds or different.");
            sb.AppendLine("The first text box is for the width, the second for height, and the third for the number of Bombs.");
            sb.AppendLine("The maximum size of the board is 781 squares ~(28 x 27).");
            sb.AppendLine();
            sb.AppendLine("Good Luck!");
            MessageBox.Show(sb.ToString());
        }
    }
}
