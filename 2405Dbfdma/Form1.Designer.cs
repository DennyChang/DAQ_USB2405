namespace _405dma
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbxDisplay = new System.Windows.Forms.PictureBox();
            this.tbxYdown = new System.Windows.Forms.TextBox();
            this.cbxSelBoard = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.txtChannelXSensitivity = new System.Windows.Forms.TextBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSelectSavePath = new System.Windows.Forms.Button();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblChannelY = new System.Windows.Forms.Label();
            this.lblChannelZ = new System.Windows.Forms.Label();
            this.lblChannelX = new System.Windows.Forms.Label();
            this.lbllXSensitivity = new System.Windows.Forms.Label();
            this.lblChannelXColor = new System.Windows.Forms.Label();
            this.lblChannelZColor = new System.Windows.Forms.Label();
            this.lblChannelYColor = new System.Windows.Forms.Label();
            this.txtChannelYSensitivity = new System.Windows.Forms.TextBox();
            this.txtChannelZSensitivity = new System.Windows.Forms.TextBox();
            this.lbllYSensitivity = new System.Windows.Forms.Label();
            this.lbllZSensitivity = new System.Windows.Forms.Label();
            this.tbxYup = new System.Windows.Forms.TextBox();
            this.textYZero = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDisplay
            // 
            this.pbxDisplay.Location = new System.Drawing.Point(55, 13);
            this.pbxDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxDisplay.Name = "pbxDisplay";
            this.pbxDisplay.Size = new System.Drawing.Size(600, 390);
            this.pbxDisplay.TabIndex = 0;
            this.pbxDisplay.TabStop = false;
            // 
            // tbxYdown
            // 
            this.tbxYdown.BackColor = System.Drawing.SystemColors.Control;
            this.tbxYdown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxYdown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxYdown.Location = new System.Drawing.Point(1, 389);
            this.tbxYdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxYdown.Name = "tbxYdown";
            this.tbxYdown.Size = new System.Drawing.Size(48, 14);
            this.tbxYdown.TabIndex = 2;
            this.tbxYdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbxSelBoard
            // 
            this.cbxSelBoard.Enabled = false;
            this.cbxSelBoard.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelBoard.FormattingEnabled = true;
            this.cbxSelBoard.Location = new System.Drawing.Point(532, 448);
            this.cbxSelBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxSelBoard.Name = "cbxSelBoard";
            this.cbxSelBoard.Size = new System.Drawing.Size(79, 23);
            this.cbxSelBoard.TabIndex = 11;
            this.cbxSelBoard.Text = "USB-2405";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Module ID:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(643, 439);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 29);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Range: +-10V";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(643, 476);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 29);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(55, 421);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(100, 21);
            this.txtTest.TabIndex = 18;
            // 
            // txtChannelXSensitivity
            // 
            this.txtChannelXSensitivity.Location = new System.Drawing.Point(725, 70);
            this.txtChannelXSensitivity.Name = "txtChannelXSensitivity";
            this.txtChannelXSensitivity.Size = new System.Drawing.Size(38, 21);
            this.txtChannelXSensitivity.TabIndex = 19;
            this.txtChannelXSensitivity.Text = "9.83 ";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(352, 484);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(226, 21);
            this.txtSavePath.TabIndex = 20;
            this.txtSavePath.Text = "D:\\Users\\Denny\\Desktop\\ADLink";
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.Location = new System.Drawing.Point(584, 482);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(27, 23);
            this.btnSelectSavePath.TabIndex = 21;
            this.btnSelectSavePath.Text = "...";
            this.btnSelectSavePath.UseVisualStyleBackColor = true;
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(315, 486);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(31, 15);
            this.lblSavePath.TabIndex = 22;
            this.lblSavePath.Text = "path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 23;
            // 
            // lblChannelY
            // 
            this.lblChannelY.AutoSize = true;
            this.lblChannelY.Location = new System.Drawing.Point(661, 98);
            this.lblChannelY.Name = "lblChannelY";
            this.lblChannelY.Size = new System.Drawing.Size(14, 15);
            this.lblChannelY.TabIndex = 23;
            this.lblChannelY.Text = "Y";
            // 
            // lblChannelZ
            // 
            this.lblChannelZ.AutoSize = true;
            this.lblChannelZ.Location = new System.Drawing.Point(661, 175);
            this.lblChannelZ.Name = "lblChannelZ";
            this.lblChannelZ.Size = new System.Drawing.Size(14, 15);
            this.lblChannelZ.TabIndex = 23;
            this.lblChannelZ.Text = "Z";
            // 
            // lblChannelX
            // 
            this.lblChannelX.AutoSize = true;
            this.lblChannelX.Location = new System.Drawing.Point(661, 42);
            this.lblChannelX.Name = "lblChannelX";
            this.lblChannelX.Size = new System.Drawing.Size(14, 15);
            this.lblChannelX.TabIndex = 23;
            this.lblChannelX.Text = "X";
            // 
            // lbllXSensitivity
            // 
            this.lbllXSensitivity.AutoSize = true;
            this.lbllXSensitivity.Location = new System.Drawing.Point(661, 70);
            this.lbllXSensitivity.Name = "lbllXSensitivity";
            this.lbllXSensitivity.Size = new System.Drawing.Size(64, 15);
            this.lbllXSensitivity.TabIndex = 23;
            this.lbllXSensitivity.Text = "Sensitivity:";
            // 
            // lblChannelXColor
            // 
            this.lblChannelXColor.AutoSize = true;
            this.lblChannelXColor.BackColor = System.Drawing.Color.Yellow;
            this.lblChannelXColor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblChannelXColor.Location = new System.Drawing.Point(681, 41);
            this.lblChannelXColor.Name = "lblChannelXColor";
            this.lblChannelXColor.Size = new System.Drawing.Size(20, 16);
            this.lblChannelXColor.TabIndex = 24;
            this.lblChannelXColor.Text = "   ";
            // 
            // lblChannelZColor
            // 
            this.lblChannelZColor.AutoSize = true;
            this.lblChannelZColor.BackColor = System.Drawing.Color.Blue;
            this.lblChannelZColor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblChannelZColor.Location = new System.Drawing.Point(681, 175);
            this.lblChannelZColor.Name = "lblChannelZColor";
            this.lblChannelZColor.Size = new System.Drawing.Size(20, 16);
            this.lblChannelZColor.TabIndex = 25;
            this.lblChannelZColor.Text = "   ";
            // 
            // lblChannelYColor
            // 
            this.lblChannelYColor.AutoSize = true;
            this.lblChannelYColor.BackColor = System.Drawing.Color.LightGreen;
            this.lblChannelYColor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblChannelYColor.Location = new System.Drawing.Point(681, 98);
            this.lblChannelYColor.Name = "lblChannelYColor";
            this.lblChannelYColor.Size = new System.Drawing.Size(20, 16);
            this.lblChannelYColor.TabIndex = 26;
            this.lblChannelYColor.Text = "   ";
            // 
            // txtChannelYSensitivity
            // 
            this.txtChannelYSensitivity.Location = new System.Drawing.Point(725, 136);
            this.txtChannelYSensitivity.Name = "txtChannelYSensitivity";
            this.txtChannelYSensitivity.Size = new System.Drawing.Size(38, 21);
            this.txtChannelYSensitivity.TabIndex = 19;
            this.txtChannelYSensitivity.Text = "10.4";
            // 
            // txtChannelZSensitivity
            // 
            this.txtChannelZSensitivity.Location = new System.Drawing.Point(725, 208);
            this.txtChannelZSensitivity.Name = "txtChannelZSensitivity";
            this.txtChannelZSensitivity.Size = new System.Drawing.Size(38, 21);
            this.txtChannelZSensitivity.TabIndex = 19;
            this.txtChannelZSensitivity.Text = "9.32";
            // 
            // lbllYSensitivity
            // 
            this.lbllYSensitivity.AutoSize = true;
            this.lbllYSensitivity.Location = new System.Drawing.Point(661, 136);
            this.lbllYSensitivity.Name = "lbllYSensitivity";
            this.lbllYSensitivity.Size = new System.Drawing.Size(64, 15);
            this.lbllYSensitivity.TabIndex = 23;
            this.lbllYSensitivity.Text = "Sensitivity:";
            // 
            // lbllZSensitivity
            // 
            this.lbllZSensitivity.AutoSize = true;
            this.lbllZSensitivity.Location = new System.Drawing.Point(661, 208);
            this.lbllZSensitivity.Name = "lbllZSensitivity";
            this.lbllZSensitivity.Size = new System.Drawing.Size(64, 15);
            this.lbllZSensitivity.TabIndex = 23;
            this.lbllZSensitivity.Text = "Sensitivity:";
            // 
            // tbxYup
            // 
            this.tbxYup.BackColor = System.Drawing.SystemColors.Control;
            this.tbxYup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxYup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxYup.Location = new System.Drawing.Point(1, 13);
            this.tbxYup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxYup.Name = "tbxYup";
            this.tbxYup.ReadOnly = true;
            this.tbxYup.Size = new System.Drawing.Size(48, 14);
            this.tbxYup.TabIndex = 1;
            this.tbxYup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textYZero
            // 
            this.textYZero.BackColor = System.Drawing.SystemColors.Control;
            this.textYZero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textYZero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYZero.Location = new System.Drawing.Point(1, 200);
            this.textYZero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textYZero.Name = "textYZero";
            this.textYZero.Size = new System.Drawing.Size(48, 14);
            this.textYZero.TabIndex = 17;
            this.textYZero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(661, 265);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(102, 107);
            this.txt.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 517);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lblChannelYColor);
            this.Controls.Add(this.lblChannelZColor);
            this.Controls.Add(this.lblChannelXColor);
            this.Controls.Add(this.lblChannelZ);
            this.Controls.Add(this.lblChannelY);
            this.Controls.Add(this.lbllZSensitivity);
            this.Controls.Add(this.lbllYSensitivity);
            this.Controls.Add(this.lbllXSensitivity);
            this.Controls.Add(this.lblChannelX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.btnSelectSavePath);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.txtChannelZSensitivity);
            this.Controls.Add(this.txtChannelYSensitivity);
            this.Controls.Add(this.txtChannelXSensitivity);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.textYZero);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxSelBoard);
            this.Controls.Add(this.tbxYdown);
            this.Controls.Add(this.tbxYup);
            this.Controls.Add(this.pbxDisplay);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDisplay;
        private System.Windows.Forms.TextBox tbxYdown;
        private System.Windows.Forms.ComboBox cbxSelBoard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.TextBox txtChannelXSensitivity;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSelectSavePath;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblChannelY;
        private System.Windows.Forms.Label lblChannelZ;
        private System.Windows.Forms.Label lblChannelX;
        private System.Windows.Forms.Label lbllXSensitivity;
        private System.Windows.Forms.Label lblChannelXColor;
        private System.Windows.Forms.Label lblChannelZColor;
        private System.Windows.Forms.Label lblChannelYColor;
        private System.Windows.Forms.TextBox txtChannelYSensitivity;
        private System.Windows.Forms.TextBox txtChannelZSensitivity;
        private System.Windows.Forms.Label lbllYSensitivity;
        private System.Windows.Forms.Label lbllZSensitivity;
        private System.Windows.Forms.TextBox tbxYup;
        private System.Windows.Forms.TextBox textYZero;
        private System.Windows.Forms.TextBox txt;
    }
}

