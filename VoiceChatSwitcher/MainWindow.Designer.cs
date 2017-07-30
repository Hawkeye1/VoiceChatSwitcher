namespace VoiceChatSwitcher
{
    partial class MainWindow
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
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.HideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(13, 65);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.ReadOnly = true;
            this.KeyTextBox.Size = new System.Drawing.Size(181, 20);
            this.KeyTextBox.TabIndex = 0;
            this.KeyTextBox.Text = "Выберети клавишу";
            // 
            // HideButton
            // 
            this.HideButton.Location = new System.Drawing.Point(297, 126);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(75, 23);
            this.HideButton.TabIndex = 1;
            this.HideButton.Text = "Hide";
            this.HideButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.HideButton);
            this.Controls.Add(this.KeyTextBox);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MainWindow";
            this.Text = "VoiceChatSwitcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Button HideButton;
    }
}

