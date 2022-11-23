using Unity.Netcode;
using UnityEngine;

public class VRClientPlayerMovement : PlayerMovement
{
    [ClientRpc]
    public override void SetPlayerPositionClientRpc(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    protected override void Movement()
    {
        throw new System.NotImplementedException();
    }

    protected override void Rotate()
    {
        throw new System.NotImplementedException();
    }
}
