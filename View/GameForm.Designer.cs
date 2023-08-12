namespace AbaloneGame.View
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.whitePlayerLbl = new System.Windows.Forms.Label();
            this.blackPlayerLbl = new System.Windows.Forms.Label();
            this.whiteProgress = new System.Windows.Forms.ProgressBar();
            this.blackProgress = new System.Windows.Forms.ProgressBar();
            this.blackScoreLbl = new System.Windows.Forms.Label();
            this.whiteScoreLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(232, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(742, 684);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // whitePlayerLbl
            // 
            this.whitePlayerLbl.AutoSize = true;
            this.whitePlayerLbl.Font = new System.Drawing.Font("Script MT Bold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.whitePlayerLbl.Location = new System.Drawing.Point(980, 12);
            this.whitePlayerLbl.Name = "whitePlayerLbl";
            this.whitePlayerLbl.Size = new System.Drawing.Size(167, 35);
            this.whitePlayerLbl.TabIndex = 1;
            this.whitePlayerLbl.Text = "White player";
            // 
            // blackPlayerLbl
            // 
            this.blackPlayerLbl.AutoSize = true;
            this.blackPlayerLbl.Font = new System.Drawing.Font("Script MT Bold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.blackPlayerLbl.Location = new System.Drawing.Point(12, 12);
            this.blackPlayerLbl.Name = "blackPlayerLbl";
            this.blackPlayerLbl.Size = new System.Drawing.Size(170, 35);
            this.blackPlayerLbl.TabIndex = 3;
            this.blackPlayerLbl.Text = "Black player";
            // 
            // whiteProgress
            // 
            this.whiteProgress.Location = new System.Drawing.Point(1017, 93);
            this.whiteProgress.Maximum = 6;
            this.whiteProgress.Name = "whiteProgress";
            this.whiteProgress.Size = new System.Drawing.Size(100, 23);
            this.whiteProgress.TabIndex = 4;
            this.whiteProgress.Tag = "";
            // 
            // blackProgress
            // 
            this.blackProgress.Location = new System.Drawing.Point(41, 93);
            this.blackProgress.Maximum = 6;
            this.blackProgress.Name = "blackProgress";
            this.blackProgress.Size = new System.Drawing.Size(100, 23);
            this.blackProgress.TabIndex = 5;
            // 
            // blackScoreLbl
            // 
            this.blackScoreLbl.AutoSize = true;
            this.blackScoreLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.blackScoreLbl.Location = new System.Drawing.Point(41, 63);
            this.blackScoreLbl.Name = "blackScoreLbl";
            this.blackScoreLbl.Size = new System.Drawing.Size(54, 21);
            this.blackScoreLbl.TabIndex = 7;
            this.blackScoreLbl.Text = "score:";
            // 
            // whiteScoreLbl
            // 
            this.whiteScoreLbl.AutoSize = true;
            this.whiteScoreLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.whiteScoreLbl.Location = new System.Drawing.Point(1017, 63);
            this.whiteScoreLbl.Name = "whiteScoreLbl";
            this.whiteScoreLbl.Size = new System.Drawing.Size(54, 21);
            this.whiteScoreLbl.TabIndex = 8;
            this.whiteScoreLbl.Text = "score:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(515, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 22);
            this.label1.TabIndex = 9;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 704);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.whiteScoreLbl);
            this.Controls.Add(this.blackScoreLbl);
            this.Controls.Add(this.blackProgress);
            this.Controls.Add(this.whiteProgress);
            this.Controls.Add(this.blackPlayerLbl);
            this.Controls.Add(this.whitePlayerLbl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label whitePlayerLbl;
        private Label blackPlayerLbl;
        private ProgressBar whiteProgress;
        private ProgressBar blackProgress;
        private Label blackScoreLbl;
        private Label whiteScoreLbl;
        private Label label1;
    }
}