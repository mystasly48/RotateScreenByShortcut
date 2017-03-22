﻿using System;

namespace MaisuLib.Display {
  [Flags()]
  internal enum DisplayDeviceStateFlags : int {
    AttachedToDesktop = 0x1,
    MultiDriver = 0x2,
    PrimaryDevice = 0x4,
    MirroringDriver = 0x8,
    VGACompatible = 0x10,
    Removable = 0x20,
    ModesPruned = 0x8000000,
    Remote = 0x4000000,
    Disconnect = 0x2000000
  }
}
