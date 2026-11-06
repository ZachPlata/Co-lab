using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB.UCStudents
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SkillCard : UserControl
    {
        public string SkillId { get; private set; } = "0";
        public string SkillTitle { get; private set; } = "";
        public string Category { get; private set; } = "";
        public string Description { get; private set; } = "";
        public string OfferedBy { get; private set; } = "";
        public string DeliveryMode { get; private set; } = "Online";

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

        private void btnRequestTrade_Click(object sender, EventArgs e)
        {
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

