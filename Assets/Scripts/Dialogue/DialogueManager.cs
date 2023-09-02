using System.Collections.Generic;
using UnityEngine;
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

    private static DialogueManager instance;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public Animator matAnim;
    public Rigidbody2D matRB;

    private DialogueVariables dialogueVariables;

    private InkExtFunctions inkExtFunctions;
    private InventoryManager inventoryManager;
    private LevelChanger levelChanger;
    private bool isHammerUsed;
    private bool isScrewdriverUsed;
    private bool isGameEnd;
    private bool isMatHit; 

    private void Awake()
    {
        if (instance != null)
            Debug.Log("Found more than one Dialogue Manager in the scene");
        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalJSON);
        inkExtFunctions = new InkExtFunctions();
        inventoryManager = new InventoryManager();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        for (int index = 0; index < choices.Length; index++)
            choicesText[index] = choices[index].GetComponentInChildren<TextMeshProUGUI>();

        matAnim = GetComponent<Animator>();
        matRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        inkExtFunctions.Bind(currentStory);

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);
        UseItem();
        GameEnd();
        HitMat();
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialogueVariables.StopListening(currentStory);

        inkExtFunctions.Unbind(currentStory);
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else if (!currentStory.canContinue)
            ExitDialogueMode();
        else
            return;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        for (int index = 0; index < choices.Length; index++)
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
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        dialogueText.text = currentStory.Continue();
        DisplayChoices();
    }

    public void UseItem()
    {
        inkExtFunctions.HasHammer(isHammerUsed);
        inkExtFunctions.HasScrewdriver(isScrewdriverUsed);

        if (!isHammerUsed | !isScrewdriverUsed)
        {
            List<Item> currentItems = new List<Item>();
            currentItems = inventoryManager.items;
            foreach (Item currentItem in currentItems)
                inventoryManager.RemoveItem(currentItem);
        }
    }

    public void GameEnd()
    {
        inkExtFunctions.ChangeGameState(isGameEnd);
        if (isGameEnd)
            levelChanger.ChangeScene("End");
    }

    public void HitMat()
    {
        inkExtFunctions.ChangeMatState(isMatHit);
        if (isMatHit)
        {
            matAnim.enabled = false;
            matRB.Sleep();
        }
    }

    public void OnApplicationQuit()
    {
        if(dialogueVariables != null)
            dialogueVariables.SaveVariables();
    }

}
