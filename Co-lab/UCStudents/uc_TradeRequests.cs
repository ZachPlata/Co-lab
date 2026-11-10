using System;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_TradeRequests : UserControl
    {
        public uc_TradeRequests()
        {
            InitializeComponent();
        }

        private void uc_TradeRequests_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] tabButtons = { button1, button2 };

            foreach (var btn in tabButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(20, 28, 23);
                    btn.ForeColor = Color.FromArgb(74, 222, 128); // Emerald Green

                    if (pnlTabIndicator != null)
                    {
                        pnlTabIndicator.Visible = true;
                        pnlTabIndicator.Location = new Point(btn.Left, btn.Bottom - 3);
                        pnlTabIndicator.Width = btn.Width;
                        pnlTabIndicator.BringToFront();
                    }
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(161, 161, 170); // Muted gray
                }
            }
        }

        private void LoadView(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            uc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(button1);
            LoadView(new uc_IncomingRequests());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            LoadView(new uc_SentRequests());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
