using System;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.play.MainControls.FriendControls;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok.play.MainControls {
    public partial class Friend : UserControl {
        public Friend() {
            InitializeComponent();
        }

        private void Friend_Load(object sender, EventArgs e) {
            using (telltokEntities db = new telltokEntities()) {
                var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
                user1.UserNo = user.u_no;
            }

            Play();
        }

        private void Play() {
            if (!DesignMode) {
                using (telltokEntities db = new telltokEntities()) {
                    var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
                    if (user == null) return;

                    var friend = user.u_friend?.Split(',') ?? Array.Empty<string>();
                    var friend_fix = user.u_friend_fix?.Split(',') ?? Array.Empty<string>();

                    AddFriendList(friend, flowLayoutPanel3);
                    AddFriendList(friend_fix, flowLayoutPanel2);
                }
            }
        }

        private void AddFriendList(string[] friendIds, FlowLayoutPanel panel) {
            using (telltokEntities db = new telltokEntities()) {
                foreach (var f in friendIds) {
                    if (int.TryParse(f, out int u_no_int)) {
                        var _friend = db.user.FirstOrDefault(x => x.u_no == u_no_int);
                        if (_friend != null) {
                            User userControl = new User();
                            userControl.UserNo = _friend.u_no;
                            int i = _friend.u_no;
                            userControl.ClickEvent += (se, ex) => {
                                Chat chat = new Chat();
                                chat.UpdateChat(Tool.UserNo, i);
                                Tool.OpenFormRelativeToParent(Tool.MainFormManager, chat, FormPosition.Right);
                            };
                            panel.Controls.Add(userControl);
                        }
                    }
                }
            }
        }
    }
}
