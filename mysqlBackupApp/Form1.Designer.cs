namespace mysqlBackupApp
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
            this.btExport = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.pbTable = new System.Windows.Forms.ProgressBar();
            this.pbRowInCurTable = new System.Windows.Forms.ProgressBar();
            this.pbRowInAllTable = new System.Windows.Forms.ProgressBar();
            this.lbCurrentTableName = new System.Windows.Forms.Label();
            this.lbTableCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRowInCurTable = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRowInAllTable = new System.Windows.Forms.Label();
            this.txtConstr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.txtDbNames = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExcludes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(65, 347);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(132, 70);
            this.btExport.TabIndex = 0;
            this.btExport.Text = "Backup DB";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.backupDB_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(306, 347);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(136, 70);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // pbTable
            // 
            this.pbTable.Location = new System.Drawing.Point(55, 159);
            this.pbTable.Name = "pbTable";
            this.pbTable.Size = new System.Drawing.Size(387, 23);
            this.pbTable.TabIndex = 2;
            // 
            // pbRowInCurTable
            // 
            this.pbRowInCurTable.Location = new System.Drawing.Point(55, 224);
            this.pbRowInCurTable.Name = "pbRowInCurTable";
            this.pbRowInCurTable.Size = new System.Drawing.Size(387, 23);
            this.pbRowInCurTable.TabIndex = 3;
            // 
            // pbRowInAllTable
            // 
            this.pbRowInAllTable.Location = new System.Drawing.Point(55, 291);
            this.pbRowInAllTable.Name = "pbRowInAllTable";
            this.pbRowInAllTable.Size = new System.Drawing.Size(387, 23);
            this.pbRowInAllTable.TabIndex = 4;
            // 
            // lbCurrentTableName
            // 
            this.lbCurrentTableName.AutoSize = true;
            this.lbCurrentTableName.Location = new System.Drawing.Point(52, 136);
            this.lbCurrentTableName.Name = "lbCurrentTableName";
            this.lbCurrentTableName.Size = new System.Drawing.Size(34, 13);
            this.lbCurrentTableName.TabIndex = 5;
            this.lbCurrentTableName.Text = "Table";
            // 
            // lbTableCount
            // 
            this.lbTableCount.AutoSize = true;
            this.lbTableCount.Location = new System.Drawing.Point(52, 185);
            this.lbTableCount.Name = "lbTableCount";
            this.lbTableCount.Size = new System.Drawing.Size(30, 13);
            this.lbTableCount.TabIndex = 6;
            this.lbTableCount.Text = "1 / 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rows in Current Table";
            // 
            // lbRowInCurTable
            // 
            this.lbRowInCurTable.AutoSize = true;
            this.lbRowInCurTable.Location = new System.Drawing.Point(52, 250);
            this.lbRowInCurTable.Name = "lbRowInCurTable";
            this.lbRowInCurTable.Size = new System.Drawing.Size(30, 13);
            this.lbRowInCurTable.TabIndex = 8;
            this.lbRowInCurTable.Text = "1 / 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rows in All Tables";
            // 
            // lbRowInAllTable
            // 
            this.lbRowInAllTable.AutoSize = true;
            this.lbRowInAllTable.Location = new System.Drawing.Point(51, 317);
            this.lbRowInAllTable.Name = "lbRowInAllTable";
            this.lbRowInAllTable.Size = new System.Drawing.Size(30, 13);
            this.lbRowInAllTable.TabIndex = 10;
            this.lbRowInAllTable.Text = "1 / 1";
            // 
            // txtConstr
            // 
            this.txtConstr.Location = new System.Drawing.Point(98, 13);
            this.txtConstr.Name = "txtConstr";
            this.txtConstr.Size = new System.Drawing.Size(379, 20);
            this.txtConstr.TabIndex = 11;
            this.txtConstr.Text = "server=IPVEYADOMAIN;user=DB_USER;pwd=DB_PASS;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Connection Str";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Backup Path";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(98, 40);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(298, 20);
            this.txtBackupPath.TabIndex = 14;
            this.txtBackupPath.Text = "C:\\Users\\USERNAME\\Desktop";
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Location = new System.Drawing.Point(402, 40);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFolderSelect.TabIndex = 15;
            this.btnFolderSelect.Text = "...";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // txtDbNames
            // 
            this.txtDbNames.Location = new System.Drawing.Point(145, 66);
            this.txtDbNames.Name = "txtDbNames";
            this.txtDbNames.Size = new System.Drawing.Size(332, 20);
            this.txtDbNames.TabIndex = 16;
            this.txtDbNames.Text = "mydb1,mydb2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Db names (virgülle ayırın)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Yedeklenmeyecek tablolar (virgülle)";
            // 
            // txtExcludes
            // 
            this.txtExcludes.Location = new System.Drawing.Point(196, 93);
            this.txtExcludes.Name = "txtExcludes";
            this.txtExcludes.Size = new System.Drawing.Size(281, 20);
            this.txtExcludes.TabIndex = 19;
            this.txtExcludes.Text = "usertable,pwtable";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 469);
            this.Controls.Add(this.txtExcludes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDbNames);
            this.Controls.Add(this.btnFolderSelect);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConstr);
            this.Controls.Add(this.lbRowInAllTable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbRowInCurTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTableCount);
            this.Controls.Add(this.lbCurrentTableName);
            this.Controls.Add(this.pbRowInAllTable);
            this.Controls.Add(this.pbRowInCurTable);
            this.Controls.Add(this.pbTable);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btExport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ProgressBar pbTable;
        private System.Windows.Forms.ProgressBar pbRowInCurTable;
        private System.Windows.Forms.ProgressBar pbRowInAllTable;
        private System.Windows.Forms.Label lbCurrentTableName;
        private System.Windows.Forms.Label lbTableCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRowInCurTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRowInAllTable;
        private System.Windows.Forms.TextBox txtConstr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.TextBox txtDbNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExcludes;
    }
}

