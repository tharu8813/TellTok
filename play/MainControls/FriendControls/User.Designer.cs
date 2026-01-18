namespace telltok.play.MainControls.FriendControls {
	partial class User {
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

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.profilePicture1 = new telltok.Tools.UserControls.ProfilePicture();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(53, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label2_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(55, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // profilePicture1
            // 
            this.profilePicture1.isClickProFIleForm = true;
            this.profilePicture1.Location = new System.Drawing.Point(7, 7);
            this.profilePicture1.Name = "profilePicture1";
            this.profilePicture1.Size = new System.Drawing.Size(40, 40);
            this.profilePicture1.TabIndex = 0;
            this.profilePicture1.UserNo = 0;
            this.profilePicture1.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.profilePicture1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // User
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profilePicture1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "User";
            this.Size = new System.Drawing.Size(300, 55);
            this.Click += new System.EventHandler(this.label2_Click);
            this.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.ResumeLayout(false);

		}

		#endregion

		private Tools.UserControls.ProfilePicture profilePicture1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}
