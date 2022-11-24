using System;
using Unity.Netcode;
using UnityEngine;

[DefaultExecutionOrder(0)] 
public class ServerTeleportPlayerAction : NetworkBehaviour, ITeleportAction, ICollisionAction
{
    public event Action<ulong, Action> TeleportEvent;
    public event Action<ulong, Action> CollisionActionEvent;

    [SerializeField]
    private Camera m_Camera;
    [SerializeField]
    private PlayerEmergencePoints _points;
    private PlayerMovement _client;
    private ServerSwimpoolObject _swimpool;


    private void Awake()
    {
        _swimpool = FindObjectOfType<ServerSwimpoolObject>();
        _client = GetComponent<PlayerMovement>();
        TeleportEvent += _swimpool.PlayerActionOnInsideSwimpool;

        //TODO загатовка
        CollisionActionEvent += _swimpool.PlayerActionOnInsideSwimpool;
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsServer)
        {
            enabled = false;
            return;
        }
        Teleport(_points.GetRandomSpawnPosition());
    }

    [ServerRpc]
    public void OnTeleportHandlerServerRpc()
    {
        var pos = _swimpool.CheckPlayerInSwimpool(NetworkObjectId) ?
            _points.GetRandomSpawnPosition() :
            _points.GetSwimPointPosition();
           
        TeleportEvent(NetworkObjectId, ()=> Teleport(pos));
    }

    private void Teleport(Vector3 pos)
    {
        _client.SetPlayerPositionClientRpc(pos);
    }

    public override void OnDestroy()
    {
        TeleportEvent -= _swimpool.PlayerActionOnInsideSwimpool;
        CollisionActionEvent -= _swimpool.PlayerActionOnInsideSwimpool;
        base.OnDestroy();
    }


    [ServerRpc]
    public void OnCollisionHandlerServerRpc()
    {
        CollisionActionEvent(NetworkObjectId, null);
    }
}
