using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogManagerSubscriptionEventChannelSO dialogManagerSubscriptionEventChannel;

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject dialogView;
    [SerializeField] private TextMeshProUGUI narratorNameDisplayer;
    [SerializeField] private TextMeshProUGUI messageDisplayer;

    private Queue<string> dialogFileStream = new Queue<string>();

    private void OnEnable()
    {
        dialogManagerSubscriptionEventChannel.OnEventRaised += StartDialog;
    }

    private void OnDisable()
    {
        dialogManagerSubscriptionEventChannel.OnEventRaised -= StartDialog;
    }

    private void StartDialog(Dialog dialog)
    {
        dialogFileStream = DialogUtility.ReadTextFile(dialog.TextFile);
        
        dialogView.SetActive(true);

        DialogUtility.DisplayDialog(dialogFileStream, narratorNameDisplayer, messageDisplayer);
        
        playerInput.SwitchCurrentActionMap("Dialog");
    }

    public void ContinueDialog()
    {
        if(dialogFileStream.Count > 0)
            DialogUtility.DisplayDialog(dialogFileStream, narratorNameDisplayer, messageDisplayer);   
        
        else
            EndDialog();
    }

    private void EndDialog()
    {
        DialogUtility.ResetDialogDisplay(narratorNameDisplayer, messageDisplayer);

        dialogView.SetActive(false);
        
        dialogFileStream.Clear();
        
        playerInput.SwitchCurrentActionMap("Player");
    }
}
