using AnotherFileBrowser.Windows;
using System.Windows.Forms;
using UnityEngine;

public class ScreenshotGenerator : MonoBehaviour
{
    private int _index;

    public void MakeScrenshot() 
    {
        new FileBrowser().SelectFolderBrowser(out string path, out DialogResult result);
        
        if (result != DialogResult.OK) return;
        path += $"\\{RoleSelector.CurrentRole}_{_index++}.png";
        ScreenCapture.CaptureScreenshot(path);
    }
}