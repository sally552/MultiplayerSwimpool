using Unity.Netcode;
using UnityEngine;

public class ClientUtils : NetworkBehaviour
{
    private IMinimizingApplication minimizing;
    private IExitApplication exitApplication;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        enabled = IsClient;
        if (!IsOwner)
        {
            enabled = false;
            return;
        }
    }

    private void Start()
    {
        minimizing = new MinimizeClientApplication();
        exitApplication = new ExitClientApplication();
    }

    private void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitApplication.ExitApplication();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            minimizing.MinimizingApplication();
        }
#endif
    }
}
