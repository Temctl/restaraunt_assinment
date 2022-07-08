namespace biyDaalt
{
    partial class welcomePage
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
            button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            label8 = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            richTextBox4 = new System.Windows.Forms.RichTextBox();
            button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(330, 461);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(102, 23);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.login);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 406);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(633, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 45);
            this.button2.TabIndex = 7;
            this.button2.Text = "available seats";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.seat_choose);
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(34, 461);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(102, 23);
            button3.TabIndex = 8;
            button3.Text = "logout";
            button3.UseVisualStyleBackColor = true;
            button3.Click += new System.EventHandler(this.log_out);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(762, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 9;
            this.tabControl1.Size = new System.Drawing.Size(225, 490);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.richTextBox3);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(217, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reviews";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Enabled = false;
            this.richTextBox3.Location = new System.Drawing.Point(6, 320);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(205, 96);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(6, 187);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(201, 96);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(6, 68);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 85);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Reviews";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(richTextBox4);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(217, 462);
            tabPage2.TabIndex = 12;
            tabPage2.Text = "User";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 126);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(44, 15);
            label8.TabIndex = 13;
            label8.Text = "Review";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(6, 90);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 23);
            numericUpDown1.TabIndex = 14;
            numericUpDown1.Maximum = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(132, 98);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 15);
            label7.TabIndex = 15;
            label7.Text = "out of 10";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 72);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 15);
            label6.TabIndex = 16;
            label6.Text = "Rating";
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(50, 330);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(121, 35);
            button5.TabIndex = 17;
            button5.Text = "Login";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new System.EventHandler(this.login);
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(136, 303);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 18;
            button4.Text = "submit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(this.submit_review);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(38, 15);
            label5.TabIndex = 19;
            label5.Text = "label5";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new System.Drawing.Point(6, 144);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new System.Drawing.Size(205, 153);
            richTextBox4.TabIndex = 20;
            richTextBox4.Text = "";
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(60, 365);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(102, 45);
            button6.TabIndex = 21;
            button6.Text = "View booking details"; 
            button6.UseVisualStyleBackColor = true;
            button6.Click += new System.EventHandler(this.view_bookingDetail);
            // 
            // welcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 514);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(button1);
            this.Name = "welcomePage";
            this.Text = "Restaraunt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox1;
        private Button button2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        static private TabPage tabPage2;
        private Label label4;
        private Label label3;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox2;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label1;
        static private Button button6;
        static private Button button3;
        static private Label label8;
        static private NumericUpDown numericUpDown1;
        static private Label label7;
        static private Label label6;
        static private Button button1;
        static private Button button5;
        static private Button button4;
        static private Label label5;
        static private RichTextBox richTextBox4;
    }
}