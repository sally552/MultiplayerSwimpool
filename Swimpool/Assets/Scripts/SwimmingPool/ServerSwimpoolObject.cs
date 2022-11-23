using System;
using Unity.Netcode;
using UnityEngine;

//TODO íå çàáûòü ïåğåèìåíîâàòü
[RequireComponent(typeof(IStateSwitcher<BaseState>))]
public class ServerSwimpoolObject : NetworkBehaviour
{
    public NetworkVariable<ulong> Owner { get; } = new NetworkVariable<ulong>(0);

    private IStateSwitcher<BaseState> _swimpoolState;

    public override void OnNetworkSpawn()
    {
        _swimpoolState = GetComponent<IStateSwitcher<BaseState>>();
        Owner.OnValueChanged += (x, y) => _swimpoolState.SwitchNextState();        

        base.OnNetworkSpawn();

        if (!IsServer)
        {
            enabled = false;
            return;
        }
    }

    public void PlayerActionOnInsideSwimpool(ulong id, Action OnActionSucñess = null)
    {
        if (!CheckCanPlayerInsideToSwimpool(id)) return;

        Owner.Value = CheckPlayerInSwimpool(id) ? 0 : id;
        OnActionSucñess?.Invoke();
    }

    public bool CheckPlayerInSwimpool(ulong id)
    {
        return id.Equals(Owner.Value);
    }

    public override void OnNetworkDespawn()  
    {
        Owner.OnValueChanged -= (x, y) => _swimpoolState.SwitchNextState();
    }

    private bool CheckCanPlayerInsideToSwimpool(ulong id)
    {
        return Owner.Value.Equals(0) || CheckPlayerInSwimpool(id);
    }
}