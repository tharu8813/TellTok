using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace telltok.play.MainControls.ChatControls {
	public partial class TellViewer : Tools.Form.DevForm {
		public TellViewer() {
			InitializeComponent();
		}

		public int FileNo {
			set {
				using(telltokEntities db = new telltokEntities()) {
					var file = db.file.FirstOrDefault(x => x.f_no == value);

					string fileDirectory = Path.Combine(Application.StartupPath, "datafiles", "file");

					Console.WriteLine(fileDirectory);

					var filePath = Directory.GetFiles(fileDirectory)
						.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x).Equals(file.f_no.ToString()));

					Console.WriteLine($"{file.f_no.ToString()} 가 입력됨");

					string fileExtension = Path.GetExtension(file.f_name).ToLower(); // 확장자를 소문자로 변환

					if(fileExtension == ".mp4" || fileExtension == ".mp3") {
						Console.WriteLine($"동영상 재생 : {filePath}");
						axWindowsMediaPlayer1.Visible = true;
						axWindowsMediaPlayer1.URL = filePath;
						axWindowsMediaPlayer1.Ctlcontrols.play();
					} else if(fileExtension == ".txt") {
						Console.WriteLine($"텍스트 표시 : {filePath}");
						textBox1.Visible = true;

						textBox1.Text = File.ReadAllText(filePath);
					} else {
						Console.WriteLine($"이미지 표시 : {filePath}");
						pictureBox1.Visible = true;
						pictureBox1.Image = Image.FromFile(filePath);

					}
				}
			}
		}
	}
}
