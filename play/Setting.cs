using System;
using System.Drawing;
using System.Windows.Forms;
using telltok.play.MainControls.SrttingControls;
using telltok.Tools;

namespace telltok.play {
	public partial class Setting : telltok.Tools.Form.DevForm {

		int selectMenuButtonIndex = 0;

		Button[] menuButton = new Button[4];
		public Setting() {
			InitializeComponent();
			menuButton = new Button[] {
				button1,
				button2,
				button3
			};
		}

		private int GetSelectButtonIndex(Button button) {
			return Array.IndexOf(menuButton, button);
		}

		private void button4_Click(object sender, EventArgs e) {
			foreach(Button b in menuButton)
				b.BackColor = Color.White;

			Button button = (Button)sender;
			button.BackColor = Color.LightGray;
			selectMenuButtonIndex = GetSelectButtonIndex(button);
			label1.Text = button.Text;
			SetPanel();
		}

		private void SetPanel() {
			panel2.Controls.Clear();
			if(selectMenuButtonIndex == 0) {
				Account account = new Account() {
					Dock = DockStyle.Fill,
					AutoScroll = true
				};
				panel2.Controls.Add(account);
			} else if(selectMenuButtonIndex == 1) {
				//보안
				Security security = new Security() {
					Dock = DockStyle.Fill,
					AutoScroll = true
				};
				panel2.Controls.Add(security);
			} else if(selectMenuButtonIndex == 2) {
				//채팅방
				ChatOption chatOption = new ChatOption() {
					Dock = DockStyle.Fill,
					AutoScroll = true
				};
				panel2.Controls.Add(chatOption);
			} else if(selectMenuButtonIndex == 3) {
				//프로그램 정보
			}
		}

		private void Setting_Load(object sender, EventArgs e) {
			Tool.FontToAllControls(this);
			SetPanel();
			label1.Text = "계정";
		}
	}
}
