using System;
using UnityEngine;

public abstract class UI_Container : MonoBehaviour
{
    private GameObject container;
    private GameObject canvas;

    protected GameObject Canvas => canvas;

    protected virtual void Awake() => canvas = transform.Find("Canvas").gameObject;

    public bool ToggleCanvas(bool active)
    {
        canvas.SetActive(active);
        return canvas.activeInHierarchy;
    }
}
