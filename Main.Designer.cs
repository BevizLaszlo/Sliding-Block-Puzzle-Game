namespace NumberMatrixGame
{
    partial class Main
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.winLabel = new System.Windows.Forms.Label();
            this.reshuffleBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.turnsLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.GamePanel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.GamePanel.Location = new System.Drawing.Point(40, 52);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(300, 300);
            this.GamePanel.TabIndex = 0;
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.winLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.winLabel.Location = new System.Drawing.Point(36, 15);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(117, 24);
            this.winLabel.TabIndex = 1;
            this.winLabel.Text = "YOU WON!";
            this.winLabel.Visible = false;
            // 
            // reshuffleBtn
            // 
            this.reshuffleBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.reshuffleBtn.Location = new System.Drawing.Point(128, 376);
            this.reshuffleBtn.Name = "reshuffleBtn";
            this.reshuffleBtn.Size = new System.Drawing.Size(125, 46);
            this.reshuffleBtn.TabIndex = 2;
            this.reshuffleBtn.Text = "Shuffle Puzzle";
            this.reshuffleBtn.UseVisualStyleBackColor = true;
            this.reshuffleBtn.Click += new System.EventHandler(this.reshuffleBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainPanel.Controls.Add(this.turnsLabel);
            this.mainPanel.Controls.Add(this.reshuffleBtn);
            this.mainPanel.Controls.Add(this.winLabel);
            this.mainPanel.Controls.Add(this.GamePanel);
            this.mainPanel.Location = new System.Drawing.Point(210, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(381, 444);
            this.mainPanel.TabIndex = 3;
            // 
            // turnsLabel
            // 
            this.turnsLabel.AutoSize = true;
            this.turnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.turnsLabel.ForeColor = System.Drawing.Color.White;
            this.turnsLabel.Location = new System.Drawing.Point(274, 18);
            this.turnsLabel.Name = "turnsLabel";
            this.turnsLabel.Size = new System.Drawing.Size(66, 20);
            this.turnsLabel.TabIndex = 3;
            this.turnsLabel.Text = "Turns: 0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.mainPanel);
            this.Name = "Main";
            this.Text = "Sliding Block Puzzle";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button reshuffleBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label turnsLabel;
    }
}

