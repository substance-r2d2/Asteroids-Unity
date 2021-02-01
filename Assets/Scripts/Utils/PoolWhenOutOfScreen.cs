using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RendererOutOfScreen))]
public class PoolWhenOutOfScreen : SimplePoolable
{
    RendererOutOfScreen OutOfScreenRender;

    private void OnEnable()
    {
        if(OutOfScreenRender != null)
        {
            OutOfScreenRender.OnOutOfScreen += HandleOutOfScreen;
        }
    }

    private void OnDisable()
    {
        OutOfScreenRender.OnOutOfScreen -= HandleOutOfScreen;
    }

    private void Start()
    {
        OutOfScreenRender = GetComponent<RendererOutOfScreen>();
        OutOfScreenRender.OnOutOfScreen += HandleOutOfScreen;
    }

    void HandleOutOfScreen(Vector3 ViewportPos)
    {
        Pool();
    }
}
