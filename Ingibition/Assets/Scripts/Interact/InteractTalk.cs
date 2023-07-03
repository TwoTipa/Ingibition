using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTalk : Interactable
{
    private NPCDialog dialog;

    private void Awake()
    {
        dialog = GetComponent<NPCDialog>();
    }
    public override void Interact()
    {
        base.Interact();
        dialog.PlayDialog();
    }
}
