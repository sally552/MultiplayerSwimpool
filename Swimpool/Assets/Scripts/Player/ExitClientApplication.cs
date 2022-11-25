using UnityEngine;

public class ExitClientApplication : IExitApplication
{
    public void ExitApplication()
    {
        Application.Quit();
    }
}
