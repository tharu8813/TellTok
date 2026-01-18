using System;
using System.Windows.Forms;
using telltok.play;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok {
    internal static class Program {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            notifyIcon = new NotifyIcon() {
                Icon = Properties.Resources.black_icon, // 로그아웃 상태일 경우 black_icon 으로 설정
                Text = "TellTok",
                Visible = true
            };

            ContextMenuStrip context = new ContextMenuStrip();

            toolStripItem[0] = context.Items.Add("TellTok", Properties.Resources.logo);
            context.Items.Add(new ToolStripSeparator());
            toolStripItem[1] = context.Items.Add("열기");
            toolStripItem[2] = context.Items.Add("잠금모드");
            toolStripItem[3] = context.Items.Add("로그이웃");
            context.Items.Add(new ToolStripSeparator());
            toolStripItem[4] = context.Items.Add("종료");
            notifyIcon.ContextMenuStrip = context;

            toolStripItem[0].Click += (se, ex) => {
                //아이콘이기 때문에 이벤트 없음
            };

            toolStripItem[1].Click += (se, ex) => {
                if (MainFormManager != null && !MainFormManager.IsDisposed) {
                    MainFormManager?.Show();
                    MainFormManager?.Focus();
                } else {
                    LoginFormManager?.Show();
                    LoginFormManager?.Focus();
                }
            };
            notifyIcon.MouseDoubleClick += (s, e) => {
                if (MainFormManager != null && !MainFormManager.IsDisposed) {
                    MainFormManager?.Show();
                    MainFormManager?.Focus();
                } else {
                    LoginFormManager?.Show();
                    LoginFormManager?.Focus();
                }
            };

            toolStripItem[4].Click += (se, ex) => {
                if (ShowQuestion("프로그램을 종료하시겠습니까?")) {
                    Tool.LoginFormManager?.Dispose();
                    Tool.MainFormManager?.Dispose();
                    Application.Exit();
                    Environment.Exit(0);
                }
            };
            Application.Run(new Login());
        }
    }
}
