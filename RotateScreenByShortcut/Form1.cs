using System;
using System.Windows.Forms;
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
      MessageBox.Show(e.Key.ToString());
      RotateDisplay.Rotate(1, DisplayOrientations.DEGREES_CW_0);

      //switch (e.Key) {
      //  case Keys.Left:
      //    RotateDisplay.Left();
      //    break;
      //  case Keys.Right:
      //    RotateDisplay.Right();
      //    break;
      //  case Keys.Up:
      //    RotateDisplay.Up();
      //    break;
      //  case Keys.Down:
      //    RotateDisplay.Down();
      //    break;
      //}
    }
  }
}
