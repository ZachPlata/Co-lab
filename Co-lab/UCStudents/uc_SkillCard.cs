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

        private Label? _lblOngoingBadge;

        // Events exposed to parent (uc_SkillExchange)
        public event EventHandler<SkillCardEventArgs>? RequestTradeClicked;
        public event EventHandler<SkillCardEventArgs>? ReportClicked;

        public uc_SkillCard()
        {
            InitializeComponent();
            EnsureOngoingBadge();
        }

        private void EnsureOngoingBadge()
        {
            if (_lblOngoingBadge == null)
            {
                _lblOngoingBadge = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                    Padding = new Padding(6, 2, 6, 2),
                    Visible = false,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };
                Controls.Add(_lblOngoingBadge);
                _lblOngoingBadge.BringToFront();
            }
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
            EnsureOngoingBadge();

            switch (state)
            {
                case CardTradeState.OngoingTrade:
                    _lblOngoingBadge!.Text = "● ONGOING";
                    _lblOngoingBadge.BackColor = Color.FromArgb(70, 48, 15);
                    _lblOngoingBadge.ForeColor = Color.FromArgb(251, 191, 36); // Amber Gold
                    _lblOngoingBadge.Visible = true;
                    _lblOngoingBadge.Location = new Point(Width - _lblOngoingBadge.PreferredWidth - 14, 10);
                    lblDeliveryMode.Visible = false;

                    btnRequestTrade.Text = "🔒 Ongoing";
                    btnRequestTrade.Enabled = false;
                    btnRequestTrade.BackColor = Color.FromArgb(38, 44, 40);
                    btnRequestTrade.ForeColor = Color.FromArgb(160, 165, 160);
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.UserPending:
                    _lblOngoingBadge!.Text = "⏳ REQUEST SENT";
                    _lblOngoingBadge.BackColor = Color.FromArgb(25, 48, 55);
                    _lblOngoingBadge.ForeColor = Color.FromArgb(56, 189, 248); // Sky blue
                    _lblOngoingBadge.Visible = true;
                    _lblOngoingBadge.Location = new Point(Width - _lblOngoingBadge.PreferredWidth - 14, 10);
                    lblDeliveryMode.Visible = false;

                    btnRequestTrade.Text = "⏳ Request Sent";
                    btnRequestTrade.Enabled = false;
                    btnRequestTrade.BackColor = Color.FromArgb(38, 44, 40);
                    btnRequestTrade.ForeColor = Color.FromArgb(160, 165, 160);
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.OwnListing:
                    _lblOngoingBadge!.Visible = false;
                    lblDeliveryMode.Visible = true;

                    btnRequestTrade.Text = "👤 Your Skill";
                    btnRequestTrade.Enabled = false;
                    btnRequestTrade.BackColor = Color.FromArgb(32, 40, 35);
                    btnRequestTrade.ForeColor = Color.FromArgb(140, 150, 142);
                    btnRequestTrade.Cursor = Cursors.Default;
                    break;

                case CardTradeState.Available:
                default:
                    _lblOngoingBadge!.Visible = false;
                    lblDeliveryMode.Visible = true;

                    btnRequestTrade.Text = "🤝 Request Trade";
                    btnRequestTrade.Enabled = true;
                    btnRequestTrade.BackColor = Color.FromArgb(46, 125, 70);
                    btnRequestTrade.ForeColor = Color.White;
                    btnRequestTrade.Cursor = Cursors.Hand;
                    break;
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
