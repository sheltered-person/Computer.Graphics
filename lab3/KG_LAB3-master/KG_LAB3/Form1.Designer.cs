
namespace KG_LAB3
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
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.defaultPictureBox = new System.Windows.Forms.PictureBox();
            this.HAF = new System.Windows.Forms.Button();
            this.HAFUpDown = new System.Windows.Forms.ComboBox();
            this.GaussUpDown = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AdaptiveTUpDown = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Location = new System.Drawing.Point(12, 390);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(117, 37);
            this.selectFileBtn.TabIndex = 0;
            this.selectFileBtn.Text = "Select Image";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // defaultPictureBox
            // 
            this.defaultPictureBox.Location = new System.Drawing.Point(12, 12);
            this.defaultPictureBox.Name = "defaultPictureBox";
            this.defaultPictureBox.Size = new System.Drawing.Size(578, 349);
            this.defaultPictureBox.TabIndex = 1;
            this.defaultPictureBox.TabStop = false;
            this.defaultPictureBox.Click += new System.EventHandler(this.defaultPictureBox_Click);
            // 
            // HAF
            // 
            this.HAF.Location = new System.Drawing.Point(163, 390);
            this.HAF.Name = "HAF";
            this.HAF.Size = new System.Drawing.Size(117, 37);
            this.HAF.TabIndex = 2;
            this.HAF.Text = "HAF";
            this.HAF.UseVisualStyleBackColor = true;
            this.HAF.Click += new System.EventHandler(this.HAF_Click);
            // 
            // HAFUpDown
            // 
            this.HAFUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HAFUpDown.FormattingEnabled = true;
            this.HAFUpDown.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "4",
            "12"});
            this.HAFUpDown.Location = new System.Drawing.Point(286, 390);
            this.HAFUpDown.Name = "HAFUpDown";
            this.HAFUpDown.Size = new System.Drawing.Size(121, 37);
            this.HAFUpDown.TabIndex = 4;
            // 
            // GaussUpDown
            // 
            this.GaussUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GaussUpDown.FormattingEnabled = true;
            this.GaussUpDown.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.GaussUpDown.Location = new System.Drawing.Point(573, 390);
            this.GaussUpDown.Name = "GaussUpDown";
            this.GaussUpDown.Size = new System.Drawing.Size(121, 37);
            this.GaussUpDown.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Gauss";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(733, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "AdaptiveT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdaptiveTUpDown
            // 
            this.AdaptiveTUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdaptiveTUpDown.FormattingEnabled = true;
            this.AdaptiveTUpDown.Items.AddRange(new object[] {
            "3",
            "5",
            "7"});
            this.AdaptiveTUpDown.Location = new System.Drawing.Point(856, 390);
            this.AdaptiveTUpDown.Name = "AdaptiveTUpDown";
            this.AdaptiveTUpDown.Size = new System.Drawing.Size(121, 37);
            this.AdaptiveTUpDown.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1018, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 37);
            this.button3.TabIndex = 9;
            this.button3.Text = "Otsu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1141, 390);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 37);
            this.button4.TabIndex = 10;
            this.button4.Text = "Histogram";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(680, 12);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(578, 349);
            this.resultPictureBox.TabIndex = 11;
            this.resultPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 441);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AdaptiveTUpDown);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GaussUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HAFUpDown);
            this.Controls.Add(this.HAF);
            this.Controls.Add(this.defaultPictureBox);
            this.Controls.Add(this.selectFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.defaultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.PictureBox defaultPictureBox;
        private System.Windows.Forms.Button HAF;
        private System.Windows.Forms.ComboBox HAFUpDown;
        private System.Windows.Forms.ComboBox GaussUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox AdaptiveTUpDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox resultPictureBox;
    }
}

