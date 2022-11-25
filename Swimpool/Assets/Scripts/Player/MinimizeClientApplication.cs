using System;
using System.Runtime.InteropServices;

public class MinimizeClientApplication : IMinimizingApplication
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void MinimizingApplication()
    {
#if UNITY_STANDALONE
        ShowWindow(GetActiveWindow(), 2);
#endif
    }
}
