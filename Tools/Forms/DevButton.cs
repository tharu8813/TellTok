using System.Drawing;
using System.Windows.Forms;

namespace telltok.Tools.Forms {
	internal class DevButton : Button {
		public DevButton() {
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderColor = Color.Gray;
			BackColor = Tool.DevColorBrown;
			ForeColor = Color.White;
		}
	}
}
