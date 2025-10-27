using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class UITextSystem : UIEventScript
{
    public static UITextSystem Instance;

    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_Text text = null;
    private List<string> dialogToShow = new List<string>();
    private int index;
    private Action callback;
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
    public void ShowDialog(List<string> dialogToShow , Action callback)
    {
        //activo evento de voz
        PlayerEvent.AddEventToList(id, BuildEvent);
        this.dialogToShow = dialogToShow;
        this.callback = callback;
        uiCanvas.SetActive(true);
        NextDialog();
    }

    private void NextDialog()
    {
        if (index >= dialogToShow.Count)
        {
            EndDialog();
            //aca saco evento de voz
            return;
        }
        text.text = dialogToShow[index];
        index++;        
    }
    //necesit un componente para guardar y llamar al init del dialogo.
    private void EndDialog()
    {
        uiCanvas.SetActive(false);
        index = 0;
        if(callback != null)
        {
            callback.Invoke();
            callback = null;
        }
        PlayerEvent.DeleteEventFromList(id);
    }
}
