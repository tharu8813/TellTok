using System;
using System.Drawing;
using System.Linq;

namespace 데이터_생성__거래_ {
    internal class Program {

        static Random random = new Random(1);

        static void Main(string[] args) {

            using (telltokEntities db = new telltokEntities()) {
                Console.WriteLine($"t_no\tt_go\tt_taket\tt_price\tt_message");
                for (int i = 0; i < 50; i++) {
                    var user = db.user.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    var take = user.u_friend.Split(',').OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    Console.WriteLine($"{i + 1}\t{user.u_no}\t{take}\t{random.Next(1, 100) + "000"}\tnull\tgo:{user.u_name}\ttake:{db.user.FirstOrDefault(x => x.u_no.ToString().Equals(take)).u_name}");
                }
            };
        }
    }
}
