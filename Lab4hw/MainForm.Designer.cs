namespace Lab4hw
{
    partial class MainForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.websitesDataGridView = new System.Windows.Forms.DataGridView();
            this.statusLabel = new System.Windows.Forms.Label();
            this.addWebButton = new System.Windows.Forms.Button();
            this.webTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.websitesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 618);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(778, 26);
            this.progressBar1.TabIndex = 0;
            // 
            // wordTextBox
            // 
            this.wordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordTextBox.Location = new System.Drawing.Point(16, 24);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(274, 26);
            this.wordTextBox.TabIndex = 1;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Location = new System.Drawing.Point(605, 20);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(123, 35);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(321, 20);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(123, 35);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // websitesDataGridView
            // 
            this.websitesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.websitesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.websitesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.websitesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.websitesDataGridView.Location = new System.Drawing.Point(18, 125);
            this.websitesDataGridView.Name = "websitesDataGridView";
            this.websitesDataGridView.RowTemplate.Height = 28;
            this.websitesDataGridView.Size = new System.Drawing.Size(723, 421);
            this.websitesDataGridView.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 570);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(56, 20);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Status";
            // 
            // addWebButton
            // 
            this.addWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addWebButton.Location = new System.Drawing.Point(321, 71);
            this.addWebButton.Name = "addWebButton";
            this.addWebButton.Size = new System.Drawing.Size(123, 35);
            this.addWebButton.TabIndex = 6;
            this.addWebButton.Text = "Add website";
            this.addWebButton.UseVisualStyleBackColor = true;
            this.addWebButton.Click += new System.EventHandler(this.addWebButton_Click);
            // 
            // webTextBox
            // 
            this.webTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webTextBox.Location = new System.Drawing.Point(16, 75);
            this.webTextBox.Name = "webTextBox";
            this.webTextBox.Size = new System.Drawing.Size(276, 26);
            this.webTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(778, 644);
            this.Controls.Add(this.webTextBox);
            this.Controls.Add(this.addWebButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.websitesDataGridView);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.progressBar1);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "MainForm";
            this.Text = "Find Word On Websites";
            ((System.ComponentModel.ISupportInitialize)(this.websitesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView websitesDataGridView;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button addWebButton;
        private System.Windows.Forms.TextBox webTextBox;
    }
}

