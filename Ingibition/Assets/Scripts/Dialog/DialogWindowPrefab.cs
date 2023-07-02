using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using static UnityEditor.Progress;

public class DialogWindowPrefab : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float dialogSpeed;
    [SerializeField] private TMP_Text textArea;
    private readonly CompositeDisposable _disposable = new();


    public void ShowDialog(string text)
    {
        textArea.text = "";
        char[] chars = text.ToCharArray();
        int charNum = 0;

        Observable.Timer(System.TimeSpan.FromSeconds(dialogSpeed))
            .Repeat()
            .Subscribe(_ => {
                textArea.text += chars[charNum];
                charNum++;
                if (charNum >= chars.Length)
                {
                    _disposable.Clear();
                    Destroy(gameObject, waitTime);
                }
            }).AddTo(_disposable);
    }

    public void StopDialog()
    {
        _disposable.Clear();
        Destroy(gameObject);
    }
}
