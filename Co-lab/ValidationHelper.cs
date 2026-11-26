using System.Windows.Forms;

namespace Co_LAB
{
    public static class ValidationHelper
    {
        public static ErrorProvider Create(ContainerControl container)
        {
            return new ErrorProvider(container)
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
        }

        public static void Configure(ErrorProvider ep)
        {
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public static void SetError(ErrorProvider ep, Control control, string message, int iconPadding = 6)
        {
            ep.SetIconPadding(control, iconPadding);
            ep.SetError(control, message);
        }

        public static void ClearError(ErrorProvider ep, Control control)
        {
            ep.SetError(control, string.Empty);
        }

        public static void ClearAll(ErrorProvider ep)
        {
            ep.Clear();
        }
    }
}