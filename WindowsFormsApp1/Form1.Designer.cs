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
            this.readDataButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contactTypeComboBox = new System.Windows.Forms.ComboBox();
            this.countriesComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.companyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revealCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // readDataButton
            // 
            this.readDataButton.Location = new System.Drawing.Point(12, 15);
            this.readDataButton.Name = "readDataButton";
            this.readDataButton.Size = new System.Drawing.Size(75, 23);
            this.readDataButton.TabIndex = 0;
            this.readDataButton.Text = "Get";
            this.readDataButton.UseVisualStyleBackColor = true;
            this.readDataButton.Click += new System.EventHandler(this.readDataButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.revealCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.contactTypeComboBox);
            this.panel1.Controls.Add(this.countriesComboBox);
            this.panel1.Controls.Add(this.readDataButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 81);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Countries";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contact types";
            // 
            // contactTypeComboBox
            // 
            this.contactTypeComboBox.FormattingEnabled = true;
            this.contactTypeComboBox.Location = new System.Drawing.Point(201, 20);
            this.contactTypeComboBox.Name = "contactTypeComboBox";
            this.contactTypeComboBox.Size = new System.Drawing.Size(156, 21);
            this.contactTypeComboBox.TabIndex = 2;
            // 
            // countriesComboBox
            // 
            this.countriesComboBox.FormattingEnabled = true;
            this.countriesComboBox.Location = new System.Drawing.Point(201, 50);
            this.countriesComboBox.Name = "countriesComboBox";
            this.countriesComboBox.Size = new System.Drawing.Size(156, 21);
            this.countriesComboBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyNameColumn,
            this.contactNameColumn,
            this.countryColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(398, 369);
            this.dataGridView1.TabIndex = 2;
            // 
            // companyNameColumn
            // 
            this.companyNameColumn.DataPropertyName = "CompanyName";
            this.companyNameColumn.HeaderText = "Company";
            this.companyNameColumn.Name = "companyNameColumn";
            // 
            // contactNameColumn
            // 
            this.contactNameColumn.DataPropertyName = "ContactName";
            this.contactNameColumn.HeaderText = "Contact";
            this.contactNameColumn.Name = "contactNameColumn";
            // 
            // countryColumn
            // 
            this.countryColumn.DataPropertyName = "CountryName";
            this.countryColumn.HeaderText = "Country";
            this.countryColumn.Name = "countryColumn";
            // 
            // revealCheckBox
            // 
            this.revealCheckBox.AutoSize = true;
            this.revealCheckBox.Location = new System.Drawing.Point(27, 52);
            this.revealCheckBox.Name = "revealCheckBox";
            this.revealCheckBox.Size = new System.Drawing.Size(60, 17);
            this.revealCheckBox.TabIndex = 5;
            this.revealCheckBox.Text = "Reveal";
            this.revealCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readDataButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox countriesComboBox;
        private System.Windows.Forms.ComboBox contactTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.CheckBox revealCheckBox;
    }
}

