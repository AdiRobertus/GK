namespace GK.main
{
    partial class ChefForm
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
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_password = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.lb_admin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(100, 262);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(122, 44);
            this.btn_logout.TabIndex = 11;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_password
            // 
            this.btn_password.Location = new System.Drawing.Point(100, 212);
            this.btn_password.Name = "btn_password";
            this.btn_password.Size = new System.Drawing.Size(122, 44);
            this.btn_password.TabIndex = 12;
            this.btn_password.Text = "Change Password";
            this.btn_password.UseVisualStyleBackColor = true;
            this.btn_password.Click += new System.EventHandler(this.btn_password_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(100, 162);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(122, 44);
            this.btn_view.TabIndex = 13;
            this.btn_view.Text = "View Order";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // lb_admin
            // 
            this.lb_admin.AutoSize = true;
            this.lb_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_admin.Location = new System.Drawing.Point(107, 82);
            this.lb_admin.Name = "lb_admin";
            this.lb_admin.Size = new System.Drawing.Size(51, 20);
            this.lb_admin.TabIndex = 8;
            this.lb_admin.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chef Navigation";
            // 
            // ChefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 434);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_password);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.lb_admin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChefForm";
            this.Text = "ChefForm";
            this.Load += new System.EventHandler(this.ChefForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_password;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Label lb_admin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}