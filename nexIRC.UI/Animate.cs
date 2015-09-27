using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace nexIRC.UI {
    public sealed class Animate {
        private Animate() {
        }

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        public enum Effect
        {
            Roll,
            Slide,
            Center,
            Blend
        }

        public static void AnimateNow(Control ctl, Effect effect1, int msec, int angle)
        {
            int[] dirmap = {
			    1,
			    5,
			    4,
			    6,
			    2,
			    10,
			    8,
			    9
		    };
            int[] effmap = {
			    0,
			    0x40000,
			    0x10,
			    0x80000
		    };
            int flags = effmap[Convert.ToInt32(effect1)];
            if (ctl.Visible)
            {
                flags = flags | 0x10000;
                angle += 180;
            }
            else
            {
                if (object.ReferenceEquals(ctl.TopLevelControl, ctl))
                {
                    flags = flags | 0x20000;
                }
                else if (effect1 == Effect.Blend)
                {
                    throw new ArgumentException();
                }
            }
            flags = flags | dirmap[(angle % 360) / 45];
            bool ok = AnimateWindow(ctl.Handle, msec, flags);
            if (!ok)
            {
                throw new Exception("Animation failed");
            }
            ctl.Visible = !ctl.Visible;
        }
    }
}
