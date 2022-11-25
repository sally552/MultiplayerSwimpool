using System;

public interface ITeleportAction
{
    public event Action<ulong, Action> TeleportEvent;
    public void OnTeleportHandlerServerRpc();
}

public interface ICollisionAction
{
    public event Action<ulong, Action> CollisionActionEvent;
    public void OnCollisionHandlerServerRpc();
}
