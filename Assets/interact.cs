using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class interact : MonoBehaviour
{
    Outline outline;
    public UnityEvent onInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void Interact()
    {
        onInteract.Invoke();
    }

}
