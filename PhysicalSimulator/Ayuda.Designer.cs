namespace PhysicalSimulator
{
    partial class Ayuda
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
            this.title = new System.Windows.Forms.Label();
            this.paso = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(190, 26);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(35, 13);
            this.title.TabIndex = 0;
            this.title.Text = "label1";
            // 
            // paso
            // 
            this.paso.Location = new System.Drawing.Point(35, 71);
            this.paso.Multiline = true;
            this.paso.Name = "paso";
            this.paso.ReadOnly = true;
            this.paso.Size = new System.Drawing.Size(351, 133);
            this.paso.TabIndex = 2;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(310, 226);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(76, 38);
            this.btn.TabIndex = 3;
            this.btn.Text = "button1";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(35, 226);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(77, 38);
            this.btn0.TabIndex = 4;
            this.btn0.Text = "button1";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 280);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.paso);
            this.Controls.Add(this.title);
            this.Name = "Ayuda";
            this.Text = "Ayuda";
            this.Load += new System.EventHandler(this.Ayuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox paso;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btn0;
    }
}