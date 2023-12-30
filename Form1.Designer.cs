namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_ForrasFajl = new System.Windows.Forms.TextBox();
            this.button_Betoltes = new System.Windows.Forms.Button();
            this.listBox_Orszagok = new System.Windows.Forms.ListBox();
            this.button_Teruletek = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_100_Kisebb = new System.Windows.Forms.RadioButton();
            this.radioButton_100_Nagyobb = new System.Windows.Forms.RadioButton();
            this.button_Megszamolas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_EredmenyFajl = new System.Windows.Forms.TextBox();
            this.button_Kiiras = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_MinMax = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_KeresendoOrszag = new System.Windows.Forms.TextBox();
            this.checkBox_TalalatokJelolese = new System.Windows.Forms.CheckBox();
            this.button_Kereses = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forrásfájl neve";
            // 
            // textbox_ForrasFajl
            // 
            this.textbox_ForrasFajl.Location = new System.Drawing.Point(16, 30);
            this.textbox_ForrasFajl.Name = "textbox_ForrasFajl";
            this.textbox_ForrasFajl.Size = new System.Drawing.Size(174, 20);
            this.textbox_ForrasFajl.TabIndex = 1;
            this.textbox_ForrasFajl.Text = "orszagok.csv";
            // 
            // button_Betoltes
            // 
            this.button_Betoltes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Betoltes.Location = new System.Drawing.Point(16, 57);
            this.button_Betoltes.Name = "button_Betoltes";
            this.button_Betoltes.Size = new System.Drawing.Size(174, 23);
            this.button_Betoltes.TabIndex = 2;
            this.button_Betoltes.Text = "Betöltés";
            this.button_Betoltes.UseVisualStyleBackColor = false;
            this.button_Betoltes.Click += new System.EventHandler(this.button_Betoltes_Click);
            // 
            // listBox_Orszagok
            // 
            this.listBox_Orszagok.FormattingEnabled = true;
            this.listBox_Orszagok.Location = new System.Drawing.Point(16, 87);
            this.listBox_Orszagok.Name = "listBox_Orszagok";
            this.listBox_Orszagok.Size = new System.Drawing.Size(174, 199);
            this.listBox_Orszagok.TabIndex = 3;
            // 
            // button_Teruletek
            // 
            this.button_Teruletek.Location = new System.Drawing.Point(16, 299);
            this.button_Teruletek.Name = "button_Teruletek";
            this.button_Teruletek.Size = new System.Drawing.Size(174, 23);
            this.button_Teruletek.TabIndex = 4;
            this.button_Teruletek.Text = "Területek átlaga";
            this.button_Teruletek.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_100_Kisebb);
            this.groupBox1.Controls.Add(this.radioButton_100_Nagyobb);
            this.groupBox1.Location = new System.Drawing.Point(196, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mit számoljunk?";
            // 
            // radioButton_100_Kisebb
            // 
            this.radioButton_100_Kisebb.AutoSize = true;
            this.radioButton_100_Kisebb.Location = new System.Drawing.Point(7, 44);
            this.radioButton_100_Kisebb.Name = "radioButton_100_Kisebb";
            this.radioButton_100_Kisebb.Size = new System.Drawing.Size(159, 17);
            this.radioButton_100_Kisebb.TabIndex = 1;
            this.radioButton_100_Kisebb.Text = "100 ezernél KISEBB területű";
            this.radioButton_100_Kisebb.UseVisualStyleBackColor = true;
            // 
            // radioButton_100_Nagyobb
            // 
            this.radioButton_100_Nagyobb.AutoSize = true;
            this.radioButton_100_Nagyobb.Checked = true;
            this.radioButton_100_Nagyobb.Location = new System.Drawing.Point(7, 19);
            this.radioButton_100_Nagyobb.Name = "radioButton_100_Nagyobb";
            this.radioButton_100_Nagyobb.Size = new System.Drawing.Size(173, 17);
            this.radioButton_100_Nagyobb.TabIndex = 0;
            this.radioButton_100_Nagyobb.TabStop = true;
            this.radioButton_100_Nagyobb.Text = "100 ezernél NAGYOBB területű";
            this.radioButton_100_Nagyobb.UseVisualStyleBackColor = true;
            // 
            // button_Megszamolas
            // 
            this.button_Megszamolas.Location = new System.Drawing.Point(196, 87);
            this.button_Megszamolas.Name = "button_Megszamolas";
            this.button_Megszamolas.Size = new System.Drawing.Size(198, 23);
            this.button_Megszamolas.TabIndex = 6;
            this.button_Megszamolas.Text = "Megszámolás";
            this.button_Megszamolas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Eredmény fájl neve";
            // 
            // textBox_EredmenyFajl
            // 
            this.textBox_EredmenyFajl.Location = new System.Drawing.Point(196, 129);
            this.textBox_EredmenyFajl.Name = "textBox_EredmenyFajl";
            this.textBox_EredmenyFajl.Size = new System.Drawing.Size(197, 20);
            this.textBox_EredmenyFajl.TabIndex = 8;
            this.textBox_EredmenyFajl.Text = "eredmeny.txt";
            // 
            // button_Kiiras
            // 
            this.button_Kiiras.Location = new System.Drawing.Point(196, 156);
            this.button_Kiiras.Name = "button_Kiiras";
            this.button_Kiiras.Size = new System.Drawing.Size(197, 23);
            this.button_Kiiras.TabIndex = 9;
            this.button_Kiiras.Text = "Kiírás";
            this.button_Kiiras.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Minimum vagy maximum?";
            // 
            // comboBox_MinMax
            // 
            this.comboBox_MinMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MinMax.FormattingEnabled = true;
            this.comboBox_MinMax.Items.AddRange(new object[] {
            "Minimum",
            "Maximum"});
            this.comboBox_MinMax.Location = new System.Drawing.Point(196, 203);
            this.comboBox_MinMax.Name = "comboBox_MinMax";
            this.comboBox_MinMax.Size = new System.Drawing.Size(197, 21);
            this.comboBox_MinMax.TabIndex = 11;
            this.comboBox_MinMax.SelectedIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ország keresése";
            // 
            // textBox_KeresendoOrszag
            // 
            this.textBox_KeresendoOrszag.Location = new System.Drawing.Point(197, 248);
            this.textBox_KeresendoOrszag.Name = "textBox_KeresendoOrszag";
            this.textBox_KeresendoOrszag.Size = new System.Drawing.Size(196, 20);
            this.textBox_KeresendoOrszag.TabIndex = 13;
            // 
            // checkBox_TalalatokJelolese
            // 
            this.checkBox_TalalatokJelolese.AutoSize = true;
            this.checkBox_TalalatokJelolese.Location = new System.Drawing.Point(196, 275);
            this.checkBox_TalalatokJelolese.Name = "checkBox_TalalatokJelolese";
            this.checkBox_TalalatokJelolese.Size = new System.Drawing.Size(156, 17);
            this.checkBox_TalalatokJelolese.TabIndex = 14;
            this.checkBox_TalalatokJelolese.Text = "Találatok jelölése a listában";
            this.checkBox_TalalatokJelolese.UseVisualStyleBackColor = true;
            // 
            // button_Kereses
            // 
            this.button_Kereses.Location = new System.Drawing.Point(196, 299);
            this.button_Kereses.Name = "button_Kereses";
            this.button_Kereses.Size = new System.Drawing.Size(197, 23);
            this.button_Kereses.TabIndex = 15;
            this.button_Kereses.Text = "Keresés";
            this.button_Kereses.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 341);
            this.Controls.Add(this.button_Kereses);
            this.Controls.Add(this.checkBox_TalalatokJelolese);
            this.Controls.Add(this.textBox_KeresendoOrszag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_MinMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Kiiras);
            this.Controls.Add(this.textBox_EredmenyFajl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Megszamolas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Teruletek);
            this.Controls.Add(this.listBox_Orszagok);
            this.Controls.Add(this.button_Betoltes);
            this.Controls.Add(this.textbox_ForrasFajl);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Országok vizsgálata";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_ForrasFajl;
        private System.Windows.Forms.Button button_Betoltes;
        private System.Windows.Forms.ListBox listBox_Orszagok;
        private System.Windows.Forms.Button button_Teruletek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_100_Kisebb;
        private System.Windows.Forms.RadioButton radioButton_100_Nagyobb;
        private System.Windows.Forms.Button button_Megszamolas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_EredmenyFajl;
        private System.Windows.Forms.Button button_Kiiras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_MinMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_KeresendoOrszag;
        private System.Windows.Forms.CheckBox checkBox_TalalatokJelolese;
        private System.Windows.Forms.Button button_Kereses;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

