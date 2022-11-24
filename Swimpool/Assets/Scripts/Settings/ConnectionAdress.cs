using UnityEngine;
using static Unity.Netcode.Transports.UTP.UnityTransport;

[CreateAssetMenu(fileName = "new Adress", menuName = "ScriptableObjects/Connection Adress")]
public class ConnectionAdress :  ScriptableObject
{
    public ConnectionAddressData AddressData;
}
