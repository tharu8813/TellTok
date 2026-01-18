namespace telltok.play.MainControls.ChatControls {
	partial class ChatFIle {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.devButton2 = new telltok.Tools.Forms.DevButton();
			this.devButton1 = new telltok.Tools.Forms.DevButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.devButton2);
			this.panel1.Controls.Add(this.devButton1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(210, 122);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(4, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(175, 11);
			this.label3.TabIndex = 8;
			this.label3.Text = "전송 일자: 2020/00/00 오전 00:00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(4, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 11);
			this.label2.TabIndex = 7;
			this.label2.Text = "확장명: (null)";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 28);
			this.label1.TabIndex = 6;
			this.label1.Text = "(파일 이름)";
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "해당 파일을 다운 받을 경로를 선택해주세요.";
			// 
			// devButton2
			// 
			this.devButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
			this.devButton2.Enabled = false;
			this.devButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devButton2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.devButton2.ForeColor = System.Drawing.Color.White;
			this.devButton2.Location = new System.Drawing.Point(3, 71);
			this.devButton2.Name = "devButton2";
			this.devButton2.Size = new System.Drawing.Size(204, 23);
			this.devButton2.TabIndex = 10;
			this.devButton2.Text = "열기";
			this.devButton2.UseVisualStyleBackColor = false;
			this.devButton2.Click += new System.EventHandler(this.devButton2_Click);
			// 
			// devButton1
			// 
			this.devButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
			this.devButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devButton1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.devButton1.ForeColor = System.Drawing.Color.White;
			this.devButton1.Location = new System.Drawing.Point(3, 96);
			this.devButton1.Name = "devButton1";
			this.devButton1.Size = new System.Drawing.Size(204, 23);
			this.devButton1.TabIndex = 9;
			this.devButton1.Text = "다운로드 하기";
			this.devButton1.UseVisualStyleBackColor = false;
			this.devButton1.Click += new System.EventHandler(this.devButton1_Click);
			// 
			// ChatFIle
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.panel1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ChatFIle";
			this.Size = new System.Drawing.Size(210, 122);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private Tools.Forms.DevButton devButton2;
		private Tools.Forms.DevButton devButton1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}
