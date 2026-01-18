using System;
using System.Linq;
using System.Windows.Forms;
using telltok.Tools;

namespace telltok.play.MainControls.FriendControls {
	public partial class AddFriendControl : UserControl {

		public AddFriendControl() {
			InitializeComponent();
		}

		private void button1_Click_1(object sender, EventArgs e) {
			using(telltokEntities db = new telltokEntities()) {
				// 이미 존재하는 친구 요청 검색
				var existingRequest = db.add_friend.FirstOrDefault(x =>
					(x.af_go == Tool.UserNo && x.af_take == user1.UserNo) ||
					(x.af_go == user1.UserNo && x.af_take == Tool.UserNo));

				// 조건에 따라 메시지 출력
				if(existingRequest != null) {
					if(existingRequest.af_go == user1.UserNo && existingRequest.af_take == Tool.UserNo) {
						Tool.ShowError("이미 해당 유저의 요청이 왔습니다.");
					} else {
						Tool.ShowError("이미 해당 유저에게 친구 요청을 보냈습니다.");
					}
					return; // 이미 요청이 존재하면 추가 작업 중단
				}

				// 새로운 친구 요청 추가
				var newFriendRequest = new add_friend() {
					af_go = Tool.UserNo,
					af_take = user1.UserNo,
				};
				db.add_friend.Add(newFriendRequest);
				db.SaveChanges(); // af_no 값 생성

				var notification = new alim() {
					a_date = Tool.now,
					af_no = newFriendRequest.af_no
				};
				db.alim.Add(notification);
				db.SaveChanges(); // 알림 저장

				Tool.ShowInfo("친구 요청이 성공적으로 전송되었습니다.");
			}
		}
	}
}
