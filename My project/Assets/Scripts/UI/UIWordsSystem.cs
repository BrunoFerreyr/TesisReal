using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class UIWordsSystem : EventScript
{
    public static UIWordsSystem Instance;
    [SerializeField] private GameObject wordsInGame;
    [SerializeField] private UIWord wordPrefab;
    [SerializeField] private Transform wordsContainer;
    private bool toggleBool = false;
    private List<UIWord> instantiatedWords = new List<UIWord>();
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            PlayerEvent.AddEventToList(id,BuildEvent);
            DontDestroyOnLoad(gameObject);
        }
    }

    public override void DoEvent(int level)
    {
        base.DoEvent(level);
        ToggleMenu();
    }

    private void ToggleMenu()
    {
        toggleBool = !toggleBool;
        wordsInGame.SetActive(toggleBool);
    }

    public void UpdateWords()
    {
        List<string> words = new List<string>(PlayerEvent.eventsDictionary.Keys);
        foreach(string word in words)
        {
            if (!IsWordAlreadyInstantiated(word))
            {
                UIWord uiWord = Instantiate(wordPrefab, wordsContainer);
                instantiatedWords.Add(uiWord);
                uiWord.Init(word);
            }
        }
    }

    public void DeleteWord(string word)
    {
        UIWord wordToDelete = instantiatedWords.Where(uiWord => uiWord.word == word).FirstOrDefault();
        if(wordToDelete == null)
        {
            Debug.LogError($"The word {word} that you are trying to delete is not already instantiated");
        }
        instantiatedWords.Remove(wordToDelete);
        Destroy(wordToDelete.gameObject);
    }
    private bool IsWordAlreadyInstantiated(string word) { return instantiatedWords.Where(uiWord => uiWord.word == word).ToList().Count > 0 ? true : false; }   
}
