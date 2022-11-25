using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public static class DialogUtility
{
    public const string NAME_PARAMETER_START_CHAR = "[";
    public const string NAME_PARAMETER_END_CHAR = "]";

    public static Queue<string> ReadTextFile(TextAsset dialogTextFile)
    {
        Queue<string> dialog = new Queue<string>();

        string dialogText = dialogTextFile.text;
        string[] dialogLines = dialogText.Split(System.Environment.NewLine.ToCharArray());

        foreach (string line in dialogLines)
        {
            if (!string.IsNullOrEmpty(line))
                dialog.Enqueue(line);
        }

        return dialog;
    }
    
    public static string GetNameInLine(string dialogLine)
    {
        string name = dialogLine.Substring(
            dialogLine.IndexOf(NAME_PARAMETER_START_CHAR) + 1, 
            dialogLine.IndexOf(NAME_PARAMETER_END_CHAR) - 1
        );
                    
        return name.Trim();
    }

    public static string GetMessageInLine(string dialogLine)
    {            
        string messageDisplayer = dialogLine.Substring(
            dialogLine.IndexOf(NAME_PARAMETER_END_CHAR) + 1, 
            dialogLine.Length - dialogLine.IndexOf(NAME_PARAMETER_END_CHAR) - 1
        );

        return messageDisplayer;
    }

    public static void DisplayDialog(Queue<string> dialogFileStream, TextMeshProUGUI narratorNameDisplayer, TextMeshProUGUI messageDisplayer)
    {
        if (dialogFileStream.Peek().StartsWith(NAME_PARAMETER_START_CHAR))
        {
            narratorNameDisplayer.text = GetNameInLine(dialogFileStream.Peek());
            messageDisplayer.text = GetMessageInLine(dialogFileStream.Dequeue());
        }

        else
            messageDisplayer.text = dialogFileStream.Dequeue();
    }

    public static void ResetDialogDisplay(TextMeshProUGUI narratorNameDisplayer, TextMeshProUGUI messageDisplayer)
    {
        narratorNameDisplayer.text = "";
        messageDisplayer.text = "";
    }
}
