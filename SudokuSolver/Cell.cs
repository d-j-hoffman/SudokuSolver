using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    class Cell : Button
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value;
                if (_value == 0)
                    this.Text = "";
                else
                    this.Text = value.ToString();
                }
        }
        public int X { get; set; }
        public int Y { get; set; }
        //Used for rule based
        public List<int> possibleNumbers { get; set; }
    }
}
