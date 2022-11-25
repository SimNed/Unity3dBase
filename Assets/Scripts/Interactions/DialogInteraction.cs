using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DialogInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogDatasSO dialogDatas;

    [SerializeField] private Broadcaster<Dialog> broadcaster;

    private Queue<Dialog> dialogsStream;

    private void Start()
    {
        dialogsStream = dialogDatas.GetDialogsStream();
    }

    public void Interact()
    {
        Dialog dialog = dialogsStream.Peek().IsSayingOnce ? dialogsStream.Dequeue() : dialogsStream.Peek();
        
        broadcaster.Broadcast(dialog);
    }
}