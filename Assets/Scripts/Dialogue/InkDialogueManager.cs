using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    public static InkDialogueManager instance;

    [Header("Dialogue UI")]
    public DialogueCanvas dialogueCanvasPrefab;
    public Button choicesButtonPrefab;
    [SerializeField] private DialogueCanvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject choicesButtons;
    //private TextMeshProUGUI[] choicesText;

    [SerializeField] private DialogueBase dialogueObj;
    [SerializeField] private Story story;

    public bool dialogueIsPlaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void EnterDialogue(DialogueBase speaker)
    {
        dialogueIsPlaying = true;

        dialogueObj = speaker;

        TextAsset storyText = speaker.GetDialogueAsset();
        story = new Story(storyText.text);

        VariablesState speakerStoryVariables = speaker.GetVariables();
        if (speakerStoryVariables != null)
            UpdateStoryVariables(speakerStoryVariables);

        CreateDialogueUI();
        ContinueStory();
    }

    void UpdateStoryVariables(VariablesState objStoryVariables)
    {
        foreach (string variable in objStoryVariables)
        {
            object varValueFromObj = objStoryVariables[variable];
            story.variablesState[variable] = varValueFromObj;
        }
    }

    void CreateDialogueUI()
    {
        dialogueCanvas = Instantiate(dialogueCanvasPrefab);
        dialogueText = dialogueCanvas.dialogueText;
        choicesButtons = dialogueCanvas.dialogueChoices;
    }

    public void ContinueStory()
    {
        if (story.canContinue)
            dialogueText.text = story.Continue();

        if(story.currentChoices.Count > 0)
        {
            for (int choiceNum = 0; choiceNum < story.currentChoices.Count; choiceNum++)
            {
                Choice inkChoice = story.currentChoices[choiceNum];
                Button choiceButton = CreateChoiceButton(inkChoice.text);

                choiceButton.onClick.AddListener(() => SelectChoice(inkChoice.index));
            }
        }
        else if(!story.canContinue)
            ExitDialogue();
    }

    Button CreateChoiceButton(string choiceText)
    {
        Button button = Instantiate(choicesButtonPrefab, choicesButtons.transform);

        button.GetComponent<TMP_Text>().text = choiceText;
        return button;
    }

    void SelectChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        Refresh();
        ContinueStory();
    }

    void Refresh()
    {
        foreach (Transform choiceButton in choicesButtons.transform)
            Destroy(choiceButton.gameObject);
        dialogueText.text = "";
    }

    void ExitDialogue()
    {
        dialogueIsPlaying = false;

        dialogueObj.UpdateVariablesState(story.variablesState);

        Refresh();
        Destroy(dialogueCanvas.gameObject);
        ClearReference();
    }

    void ClearReference()
    {

    }



}
