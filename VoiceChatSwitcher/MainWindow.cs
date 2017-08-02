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
        private ISkype skypeMachine;
        private Keys muteKey;

        public MainWindow()
        {
            RegisterSkype4ComDll();
            skypeMachine = new Skype();
            InitializeComponent();
            KeyTextBox.KeyDown += KeyTextBox_KeyDown;
            this.MouseDown += MainWindow_MouseDown;
            HideButton.KeyDown += HideButton_KeyDown;
            HideButton.KeyUp += HideButton_KeyUp;
            CheckSkypeClient();
        }

        private void HideButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == muteKey)
            {
                skypeMachine.Mute = false;
            }
        }

        private void HideButton_KeyDown(object sender, KeyEventArgs e)
        {
            //if (!KeyTextBox.Focused)
            //{
            if (e.KeyData == muteKey)
            {
                skypeMachine.Mute = true;
            }
            //}
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
            muteKey = key;
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

        private void CheckSkypeClient()
        {
            if (!skypeMachine.Client.IsRunning)
            {
                MessageBox.Show("Клиент Skype не запущен");
            }
        }
    }
}
