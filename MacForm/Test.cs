using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MacForm
{
    public partial class Test : BaseForm
    {
        public Test()
        {
            InitializeComponent();
            this.MouseDown += Window_MouseDown;

        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }
        public static void Window_MouseDown(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            Form ParentForm = ctrl.FindForm();
            ReleaseCapture();
            SendMessage(ParentForm.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}
