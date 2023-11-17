using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberMatrixGame
{
    public partial class Main : Form
    {
        enum Direction { Top, Right, Bottom, Left }
        Random rnd = new Random();
        int[,] numMatrix = new int[5, 5];

        private void InitializeNumMatrix()
        {
            for (int i = 1; i <= 3; i++)
                for (int j = 1; j <= 3; j++)
                {
                    numMatrix[i, j] = 5;
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
                            Tag = new int[i, j]
                        };
                        btn.Click += Btn_Click;
                        GamePanel.Controls.Add(btn);
                    }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button thisBtn = (Button)sender;
            if (true)
            {
                AnimateButton(thisBtn, Direction.Bottom);
            }
        }

        public Main()
        {
            InitializeComponent();
            InitializeNumMatrix();
            ButtonsRender();
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

        private void IsThereEmptySquare(int x, int y)
        {

            if (numMatrix[x - 1, y] == 0 && x - 1 > 0) return true;
        }
    }
}
