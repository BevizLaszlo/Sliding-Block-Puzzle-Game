using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace NumberMatrixGame
{
    public partial class Main : Form
    {
        enum Direction { Top, Right, Bottom, Left }
        Direction currentTurn;
        Random rnd = new Random();
        int[,] numMatrix = new int[5,5];
        int turns = 0;

        private void InitializeNumMatrix()
        {
            do
            {
                List<int> numsUsed = new List<int>();
                for (int i = 1; i < numMatrix.GetLength(0) - 1; i++)
                    for (int j = 1; j < numMatrix.GetLength(1) - 1; j++)
                    {
                        int num;
                        do
                        {
                            num = rnd.Next((numMatrix.GetLength(0) - 2) * (numMatrix.GetLength(1) - 2));
                        } while (numsUsed.Contains(num));

                        numMatrix[i, j] = num;
                        numsUsed.Add(num);
                    }
            } while (!IsPuzzleSolveable());
        }

        private void ButtonsRender()
        {
            for (int i = 0; i < numMatrix.GetLength(0); i++)
                for (int j = 0; j < numMatrix.GetLength(1); j++)
                    if (numMatrix[i, j] != 0)
                    {

                        Button btn = new Button()
                        {
                            Text = numMatrix[i, j].ToString(),
                            Width = 100,
                            Height = 100,
                            Top = (i - 1) * 100,
                            Left = (j - 1) * 100,
                            Tag = $"{i}{j}",
                            BackColor = Color.White,
                        };
                        btn.Click += Btn_Click;
                        GamePanel.Controls.Add(btn);
                    }
        }

        public Main()
        {
            InitializeComponent();
            InitializeNumMatrix();
            ButtonsRender();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button thisBtn = (Button)sender;
            string coordinates = (string)thisBtn.Tag;
            int x = int.Parse(coordinates[0].ToString());
            int y = int.Parse(coordinates[1].ToString());

            if (IsThereEmptySquare(x, y))
            {
                turnsLabel.Text = $"Turns: {++turns}";

                AnimateButton(thisBtn, currentTurn);
                int[] newPlace = new int[2];

                switch (currentTurn)
                {
                    case Direction.Top:
                        thisBtn.Tag = $"{x - 1}{y}";
                        newPlace = new int[] { x - 1, y };
                        break;
                    case Direction.Right:
                        thisBtn.Tag = $"{x}{y + 1}";
                        newPlace = new int[] { x, y + 1 };
                        break;
                    case Direction.Bottom:
                        thisBtn.Tag = $"{x + 1}{y}";
                        newPlace = new int[] { x + 1, y };
                        break;
                    case Direction.Left:
                        thisBtn.Tag = $"{x}{y - 1}";
                        newPlace = new int[] { x, y - 1 };
                        break;
                    default:
                        break;
                }

                int temp = numMatrix[x, y];
                numMatrix[x, y] = 0;
                numMatrix[newPlace[0], newPlace[1]] = temp;

                if (CheckForWin())
                {
                    winLabel.Visible = true;
                    foreach (Button btn in GamePanel.Controls)
                        btn.Click -= Btn_Click;
                }
            }
        }

        private void AnimateButton(Button btn, Direction d)
        {
            for(int i = 0; i < 10; i++)
            {
                switch (d)
                {
                    case Direction.Top:
                        btn.Top -= 10;
                        break;
                    case Direction.Right:
                        btn.Left += 10;
                        break;
                    case Direction.Bottom:
                        btn.Top += 10;
                        break;
                    case Direction.Left:
                        btn.Left -= 10;
                        break;
                    default:
                        break;
                }
                Thread.Sleep(3);
            }
        }

        private bool IsThereEmptySquare(int x, int y)
        {
            if (numMatrix[x - 1, y] == 0 && x - 1 > 0)
            {
                currentTurn = Direction.Top;
                return true;
            }
            if (numMatrix[x + 1, y] == 0 && x + 1 < numMatrix.GetLength(0) - 1)
            {
                currentTurn = Direction.Bottom;
                return true;
            }
            if (numMatrix[x, y - 1] == 0 && y - 1 > 0)
            {
                currentTurn = Direction.Left;
                return true;
            }
            if (numMatrix[x, y + 1] == 0 && y + 1 < numMatrix.GetLength(1) - 1)
            {
                currentTurn = Direction.Right;
                return true;
            }
            return false;
        }

        private bool CheckForWin()
        {
            int checker = 1;

            for (int i = 1; i < numMatrix.GetLength(0) - 1; i++)
                for (int j = 1; j < numMatrix.GetLength(1) - 1; j++)
                {
                    if ((i != numMatrix.GetLength(0) - 2 || j != numMatrix.GetLength(1) - 2) && numMatrix[i, j] != checker) return false;
                    checker++;
                }

            return true;
        }

        private bool IsPuzzleSolveable()
        {
            int inversion = 0;
            int[] numArray = new int[(numMatrix.GetLength(0) - 2) * (numMatrix.GetLength(1) - 2) - 1];
            int current = 0;

            for (int i = 1; i < numMatrix.GetLength(0) - 1; i++)
                for (int j = 1; j < numMatrix.GetLength(1) - 1; j++)
                    if (numMatrix[i, j] != 0) numArray[current++] = numMatrix[i, j];

            for (int i = 0; i < numArray.Length - 1; i++)
                for (int j = i + 1; j < numArray.Length; j++)
                    if (numArray[i] > numArray[j]) inversion++;

            return inversion % 2 == 0;
        }

        private void reshuffleBtn_Click(object sender, EventArgs e)
        {
            turns = 0;
            turnsLabel.Text = $"Turns: {turns}";
            GamePanel.Controls.Clear();
            winLabel.Visible = false;
            InitializeNumMatrix();
            ButtonsRender();
        }
    }
}
