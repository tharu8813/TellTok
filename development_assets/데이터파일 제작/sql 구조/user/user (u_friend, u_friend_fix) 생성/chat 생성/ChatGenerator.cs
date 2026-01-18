using chat_생성;
using System;
using System.Collections.Generic;
using System.Linq;

public class ChatGenerator {
	// 채팅 내역을 생성하는 메서드
	public static List<(int sender, int receiver, DateTime sentDate)> GenerateChatHistory(int userId, string friendList, HashSet<string> existingChats) {
		// 친구 리스트를 파싱
		var friends = friendList.Split(',').Select(f => int.Parse(f)).ToList();
		var random = new Random();
		var chatHistory = new List<(int sender, int receiver, DateTime sentDate)>();

		// 이미 채팅을 주고받은 유저들을 제외하고 최대 5명만 랜덤으로 선택
		var selectedFriends = friends
			.Where(f => !existingChats.Contains($"{userId},{f}") && !existingChats.Contains($"{f},{userId}"))
			.OrderBy(f => random.Next())
			.Take(4)
			.ToList();

		// 친구와 채팅 주고받기
		foreach(var friend in selectedFriends) {
			// 채팅 날짜와 시간 생성 (각각 다른 시간으로 설정)
			DateTime baseDate = DateTime.Today.AddDays(random.Next(0, 10));  // 오늘 또는 내일 날짜로 설정
			baseDate = baseDate.AddHours(random.Next(0, 24)) // 랜덤 시간 (0 ~ 23시)
				.AddMinutes(random.Next(0, 60)) // 랜덤 분 (0 ~ 59분)
				.AddSeconds(random.Next(0, 60)); // 랜덤 초 (0 ~ 59초)

			// 채팅 내역 3번 이상 주고받기
			for(int i = 0; i < 2; i++) // 각 친구와 2번 이상 주고받기
			{
				// 유저 -> 친구
				chatHistory.Add((userId, friend, baseDate));
				baseDate = baseDate.AddSeconds(random.Next(10, 60)); // 채팅 간 시간 간격을 10~60초로 설정

				// 친구 -> 유저
				chatHistory.Add((friend, userId, baseDate));
				baseDate = baseDate.AddSeconds(random.Next(10, 60)); // 채팅 간 시간 간격을 10~60초로 설정
			}

			// 채팅방 구분
			chatHistory.Add((' ', 0, DateTime.MinValue));
		}

		// 생성된 채팅 내역을 기존 채팅 목록에 추가
		foreach(var chat in chatHistory) {
			if(chat.sentDate != DateTime.MinValue) {
				existingChats.Add($"{chat.sender},{chat.receiver}");
				existingChats.Add($"{chat.receiver},{chat.sender}");
			}
		}

		return chatHistory;
	}
}

class Program {
	static void Main() {
		// 첫 번째 유저 (userId = 1)
		using(telltokEntities db = new telltokEntities()) {
			var user = db.user;
			foreach(var tamp in user) {
				int userId1 = tamp.u_no;
				string friendList1 = tamp.u_friend;
				HashSet<string> existingChats = new HashSet<string>(); // 기존 채팅 내역

				// 첫 번째 유저의 채팅 내역 생성
				var chatHistory1 = ChatGenerator.GenerateChatHistory(userId1, friendList1, existingChats);

				// 첫 번째 유저의 채팅 내역 출력
				Console.WriteLine("User 1's Chat History:");
				foreach(var chat in chatHistory1) {
					if(chat.sentDate == DateTime.MinValue) {
						Console.WriteLine("--");
					} else {
						Console.WriteLine($"Sender: {chat.sender}, Receiver: {chat.receiver}, Date: {chat.sentDate}");
						var user_set = new chat() {
							c_date = chat.sentDate,
							c_go = chat.sender,
							c_take = chat.receiver,
							c_message = null,
							f_no = null
						};
						db.chat.Add(user_set);
					}
				}
			}
			db.SaveChanges();
		}
		Console.ReadLine();
	}
}
