
namespace FZ_POS
{
    partial class UserControlMealMenu
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
            this.gboxMeal = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pbMeal = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gboxMeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxMeal
            // 
            this.gboxMeal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gboxMeal.Controls.Add(this.label1);
            this.gboxMeal.Controls.Add(this.lblPrice);
            this.gboxMeal.Controls.Add(this.pbMeal);
            this.gboxMeal.Controls.Add(this.btnAdd);
            this.gboxMeal.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxMeal.Location = new System.Drawing.Point(0, 0);
            this.gboxMeal.Name = "gboxMeal";
            this.gboxMeal.Size = new System.Drawing.Size(140, 160);
            this.gboxMeal.TabIndex = 4;
            this.gboxMeal.TabStop = false;
            this.gboxMeal.Text = "Meal Name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "$";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Location = new System.Drawing.Point(31, 130);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(63, 30);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "15.70";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbMeal
            // 
            this.pbMeal.Image = global::FZ_POS.Properties.Resources.哈囉豬;
            this.pbMeal.Location = new System.Drawing.Point(10, 20);
            this.pbMeal.Name = "pbMeal";
            this.pbMeal.Size = new System.Drawing.Size(120, 110);
            this.pbMeal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMeal.TabIndex = 1;
            this.pbMeal.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(100, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // UserControlMealMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.gboxMeal);
            this.Name = "UserControlMealMenu";
            this.Size = new System.Drawing.Size(140, 160);
            this.gboxMeal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gboxMeal;
        public System.Windows.Forms.Label lblPrice;
        public System.Windows.Forms.PictureBox pbMeal;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Label label1;
    }
}
