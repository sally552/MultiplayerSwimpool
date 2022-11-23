using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkConnectionManager : MonoBehaviour
{
    public static string IPToConnectTo = "127.0.0.1";
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        var networkManager = NetworkManager.Singleton;
        if (!networkManager.IsClient && !networkManager.IsServer)
        {
            IPToConnectTo = GUILayout.TextField(IPToConnectTo);
            if (GUILayout.Button("Host"))
            {
                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(IPToConnectTo, 9998);
                networkManager.StartHost();
            }

            if (GUILayout.Button("Client"))
            {

                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(IPToConnectTo, 9998);
                networkManager.StartClient();
            }

            if (GUILayout.Button("Server"))
            {

                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(IPToConnectTo, 9998);
                networkManager.StartServer();
            }
        }

        GUILayout.EndArea();
    }
}

