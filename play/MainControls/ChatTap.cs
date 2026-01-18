using System;
using System.Linq;
using System.Windows.Forms;
using telltok.play.MainControls.ChatControls;
using telltok.Tools;

namespace telltok.play.MainControls {
	public partial class ChatTap : UserControl {

		public ChatTap() {
			InitializeComponent();
			UpdateList();
		}

		public void UpdateList() {
			//int no = 1;
			//using(var db = new telltokEntities()) // DB 컨텍스트를 밖으로 빼서 한 번만 사용
			//{
			//	for(int i = 1; i <= 40; i++) {
			//		for(int j = 1; j <= 40; j++) {
			//			var users = db.chat.Where(x => (x.c_go == i && x.c_take == j) || (x.c_go == j && x.c_take == i));
			//			if(users.Any()) {
			//				foreach(var user in users) {
			//					user.cg_no = no;
			//					Console.WriteLine(no);
			//				}
			//				no++;
			//			}
			//		}
			//	}
			//	db.SaveChanges(); // 변경 사항을 한 번만 저장
			//}

			using(telltokEntities db = new telltokEntities()) {
				// 사용자가 속한 채팅 그룹과 관련된 모든 데이터 가져오기
				var chatGroups = db.chat
					.Where(x => x.c_go == Tool.UserNo || x.c_take == Tool.UserNo)
					.GroupBy(x => x.cg_no)
					.Select(g => new {
						GroupId = g.Key,
						LastChat = g.OrderByDescending(x => x.c_date).ThenByDescending(x => x.c_no).FirstOrDefault(),
						ChatGroupNo = g.Max(x => x.cg_no),
						FileNo = g.FirstOrDefault().f_no,
					})
					.OrderByDescending(group => group.LastChat.c_date) // 최근 대화 날짜 기준으로 정렬
					.ThenByDescending(group => group.LastChat.c_no) // 날짜가 같을 경우, 채팅 번호 기준으로 정렬
					.ToList();

				flowLayoutPanel1.Controls.Clear();
				// 결과 출력
				foreach(var group in chatGroups) {
					if(group.LastChat != null) {
						Console.WriteLine($"전송: {group.LastChat.c_go} / 받음: {group.LastChat.c_take} /  마지막 날짜: {group.LastChat.c_date} / 마지막 대화 내용: {group.LastChat.c_message}");

						int takeUserNo = group.LastChat.user.u_no == Tool.UserNo ? group.LastChat.user1.u_no : group.LastChat.user.u_no;

						ChatList chatList = new ChatList() {
							ChatDate = group.LastChat.c_date,
							ChatText = group.LastChat.c_delete ? "(삭제된 메세지입니다.)" : group.LastChat.f_no != null ? "(파일) " + group.LastChat.c_message : group.LastChat.e_no != null ? "(이모티콘) " + group.LastChat.c_message : group.LastChat.c_message,
							ChatUserName = group.LastChat.user.u_no == Tool.UserNo ? group.LastChat.user1.u_name : group.LastChat.user.u_name,
							ProfileUserNo = takeUserNo
						};
						var _i = group;
						chatList.ChatListClick += (se, ex) => {
							Chat chat = new Chat();
							chat.UpdateChat(Tool.UserNo, takeUserNo);
							Tool.OpenFormRelativeToParent(Tool.MainFormManager, chat, Tool.FormPosition.Right);
						};
						flowLayoutPanel1.Controls.Add(chatList);
					}
				}
				Tool.FontToAllControls(this);
			}
		}

		private void ChatTap_Load(object sender, EventArgs e) {
			Timer timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += (se, ex) => {
				Console.WriteLine("업데이트 대기중...");
				if(Tool.isChatListChange) {
					Console.WriteLine("업데이트됌");
					Tool.isChatListChange = false;
					UpdateList();
				}
			};
			timer.Start();

			Disposed += (se, ex) => {
				timer.Stop();
				timer.Dispose();
				Console.WriteLine("리소스 해재");
			};
		}
	}
}
