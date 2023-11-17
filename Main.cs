using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberMatrixGame
{
    public partial class Main : Form
    {
        enum Direction { Top, Right, Bottom, Left }
        Direction currentTurn;
        Random rnd = new Random();
        int[,] numMatrix = new int[5, 5];

        private void InitializeNumMatrix()
        {
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 1; i <= 3; i++)
                for (int j = 1; j <= 3; j++)
                {
                    if (i != 3 || j != 3)
                    {
                        int index = rnd.Next(nums.Count);
                        numMatrix[i, j] = nums[index];
                        nums.RemoveAt(index);
                    }
                }
            numMatrix[3, 3] = 0;
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
                    winLabel.Visible = true;
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
            if (numMatrix[x + 1, y] == 0 && x + 1 < 4)
            {
                currentTurn = Direction.Bottom;
                return true;
            }
            if (numMatrix[x, y - 1] == 0 && y - 1 > 0)
            {
                currentTurn = Direction.Left;
                return true;
            }
            if (numMatrix[x, y + 1] == 0 && y + 1 < 4)
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
                    if ((i != 3 || j != 3) && numMatrix[i, j] != checker) return false;
                    checker++;
                }

            return true;
        }
    }
}
