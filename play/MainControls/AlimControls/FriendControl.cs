using System;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.Tools;

namespace telltok.play.MainControls.AlimControls {
    public partial class FriendControl : UserControl {
        public FriendControl() {
            InitializeComponent();
        }

        public EventHandler YesEvent;
        public EventHandler NoEvent;

        int _GetAlimNo;

        public int GetAlimNo {
            set {
                _GetAlimNo = value;
                int userNo = 0;
                using (telltokEntities db = new telltokEntities()) {
                    var alim = db.alim.FirstOrDefault(x => x.a_no == value);
                    var addFriendNo = alim?.add_friend;
                    if (addFriendNo == null) {
                        return;
                    }
                    profilePicture1.UserNo = addFriendNo.af_go;
                    label2.Text = addFriendNo.user.u_name;
                    label3.Text = alim.a_date.ToString("g");

                    userNo = addFriendNo.af_go;
                }
            }
            get {
                return _GetAlimNo;
            }
        }

        private void button1_Click(object sender, System.EventArgs e) {
            using (telltokEntities db = new telltokEntities()) {
                var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
                if (user != null) {
                    var friendList = user.u_friend?.Split(',').ToList();
                    friendList.Add(db.alim.FirstOrDefault(x => x.a_no == GetAlimNo).add_friend.af_go.ToString());
                    friendList.Sort();
                    user.u_friend = string.Join(",", friendList);
                }

                var e_user = db.user.FirstOrDefault(x => x.u_no == db.alim.FirstOrDefault(a => a.a_no == GetAlimNo).add_friend.af_go);
                if (e_user != null) {
                    var friendList = e_user.u_friend?.Split(',').ToList();
                    friendList.Add(Tool.UserNo.ToString());
                    friendList.Sort();
                    e_user.u_friend = string.Join(",", friendList);
                }

                var addfriend = db.alim.FirstOrDefault(x => x.a_no == GetAlimNo);

                db.add_friend.Remove(addfriend.add_friend);
                db.alim.Remove(addfriend);

                db.SaveChanges();
            }
            YesEvent?.Invoke(sender, e);
        }

        private void button2_Click(object sender, System.EventArgs e) {
            using (telltokEntities db = new telltokEntities()) {
                var addfriend = db.alim.FirstOrDefault(x => x.a_no == GetAlimNo);

                db.add_friend.Remove(addfriend.add_friend);
                db.alim.Remove(addfriend);
                db.SaveChanges();
            }
            NoEvent?.Invoke(sender, e);
        }
    }
}
