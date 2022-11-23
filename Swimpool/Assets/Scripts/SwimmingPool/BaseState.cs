using System;
using Unity.Netcode;
using UnityEngine;

public abstract class BaseState: IChangeActiveItem
{
    public BaseState SwitchStateTo { get; set; }

    public virtual void ActivateState()
    {
        
    }

    public virtual void DesactivateState()
    {
        
    }
}



