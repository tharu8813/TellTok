using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.ChatControls {
	public partial class ChatGo : UserControl {
		public ChatGo() {
			InitializeComponent();
		}

		public Chat Chat { get; set; }

		private int[] _chatUserInfoNo = new int[2];
		public int[] ChatUserInfoNo {
			get => _chatUserInfoNo;
			set => _chatUserInfoNo = value;
		}

		string userName;
		string message;
		string date;

		int _ChatGoUserNo;

		public int ChatGoUserNo {
			get {
				return _ChatGoUserNo;
			}
			set {
				_ChatGoUserNo = value;
				using(telltokEntities db = new telltokEntities()) {
					var chatNo = db.chat.FirstOrDefault(x => x.c_no == value);

					label2.Text = chatNo.c_date.ToString("t");

					// 15자 단위로 줄바꿈된 문자열 생성
					StringBuilder sb = new StringBuilder();
					int i = 0;
					foreach(char c in chatNo.c_message) {
						sb.Append(c);
						i++;
						if(i % 18 == 0) {
							sb.Append("\n");
						}
					}

					// Label이 존재하면 재사용, 없으면 새로 생성
					panel2.Controls.Clear();
					Label label = new Label() {
						Dock = DockStyle.Fill,
						Padding = new Padding(3, 3, 3, 3),
						AutoSize = true,
						ForeColor = Color.Black,
						RightToLeft = RightToLeft.No
					};

					userName = chatNo.user.u_name;
					message = chatNo.c_message;
					date = chatNo.c_date.ToString("f");

					new ToolTip().SetToolTip(label, date);

					label.MouseDown += (sender, e) => {
						if(e.Button == MouseButtons.Right) {
							ContextMenu contextMenu = new ContextMenu();
							MenuItem menuItem = new MenuItem("복사");
							MenuItem menuItem1 = new MenuItem("삭제");
							MenuItem menuItem2 = new MenuItem("수정");
							MenuItem menuItem3 = new MenuItem("대화 캡처");

							menuItem.Click += MenuItem_Click;
							menuItem1.Click += MenuItem1_Click;
							menuItem2.Click += MenuItem2_Click;
							menuItem3.Click += MenuItem3_Click;

							contextMenu.MenuItems.Add(menuItem);
							contextMenu.MenuItems.Add("-");
							contextMenu.MenuItems.Add(menuItem1);
							contextMenu.MenuItems.Add(menuItem2);
							contextMenu.MenuItems.Add("-");
							contextMenu.MenuItems.Add(menuItem3);

							if(chatNo.c_delete) {
								menuItem1.Enabled = false;
								menuItem2.Enabled = false;
							}

							label.ContextMenu = contextMenu;
						}
					};
					panel2.Controls.Add(label);

					// Label 텍스트 업데이트
					label.Text = sb.ToString();


					if(label.Text.Equals("")) {
						label.ForeColor = Color.Gray;
						label.Text = "(비어있음)";
					}

					if(chatNo.f_no != null) {
						ChatFIle chatFIle1 = new ChatFIle();
						chatFIle1.Visible = true;
						if(chatNo.c_delete)
							chatFIle1.FileDelete = true;
						else
							chatFIle1.ChatFileNo = value;
						chatFIle1.RightToLeft = RightToLeft.No;
						flowLayoutPanel1.Controls.Add(chatFIle1);
					}

					if(chatNo.c_delete) {
						label.Font = new Font(Font.FontFamily, 9, FontStyle.Italic);
						label.ForeColor = Color.Gray;
						label.Text = "삭제된 메세지입니다.";
						message = "삭제된 메세지입니다.";
						Console.WriteLine("삭제됨");
					} else {
						if(chatNo.e_no != null) {
							PictureBox pictureBox1 = new PictureBox() {
								Image = Tool.CreateRoundedImage(Tool.GetByteToImage(chatNo.emoticon.e_image), 200),
								SizeMode = PictureBoxSizeMode.Zoom,
								BackColor = Color.White,
								Size = new Size(100, 100),
								RightToLeft = RightToLeft.No
							};
							flowLayoutPanel1.Controls.Add(pictureBox1);
						}
					}
				}
			}

		}

		private void MenuItem3_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new SaveFileDialog() {
				AddExtension = true,
				Filter = "이미지|*.jpg",
				FileName = $"telltok_chat_screen_shot ({DateTime.Parse(date):yyyyMMdd-HHmmss})"
			};
			if(saveFileDialog.ShowDialog() == DialogResult.OK) {
				using(Bitmap bitmap = new Bitmap(Width, Height)) {
					DrawToBitmap(bitmap, new Rectangle(0, 0, Width, Height));
					bitmap.Save(saveFileDialog.FileName);
					Tool.ShowInfo("저장되었습니다.");
				}
			}
		}

		private void MenuItem2_Click(object sender, System.EventArgs e) {
			ChatEdit chatEdit = new ChatEdit() {
				ChatGoUserNo = ChatGoUserNo
			};
			chatEdit.ShowDialog();
			Chat.UpdateChat(ChatUserInfoNo[0], ChatUserInfoNo[1]);
		}

		private void MenuItem1_Click(object sender, System.EventArgs e) {
			if(Tool.ShowQuestion("정말 삭제하시겠습니까?")) {
				using(telltokEntities db = new telltokEntities()) {
					var chat = db.chat.FirstOrDefault(x => x.c_no == ChatGoUserNo);
					chat.c_delete = true;
					db.SaveChanges();
				}
				Tool.ShowInfo("삭제되었습니다.");
				Chat.UpdateChat(ChatUserInfoNo[0], ChatUserInfoNo[1]);
			}
		}

		private void MenuItem_Click(object sender, System.EventArgs e) {
			Clipboard.SetText($"{userName} [{date}] - {message}");
		}
	}
}
