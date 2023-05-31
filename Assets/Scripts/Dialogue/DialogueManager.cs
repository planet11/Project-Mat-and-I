using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Load Global JSON")]
    [SerializeField] private TextAsset loadGlobalJSON;

    public static DialogueManager instance;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private DialogueVariables dialogueVariables;
    private InkExtFunctions inkExtFunctions;

    public Collider2D screwdriverCollider;
    public Collider2D hammerCollider;
    public ItemPickup hammer;
    public Animator matAnim; 


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        DontDestroyOnLoad(instance);

        dialogueVariables = new DialogueVariables(loadGlobalJSON);
        inkExtFunctions = new InkExtFunctions();
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        screwdriverCollider.enabled = false;
        hammerCollider.enabled = false;
        hammer.enabled = false;

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        for (int index = 0; index < choices.Length; index++)
        //foreach(GameObject choice in choices)
            choicesText[index] = choices[index].GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!dialogueIsPlaying)
            return;

        if (inkExtFunctions.screwdriverIsSet)
            screwdriverCollider.enabled = true;

        if (inkExtFunctions.hammerIsSet)
            hammerCollider.enabled = true;

        if (inkExtFunctions.matIsHit)
            matAnim.enabled = false;

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        inkExtFunctions.Bind(currentStory);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialogueVariables.StopListening(currentStory);

        //inkExtFunctions.Unbind(currentStory);
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else if (!currentStory.canContinue)
        {
            ExitDialogueMode();
        }
        else
        {
            return;
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        for (int index = 0; index < choices.Length; index++)
        //foreach(Choice choice in currentChoices)
        {
            if (index < currentChoices.Count)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = currentChoices[index].text;
            }
            else
            {
                choices[index].gameObject.SetActive(false);
                choicesText[index].text = "";
            }
        }
        //StartCoroutine(SelectedFirstChoice());
    }

    //private IEnumerator SelectedFirstChoice()
    //{
        ///Event System requires we clean it first,
        ///then wait for at least one frame before we set the current selected obj
        //EventSystem.current.SetSelectedGameObject(null);
        //yield return new WaitForEndOfFrame();
        //EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    //}

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        dialogueText.text = currentStory.Continue();
        DisplayChoices();
    }

}
