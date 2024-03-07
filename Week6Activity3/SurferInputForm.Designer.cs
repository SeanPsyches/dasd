namespace Week6Activity3
{
    partial class SurferInputForm
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStance = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.listBoxSurfboards = new System.Windows.Forms.Button();
            this.actualCheckedListBoxSurfboards = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(119, 66);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxStance
            // 
            this.textBoxStance.Location = new System.Drawing.Point(119, 150);
            this.textBoxStance.Name = "textBoxStance";
            this.textBoxStance.Size = new System.Drawing.Size(100, 20);
            this.textBoxStance.TabIndex = 2;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(119, 306);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 56);
            this.Submit.TabIndex = 3;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Country :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stance :";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(119, 105);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(100, 21);
            this.comboBoxCountry.TabIndex = 7;
            // 
            // listBoxSurfboards
            // 
            this.listBoxSurfboards.Location = new System.Drawing.Point(75, 192);
            this.listBoxSurfboards.Name = "listBoxSurfboards";
            this.listBoxSurfboards.Size = new System.Drawing.Size(144, 23);
            this.listBoxSurfboards.TabIndex = 8;
            this.listBoxSurfboards.Text = "Lets see the boards.....";
            this.listBoxSurfboards.UseVisualStyleBackColor = true;
            this.listBoxSurfboards.Click += new System.EventHandler(this.listBoxSurfboards_Click);
            // 
            // actualCheckedListBoxSurfboards
            // 
            this.actualCheckedListBoxSurfboards.FormattingEnabled = true;
            this.actualCheckedListBoxSurfboards.Location = new System.Drawing.Point(331, 45);
            this.actualCheckedListBoxSurfboards.Name = "actualCheckedListBoxSurfboards";
            this.actualCheckedListBoxSurfboards.Size = new System.Drawing.Size(400, 274);
            this.actualCheckedListBoxSurfboards.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "**Last Surfboard Checked Will Be Yours :)";
            // 
            // SurferInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.actualCheckedListBoxSurfboards);
            this.Controls.Add(this.listBoxSurfboards);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.textBoxStance);
            this.Controls.Add(this.textBoxName);
            this.Name = "SurferInputForm";
            this.Text = "SurferInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxStance;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Button listBoxSurfboards;
        private System.Windows.Forms.CheckedListBox actualCheckedListBoxSurfboards;
        private System.Windows.Forms.Label label4;
    }
}