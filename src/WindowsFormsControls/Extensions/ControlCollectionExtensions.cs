using System.Windows.Forms;

namespace WindowsFormsControls.Extensions;

public static class ControlCollectionExtensions
{
    /// <summary>
    /// add multiple controls in the specified control
    /// </summary>
    /// <param name="controlCollection">the current control</param>
    /// <param name="controls">the array of controls that must be added</param>
    public static void AddControls(this Control.ControlCollection controlCollection, params Control[] controls) => controlCollection.AddRange(controls);

    /// <summary>
    /// removes a range of controls in the specified control
    /// </summary>
    /// <param name="controlCollection">the current control</param>
    /// <param name="controls">the controls that must be removed</param>
    public static void RemoveRange(this Control.ControlCollection controlCollection, params Control[] controls)
    {
        foreach (Control control in controls)
        {
            controlCollection.Remove(control);
            if (!control.IsDisposed)
            {
                control.Dispose();
            }
        }
    }
}