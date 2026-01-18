namespace telltok.play {
	partial class Chat {
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.devTextBox1 = new telltok.Tools.Forms.DevTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.devButton1 = new telltok.Tools.Forms.DevButton();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.profilePicture1 = new telltok.Tools.UserControls.ProfilePicture();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.devTextBox1);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.pictureBox2);
			this.panel2.Controls.Add(this.devButton1);
			this.panel2.Controls.Add(this.trackBar1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 493);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(382, 118);
			this.panel2.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::telltok.Properties.Resources.chat_emoticon;
			this.pictureBox1.Location = new System.Drawing.Point(39, 89);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(23, 23);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// devTextBox1
			// 
			this.devTextBox1.AllowDrop = true;
			this.devTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.devTextBox1.ForeColor = System.Drawing.Color.Gray;
			this.devTextBox1.Location = new System.Drawing.Point(12, 6);
			this.devTextBox1.Multiline = true;
			this.devTextBox1.Name = "devTextBox1";
			this.devTextBox1.Size = new System.Drawing.Size(360, 80);
			this.devTextBox1.SubText = "메세지 입력";
			this.devTextBox1.TabIndex = 0;
			this.devTextBox1.Text = "메세지 입력";
			this.devTextBox1.TextChanged += new System.EventHandler(this.devTextBox1_TextChanged);
			this.devTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.devTextBox1_DragDrop);
			this.devTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.devTextBox1_DragEnter);
			this.devTextBox1.DragLeave += new System.EventHandler(this.devTextBox1_DragLeave);
			this.devTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.devTextBox1_KeyDown);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(9, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(364, 83);
			this.button1.TabIndex = 4;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::telltok.Properties.Resources.chat_button;
			this.pictureBox2.Location = new System.Drawing.Point(10, 89);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(23, 23);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 3;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// devButton1
			// 
			this.devButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
			this.devButton1.Enabled = false;
			this.devButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devButton1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.devButton1.ForeColor = System.Drawing.Color.White;
			this.devButton1.Location = new System.Drawing.Point(310, 92);
			this.devButton1.Name = "devButton1";
			this.devButton1.Size = new System.Drawing.Size(62, 23);
			this.devButton1.TabIndex = 2;
			this.devButton1.Text = "전송";
			this.devButton1.UseVisualStyleBackColor = false;
			this.devButton1.Click += new System.EventHandler(this.devButton1_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.trackBar1.Location = new System.Drawing.Point(186, 92);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Minimum = 10;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(118, 23);
			this.trackBar1.TabIndex = 1;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.Value = 100;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.profilePicture1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(382, 75);
			this.panel3.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(65, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// profilePicture1
			// 
			this.profilePicture1.isClickProFIleForm = true;
			this.profilePicture1.Location = new System.Drawing.Point(14, 15);
			this.profilePicture1.Name = "profilePicture1";
			this.profilePicture1.Size = new System.Drawing.Size(45, 45);
			this.profilePicture1.TabIndex = 0;
			this.profilePicture1.UserNo = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 418);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 75);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(382, 418);
			this.panel1.TabIndex = 9;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "파일을 선택해주세요.";
			this.openFileDialog1.Filter = "모든 파일|*.*";
			this.openFileDialog1.Title = "전송할 파일";
			// 
			// Chat
			// 
			this.ClientSize = new System.Drawing.Size(382, 611);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.KeyPreview = true;
			this.Name = "Chat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
			this.Load += new System.EventHandler(this.Chat_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Chat_KeyDown);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private Tools.UserControls.ProfilePicture profilePicture1;
		private System.Windows.Forms.TrackBar trackBar1;
		private Tools.Forms.DevButton devButton1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Tools.Forms.DevTextBox devTextBox1;
		public System.Windows.Forms.Label label1;
	}
}
