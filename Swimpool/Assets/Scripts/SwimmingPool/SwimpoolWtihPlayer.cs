using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimpoolWtihPlayer : BaseState
{
    private Material _material;

    private const string Emission = "_EMISSION";


    public SwimpoolWtihPlayer(Material mat)
    {
        _material = mat;
    }

    public override void ActivateState()
    {
        _material.EnableKeyword(Emission);
    }

    public override void DesactivateState()
    {
        _material.DisableKeyword(Emission);
    }
}
