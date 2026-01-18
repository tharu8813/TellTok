using System;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok.play.MainControls {
    public partial class And : UserControl {
        public And() {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {
            Setting setting = new Setting();
            Tool.OpenFormRelativeToParent(Tool.MainFormManager, setting, FormPosition.Left);
        }

        private void pictureBox2_Click(object sender, System.EventArgs e) {
            Alim alim = new Alim();
            Tool.OpenFormRelativeToParent(Tool.MainFormManager, alim, FormPosition.Left);
        }

        private void And_Load(object sender, EventArgs e) {
            using (telltokEntities db = new telltokEntities()) {
                var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);

                profilePicture1.UserNo = Tool.UserNo;
                label1.Text = user.u_name;
                label2.Text = $"{user.u_id}@telltok.com";
                label6.Text = $"포인트: {user.u_tellpay:#,###}원";
            }
        }
    }
}
