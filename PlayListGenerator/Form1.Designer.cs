namespace PlayListGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMenu3 = new System.Windows.Forms.Button();
            this.buttonMenu2 = new System.Windows.Forms.Button();
            this.buttonMenu1 = new System.Windows.Forms.Button();
            this.panelWorkArea = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.buttonMenu3);
            this.panelMenu.Controls.Add(this.buttonMenu2);
            this.panelMenu.Controls.Add(this.buttonMenu1);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(135, 650);
            this.panelMenu.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 624);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "© 2019 DALFID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(88)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 45);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(24, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = " Play List\r\nGenerator\r\n";
            // 
            // buttonMenu3
            // 
            this.buttonMenu3.BackColor = System.Drawing.Color.Green;
            this.buttonMenu3.FlatAppearance.BorderSize = 0;
            this.buttonMenu3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.buttonMenu3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMenu3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu3.Location = new System.Drawing.Point(0, 191);
            this.buttonMenu3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMenu3.Name = "buttonMenu3";
            this.buttonMenu3.Size = new System.Drawing.Size(135, 32);
            this.buttonMenu3.TabIndex = 0;
            this.buttonMenu3.Text = "Create";
            this.buttonMenu3.UseVisualStyleBackColor = false;
            this.buttonMenu3.Click += new System.EventHandler(this.Button4_Click);
            // 
            // buttonMenu2
            // 
            this.buttonMenu2.BackColor = System.Drawing.Color.Green;
            this.buttonMenu2.FlatAppearance.BorderSize = 0;
            this.buttonMenu2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.buttonMenu2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMenu2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu2.Location = new System.Drawing.Point(0, 159);
            this.buttonMenu2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMenu2.Name = "buttonMenu2";
            this.buttonMenu2.Size = new System.Drawing.Size(135, 32);
            this.buttonMenu2.TabIndex = 0;
            this.buttonMenu2.Text = "button3";
            this.buttonMenu2.UseVisualStyleBackColor = false;
            this.buttonMenu2.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonMenu1
            // 
            this.buttonMenu1.BackColor = System.Drawing.Color.Green;
            this.buttonMenu1.FlatAppearance.BorderSize = 0;
            this.buttonMenu1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.buttonMenu1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu1.Location = new System.Drawing.Point(0, 127);
            this.buttonMenu1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMenu1.Name = "buttonMenu1";
            this.buttonMenu1.Size = new System.Drawing.Size(135, 32);
            this.buttonMenu1.TabIndex = 0;
            this.buttonMenu1.Text = "button1";
            this.buttonMenu1.UseVisualStyleBackColor = false;
            this.buttonMenu1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.AutoScroll = true;
            this.panelWorkArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelWorkArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkArea.Location = new System.Drawing.Point(135, 45);
            this.panelWorkArea.Margin = new System.Windows.Forms.Padding(0);
            this.panelWorkArea.Name = "panelWorkArea";
            this.panelWorkArea.Size = new System.Drawing.Size(765, 605);
            this.panelWorkArea.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(135, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 45);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.Yellow;
            this.button6.Location = new System.Drawing.Point(683, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 1;
            this.button6.Text = "_";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(721, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 0;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelWorkArea);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonMenu1;
        private System.Windows.Forms.Panel panelWorkArea;
        private System.Windows.Forms.Button buttonMenu2;
        private System.Windows.Forms.Button buttonMenu3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

