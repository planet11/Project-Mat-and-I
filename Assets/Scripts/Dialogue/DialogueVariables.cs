using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> variables;

    public DialogueVariables(TextAsset loadGlobalJSON)
    {
        ///create the story
        Story globalVariablesStory = new Story(loadGlobalJSON.text);

        ///initialize the dictionary of variables
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Intializing " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        ///set the varibles global should be done before the listener
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

   private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        //Debug.Log("Variable changed: " + name + " = " + value);
        ///only maintain variables initialized from the global ink file
        if (variables.ContainsKey(name))
        {
            variables[name] = value;
            //variables.Remove(name);
            //variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    } 
}
