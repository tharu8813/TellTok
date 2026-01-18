using System.Linq;
using telltok.db;
using telltok.Tools;

namespace telltok.play.MainControls.ChatControls {
    public partial class ChatEdit : telltok.Tools.Form.DevForm {
        public ChatEdit() {
            InitializeComponent();
        }

        int _ChatGoUserNo;

        public int ChatGoUserNo {
            set {
                _ChatGoUserNo = value;
                using (telltokEntities db = new telltokEntities()) {
                    devTextBox1.SetText = db.chat?.FirstOrDefault(x => x.c_no == value).c_message;
                }
            }
            get {
                return _ChatGoUserNo;
            }
        }

        private void devButton1_Click(object sender, System.EventArgs e) {
            if (devTextBox1.isTextNull) {
                Tool.ShowError("내용을 입력해주세요.");
                return;
            }
            if (Tool.ShowQuestion("수정하시겠습니까?")) {
                using (telltokEntities db = new telltokEntities()) {
                    var chat = db.chat.FirstOrDefault(x => x.c_no == ChatGoUserNo);
                    chat.c_message = devTextBox1.Text;
                    db.SaveChanges();
                }
                Tool.ShowInfo("수정되었습니다.");
                Close();
            }
        }

        private void ChatEdit_Load(object sender, System.EventArgs e) {
            Tool.FontToAllControls(this);
        }
    }
}
