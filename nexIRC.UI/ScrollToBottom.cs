using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Telerik.WinControls.RichTextBox;
namespace nexIRC.UI {
	public class ScrollToBottom {
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
		private static readonly int WM_VSCROLL = 277;
		public ScrollToBottom(RichTextBox richTextBox) {
			try {
				SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)7, IntPtr.Zero);
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}