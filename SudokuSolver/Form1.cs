using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        Board board;
        public Form1()
        {
            InitializeComponent();
            board = new Board();
            board.PopulateEmptyGrid(this.panelSudoku);
            textBoxTimeTaken.WordWrap = true;
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            board.PopulateGridFromString(inputTextBox.Text);
        }

        private void bruteButton_Click(object sender, EventArgs e)
        {
            board.BackupBoard();
            DateTime start = DateTime.Now;
            board.BruteForce();
            DateTime end = DateTime.Now;
            textBoxTimeTaken.Text = ($"Brute Force: {(end-start).TotalMilliseconds} milliseconds");
        }

        private void ruleBasedButton_Click(object sender, EventArgs e)
        {
            board.BackupBoard();
            board.RuleBasedSolve();
        }

        private void undoSolveButton_Click(object sender, EventArgs e)
        {
            board.UndoSolve();
        }
    }
}
