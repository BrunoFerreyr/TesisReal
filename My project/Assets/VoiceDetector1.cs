using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceDetector1 : MonoBehaviour
{
    KeywordRecognizer KeywordRecognizer;
    Dictionary<string, Action> wordToAction;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Avanza()
    {
        rb.velocity=transform.forward*2f;
    }

    

    public void Update()
    {
        
    }
    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    
}
