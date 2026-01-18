using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.Tools;

namespace telltok.play.MainControls.ChatControls {
    public partial class ChatFIle : UserControl {
        public ChatFIle() {
            InitializeComponent();
        }

        int FileNo = 0;

        public bool FileDelete {
            set {
                if (value) {
                    label1.Text = "삭제되어 확인할 수 없습니다.";
                    label1.ForeColor = Color.Red;
                    label2.Text = $"확장명: NULL";
                    label3.Text = $"전송 일자: NULL";

                    devButton1.Enabled = false;
                    devButton2.Enabled = false;
                }
            }
        }

        public int ChatFileNo {
            set {
                using (telltokEntities db = new telltokEntities()) {
                    var file = db.chat.FirstOrDefault(x => x.c_no == value);
                    if (file == null) {
                        label1.Text = "!!!";
                        return;
                    }
                    label1.Text = file.file.f_name;
                    label2.Text = $"확장명: {Path.GetExtension(file.file.f_name)}";
                    label3.Text = $"전송 일자: {file.c_date}";

                    string extension = Path.GetExtension(file.file.f_name);
                    if (extension.Equals(".mp3", System.StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".mp4", System.StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".jpg", System.StringComparison.OrdinalIgnoreCase) ||
                        extension.Equals(".txt", System.StringComparison.OrdinalIgnoreCase)) {
                        devButton2.Enabled = true;
                    }
                    FileNo = (int)file.f_no;
                }
            }
        }

        private void devButton2_Click(object sender, System.EventArgs e) {
            TellViewer player = new TellViewer() {
                FileNo = FileNo
            };
            player.Show();
        }

        private void devButton1_Click(object sender, System.EventArgs e) {
            using (telltokEntities db = new telltokEntities()) {
                var fileinfo = db.file.FirstOrDefault(x => x.f_no == FileNo);

                var FilePath = Directory.GetFiles($"datafiles/file")
                        .FirstOrDefault(x => Path.GetFileNameWithoutExtension(x)
                        .Equals(FileNo.ToString()));

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    if (File.Exists(folderBrowserDialog1.SelectedPath + "/" + fileinfo.f_name))
                        if (!Tool.ShowQuestion("같은 이름에 파일이 있습니다. 덮어쓰겠습니까?"))
                            return;
                    File.Copy(FilePath, $"{folderBrowserDialog1.SelectedPath}/{fileinfo.f_name}", true);
                    Tool.ShowInfo("파일이 다운로드되었습니다.");
                }
            }
        }
    }
}
