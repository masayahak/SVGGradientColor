namespace SVGGradientColor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cbOutSize = new System.Windows.Forms.ComboBox();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pbBackColor = new System.Windows.Forms.PictureBox();
            this.btnSwitchColor = new System.Windows.Forms.Button();
            this.pbColor2 = new System.Windows.Forms.PictureBox();
            this.pbColor1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialogBackColor = new System.Windows.Forms.ColorDialog();
            this.panelImageBack = new System.Windows.Forms.Panel();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStroke = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor1)).BeginInit();
            this.panelImageBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.AllowDrop = true;
            this.txtFile.Location = new System.Drawing.Point(47, 27);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(738, 31);
            this.txtFile.TabIndex = 0;
            this.txtFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFile_KeyDown);
            this.txtFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFile_KeyPress);
            this.txtFile.Leave += new System.EventHandler(this.txtFile_Leave);
            // 
            // cbOutSize
            // 
            this.cbOutSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutSize.FormattingEnabled = true;
            this.cbOutSize.Items.AddRange(new object[] {
            "16",
            "32",
            "48",
            "64",
            "128",
            "256",
            "512"});
            this.cbOutSize.Location = new System.Drawing.Point(531, 568);
            this.cbOutSize.Margin = new System.Windows.Forms.Padding(2);
            this.cbOutSize.Name = "cbOutSize";
            this.cbOutSize.Size = new System.Drawing.Size(88, 32);
            this.cbOutSize.TabIndex = 7;
            this.cbOutSize.SelectedIndexChanged += new System.EventHandler(this.cbOutSize_SelectedIndexChanged);
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Left Top to Right Bottom",
            "Right Top to Left Bottom",
            "Top to Bottom",
            "Left to Right"});
            this.cbDirection.Location = new System.Drawing.Point(528, 138);
            this.cbDirection.Margin = new System.Windows.Forms.Padding(2);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(297, 32);
            this.cbDirection.TabIndex = 8;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(689, 568);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save as";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(524, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Gradient Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(547, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Color 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(710, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Color 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(530, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Open SVG File";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(630, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Back Color";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(789, 24);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(36, 36);
            this.btnReload.TabIndex = 20;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(7, 24);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 36);
            this.btnOpen.TabIndex = 19;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pbBackColor
            // 
            this.pbBackColor.BackColor = System.Drawing.Color.Gray;
            this.pbBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBackColor.Location = new System.Drawing.Point(635, 407);
            this.pbBackColor.Margin = new System.Windows.Forms.Padding(2);
            this.pbBackColor.Name = "pbBackColor";
            this.pbBackColor.Size = new System.Drawing.Size(77, 78);
            this.pbBackColor.TabIndex = 17;
            this.pbBackColor.TabStop = false;
            this.pbBackColor.DoubleClick += new System.EventHandler(this.pbBackColor_DoubleClick);
            // 
            // btnSwitchColor
            // 
            this.btnSwitchColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.btnSwitchColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSwitchColor.FlatAppearance.BorderSize = 0;
            this.btnSwitchColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchColor.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchColor.Image")));
            this.btnSwitchColor.Location = new System.Drawing.Point(653, 289);
            this.btnSwitchColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnSwitchColor.Name = "btnSwitchColor";
            this.btnSwitchColor.Size = new System.Drawing.Size(36, 36);
            this.btnSwitchColor.TabIndex = 10;
            this.btnSwitchColor.UseVisualStyleBackColor = false;
            this.btnSwitchColor.Click += new System.EventHandler(this.btnSwitchColor_Click);
            // 
            // pbColor2
            // 
            this.pbColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(218)))), ((int)(((byte)(198)))));
            this.pbColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor2.Location = new System.Drawing.Point(714, 265);
            this.pbColor2.Margin = new System.Windows.Forms.Padding(2);
            this.pbColor2.Name = "pbColor2";
            this.pbColor2.Size = new System.Drawing.Size(77, 78);
            this.pbColor2.TabIndex = 6;
            this.pbColor2.TabStop = false;
            this.pbColor2.DoubleClick += new System.EventHandler(this.pbColor2_DoubleClick);
            // 
            // pbColor1
            // 
            this.pbColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(0)))), ((int)(((byte)(179)))));
            this.pbColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor1.Location = new System.Drawing.Point(551, 265);
            this.pbColor1.Margin = new System.Windows.Forms.Padding(2);
            this.pbColor1.Name = "pbColor1";
            this.pbColor1.Size = new System.Drawing.Size(77, 78);
            this.pbColor1.TabIndex = 4;
            this.pbColor1.TabStop = false;
            this.pbColor1.DoubleClick += new System.EventHandler(this.pbColor1_DoubleClick);
            // 
            // panelImageBack
            // 
            this.panelImageBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelImageBack.Controls.Add(this.pbTestImage);
            this.panelImageBack.Location = new System.Drawing.Point(7, 90);
            this.panelImageBack.Name = "panelImageBack";
            this.panelImageBack.Size = new System.Drawing.Size(512, 512);
            this.panelImageBack.TabIndex = 22;
            // 
            // pbTestImage
            // 
            this.pbTestImage.BackColor = System.Drawing.Color.Gray;
            this.pbTestImage.Location = new System.Drawing.Point(224, 224);
            this.pbTestImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(64, 64);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTestImage.TabIndex = 3;
            this.pbTestImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(631, 574);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "PX";
            // 
            // lblStroke
            // 
            this.lblStroke.AutoSize = true;
            this.lblStroke.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStroke.ForeColor = System.Drawing.Color.Violet;
            this.lblStroke.Location = new System.Drawing.Point(50, 63);
            this.lblStroke.Name = "lblStroke";
            this.lblStroke.Size = new System.Drawing.Size(714, 24);
            this.lblStroke.TabIndex = 24;
            this.lblStroke.Text = "This SVG File contains \"stroke\" attributes in \"SVG\" tag.  Sorry, I can\'t draw gra" +
    "diental well.";
            this.lblStroke.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(833, 607);
            this.Controls.Add(this.lblStroke);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbBackColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSwitchColor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbDirection);
            this.Controls.Add(this.cbOutSize);
            this.Controls.Add(this.pbColor2);
            this.Controls.Add(this.pbColor1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.panelImageBack);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVG Gradient Color";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor1)).EndInit();
            this.panelImageBack.ResumeLayout(false);
            this.panelImageBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.PictureBox pbColor1;
        private System.Windows.Forms.PictureBox pbColor2;
        private System.Windows.Forms.ComboBox cbOutSize;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSwitchColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbBackColor;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialogBackColor;
        private System.Windows.Forms.Panel panelImageBack;
        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStroke;
    }
}