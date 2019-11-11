namespace GK.main
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_admin = new System.Windows.Forms.Label();
            this.btn_order = new System.Windows.Forms.Button();
            this.btn_employee = new System.Windows.Forms.Button();
            this.btn_menu = new System.Windows.Forms.Button();
            this.btn_member = new System.Windows.Forms.Button();
            this.btn_password = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Navigation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Welcome";
            // 
            // lb_admin
            // 
            this.lb_admin.AutoSize = true;
            this.lb_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_admin.Location = new System.Drawing.Point(154, 79);
            this.lb_admin.Name = "lb_admin";
            this.lb_admin.Size = new System.Drawing.Size(51, 20);
            this.lb_admin.TabIndex = 0;
            this.lb_admin.Text = "label1";
            // 
            // btn_order
            // 
            this.btn_order.Location = new System.Drawing.Point(157, 127);
            this.btn_order.Name = "btn_order";
            this.btn_order.Size = new System.Drawing.Size(122, 44);
            this.btn_order.TabIndex = 1;
            this.btn_order.Text = "Order";
            this.btn_order.UseVisualStyleBackColor = true;
            this.btn_order.Click += new System.EventHandler(this.btn_order_Click);
            // 
            // btn_employee
            // 
            this.btn_employee.Location = new System.Drawing.Point(157, 177);
            this.btn_employee.Name = "btn_employee";
            this.btn_employee.Size = new System.Drawing.Size(122, 44);
            this.btn_employee.TabIndex = 1;
            this.btn_employee.Text = "Manage Employee";
            this.btn_employee.UseVisualStyleBackColor = true;
            this.btn_employee.Click += new System.EventHandler(this.btn_employee_Click);
            // 
            // btn_menu
            // 
            this.btn_menu.Location = new System.Drawing.Point(157, 227);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(122, 44);
            this.btn_menu.TabIndex = 1;
            this.btn_menu.Text = "Manage Menu";
            this.btn_menu.UseVisualStyleBackColor = true;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // btn_member
            // 
            this.btn_member.Location = new System.Drawing.Point(157, 277);
            this.btn_member.Name = "btn_member";
            this.btn_member.Size = new System.Drawing.Size(122, 44);
            this.btn_member.TabIndex = 1;
            this.btn_member.Text = "Manage Member";
            this.btn_member.UseVisualStyleBackColor = true;
            this.btn_member.Click += new System.EventHandler(this.btn_member_Click);
            // 
            // btn_password
            // 
            this.btn_password.Location = new System.Drawing.Point(157, 327);
            this.btn_password.Name = "btn_password";
            this.btn_password.Size = new System.Drawing.Size(122, 44);
            this.btn_password.TabIndex = 1;
            this.btn_password.Text = "Change Password";
            this.btn_password.UseVisualStyleBackColor = true;
            this.btn_password.Click += new System.EventHandler(this.btn_password_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(157, 377);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(122, 44);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 459);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_password);
            this.Controls.Add(this.btn_member);
            this.Controls.Add(this.btn_menu);
            this.Controls.Add(this.btn_employee);
            this.Controls.Add(this.btn_order);
            this.Controls.Add(this.lb_admin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_admin;
        private System.Windows.Forms.Button btn_order;
        private System.Windows.Forms.Button btn_employee;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Button btn_member;
        private System.Windows.Forms.Button btn_password;
        private System.Windows.Forms.Button btn_logout;
    }
}