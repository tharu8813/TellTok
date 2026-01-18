using System;
using System.Windows.Forms;

namespace telltok.play.MainControls.ChatControls {
	public partial class Dateline : UserControl {
		public Dateline() {
			InitializeComponent();
		}

		public DateTime Date {
			set {
				label1.Text = value.ToString("yyyy년 MM월 dd일 ") + WeekendKR(value.DayOfWeek);
			}
		}

		private string WeekendKR(DayOfWeek dateTime) {
			switch(dateTime) {
				case DayOfWeek.Sunday:
					return "일요일";
				case DayOfWeek.Monday:
					return "월요일";
				case DayOfWeek.Tuesday:
					return "화요일";
				case DayOfWeek.Wednesday:
					return "수요일";
				case DayOfWeek.Thursday:
					return "목요일";
				case DayOfWeek.Friday:
					return "금요일";
				case DayOfWeek.Saturday:
					return "토요일";
				default:
					return null;
			}
		}
	}
}
