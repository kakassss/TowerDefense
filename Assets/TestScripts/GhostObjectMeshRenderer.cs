using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GhostObjectMeshRenderer : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _meshRenderers;

    private GhostObjectReceiver _ghostObjectReceiver;

    [Inject]
    private void Construct(GhostObjectReceiver ghostObjectReceiver)
    {
        _ghostObjectReceiver = ghostObjectReceiver;
    }

    private void Update()
    {
        SetRedMaterial();
    }
    // private void OnEnable()
    // {
    //     _ghostObjectReceiver.AddOnGhostMaterialGreen(SetGreenMaterial);
    //     _ghostObjectReceiver.AddOnGhostMaterialRed(SetRedMaterial);
    // }
    //
    // private void OnDestroy()
    // {
    //     _ghostObjectReceiver.RemoveOnGhostMaterialGreen(SetGreenMaterial);
    //     _ghostObjectReceiver.RemoveOnGhostMaterialRed(SetRedMaterial);
    // }

    private void SetGreenMaterial()
    {
        for (int i = 0; i < _ghostObjectReceiver.MeshRenderers.Count; i++)
        {
            _ghostObjectReceiver.MeshRenderers[i].material = _ghostObjectReceiver.GreenMaterials[i];
        }
    }

    private void SetRedMaterial()
    {
        for (int i = 0; i < _meshRenderers.Count; i++)
        {
            _ghostObjectReceiver.MeshRenderers[i].material = _ghostObjectReceiver.RedMaterials[i];
        }
    }
}