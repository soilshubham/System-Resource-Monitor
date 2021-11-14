using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace System_Resource_Monitor
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            lblName.Text = System.Environment.MachineName + " - " + System.Environment.UserName;

            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                lblProcessor.Text = obj["Name"].ToString();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fCPU = pCPU.NextValue();
            float fRAM = pRAM.NextValue();
            metroProgressBarCPU.Value = (int)fCPU;
            metroProgressBarRAM.Value = (int)fRAM;
            lblCPU.Text = string.Format("{0:0.00}%", fCPU);
            lblRAM.Text = string.Format("{0:0.00}%", fRAM);

            chart1.Series["CPU"].Points.AddY(fCPU);
            chart1.Series["RAM"].Points.AddY(fRAM);

           
        }
    }
}
