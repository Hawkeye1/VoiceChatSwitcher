using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace VoiceChatSwitcher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterSkype4ComDll();
            KeyTextBox.KeyDown += KeyTextBox_KeyDown;
            this.MouseDown += MainWindow_MouseDown;
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            HideButton.Focus();
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            InitKey(e.KeyData);

        }

        private void InitKey(Keys key)
        {
            KeyTextBox.Text = key.ToString();
        }

        private void RegisterSkype4ComDll ()
        {
            try
            {
                String argFileInfo = "/s " + AppDomain.CurrentDomain.BaseDirectory +"Skype4COM.dll";

                Process reg = new Process();
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = argFileInfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
