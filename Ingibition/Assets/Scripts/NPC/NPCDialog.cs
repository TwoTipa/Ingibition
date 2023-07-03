using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private DialogShowType dialogType;
    [SerializeField] private Vector3 dialogOffset;
    [SerializeField] private List<string> dialogList = new List<string>();
    private int currentDialog=0;

    public void PlayDialog()
    {
        if (dialogList.Count > 0 && dialogList.Count> currentDialog)
        {
            switch (dialogType)
            {
                case DialogShowType.random:
                    DialogSystem.Inst.CreateDialog(dialogList[Random.Range(0, dialogList.Count)], transform.position + dialogOffset, transform);
                    break;
                case DialogShowType.linear:
                    DialogSystem.Inst.CreateDialog(dialogList[currentDialog], transform.position + dialogOffset, transform);
                    currentDialog++;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // ������������� ���� ��� �����
        Gizmos.color = UnityEngine.Color.green;

        // ��������� ������� ������ �������
        Vector3 position = transform.position + dialogOffset;

        // ������ ������� � ����� ���������
        Gizmos.DrawWireCube(position, new Vector3(5, 1, 0f));
    }
}
