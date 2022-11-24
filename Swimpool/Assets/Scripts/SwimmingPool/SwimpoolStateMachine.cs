using Unity.Netcode;
using UnityEngine;

[DefaultExecutionOrder(1)]
[RequireComponent(typeof(ServerSwimpoolObject))]
public class SwimpoolStateMachine : NetworkBehaviour, IStateSwitcher<BaseState>
{
    [SerializeField]
    private Material _swimpoolEmmisionMaterial;

    public BaseState _currentState;

    private BaseState _stateWithPlayer;
    private BaseState _stateWithoutPlayer;
    private ServerSwimpoolObject _serverSwimpool;


    private void Awake()
    {
        _serverSwimpool = GetComponent<ServerSwimpoolObject>();
        _stateWithPlayer = new SwimpoolWtihPlayer(_swimpoolEmmisionMaterial);
        _stateWithoutPlayer = new SwimpoolWtihoutPlayer();
        _stateWithoutPlayer.DesactivateState();
        _stateWithPlayer.DesactivateState();

        _stateWithPlayer.SwitchStateTo = _stateWithoutPlayer;
        _stateWithoutPlayer.SwitchStateTo = _stateWithPlayer;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (!IsClient)
        {
            enabled = false;
            return;
        }
       
        SetStartState();
    }

    public void Switcher(BaseState newState)
    {
        if (_currentState != null)
            _currentState.DesactivateState();
        _currentState = newState;
        _currentState.ActivateState();
    }

    public void SwitchNextState()
    {
        if(_currentState != null)
            _currentState.DesactivateState();
        _currentState = _currentState.SwitchStateTo;
        _currentState.ActivateState();
    }

    private void SetStartState()
    {
        var hasOwner = !_serverSwimpool.Owner.Value.Equals(0);
        Switcher(hasOwner ? _stateWithPlayer : _stateWithoutPlayer);
    }
}
