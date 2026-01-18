namespace telltok.play.MainControls.UserProfileControls {
	partial class EditProfile {
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
            this.label1 = new System.Windows.Forms.Label();
            this.devTextBox1 = new telltok.Tools.Forms.DevTextBox();
            this.devTextBox2 = new telltok.Tools.Forms.DevTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.devButton1 = new telltok.Tools.Forms.DevButton();
            this.devButton2 = new telltok.Tools.Forms.DevButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.profilePicture1 = new telltok.Tools.UserControls.ProfilePicture();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "프로필 편집";
            // 
            // devTextBox1
            // 
            this.devTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devTextBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.devTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.devTextBox1.Location = new System.Drawing.Point(16, 169);
            this.devTextBox1.MaxLength = 15;
            this.devTextBox1.Name = "devTextBox1";
            this.devTextBox1.Size = new System.Drawing.Size(233, 26);
            this.devTextBox1.SubText = "이름";
            this.devTextBox1.TabIndex = 4;
            this.devTextBox1.Text = "이름";
            this.devTextBox1.TextChanged += new System.EventHandler(this.devTextBox1_TextChanged);
            // 
            // devTextBox2
            // 
            this.devTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devTextBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.devTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.devTextBox2.Location = new System.Drawing.Point(16, 225);
            this.devTextBox2.MaxLength = 45;
            this.devTextBox2.Multiline = true;
            this.devTextBox2.Name = "devTextBox2";
            this.devTextBox2.Size = new System.Drawing.Size(233, 80);
            this.devTextBox2.SubText = "상태 메세지";
            this.devTextBox2.TabIndex = 5;
            this.devTextBox2.Text = "상태 메세지";
            this.devTextBox2.TextChanged += new System.EventHandler(this.devTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "1 ~ 15자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "1 ~ 45자";
            // 
            // devButton1
            // 
            this.devButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.devButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devButton1.ForeColor = System.Drawing.Color.White;
            this.devButton1.Location = new System.Drawing.Point(138, 348);
            this.devButton1.Name = "devButton1";
            this.devButton1.Size = new System.Drawing.Size(111, 30);
            this.devButton1.TabIndex = 8;
            this.devButton1.Text = "수정";
            this.devButton1.UseVisualStyleBackColor = false;
            this.devButton1.Click += new System.EventHandler(this.devButton1_Click);
            // 
            // devButton2
            // 
            this.devButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.devButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devButton2.ForeColor = System.Drawing.Color.Black;
            this.devButton2.Location = new System.Drawing.Point(12, 348);
            this.devButton2.Name = "devButton2";
            this.devButton2.Size = new System.Drawing.Size(111, 30);
            this.devButton2.TabIndex = 9;
            this.devButton2.Text = "닫기";
            this.devButton2.UseVisualStyleBackColor = false;
            this.devButton2.Click += new System.EventHandler(this.devButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "프로필 사진|*.jpg;*.jpeg";
            // 
            // profilePicture1
            // 
            this.profilePicture1.isClickProFIleForm = false;
            this.profilePicture1.Location = new System.Drawing.Point(84, 47);
            this.profilePicture1.Name = "profilePicture1";
            this.profilePicture1.Size = new System.Drawing.Size(100, 100);
            this.profilePicture1.TabIndex = 0;
            this.profilePicture1.UserNo = 0;
            // 
            // EditProfile
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(261, 390);
            this.Controls.Add(this.devButton2);
            this.Controls.Add(this.devButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.devTextBox2);
            this.Controls.Add(this.devTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profilePicture1);
            this.Name = "EditProfile";
            this.Text = "TellTok - 프로필 편집";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private Tools.Forms.DevTextBox devTextBox1;
		private Tools.Forms.DevTextBox devTextBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Tools.Forms.DevButton devButton1;
		private Tools.Forms.DevButton devButton2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private Tools.UserControls.ProfilePicture profilePicture1;
	}
}
