namespace SmartValve
{
    partial class ValveForm
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
            this.btnSelectValve = new System.Windows.Forms.Button();
            this.txtValveName = new System.Windows.Forms.TextBox();
            this.btnAddAnother = new System.Windows.Forms.Button();
            this.btnRemoveValve = new System.Windows.Forms.Button();
            this.lstValves = new System.Windows.Forms.ListBox();
            this.btnExportJson = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // btnSelectValve
            // 
            this.btnSelectValve.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSelectValve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectValve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectValve.Location = new System.Drawing.Point(52, 43);
            this.btnSelectValve.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectValve.Name = "btnSelectValve";
            this.btnSelectValve.Size = new System.Drawing.Size(166, 38);
            this.btnSelectValve.TabIndex = 0;
            this.btnSelectValve.Text = "Select Valve";
            this.btnSelectValve.UseVisualStyleBackColor = false;
            this.btnSelectValve.Click += new System.EventHandler(this.btnSelectValve_Click);
            // 
            // txtValveName
            // 
            this.txtValveName.BackColor = System.Drawing.Color.RosyBrown;
            this.txtValveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValveName.Location = new System.Drawing.Point(52, 116);
            this.txtValveName.Multiline = true;
            this.txtValveName.Name = "txtValveName";
            this.txtValveName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValveName.Size = new System.Drawing.Size(203, 37);
            this.txtValveName.TabIndex = 1;
            this.txtValveName.Text = "Enter Valve Name";
            this.txtValveName.TextChanged += new System.EventHandler(this.txtValveName_TextChanged);
            this.txtValveName.Enter += new System.EventHandler(this.txtValveName_Enter);
            this.txtValveName.Leave += new System.EventHandler(this.txtValveName_Leave);
            // 
            // btnAddAnother
            // 
            this.btnAddAnother.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAddAnother.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAnother.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAnother.ForeColor = System.Drawing.Color.Black;
            this.btnAddAnother.Location = new System.Drawing.Point(52, 185);
            this.btnAddAnother.Name = "btnAddAnother";
            this.btnAddAnother.Size = new System.Drawing.Size(185, 42);
            this.btnAddAnother.TabIndex = 2;
            this.btnAddAnother.Text = "Add Valve";
            this.btnAddAnother.UseVisualStyleBackColor = false;
            this.btnAddAnother.Click += new System.EventHandler(this.btnAddAnother_Click);
            // 
            // btnRemoveValve
            // 
            this.btnRemoveValve.BackColor = System.Drawing.Color.RosyBrown;
            this.btnRemoveValve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveValve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveValve.Location = new System.Drawing.Point(52, 276);
            this.btnRemoveValve.Name = "btnRemoveValve";
            this.btnRemoveValve.Size = new System.Drawing.Size(184, 38);
            this.btnRemoveValve.TabIndex = 3;
            this.btnRemoveValve.Text = "Remove Valve";
            this.btnRemoveValve.UseVisualStyleBackColor = false;
            this.btnRemoveValve.Click += new System.EventHandler(this.btnRemoveValve_Click);
            // 
            // lstValves
            // 
            this.lstValves.BackColor = System.Drawing.Color.Silver;
            this.lstValves.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValves.ForeColor = System.Drawing.Color.Black;
            this.lstValves.FormattingEnabled = true;
            this.lstValves.ItemHeight = 22;
            this.lstValves.Location = new System.Drawing.Point(60, 357);
            this.lstValves.Name = "lstValves";
            this.lstValves.Size = new System.Drawing.Size(481, 180);
            this.lstValves.TabIndex = 4;
            this.lstValves.SelectedIndexChanged += new System.EventHandler(this.lstValves_SelectedIndexChanged);
            // 
            // btnExportJson
            // 
            this.btnExportJson.BackColor = System.Drawing.Color.RosyBrown;
            this.btnExportJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportJson.Location = new System.Drawing.Point(67, 571);
            this.btnExportJson.Name = "btnExportJson";
            this.btnExportJson.Size = new System.Drawing.Size(170, 34);
            this.btnExportJson.TabIndex = 5;
            this.btnExportJson.Text = "File Created";
            this.btnExportJson.UseVisualStyleBackColor = false;
            this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
            // 
            // X
            // 
            this.X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.Location = new System.Drawing.Point(544, 1);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(47, 42);
            this.X.TabIndex = 6;
            this.X.Text = "X";
            this.X.UseVisualStyleBackColor = true;
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ValveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(592, 670);
            this.Controls.Add(this.X);
            this.Controls.Add(this.btnExportJson);
            this.Controls.Add(this.lstValves);
            this.Controls.Add(this.btnRemoveValve);
            this.Controls.Add(this.btnAddAnother);
            this.Controls.Add(this.txtValveName);
            this.Controls.Add(this.btnSelectValve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ValveForm";
            this.Load += new System.EventHandler(this.ValveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectValve;
        private System.Windows.Forms.TextBox txtValveName;
        private System.Windows.Forms.Button btnAddAnother;
        private System.Windows.Forms.Button btnRemoveValve;
        private System.Windows.Forms.ListBox lstValves;
        private System.Windows.Forms.Button btnExportJson;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}