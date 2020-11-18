using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace MacForm
{
    public static class IconFont
    {
        /// <summary>
        /// 自定义字体控制器
        /// </summary>
        private static PrivateFontCollection m_fontCollection = new PrivateFontCollection();

        /// <summary>
        /// 设置GDI高质量模式抗锯齿
        /// </summary>
        /// <param name="g">The g.</param>
        private static void SetGDIHigh(this Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <exception cref="FileNotFoundException">Font file not found</exception>
        static IconFont()
        {
            //string strPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.ToLower().Replace("file:///", "");
            //string strDir = System.IO.Path.GetDirectoryName(strPath);
            //if (!Directory.Exists(Path.Combine(strDir, "IconFont")))
            //{
            //    Directory.CreateDirectory(Path.Combine(strDir, "IconFont"));
            //}
            string strFile = Path.Combine(System.Windows.Forms.Application.StartupPath, "FontAwesome.ttf");
            if (!File.Exists(strFile))
            {
                var fs = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MacForm.IconFont.FontAwesome.ttf");
                FileStream sw = new FileStream(strFile, FileMode.Create, FileAccess.Write);
                fs.CopyTo(sw);
                sw.Close();
                fs.Close();
            }
            m_fontCollection.AddFontFile(strFile);
        }


        /// <summary>
        /// 获取真实非转义字符
        /// </summary>
        public static string GetFont(int icon)
        {
            return char.ConvertFromUtf32((int)icon);
        }

        /// <summary>
        /// 给控件设置字体图标
        /// </summary>
        /// <param name="Ctrl">前端控件</param>
        /// <param name="IconName">图标名称</param>
        /// <param name="Size">图标字体大小</param>
        /// <param name="ForeColor">图标颜色</param>
        public static void SetIcon(System.Windows.Forms.Control Ctrl, string IconName, float Size, Color ForeColor)
        {
            Font font = new Font(m_fontCollection.Families[0], Size, FontStyle.Regular, GraphicsUnit.Pixel);
            Ctrl.Text = IconName;
            Ctrl.Font = font;
            Ctrl.ForeColor = ForeColor;
        }

        /// <summary>
        /// 获取图标
        /// </summary>
        /// <param name="iconText">图标名称</param>
        /// <param name="imageSize">图标大小</param>
        /// <param name="foreColor">前景色</param>
        /// <param name="backColor">背景色</param>
        /// <returns>图标</returns>
        public static Icon GetIcon(string iconText, int imageSize = 16, Color? foreColor = null, Color? backColor = null)
        {
            Bitmap image = GetImage(iconText, imageSize, foreColor, backColor);
            return image != null ? ToIcon(image, imageSize) : null;
        }
        /// <summary>
        /// Gets the size of the icon.
        /// </summary>
        /// <param name="fontText">The icon text.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns>Size.</returns>
        private static Size GetIconSize(string fontText, Graphics graphics, Font font)
        {
            return graphics.MeasureString(fontText, font).ToSize();
        }
        /// <summary>
        /// 获取图标.
        /// </summary>
        /// <param name="fontText">图标名称.</param>
        /// <param name="imageSize">图标大小.</param>
        /// <param name="foreColor">前景色</param>
        /// <param name="backColor">背景色.</param>
        /// <returns>Bitmap.</returns>
        /// <exception cref="FileNotFoundException">Font file not found</exception>
        public static Bitmap GetImage(string fontText, int imageSize = 16, Color? foreColor = null, Color? backColor = null)
        {
            if (!foreColor.HasValue)
                foreColor = Color.Black;
            Font font = new Font(m_fontCollection.Families[0], imageSize, FontStyle.Regular, GraphicsUnit.Pixel);

            Bitmap srcImage = new Bitmap(imageSize, imageSize);
            using (Graphics g = Graphics.FromImage(srcImage))
            {
                g.SetGDIHigh();

                SizeF textSize = GetIconSize(fontText, g, font);

                if (backColor.HasValue && backColor.Value != Color.Empty && backColor.Value != Color.Transparent)
                    g.Clear(backColor.Value);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                using (Brush brush2 = new SolidBrush(foreColor.Value))
                {
                    g.DrawString(fontText, font, brush2, new PointF((imageSize - textSize.Width) / 2.0f + 0.5f, (imageSize - textSize.Height) / 2.0f + 1f));
                }
            }

            return srcImage;
        }
        /// <summary>
        /// Converts to icon.
        /// </summary>
        /// <param name="srcBitmap">The source bitmap.</param>
        /// <param name="size">The size.</param>
        /// <returns>Icon.</returns>
        /// <exception cref="ArgumentNullException">srcBitmap</exception>
        private static Icon ToIcon(Bitmap srcBitmap, int size)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException("srcBitmap");
            }

            System.IntPtr iconHandle = srcBitmap.GetHicon();
            System.Drawing.Icon icon = Icon.FromHandle(iconHandle);

            return icon;
        }

    }
}
