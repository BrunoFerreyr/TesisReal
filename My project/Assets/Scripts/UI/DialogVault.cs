using UnityEngine;
using System.Linq;
using System;

public class DialogVault : MonoBehaviour
{
    public static DialogVault Instance;
    private Dialog[] dialogs;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FindDialog(string dialogId, Action callback)
    {
        Dialog dialog = dialogs.Where(dialog => dialog.dialogId == dialogId).FirstOrDefault();
        if(dialog != null)
        {
            UITextSystem.Instance.ShowDialog(dialog.dialogs.ToList(), callback);
        }
        else
        {
            Debug.LogError($"The dialog with the id {dialogId} does not exist on the dialogs array");
        }
    }

}
