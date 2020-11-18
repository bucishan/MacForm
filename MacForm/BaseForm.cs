using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MacForm
{
    public partial class BaseForm : Form
    {
        #region 窗体阴影特效
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= 0x00020000;
                return createParams;
            }
        }
        #endregion
        public BaseForm()
        {
            this.Load += BaseForm_Load;
            InitializeComponent();

        }
        /// <summary>
        /// 窗体加载事件 设置窗体圆角
        /// </summary>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            SetFormRoundRectRgn(this, 3);	//设置圆角
        }


        #region ----------自定义属性----------


        public enum PositionEnum
        {
            Left,
            Right
        }

        private PositionEnum _BtnPosition = PositionEnum.Left;
        /// <summary>
        /// 红绿灯按钮显示位置
        /// </summary>
        /// <value>The color of the focus.</value>
        [Browsable(true), Description("红绿灯按钮显示位置")]
        [Category("Appearance")]
        public PositionEnum BtnPosition
        {
            get { return _BtnPosition; }
            set
            {
                if (value != _BtnPosition)
                {
                    _BtnPosition = value;
                    SetBtnPosition(value);
                }
            }
        }

        /// <summary>
        /// 设置红绿灯按钮位置
        /// </summary>
        private void SetBtnPosition(PositionEnum position)
        {
            int btnWidth = btnClose.Width;
            int clientWidth = this.ClientRectangle.Width;
            Point InitLeftPoint = new Point(10, 10);
            Point InitRightPoint = new Point(clientWidth - btnWidth - 10, 10);
            switch (position)
            {
                case PositionEnum.Left:
                    {
                        btnClose.Location = InitLeftPoint;
                        InitLeftPoint.X += (btnWidth + 8);
                        btnMin.Location = InitLeftPoint;
                        InitLeftPoint.X += (btnWidth + 8);
                        btnRestore.Location = InitLeftPoint;
                        break;
                    }
                case PositionEnum.Right:
                    {
                        btnClose.Location = InitRightPoint;
                        InitRightPoint.X -= (btnWidth + 8);
                        btnMin.Location = InitRightPoint;
                        InitRightPoint.X -= (btnWidth + 8);
                        btnRestore.Location = InitRightPoint;
                        break;
                    }
            }
        }

        /// <summary>
        /// 置顶红绿灯按钮
        /// </summary>
        public void SetBtnBringToFront()
        {
            btnClose.BringToFront();
            btnMin.BringToFront();
            btnRestore.BringToFront();
        }
        #endregion


        #region ----------Window API使用常量----------

        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_WINDOWPOSCHANGING = 0x46;
        public const int WM_PAINT = 0xF;
        public const int WM_CREATE = 0x0001;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_SYSCOMMAND = 0x0112;

        public const int SC_MOVE = 0xF010;


        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 0x10;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTCAPTION = 2;
        public const int HTCLIENT = 1;

        public const int WM_FALSE = 0;
        public const int WM_TRUE = 1;

        #endregion

        #region ----------系统Api函数----------

        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Ansi)]
        public static extern int DeleteObject(int hObject);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #region ----------调用系统函数改变界面----------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SetBtnBringToFront();
        }

        protected override void OnResize(System.EventArgs e)
        {
            SetBtnPosition(this.BtnPosition);   //实时刷新按钮位置
        }

        /// <summary>
        /// 设置窗体的圆角矩形
        /// </summary>
        /// <param name="form">需要设置的窗体</param>
        /// <param name="rgnRadius">圆角矩形的半径</param>
        public static void SetFormRoundRectRgn(Form form, int rgnRadius)
        {
            int hRgn = CreateRoundRectRgn(0, 0, form.Width + 1, form.Height + 1, rgnRadius, rgnRadius);
            SetWindowRgn(form.Handle, hRgn, false);
            DeleteObject(hRgn);
        }
        /// <summary>
        /// 窗体拖动事件
        /// </summary>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        #region ----------按钮事件----------

        /// <summary>
        /// 红绿灯按钮功能事件
        /// </summary>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "close":
                    {
                        this.Close();
                        break;
                    }
                case "restore":
                    {
                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }
                        SetFormRoundRectRgn(this, 3);   //设置圆角

                        break;
                    }
                case "min":
                    {
                        if (this.WindowState != FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                        break;
                    }
            }
        }
        #endregion

    }
}
