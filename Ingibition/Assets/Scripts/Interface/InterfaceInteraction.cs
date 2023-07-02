using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class InterfaceInteraction : MonoBehaviour
{
    public TMP_Text helpText;
    private void Start()
    {
        PlayerInteraction._inst.onInteractableChangedCallback += UpdateActionButtonIcon;
        PlayerInteraction._inst.onInteractionCallback += UpdateInteractionText;
    }

    private void UpdateInteractionText()
    {
        helpText.color = Color.yellow;
        Observable.Timer(System.TimeSpan.FromSeconds(0.1f)) // создаем timer Observable
        .Subscribe(_ => { // подписываемся
            helpText.color = Color.white;
        }).AddTo(this); // привязываем подписку к disposable
    }

    private void UpdateActionButtonIcon(bool hasInter)
    {
        helpText.gameObject.SetActive(hasInter);
    }
}
