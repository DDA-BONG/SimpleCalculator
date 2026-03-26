namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_main = new Label();
            txt_show = new TextBox();
            txt_oprnd = new TextBox();
            btn_CE = new Button();
            btn_C = new Button();
            btn_del = new Button();
            btn_div = new Button();
            btn_num7 = new Button();
            btn_num8 = new Button();
            btn_num9 = new Button();
            btn_mult = new Button();
            btn_num4 = new Button();
            btn_num5 = new Button();
            btn_num6 = new Button();
            btn_minus = new Button();
            btn_num1 = new Button();
            btn_num2 = new Button();
            btn_num3 = new Button();
            btn_plus = new Button();
            btn_num0 = new Button();
            btn_dot = new Button();
            btn_equal = new Button();
            SuspendLayout();
            // 
            // lbl_main
            // 
            lbl_main.AutoSize = true;
            lbl_main.Font = new Font("맑은 고딕", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lbl_main.ForeColor = Color.Blue;
            lbl_main.Location = new Point(12, 9);
            lbl_main.Name = "lbl_main";
            lbl_main.Size = new Size(403, 62);
            lbl_main.TabIndex = 0;
            lbl_main.Text = "SimpleCalculator";
            // 
            // txt_show
            // 
            txt_show.Font = new Font("맑은 고딕", 15F);
            txt_show.Location = new Point(38, 89);
            txt_show.Name = "txt_show";
            txt_show.ReadOnly = true;
            txt_show.Size = new Size(421, 41);
            txt_show.TabIndex = 1;
            txt_show.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_oprnd
            // 
            txt_oprnd.Font = new Font("맑은 고딕", 15F);
            txt_oprnd.Location = new Point(38, 145);
            txt_oprnd.Name = "txt_oprnd";
            txt_oprnd.ReadOnly = true;
            txt_oprnd.Size = new Size(421, 41);
            txt_oprnd.TabIndex = 2;
            txt_oprnd.Text = "0";
            txt_oprnd.TextAlign = HorizontalAlignment.Right;
            // 
            // btn_CE
            // 
            btn_CE.Font = new Font("맑은 고딕", 18F);
            btn_CE.Location = new Point(59, 242);
            btn_CE.Name = "btn_CE";
            btn_CE.Size = new Size(75, 55);
            btn_CE.TabIndex = 3;
            btn_CE.Text = "CE";
            btn_CE.UseVisualStyleBackColor = true;
            btn_CE.Click += btn_CE_Click;
            // 
            // btn_C
            // 
            btn_C.Font = new Font("맑은 고딕", 18F);
            btn_C.Location = new Point(161, 243);
            btn_C.Name = "btn_C";
            btn_C.Size = new Size(75, 55);
            btn_C.TabIndex = 4;
            btn_C.Text = "C";
            btn_C.UseVisualStyleBackColor = true;
            btn_C.Click += btn_C_Click;
            // 
            // btn_del
            // 
            btn_del.Font = new Font("맑은 고딕", 16F);
            btn_del.Location = new Point(272, 243);
            btn_del.Name = "btn_del";
            btn_del.Size = new Size(75, 55);
            btn_del.TabIndex = 5;
            btn_del.Text = "DEL";
            btn_del.UseVisualStyleBackColor = true;
            btn_del.Click += btn_del_Click;
            // 
            // btn_div
            // 
            btn_div.Font = new Font("맑은 고딕", 18F);
            btn_div.Location = new Point(378, 243);
            btn_div.Name = "btn_div";
            btn_div.Size = new Size(75, 55);
            btn_div.TabIndex = 6;
            btn_div.Text = "÷";
            btn_div.UseVisualStyleBackColor = true;
            btn_div.Click += OperatorButton_Click;
            // 
            // btn_num7
            // 
            btn_num7.Font = new Font("맑은 고딕", 18F);
            btn_num7.Location = new Point(59, 319);
            btn_num7.Name = "btn_num7";
            btn_num7.Size = new Size(75, 55);
            btn_num7.TabIndex = 7;
            btn_num7.Text = "7";
            btn_num7.UseVisualStyleBackColor = true;
            btn_num7.Click += NumberButton_Click;
            // 
            // btn_num8
            // 
            btn_num8.Font = new Font("맑은 고딕", 18F);
            btn_num8.Location = new Point(161, 319);
            btn_num8.Name = "btn_num8";
            btn_num8.Size = new Size(75, 55);
            btn_num8.TabIndex = 8;
            btn_num8.Text = "8";
            btn_num8.UseVisualStyleBackColor = true;
            btn_num8.Click += NumberButton_Click;
            // 
            // btn_num9
            // 
            btn_num9.Font = new Font("맑은 고딕", 18F);
            btn_num9.Location = new Point(272, 319);
            btn_num9.Name = "btn_num9";
            btn_num9.Size = new Size(75, 55);
            btn_num9.TabIndex = 9;
            btn_num9.Text = "9";
            btn_num9.UseVisualStyleBackColor = true;
            btn_num9.Click += NumberButton_Click;
            // 
            // btn_mult
            // 
            btn_mult.Font = new Font("맑은 고딕", 18F);
            btn_mult.Location = new Point(378, 319);
            btn_mult.Name = "btn_mult";
            btn_mult.Size = new Size(75, 55);
            btn_mult.TabIndex = 10;
            btn_mult.Text = "X";
            btn_mult.UseVisualStyleBackColor = true;
            btn_mult.Click += OperatorButton_Click;
            // 
            // btn_num4
            // 
            btn_num4.Font = new Font("맑은 고딕", 18F);
            btn_num4.Location = new Point(59, 390);
            btn_num4.Name = "btn_num4";
            btn_num4.Size = new Size(75, 55);
            btn_num4.TabIndex = 11;
            btn_num4.Text = "4";
            btn_num4.UseVisualStyleBackColor = true;
            btn_num4.Click += NumberButton_Click;
            // 
            // btn_num5
            // 
            btn_num5.Font = new Font("맑은 고딕", 18F);
            btn_num5.Location = new Point(161, 390);
            btn_num5.Name = "btn_num5";
            btn_num5.Size = new Size(75, 55);
            btn_num5.TabIndex = 12;
            btn_num5.Text = "5";
            btn_num5.UseVisualStyleBackColor = true;
            btn_num5.Click += NumberButton_Click;
            // 
            // btn_num6
            // 
            btn_num6.Font = new Font("맑은 고딕", 18F);
            btn_num6.Location = new Point(272, 390);
            btn_num6.Name = "btn_num6";
            btn_num6.Size = new Size(75, 55);
            btn_num6.TabIndex = 13;
            btn_num6.Text = "6";
            btn_num6.UseVisualStyleBackColor = true;
            btn_num6.Click += NumberButton_Click;
            // 
            // btn_minus
            // 
            btn_minus.Font = new Font("맑은 고딕", 18F);
            btn_minus.Location = new Point(378, 390);
            btn_minus.Name = "btn_minus";
            btn_minus.Size = new Size(75, 55);
            btn_minus.TabIndex = 14;
            btn_minus.Text = "-";
            btn_minus.UseVisualStyleBackColor = true;
            btn_minus.Click += OperatorButton_Click;
            // 
            // btn_num1
            // 
            btn_num1.Font = new Font("맑은 고딕", 18F);
            btn_num1.Location = new Point(61, 457);
            btn_num1.Name = "btn_num1";
            btn_num1.Size = new Size(75, 55);
            btn_num1.TabIndex = 15;
            btn_num1.Text = "1";
            btn_num1.UseVisualStyleBackColor = true;
            btn_num1.Click += NumberButton_Click;
            // 
            // btn_num2
            // 
            btn_num2.Font = new Font("맑은 고딕", 18F);
            btn_num2.Location = new Point(161, 457);
            btn_num2.Name = "btn_num2";
            btn_num2.Size = new Size(75, 55);
            btn_num2.TabIndex = 16;
            btn_num2.Text = "2";
            btn_num2.UseVisualStyleBackColor = true;
            btn_num2.Click += NumberButton_Click;
            // 
            // btn_num3
            // 
            btn_num3.Font = new Font("맑은 고딕", 18F);
            btn_num3.Location = new Point(272, 457);
            btn_num3.Name = "btn_num3";
            btn_num3.Size = new Size(75, 55);
            btn_num3.TabIndex = 17;
            btn_num3.Text = "3";
            btn_num3.UseVisualStyleBackColor = true;
            btn_num3.Click += NumberButton_Click;
            // 
            // btn_plus
            // 
            btn_plus.Font = new Font("맑은 고딕", 18F);
            btn_plus.Location = new Point(378, 457);
            btn_plus.Name = "btn_plus";
            btn_plus.Size = new Size(75, 55);
            btn_plus.TabIndex = 18;
            btn_plus.Text = "+";
            btn_plus.UseVisualStyleBackColor = true;
            btn_plus.Click += OperatorButton_Click;
            // 
            // btn_num0
            // 
            btn_num0.Font = new Font("맑은 고딕", 18F);
            btn_num0.Location = new Point(161, 528);
            btn_num0.Name = "btn_num0";
            btn_num0.Size = new Size(75, 55);
            btn_num0.TabIndex = 20;
            btn_num0.Text = "0";
            btn_num0.UseVisualStyleBackColor = true;
            btn_num0.Click += NumberButton_Click;
            // 
            // btn_dot
            // 
            btn_dot.Enabled = false;
            btn_dot.Font = new Font("맑은 고딕", 18F);
            btn_dot.Location = new Point(272, 528);
            btn_dot.Name = "btn_dot";
            btn_dot.Size = new Size(75, 55);
            btn_dot.TabIndex = 21;
            btn_dot.Text = ".";
            btn_dot.UseVisualStyleBackColor = true;
            // 
            // btn_equal
            // 
            btn_equal.Font = new Font("맑은 고딕", 18F);
            btn_equal.Location = new Point(378, 528);
            btn_equal.Name = "btn_equal";
            btn_equal.Size = new Size(75, 55);
            btn_equal.TabIndex = 22;
            btn_equal.Text = "=";
            btn_equal.UseVisualStyleBackColor = true;
            btn_equal.Click += btn_equal_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 648);
            Controls.Add(btn_equal);
            Controls.Add(btn_dot);
            Controls.Add(btn_num0);
            Controls.Add(btn_plus);
            Controls.Add(btn_num3);
            Controls.Add(btn_num2);
            Controls.Add(btn_num1);
            Controls.Add(btn_minus);
            Controls.Add(btn_num6);
            Controls.Add(btn_num5);
            Controls.Add(btn_num4);
            Controls.Add(btn_mult);
            Controls.Add(btn_num9);
            Controls.Add(btn_num8);
            Controls.Add(btn_num7);
            Controls.Add(btn_div);
            Controls.Add(btn_del);
            Controls.Add(btn_C);
            Controls.Add(btn_CE);
            Controls.Add(txt_oprnd);
            Controls.Add(txt_show);
            Controls.Add(lbl_main);
            Name = "Form1";
            Text = "Simple Calculator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_main;
        private TextBox txt_show;
        private TextBox txt_oprnd;
        private Button btn_CE;
        private Button btn_C;
        private Button btn_del;
        private Button btn_div;
        private Button btn_num7;
        private Button btn_num8;
        private Button btn_num9;
        private Button btn_mult;
        private Button btn_num4;
        private Button btn_num5;
        private Button btn_num6;
        private Button btn_minus;
        private Button btn_num1;
        private Button btn_num2;
        private Button btn_num3;
        private Button btn_plus;
        private Button btn_num0;
        private Button btn_dot;
        private Button btn_equal;
    }
}
