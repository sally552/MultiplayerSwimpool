using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR && UNITY_STANDALONE
public class SwitchServerAndClient
{
    private  const string SERVER = "SERVER";
    private  const string CLIENT = "CLIENT";

    private  const string CLIENT_PATH = "Build/Switch to client";
    private  const string SERVER_PATH = "Build/Switch to server";

    private const string SettingPrefKey = "Setting";
    private static bool IsServerEnabled
    {
        get => EditorPrefs.GetBool(SettingPrefKey);
        set => EditorPrefs.SetBool(SettingPrefKey, value);
    }

    [MenuItem(CLIENT_PATH)]
    public static void SwitchToClient()
    {
        string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
        defines = AddCompilerDefines(defines, CLIENT);
        defines = RemoveCompilerDefines(defines, SERVER);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defines);
        IsServerEnabled = false;
    }

    [MenuItem(SERVER_PATH)]
    public static void SwitchToServer()
    {
        string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);      
        defines = AddCompilerDefines(defines, SERVER);
        defines = RemoveCompilerDefines(defines, CLIENT);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defines);
        IsServerEnabled = true;
    }

    [MenuItem(CLIENT_PATH, false), MenuItem(SERVER_PATH, true)]
    private static bool SettingValidate()
    {
        Menu.SetChecked(CLIENT_PATH, !IsServerEnabled);
        Menu.SetChecked(SERVER_PATH, IsServerEnabled);
        return true;
    }



    private static string AddCompilerDefines(string defines, params string[] toAdd)
    {
        List<string> splitDefines = new List<string>(defines.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries));
        foreach (var add in toAdd)
        {
            if (!splitDefines.Contains(add))
                splitDefines.Add(add);
        }
        return string.Join(";", splitDefines.ToArray());
    }

    private static string RemoveCompilerDefines(string defines, params string[] toRemove)
    {
        List<string> splitDefines = new List<string>(defines.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries));
        foreach (var remove in toRemove)
            splitDefines.Remove(remove);

        return string.Join(";", splitDefines.ToArray());
    }
}
#endif