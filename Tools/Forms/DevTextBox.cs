using System.Drawing;
using System.Windows.Forms;

namespace telltok.Tools.Forms {
	public partial class DevTextBox : TextBox {

		private string _subText;

		public string SubText {
			get {
				return _subText;
			}
			set {
				Text = value;
				_subText = value;
			}
		}

		public bool isTextNull => string.IsNullOrEmpty(Text) || (Text == _subText && ForeColor == Color.Gray);

		public void Reset() {
			if(Focused) {
				Text = "";
				ForeColor = Color.Black;
			} else {
				Text = SubText;
				ForeColor = Color.Gray;
			}
		}

		public DevTextBox() {
			BorderStyle = BorderStyle.FixedSingle;
			ForeColor = Color.Gray;

			Enter += DevTextBox_Enter;
			Leave += DevTextBox_Leave;

			Text = SubText;
		}

		public string SetText {
			set {
				ForeColor = Color.Black;
				Text = value.ToString();
			}
		}

		private void DevTextBox_Enter(object sender, System.EventArgs e) {
			if(ForeColor == Color.Gray) {
				ForeColor = Color.Black;
				Text = "";
			}
		}

		private void DevTextBox_Leave(object sender, System.EventArgs e) {
			if(Text == "") {
				ForeColor = Color.Gray;
				Text = SubText;
			}
		}

	}
}
