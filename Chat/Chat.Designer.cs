namespace Chat
{
    partial class Chat
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
            this.lb_chat = new System.Windows.Forms.ListBox();
            this.lb_title = new System.Windows.Forms.Label();
            this.tb_mensagem = new System.Windows.Forms.TextBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_logged_as = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_chat
            // 
            this.lb_chat.FormattingEnabled = true;
            this.lb_chat.ItemHeight = 16;
            this.lb_chat.Location = new System.Drawing.Point(12, 62);
            this.lb_chat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_chat.Name = "lb_chat";
            this.lb_chat.Size = new System.Drawing.Size(519, 468);
            this.lb_chat.TabIndex = 1;
            this.lb_chat.DoubleClick += new System.EventHandler(this.lb_chat_DoubleClick);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Monotype Corsiva", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(12, 6);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(169, 52);
            this.lb_title.TabIndex = 2;
            this.lb_title.Text = "The Chat";
            // 
            // tb_mensagem
            // 
            this.tb_mensagem.Location = new System.Drawing.Point(12, 544);
            this.tb_mensagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_mensagem.Multiline = true;
            this.tb_mensagem.Name = "tb_mensagem";
            this.tb_mensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_mensagem.Size = new System.Drawing.Size(519, 64);
            this.tb_mensagem.TabIndex = 3;
            this.tb_mensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_KeyDown);
            // 
            // lb_username
            // 
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(349, 33);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(167, 26);
            this.lb_username.TabIndex = 4;
            this.lb_username.Text = "guest";
            this.lb_username.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_logged_as
            // 
            this.lb_logged_as.AutoSize = true;
            this.lb_logged_as.Location = new System.Drawing.Point(381, 9);
            this.lb_logged_as.Name = "lb_logged_as";
            this.lb_logged_as.Size = new System.Drawing.Size(134, 17);
            this.lb_logged_as.TabIndex = 5;
            this.lb_logged_as.Text = "You\'re logged in as:";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(210, 34);
            this.tb_username.Margin = new System.Windows.Forms.Padding(4);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(132, 22);
            this.tb_username.TabIndex = 6;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 619);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.lb_logged_as);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.tb_mensagem);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.lb_chat);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(559, 666);
            this.MinimumSize = new System.Drawing.Size(559, 666);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lb_chat;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TextBox tb_mensagem;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_logged_as;
        private System.Windows.Forms.TextBox tb_username;
    }
}

