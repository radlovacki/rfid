namespace RFID_RC522
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHandshake = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnDeviceManager = new System.Windows.Forms.Button();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAction7 = new System.Windows.Forms.Button();
            this.btnAction6 = new System.Windows.Forms.Button();
            this.btnAction5 = new System.Windows.Forms.Button();
            this.btnAction4 = new System.Windows.Forms.Button();
            this.btnAction3 = new System.Windows.Forms.Button();
            this.btnAction2 = new System.Windows.Forms.Button();
            this.btnAction1 = new System.Windows.Forms.Button();
            this.btnAction0 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyEverything = new System.Windows.Forms.Button();
            this.btnCopySelection = new System.Windows.Forms.Button();
            this.txtSerialInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(250, 11);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(747, 650);
            this.richTextBox1.TabIndex = 300;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSpStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbHandshake);
            this.groupBox1.Controls.Add(this.cbStopBits);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbDataBits);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbBaudRate);
            this.groupBox1.Controls.Add(this.btnDeviceManager);
            this.groupBox1.Controls.Add(this.cbPortName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 213);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // btnSpStart
            // 
            this.btnSpStart.Location = new System.Drawing.Point(6, 181);
            this.btnSpStart.Name = "btnSpStart";
            this.btnSpStart.Size = new System.Drawing.Size(218, 23);
            this.btnSpStart.TabIndex = 7;
            this.btnSpStart.Text = "Start Communication";
            this.btnSpStart.UseVisualStyleBackColor = true;
            this.btnSpStart.Click += new System.EventHandler(this.btnSpStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "Handshake";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Stop Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Data Bits";
            // 
            // cbHandshake
            // 
            this.cbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHandshake.FormattingEnabled = true;
            this.cbHandshake.Location = new System.Drawing.Point(75, 154);
            this.cbHandshake.Name = "cbHandshake";
            this.cbHandshake.Size = new System.Drawing.Size(149, 21);
            this.cbHandshake.TabIndex = 6;
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(75, 127);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(149, 21);
            this.cbStopBits.TabIndex = 5;
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(75, 99);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(149, 21);
            this.cbParity.TabIndex = 4;
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(75, 71);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(149, 21);
            this.cbDataBits.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Name";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(75, 43);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(149, 21);
            this.cbBaudRate.TabIndex = 2;
            // 
            // btnDeviceManager
            // 
            this.btnDeviceManager.Location = new System.Drawing.Point(198, 13);
            this.btnDeviceManager.Name = "btnDeviceManager";
            this.btnDeviceManager.Size = new System.Drawing.Size(26, 23);
            this.btnDeviceManager.TabIndex = 1;
            this.btnDeviceManager.TabStop = false;
            this.btnDeviceManager.Text = "?";
            this.btnDeviceManager.UseVisualStyleBackColor = true;
            this.btnDeviceManager.Click += new System.EventHandler(this.btnDeviceManager_Click);
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(75, 15);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(117, 21);
            this.cbPortName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAction7);
            this.groupBox2.Controls.Add(this.btnAction6);
            this.groupBox2.Controls.Add(this.btnAction5);
            this.groupBox2.Controls.Add(this.btnAction4);
            this.groupBox2.Controls.Add(this.btnAction3);
            this.groupBox2.Controls.Add(this.btnAction2);
            this.groupBox2.Controls.Add(this.btnAction1);
            this.groupBox2.Controls.Add(this.btnAction0);
            this.groupBox2.Location = new System.Drawing.Point(13, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 255);
            this.groupBox2.TabIndex = 201;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // btnAction7
            // 
            this.btnAction7.Location = new System.Drawing.Point(5, 223);
            this.btnAction7.Name = "btnAction7";
            this.btnAction7.Size = new System.Drawing.Size(218, 23);
            this.btnAction7.TabIndex = 7;
            this.btnAction7.Text = "Action 7";
            this.btnAction7.UseVisualStyleBackColor = true;
            this.btnAction7.Click += new System.EventHandler(this.btnAction7_Click);
            // 
            // btnAction6
            // 
            this.btnAction6.Location = new System.Drawing.Point(5, 194);
            this.btnAction6.Name = "btnAction6";
            this.btnAction6.Size = new System.Drawing.Size(218, 23);
            this.btnAction6.TabIndex = 6;
            this.btnAction6.Text = "Action 6";
            this.btnAction6.UseVisualStyleBackColor = true;
            this.btnAction6.Click += new System.EventHandler(this.btnAction6_Click);
            // 
            // btnAction5
            // 
            this.btnAction5.Location = new System.Drawing.Point(5, 165);
            this.btnAction5.Name = "btnAction5";
            this.btnAction5.Size = new System.Drawing.Size(218, 23);
            this.btnAction5.TabIndex = 5;
            this.btnAction5.Text = "Action 5";
            this.btnAction5.UseVisualStyleBackColor = true;
            this.btnAction5.Click += new System.EventHandler(this.btnAction5_Click);
            // 
            // btnAction4
            // 
            this.btnAction4.Location = new System.Drawing.Point(5, 136);
            this.btnAction4.Name = "btnAction4";
            this.btnAction4.Size = new System.Drawing.Size(218, 23);
            this.btnAction4.TabIndex = 4;
            this.btnAction4.Text = "Action 4";
            this.btnAction4.UseVisualStyleBackColor = true;
            this.btnAction4.Click += new System.EventHandler(this.btnAction4_Click);
            // 
            // btnAction3
            // 
            this.btnAction3.Location = new System.Drawing.Point(5, 107);
            this.btnAction3.Name = "btnAction3";
            this.btnAction3.Size = new System.Drawing.Size(218, 23);
            this.btnAction3.TabIndex = 3;
            this.btnAction3.Text = "Action 3";
            this.btnAction3.UseVisualStyleBackColor = true;
            this.btnAction3.Click += new System.EventHandler(this.btnAction3_Click);
            // 
            // btnAction2
            // 
            this.btnAction2.Location = new System.Drawing.Point(5, 78);
            this.btnAction2.Name = "btnAction2";
            this.btnAction2.Size = new System.Drawing.Size(218, 23);
            this.btnAction2.TabIndex = 2;
            this.btnAction2.Text = "Action 2";
            this.btnAction2.UseVisualStyleBackColor = true;
            this.btnAction2.Click += new System.EventHandler(this.btnAction2_Click);
            // 
            // btnAction1
            // 
            this.btnAction1.Location = new System.Drawing.Point(5, 49);
            this.btnAction1.Name = "btnAction1";
            this.btnAction1.Size = new System.Drawing.Size(218, 23);
            this.btnAction1.TabIndex = 1;
            this.btnAction1.Text = "Action 1";
            this.btnAction1.UseVisualStyleBackColor = true;
            this.btnAction1.Click += new System.EventHandler(this.btnAction1_Click);
            // 
            // btnAction0
            // 
            this.btnAction0.Location = new System.Drawing.Point(5, 20);
            this.btnAction0.Name = "btnAction0";
            this.btnAction0.Size = new System.Drawing.Size(218, 23);
            this.btnAction0.TabIndex = 0;
            this.btnAction0.Text = "DumpInfo";
            this.btnAction0.UseVisualStyleBackColor = true;
            this.btnAction0.Click += new System.EventHandler(this.btnAction0_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(250, 694);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopyEverything
            // 
            this.btnCopyEverything.Location = new System.Drawing.Point(406, 694);
            this.btnCopyEverything.Name = "btnCopyEverything";
            this.btnCopyEverything.Size = new System.Drawing.Size(150, 23);
            this.btnCopyEverything.TabIndex = 2;
            this.btnCopyEverything.Text = "Copy Everything";
            this.btnCopyEverything.UseVisualStyleBackColor = true;
            this.btnCopyEverything.Click += new System.EventHandler(this.btnCopyEverything_Click);
            // 
            // btnCopySelection
            // 
            this.btnCopySelection.Location = new System.Drawing.Point(562, 694);
            this.btnCopySelection.Name = "btnCopySelection";
            this.btnCopySelection.Size = new System.Drawing.Size(150, 23);
            this.btnCopySelection.TabIndex = 1;
            this.btnCopySelection.Text = "Copy Selection";
            this.btnCopySelection.UseVisualStyleBackColor = true;
            this.btnCopySelection.Click += new System.EventHandler(this.btnCopySelection_Click);
            // 
            // txtSerialInput
            // 
            this.txtSerialInput.BackColor = System.Drawing.Color.Black;
            this.txtSerialInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialInput.ForeColor = System.Drawing.Color.Lime;
            this.txtSerialInput.Location = new System.Drawing.Point(250, 666);
            this.txtSerialInput.Name = "txtSerialInput";
            this.txtSerialInput.Size = new System.Drawing.Size(746, 22);
            this.txtSerialInput.TabIndex = 301;
            this.txtSerialInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialInput_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.txtSerialInput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyEverything);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCopySelection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID-RC522";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeviceManager;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbHandshake;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSpStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAction3;
        private System.Windows.Forms.Button btnAction2;
        private System.Windows.Forms.Button btnAction1;
        private System.Windows.Forms.Button btnAction0;
        private System.Windows.Forms.Button btnAction7;
        private System.Windows.Forms.Button btnAction6;
        private System.Windows.Forms.Button btnAction5;
        private System.Windows.Forms.Button btnAction4;
        private System.Windows.Forms.Button btnCopyEverything;
        private System.Windows.Forms.Button btnCopySelection;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSerialInput;
    }
}

