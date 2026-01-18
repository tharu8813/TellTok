using System;
using System.Drawing;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.ChatControls {
    public partial class ChatList : UserControl {

        public EventHandler ChatListClick;

        public ChatList() {
            InitializeComponent();
        }

        public string ChatUserName {
            get {
                return label1.Text;
            }
            set {
                label1.Text = value;
            }
        }
        public string ChatText {
            get {
                return label2.Text;
            }
            set {
                string text = value;
                if (text.Length > 20) {
                    text = text.Substring(0, 20) + "...";
                }
                label2.Text = text;
            }
        }

        public DateTime ChatDate {
            set {
                string text = "";
                DateTime today = Tool.now;

                if (value.Date == today.Date) {
                    text = $"{(today.Hour < 12 ? "오전" : "오후")}{value:hh:mm}";
                } else if (value.Date == today.AddDays(-1).Date) {
                    text = "어제";
                } else {
                    text = value.ToString("yyyy-MM-dd");
                }
                label3.Text = text;
            }
        }

        public int ProfileUserNo {
            set {
                profilePicture1.UserNo = value;
            }
        }

        private void label2_MouseEnter_1(object sender, EventArgs e) {
            BackColor = Color.LightGray;
        }

        private void label2_MouseLeave_1(object sender, EventArgs e) {
            BackColor = Color.White;
        }

        private void profilePicture1_Click(object sender, EventArgs e) {
            ChatListClick?.Invoke(this, e);
        }
    }
}
