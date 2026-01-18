using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using telltok.db;
using telltok.play.MainControls;
using telltok.Tools;
using static telltok.Tools.Tool;

namespace telltok.play {
    public partial class MainForm : Tools.Form.DevForm {
        PictureBox[] box;
        Image[][] resources;
        Image[] ads_images;

        int select_index = 0;

        Image[][] menu_resources = new Image[3][];
        Timer AdsTimer;

        int AdsImageShowIndex = 0;

        public MainForm() {
            InitializeComponent();
            notifyIcon.Icon = Properties.Resources.icon;

            MainFormManager = this;

            Disposed += (se, ex) => {
                foreach (Control control in Controls) {
                    control.Dispose();
                }
            };

            box = new PictureBox[] {
                pictureBox1,
                pictureBox2,
                pictureBox3
            };

            // 리소스 배열 초기화
            resources = new Image[][] {
                new Image[] {
                    Properties.Resources.main_friend_2,
                    Properties.Resources.main_chat_2,
                    Properties.Resources.main_and_2
                }, // enter
                new Image[] {
                    Properties.Resources.main_friend_3,
                    Properties.Resources.main_chat_3,
                    Properties.Resources.main_and_3
                }, // not_selet
                new Image[] {
                    Properties.Resources.main_friend_1,
                    Properties.Resources.main_chat_1,
                    Properties.Resources.main_and_1
                }  // selet
            };

            UpdateMenuButton(
                null,
                null,
                new Image[] {
                    Properties.Resources.AddFriend_3
                }
            );

            for (int i = 0; i < box.Length; i++) {
                box[i].Image = resources[1][i]; // not_selet 이미지
            }
            box[select_index].Image = resources[2][select_index];

            using (telltokEntities db = new telltokEntities()) {
                var list = db.ads.ToList();
                ads_images = new Image[list.Count];
                for (int i = 0; i < list.Count; i++)
                    ads_images[i] = Tool.GetByteToImage(list[i].ad_image);
            }
            pictureBox4.Image = ads_images[0];
            StartShowADS();

            ShowAlie();
        }

        private void ShowAlie() {
            using (telltokEntities db = new telltokEntities()) {
                var userAlie_addFriend = db.alim.Where(x => x.add_friend.af_take == Tool.UserNo).ToList();

                var userinfo = db.user.FirstOrDefault(x => x.u_no == Tool.UserNo);

                if (userAlie_addFriend.Any()) {
                    Tool.notifyIcon.ShowBalloonTip(1000, "TellTok - 알람이 왔습니다.", $"환영합니다, {userinfo.u_name}님!\n알람수: {userAlie_addFriend.Count}개\n\n클릭시 알람창으로 이동합니다.", ToolTipIcon.Info);
                    Tool.notifyIcon.BalloonTipClicked += (se, ex) => {
                        Alim alim = new Alim();
                        OpenFormRelativeToParent(this, alim, FormPosition.Left);
                    };
                }
            }
        }

        private void UpdateMenuButton(Image[] menu1, Image[] menu2, Image[] menu3) {
            menu_resources = new Image[][] {
                menu1,
                menu2,
                menu3
            };
            PictureBox[] menu_boxes = { pictureBox7, pictureBox6, pictureBox5 };

            for (int i = 0; i < menu_boxes.Length; i++) {
                if (menu_resources[i] != null) {
                    menu_boxes[i].Image = menu_resources[i][0];
                    menu_boxes[i].Cursor = Cursors.Hand;
                } else {
                    menu_boxes[i].Image = null;
                    menu_boxes[i].Cursor = Cursors.Default;
                }
            }
        }

        private void StartShowADS() {
            AdsTimer = new Timer();
            AdsTimer.Interval = 5000;
            AdsTimer.Tick += (se, ex) => {
                AdsImageShowIndex++;
                if (AdsImageShowIndex == 10)
                    AdsImageShowIndex = 0;

                pictureBox4.Image = ads_images[AdsImageShowIndex];
            };
            AdsTimer.Start();
        }

        // PictureBox의 인덱스 반환
        private int GetPictureBoxIndex(PictureBox pictureBox) {
            return Array.IndexOf(box, pictureBox);
        }

        // MouseEnter 이벤트
        private void pictureBox3_MouseEnter(object sender, EventArgs e) {
            var pictureBox = sender as PictureBox;
            int index = GetPictureBoxIndex(pictureBox);
            if (select_index != index) {
                pictureBox.Image = resources[0][index]; // enter 이미지
            }
        }

        // MouseLeave 이벤트
        private void pictureBox3_MouseLeave(object sender, EventArgs e) {
            var pictureBox = sender as PictureBox;
            int index = GetPictureBoxIndex(pictureBox);
            if (select_index != index) {
                pictureBox.Image = resources[1][index]; // not_selet 이미지
            }
        }

        // MouseDown 이벤트
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e) {
            var pictureBox = sender as PictureBox;
            int index = GetPictureBoxIndex(pictureBox);
            if (select_index != index) {
                select_index = index;
                pictureBox.Image = resources[2][index]; // selet 이미지
                for (int i = 0; i < box.Length; i++) {
                    if (i != index) {
                        box[i].Image = resources[1][i]; // not_selet 이미지
                    }
                }
                SetPanel();
            }
        }

        public void SetPanel() {
            foreach (Control control in panel8.Controls) {
                control.Dispose();
            }
            panel8.Controls.Clear();
            if (select_index == 0) {
                label1.Text = "친구";
                Friend friend = new Friend() {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                UpdateMenuButton(null, null, new Image[] {
                        Properties.Resources.AddFriend_3
                    }
                );
                panel8.Controls.Add(friend);
            } else if (select_index == 1) {
                label1.Text = "채팅";
                ChatTap chat = new ChatTap() {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                panel8.Controls.Add(chat);
                Console.WriteLine("start");
                UpdateMenuButton(null, null, null);
            } else if (select_index == 2) {
                label1.Text = "더보기";
                And and = new And() {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                panel8.Controls.Add(and);
                UpdateMenuButton(null,
                    new Image[] {
                        Properties.Resources.and_logout_2
                    },
                    new Image[] {
                        Properties.Resources.and_stop_2
                });
            }
            Tool.FontToAllControls(this);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            SetPanel();
        }

        private void pictureBox5_Click(object sender, EventArgs e) {
            if (select_index == 0) {
                //친구추가
                AddFriend addFriend = new AddFriend();
                OpenFormRelativeToParent(this, addFriend, FormPosition.Right);
            } else if (select_index == 2) {
                if (Tool.ShowQuestion("프로그램을 종료하시겠습니까?")) {
                    Tool.LoginFormManager?.Dispose();
                    Tool.MainFormManager?.Dispose();
                    Application.Exit();
                    Environment.Exit(0);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e) {
            if (select_index == 2) {
                Tool.LoginFormManager.LogOut();
            }
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
            Tool.notifyIcon.ShowBalloonTip(1000, "백그라운드 실행중", "TellTok이 백그라운드에서 실행중입니다.\n종료를 원하시면 시스템트레이에서 종료해주세요.", ToolTipIcon.Info);
            Tool.notifyIcon.BalloonTipClicked += (se, ex) => {
                Alim alim = new Alim();
                OpenFormRelativeToParent(this, alim, FormPosition.Left);
            };
            e.Cancel = true;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e) {
            pictureBox8.Image = Properties.Resources.main_settings;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e) {
            pictureBox8.Image = Properties.Resources.main_settings_hover;
        }

        private void pictureBox8_Click(object sender, EventArgs e) {
            Setting setting = new Setting();
            Tool.OpenFormRelativeToParent(this, setting, FormPosition.Left);
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e) {
            pictureBox9.Image = Properties.Resources.main_alim_hover;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e) {
            pictureBox9.Image = Properties.Resources.main_alim;
        }

        private void pictureBox9_Click(object sender, EventArgs e) {
            Alim alim = new Alim();
            Tool.OpenFormRelativeToParent(this, alim, FormPosition.Left);
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e) {
            Location = Tool.LoginFormManager.Location;

            toolStripItem[1].Enabled = true; //실행
            toolStripItem[2].Enabled = !Properties.Settings.Default.LockModPassword.Equals(""); //잠금모드
            toolStripItem[3].Enabled = true; //로그아웃
            toolStripItem[4].Enabled = true; //프로그램 종료
        }
    }
}
