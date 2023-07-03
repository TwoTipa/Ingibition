using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable lastInteractable;
    public delegate void OnInteractableChangedCallback(bool hasInter);
    public OnInteractableChangedCallback onInteractableChangedCallback;
    public delegate void OnInteractionCallback();
    public OnInteractionCallback onInteractionCallback;

    public static PlayerInteraction _inst;

    private void Awake()
    {
        if (_inst == null)
        {
            _inst = this;
        }
        else
        {
            _inst = null;
        }
    }

    public void SetLastInteractable(Interactable interactable)
    {
        lastInteractable = interactable;
        onInteractableChangedCallback.Invoke(interactable!=null);
    }

    public bool TryUse()
    {
        if (lastInteractable != null)
        {
            lastInteractable.Interact();
            onInteractionCallback.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }
}
