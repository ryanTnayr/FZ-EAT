
namespace FZ_POS
{
    partial class ucSideLabel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbtnCancel = new FZ_POS.CircleButton();
            this.lblSide = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbtnCancel);
            this.panel1.Controls.Add(this.lblSide);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 33);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // cbtnCancel
            // 
            this.cbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.cbtnCancel.FlatAppearance.BorderSize = 0;
            this.cbtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnCancel.ForeColor = System.Drawing.Color.Red;
            this.cbtnCancel.Location = new System.Drawing.Point(68, 0);
            this.cbtnCancel.Name = "cbtnCancel";
            this.cbtnCancel.Size = new System.Drawing.Size(30, 28);
            this.cbtnCancel.TabIndex = 1;
            this.cbtnCancel.TabStop = false;
            this.cbtnCancel.Text = "X";
            this.cbtnCancel.UseVisualStyleBackColor = false;
            this.cbtnCancel.Visible = false;
            this.cbtnCancel.MouseEnter += new System.EventHandler(this.cbtnCancel_MouseEnter);
            this.cbtnCancel.MouseLeave += new System.EventHandler(this.cbtnCancel_MouseLeave);
            // 
            // lblSide
            // 
            this.lblSide.AutoSize = true;
            this.lblSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSide.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSide.Location = new System.Drawing.Point(0, 0);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(68, 30);
            this.lblSide.TabIndex = 0;
            this.lblSide.Text = "label1";
            this.lblSide.MouseEnter += new System.EventHandler(this.lblSide_MouseEnter);
            this.lblSide.MouseLeave += new System.EventHandler(this.lblSide_MouseLeave);
            // 
            // ucSideLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "ucSideLabel";
            this.Size = new System.Drawing.Size(106, 36);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblSide;
        internal CircleButton cbtnCancel;
    }
}
