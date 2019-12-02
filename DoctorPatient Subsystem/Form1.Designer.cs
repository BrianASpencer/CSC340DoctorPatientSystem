namespace DoctorPatient_Subsystem
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.loginLoginBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginPasswordTB = new System.Windows.Forms.TextBox();
            this.loginIDtB = new System.Windows.Forms.TextBox();
            this.radioButtonPatient = new System.Windows.Forms.RadioButton();
            this.radioButtonDoctor = new System.Windows.Forms.RadioButton();
            this.loginInvalid = new System.Windows.Forms.Label();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "View Notices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "View Medical Records";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(704, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(447, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 20);
            this.textBox2.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(447, 154);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(204, 173);
            this.listBox1.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(651, 124);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.loginInvalid);
            this.LoginPanel.Controls.Add(this.loginLoginBtn);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Controls.Add(this.loginPasswordTB);
            this.LoginPanel.Controls.Add(this.loginIDtB);
            this.LoginPanel.Controls.Add(this.radioButtonPatient);
            this.LoginPanel.Controls.Add(this.radioButtonDoctor);
            this.LoginPanel.Location = new System.Drawing.Point(21, 43);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(767, 426);
            this.LoginPanel.TabIndex = 12;
            this.LoginPanel.TabStop = true;
            // 
            // loginLoginBtn
            // 
            this.loginLoginBtn.Location = new System.Drawing.Point(375, 250);
            this.loginLoginBtn.Name = "loginLoginBtn";
            this.loginLoginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginLoginBtn.TabIndex = 6;
            this.loginLoginBtn.Text = "Login";
            this.loginLoginBtn.UseVisualStyleBackColor = true;
            this.loginLoginBtn.Click += new System.EventHandler(this.LoginLoginBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // loginPasswordTB
            // 
            this.loginPasswordTB.Location = new System.Drawing.Point(361, 194);
            this.loginPasswordTB.Name = "loginPasswordTB";
            this.loginPasswordTB.Size = new System.Drawing.Size(100, 20);
            this.loginPasswordTB.TabIndex = 3;
            // 
            // loginIDtB
            // 
            this.loginIDtB.Location = new System.Drawing.Point(361, 155);
            this.loginIDtB.Name = "loginIDtB";
            this.loginIDtB.Size = new System.Drawing.Size(100, 20);
            this.loginIDtB.TabIndex = 2;
            // 
            // radioButtonPatient
            // 
            this.radioButtonPatient.AutoSize = true;
            this.radioButtonPatient.Checked = true;
            this.radioButtonPatient.Location = new System.Drawing.Point(380, 123);
            this.radioButtonPatient.Name = "radioButtonPatient";
            this.radioButtonPatient.Size = new System.Drawing.Size(58, 17);
            this.radioButtonPatient.TabIndex = 1;
            this.radioButtonPatient.TabStop = true;
            this.radioButtonPatient.Text = "Patient";
            this.radioButtonPatient.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoctor
            // 
            this.radioButtonDoctor.AutoSize = true;
            this.radioButtonDoctor.Location = new System.Drawing.Point(380, 99);
            this.radioButtonDoctor.Name = "radioButtonDoctor";
            this.radioButtonDoctor.Size = new System.Drawing.Size(57, 17);
            this.radioButtonDoctor.TabIndex = 0;
            this.radioButtonDoctor.Text = "Doctor";
            this.radioButtonDoctor.UseVisualStyleBackColor = true;
            this.radioButtonDoctor.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // loginInvalid
            // 
            this.loginInvalid.AutoSize = true;
            this.loginInvalid.ForeColor = System.Drawing.Color.DarkRed;
            this.loginInvalid.Location = new System.Drawing.Point(284, 287);
            this.loginInvalid.Name = "loginInvalid";
            this.loginInvalid.Size = new System.Drawing.Size(236, 13);
            this.loginInvalid.TabIndex = 7;
            this.loginInvalid.Text = "*Invalid login please check your login information";
            this.loginInvalid.Visible = false;
            this.loginInvalid.Click += new System.EventHandler(this.Label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button loginLoginBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginPasswordTB;
        private System.Windows.Forms.TextBox loginIDtB;
        private System.Windows.Forms.RadioButton radioButtonPatient;
        private System.Windows.Forms.RadioButton radioButtonDoctor;
        private System.Windows.Forms.Label loginInvalid;
    }
}

