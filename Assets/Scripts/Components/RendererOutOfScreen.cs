using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used to detect when our sprite is out of screen and out of visibility
 * Use 'OnOutOfScreen' to hook into the out of screen event
 */

[RequireComponent(typeof(Renderer))]
public class RendererOutOfScreen : MonoBehaviour
{
    Renderer mRenderer = null;

    Camera MainCamera = null;

    public System.Action<Vector3> OnOutOfScreen;

    bool bPreviousVisibility = true;

    void Start()
    {
        mRenderer = GetComponent<Renderer>();
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (!mRenderer.isVisible && bPreviousVisibility == true)
        {
            Vector3 CurrentViewportPos = MainCamera.WorldToViewportPoint(transform.position);

            if (CurrentViewportPos.y < 0.0f || CurrentViewportPos.y > 1.0f 
                || CurrentViewportPos.x > 1.0f || CurrentViewportPos.x < 0.0f)
            {
                OnOutOfScreen?.Invoke(CurrentViewportPos);
            }
        }

        bPreviousVisibility = mRenderer.isVisible;
    }
}
