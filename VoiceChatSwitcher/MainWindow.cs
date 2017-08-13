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
using System.Runtime.InteropServices;

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
            CheckSkypeClient();
            SetHook();
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

        private const int WH_KEYBOARD_LL = 13;

        private LowLevelKeyboardProcDelegate m_callback;
        private IntPtr m_hHook;

        [DllImport("user32.dll", EntryPoint = "SetWindowsHookEx")]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelKeyboardProcDelegate lpfn,
            IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("Kernel32.dll", EntryPoint = "GetModuleHandle")]
        private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        [DllImport("user32.dll", EntryPoint = "CallNextHookEx")]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr LowLevelKeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
            else
            {
                var khs = (KeyboardHookStruct)Marshal.PtrToStructure(lParam,
                    typeof(KeyboardHookStruct));

                if (khs.VirtualKeyCode == Convert.ToInt32(muteKey) &&
                    wParam.ToInt32() == 256)     
                {
                    // some processing
                    MessageBox.Show("You down: " + muteKey.ToString());
                    IntPtr val = new IntPtr(1);
                    return val;
                }
                if (khs.VirtualKeyCode == Convert.ToInt32(muteKey) &&
                    wParam.ToInt32() == 257)     
                {
                    // some processing
                    MessageBox.Show("You up: " + muteKey.ToString());
                    IntPtr val = new IntPtr(1);
                    return val;
                }
                else
                {
                    return CallNextHookEx(m_hHook, nCode, wParam, lParam);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardHookStruct
        {
            public readonly int VirtualKeyCode;
            public readonly int ScanCode;
            public readonly int Flags;
            public readonly int Time;
            public readonly IntPtr ExtraInfo;
        }

        private delegate IntPtr LowLevelKeyboardProcDelegate(
            int nCode, IntPtr wParam, IntPtr lParam);

        public void SetHook()
        {
            m_callback = LowLevelKeyboardHookProc;
            m_hHook = SetWindowsHookEx(WH_KEYBOARD_LL, m_callback,
                GetModuleHandle(IntPtr.Zero), 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(m_hHook);
        }
    }
}
