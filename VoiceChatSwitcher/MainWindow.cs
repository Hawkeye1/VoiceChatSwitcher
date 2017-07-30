using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceChatSwitcher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyTextBox.KeyDown += KeyTextBox_KeyDown;
            KeyTextBox.MouseDown += KeyTextBox_MouseDown;
            this.MouseDown += MainWindow_MouseDown;
        }

        private void KeyTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //KeyTextBox.HideSelection = false;
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
    }
}
