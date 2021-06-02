using System;
using System.Drawing;
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
        private Label[] _lboard = new Label[0];
        private int _width = 10;
        private int _height = 10;
        private int _mines = 10;// This is where I state what variables equal - Example. x = 2;
        private Random _myHat = new Random();
        private bool _gameFinished = false;
        private object BoardLock = new object();
        double timeEllapsed = 0;
        Color highLightColor = Color.Yellow;
        Color unrevealedBackColor = Color.Gray;
        Color revealedBackColor = Color.LightGray;
        Color questionMarkColor = Color.Purple;
        private enum TileValue
        {
            Empty,
            Bomb,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Win
        }

        /// <summary>
        /// This is used only in the GettileValue method to assist in abstracting specifics of how values are stored / displayed to users.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private TileValue ConvertToEnum(in string s)
        {
            TileValue t = TileValue.Empty;
            switch (s)
            {
                case ("  "):
                    {
                        t = TileValue.Empty;
                        break;
                    }
                case ("B"):
                    {
                        t = TileValue.Bomb;
                        break;
                    }
                case ("1"):
                    {
                        t = TileValue.One;
                        break;
                    }
                case ("2"):
                    {
                        t = TileValue.Two;
                        break;
                    }
                case ("3"):
                    {
                        t = TileValue.Three;
                        break;
                    }
                case ("4"):
                    {
                        t = TileValue.Four;
                        break;
                    }
                case ("5"):
                    {
                        t = TileValue.Five;
                        break;
                    }
                case ("6"):
                    {
                        t = TileValue.Six;
                        break;
                    }
                case ("7"):
                    {
                        t = TileValue.Seven;
                        break;
                    }
                case ("8"):
                    {
                        t = TileValue.Eight;
                        break;
                    }
                case ("W"):
                    {
                        t = TileValue.Win;
                        break;
                    }
                default:
                    break;
            }
            return t;
        }
        /// <summary>
        /// This is used only in the SettileValue method to assist in abstracting specifics of how values are stored / displayed to users.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private string ConvertFromEnum(in TileValue t)
        {
            string s = "  ";
            switch (t)
            {
                case (TileValue.Empty):
                    {
                        s = "  ";
                        break;
                    }
                case (TileValue.Bomb):
                    {
                        s = "B";
                        break;
                    }
                case (TileValue.One):
                    {
                        s = "1";
                        break;
                    }
                case (TileValue.Two):
                    {
                        s = "2";
                        break;
                    }
                case (TileValue.Three):
                    {
                        s = "3";
                        break;
                    }
                case (TileValue.Four):
                    {
                        s = "4";
                        break;
                    }
                case (TileValue.Five):
                    {
                        s = "5";
                        break;
                    }
                case (TileValue.Six):
                    {
                        s = "6";
                        break;
                    }
                case (TileValue.Seven):
                    {
                        s = "7";
                        break;
                    }
                case (TileValue.Eight):
                    {
                        s = "8";
                        break;
                    }
                case (TileValue.Win):
                    {
                        s = "W";
                        break;
                    }
                default:
                    break;
            }
            return s;
        }

        /// <summary>
        /// Help abstract UI.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private TileValue GetTileValue(in int index)
        {
            return ConvertToEnum(_lboard[index].Text);
        }
        /// <summary>
        /// help abstract ui.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void SetTileValue(in int index, in TileValue value)
        {
            _lboard[index].Text = ConvertFromEnum(value);
        }
        private void SetTileBackcolor(in int index, in Color c)
        {
            _lboard[index].BackColor = c;
        }
        private void SetTileForecolor(in int index, in Color c)
        {
            _lboard[index].ForeColor = c;
        }
        private bool IsTileRevealed(in int index)
        {
            return (_lboard[index].BackColor != unrevealedBackColor && !IsTileHighLighted(index) && !IsTileQuestioned(index));
        }
        private bool IsTileHighLighted(in int index)
        {
            return (_lboard[index].BackColor == highLightColor);
        }
        private bool IsTileQuestioned(in int index)
        {
            return (_lboard[index].BackColor == questionMarkColor);
        }
        private void ResizeWindow()
        {
            int minWResise = 16;
            int minHResize = 2;

            this.MaximumSize = new Size((_width > minWResise) ? _width * 16 + 35 : minWResise * 16 + 35, _height > minHResize ? _height * 16 + 98 : minHResize * 16 + 98);

            this.MinimumSize = this.MaximumSize;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lock (BoardLock)
            {
                ResizeWindow();
                Build();
                Assign();
                timer1.Enabled = true;
            }
        }
        private void UpdateTileColors(int index)
        {
            if (GetTileValue(index) == TileValue.Bomb)
            {
                SetTileForecolor(index, Color.Black);
                SetTileBackcolor(index, Color.Red);
            }
            else
            {
                SetTileBackcolor(index, revealedBackColor);

                if (GetTileValue(index) == TileValue.One)
                {
                    SetTileForecolor(index, Color.Blue);
                }
                else if (GetTileValue(index) == TileValue.Two)
                {
                    SetTileForecolor(index, Color.Green);
                }
                else if (GetTileValue(index) == TileValue.Three)
                {
                    SetTileForecolor(index, Color.Red);
                }
                else if (GetTileValue(index) == TileValue.Four)
                {
                    SetTileForecolor(index, Color.Purple);
                }
                else if (GetTileValue(index) == TileValue.Five)
                {
                    SetTileForecolor(index, Color.Yellow);
                }
                else if (GetTileValue(index) == TileValue.Six)
                {
                    SetTileForecolor(index, Color.Orange);
                }
                else if (GetTileValue(index) == TileValue.Seven)
                {
                    SetTileForecolor(index, Color.Black);
                }
                else if (GetTileValue(index) == TileValue.Eight)
                {
                    SetTileForecolor(index, Color.White);
                }
            }
        }
        private void BombCheck(in int index)
        {
            if (!_gameFinished)
            {
                UpdateTileColors(index);
                if (GetTileValue(index) == TileValue.Bomb)
                {
                    _gameFinished = true;
                    timer1.Enabled = false;
                }
            }
        }
        /// <summary>
        /// This section randomly sets up the game. Puts bombs in appropriate locations
        /// </summary>
        public void Assign()
        {
            int rand = 0;
            int bombsPlaced = 0;
            for (int i = 0; i < _height * _width; i++)//set all values to empty
            {
                SetTileValue(i, TileValue.Empty);
            }
            do//set random tiles to be bombs
            {
                rand = _myHat.Next(0, _width * _height);
                if (GetTileValue(rand) == TileValue.Empty)
                {
                    SetTileValue(rand, TileValue.Bomb);
                    bombsPlaced++;
                }
            }
            while (bombsPlaced < _mines);
            for (int i = 0, adjacentBombs = 0; i < _height * _width; i++, adjacentBombs = 0)
            {
                if (GetTileValue(i) != TileValue.Bomb)
                {
                    if (i >= _width)//up 3
                    {
                        if (i % _width != 0 && GetTileValue(i - 1 - _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                        if (GetTileValue(i - _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                        if ((i + 1) % _width != 0 && GetTileValue(i + 1 - _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                    }
                    if ((i + 1) % _width != 0 && GetTileValue(i + 1) == TileValue.Bomb)
                    {
                        adjacentBombs++;
                    }
                    if (i < _width * (_height - 1))//bottom 3
                    {
                        if (i % _width != 0 && GetTileValue(i - 1 + _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                        if (GetTileValue(i + _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                        if ((i + 1) % _width != 0 && GetTileValue(i + 1 + _width) == TileValue.Bomb)
                        {
                            adjacentBombs++;
                        }
                    }
                    if (i % _width != 0 && GetTileValue(i - 1) == TileValue.Bomb)//left
                    {
                        adjacentBombs++;
                    }
                    if (adjacentBombs != 0)
                    {
                        SetTileValue(i, ConvertToEnum(Convert.ToString(adjacentBombs)));
                    }
                }
            }
        }
        /// <summary>
        /// This section makes the grid for the game
        /// </summary>
        public void Build()
        {
            int oldBoardLength = _lboard.Length;
            #region Remove unneded tiles
            for (int i = _width * _height; i < oldBoardLength; i++)
            {
                Controls.Remove(_lboard[i]);
            }
            #endregion

            Array.Resize(ref _lboard, _width * _height);
            ResizeWindow();

            #region Reset Old Tiles
            for (int i = 0; i < oldBoardLength && i < _lboard.Length; i++)
            {
                if (i != 0)
                {
                    if (i % _width != 0)
                    {
                        _lboard[i].Left = _lboard[i - 1].Right + 1;
                        _lboard[i].Top = _lboard[i - 1].Top;
                    }
                    else
                    {
                        _lboard[i].Left = _lboard[i - _width].Left;
                        _lboard[i].Top = _lboard[i - _width].Bottom + 1;
                    }
                }
                _lboard[i].ForeColor = unrevealedBackColor;
                _lboard[i].BackColor = unrevealedBackColor;
            }
            #endregion
            #region Add New Tiles
            for (int i = oldBoardLength; i < _lboard.Length; i++)
            {
                _lboard[i] = new Label();
                if (i == 0)
                {
                    _lboard[i].Height = 15;
                    _lboard[i].Width = 15;
                    _lboard[i].Left = 10;//width * height/2;//Convert.ToInt16(this.Width - (this.Width / 1.1));
                    _lboard[i].Top = 50;
                }
                if (i != 0)
                {
                    if (i % _width != 0)
                    {
                        _lboard[i].Left = _lboard[i - 1].Right + 1;
                        _lboard[i].Top = _lboard[i - 1].Top;
                    }
                    else
                    {
                        _lboard[i].Left = _lboard[i - _width].Left;
                        _lboard[i].Top = _lboard[i - _width].Bottom + 1;
                    }
                    _lboard[i].Width = _lboard[i - 1].Width;
                    _lboard[i].Height = _lboard[i - 1].Height;
                }
                _lboard[i].Font = new Font("Ariel Black", 8, FontStyle.Bold);
                _lboard[i].AutoSize = false;
                Controls.Add(_lboard[i]);
                _lboard[i].BringToFront();
                _lboard[i].Tag = i;
                _lboard[i].Click += new EventHandler(Form1_Click);
                _lboard[i].Visible = true;
                _lboard[i].ForeColor = unrevealedBackColor;
                _lboard[i].BackColor = unrevealedBackColor;
            }
            #endregion
            #region User Control Setup
            //lreset.BringToFront();
            //tbwidth.BringToFront();
            //tbheight.BringToFront();
            //tbmines.BringToFront();
            //linfo.BringToFront();
            l_TimeEllapsed.Text = "0";
            timeEllapsed = 0;
            #endregion
        }
        void Form1_Click(object sender, EventArgs e)// This section runs when you click a square
        {
            lock (BoardLock)
            {
                this.ActiveControl = null;
                if (!_gameFinished)
                {
                    int index = Convert.ToInt16(((Label)sender).Tag);
                    MouseEventArgs me = (MouseEventArgs)e;
                    if (me.Button == MouseButtons.Right && !IsTileRevealed(index))
                    {
                        SetTileForecolor(index, (IsTileHighLighted(index)) ? questionMarkColor : (IsTileQuestioned(index)) ? unrevealedBackColor :  highLightColor);
                        SetTileBackcolor(index, (IsTileHighLighted(index)) ? questionMarkColor : (IsTileQuestioned(index)) ? unrevealedBackColor : highLightColor);
                    }
                    else if (me.Button == MouseButtons.Left)
                    {
                        BombCheck(index);
                        if (!_gameFinished)
                        {
                            if (GetTileValue(index) == TileValue.Empty)
                            {
                                bool continueRevealing = false;
                                //could add minTileRevealed variable to make the performance better possibly.
                                do
                                {
                                    continueRevealing = false;
                                    for (int i = 0; i < _lboard.Length; i++)
                                    {
                                        if (GetTileValue(i) == TileValue.Empty && IsTileRevealed(i))
                                        {
                                            if (i >= _width)//up 3
                                            {
                                                if (i % _width != 0 && !IsTileRevealed(i - 1 - _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i - _width - 1);
                                                }
                                                if (!IsTileRevealed(i - _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i - _width);
                                                }
                                                if ((i + 1) % _width != 0 && i != _width * _height - 1 && !IsTileRevealed(i + 1 - _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i + 1 - _width);
                                                }
                                            }
                                            if ((i + 1) % _width != 0 && !IsTileRevealed(i + 1))//right
                                            {
                                                continueRevealing = true;
                                                BombCheck(i + 1);
                                            }
                                            if (i < _width * (_height - 1))//down 3
                                            {
                                                if (i % _width != 0 && !IsTileRevealed(i - 1 + _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i - 1 + _width);
                                                }
                                                if (!IsTileRevealed(i + _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i + _width);
                                                }
                                                if ((i + 1) % _width != 0 && !IsTileRevealed(i + 1 + _width))
                                                {
                                                    continueRevealing = true;
                                                    BombCheck(i + 1 + _width);
                                                }
                                            }
                                            if (i % _width != 0 && !IsTileRevealed(i - 1))//left
                                            {
                                                continueRevealing = true;
                                                BombCheck(i - 1);
                                            }
                                        }
                                    }
                                } while (continueRevealing);
                            }
                            int tilesRevealed = 0;
                            for (int i = 0; i < _width * _height; i++)
                            {
                                if (IsTileRevealed(i))
                                {
                                    tilesRevealed++;
                                }
                            }
                            if (tilesRevealed == (_height * _width) - _mines)
                            {
                                for (int i = 0; i < _width * _height; i++)
                                {
                                    if (IsTileRevealed(i))
                                    {
                                        SetTileValue(i, TileValue.Win);
                                        SetTileForecolor(i, Color.Blue);
                                    }
                                    else
                                    {
                                        SetTileForecolor(i, Color.Black);
                                        SetTileBackcolor(i, revealedBackColor);
                                    }
                                }
                                _gameFinished = true;
                                timer1.Enabled = false;
                            }
                        }
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
            lock (BoardLock)
            {
                int h = 0;
                int w = 0;
                int m = 0;
                int.TryParse(tbheight.Text, out h);
                int.TryParse(tbwidth.Text, out w);
                int.TryParse(tbmines.Text, out m);
                if (ResetIsValid(h, w, m, out string errorMessage))
                {
                    timer1.Enabled = false;
                    _height = h;
                    _width = w;
                    _mines = m;
                    _gameFinished = false;
                    Build();
                    Assign();
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show(errorMessage, "Invalid Input!");
                }
            }
        }

        private const int maxTileCount = 2000;
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
            int minTileCount = 2;

            if (h * w < minTileCount)
            {
                errorMessage = $"There must be at least {minTileCount} tiles in the grid.";
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
            sb.AppendLine($"The maximum size of the board is {maxTileCount} tiles.");
            sb.AppendLine();
            sb.AppendLine("Good Luck!");
            MessageBox.Show(sb.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeEllapsed += .1;// Math.Round(timeEllapsed + .1, 1);
            l_TimeEllapsed.Text = string.Format("{0:0.0}", timeEllapsed);
        }
    }
}
