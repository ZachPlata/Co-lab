using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Co_LAB
{
    /// <summary>
    /// Displays a solid, opaque loading screen with a 60 FPS animated spinner over a target panel
    /// on a dedicated STA UI thread until the new UserControl has finished loading and painting.
    /// </summary>
    public sealed class LoadingOverlay : IDisposable
    {
        private static int _activeCount;

        private Thread? _uiThread;
        private SpinnerForm? _form;
        private readonly ManualResetEventSlim _ready = new ManualResetEventSlim(false);
        private bool _ownsSlot;
        private bool _disposed;

        public static LoadingOverlay ShowOver(Control targetPanel, string message = "Loading...")
        {
            var overlay = new LoadingOverlay();
            if (targetPanel != null && targetPanel.IsHandleCreated && targetPanel.Visible)
            {
                if (Interlocked.CompareExchange(ref _activeCount, 1, 0) == 0)
                {
                    Rectangle screenBounds = targetPanel.RectangleToScreen(targetPanel.ClientRectangle);
                    if (screenBounds.Width > 20 && screenBounds.Height > 20)
                    {
                        overlay._ownsSlot = true;
                        overlay.Start(screenBounds, message);
                    }
                    else
                    {
                        Interlocked.Exchange(ref _activeCount, 0);
                    }
                }
            }
            return overlay;
        }

        private void Start(Rectangle bounds, string message)
        {
            _uiThread = new Thread(() =>
            {
                _form = new SpinnerForm(bounds, message);
                _form.Shown += (s, e) => _ready.Set();
                Application.Run(_form);
            });
            _uiThread.SetApartmentState(ApartmentState.STA);
            _uiThread.IsBackground = true;
            _uiThread.Start();

            // Wait until the solid cover is painted on screen before loading begins
            _ready.Wait(300);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            try
            {
                if (_form != null && !_form.IsDisposed && _form.IsHandleCreated)
                {
                    _form.BeginInvoke(new Action(() =>
                    {
                        if (!_form.IsDisposed)
                        {
                            _form.Close();
                        }
                    }));
                }
            }
            catch
            {
            }
            finally
            {
                if (_ownsSlot)
                {
                    Interlocked.Exchange(ref _activeCount, 0);
                }
                _ready.Dispose();
            }
        }

        private sealed class SpinnerForm : Form
        {
            private readonly System.Windows.Forms.Timer _animTimer;
            private readonly string _message;
            private float _angle;

            protected override bool ShowWithoutActivation => true;

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE
                    return cp;
                }
            }

            public SpinnerForm(Rectangle bounds, string message)
            {
                _message = message;
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                Bounds = bounds;
                ShowInTaskbar = false;
                BackColor = Color.FromArgb(15, 20, 16); // Solid opaque dark background
                Opacity = 1.0;
                DoubleBuffered = true;

                _animTimer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
                _animTimer.Tick += (s, e) =>
                {
                    _angle = (_angle + 10f) % 360f;
                    Invalidate();
                };
                _animTimer.Start();

                FormClosed += (s, e) =>
                {
                    _animTimer.Stop();
                    _animTimer.Dispose();
                };
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int spinnerSize = 48;
                int cx = ClientSize.Width / 2;
                int cy = ClientSize.Height / 2 - 14;
                Rectangle rect = new Rectangle(cx - spinnerSize / 2, cy - spinnerSize / 2, spinnerSize, spinnerSize);

                // Subtle background track
                using (Pen trackPen = new Pen(Color.FromArgb(36, 52, 40), 4.5f))
                {
                    g.DrawEllipse(trackPen, rect);
                }

                // Emerald green rotating arc
                using (Pen arcPen = new Pen(Color.FromArgb(74, 222, 128), 4.5f))
                {
                    arcPen.StartCap = LineCap.Round;
                    arcPen.EndCap = LineCap.Round;
                    g.DrawArc(arcPen, rect, _angle, 100f);
                }

                // Loading label
                using (Font font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(212, 212, 216)))
                {
                    SizeF textSize = g.MeasureString(_message, font);
                    g.DrawString(_message, font, textBrush, cx - textSize.Width / 2f, cy + spinnerSize / 2f + 12f);
                }
            }
        }
    }
}
