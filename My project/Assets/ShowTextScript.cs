using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowText(string _text)
    {
        if(_text != "")
        {
            text.text = _text;
            this.gameObject.SetActive(true);
        }      
    }

    public void HideText()
    {
        this.gameObject.SetActive(false);
    }
}
