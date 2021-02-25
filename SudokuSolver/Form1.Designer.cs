
namespace SudokuSolver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSudoku = new System.Windows.Forms.Panel();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.bruteButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxTimeTaken = new System.Windows.Forms.TextBox();
            this.ruleBasedButton = new System.Windows.Forms.Button();
            this.undoSolveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelSudoku
            // 
            this.panelSudoku.Location = new System.Drawing.Point(338, 12);
            this.panelSudoku.Name = "panelSudoku";
            this.panelSudoku.Size = new System.Drawing.Size(450, 450);
            this.panelSudoku.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(24, 442);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(281, 20);
            this.inputTextBox.TabIndex = 1;
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(24, 413);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(281, 23);
            this.inputButton.TabIndex = 2;
            this.inputButton.Text = "Input Sudoku String";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // bruteButton
            // 
            this.bruteButton.Location = new System.Drawing.Point(24, 13);
            this.bruteButton.Name = "bruteButton";
            this.bruteButton.Size = new System.Drawing.Size(281, 46);
            this.bruteButton.TabIndex = 3;
            this.bruteButton.Text = "Brute Force";
            this.bruteButton.UseVisualStyleBackColor = true;
            this.bruteButton.Click += new System.EventHandler(this.bruteButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // textBoxTimeTaken
            // 
            this.textBoxTimeTaken.Location = new System.Drawing.Point(24, 235);
            this.textBoxTimeTaken.Multiline = true;
            this.textBoxTimeTaken.Name = "textBoxTimeTaken";
            this.textBoxTimeTaken.Size = new System.Drawing.Size(281, 172);
            this.textBoxTimeTaken.TabIndex = 4;
            // 
            // ruleBasedButton
            // 
            this.ruleBasedButton.Location = new System.Drawing.Point(24, 65);
            this.ruleBasedButton.Name = "ruleBasedButton";
            this.ruleBasedButton.Size = new System.Drawing.Size(281, 46);
            this.ruleBasedButton.TabIndex = 5;
            this.ruleBasedButton.Text = "Rule-Based Solve";
            this.ruleBasedButton.UseVisualStyleBackColor = true;
            this.ruleBasedButton.Click += new System.EventHandler(this.ruleBasedButton_Click);
            // 
            // undoSolveButton
            // 
            this.undoSolveButton.Location = new System.Drawing.Point(24, 117);
            this.undoSolveButton.Name = "undoSolveButton";
            this.undoSolveButton.Size = new System.Drawing.Size(281, 46);
            this.undoSolveButton.TabIndex = 6;
            this.undoSolveButton.Text = "Undo Solve";
            this.undoSolveButton.UseVisualStyleBackColor = true;
            this.undoSolveButton.Click += new System.EventHandler(this.undoSolveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.undoSolveButton);
            this.Controls.Add(this.ruleBasedButton);
            this.Controls.Add(this.textBoxTimeTaken);
            this.Controls.Add(this.bruteButton);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.panelSudoku);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSudoku;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button bruteButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBoxTimeTaken;
        private System.Windows.Forms.Button ruleBasedButton;
        private System.Windows.Forms.Button undoSolveButton;
    }
}

