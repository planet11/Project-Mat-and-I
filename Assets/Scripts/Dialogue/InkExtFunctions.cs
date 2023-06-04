using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExtFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("SetScrewdriver", (bool setScrewdriver) => SetScrewdriver(setScrewdriver));
        story.BindExternalFunction("SetHammer", (bool setHammer) => SetHammer(setHammer));
        story.BindExternalFunction("MatIsHit", (bool matIsHit) => MatIsHit(matIsHit));
    }

    //public void Unbind(Story story)
    //{
    //    story.UnbindExternalFunction("CircuitIsFixed");
    //}

    public void SetScrewdriver(bool setScrewdriver)
    {
        Debug.Log(setScrewdriver);
    }

    public void SetHammer(bool setHammer)
    {
        Debug.Log(setHammer);
    }

    public void MatIsHit(bool matIsHit)
    {
            Debug.Log("Mat is hit.");
    }

}
