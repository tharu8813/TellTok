using System;
using telltok.Tools;

namespace telltok.play.MainControls.SrttingControls {
	public partial class LockModSetPassword : telltok.Tools.Form.DevForm {
		public LockModSetPassword() {
			InitializeComponent();

			DialogResult = System.Windows.Forms.DialogResult.No;
		}

		string _ReseultPassword = "";

		public string ReseultPassword {
			get {
				return _ReseultPassword;
			}
			set {
				_ReseultPassword = value;
			}
		}

		private void maskedTextBox1_TextChanged(object sender, EventArgs e) {
			if(maskedTextBox1.Text.Replace("_", "").Length >= 4 && maskedTextBox2.Text.Replace("_", "").Length >= 4) {
				devButton1.Enabled = true;
			} else {
				devButton1.Enabled = false;
			}
		}

		private void devButton1_Click(object sender, EventArgs e) {
			if(maskedTextBox1.Text.Replace("_", "").Equals(maskedTextBox2.Text.Replace("_", ""))) {
				_ReseultPassword = maskedTextBox1.Text.Replace("_", "");
				Dispose();
				DialogResult = System.Windows.Forms.DialogResult.Yes;
			} else {
				Tool.ShowError("암호가 확인란과 일치하지 않습니다.");
				maskedTextBox1.Text = "";
				maskedTextBox2.Text = "";
			}
		}

		private void LockModSetPassword_Load(object sender, EventArgs e) {
			Tool.FontToAllControls(this);
		}
	}
}
