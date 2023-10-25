namespace Messanger
{
    partial class MessagePage
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
            allMessageTb = new TextBox();
            toWhomTb = new TextBox();
            toWhomBtn = new Button();
            textBox1 = new TextBox();
            getMessageBtn = new Button();
            sendBtn = new Button();
            SuspendLayout();
            // 
            // allMessageTb
            // 
            allMessageTb.Location = new Point(55, 72);
            allMessageTb.Multiline = true;
            allMessageTb.Name = "allMessageTb";
            allMessageTb.Size = new Size(705, 316);
            allMessageTb.TabIndex = 0;
            // 
            // toWhomTb
            // 
            toWhomTb.Location = new Point(55, 20);
            toWhomTb.Name = "toWhomTb";
            toWhomTb.Size = new Size(245, 27);
            toWhomTb.TabIndex = 1;
            // 
            // toWhomBtn
            // 
            toWhomBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toWhomBtn.Location = new Point(352, 20);
            toWhomBtn.Name = "toWhomBtn";
            toWhomBtn.Size = new Size(136, 29);
            toWhomBtn.TabIndex = 2;
            toWhomBtn.Text = "To Whom";
            toWhomBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 415);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(456, 27);
            textBox1.TabIndex = 3;
            // 
            // getMessageBtn
            // 
            getMessageBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            getMessageBtn.Location = new Point(652, 413);
            getMessageBtn.Name = "getMessageBtn";
            getMessageBtn.Size = new Size(108, 29);
            getMessageBtn.TabIndex = 4;
            getMessageBtn.Text = "Get";
            getMessageBtn.UseVisualStyleBackColor = true;
            // 
            // sendBtn
            // 
            sendBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            sendBtn.Location = new Point(531, 413);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(104, 29);
            sendBtn.TabIndex = 5;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            // 
            // MessagePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 475);
            Controls.Add(sendBtn);
            Controls.Add(getMessageBtn);
            Controls.Add(textBox1);
            Controls.Add(toWhomBtn);
            Controls.Add(toWhomTb);
            Controls.Add(allMessageTb);
            Name = "MessagePage";
            Text = "MessagePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox allMessageTb;
        private TextBox toWhomTb;
        private Button toWhomBtn;
        private TextBox textBox1;
        private Button getMessageBtn;
        private Button sendBtn;
    }
}