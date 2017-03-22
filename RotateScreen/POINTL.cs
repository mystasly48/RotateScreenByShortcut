using System.Runtime.InteropServices;

namespace MaisuLib.Display {
  [StructLayout(LayoutKind.Sequential)]
  internal struct POINTL {
    long x;
    long y;
  }
}
