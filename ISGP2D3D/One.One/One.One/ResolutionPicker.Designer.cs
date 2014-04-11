namespace One.One
{
	partial class ResolutionPicker
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
			this.resolutionsDgv = new System.Windows.Forms.DataGridView();
			this.selectBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.resolutionsDgv)).BeginInit();
			this.SuspendLayout();
			// 
			// resolutionsDgv
			// 
			this.resolutionsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.resolutionsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.resolutionsDgv.Location = new System.Drawing.Point(12, 12);
			this.resolutionsDgv.Name = "resolutionsDgv";
			this.resolutionsDgv.Size = new System.Drawing.Size(249, 253);
			this.resolutionsDgv.TabIndex = 0;
			// 
			// selectBtn
			// 
			this.selectBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.selectBtn.Location = new System.Drawing.Point(95, 280);
			this.selectBtn.MaximumSize = new System.Drawing.Size(86, 23);
			this.selectBtn.Name = "selectBtn";
			this.selectBtn.Size = new System.Drawing.Size(86, 23);
			this.selectBtn.TabIndex = 1;
			this.selectBtn.Text = "Select";
			this.selectBtn.UseVisualStyleBackColor = true;
			// 
			// ResolutionPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(273, 315);
			this.Controls.Add(this.selectBtn);
			this.Controls.Add(this.resolutionsDgv);
			this.Name = "ResolutionPicker";
			this.Text = "Resolutions";
			((System.ComponentModel.ISupportInitialize)(this.resolutionsDgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView resolutionsDgv;
		private System.Windows.Forms.Button selectBtn;
	}
}