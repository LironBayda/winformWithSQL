namespace ordersystemmengment
{
    partial class orderMengmentSystem
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
            this.menu = new System.Windows.Forms.ListBox();
            this.explanation = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.fristLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.theirdLabel = new System.Windows.Forms.Label();
            this.fourthLabel = new System.Windows.Forms.Label();
            this.fourthtextBox = new System.Windows.Forms.TextBox();
            this.thierdTextBox = new System.Windows.Forms.TextBox();
            this.secondTextBox = new System.Windows.Forms.TextBox();
            this.fristTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.totalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.menu.FormattingEnabled = true;
            this.menu.ItemHeight = 20;
            this.menu.Items.AddRange(new object[] {
            "new customer",
            "exsit customer",
            "new supplier",
            "exsit supplier"});
            this.menu.Location = new System.Drawing.Point(47, 92);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(193, 84);
            this.menu.TabIndex = 0;
            this.menu.SelectedIndexChanged += new System.EventHandler(this.menu_SelectedIndexChanged);
            // 
            // explanation
            // 
            this.explanation.AutoSize = true;
            this.explanation.Location = new System.Drawing.Point(275, 31);
            this.explanation.Name = "explanation";
            this.explanation.Size = new System.Drawing.Size(254, 20);
            this.explanation.TabIndex = 1;
            this.explanation.Text = "choose one of the followinf options";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Crimson;
            this.errorLabel.Location = new System.Drawing.Point(275, 66);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 20);
            this.errorLabel.TabIndex = 2;
            // 
            // fristLabel
            // 
            this.fristLabel.AutoSize = true;
            this.fristLabel.Location = new System.Drawing.Point(275, 112);
            this.fristLabel.Name = "fristLabel";
            this.fristLabel.Size = new System.Drawing.Size(51, 20);
            this.fristLabel.TabIndex = 3;
            this.fristLabel.Text = "label2";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(275, 166);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(51, 20);
            this.secondLabel.TabIndex = 4;
            this.secondLabel.Text = "label3";
            // 
            // theirdLabel
            // 
            this.theirdLabel.AutoSize = true;
            this.theirdLabel.Location = new System.Drawing.Point(275, 226);
            this.theirdLabel.Name = "theirdLabel";
            this.theirdLabel.Size = new System.Drawing.Size(51, 20);
            this.theirdLabel.TabIndex = 5;
            this.theirdLabel.Text = "label4";
            // 
            // fourthLabel
            // 
            this.fourthLabel.AutoSize = true;
            this.fourthLabel.Location = new System.Drawing.Point(275, 277);
            this.fourthLabel.Name = "fourthLabel";
            this.fourthLabel.Size = new System.Drawing.Size(51, 20);
            this.fourthLabel.TabIndex = 6;
            this.fourthLabel.Text = "label5";
            // 
            // fourthtextBox
            // 
            this.fourthtextBox.Location = new System.Drawing.Point(452, 271);
            this.fourthtextBox.Name = "fourthtextBox";
            this.fourthtextBox.Size = new System.Drawing.Size(100, 26);
            this.fourthtextBox.TabIndex = 7;
            // 
            // thierdTextBox
            // 
            this.thierdTextBox.Location = new System.Drawing.Point(452, 218);
            this.thierdTextBox.Name = "thierdTextBox";
            this.thierdTextBox.Size = new System.Drawing.Size(100, 26);
            this.thierdTextBox.TabIndex = 8;
            // 
            // secondTextBox
            // 
            this.secondTextBox.Location = new System.Drawing.Point(452, 160);
            this.secondTextBox.Name = "secondTextBox";
            this.secondTextBox.Size = new System.Drawing.Size(100, 26);
            this.secondTextBox.TabIndex = 9;
            // 
            // fristTextBox
            // 
            this.fristTextBox.Location = new System.Drawing.Point(452, 112);
            this.fristTextBox.Name = "fristTextBox";
            this.fristTextBox.Size = new System.Drawing.Size(100, 26);
            this.fristTextBox.TabIndex = 10;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(357, 358);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 29);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(29, 192);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(240, 150);
            this.dataGridView.TabIndex = 12;
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Location = new System.Drawing.Point(119, 362);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(0, 20);
            this.totalPrice.TabIndex = 13;
            // 
            // orderMengmentSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fristTextBox);
            this.Controls.Add(this.secondTextBox);
            this.Controls.Add(this.thierdTextBox);
            this.Controls.Add(this.fourthtextBox);
            this.Controls.Add(this.fourthLabel);
            this.Controls.Add(this.theirdLabel);
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.fristLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.explanation);
            this.Controls.Add(this.menu);
            this.Name = "orderMengmentSystem";
            this.Text = "Order Mengment System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox menu;
        private System.Windows.Forms.Label explanation;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label fristLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label theirdLabel;
        private System.Windows.Forms.Label fourthLabel;
        private System.Windows.Forms.TextBox fourthtextBox;
        private System.Windows.Forms.TextBox thierdTextBox;
        private System.Windows.Forms.TextBox secondTextBox;
        private System.Windows.Forms.TextBox fristTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label totalPrice;
    }
}

