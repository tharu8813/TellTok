namespace telltok.play.MainControls.ChatControls {
	partial class ChatList {
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
			this.label3 = new System.Windows.Forms.Label();
			this.profilePicture1 = new telltok.Tools.UserControls.ProfilePicture();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(65, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			this.label1.Click += new System.EventHandler(this.profilePicture1_Click);
			this.label1.MouseEnter += new System.EventHandler(this.label2_MouseEnter_1);
			this.label1.MouseLeave += new System.EventHandler(this.label2_MouseLeave_1);
			// 
			// label2
			// 
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(65, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(220, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "label2";
			this.label2.Click += new System.EventHandler(this.profilePicture1_Click);
			this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter_1);
			this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave_1);
			// 
			// label3
			// 
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(231, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 22);
			this.label3.TabIndex = 3;
			this.label3.Text = "2024-01-01";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.label3.Click += new System.EventHandler(this.profilePicture1_Click);
			this.label3.MouseEnter += new System.EventHandler(this.label2_MouseEnter_1);
			this.label3.MouseLeave += new System.EventHandler(this.label2_MouseLeave_1);
			// 
			// profilePicture1
			// 
			this.profilePicture1.isClickProFIleForm = true;
			this.profilePicture1.Location = new System.Drawing.Point(9, 6);
			this.profilePicture1.Name = "profilePicture1";
			this.profilePicture1.Size = new System.Drawing.Size(50, 50);
			this.profilePicture1.TabIndex = 4;
			this.profilePicture1.UserNo = 0;
			// 
			// ChatList
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.profilePicture1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ChatList";
			this.Size = new System.Drawing.Size(300, 65);
			this.Click += new System.EventHandler(this.profilePicture1_Click);
			this.MouseEnter += new System.EventHandler(this.label2_MouseEnter_1);
			this.MouseLeave += new System.EventHandler(this.label2_MouseLeave_1);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Tools.UserControls.ProfilePicture profilePicture1;
	}
}
