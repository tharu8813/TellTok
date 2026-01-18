using telltok.Tools;

namespace telltok.play {
	partial class Login {
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.devTextBox1 = new telltok.Tools.Forms.DevTextBox();
            this.devTextBox2 = new telltok.Tools.Forms.DevTextBox();
            this.devButton1 = new telltok.Tools.Forms.DevButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilePicture1 = new telltok.Tools.UserControls.ProfilePicture();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::telltok.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // devTextBox1
            // 
            this.devTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devTextBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.devTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.devTextBox1.Location = new System.Drawing.Point(11, 44);
            this.devTextBox1.Name = "devTextBox1";
            this.devTextBox1.Size = new System.Drawing.Size(254, 26);
            this.devTextBox1.SubText = "TellTok 계정";
            this.devTextBox1.TabIndex = 1;
            this.devTextBox1.Text = "TellTok 계정";
            this.devTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.devTextBox1_KeyPress);
            // 
            // devTextBox2
            // 
            this.devTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devTextBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.devTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.devTextBox2.Location = new System.Drawing.Point(11, 67);
            this.devTextBox2.Name = "devTextBox2";
            this.devTextBox2.Size = new System.Drawing.Size(254, 26);
            this.devTextBox2.SubText = "비밀번호";
            this.devTextBox2.TabIndex = 2;
            this.devTextBox2.Text = "비밀번호";
            this.devTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.devTextBox1_KeyPress);
            // 
            // devButton1
            // 
            this.devButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.devButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devButton1.ForeColor = System.Drawing.Color.White;
            this.devButton1.Location = new System.Drawing.Point(11, 102);
            this.devButton1.Name = "devButton1";
            this.devButton1.Size = new System.Drawing.Size(254, 30);
            this.devButton1.TabIndex = 3;
            this.devButton1.Text = "로그인";
            this.devButton1.UseVisualStyleBackColor = false;
            this.devButton1.Click += new System.EventHandler(this.devButton1_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkBox1.Location = new System.Drawing.Point(11, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "자동 로그인";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.ToolTipTitle = "자동 로그인";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(10, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 52);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "비밀번호가 일치하지 않습니다. 확인후 다시 시도 해 주세요.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.devButton1);
            this.panel1.Controls.Add(this.devTextBox2);
            this.panel1.Controls.Add(this.devTextBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(56, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 173);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "잠금모드 상태입니다.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(32, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 38);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maskedTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maskedTextBox1.Location = new System.Drawing.Point(33, 211);
            this.maskedTextBox1.Mask = "0     0     0     0";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '●';
            this.maskedTextBox1.Size = new System.Drawing.Size(255, 35);
            this.maskedTextBox1.TabIndex = 9;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(29, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "잠금모드 암호가 일치하지 않습니다.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(14, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "test1234@gmail.com";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(43, 505);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "잠금모드 비밀번호를 잃어버리셨나요?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.profilePicture1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.maskedTextBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(39, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 532);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // profilePicture1
            // 
            this.profilePicture1.isClickProFIleForm = false;
            this.profilePicture1.Location = new System.Drawing.Point(3, 6);
            this.profilePicture1.Name = "profilePicture1";
            this.profilePicture1.Size = new System.Drawing.Size(306, 110);
            this.profilePicture1.TabIndex = 13;
            this.profilePicture1.UserNo = 0;
            // 
            // Login
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(384, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "TellTok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.VisibleChanged += new System.EventHandler(this.Login_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private Tools.Forms.DevTextBox devTextBox1;
		private Tools.Forms.DevTextBox devTextBox2;
		private Tools.Forms.DevButton devButton1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private Tools.UserControls.ProfilePicture profilePicture1;
	}
}
