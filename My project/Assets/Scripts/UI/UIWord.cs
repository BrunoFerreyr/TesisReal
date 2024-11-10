using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIWord : MonoBehaviour
{
    [SerializeField] private TMP_Text wordText = null;
    [SerializeField] private Image image = null;
    public string word;
    // Start is called before the first frame update
    public void Init(string wordText)
    {
        word = wordText;
        this.wordText.text = wordText;
        image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
