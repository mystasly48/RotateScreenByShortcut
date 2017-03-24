using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using MaisuLib.Hotkey;
using MaisuLib.Display;

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
      uint displayIndex = (uint)(Array.IndexOf(Screen.AllScreens.Reverse().ToArray(), Screen.FromPoint(Cursor.Position)) + 1);
      Debug.WriteLine("Key: {0}, Display: {1}", e.Key, displayIndex);
      switch (e.Key) {
        case Keys.Left:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_270);
          break;
        case Keys.Right:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_90);
          break;
        case Keys.Up:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_0);
          break;
        case Keys.Down:
          RotateDisplay.Rotate(displayIndex, DisplayOrientations.DEGREES_CW_180);
          break;
      }
    }

    private void Form1_Shown(object sender, EventArgs e) => Hide();
  }
}
