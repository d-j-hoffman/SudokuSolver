using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SudokuSolver
{
    internal class Board
    {
        private Cell[,] grid = new Cell[9, 9];
        int[,] backup = new int[9,9];
        public void PopulateEmptyGrid(Panel sudokuPanel)
        {
            int cellSize = sudokuPanel.Size.Width / 9;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell temp = new Cell();
                    temp.Location = new Point(j * cellSize, i * cellSize);
                    temp.Size = new Size(cellSize, cellSize);
                    temp.Font = new Font("Times New Roman", cellSize / 2);
                    temp.X = j;
                    temp.Y = i;
                    temp.FlatStyle = FlatStyle.Flat;
                    temp.BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    temp.KeyPress += CellKeyPress;
                    temp.Value = 0;
                    sudokuPanel.Controls.Add(temp);
                    grid[j, i] = temp;
                }
            }
        }

        public void PopulateGridFromString(string input)
        {
            if (input.Length == 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        grid[j, i].Value = (int)input[i * 9 + j] - 48;
                    }
                }
            }
        }

        private void CellKeyPress(object sender, KeyPressEventArgs e)
        {
            int result;
            var cell = sender as Cell;
            if (int.TryParse(e.KeyChar.ToString(), out result))
            {
                cell.Value = result;
            }
        }
        public void UndoSolve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Value = backup[i, j];
                }
            }
        }

        public void BackupBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    backup[i, j] = grid[i, j].Value;
                }
            }
        }
        public bool BruteForce(int x = 0, int y = 0)
        {
            int newX = x, newY = y;
            if (x < 8)
                newX++;
            else
            {
                newX = 0;
                newY++;
            }
            if (y == 9)
                return true;
            if (grid[x, y].Value != 0)
                return BruteForce(newX, newY);
            List<int> possibleChoices = PossibleChoices(x, y);
            int counter = 0;
            while (possibleChoices.Count > counter)
            {
                grid[x, y].Value = possibleChoices[counter];
                if (BruteForce(newX, newY))
                    return true;
                counter++;
            }
            //Backtrack
            grid[x, y].Value = 0;
            return false;
        }

        #region Rule Based
        /*Interesting reading on Brute Force and Rule-based solving solutions
        * https://www.ijettcs.org/Volume4Issue5(2)/IJETTCS-2015-10-10-17.pdf 
        * I used the rules in this to attempt a rule based approach
        * -- THESE RULES ARE LISTED ACCORDING TO PRIORITY --
        * Rule 1 - Naked Single: A cell only has one potential number. Assign it.
        * Rule 2 - Hidden Single: If a region(Row, column, 3x3) only has one potential number, assign it.
        * Rule 3 - Naked Pair: If a region contains 2 squares which each only have two specific candidates,
        *          If one such pair exists, remove all occurrances of these numbers from the potential list of their
        *          relative regions.
        * Rule 4 - Hidden Pair: If a region contains only two squares which can hold two specific candidates,
        *          then those squares are a hidden pair. Treat the same as a naked pair.
        * Rule 5 - Guessing(Nishio):The solver finds an empty square and fills in one of the candidates for that square.
        *          It then continues from there and sees if the guess leads to a solution or an invalid puzzle. If invalid
        *          rollback and try another guess.
        */
        
        public void RuleBasedSolve()
        {
            int brokeCounter = 0;
            while(brokeCounter < 100 )
            {
                UpdatePotentialChoices();
                if (CheckNakedSingle())
                    continue;
                brokeCounter++;
            }

        }

        private bool CheckHiddenSingle()
        {
            bool isChanged = false;
            //Check each row, column and region whether there are 8 distinct numbers.
            for (int i = 0; i < 9; i++)
            {
                List<int> rowChoices = PossibleChoicesRow(i);
                if(rowChoices.Count ==8)
                {
                    int missingNo = FindMissingNumber(rowChoices);
                    for (int j = 0; j < 9; j++)
                        if (grid[j,i].Value == 0)
                        {
                            grid[j, i].Value = missingNo;
                            isChanged = true;
                        }

                }
                List<int> columnChoices = PossibleChoicesColumn(i);
                if(columnChoices.Count == 8)
                {
                    int missingNo = FindMissingNumber(columnChoices);
                    for (int j = 0; j < 9; j++)
                        if (grid[i,j].Value == 0)
                        {
                            grid[i, j].Value = missingNo;
                            isChanged = true;
                        }

                }
            }
            return isChanged;
        }

        private bool CheckNakedSingle()
        {
            bool isChanged = false;
            foreach(Cell cell in grid)
            {
                if (cell.possibleNumbers?.Count == 1)
                {
                    cell.Value = cell.possibleNumbers[0];
                    cell.possibleNumbers.RemoveAt(0);
                    isChanged = true;
                }
            }
            return isChanged;
        }
        private void UpdatePotentialChoices()
        {
            foreach(Cell cell in grid)
            {
                if(cell.Value == 0)
                    cell.possibleNumbers = PossibleChoices(cell.X, cell.Y);
            }

        }
        #endregion
        #region Solving Utils

        private int FindMissingNumber(List<int> list)
        {
            for (int i = 1; i < 9; i++)
                if (!list.Contains(i))
                    return i;
            return -1;
        }
        private List<int> PossibleChoices(int X, int Y)
        {
            List<int> returnList = new List<int>();
            List<int> temp = PossibleChoicesRow(Y);
            temp.AddRange(PossibleChoicesColumn(X));
            temp.AddRange(PossibleChoicesRegion(X, Y));
            temp = (from i in temp select i).Distinct().ToList();
            for(int i = 1; i<=9; i++)
            {
                if (!temp.Contains(i))
                    returnList.Add(i);
            }
            return returnList;
        }

        private List<int> PossibleChoicesRow(int Y)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < 9; i++)
                returnList.Add(grid[i, Y].Value);
            return (from i in returnList select i).Where(i=>i!=0).Distinct().ToList();
        }

        private List<int> PossibleChoicesColumn(int X)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < 9; i++)
                returnList.Add(grid[X, i].Value);
            return (from i in returnList select i).Where(i => i != 0).Distinct().ToList();
        }

        private List<int> PossibleChoicesRegion(int X, int Y)
        {
            List<int> returnList = new List<int>();
            int baseX = X / 3 * 3;
            int baseY = Y / 3 * 3;
            for(int i = baseX; i<baseX+3; i++)
            {
                for (int j = baseY; j < baseY + 3; j++)
                    returnList.Add(grid[i, j].Value);
            }
            return (from i in returnList select i).Where(i => i != 0).Distinct().ToList();
        }

        #endregion Solving Utils
    }
}