using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace telltok.play.MainControls.FriendControls {
	public partial class User : UserControl {

		public EventHandler ClickEvent;

		public User() {
			InitializeComponent();
		}

		int _UserNo;

		public int UserNo {
			set {
				if(value != 0) {
					_UserNo = value;
					using(telltokEntities db = new telltokEntities()) {
						var user = db.user.FirstOrDefault(x => x.u_no == value);
						label1.Text = user.u_name;
						label2.Text = user.u_status_text;
						profilePicture1.UserNo = value;
					}
				}
			}
			get {
				return _UserNo;
			}
		}

		private void label2_MouseEnter(object sender, System.EventArgs e) {
			BackColor = Color.LightGray;
		}

		private void label2_MouseLeave(object sender, System.EventArgs e) {
			BackColor = Color.White;
		}

		private void label2_Click(object sender, System.EventArgs e) {
			ClickEvent?.Invoke(sender, e);
		}
	}
}
