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
			this.selectBtn = new System.Windows.Forms.Button();
			this.resolutionsLv = new System.Windows.Forms.ListView();
			this.SuspendLayout();
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
			this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
			// 
			// resolutionsLv
			// 
			this.resolutionsLv.FullRowSelect = true;
			this.resolutionsLv.GridLines = true;
			this.resolutionsLv.Location = new System.Drawing.Point(12, 12);
			this.resolutionsLv.Name = "resolutionsLv";
			this.resolutionsLv.Size = new System.Drawing.Size(249, 262);
			this.resolutionsLv.TabIndex = 2;
			this.resolutionsLv.UseCompatibleStateImageBehavior = false;
			this.resolutionsLv.View = System.Windows.Forms.View.Details;
			this.resolutionsLv.SelectedIndexChanged += new System.EventHandler(this.resolutionsLv_SelectedIndexChanged);
			// 
			// ResolutionPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(273, 315);
			this.Controls.Add(this.resolutionsLv);
			this.Controls.Add(this.selectBtn);
			this.Name = "ResolutionPicker";
			this.Text = "Resolutions";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button selectBtn;
		private System.Windows.Forms.ListView resolutionsLv;
	}
}