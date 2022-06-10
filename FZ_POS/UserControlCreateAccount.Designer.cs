
namespace FZ_POS
{
    partial class UserControlCreateAccount
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBeCus = new System.Windows.Forms.Button();
            this.btnBeStore = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOK = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsername.Location = new System.Drawing.Point(198, 89);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(289, 31);
            this.txtUsername.TabIndex = 20;
            this.txtUsername.Text = "Enter 3~16 char..";
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            this.txtUsername.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUsername_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 19;
            this.label3.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(198, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(289, 31);
            this.txtPassword.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Password";
            // 
            // btnBeCus
            // 
            this.btnBeCus.BackColor = System.Drawing.Color.Transparent;
            this.btnBeCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBeCus.FlatAppearance.BorderSize = 0;
            this.btnBeCus.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeCus.Location = new System.Drawing.Point(267, 207);
            this.btnBeCus.Margin = new System.Windows.Forms.Padding(0);
            this.btnBeCus.Name = "btnBeCus";
            this.btnBeCus.Size = new System.Drawing.Size(220, 84);
            this.btnBeCus.TabIndex = 25;
            this.btnBeCus.Text = "|Become Customer->";
            this.btnBeCus.UseVisualStyleBackColor = false;
            this.btnBeCus.Click += new System.EventHandler(this.btnBeCus_Click);
            // 
            // btnBeStore
            // 
            this.btnBeStore.BackColor = System.Drawing.Color.Transparent;
            this.btnBeStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBeStore.FlatAppearance.BorderSize = 0;
            this.btnBeStore.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeStore.Location = new System.Drawing.Point(41, 207);
            this.btnBeStore.Margin = new System.Windows.Forms.Padding(0);
            this.btnBeStore.Name = "btnBeStore";
            this.btnBeStore.Size = new System.Drawing.Size(220, 84);
            this.btnBeStore.TabIndex = 26;
            this.btnBeStore.Text = "<-Become Store|";
            this.btnBeStore.UseVisualStyleBackColor = false;
            this.btnBeStore.Click += new System.EventHandler(this.btnBeStore_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(480, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 48);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOK.Location = new System.Drawing.Point(44, 126);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(14, 19);
            this.lblOK.TabIndex = 28;
            this.lblOK.Text = "-";
            this.lblOK.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(44, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "At least 3 char";
            // 
            // UserControlCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBeStore);
            this.Controls.Add(this.btnBeCus);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Name = "UserControlCreateAccount";
            this.Size = new System.Drawing.Size(540, 370);
            this.Load += new System.EventHandler(this.UserControlCreateAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBeCus;
        private System.Windows.Forms.Button btnBeStore;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label label2;
    }
}
