using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool isFocus = false;
    Transform player;

    void Update()
    {
        if (isFocus)
        {
            print("IsFocus");
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
    }

}
