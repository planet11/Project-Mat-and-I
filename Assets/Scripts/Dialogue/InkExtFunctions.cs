using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExtFunctions
{
    public void Bind(Story story, Animator anim)
    {
        story.BindExternalFunction("SetScrewdriver", (bool setScrewdriver) => SetScrewdriver(setScrewdriver));
        story.BindExternalFunction("SetHammer", (bool setHammer) => SetHammer(setHammer));
        story.BindExternalFunction("MatIsHit", (bool matIsHit) => MatIsHit(matIsHit,anim));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("CircuitIsFixed");
    }

    public void SetScrewdriver(bool setScrewdriver)
    {
        Debug.Log(setScrewdriver);
    }

    public void SetHammer(bool setHammer)
    {
        Debug.Log(setHammer);
    }

    public void MatIsHit(bool matIsHit, Animator anim)
    {
        if (matIsHit && anim != null)
        {
            Debug.Log("Mat is hit.");
            anim.enabled = false;
        }
    }

}
