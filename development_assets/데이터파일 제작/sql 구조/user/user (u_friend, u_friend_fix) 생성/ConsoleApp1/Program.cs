using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

class Program {
	/// <summary>
	/// 학생들의 친구 목록을 저장하는 배열.
	/// </summary>
	static List<int>[] friendLists = new List<int>[40];

	/// <summary>
	/// 프로그램의 메인 진입점입니다. 친구 목록을 생성하고, 각 학생의 가장 친한 친구를 출력합니다.
	/// </summary>
	static void Main() {
		// 친구 목록 생성
		var result = GenerateFriendLists(40, 8);

		// 친구 목록 출력
		for(int i = 0; i < result.Length; i++) {
			string text = string.Join(", ", result[i].OrderBy(f => f));
			Console.Write($"[{i + 1}]: ");
			Console.WriteLine(text); // 친구 리스트 오름차순 정렬
			using(var t = new telltokEntities()) {
				var user = t.user.FirstOrDefault(x => x.u_no == i + 1);
				user.u_friend = text;
				t.SaveChanges();
			}
		}
		friendLists = result;

		// 가장 친한 친구 목록 선택
		var closeFriendLists = SelectCloseFriends(friendLists, 3);

		// 가장 친한 친구 출력
		for(int i = 0; i < closeFriendLists.Length; i++) {
			string text = string.Join(", ", closeFriendLists[i].OrderBy(f => f));
			Console.Write($"[{i + 1}]의 가장 친한 친구: ");
			Console.WriteLine(text); // 가장 친한 친구 리스트 오름차순 정렬
			using(var t = new telltokEntities()) {
				var user = t.user.FirstOrDefault(x => x.u_no == i + 1);
				user.u_friend_fix = text;
				t.SaveChanges();
			}
		}
		Console.ReadLine();
	}

	/// <summary>
	/// 주어진 학생 수, 최대 친구 수, 평균 친구 수를 바탕으로 친구 관계를 생성합니다.
	/// </summary>
	/// <param name="totalStudents">학생 수</param>
	/// <param name="maxFriends">한 학생이 가질 수 있는 최대 친구 수</param>
	/// <returns>학생별 친구 목록을 담은 배열</returns>
	static List<int>[] GenerateFriendLists(int totalStudents, int maxFriends) {
		var random = new Random();
		var friendLists = new List<int>[totalStudents];

		// 각 학생의 친구 목록 초기화
		for(int i = 0; i < totalStudents; i++) {
			friendLists[i] = new List<int>();
		}

		// 친구 관계 추가
		for(int i = 1; i < totalStudents; i++) {
			// 최대 친구 수는 maxFriends로 제한
			int friendCount = random.Next(1, maxFriends);

			while(friendLists[i - 1].Count < friendCount) {
				int friend = random.Next(0, totalStudents);

				// 자기 자신이나 0번 학생은 제외
				if(friend + 1 == i || friendLists[i - 1].Contains(friend + 1))
					continue;

				// 양방향 친구 관계 추가
				friendLists[i - 1].Add(friend + 1);
				friendLists[friend].Add(i); // 상대방도 친구 목록에 추가
			}
		}

		return friendLists;
	}

	/// <summary>
	/// 각 학생의 가장 친한 친구를 랜덤하게 선택합니다.
	/// </summary>
	/// <param name="friendLists">각 학생의 친구 목록</param>
	/// <param name="maxCloseFriends">각 학생이 가질 수 있는 최대 가장 친한 친구 수</param>
	/// <returns>각 학생의 가장 친한 친구 목록을 담은 배열</returns>
	static List<int>[] SelectCloseFriends(List<int>[] friendLists, int maxCloseFriends) {
		var random = new Random();
		var closeFriendLists = new List<int>[friendLists.Length];

		for(int i = 0; i < friendLists.Length; i++) {
			var friends = friendLists[i];

			// 친구 리스트가 비어 있는 경우 건너뜀
			if(friends.Count == 0) {
				closeFriendLists[i] = new List<int>();
				continue;
			}

			// 가장 친한 친구 선택 (랜덤으로 최대 maxCloseFriends명)
			int numCloseFriends = Math.Min(maxCloseFriends, friends.Count);
			var closeFriends = friends.OrderBy(x => random.Next()).Take(numCloseFriends).ToList();

			closeFriendLists[i] = closeFriends;
		}

		return closeFriendLists;
	}
}
