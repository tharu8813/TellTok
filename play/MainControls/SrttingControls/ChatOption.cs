using System;
using System.Drawing;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.SrttingControls {
	public partial class ChatOption : UserControl {
		public ChatOption() {
			InitializeComponent();
			Timer timer = new Timer();
			timer.Tick += Timer_Tick;
			timer.Interval = 100;
			timer.Start();

			UpdateColor();
		}

		private void Timer_Tick(object sender, EventArgs e) {
			trackBar1.Value = Properties.Settings.Default.ChatOpacity;
			UpdateOpacity();
			UpdateColor();
		}

		private void UpdateColor() {
			pictureBox1.BackColor = Properties.Settings.Default.ChatBackColor;
		}

		private void button1_Click(object sender, EventArgs e) {
			BackColorDialog.Color = Properties.Settings.Default.ChatBackColor;
			BackColorDialog.ShowDialog(this);

			Properties.Settings.Default.ChatBackColor = BackColorDialog.Color;
			Properties.Settings.Default.Save();
		}

		private void ChatOption_Load(object sender, EventArgs e) {
			Tool.FontToAllControls(this);

			trackBar1.Value = Properties.Settings.Default.ChatOpacity;
			UpdateOpacity();
		}

		private void UpdateOpacity() {
			Properties.Settings.Default.ChatOpacity = trackBar1.Value;
			Properties.Settings.Default.Save();
		}

		private void trackBar1_Scroll(object sender, EventArgs e) {
			UpdateOpacity();
		}

		private void button2_Click(object sender, EventArgs e) {
			if(Tool.ShowQuestion("기본값으로 변경하시겠습니까?")) {
				Properties.Settings.Default.ChatBackColor = Color.FromArgb(186, 206, 224);
				Properties.Settings.Default.Save();
			}
		}
	}
}
