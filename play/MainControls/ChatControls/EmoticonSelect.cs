using System.Linq;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.ChatControls {
	public partial class EmoticonSelect : telltok.Tools.Form.DevForm {
		public EmoticonSelect(Chat chat) {
			InitializeComponent();
			Chat = chat;
		}

		public Chat Chat { get; }

		private void EmoticonSelect_Load(object sender, System.EventArgs e) {
			Text = $"TellTok - 이모티콘 - {Chat.label1.Text}";

			var list = Application.OpenForms.Cast<Form>().ToList();
			foreach(var it in list) {
				if(it != this && it.Text.Equals(Text)) {
					it.Activate();
					Close();
					return;
				}
			}

			using(telltokEntities db = new telltokEntities()) {
				var user = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);
				string[] em_list = user.u_emoticon.Split(',');
				updateEm(int.Parse(em_list[0]));
				foreach(string em in em_list) {
					var img = db.emoticon.FirstOrDefault(x => (x.eg_no + "").Equals(em)).e_image;
					int em_no = int.Parse(em);

					imageList1.Images.Add(Tool.CreateRoundedImage(Tool.GetByteToImage(img), 20));
					Button button = new Button() {
						FlatStyle = FlatStyle.Flat,
						Text = "",
						Image = imageList1.Images[imageList1.Images.Count - 1],
						Size = new System.Drawing.Size(70, 70),
						BackColor = System.Drawing.Color.White,
					};
					button.Click += (se, ex) => {
						updateEm(em_no);
					};
					flowLayoutPanel1.Controls.Add(button);
				}
			}
			Tool.FontToAllControls(this);
		}

		void updateEm(int em_no) {
			tableLayoutPanel1.Controls.Clear();

			using(telltokEntities db = new telltokEntities()) {
				var list = db.emoticon.Where(x => x.eg_no == em_no).ToList();
				label1.Text = list[0].emoticon_group.eg_name;
				imageList2.Images.Clear();
				foreach(var em in list) {
					int e_no = em.e_no;

					imageList2.Images.Add(Tool.CreateRoundedImage(Tool.GetByteToImage(em.e_image), 20));

					Button button = new Button() {
						FlatStyle = FlatStyle.Flat,
						Text = "",
						Image = imageList2.Images[imageList2.Images.Count - 1],
						Size = new System.Drawing.Size(60, 60),
					};
					button.Click += (se, ex) => {
						Chat.GoEmoticonAndChat(e_no);
					};
					tableLayoutPanel1.Controls.Add(button);
				}
				tableLayoutPanel1.Controls.Add(new Panel() { AutoSize = true, Dock = DockStyle.Fill });
			}
			Tool.FontToAllControls(this);
		}
	}
}
