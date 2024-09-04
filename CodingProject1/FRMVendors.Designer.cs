namespace CodingProject1
{
    partial class FRMVendors
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
            this.GBXVendorInformation = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CBXDefaultDiscount = new System.Windows.Forms.ComboBox();
            this.TXTComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXTVendorSalesRepresentitive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTVendorPhoneNumber = new System.Windows.Forms.TextBox();
            this.TXTVendorYTD = new System.Windows.Forms.TextBox();
            this.lable7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTVendorZipCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTVendorState = new System.Windows.Forms.TextBox();
            this.TXTVendorCity = new System.Windows.Forms.TextBox();
            this.TXTVendorAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTVendorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNPrevious = new System.Windows.Forms.Button();
            this.BTNNext = new System.Windows.Forms.Button();
            this.BTNSave = new System.Windows.Forms.Button();
            this.BTNExit = new System.Windows.Forms.Button();
            this.LBXVendors = new System.Windows.Forms.ListBox();
            this.GBXVendorInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBXVendorInformation
            // 
            this.GBXVendorInformation.Controls.Add(this.label9);
            this.GBXVendorInformation.Controls.Add(this.CBXDefaultDiscount);
            this.GBXVendorInformation.Controls.Add(this.TXTComments);
            this.GBXVendorInformation.Controls.Add(this.label8);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorSalesRepresentitive);
            this.GBXVendorInformation.Controls.Add(this.label7);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorPhoneNumber);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorYTD);
            this.GBXVendorInformation.Controls.Add(this.lable7);
            this.GBXVendorInformation.Controls.Add(this.label6);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorZipCode);
            this.GBXVendorInformation.Controls.Add(this.label5);
            this.GBXVendorInformation.Controls.Add(this.label4);
            this.GBXVendorInformation.Controls.Add(this.label3);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorState);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorCity);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorAddress);
            this.GBXVendorInformation.Controls.Add(this.label2);
            this.GBXVendorInformation.Controls.Add(this.TXTVendorName);
            this.GBXVendorInformation.Controls.Add(this.label1);
            this.GBXVendorInformation.Location = new System.Drawing.Point(14, 29);
            this.GBXVendorInformation.Margin = new System.Windows.Forms.Padding(2);
            this.GBXVendorInformation.Name = "GBXVendorInformation";
            this.GBXVendorInformation.Padding = new System.Windows.Forms.Padding(2);
            this.GBXVendorInformation.Size = new System.Drawing.Size(496, 280);
            this.GBXVendorInformation.TabIndex = 1;
            this.GBXVendorInformation.TabStop = false;
            this.GBXVendorInformation.Text = "Vendor Information";
            this.GBXVendorInformation.TextChanged += new System.EventHandler(this.GBXVendorInformation_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 247);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Default Discount (in days):";
            // 
            // CBXDefaultDiscount
            // 
            this.CBXDefaultDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXDefaultDiscount.FormattingEnabled = true;
            this.CBXDefaultDiscount.Location = new System.Drawing.Point(163, 244);
            this.CBXDefaultDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.CBXDefaultDiscount.Name = "CBXDefaultDiscount";
            this.CBXDefaultDiscount.Size = new System.Drawing.Size(128, 21);
            this.CBXDefaultDiscount.TabIndex = 27;
            this.CBXDefaultDiscount.Tag = "Default Discount";
            this.CBXDefaultDiscount.DropDownClosed += new System.EventHandler(this.ComboBoxChanged);
            // 
            // TXTComments
            // 
            this.TXTComments.Location = new System.Drawing.Point(91, 215);
            this.TXTComments.Margin = new System.Windows.Forms.Padding(2);
            this.TXTComments.Name = "TXTComments";
            this.TXTComments.Size = new System.Drawing.Size(388, 20);
            this.TXTComments.TabIndex = 26;
            this.TXTComments.Tag = "Comments";
            this.TXTComments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Comments:";
            // 
            // TXTVendorSalesRepresentitive
            // 
            this.TXTVendorSalesRepresentitive.Location = new System.Drawing.Point(150, 181);
            this.TXTVendorSalesRepresentitive.Margin = new System.Windows.Forms.Padding(2);
            this.TXTVendorSalesRepresentitive.Name = "TXTVendorSalesRepresentitive";
            this.TXTVendorSalesRepresentitive.Size = new System.Drawing.Size(328, 20);
            this.TXTVendorSalesRepresentitive.TabIndex = 25;
            this.TXTVendorSalesRepresentitive.Tag = "Sales Representative";
            this.TXTVendorSalesRepresentitive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Sales Representative:";
            // 
            // TXTVendorPhoneNumber
            // 
            this.TXTVendorPhoneNumber.Location = new System.Drawing.Point(312, 123);
            this.TXTVendorPhoneNumber.Name = "TXTVendorPhoneNumber";
            this.TXTVendorPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.TXTVendorPhoneNumber.TabIndex = 23;
            this.TXTVendorPhoneNumber.Tag = "Phone Number";
            this.TXTVendorPhoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // TXTVendorYTD
            // 
            this.TXTVendorYTD.Location = new System.Drawing.Point(118, 152);
            this.TXTVendorYTD.Name = "TXTVendorYTD";
            this.TXTVendorYTD.Size = new System.Drawing.Size(184, 20);
            this.TXTVendorYTD.TabIndex = 24;
            this.TXTVendorYTD.Tag = "Sales to Date";
            this.TXTVendorYTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // lable7
            // 
            this.lable7.AutoSize = true;
            this.lable7.Location = new System.Drawing.Point(28, 152);
            this.lable7.Name = "lable7";
            this.lable7.Size = new System.Drawing.Size(71, 13);
            this.lable7.TabIndex = 28;
            this.lable7.Text = "Sales to Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Phone Number:";
            // 
            // TXTVendorZipCode
            // 
            this.TXTVendorZipCode.Location = new System.Drawing.Point(86, 123);
            this.TXTVendorZipCode.Name = "TXTVendorZipCode";
            this.TXTVendorZipCode.Size = new System.Drawing.Size(66, 20);
            this.TXTVendorZipCode.TabIndex = 22;
            this.TXTVendorZipCode.Tag = "Zip Code";
            this.TXTVendorZipCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Zip Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "State:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "City:";
            // 
            // TXTVendorState
            // 
            this.TXTVendorState.Location = new System.Drawing.Point(374, 90);
            this.TXTVendorState.Name = "TXTVendorState";
            this.TXTVendorState.Size = new System.Drawing.Size(104, 20);
            this.TXTVendorState.TabIndex = 20;
            this.TXTVendorState.Tag = "State";
            this.TXTVendorState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // TXTVendorCity
            // 
            this.TXTVendorCity.Location = new System.Drawing.Point(86, 92);
            this.TXTVendorCity.Name = "TXTVendorCity";
            this.TXTVendorCity.Size = new System.Drawing.Size(204, 20);
            this.TXTVendorCity.TabIndex = 19;
            this.TXTVendorCity.Tag = "City";
            this.TXTVendorCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // TXTVendorAddress
            // 
            this.TXTVendorAddress.Location = new System.Drawing.Point(86, 56);
            this.TXTVendorAddress.Name = "TXTVendorAddress";
            this.TXTVendorAddress.Size = new System.Drawing.Size(392, 20);
            this.TXTVendorAddress.TabIndex = 18;
            this.TXTVendorAddress.Tag = "Address";
            this.TXTVendorAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Address:";
            // 
            // TXTVendorName
            // 
            this.TXTVendorName.Location = new System.Drawing.Point(86, 28);
            this.TXTVendorName.Name = "TXTVendorName";
            this.TXTVendorName.Size = new System.Drawing.Size(392, 20);
            this.TXTVendorName.TabIndex = 16;
            this.TXTVendorName.Tag = "Name";
            this.TXTVendorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            // 
            // BTNPrevious
            // 
            this.BTNPrevious.Location = new System.Drawing.Point(105, 330);
            this.BTNPrevious.Name = "BTNPrevious";
            this.BTNPrevious.Size = new System.Drawing.Size(115, 23);
            this.BTNPrevious.TabIndex = 2;
            this.BTNPrevious.Text = "<- Previous Vendor";
            this.BTNPrevious.UseVisualStyleBackColor = true;
            this.BTNPrevious.Click += new System.EventHandler(this.BTNPrevious_Click);
            // 
            // BTNNext
            // 
            this.BTNNext.Location = new System.Drawing.Point(226, 330);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(115, 23);
            this.BTNNext.TabIndex = 3;
            this.BTNNext.Text = "Next Vendor ->";
            this.BTNNext.UseVisualStyleBackColor = true;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            // 
            // BTNSave
            // 
            this.BTNSave.Location = new System.Drawing.Point(185, 368);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(75, 23);
            this.BTNSave.TabIndex = 4;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // BTNExit
            // 
            this.BTNExit.Location = new System.Drawing.Point(418, 426);
            this.BTNExit.Name = "BTNExit";
            this.BTNExit.Size = new System.Drawing.Size(75, 23);
            this.BTNExit.TabIndex = 5;
            this.BTNExit.Text = "Exit";
            this.BTNExit.UseVisualStyleBackColor = true;
            this.BTNExit.Click += new System.EventHandler(this.BTNExit_Click);
            // 
            // LBXVendors
            // 
            this.LBXVendors.BackColor = System.Drawing.SystemColors.Window;
            this.LBXVendors.ForeColor = System.Drawing.SystemColors.MenuText;
            this.LBXVendors.FormattingEnabled = true;
            this.LBXVendors.Location = new System.Drawing.Point(566, 29);
            this.LBXVendors.Margin = new System.Windows.Forms.Padding(2);
            this.LBXVendors.Name = "LBXVendors";
            this.LBXVendors.Size = new System.Drawing.Size(260, 420);
            this.LBXVendors.TabIndex = 6;
            this.LBXVendors.SelectedIndexChanged += new System.EventHandler(this.LBXVendors_SelectedIndexChanged);
            // 
            // FRMVendors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 490);
            this.ControlBox = false;
            this.Controls.Add(this.LBXVendors);
            this.Controls.Add(this.BTNExit);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.BTNNext);
            this.Controls.Add(this.BTNPrevious);
            this.Controls.Add(this.GBXVendorInformation);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FRMVendors";
            this.Text = "FRMVendors";
            this.Load += new System.EventHandler(this.FRMVendors_Load);
            this.GBXVendorInformation.ResumeLayout(false);
            this.GBXVendorInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBXVendorInformation;
        private System.Windows.Forms.TextBox TXTVendorPhoneNumber;
        private System.Windows.Forms.TextBox TXTVendorYTD;
        private System.Windows.Forms.Label lable7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTVendorZipCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTVendorState;
        private System.Windows.Forms.TextBox TXTVendorCity;
        private System.Windows.Forms.TextBox TXTVendorAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTVendorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTVendorSalesRepresentitive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBXDefaultDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BTNPrevious;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Button BTNExit;
        private System.Windows.Forms.ListBox LBXVendors;
    }
}