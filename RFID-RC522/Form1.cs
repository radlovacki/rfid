using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_RC522
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();
        public delegate void spDelegate(string sData);

        public Form1()
        {
            InitializeComponent();
            txtSerialInput.KeyDown += new KeyEventHandler(txtSerialInput_KeyDown);
        }

        private void spDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string str = sp.ReadLine();
                BeginInvoke((new spDelegate(stringDisplay)), str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stringDisplay(string sData)
        {
            richTextBox1.AppendText(sData + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbPortName.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9" });
            cbPortName.SelectedIndex = 3;
            ToolTip cbPortNameToolTip = new ToolTip();
            cbPortNameToolTip.SetToolTip(cbPortName, "Select or Enter Serial Port Name");
            cbBaudRate.Items.AddRange(new object[] { "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600" });
            ToolTip cbBaudRateToolTip = new ToolTip();
            cbBaudRateToolTip.SetToolTip(cbBaudRate, "Select Serial Port Baud Rate");
            cbBaudRate.SelectedIndex = 1;
            cbDataBits.Items.AddRange(new object[] { "5", "6", "7", "8" });
            ToolTip cbDataBitsToolTip = new ToolTip();
            cbDataBitsToolTip.SetToolTip(cbDataBits, "Select Serial Port Data Bits");
            cbDataBits.SelectedIndex = 3;
            cbParity.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            ToolTip cbParityToolTip = new ToolTip();
            cbParityToolTip.SetToolTip(cbParity, "Select Serial Port Parity");
            cbParity.SelectedIndex = 0;
            cbStopBits.Items.AddRange(new object[] { "0", "1", "1.5", "2" });
            ToolTip cbStopBitsToolTip = new ToolTip();
            cbStopBitsToolTip.SetToolTip(cbStopBits, "Select Serial Port Stop Bits");
            cbStopBits.SelectedIndex = 1;
            cbHandshake.Items.AddRange(new object[] { "None", "RequestToSend", "RequestToSendXOnXOf", "XOnXOf" });
            ToolTip cbHandshakeToolTip = new ToolTip();
            cbHandshakeToolTip.SetToolTip(cbHandshake, "Select Serial Port Handshake");
            cbHandshake.SelectedIndex = 0;
        }

        private void btnDeviceManager_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void btnSpStart_Click(object sender, EventArgs e)
        {
            if (cbPortName.SelectedIndex < 0)
            {
                MessageBox.Show("You MUST select or enter Serial Port Name!");
            }
            else if (btnSpStart.Text == "Start Communication")
            {
                // Serial Port Communication Setup
                sp.PortName = cbPortName.Text;
                sp.BaudRate = int.Parse(cbBaudRate.Text);
                sp.DataBits = int.Parse(cbDataBits.Text);
                sp.Parity = (Parity)cbParity.SelectedIndex;
                if (cbParity.SelectedIndex == 0)
                    sp.Parity = Parity.None;
                else if (cbParity.SelectedIndex == 1)
                    sp.Parity = Parity.Odd;
                else if (cbParity.SelectedIndex == 2)
                    sp.Parity = Parity.Even;
                else if (cbParity.SelectedIndex == 3)
                    sp.Parity = Parity.Mark;
                else
                    sp.Parity = Parity.Space;
                if (cbStopBits.SelectedIndex == 0)
                    sp.StopBits = StopBits.None;
                else if (cbStopBits.SelectedIndex == 1)
                    sp.StopBits = StopBits.One;
                else if (cbStopBits.SelectedIndex == 2)
                    sp.StopBits = StopBits.OnePointFive;
                else
                    sp.StopBits = StopBits.Two;
                if (cbHandshake.SelectedIndex == 0)
                    sp.Handshake = Handshake.None;
                else if (cbHandshake.SelectedIndex == 1)
                    sp.Handshake = Handshake.RequestToSend;
                else if (cbHandshake.SelectedIndex == 2)
                    sp.Handshake = Handshake.RequestToSendXOnXOff;
                else
                    sp.Handshake = Handshake.XOnXOff;
                sp.DataReceived += spDataReceived;
                sp.DtrEnable = true;
                sp.Open();
                sp.ReadExisting();
                btnSpStart.Text = "Stop Communication";
            }
            else if (btnSpStart.Text == "Stop Communication")
            {
                sp.Close();
                btnSpStart.Text = "Start Communication";
            }
        }

        private void btnAction0_Click(object sender, EventArgs e)
        {
            sp.WriteLine("0");
        }

        private void btnAction1_Click(object sender, EventArgs e)
        {
            sp.WriteLine("1");
        }

        private void btnAction2_Click(object sender, EventArgs e)
        {
            sp.WriteLine("2");
        }

        private void btnAction3_Click(object sender, EventArgs e)
        {
            sp.WriteLine("3");
        }

        private void btnAction4_Click(object sender, EventArgs e)
        {
            sp.WriteLine("4");
        }

        private void btnAction5_Click(object sender, EventArgs e)
        {
            sp.WriteLine("5");
        }

        private void btnAction6_Click(object sender, EventArgs e)
        {
            sp.WriteLine("6");
        }

        private void btnAction7_Click(object sender, EventArgs e)
        {
            sp.WriteLine("7");
        }

        private void btnCopySelection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
            {
                MessageBox.Show("Select the text and try again!", "Copy Selection");
            }
        }

        private void btnCopyEverything_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                Clipboard.SetText(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("The Serial Monitor is empty!", "Copy Everything");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void txtSerialInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.AppendText(txtSerialInput.Text + Environment.NewLine);
                sp.WriteLine(txtSerialInput.Text);
                e.SuppressKeyPress = true;
                txtSerialInput.Clear();
                txtSerialInput.Focus();
            }
        }
    }
}