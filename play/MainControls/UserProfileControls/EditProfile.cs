using System.Linq;
using telltok.Tools;

namespace telltok.play.MainControls.UserProfileControls {
	public partial class EditProfile : telltok.Tools.Form.DevForm {
		public EditProfile() {
			InitializeComponent();

			Tool.FontToAllControls(this);
		}

		public int UserNo {
			set {
				using(telltokEntities db = new telltokEntities()) {
					var user = db.user.FirstOrDefault(x => x.u_no == value);
					profilePicture1.UserNo = user.u_no;

					devTextBox1.SetText = user.u_name;
					devTextBox2.SetText = user.u_status_text;

				}
			}
		}

		private void devButton2_Click(object sender, System.EventArgs e) {
			Dispose();
		}

		private void devButton1_Click(object sender, System.EventArgs e) {
			if(Tool.ShowQuestion("입력한 내용으로 프로필이 변경됩니다. 계속하시겠습니까?")) {
				using(telltokEntities db = new telltokEntities()) {
					var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
					user.u_name = devTextBox1.Text;
					user.u_status_text = devTextBox2.Text;
					db.SaveChanges();
				}
				Tool.ShowInfo("변경되었습니다.");
				Dispose();
			}
		}

		private void devTextBox1_TextChanged(object sender, System.EventArgs e) {
			if(devTextBox1.isTextNull || devTextBox2.isTextNull) {
				devButton1.Enabled = false;
			} else {
				devButton1.Enabled = true;
			}
		}
	}
}
