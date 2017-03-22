using System;
using System.Windows.Forms;
using MaisuLib.Hotkey;
using MaisuLib.Display;
using System.Diagnostics;

namespace RotateScreenByShortcut {
  public partial class Form1 : Form {
    KeyboardHook hook = new KeyboardHook();

    public Form1() {
      InitializeComponent();
      hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
      ModifierKeys tempHotkey = MaisuLib.Hotkey.ModifierKeys.Control | MaisuLib.Hotkey.ModifierKeys.Alt;
      hook.RegisterHotkey(tempHotkey, Keys.Left);
      hook.RegisterHotkey(tempHotkey, Keys.Right);
      hook.RegisterHotkey(tempHotkey, Keys.Up);
      hook.RegisterHotkey(tempHotkey, Keys.Down);
    }

    private void hook_KeyPressed(object sender, KeyPressedEventArgs e) {
      uint displayIndex = 1;
      Debug.WriteLine("Key: {0}, Display: {1}", e.Key, displayIndex);

      switch (e.Key) {
        case Keys.Left:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_270);
          //RotateDisplay.Left();
          break;
        case Keys.Right:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_90);
          //RotateDisplay.Right();
          break;
        case Keys.Up:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_0);
          //RotateDisplay.Up();
          break;
        case Keys.Down:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_180);
          //RotateDisplay.Down();
          break;
      }
    }

    private void Form1_Shown(object sender, EventArgs e) {
      Hide();
    }
  }
}
