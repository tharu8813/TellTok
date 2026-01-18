using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.play.MainControls.UserProfileControls;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok.play {
    public partial class UserProfile : Tools.Form.DevForm {
        public UserProfile() {
            InitializeComponent();

            Tool.FontToAllControls(this);
        }

        bool isLever = false;

        private int _GetUserNo;

        public int GetUserNo {
            set {
                _GetUserNo = value;
                using (telltokEntities db = new telltokEntities()) {
                    var user = db.user.FirstOrDefault(x => x.u_no == value);
                    string path = $@"datafiles\UserBackground\{value}.jpg";
                    if (!File.Exists(path)) {
                        path = $@"datafiles\UserBackground\{value}.gif";
                    }
                    // 기존 이미지 해제 (메모리 누수 방지)
                    if (pictureBox1.Image != null) {
                        pictureBox1.Image.Dispose();
                    }

                    // 메모리에서 이미지 로드
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path))) {
                        pictureBox1.Image = new Bitmap(Image.FromStream(ms));
                    }
                    //pictureBox1.Image = image;
                    profilePicture1.UserNo = value;
                    label1.Text = user.u_name;
                    label2.Text = user.u_status_text;
                    Text = $"TellTok - 프로필 - {user.u_name}";
                }

                if (GetUserNo == Tool.UserNo) {
                    pictureBox3.Image = Properties.Resources.Profile_myInfo;
                    label4.Text = "프로필 수정";
                }

                UpdateLikeCount();
            }
            get {
                return _GetUserNo;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            using (Brush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0))) {
                g.FillRectangle(brush, pictureBox1.ClientRectangle);
            }
        }

        private void UserProFile_Load(object sender, EventArgs e) {
            Control[] control = new Control[] { profilePicture1, label1, label2, label3, label4, pictureBox2, pictureBox3 };
            foreach (Control c in control) {
                c.BackColor = Color.Transparent;
                c.Parent = pictureBox1;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e) {
            pictureBox2.Image = Properties.Resources.Profile_Like;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e) {
            if (GetUserNo != Tool.UserNo) {
                using (telltokEntities db = new telltokEntities()) {
                    var userLike = db.user.FirstOrDefault(x => x.u_no == GetUserNo);
                    userLike.u_like_count++;
                    db.SaveChanges();
                }
                UpdateLikeCount();
            } else {
                isLever = true;
                Tool.ShowError("자기 자신에게는 좋아요를 누를수 없습니다.");
                Activate();
                isLever = false;
            }
            pictureBox2.Image = Properties.Resources.Profile_Like_Click;
        }

        private void UpdateLikeCount() {
            using (telltokEntities db = new telltokEntities()) {
                var user = db.user.FirstOrDefault(x => x.u_no == GetUserNo);
                label3.Text = user.u_like_count.ToString("#,###") + "개";
            }
        }

        private void UserProfile_Deactivate(object sender, EventArgs e) {
            if (!isLever) {
                Close();
                Tool.MainFormManager.Activate();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            if (GetUserNo != Tool.UserNo) {
                using (telltokEntities db = new telltokEntities()) {
                    var userFriendList = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo).u_friend.Split(',').ToList();
                    isLever = true;
                    if (userFriendList.Contains(GetUserNo.ToString())) {
                        Chat chat = new Chat();
                        chat.UpdateChat(Tool.UserNo, GetUserNo);
                        Tool.OpenFormRelativeToParent(Tool.MainFormManager, chat, FormPosition.Right);
                        Console.WriteLine("yy");
                    } else {
                        Tool.ShowError("해당 유저와 친구가 아닙니다.");
                        Console.WriteLine("nn");
                    }
                    isLever = false;
                }
            } else {
                EditProfile editProfile = new EditProfile();
                editProfile.UserNo = Tool.UserNo;
                Tool.OpenFormRelativeToParent(Tool.MainFormManager, editProfile, FormPosition.Left);
            }
        }
    }
}
