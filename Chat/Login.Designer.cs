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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_entrar = new System.Windows.Forms.Button();
            this.button_registo = new System.Windows.Forms.Button();
            this.lb_alert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(86, 141);
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(152, 20);
            this.textbox_username.TabIndex = 0;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(86, 182);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(152, 20);
            this.textbox_password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Emblema One", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // button_entrar
            // 
            this.button_entrar.Location = new System.Drawing.Point(176, 255);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(113, 40);
            this.button_entrar.TabIndex = 6;
            this.button_entrar.Text = "Entrar";
            this.button_entrar.UseVisualStyleBackColor = true;
            this.button_entrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_registo
            // 
            this.button_registo.Location = new System.Drawing.Point(39, 255);
            this.button_registo.Name = "button_registo";
            this.button_registo.Size = new System.Drawing.Size(113, 40);
            this.button_registo.TabIndex = 7;
            this.button_registo.Text = "Registar";
            this.button_registo.UseVisualStyleBackColor = true;
            this.button_registo.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb_alert
            // 
            this.lb_alert.AutoSize = true;
            this.lb_alert.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_alert.Location = new System.Drawing.Point(83, 224);
            this.lb_alert.Name = "lb_alert";
            this.lb_alert.Size = new System.Drawing.Size(0, 13);
            this.lb_alert.TabIndex = 8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.lb_alert);
            this.Controls.Add(this.button_registo);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.Button button_registo;
        private System.Windows.Forms.Label lb_alert;
    }
}