namespace telltok.play.MainControls.ChatControls {
	partial class ChatEdit {
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
			this.devTextBox1 = new telltok.Tools.Forms.DevTextBox();
			this.devButton1 = new telltok.Tools.Forms.DevButton();
			this.SuspendLayout();
			// 
			// devTextBox1
			// 
			this.devTextBox1.AllowDrop = true;
			this.devTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.devTextBox1.ForeColor = System.Drawing.Color.Gray;
			this.devTextBox1.Location = new System.Drawing.Point(12, 12);
			this.devTextBox1.Multiline = true;
			this.devTextBox1.Name = "devTextBox1";
			this.devTextBox1.Size = new System.Drawing.Size(369, 80);
			this.devTextBox1.SubText = "메세지 입력";
			this.devTextBox1.TabIndex = 1;
			this.devTextBox1.Text = "메세지 입력";
			// 
			// devButton1
			// 
			this.devButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
			this.devButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devButton1.ForeColor = System.Drawing.Color.White;
			this.devButton1.Location = new System.Drawing.Point(12, 98);
			this.devButton1.Name = "devButton1";
			this.devButton1.Size = new System.Drawing.Size(369, 33);
			this.devButton1.TabIndex = 2;
			this.devButton1.Text = "수정하기";
			this.devButton1.UseVisualStyleBackColor = false;
			this.devButton1.Click += new System.EventHandler(this.devButton1_Click);
			// 
			// ChatEdit
			// 
			this.ClientSize = new System.Drawing.Size(393, 143);
			this.Controls.Add(this.devButton1);
			this.Controls.Add(this.devTextBox1);
			this.Name = "ChatEdit";
			this.Text = "TellTok - 채팅 수정";
			this.Load += new System.EventHandler(this.ChatEdit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Tools.Forms.DevTextBox devTextBox1;
		private Tools.Forms.DevButton devButton1;
	}
}
