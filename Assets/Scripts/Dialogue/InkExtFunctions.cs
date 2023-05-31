using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExtFunctions
{
    public bool screwdriverIsSet = false;
    public bool hammerIsSet = false;
    public bool matIsHit = false;
    public void Bind(Story story)
    {
        story.BindExternalFunction("SetScrewdriver", (bool setScrewdriver) => SetScrewdriver(setScrewdriver));
        story.BindExternalFunction("SetHammer", (bool setHammer) => SetHammer(setHammer));
        story.BindExternalFunction("MatIsHit", (bool isHit) => MatIsHit(matIsHit));
    }

    //public void Unbind(Story story)
    //{
    //    story.UnbindExternalFunction("CircuitIsFixed");
    //}

    public void SetScrewdriver(bool setScrewdriver)
    {
        Debug.Log(setScrewdriver);
        screwdriverIsSet = setScrewdriver;
    }

    public void SetHammer(bool setHammer)
    {
        Debug.Log(setHammer);
        hammerIsSet = setHammer;
    }

    public void MatIsHit(bool isHit)
    {
        Debug.Log("Mat is hit.");
        matIsHit = isHit;
    }

}
