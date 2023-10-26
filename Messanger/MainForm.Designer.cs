namespace Messanger
{
    partial class MainForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            firstNameTb = new TextBox();
            emailTb = new TextBox();
            phoneNumberTb = new TextBox();
            lastNameTb = new TextBox();
            registerBtn = new Button();
            wrongRegisterLb = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(54, 58);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "First name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(54, 220);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(54, 140);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 2;
            label3.Text = "Last name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(54, 305);
            label4.Name = "label4";
            label4.Size = new Size(137, 25);
            label4.TabIndex = 3;
            label4.Text = "Phone number";
            // 
            // firstNameTb
            // 
            firstNameTb.Location = new Point(73, 97);
            firstNameTb.Name = "firstNameTb";
            firstNameTb.Size = new Size(298, 27);
            firstNameTb.TabIndex = 4;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(73, 260);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(298, 27);
            emailTb.TabIndex = 5;
            // 
            // phoneNumberTb
            // 
            phoneNumberTb.Location = new Point(73, 344);
            phoneNumberTb.Name = "phoneNumberTb";
            phoneNumberTb.Size = new Size(298, 27);
            phoneNumberTb.TabIndex = 6;
            // 
            // lastNameTb
            // 
            lastNameTb.Location = new Point(73, 180);
            lastNameTb.Name = "lastNameTb";
            lastNameTb.Size = new Size(298, 27);
            lastNameTb.TabIndex = 7;
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            registerBtn.Location = new Point(98, 401);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(246, 49);
            registerBtn.TabIndex = 8;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // wrongRegisterLb
            // 
            wrongRegisterLb.AutoSize = true;
            wrongRegisterLb.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            wrongRegisterLb.Location = new Point(54, 21);
            wrongRegisterLb.Name = "wrongRegisterLb";
            wrongRegisterLb.Size = new Size(0, 20);
            wrongRegisterLb.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 482);
            Controls.Add(wrongRegisterLb);
            Controls.Add(registerBtn);
            Controls.Add(lastNameTb);
            Controls.Add(phoneNumberTb);
            Controls.Add(emailTb);
            Controls.Add(firstNameTb);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Messanger";
            Click += registerBtn_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox firstNameTb;
        private TextBox emailTb;
        private TextBox phoneNumberTb;
        private TextBox lastNameTb;
        private Button registerBtn;
        private Label wrongRegisterLb;
    }
}