using UnityEngine;
using Ink.Runtime;

public class MatDialogue : DialogueBase
{
    [Header("Mat Variables")]
    [SerializeField] private bool firstTalk;
    [SerializeField] private bool setScrewdriver;

    public bool circuitIsFixed = false;

    public bool FirstTalk
    {
        get => firstTalk;
        set => firstTalk = value;
    }

    public override void UpdateVariablesState(VariablesState variables)
    {
        base.UpdateVariablesState(variables);

        firstTalk = (bool)variables["firstTalk"];
        setScrewdriver = (bool)variables["setScrewdriver"];

        PerformDialogueActions();
    }

    protected void PerformDialogueActions()
    {
        if (setScrewdriver)
        {
            Debug.Log("Scredriver is set.");
        }
    }




}
