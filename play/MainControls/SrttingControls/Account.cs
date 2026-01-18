using System;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.Tools;

namespace telltok.play.MainControls.SrttingControls {
    public partial class Account : UserControl {
        public Account() {
            InitializeComponent();
        }

        private void Security_Load(object sender, EventArgs e) {
            Tool.FontToAllControls(this);
            using (telltokEntities db = new telltokEntities()) {
                var userInfo = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
                label3.Text = $"{userInfo.u_id}@telltok.com";
                label4.Text = userInfo.u_birthdate.ToString("yyyy-MM-dd");
                label6.Text = $"{userInfo.u_friend_id:00000000}";
                label8.Text = userInfo.u_gender == 0 ? "공개 안함" : userInfo.u_gender == 1 ? "남성" : "여성";
            }
        }
    }
}
