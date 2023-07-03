using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private DialogWindowPrefab dialogWindowPrefab;
    private DialogWindowPrefab dWin;

    public static DialogSystem Inst;

    private void Awake()
    {
        if (Inst==null)
        {
            Inst = this;
        }
        else
        {
            Inst = null;
        }
    }

    public void CreateDialog(string dialog, Vector3 pos, Transform parent)
    {
        if(dWin != null)dWin.StopDialog();
        dWin = Instantiate(dialogWindowPrefab, pos, Quaternion.identity, parent);
        dWin.ShowDialog(dialog);
    }
}

public enum DialogShowType
{
    random, linear
}
