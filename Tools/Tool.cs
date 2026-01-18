using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using telltok.play;

namespace telltok.Tools {
    public class Tool {
        static PrivateFontCollection privateFonts = new PrivateFontCollection();

        public static bool isChatListChange = false;

        public static DateTime now = new DateTime(2025, 9, 21, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

        /// <summary>
        /// Byte[] 형식을 Image 형식으로 변환합니다.
        /// </summary>
        /// <param name="b">이미지의 Byte[]</param>
        /// <returns>이미지</returns>
        public static Image GetByteToImage(byte[] b) {
            using (MemoryStream s = new MemoryStream(b))
                return Image.FromStream(s);
        }

        /// <summary>
        /// Login Form을 제외한 모든 Form을 종료합니다.
        /// </summary>
        public static void CloesedAllTagWinForm() {
            Tool.LoginFormManager.Location = Tool.MainFormManager.Location;

            foreach (System.Windows.Forms.Form form in Application.OpenForms.Cast<System.Windows.Forms.Form>().ToList()) {
                if (string.Equals(form.Name, "Login", StringComparison.OrdinalIgnoreCase))
                    form.Show();
                else
                    form.Dispose();
            }
        }


        /// <summary>
        /// 메인 폼 관리자입니다. null 일경우 메인폼은 존재하지 않습니다.
        /// </summary>
        public static MainForm MainFormManager = null;

        /// <summary>
        /// 로그인 폼 관리자입니다. null 일경우 로그인폼은 존재하지 않습니다.
        /// </summary>
        public static Login LoginFormManager = null;

        public static int UserNo = 3;

        public static Color DevColorBrown = Color.FromArgb(58, 30, 29);
        public static Color DevColorOrange = Color.FromArgb(255, 170, 1);

        /// <summary>
        /// 부모 창 기준으로 자식 창을 왼쪽 또는 오른쪽에 배치합니다.
        /// </summary>
        /// <param name="mainForm">기준 부모 폼</param>
        /// <param name="childForm">배치할 자식 폼</param>
        /// <param name="position">Left 또는 Right</param>
        public static void OpenFormRelativeToParent(System.Windows.Forms.Form mainForm, System.Windows.Forms.Form childForm, FormPosition position) {
            int childX;
            int parentX = mainForm.Location.X;
            int parentY = mainForm.Location.Y;

            switch (position) {
                case FormPosition.Right:
                    childX = parentX + mainForm.Width;
                    break;
                case FormPosition.Left:
                    childX = parentX - childForm.Width;
                    break;
                default:
                    throw new ArgumentException("Invalid position. Use 'Left' or 'Right'.");
            }

            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(childX, parentY);
            childForm.Show();
        }


        public enum FormPosition {
            Left,
            Right
        }

        /// <summary>
        /// 시스템 트레이에 표시되는 아이콘을 담당합니다.
        /// 이 아이콘은 응용 프로그램의 백그라운드 상태를 나타내며, 사용자와의 상호작용을 지원합니다.
        /// </summary>
        /// <remarks>
        /// <para>이 필드는 프로그램 시작 시 초기화되어야 하며, 마우스 클릭 이벤트 및 컨텍스트 메뉴와 연동될 수 있습니다.</para>
        /// <para>예: <see cref="System.Windows.Forms.NotifyIcon"/>.</para>
        /// </remarks>
        public static NotifyIcon notifyIcon;

        /// <summary>
        /// 시스템 트레이 아이콘 우클릭 시 표시되는 컨텍스트 메뉴의 항목들입니다.
        /// </summary>
        /// <remarks>
        /// <para>이 배열은 최대 5개의 메뉴 항목을 저장하며, 프로그램 실행 중 동적으로 설정할 수 있습니다.</para>
        /// <para>각 항목은 <see cref="System.Windows.Forms.ToolStripItem"/>으로 정의되며, 클릭 이벤트와 연동될 수 있습니다.</para>
        /// </remarks>
        public static ToolStripItem[] toolStripItem = new ToolStripItem[5];

        /// <summary>
        /// Form 전체에 "NoonnuBasicGothicRegular.ttf" 폰트를 적용합니다.
        /// 폰트 파일이 없거나 적용이 실패한 경우 기본 폰트가 유지됩니다.
        /// </summary>
        /// <param name="control">적용할 상위 컨트롤</param>
        /// <remarks>
        /// 이 메서드는 커스텀 폰트를 모든 하위 컨트롤에 재귀적으로 적용합니다.
        /// </remarks>
        public static void FontToAllControls(Control control) {
            try {
                privateFonts.AddFontFile("NoonnuBasicGothicRegular.ttf");
                ApplyCustomFontToAllControls(control);
            } catch (Exception) {
            }
        }
        static void ApplyCustomFontToAllControls(Control control) {
            control.Font = new Font(privateFonts.Families[0], control.Font.Size, control.Font.Style);
            foreach (Control childControl in control.Controls) {
                ApplyCustomFontToAllControls(childControl);
            }
        }

        /// <summary>
        /// 사용자에게 오류 메시지를 표시합니다.
        /// 메시지는 <see cref="MessageBoxIcon.Error" /> 아이콘과 함께 표시됩니다.
        /// </summary>
        /// <param name="text">표시할 오류 메시지</param>
        public static void ShowError(string text) {
            MessageBox.Show(text, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 사용자에게 정보 메시지를 표시합니다.
        /// 메시지는 <see cref="MessageBoxIcon.Information" /> 아이콘과 함께 표시됩니다.
        /// </summary>
        /// <param name="text">표시할 정보 메시지</param>
        public static void ShowInfo(string text) {
            MessageBox.Show(text, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 사용자에게 질문 메시지를 표시하고, "예" 또는 "아니오" 버튼 중 선택한 결과를 반환합니다.
        /// 메시지는 <see cref="MessageBoxIcon.Question" /> 아이콘과 함께 표시됩니다.
        /// </summary>
        /// <param name="text">표시할 질문 메시지</param>
        /// <returns>
        /// 사용자가 "예" 버튼을 클릭하면 true, "아니오" 버튼을 클릭하면 false를 반환합니다.
        /// </returns>
        /// <remarks>
        /// 이 메서드는 대화형 메시지 박스를 사용하여 사용자 입력을 처리합니다.
        /// </remarks>
        public static bool ShowQuestion(string text) {
            DialogResult result = MessageBox.Show(text, "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// 주어진 이미지를 1000x1000 크기로 리사이즈하고, 둥근 모서리로 잘라 반환합니다.
        /// Anti-Aliasing을 적용하여 가장자리를 부드럽게 처리합니다.
        /// </summary>
        /// <param name="originalImage">원본 이미지</param>
        /// <param name="radius">둥근 모서리 반지름</param>
        /// <returns>처리된 이미지</returns>
        public static Image CreateRoundedImage(Image originalImage, int radius) {
            if (originalImage == null) return null;

            const int size = 1000;
            Bitmap result = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(result)) {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsPath path = new GraphicsPath();
                int r = radius;

                // 네 귀퉁이의 둥근 모서리 만들기
                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(size - r, 0, r, r, 270, 90);
                path.AddArc(size - r, size - r, r, r, 0, 90);
                path.AddArc(0, size - r, r, r, 90, 90);
                path.CloseFigure();

                g.SetClip(path);
                g.DrawImage(originalImage, new Rectangle(0, 0, size, size));
            }

            return result;
        }


    }
}
