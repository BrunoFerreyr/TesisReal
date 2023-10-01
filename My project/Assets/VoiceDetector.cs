using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceDetector : MonoBehaviour
{
    KeywordRecognizer KeywordRecognizer;
    Dictionary<string, Action> wordToAction;
    private Rigidbody rb;
    public GameObject text;
    int level;
    // Start is called before the first frame update
    public List<EventScript> events;

    public List<EventScript> helpEvents;
    public int actualHelpNumber;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("azul", Azul);
        wordToAction.Add("rojo", Rojo);
        wordToAction.Add("verde", Verde);
        wordToAction.Add("Donde esta la puerta", Avanza);
        wordToAction.Add("gira", Gira);
        wordToAction.Add("salta", Salta);
        wordToAction.Add("Dame Vision", ShowCode);
        wordToAction.Add("Empujar", BreakThings);
        wordToAction.Add("1389", OpenDoor);
        wordToAction.Add("Ayuda", Help);
        KeywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        KeywordRecognizer.OnPhraseRecognized += WordRecognized;
        KeywordRecognizer.Start();
        Debug.Log("entr");
    }
    
    private void Avanza()
    {
        //rb.AddForce(transform.forward*1000f);

    }

    private void Gira()
    {
        this.transform.eulerAngles = new Vector3(0,-180,0);
    }

    private void Salta()
    {
        //rb.velocity = transform.up * 5f;
    }
    /// <summary>
    /// 1-Creo la palabra en el start
    /// 2-Creo la funcion con el mismo name mas abajo. En la misma tengo qeu verificar si hay eventos en la lista, y luego construir el mismo con BuildEvent, y pasando la int de referencia de ese evento.
    /// 3-Creo el script del evento. Saco el monobehaviour y uso EventScript en su lugar, delegando las funciones DoEvent y BuildEvent.
    /// 4-En el do event tengo que poner lo que hace el evento o llamar algo dentro del script para hacerlo.IMPORTANTE:Verificar siempre donde pongo el eventHasStarted en true y false.
    /// 5-Listo.
    /// 6-Poner Rigidbody al collider del event tambien el tag Event
    /// </summary>
    private void ShowCode()
    {
        //Usamos siempre el mismo numero, al hacer un evento, lo desactivo, entonces el siguiente va a ser el unico con ese numero, y asi suscesivamente.
        if(events.Count != 0)
        {
            for (int x = 0; x < events.Count; x++)
            {
                events[x].GetComponent<EventScript>().BuildEvent(0,level);
                
            }
        }      
        //Despues esto puede unirse todo, con las palabras cambio un int yllamo a una funcion con el for
    }
    //PUEDO TENER 2 SCRIPTS, UNO CON LOS DIALOGSO SIN EVENTOS, Y CUANDO COLISIONA CON UNO, SE 
    //ACTIVA ESTE.
    private void OpenDoor()
    {
        if (events.Count != 0)
        {
            for (int x = 0; x < events.Count; x++)
            {
                events[x].GetComponent<EventScript>().BuildEvent(1,level);
                //Solo funciona si los numeros en ambos lados son los mismos, con esto cada evento tendra su numero.
            }
        }
        //UsarEvent de abajo
    }
    private void BreakThings()
    {
        if (events.Count != 0)
        {
            for (int x = 0; x < events.Count; x++)
            {
                events[x].GetComponent<EventScript>().BuildEvent(2,level);
            }
        }
    }
    private void Help()
    {
        helpEvents[actualHelpNumber].GetComponent<EventScript>().BuildEvent(0,level);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            actualHelpNumber = 1;
        }
    }
    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    private void Verde()
    {
        //GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
        Debug.Log("entra1");
    }

    private void Rojo()
    {
        //GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
    }

    private void Azul()
    {
        //GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);
        Debug.Log("entra2");
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Event")
        {
            events.Add(other.GetComponent<EventScript>());// va a agregarcada vez que colisiona
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Event")
        {
            int temporalID = other.GetComponent<EventScript>().type;
            for(int x = 0; x< events.Count; x++)
            {
                if(events[x] != null)
                {

                    if (temporalID == events[x].type)
                    {
                        events.RemoveAt(x);
                        Debug.Log("temporalID" + temporalID+ "wtf"+ x);
                    }
                }
            }            
        }
    }
}
