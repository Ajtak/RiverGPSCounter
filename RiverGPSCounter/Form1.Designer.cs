namespace RiverGPSCounter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            pbInfo = new ProgressBar();
            lbRiver = new Label();
            pnInput = new Panel();
            button3 = new Button();
            pnInput.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(3, 39);
            button1.Name = "button1";
            button1.Size = new Size(382, 32);
            button1.TabIndex = 0;
            button1.Text = "Zpracovat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 13);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Soubor";
            // 
            // button2
            // 
            button2.Location = new Point(54, 7);
            button2.Name = "button2";
            button2.Size = new Size(117, 26);
            button2.TabIndex = 4;
            button2.Text = "Vybrat soubor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Multiselect = true;
            // 
            // pbInfo
            // 
            pbInfo.Location = new Point(12, 124);
            pbInfo.Name = "pbInfo";
            pbInfo.Size = new Size(388, 23);
            pbInfo.TabIndex = 5;
            // 
            // lbRiver
            // 
            lbRiver.AutoSize = true;
            lbRiver.Location = new Point(12, 106);
            lbRiver.Name = "lbRiver";
            lbRiver.Size = new Size(22, 15);
            lbRiver.TabIndex = 6;
            lbRiver.Text = "     ";
            // 
            // pnInput
            // 
            pnInput.Controls.Add(label2);
            pnInput.Controls.Add(button2);
            pnInput.Controls.Add(button1);
            pnInput.Location = new Point(12, 12);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(388, 80);
            pnInput.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(315, 95);
            button3.Name = "button3";
            button3.Size = new Size(85, 23);
            button3.TabIndex = 8;
            button3.Text = "Downloader";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 159);
            Controls.Add(button3);
            Controls.Add(pnInput);
            Controls.Add(lbRiver);
            Controls.Add(pbInfo);
            Name = "Form1";
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private Button button2;
        private OpenFileDialog openFileDialog1;
        private ProgressBar pbInfo;
        private Label lbRiver;
        private Panel pnInput;
        private Button button3;
    }
}
