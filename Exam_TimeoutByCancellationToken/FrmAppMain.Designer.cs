
namespace Exam_TimeoutByCancellationToken
{
    partial class FrmAppMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnTickTackWithTimeout = new System.Windows.Forms.Button();
            this.GrpTicktack = new System.Windows.Forms.GroupBox();
            this.BtnTicktackNoTimeout = new System.Windows.Forms.Button();
            this.TtlTimeout = new System.Windows.Forms.Label();
            this.NumTimeout = new System.Windows.Forms.NumericUpDown();
            this.NumRepeat = new System.Windows.Forms.NumericUpDown();
            this.TtlRepeat = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.RunningStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.SLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SBtnCancel = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTest_TestLogic1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTest_TestLogic2 = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpTicktack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRepeat)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTickTackWithTimeout
            // 
            this.BtnTickTackWithTimeout.Location = new System.Drawing.Point(32, 64);
            this.BtnTickTackWithTimeout.Name = "BtnTickTackWithTimeout";
            this.BtnTickTackWithTimeout.Size = new System.Drawing.Size(168, 19);
            this.BtnTickTackWithTimeout.TabIndex = 2;
            this.BtnTickTackWithTimeout.Text = "Ticktack with timeout";
            this.BtnTickTackWithTimeout.UseVisualStyleBackColor = true;
            this.BtnTickTackWithTimeout.Click += new System.EventHandler(this.BtnTickTackWithTimeout_Click);
            // 
            // GrpTicktack
            // 
            this.GrpTicktack.Controls.Add(this.BtnTicktackNoTimeout);
            this.GrpTicktack.Controls.Add(this.TtlTimeout);
            this.GrpTicktack.Controls.Add(this.NumTimeout);
            this.GrpTicktack.Controls.Add(this.NumRepeat);
            this.GrpTicktack.Controls.Add(this.BtnTickTackWithTimeout);
            this.GrpTicktack.Controls.Add(this.TtlRepeat);
            this.GrpTicktack.Location = new System.Drawing.Point(16, 40);
            this.GrpTicktack.Name = "GrpTicktack";
            this.GrpTicktack.Size = new System.Drawing.Size(456, 144);
            this.GrpTicktack.TabIndex = 1;
            this.GrpTicktack.TabStop = false;
            this.GrpTicktack.Text = "Ticktack";
            // 
            // BtnTicktackNoTimeout
            // 
            this.BtnTicktackNoTimeout.Location = new System.Drawing.Point(32, 96);
            this.BtnTicktackNoTimeout.Name = "BtnTicktackNoTimeout";
            this.BtnTicktackNoTimeout.Size = new System.Drawing.Size(168, 19);
            this.BtnTicktackNoTimeout.TabIndex = 5;
            this.BtnTicktackNoTimeout.Text = "Ticktack (No timeout)";
            this.BtnTicktackNoTimeout.UseVisualStyleBackColor = true;
            this.BtnTicktackNoTimeout.Click += new System.EventHandler(this.BtnTicktackNoTimeout_Click);
            // 
            // TtlTimeout
            // 
            this.TtlTimeout.AutoSize = true;
            this.TtlTimeout.Location = new System.Drawing.Point(288, 64);
            this.TtlTimeout.Name = "TtlTimeout";
            this.TtlTimeout.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.TtlTimeout.Size = new System.Drawing.Size(114, 18);
            this.TtlTimeout.TabIndex = 4;
            this.TtlTimeout.Text = "ms (-1 = No timeout)";
            // 
            // NumTimeout
            // 
            this.NumTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumTimeout.Location = new System.Drawing.Point(208, 64);
            this.NumTimeout.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NumTimeout.Name = "NumTimeout";
            this.NumTimeout.Size = new System.Drawing.Size(72, 19);
            this.NumTimeout.TabIndex = 3;
            this.NumTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumTimeout.Value = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            // 
            // NumRepeat
            // 
            this.NumRepeat.Location = new System.Drawing.Point(96, 32);
            this.NumRepeat.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumRepeat.Name = "NumRepeat";
            this.NumRepeat.Size = new System.Drawing.Size(72, 19);
            this.NumRepeat.TabIndex = 1;
            this.NumRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumRepeat.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // TtlRepeat
            // 
            this.TtlRepeat.AutoSize = true;
            this.TtlRepeat.Location = new System.Drawing.Point(32, 32);
            this.TtlRepeat.Name = "TtlRepeat";
            this.TtlRepeat.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.TtlRepeat.Size = new System.Drawing.Size(43, 18);
            this.TtlRepeat.TabIndex = 0;
            this.TtlRepeat.Text = "Repeat:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunningStatus,
            this.SLblStatus,
            this.SBtnCancel});
            this.statusStrip.Location = new System.Drawing.Point(0, 196);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(488, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // RunningStatus
            // 
            this.RunningStatus.MarqueeAnimationSpeed = 20;
            this.RunningStatus.Name = "RunningStatus";
            this.RunningStatus.Size = new System.Drawing.Size(100, 16);
            this.RunningStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // SLblStatus
            // 
            this.SLblStatus.Name = "SLblStatus";
            this.SLblStatus.Size = new System.Drawing.Size(311, 17);
            this.SLblStatus.Spring = true;
            this.SLblStatus.Text = "Status Message";
            this.SLblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SBtnCancel
            // 
            this.SBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SBtnCancel.Name = "SBtnCancel";
            this.SBtnCancel.ShowDropDownArrow = false;
            this.SBtnCancel.Size = new System.Drawing.Size(60, 20);
            this.SBtnCancel.Text = "[ Cancel ]";
            this.SBtnCancel.Click += new System.EventHandler(this.SBtnCancel_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTest});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(488, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MnuTest
            // 
            this.MnuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTest_TestLogic1,
            this.MnuTest_TestLogic2});
            this.MnuTest.Name = "MnuTest";
            this.MnuTest.Size = new System.Drawing.Size(39, 20);
            this.MnuTest.Text = "&Test";
            // 
            // MnuTest_TestLogic1
            // 
            this.MnuTest_TestLogic1.Name = "MnuTest_TestLogic1";
            this.MnuTest_TestLogic1.Size = new System.Drawing.Size(132, 22);
            this.MnuTest_TestLogic1.Text = "Test Logic&1";
            this.MnuTest_TestLogic1.Click += new System.EventHandler(this.MnuTest_TestLogic1_Click);
            // 
            // MnuTest_TestLogic2
            // 
            this.MnuTest_TestLogic2.Name = "MnuTest_TestLogic2";
            this.MnuTest_TestLogic2.Size = new System.Drawing.Size(132, 22);
            this.MnuTest_TestLogic2.Text = "Test Logic&2";
            this.MnuTest_TestLogic2.Click += new System.EventHandler(this.MnuTest_TestLogic2_Click);
            // 
            // FrmAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 218);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.GrpTicktack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmAppMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examination And Example for Timeout By CancellationToken";
            this.Load += new System.EventHandler(this.FrmAppMain_Load);
            this.GrpTicktack.ResumeLayout(false);
            this.GrpTicktack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRepeat)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnTickTackWithTimeout;
        private System.Windows.Forms.GroupBox GrpTicktack;
        private System.Windows.Forms.NumericUpDown NumRepeat;
        private System.Windows.Forms.Label TtlRepeat;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SLblStatus;
        private System.Windows.Forms.ToolStripDropDownButton SBtnCancel;
        private System.Windows.Forms.ToolStripProgressBar RunningStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuTest;
        private System.Windows.Forms.ToolStripMenuItem MnuTest_TestLogic1;
        private System.Windows.Forms.ToolStripMenuItem MnuTest_TestLogic2;
        private System.Windows.Forms.Label TtlTimeout;
        private System.Windows.Forms.NumericUpDown NumTimeout;
        private System.Windows.Forms.Button BtnTicktackNoTimeout;
    }
}

