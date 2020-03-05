namespace Chat
{
    partial class Login
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
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_entrar = new System.Windows.Forms.Button();
            this.button_registo = new System.Windows.Forms.Button();
            this.lb_alert = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(115, 174);
            this.textbox_username.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(201, 22);
            this.textbox_username.TabIndex = 0;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(115, 224);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(201, 22);
            this.textbox_password.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 227);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // button_entrar
            // 
            this.button_entrar.Location = new System.Drawing.Point(235, 314);
            this.button_entrar.Margin = new System.Windows.Forms.Padding(4);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(151, 49);
            this.button_entrar.TabIndex = 6;
            this.button_entrar.Text = "Entrar";
            this.button_entrar.UseVisualStyleBackColor = true;
            this.button_entrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_registo
            // 
            this.button_registo.Location = new System.Drawing.Point(52, 314);
            this.button_registo.Margin = new System.Windows.Forms.Padding(4);
            this.button_registo.Name = "button_registo";
            this.button_registo.Size = new System.Drawing.Size(151, 49);
            this.button_registo.TabIndex = 7;
            this.button_registo.Text = "Registar";
            this.button_registo.UseVisualStyleBackColor = true;
            this.button_registo.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb_alert
            // 
            this.lb_alert.AutoSize = true;
            this.lb_alert.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_alert.Location = new System.Drawing.Point(111, 276);
            this.lb_alert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_alert.Name = "lb_alert";
            this.lb_alert.Size = new System.Drawing.Size(0, 17);
            this.lb_alert.TabIndex = 8;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_title.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(46, 32);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(309, 99);
            this.lb_title.TabIndex = 9;
            this.lb_title.Text = "The Chat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 43);
            this.label1.TabIndex = 10;
            this.label1.Text = "Welcome to";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.lb_alert);
            this.Controls.Add(this.button_registo);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(438, 443);
            this.MinimumSize = new System.Drawing.Size(438, 443);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.Button button_registo;
        private System.Windows.Forms.Label lb_alert;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label label1;
    }
}