namespace SerialFtp
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.リスト取得ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewRemote = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripPrgressBarRequest = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBarResponse = new System.Windows.Forms.ToolStripProgressBar();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(496, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// ファイルToolStripMenuItem
			// 
			this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.リスト取得ToolStripMenuItem,
            this.toolStripSeparator1,
            this.終了ToolStripMenuItem});
			this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.ファイルToolStripMenuItem.Text = "ファイル";
			// 
			// リスト取得ToolStripMenuItem
			// 
			this.リスト取得ToolStripMenuItem.Name = "リスト取得ToolStripMenuItem";
			this.リスト取得ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.リスト取得ToolStripMenuItem.Text = "リスト取得";
			this.リスト取得ToolStripMenuItem.Click += new System.EventHandler(this.リスト取得ToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
			// 
			// 終了ToolStripMenuItem
			// 
			this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
			this.終了ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.終了ToolStripMenuItem.Text = "終了";
			this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
			// 
			// listViewRemote
			// 
			this.listViewRemote.AllowDrop = true;
			this.listViewRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.listViewRemote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewRemote.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listViewRemote.FullRowSelect = true;
			this.listViewRemote.Location = new System.Drawing.Point(0, 24);
			this.listViewRemote.Name = "listViewRemote";
			this.listViewRemote.Size = new System.Drawing.Size(496, 330);
			this.listViewRemote.TabIndex = 1;
			this.listViewRemote.UseCompatibleStateImageBehavior = false;
			this.listViewRemote.View = System.Windows.Forms.View.Details;
			this.listViewRemote.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewRemote_DragEnter);
			this.listViewRemote.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewRemote_DragDrop);
			this.listViewRemote.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewRemote_ItemDrag);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ファイル名";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "機械語";
			this.columnHeader2.Width = 70;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "書込禁止";
			this.columnHeader3.Width = 70;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "編集禁止";
			this.columnHeader4.Width = 70;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "書込確認";
			this.columnHeader5.Width = 70;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "アスキー";
			this.columnHeader6.Width = 70;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripPrgressBarRequest,
            this.toolStripStatusLabel2,
            this.toolStripProgressBarResponse});
			this.statusStrip.Location = new System.Drawing.Point(0, 332);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(496, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
			this.toolStripStatusLabel1.Text = "リクエスト";
			// 
			// toolStripPrgressBarRequest
			// 
			this.toolStripPrgressBarRequest.Name = "toolStripPrgressBarRequest";
			this.toolStripPrgressBarRequest.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(29, 17);
			this.toolStripStatusLabel2.Text = "応答";
			// 
			// toolStripProgressBarResponse
			// 
			this.toolStripProgressBarResponse.Name = "toolStripProgressBarResponse";
			this.toolStripProgressBarResponse.Size = new System.Drawing.Size(100, 16);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 354);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.listViewRemote);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "SerialFtp";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
		private System.Windows.Forms.ListView listViewRemote;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem リスト取得ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripPrgressBarRequest;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarResponse;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;

	}
}

