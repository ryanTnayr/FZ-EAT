
namespace FZ_POS
{
    partial class FormCusHistory
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.userControlCusCart1 = new FZ_POS.UserControlCusCart();
            this.userControlCusCart2 = new FZ_POS.UserControlCusCart();
            this.userControlCusCart3 = new FZ_POS.UserControlCusCart();
            this.userControlCusCart4 = new FZ_POS.UserControlCusCart();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.userControlCusCart1);
            this.flowLayoutPanel1.Controls.Add(this.userControlCusCart2);
            this.flowLayoutPanel1.Controls.Add(this.userControlCusCart3);
            this.flowLayoutPanel1.Controls.Add(this.userControlCusCart4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(74, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(595, 553);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // userControlCusCart1
            // 
            this.userControlCusCart1.Location = new System.Drawing.Point(3, 3);
            this.userControlCusCart1.Name = "userControlCusCart1";
            this.userControlCusCart1.Size = new System.Drawing.Size(528, 100);
            this.userControlCusCart1.TabIndex = 0;
            // 
            // userControlCusCart2
            // 
            this.userControlCusCart2.Location = new System.Drawing.Point(3, 109);
            this.userControlCusCart2.Name = "userControlCusCart2";
            this.userControlCusCart2.Size = new System.Drawing.Size(528, 100);
            this.userControlCusCart2.TabIndex = 1;
            // 
            // userControlCusCart3
            // 
            this.userControlCusCart3.Location = new System.Drawing.Point(3, 215);
            this.userControlCusCart3.Name = "userControlCusCart3";
            this.userControlCusCart3.Size = new System.Drawing.Size(528, 100);
            this.userControlCusCart3.TabIndex = 2;
            // 
            // userControlCusCart4
            // 
            this.userControlCusCart4.Location = new System.Drawing.Point(3, 321);
            this.userControlCusCart4.Name = "userControlCusCart4";
            this.userControlCusCart4.Size = new System.Drawing.Size(528, 100);
            this.userControlCusCart4.TabIndex = 3;
            // 
            // FormCusHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 602);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCusHistory";
            this.Text = "FormCusHistory";
            this.Load += new System.EventHandler(this.FormCusHistory_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserControlCusCart userControlCusCart1;
        private UserControlCusCart userControlCusCart2;
        private UserControlCusCart userControlCusCart3;
        private UserControlCusCart userControlCusCart4;
    }
}