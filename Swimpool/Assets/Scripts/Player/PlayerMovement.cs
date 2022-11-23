using Unity.Netcode;
using UnityEngine;

public abstract class PlayerMovement : NetworkBehaviour
{
    protected abstract void Movement();
    protected abstract void Rotate();

    [ClientRpc]
    public virtual void SetPlayerPositionClientRpc(Vector3 position)
    { }
}
