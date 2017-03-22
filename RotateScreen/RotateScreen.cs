using System;
using System.Runtime.InteropServices;

namespace MaisuLib.Display {
  public class RotateDisplay {
    private static bool Rotate(uint DisplayNumber, DisplayOrientations Orientation) {
      if (DisplayNumber == 0)
        throw new ArgumentOutOfRangeException("DisplayNumber", DisplayNumber, "First display is 1.");

      bool result = false;
      DISPLAY_DEVICE d = new DISPLAY_DEVICE();
      DEVMODE dm = new DEVMODE();
      d.cb = Marshal.SizeOf(d);

      if (!NativeMethods.EnumDisplayDevices(null, DisplayNumber - 1, ref d, 0))
        throw new ArgumentOutOfRangeException("DisplayNumber", DisplayNumber, "Number is greater than connected displays.");

      if (0 != NativeMethods.EnumDisplaySettings(d.DeviceName, NativeMethods.ENUM_CURRENT_SETTINGS, ref dm)) {
        if ((dm.dmDisplayOrientation + (int)Orientation) % 2 == 1) {
          int temp = dm.dmPelsHeight;
          dm.dmPelsHeight = dm.dmPelsWidth;
          dm.dmPelsWidth = temp;
        }

        switch (Orientation) {
          case DisplayOrientations.DEGREES_CW_90:
            dm.dmDisplayOrientation = NativeMethods.DMDO_270;
            break;
          case DisplayOrientations.DEGREES_CW_180:
            dm.dmDisplayOrientation = NativeMethods.DMDO_180;
            break;
          case DisplayOrientations.DEGREES_CW_270:
            dm.dmDisplayOrientation = NativeMethods.DMDO_90;
            break;
          case DisplayOrientations.DEGREES_CW_0:
            dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
            break;
          default:
            break;
        }

        DISP_CHANGE ret = NativeMethods.ChangeDisplaySettingsEx(d.DeviceName, ref dm, IntPtr.Zero, DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);

        result = ret == 0;
      }

      return result;
    }

    public static void ResetAllRotations() {
      try {
        for (uint i = 0; i <= 64; i++) {
          Rotate(i, DisplayOrientations.DEGREES_CW_0);
        }
      } catch (ArgumentOutOfRangeException ex) {
        //
      }
    }
  }
}
