using System.Linq;
using telltok.play.MainControls.AlimControls;
using telltok.Tools;

namespace telltok.play {
	public partial class Alim : telltok.Tools.Form.DevForm {
		public Alim() {
			InitializeComponent();
		}

		private void UpdateAlim() {
			using(telltokEntities db = new telltokEntities()) {
				var alim = db.alim.Where(x => x.add_friend.af_take == Tool.UserNo).ToList();

				flowLayoutPanel1.Controls.Clear();
				foreach(var a in alim) {
					if(a.af_no != null) {
						FriendControl alimListControl = new FriendControl() {
							GetAlimNo = a.a_no,
						};

						alimListControl.YesEvent += (se, ex) => {
							UpdateAlim();
						};

						alimListControl.NoEvent += (se, ex) => {
							UpdateAlim();
						};

						flowLayoutPanel1.Controls.Add(alimListControl);
					}
				}
				label2.Text = $"총 {alim.Count}개의 알림이 왔습니다.";
			}
			Tool.FontToAllControls(this);
		}


		private void Alim_Load(object sender, System.EventArgs e) {
			Tool.FontToAllControls(this);
			UpdateAlim();
		}
	}
}
