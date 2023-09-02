using UnityEngine;
using Ink.Runtime;

public class InkExtFunctions
{
    public void Bind(Story story)
    {
        if(story != null)
        {
            story.BindExternalFunction("setItem", (string item) => SetItem(item));
            story.BindExternalFunction("hasHammer", (bool hasHammer) => HasHammer(hasHammer));
            story.BindExternalFunction("hasScrewdriver", (bool hasScrewdriver) => HasScrewdriver(hasScrewdriver));
            story.BindExternalFunction("gameState", (bool isEnded) => ChangeGameState(isEnded));
            story.BindExternalFunction("matState", (bool isHit) => ChangeMatState(isHit));
        }
        else
            Debug.Log("Story is null.");
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("setItem");
        story.UnbindExternalFunction("hasHammer");
        story.UnbindExternalFunction("hasScrewdriver");
        story.UnbindExternalFunction("gameState");
        story.UnbindExternalFunction("matState");
    }

    public void SetItem(string item)
    {
        Debug.Log(item + "is set.");
    }

    public void HasHammer(bool hasHammer)
    {
        Debug.Log(hasHammer);
    }

    public void HasScrewdriver(bool hasScrewdriver)
    {
        Debug.Log(hasScrewdriver);
    }

    public void ChangeGameState(bool isEnded)
    {
        Debug.Log(isEnded);
    }

    public void ChangeMatState(bool isHit)
    {
        Debug.Log(isHit);
    }

}