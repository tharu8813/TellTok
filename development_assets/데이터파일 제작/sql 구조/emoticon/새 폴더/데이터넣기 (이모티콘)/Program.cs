using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace 데이터넣기__이모티콘_ {
    internal class Program {

        static string em_path = @"C:\Users\USER\Desktop\폴더\전국대회 강원 2025\채팅버전\데이터파일\이모티콘";

        static void Main(string[] args) {
            using (telltokEntities1 db = new telltokEntities1()) {
                var em_name = db.emoticon_store.ToList();
                int no = 1;
                foreach (var em in em_name) {
                    var files = Directory.GetFiles(Path.Combine(em_path, em.es_name)).OrderBy(x => int.Parse(Path.GetFileName(x).Split('.')[0]));
                    foreach (var f in files) {
                        Console.WriteLine($"이미지 넣는중... (경로: {f}, 이모티콘 상점 고유번호: {no})");
                        emoticon emoticon = new emoticon() {
                            es_no = no,
                            e_image = ConvertImageToByteArray(f)
                        };
                        db.emoticon.Add(emoticon);
                    }
                    no++;
                }
                db.SaveChanges();
            }
        }
        static byte[] ConvertImageToByteArray(string imagePath) {
            using (Image image = Image.FromFile(imagePath)) {
                using (MemoryStream memoryStream = new MemoryStream()) {
                    image.Save(memoryStream, image.RawFormat);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
