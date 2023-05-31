using UnityEngine;
using Ink.Runtime;

public class DialogueBase : MonoBehaviour
{
    //[SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextAsset inkAsset;

    protected VariablesState dialogueVariables;

    private bool playerInRange;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    protected virtual void OnMouseUp()
    {
        if (playerInRange && !InkDialogueManager.instance.dialogueIsPlaying)
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit;
            hit = Physics2D.Raycast(mousePos, Vector2.down);
            if (hit.collider.name == name)
                InkDialogueManager.instance.EnterDialogue(this);
        }
    }

    public TextAsset GetDialogueAsset()
    {
        return inkAsset;
    }

    public VariablesState GetVariables()
    {
        return dialogueVariables;
    }

    public virtual void UpdateVariablesState(VariablesState variables)
    {
        dialogueVariables = variables;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
