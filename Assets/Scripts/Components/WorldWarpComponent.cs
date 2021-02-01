using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach this to give 'hyperspace' effect to any visible game object
 */

[RequireComponent(typeof(RendererOutOfScreen))]
public class WorldWarpComponent : MonoBehaviour
{
    RendererOutOfScreen RendererOutOfScreenComp;

    private void OnEnable()
    {
        if (RendererOutOfScreenComp != null)
        {
            RendererOutOfScreenComp.OnOutOfScreen += HandleOutOfScreen;
        }
    }

    private void OnDisable()
    {
        RendererOutOfScreenComp.OnOutOfScreen -= HandleOutOfScreen;
    }

    void Start()
    {
        RendererOutOfScreenComp = GetComponent<RendererOutOfScreen>();
        RendererOutOfScreenComp.OnOutOfScreen += HandleOutOfScreen;
    }

    //Warp the GO to the other side by calculating new postion by using viewport to world
    void HandleOutOfScreen(Vector3 ViewportPos)
    {
        if (ViewportPos.y < 0.0f || ViewportPos.y > 1.0f)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(ViewportPos.x, -1.0f * ViewportPos.y + 1.0f, ViewportPos.z));
        }
        else if(ViewportPos.x > 1.0f || ViewportPos.x < 0.0f)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-1.0f * ViewportPos.x + 1.0f, ViewportPos.y, ViewportPos.z));
        }
    }
}
