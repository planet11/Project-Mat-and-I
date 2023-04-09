using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision happened!");
    }*/

    new Camera camera;
    PlayerMovement movement;
    public Interactable focus;

    void Start()
    {
        camera = Camera.main;
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("clicked");

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    Debug.Log("hit");
                    SetFocus(interactable);
                }
            }
        }
        if (movement.horizontal != 0)
        {
            RemoveFocus();
        }

    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus || newFocus != null)
        {
            focus.OnDefocused();
        }
        focus = newFocus;
        newFocus.OnFocused(transform);
        movement.FollowTarget(newFocus);

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        movement.StopFollowingTarget();
    }
}
