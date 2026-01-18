using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.play;
using static telltok.Tools.Tool;

namespace telltok.Tools.UserControls {
    public partial class ProfilePicture : UserControl {

        public ProfilePicture() {
            InitializeComponent();
        }
        int _UserNo = 0;
        bool _isClickProFIleForm = false;

        public int UserNo {
            get {
                return _UserNo;
            }
            set {
                if (value == 0) return;
                _UserNo = value;
                using (telltokEntities db = new telltokEntities())
                    pictureBox1.Image = Tool.CreateRoundedImage(Tool.GetByteToImage(db.user.FirstOrDefault(x => x.u_no == value).u_profile_image), 800);
            }
        }

        public bool isClickProFIleForm {
            get {
                return _isClickProFIleForm;
            }
            set {
                _isClickProFIleForm = value;
                pictureBox1.Cursor = value ? Cursors.Hand : Cursors.Default;
            }
        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {
            if (isClickProFIleForm) {
                UserProfile userProFile = new UserProfile();
                userProFile.GetUserNo = UserNo;
                Tool.OpenFormRelativeToParent(Tool.MainFormManager, userProFile, FormPosition.Left);
            }
        }
    }
}
