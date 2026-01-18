using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok.play {
	public partial class Login : Tools.Form.DevForm {

		bool isLoginPlay = false;

		public Login() {
			InitializeComponent();

			toolStripItem[2].Click += (se, ex) => {
				CloesedAllTagWinForm();
				ShowLockMod();
			};
			toolStripItem[3].Click += (se, ex) => {
				LogOut();
			};

			Tool.LoginFormManager = this;
		}

		/// <summary>
		/// 로그아웃
		/// </summary>
		public void LogOut() {
			CloesedAllTagWinForm();
			Properties.Settings.Default.LoginUserNo = 0;
			Properties.Settings.Default.LockModPassword = "";
			Properties.Settings.Default.Save();

			ShowLoginMod();
		}

		private void Login_Load(object sender, EventArgs e) {
			FontToAllControls(this);

			ShowLoginMod();

			toolTip1.SetToolTip(checkBox1, "TellTok 실행시 로그인된 상태로 실행합니다.");
			LoginErrorUIUpdate("", false);
			LockErrorUIUpdate("", false);
		}

		/// <summary>
		/// 잠금모드를 표시합니다.
		/// </summary>
		private void ShowLockMod() {
			notifyIcon.Icon = Properties.Resources.Lock_mode_icon;
			maskedTextBox1.Text = "";
			using(telltokEntities db = new telltokEntities()) {
				var LoginUser = db.user.FirstOrDefault(x => x.u_no == Properties.Settings.Default.LoginUserNo);
				Console.WriteLine(LoginUser.u_id + "진행");
				label4.Text = $"{LoginUser.u_id}@telltok.com";
				profilePicture1.UserNo = LoginUser.u_no;

				Text = "TellTok - 잠금모드";
				maskedTextBox1.Focus();
				panel1.Visible = false;
				panel2.Visible = true;
			}
		}

		/// <summary>
		/// 로그인 모드로 변경합니다.
		/// </summary>
		private void ShowLoginMod() {
			notifyIcon.Icon = Properties.Resources.black_icon;
			Text = "TellTok - 로그인";
			checkBox1.Checked = false;
			devTextBox1.Reset();
			devTextBox2.Reset();

			if(Properties.Settings.Default.LoginUserNo != 0) {
				using(telltokEntities db = new telltokEntities()) {
					var LoginUser = db.user.FirstOrDefault(x => x.u_no == Properties.Settings.Default.LoginUserNo);
					checkBox1.Checked = true;
					devTextBox1.Focus();
					devTextBox1.Text = LoginUser.u_id;
					devTextBox2.Focus();
					devTextBox2.Text = LoginUser.u_pw;
					LoginStart();
				}
			}

			panel1.Visible = true;
			panel2.Visible = false;
		}

		/// <summary>
		/// 로그인 UI를 활성화하거나 비활성화합니다.
		/// </summary>
		/// <param name="en">활성화 여부</param>
		private void LoginUIStop(bool en) {
			devTextBox1.Enabled = en;
			devTextBox2.Enabled = en;
			checkBox1.Enabled = en;
			if(en) {
				devButton1.Image = null;
				devButton1.Text = "로그인";
			} else {
				devButton1.Image = Properties.Resources.login_loding;
				devButton1.Text = "";
			}
		}

		/// <summary>
		/// textbox 포커스후 엔터를 누를시 로그인을 시도합니다.
		/// </summary>
		private void devTextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			button1.ForeColor = Tool.DevColorOrange;
			label1.ForeColor = Tool.DevColorOrange;
			if(e.KeyChar == (char)Keys.Enter) {
				LoginStart();
			}
		}

		/// <summary>
		/// 로그인 애러 메세지를 표시합니다.
		/// </summary>
		/// <param name="text">표시할 텍스트</param>
		/// <param name="value">표시 여부</param>
		private void LoginErrorUIUpdate(string text, bool value) {
			label1.Text = text;
			button1.ForeColor = value == true ? Color.Red : Tool.DevColorOrange;
			label1.ForeColor = value == true ? Color.Red : Tool.DevColorOrange;
		}

		/// <summary>
		/// 로그인을 시도합니다.
		/// </summary>
		private async void LoginStart() {
			if(isLoginPlay) return;
			// 로그인 중 처리
			LoginUIStop(false); // 버튼 비활성화
			isLoginPlay = true;

			// 로그인 처리를 비동기적으로 진행
			await Task.Delay(1000);

			using(telltokEntities db = new telltokEntities()) {
				var user = db.user.FirstOrDefault(x => x.u_id.Equals(devTextBox1.Text) && x.u_pw.Equals(devTextBox2.Text));

				if(user != null) {
					LoginErrorUIUpdate("", false);
					if(checkBox1.Checked) {
						Properties.Settings.Default.LoginUserNo = user.u_no;
						Properties.Settings.Default.Save();
					} else {
						Properties.Settings.Default.LoginUserNo = 0;
						Properties.Settings.Default.Save();
					}
					Tool.UserNo = user.u_no;
					if(Properties.Settings.Default.LockModPassword.Equals("")) {
						Hide();
						new MainForm().Show();
					} else {
						ShowLockMod();
					}

				} else {
					LoginErrorUIUpdate("비밀번호가 일치하지 않습니다. 확인 후 다시 시도 해 주세요.", true);
				}
			}

			LoginUIStop(true);  // UI 활성화
			devButton1.Enabled = true; // 로그인 종료
			isLoginPlay = false;
		}

		/// <summary>
		/// 로그인 버튼을 클릭시 이벤트를 발생시킵니다.
		/// </summary>
		private void devButton1_Click_1(object sender, EventArgs e) {
			if(devButton1.BackColor == Color.Gray) {
				return;
			}
			LoginStart();
		}

		//================================================================================
		//잠금모드 코드 ==================================================================
		//================================================================================

		/// <summary>
		/// 잠금모드 UI를 활성화 또는 비활성화합니다.
		/// </summary>
		/// <param name="en"></param>
		private void LockUIStop(bool en) {
			maskedTextBox1.Enabled = en;
		}

		/// <summary>
		/// 잠금모드 에러 메세지를 표시합니다.
		/// </summary>
		/// <param name="text">표시할 텍스트</param>
		/// <param name="value">표시 여부</param>
		private void LockErrorUIUpdate(string text, bool value) {
			label3.Text = text;
			button2.ForeColor = value == true ? Color.Red : Tool.DevColorOrange;
			label3.ForeColor = value == true ? Color.Red : Tool.DevColorOrange;
		}

		/// <summary>
		/// maskedTextBox에 text 가 변경될때마다 이벤트를 발생시킵니다. 만약 maskedTextBox 가 4글자를 넘으면 잠금모드 해제를 시도합니다.
		/// </summary>
		private async void maskedTextBox1_TextChanged(object sender, EventArgs e) {
			LockErrorUIUpdate("", false);

			if(Regex.Replace(maskedTextBox1.Text, @"\s", "").Length >= 4) {
				LockUIStop(false);
				await Task.Delay(100);
				LockTest();
				LockUIStop(true);

			}
		}

		/// <summary>
		/// 잠금모드 해제를 시도합니다.
		/// </summary>
		private void LockTest() {
			if(Properties.Settings.Default.LockModPassword.Equals(Regex.Replace(maskedTextBox1.Text, @"\s", ""))) {
				Hide();
				new MainForm().Show();
			} else {
				maskedTextBox1.Text = "";
				LockErrorUIUpdate("잠금모드 암호가 일치하지 않습니다.", true);
			}
		}

		/// <summary>
		/// 잠금모드 초기화 관련 메서드입니다.
		/// </summary>
		private void label5_Click(object sender, EventArgs e) {
			if(ShowQuestion("현재 로그인중인 계정에서 로그아웃하고 잠금모드 상태를 초기화합니다. 다시 로그인후 설정에서 설정 가능합니다. 계속하시겠습니까?")) {
				Properties.Settings.Default.LoginUserNo = 0;
				Properties.Settings.Default.LockModPassword = "";
				Properties.Settings.Default.Save();

				ShowLoginMod();
			}
		}

		private void Login_Shown(object sender, EventArgs e) {
			toolStripItem[1].Enabled = true; //실행
			toolStripItem[2].Enabled = false; //잠금모드
			toolStripItem[3].Enabled = false; //로그아웃
			toolStripItem[4].Enabled = true; //프로그램 종료
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}

		private void Login_VisibleChanged(object sender, EventArgs e) {
			toolStripItem[1].Enabled = true; //실행
			toolStripItem[2].Enabled = false; //잠금모드
			toolStripItem[3].Enabled = false; //로그아웃
			toolStripItem[4].Enabled = true; //프로그램 종료
		}
	}
}
