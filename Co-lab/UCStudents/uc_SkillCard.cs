using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB.UCStudents
{
    public enum CardTradeState
    {
        Available,
        OngoingTrade,
        UserPending,
        OwnListing
    }

    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SkillCard : UserControl
    {
        public string SkillId { get; private set; } = "0";
        public string SkillTitle { get; private set; } = "";
        public string Category { get; private set; } = "";
        public string Description { get; private set; } = "";
        public string OfferedBy { get; private set; } = "";
        public string DeliveryMode { get; private set; } = "Online";

        public CardTradeState CurrentState { get; private set; } = CardTradeState.Available;

        // Events exposed to parent (uc_SkillExchange)
        public event EventHandler<SkillCardEventArgs>? RequestTradeClicked;
        public event EventHandler<SkillCardEventArgs>? ReportClicked;

        public uc_SkillCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the designer card with values from a database DataRow.
        /// </summary>
        public void BindData(DataRow row)
        {
            SkillId = row["SkillId"]?.ToString() ?? "0";
            SkillTitle = row["SkillTitle"]?.ToString() ?? "Untitled Skill";
            Category = row["Category"]?.ToString() ?? "General";
            Description = row["Description"]?.ToString() ?? "No description provided.";
            OfferedBy = row["OfferedBy"]?.ToString() ?? "Anonymous Student";
            DeliveryMode = row["DeliveryMode"]?.ToString() ?? "Online";

            lblCategoryBadge.Text = Category.ToUpper();
            lblDeliveryMode.Text = DeliveryMode == "Face-to-Face" ? "📍 F2F" : "🌐 Online";
            lblSkillTitle.Text = SkillTitle;
            lblDescription.Text = Description;
            lblOfferedBy.Text = "👤 " + OfferedBy;
        }

        /// <summary>
        /// Sets the trade state of the card: Available, OngoingTrade, UserPending, or OwnListing.
        /// When in an ongoing trade, keeps the card visible with an "ONGOING" status badge and disables the trade button.
        /// </summary>
        public void SetTradeState(CardTradeState state)
        {
            CurrentState = state;

            switch (state)
            {
                case CardTradeState.OngoingTrade:
                    lblOngoingBadge.Text = "● ONGOING";
                    lblOngoingBadge.BackColor = Color.FromArgb(70, 48, 15);
                    lblOngoingBadge.ForeColor = Color.FromArgb(251, 191, 36); // Amber Gold
                    lblOngoingBadge.Visible = true;
                    lblOngoingBadge.Location = new Point(Width - lblOngoingBadge.PreferredWidth - 14, 10);
                    lblDeliveryMode.Visible = false;

                    btnRequestTrade.Text = "🔒 Ongoing";
                    btnRequestTrade.Enabled = true;
                    btnRequestTrade.BackColor = Color.FromArgb(45, 52, 47);
                    btnRequestTrade.ForeColor = Color.FromArgb(170, 175, 170);
                    btnRequestTrade.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 64);
                    btnRequestTrade.FlatAppearance.BorderSize = 1;
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.UserPending:
                    lblOngoingBadge.Text = "⏳ REQUEST SENT";
                    lblOngoingBadge.BackColor = Color.FromArgb(20, 60, 35);
                    lblOngoingBadge.ForeColor = Color.FromArgb(134, 239, 172); // Light mint green
                    lblOngoingBadge.Visible = true;
                    lblOngoingBadge.Location = new Point(Width - lblOngoingBadge.PreferredWidth - 14, 10);
                    lblDeliveryMode.Visible = false;

                    btnRequestTrade.Text = "⏳ Request Sent";
                    btnRequestTrade.Enabled = true;
                    btnRequestTrade.BackColor = Color.FromArgb(28, 90, 50); // Vibrant forest green
                    btnRequestTrade.ForeColor = Color.FromArgb(240, 253, 244);
                    btnRequestTrade.FlatAppearance.BorderColor = Color.FromArgb(74, 222, 128);
                    btnRequestTrade.FlatAppearance.BorderSize = 1;
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.OwnListing:
                    lblOngoingBadge.Visible = false;
                    lblDeliveryMode.Visible = true;
                    btnReport.Visible = false;

                    btnRequestTrade.Text = "👤 Your Skill";
                    btnRequestTrade.Enabled = true;
                    btnRequestTrade.BackColor = Color.FromArgb(24, 75, 42); // Clean dark emerald green
                    btnRequestTrade.ForeColor = Color.FromArgb(187, 247, 208); // Light emerald text
                    btnRequestTrade.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
                    btnRequestTrade.FlatAppearance.BorderSize = 1;
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.Available:
                default:
                    lblOngoingBadge.Visible = false;
                    lblDeliveryMode.Visible = true;
                    btnReport.Visible = true;

                    bool canTrade = UserSession.IsVerified || !UserSession.IsLoggedIn;
                    btnRequestTrade.Text = canTrade ? "🤝 Request Trade" : "🔒 Pending Verification";
                    btnRequestTrade.Enabled = canTrade;
                    btnRequestTrade.BackColor = canTrade ? Color.FromArgb(46, 125, 70) : Color.FromArgb(45, 52, 47);
                    btnRequestTrade.ForeColor = canTrade ? Color.White : Color.FromArgb(170, 175, 170);
                    btnRequestTrade.FlatAppearance.BorderSize = 0;
                    btnRequestTrade.Cursor = canTrade ? Cursors.Hand : Cursors.Default;
                    btnReport.Enabled = canTrade;
                    break;
            }

            if (state != CardTradeState.OwnListing && state != CardTradeState.Available)
            {
                btnReport.Visible = true;
                btnReport.Enabled = UserSession.IsVerified || !UserSession.IsLoggedIn;
            }
        }

        private void btnRequestTrade_Click(object sender, EventArgs e)
        {
            if (CurrentState != CardTradeState.Available)
            {
                return;
            }

            RequestTradeClicked?.Invoke(this, new SkillCardEventArgs(SkillId, SkillTitle, OfferedBy, DeliveryMode));
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportClicked?.Invoke(this, new SkillCardEventArgs(SkillId, SkillTitle, OfferedBy, DeliveryMode));
        }
    }

    public class SkillCardEventArgs : EventArgs
    {
        public string SkillId { get; }
        public string SkillTitle { get; }
        public string OfferedBy { get; }
        public string DeliveryMode { get; }

        public SkillCardEventArgs(string skillId, string skillTitle, string offeredBy, string deliveryMode)
        {
            SkillId = skillId;
            SkillTitle = skillTitle;
            OfferedBy = offeredBy;
            DeliveryMode = deliveryMode;
        }
    }
}
