using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using ListViewSubItem = System.Windows.Forms.ListViewItem.ListViewSubItem;

namespace One.One
{
	public partial class ResolutionPicker : Form
	{
		/// <summary>
		/// Collection of all 32bit per pixel resolutions.
		/// </summary>
		private ICollection<DisplayMode> PermittedDisplayModes { get; set; }
		private DisplayMode SelectedDisplayMode { get; set; }

		public ResolutionPicker()
		{
			InitializeComponent();

			// Bgr32 is deprecated. Color seems to be a similar 32byte per pixel format
			PermittedDisplayModes = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes
				.Where(dm => dm.Format == SurfaceFormat.Color)
				.ToList();

			resolutionsLv.Columns.Add("Pixeldepth");
			resolutionsLv.Columns.Add("Width");
			resolutionsLv.Columns.Add("Height");
			foreach (var res in PermittedDisplayModes)
			{
				ListViewItem item = new ListViewItem();
				item.Tag = res;
				item.Text = res.Format.ToString();
				item.SubItems.Add(new ListViewSubItem(item, res.Width.ToString()));
				item.SubItems.Add(new ListViewSubItem(item, res.Height.ToString()));
				resolutionsLv.Items.Add(item);
			}
		}

		private void resolutionsLv_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (resolutionsLv.SelectedItems.Count > 0)
			{
				var selectedItem = resolutionsLv.SelectedItems[0];
				SelectedDisplayMode = (DisplayMode)selectedItem.Tag;
			}
			else
			{
				SelectedDisplayMode = null;
			}
		}
	}
}
