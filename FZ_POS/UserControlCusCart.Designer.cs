
namespace FZ_POS
{
    partial class UserControlCusCart
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblNumThings = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCartPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FZ_POS.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lblShopName.Location = new System.Drawing.Point(124, 4);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(141, 37);
            this.lblShopName.TabIndex = 1;
            this.lblShopName.Text = "shopname";
            // 
            // lblNumThings
            // 
            this.lblNumThings.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lblNumThings.Location = new System.Drawing.Point(126, 40);
            this.lblNumThings.Name = "lblNumThings";
            this.lblNumThings.Size = new System.Drawing.Size(29, 36);
            this.lblNumThings.TabIndex = 2;
            this.lblNumThings.Text = "2 ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.label3.Location = new System.Drawing.Point(151, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "items  。$";
            // 
            // lblCartPrice
            // 
            this.lblCartPrice.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lblCartPrice.Location = new System.Drawing.Point(279, 40);
            this.lblCartPrice.Name = "lblCartPrice";
            this.lblCartPrice.Size = new System.Drawing.Size(98, 36);
            this.lblCartPrice.TabIndex = 4;
            this.lblCartPrice.Text = "120.00";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.label5.Location = new System.Drawing.Point(488, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 100);
            this.label5.TabIndex = 5;
            this.label5.Text = ">";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlCusCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCartPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumThings);
            this.Controls.Add(this.lblShopName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserControlCusCart";
            this.Size = new System.Drawing.Size(528, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblNumThings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCartPrice;
        private System.Windows.Forms.Label label5;
    }
}
