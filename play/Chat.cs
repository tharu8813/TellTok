using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.play.MainControls.ChatControls;
using telltok.Tools;

namespace telltok.play {
    public partial class Chat : telltok.Tools.Form.DevForm {

        int ChatGroupNo;
        int _TakeUserNo = 0;
        int _GoUserNo = 0;

        EmoticonSelect emoticonSelect = null;

        public Chat() {
            InitializeComponent();
        }

        public int TakeUserNo {
            set {
                _TakeUserNo = value;
                using (telltokEntities db = new telltokEntities()) {
                    var user = db.user.FirstOrDefault(x => x.u_no == value);

                    profilePicture1.UserNo = user.u_no; ;
                    label1.Text = user.u_name;
                    Text = "TellTok - 채팅방 - " + user.u_name;
                }
            }
            get {
                return _TakeUserNo;
            }
        }

        public int GoUserNo {
            set {
                _GoUserNo = value;
            }
            get {
                return _GoUserNo;
            }
        }

        public void UpdateChat(int goNo, int takeNo) {
            GoUserNo = goNo;
            TakeUserNo = takeNo;

            tableLayoutPanel1.Controls.Clear();

            using (telltokEntities db = new telltokEntities()) {
                var groupNoList = db.chat.FirstOrDefault(x => (x.c_go == Tool.UserNo && x.c_take == takeNo) || (x.c_go == takeNo && x.c_take == Tool.UserNo));
                if (groupNoList == null) return;

                var groupNo = groupNoList.cg_no;
                ChatGroupNo = groupNo;
                List<DateTime> d = new List<DateTime>();
                var chat = db.chat.Where(x => x.cg_no == groupNo).OrderBy(x => x.c_date);
                foreach (var i in chat) {
                    if (!d.Contains(i.c_date.Date)) {
                        Dateline dateline = new Dateline() {
                            Date = i.c_date.Date,
                            Dock = DockStyle.Fill
                        };
                        tableLayoutPanel1.Controls.Add(dateline);
                    }
                    d.Add(i.c_date.Date);
                    Console.WriteLine($"전송 내역 : [전송: {i.c_go} / 받음: {i.c_take}/ 내용: {i.c_message}]");

                    if (i.c_go == Tool.UserNo) {
                        ChatGo chatGo = new ChatGo() {
                            AutoSize = true,
                            Dock = DockStyle.Right,
                            Chat = this
                        };
                        chatGo.ChatUserInfoNo = new int[] { i.c_go, i.c_take };
                        chatGo.ChatGoUserNo = i.c_no;
                        tableLayoutPanel1.Controls.Add(chatGo);
                    } else {
                        ChatTake chatTake = new ChatTake() {
                            AutoSize = true,
                            Dock = DockStyle.Left,
                        };
                        chatTake.ChatTakeNo = i.c_no;

                        tableLayoutPanel1.Controls.Add(chatTake);
                    }
                }
                tableLayoutPanel1.Controls.Add(new Panel() { AutoSize = true, Dock = DockStyle.Fill });
                tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.VerticalScroll.Maximum;
            }
            Tool.isChatListChange = true;
            Tool.FontToAllControls(this);
        }

        public void GoEmoticonAndChat(int e_no) {
            GoChat(null, e_no);
        }

        Color GetContrastTextColor(Color bgColor) {
            double luminance = (0.3 * bgColor.R) + (0.6 * bgColor.G) + (0.1 * bgColor.B);
            return luminance >= 128 ? Color.Black : Color.White;
        }

        private void Chat_Load(object sender, EventArgs e) {
            Tool.FontToAllControls(this);
            tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.VerticalScroll.Maximum;

            trackBar1.Value = Properties.Settings.Default.ChatOpacity;
            UpdateOpacity();
            UpdateSkin();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

            var formList = Application.OpenForms
                .OfType<Form>()
                .Where(f => f.Text == Text)
                .ToList();

            if (formList.Count > 1) {
                for (int i = 1; i < formList.Count; i++) {
                    formList[i].Close();
                }
                formList[0].Focus();

                if (formList[0].WindowState == FormWindowState.Minimized) {
                    formList[0].WindowState = FormWindowState.Normal;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            trackBar1.Value = Properties.Settings.Default.ChatOpacity;
            UpdateOpacity();
            UpdateSkin();
        }
        private void UpdateSkin() {
            Color backcolor = Properties.Settings.Default.ChatBackColor;

            panel3.BackColor = backcolor;
            tableLayoutPanel1.BackColor = backcolor;

            ForeColor = GetContrastTextColor(backcolor);
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            UpdateOpacity();
        }

        private void UpdateOpacity() {
            Properties.Settings.Default.ChatOpacity = trackBar1.Value;
            Properties.Settings.Default.Save();
            try {
                Opacity = Properties.Settings.Default.ChatOpacity / 100.00;
            } catch (Exception) {
            }
        }

        private void devTextBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
                button1.ForeColor = Color.Green;
            } else {
                e.Effect = DragDropEffects.None;
                button1.ForeColor = Color.Red;
            }
        }

        private void devTextBox1_DragLeave(object sender, EventArgs e) {
            button1.ForeColor = Color.White;
        }

        private void devTextBox1_DragDrop(object sender, DragEventArgs e) {
            button1.ForeColor = Color.White;

            // 드롭된 파일 경로 가져오기
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                FileSaveDB(files.FirstOrDefault());
            }
        }

        private void FileSaveDB(string path) {
            if (Tool.ShowQuestion($"해당 파일과 함께 메세지를 전송하시겠습니까?\n\n파일 경로: {path}\n메세지: {(devTextBox1.ForeColor != Color.Black ? "" : devTextBox1.Text)}")) {
                using (telltokEntities db = new telltokEntities()) {
                    var file = new file() {
                        f_no = 0,
                        f_name = Path.GetFileName(path),
                    };
                    db.file.Add(file);
                    db.SaveChanges();

                    File.Copy(path, $@"{Application.StartupPath}\datafiles\file\{file.f_no}{Path.GetExtension(path)}");

                    GoChat(file.f_no, null);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                FileSaveDB(openFileDialog1.FileName);
            }
        }

        private void devTextBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !e.Shift && !string.IsNullOrEmpty(devTextBox1.Text)) {
                GoChat(null, null);            // 원하는 동작 수행
                e.SuppressKeyPress = true; // 엔터 입력 무시
            }
        }

        private void devButton1_Click(object sender, EventArgs e) {
            GoChat(null, null);
        }

        private void GoChat(int? fileNo, int? emoticonNo) {
            using (telltokEntities db = new telltokEntities()) {
                var test = db.chat.Where(x => (x.c_go == Tool.UserNo && x.c_take == TakeUserNo) || (x.c_go == TakeUserNo && x.c_take == Tool.UserNo)).ToList();
                if (!test.Any()) {
                    Console.WriteLine("채팅 내역 없음");
                    var chatgroup = new chat_group();
                    chatgroup.cg_tamp = chatgroup.cg_no;
                    db.chat_group.Add(chatgroup);
                    db.SaveChanges();

                    ChatGroupNo = chatgroup.cg_no;

                    UpdateChat(GoUserNo, TakeUserNo);
                } else {
                    Console.WriteLine("채팅 내역 있음");
                }
            }

            string GoText = devTextBox1.isTextNull ? "" : devTextBox1.Text;

            using (telltokEntities db = new telltokEntities()) {
                var chat = new chat() {
                    c_date = Tool.now,
                    c_go = Tool.UserNo,
                    c_take = TakeUserNo,
                    c_message = GoText,
                    e_no = emoticonNo,
                    f_no = fileNo,
                    c_delete = false,
                    cg_no = ChatGroupNo,
                };
                db.chat.Add(chat);
                db.SaveChanges();


                UpdateChat(GoUserNo, TakeUserNo);

                devTextBox1.Focus();
                devTextBox1.Text = "";
            }
        }

        private void Chat_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.V) {
                if (Clipboard.ContainsFileDropList()) {
                    FileSaveDB(Clipboard.GetFileDropList()[0]);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            Tool.OpenFormRelativeToParent(this, emoticonSelect = new EmoticonSelect(this), Tool.FormPosition.Left);
        }

        private void devTextBox1_TextChanged(object sender, EventArgs e) {
            devButton1.Enabled = !devTextBox1.isTextNull;
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e) {
            if (emoticonSelect != null) emoticonSelect.Close();

        }
    }
}
