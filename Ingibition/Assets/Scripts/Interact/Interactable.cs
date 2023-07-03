using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Interactable : MonoBehaviour, IInteractable
{
    public bool isTriggerInstant;
    protected bool hasInteracted;
    protected GameObject entity;

    public GameObject GetCurrentEntity()
    {
        return entity;
    }

    public virtual void Interact()
    {
        if (entity == null || hasInteracted)
        {
            return;
        }
        else if (entity != null)
        {
            // This method is supposed to be overridden by the child classes
            Debug.Log("Interacting with " + entity.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && !hasInteracted)
        {
            entity = this.gameObject;
            PlayerInteraction._inst.SetLastInteractable(this);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other != null && !hasInteracted)
        {
            entity = this.gameObject;
            PlayerInteraction._inst.SetLastInteractable(this);
        }
        else if (other != null && hasInteracted)
        {
            entity = null;
            PlayerInteraction._inst.SetLastInteractable(null);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        entity = null;
        PlayerInteraction._inst.SetLastInteractable(null);
    }
}
