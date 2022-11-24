using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkConnectionManager : MonoBehaviour
{
    //TODO в редакторе ручками подставлять или ручками вбивать
    [SerializeField]
    private ConnectionAdress _adress;
    private string m_IPToConnectTo;
    private ushort _port;

    private void Awake()
    {
        m_IPToConnectTo = _adress.AddressData.Address;
        _port = _adress.AddressData.Port;
    }

    private void OnGUI()
    {

        GUILayout.BeginArea(new Rect(10, 10, 300, 600));
        var networkManager = NetworkManager.Singleton;

        var connect = (networkManager.IsClient || networkManager.IsServer);
        if (!connect)
        {
#if UNITY_EDITOR
            m_IPToConnectTo = GUILayout.TextField(m_IPToConnectTo);
            _port = ushort.Parse(GUILayout.TextField(_port.ToString()));


            if (GUILayout.Button("Host"))
            {
                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(m_IPToConnectTo, _port);
                networkManager.StartHost();
            }
#endif
#if CLIENT || UNITY_EDITOR
            if (GUILayout.Button("Client"))
            {
                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(m_IPToConnectTo, _port);
                networkManager.StartClient();
            }
#endif
#if SERVER || UNITY_EDITOR
            if (GUILayout.Button("Server"))
            {
                (networkManager.NetworkConfig.NetworkTransport as UnityTransport).SetConnectionData(m_IPToConnectTo, _port);
                networkManager.StartServer();
            }
#endif
        }
#if SERVER && !UNITY_EDITOR
        else
        if (GUILayout.Button("Stop server"))
        {
            networkManager.Shutdown();
        }
#endif
        GUILayout.EndArea();
    }
}

