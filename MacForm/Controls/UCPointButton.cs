using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MacForm.Controls
{
    public partial class UCPointButton : Button
    {
        private Rectangle _MouseRect;
        private bool _MouseEnter;
        private bool _MouseDown;
        private bool _IsEnabled = true;

        public new EventHandler Click;

        /// <summary>
        /// 设置GDI高质量模式抗锯齿
        /// </summary>
        /// <param name="g">The g.</param>
        private void SetGDIHigh(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
        }

        public UCPointButton()
        {
            //InitializeComponent();
            this.Size = new Size(15, 15);

            SetStyle(
               //ControlStyles.SupportsTransparentBackColor |
               //ControlStyles.Opaque |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.UserMouse |
               ControlStyles.Selectable |
               ControlStyles.StandardClick, true);

            IconFlagCode = 0xf00c;
            IconFlag = null;
            IconFlagColor = ColorTranslator.FromHtml("#ffffff");
            IconFlagAlways = false;
            FillColor = ColorTranslator.FromHtml("#EC4F4A");
            FillDownColor = ColorTranslator.FromHtml("#B43634");
            FillEnterColor = ColorTranslator.FromHtml("#D83634");
            FillDisabledColor = ColorTranslator.FromHtml("#E3E3E3");
            BorderColor = ColorTranslator.FromHtml("#AE4F4F");
            BorderWidth = 1;
            //BackColor = Color.Transparent;

        }

        #region 属性


        /// <summary>
        /// 按钮显示图标IconFont代码
        /// </summary>
        [Browsable(true), DefaultValue(typeof(int), "0xf00c"), Description("按钮显示图标IconFont代码")]
        [Category("Appearance")]
        public int IconFlagCode { get; set; }

        /// <summary>
        /// 按钮图标
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Bitmap), null), Description("按钮显示图标")]
        [Category("Appearance")]
        public Bitmap IconFlag { get; set; }

        /// <summary>
        /// 按钮显示图标是否总是显示
        /// </summary>
        [Browsable(true), DefaultValue(false), Description("按钮显示图标是否总是显示")]
        [Category("Appearance")]
        public bool IconFlagAlways { get; set; }

        /// <summary>
        /// 按钮图标颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Control"), Description("按钮图标颜色")]
        [Category("Appearance")]
        public Color IconFlagColor { get; set; }

        /// <summary>
        /// 按钮默认颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Control"), Description("按钮默认颜色")]
        [Category("Appearance")]
        public Color FillColor { get; set; }

        /// <summary>
        /// 按钮按下颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Control"), Description("按钮按下颜色")]
        [Category("Appearance")]
        public Color FillDownColor { get; set; }

        /// <summary>
        /// 按钮鼠标移入颜色
        /// </summary>
        /// <value></value>
        [Browsable(true), DefaultValue(typeof(Color), "Control"), Description("按钮鼠标移入颜色")]
        [Category("Appearance")]
        public Color FillEnterColor { get; set; }

        /// <summary>
        /// 按钮禁用颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Control"), Description("按钮禁用颜色")]
        [Category("Appearance")]
        public Color FillDisabledColor { get; set; }

        /// <summary>
        /// 获取或设置边框大小
        /// </summary>
        [Browsable(true), DefaultValue(2), Description("按钮边框大小")]
        [Category("Appearance")]
        public int BorderWidth { get; set; }

        /// <summary>
        /// 获取或设置按钮边框颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Black"), Description("按钮边框颜色")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// 设置ToggleButton可操作性，相当于Enabled
        /// </summary>
        [Browsable(true), DefaultValue(true), Description("设置ToggleButton可操作性")]
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                if (_IsEnabled != value)
                {
                    _IsEnabled = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// 请使用EnableToogle
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Enabled { get { return false; } set { } }

        #endregion

        #region 鼠标

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_IsEnabled && _MouseRect != null && _MouseRect.Contains(new Point(e.X, e.Y)))
                {
                    if (this.Click != null)
                    {
                        Click(this, new EventArgs());
                    }
                }
            }
            base.OnMouseClick(e);
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_MouseRect != null && _MouseRect.Contains(new Point(e.X, e.Y)))
                {
                    _MouseDown = true;
                }
            }
            base.OnMouseDown(e);
        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _MouseDown = false;
            base.Invalidate();
            //base.OnMouseUp(e);
        }
        /// <summary>
        /// 鼠标进入按钮
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _MouseEnter = true;
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// 鼠标离开控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _MouseEnter = false;
            base.OnMouseLeave(e);
        }

        #endregion
        //protected override void OnLocationChanged(EventArgs e)
        //{
        //    // pick up the container's surface again. 
        //    Visible = false;
        //    Visible = true;
        //}

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
        //        return cp;
        //    }
        //}
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            SetGDIHigh(g);

            _MouseRect = new Rectangle(0, 0, this.ClientRectangle.Width - BorderWidth, this.ClientRectangle.Height - BorderWidth);

            Color Fill = FillColor;
            Color Border = BorderColor;
            if (_IsEnabled)
            {
                if (_MouseEnter)
                {
                    Fill = _MouseDown ? FillDownColor : FillEnterColor;
                }
            }
            else
            {
                Fill = FillDisabledColor;
                Border = FillDisabledColor;
            }

            //绘制边线
            using (Pen pen = new Pen(Border, BorderWidth))
            {
                g.DrawEllipse(pen, _MouseRect);
            }

            //绘制填充圆
            using (Brush brush = new SolidBrush(Fill))
            {
                g.FillEllipse(brush, _MouseRect);
            }

            //绘制图标
            bool isShow = IconFlagAlways ? true : _MouseEnter;
            if (isShow && IconFlagCode > 0)
            {
                Rectangle iconRect = _MouseRect;
                int iconSize = iconRect.Width / 5;
                iconRect.Inflate(-iconSize, -iconSize);
                Bitmap bmIcon = IconFont.GetImage(IconFont.GetFont(IconFlagCode), iconRect.Width, IconFlagColor);
                g.DrawImage(bmIcon, iconRect);
            }
            g.ResetClip();

        }

    }
}
