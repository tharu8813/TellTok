using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using telltok.play.MainControls.FriendControls;
using telltok.Tools;

namespace telltok.play {
	public partial class AddFriend : Tools.Form.DevForm {
		public static AddFriend thisForm;

		string MyAddFriendID = "";

		public AddFriend() {
			InitializeComponent();
			thisForm = this;
		}

		private void AddFriend_Shown(object sender, EventArgs e) {
			CheckClipboard();
		}

		private void AddFriend_Load(object sender, EventArgs e) {
			Tool.FontToAllControls(this);

			using(telltokEntities db = new telltokEntities()) {
				MyAddFriendID = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo).u_friend_id.ToString();
			}

			label1.Text = $"친구 추가 ID만 있으면 언제든지 추가할 수 있어요! 친구 추가 ID의 8자리 번호를 입력해 보세요. 나의 친구 추가 번호는 {MyAddFriendID} 에요!";
		}

		private void CheckClipboard() {
			if(Regex.IsMatch(Clipboard.GetText(), @"^\d{8}$")) {
				if(Tool.ShowQuestion($"클립보드에 친구 추가 ID 로 추측되는 내용을 발견했습니다.\n해당 ID 로 검색하시겠습니까?\n\n친구 추가 ID: {Clipboard.GetText()}")) {
					maskedTextBox1.Text = Clipboard.GetText();
				}
			}
		}

		private void maskedTextBox1_TextChanged(object sender, EventArgs e) {
			flowLayoutPanel1.Controls.Clear();

			// maskedTextBox1.Text에서 밑줄(_)을 제거한 후 숫자 값으로 변환  
			string cleanedText = maskedTextBox1.Text.Replace("_", "");
			if(cleanedText.Length == 0) return; // 입력된 값이 없으면 처리하지 않음  

			if(cleanedText.Length == 8) {

				using(telltokEntities db = new telltokEntities()) {
					List<int> list = new List<int>();
					foreach(string it in db.user.FirstOrDefault(x => x.u_no == Tool.UserNo).u_friend.Split(',')) {
						list.Add(int.Parse(it));
					}

					var userList = db.user.Where(x => !list.Contains(x.u_no) && x.u_no != Tool.UserNo && x.u_friend_id.ToString().Contains(cleanedText));
					foreach(var it in userList) {
						Invoke(new Action(() => {
							Console.WriteLine("?????? " + it.u_no);
							AddFriendControl addFriendControl = new AddFriendControl();
							addFriendControl.user1.UserNo = it.u_no;
							flowLayoutPanel1.Controls.Add(addFriendControl);
						}));
					}
				}
			}
			Tool.FontToAllControls(this);
		}

		private async void button1_Click(object sender, EventArgs e) {
			if(button1.Text.Equals("내 친구추가 ID 복사하기")) {
				button1.Text = "복사 완료!";
				Clipboard.SetText(MyAddFriendID);
				await Task.Delay(500);
				button1.Text = "내 친구추가 ID 복사하기";
			}
		}

		private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {

		}
	}
}
