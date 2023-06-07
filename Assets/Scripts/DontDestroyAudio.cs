using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
  void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("bgm"); // find audio with tag
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
