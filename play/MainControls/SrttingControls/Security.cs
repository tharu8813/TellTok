using System;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.SrttingControls {
	public partial class Security : UserControl {
		private bool isCheckboxNoEvent = false;

		public Security() {
			InitializeComponent();
		}

		private void Security_Load(object sender, EventArgs e) {
			InitializeCheckBoxStates();

			Tool.FontToAllControls(this);
		}

		private void InitializeCheckBoxStates() {
			// 로그인 상태에 따라 체크박스 초기화
			CheckBoxNoEvent(checkBox1, !Properties.Settings.Default.LoginUserNo.ToString().Equals("0"));
			CheckBoxNoEvent(checkBox2, !string.IsNullOrEmpty(Properties.Settings.Default.LockModPassword));
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			if(isCheckboxNoEvent) return;

			if(checkBox1.Checked) {
				EnableLogin();
			} else {
				DisableLoginWithConfirmation();
			}
		}

		private void EnableLogin() {
			Properties.Settings.Default.LoginUserNo = Tool.UserNo;
			Properties.Settings.Default.Save();
			EnableCheckBox(checkBox2, true);
		}

		private void DisableLoginWithConfirmation() {
			if(!string.IsNullOrEmpty(Properties.Settings.Default.LockModPassword) &&
				!Tool.ShowQuestion("계속 진행 시 잠금모드 비밀번호가 초기화됩니다. 진행하시겠습니까?")) {
				CheckBoxNoEvent(checkBox1, true);
				return;
			}

			Properties.Settings.Default.LoginUserNo = 0;
			Properties.Settings.Default.LockModPassword = string.Empty;
			Properties.Settings.Default.Save();
			EnableCheckBox(checkBox2, false);
			Tool.toolStripItem[3].Enabled = false;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e) {
			if(isCheckboxNoEvent) return;

			if(checkBox2.Checked) {
				SetLockPassword();
			} else {
				RemoveLockPasswordWithConfirmation();
			}
		}

		private void SetLockPassword() {
			var lockModSetPassword = new LockModSetPassword();
			lockModSetPassword.ShowDialog();

			if(lockModSetPassword.DialogResult == DialogResult.Yes) {
				Properties.Settings.Default.LockModPassword = lockModSetPassword.ReseultPassword;
				Properties.Settings.Default.Save();
				CheckBoxNoEvent(checkBox2, true);
				Tool.toolStripItem[2].Enabled = true;
			} else {
				CheckBoxNoEvent(checkBox2, false);
			}
		}

		private void RemoveLockPasswordWithConfirmation() {
			if(Tool.ShowQuestion("계속 진행 시 잠금모드 비밀번호가 초기화됩니다. 진행하시겠습니까?")) {
				Properties.Settings.Default.LockModPassword = string.Empty;
				Properties.Settings.Default.Save();
				CheckBoxNoEvent(checkBox2, false);
				Tool.toolStripItem[3].Enabled = false;
			} else {
				CheckBoxNoEvent(checkBox2, true);
			}
		}

		private void CheckBoxNoEvent(CheckBox checkBox, bool isChecked) {
			isCheckboxNoEvent = true;
			checkBox.Checked = isChecked;
			isCheckboxNoEvent = false;
		}

		private void EnableCheckBox(CheckBox checkBox, bool isEnabled) {
			checkBox.Enabled = isEnabled;
			CheckBoxNoEvent(checkBox, false);
		}
	}
}
