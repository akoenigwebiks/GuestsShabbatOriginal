namespace Guests
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
            this.lstGuestsName = new System.Windows.Forms.ListBox();
            this.btnEnterGuestName = new System.Windows.Forms.Button();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstGuestsName
            // 
            this.lstGuestsName.FormattingEnabled = true;
            this.lstGuestsName.ItemHeight = 16;
            this.lstGuestsName.Location = new System.Drawing.Point(312, 216);
            this.lstGuestsName.Name = "lstGuestsName";
            this.lstGuestsName.Size = new System.Drawing.Size(118, 116);
            this.lstGuestsName.TabIndex = 7;
            this.lstGuestsName.SelectedIndexChanged += new System.EventHandler(this.lstGuestsName_SelectedIndexChanged);
            // 
            // btnEnterGuestName
            // 
            this.btnEnterGuestName.Location = new System.Drawing.Point(316, 366);
            this.btnEnterGuestName.Name = "btnEnterGuestName";
            this.btnEnterGuestName.Size = new System.Drawing.Size(109, 34);
            this.btnEnterGuestName.TabIndex = 6;
            this.btnEnterGuestName.Text = "היכנס";
            this.btnEnterGuestName.UseVisualStyleBackColor = true;
            this.btnEnterGuestName.Click += new System.EventHandler(this.btnEnterGuestName_Click);
            // 
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(316, 143);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(114, 22);
            this.txtGuestName.TabIndex = 5;
            this.txtGuestName.TextChanged += new System.EventHandler(this.txtGuestName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(310, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "ברוכים הבאים";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 626);
            this.Controls.Add(this.lstGuestsName);
            this.Controls.Add(this.btnEnterGuestName);
            this.Controls.Add(this.txtGuestName);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGuestsName;
        private System.Windows.Forms.Button btnEnterGuestName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label label1;
    }
}