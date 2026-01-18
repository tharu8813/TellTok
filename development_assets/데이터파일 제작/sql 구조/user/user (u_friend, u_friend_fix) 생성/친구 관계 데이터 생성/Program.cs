using System;
using System.Collections.Generic;
using System.Linq;
using 친구_관계_데이터_생성;

public class FriendGenerator {
	// 친구 관계를 생성하는 메서드
	public static List<(int user1, int user2)> GenerateFriendship(int userId, string friendList, HashSet<string> existingFriendships) {
		// 친구 리스트를 파싱
		var friends = friendList.Split(',').Select(f => int.Parse(f)).ToList();
		var random = new Random();
		var friendships = new List<(int user1, int user2)>();

		// 이미 친구 관계가 아닌 유저들 중에서 하나를 랜덤으로 선택
		var selectedFriend = friends
			.Where(f => !existingFriendships.Contains($"{userId},{f}") && !existingFriendships.Contains($"{f},{userId}"))
			.OrderBy(f => random.Next())
			.Take(1)
			.FirstOrDefault();

		// 친구 관계가 존재하면 추가
		if(selectedFriend != 0) {
			friendships.Add((userId, selectedFriend));

			// 기존 친구 관계에 추가
			existingFriendships.Add($"{userId},{selectedFriend}");
			existingFriendships.Add($"{selectedFriend},{userId}");
		}

		return friendships;
	}
}

class Program {
	static void Main() {
		string tableText = "";
		var random = new Random();

		// 랜덤한 유저 ID를 n개 생성 (예시: 1~10)
		List<int> randomUserIds = Enumerable.Range(1, 10) // 1부터 10까지
											  .OrderBy(x => random.Next()) // 랜덤 정렬
											  .ToList();

		using(var db = new telltokEntities()) {
			var user = db.user;
			foreach(var tamp in user) {
				int userId1 = randomUserIds[random.Next(randomUserIds.Count)]; // 랜덤 userId 선택
				string friendList1 = tamp.u_friend;
				HashSet<string> existingFriendships = new HashSet<string>(); // 기존 친구 관계

				// 첫 번째 유저의 친구 관계 생성
				var friendships = FriendGenerator.GenerateFriendship(userId1, friendList1, existingFriendships);

				// 생성된 친구 관계 출력
				Console.WriteLine("=====================================");
				foreach(var friendship in friendships) {
					Console.WriteLine($"{friendship.user1}번 유저의 친구는 {friendship.user2}번 입니다.");
				}
				foreach(var friendship in friendships) {
					tableText = $"{tableText}\n{friendship.user1}\t{friendship.user2}";
				}
			}
			Console.WriteLine(tableText);
		}
		Console.ReadLine();
	}
}
