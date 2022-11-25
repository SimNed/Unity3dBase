using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName="DialogDatas", menuName="Scriptable Object/Datas/DialogDatas")]

public class DialogDatasSO : ScriptableObject
{
    [SerializeField] private List<Dialog> dialogs;

    private Queue<Dialog> dialogsStream;

    private void OnEnable()
    {
        this.dialogsStream = new Queue<Dialog>(dialogs);
    }

    public Queue<Dialog> GetDialogsStream()
    {
        return this.dialogsStream;
    }
}
