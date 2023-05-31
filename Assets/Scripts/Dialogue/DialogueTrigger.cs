using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerInRange;
    Camera cam;
    public LayerMask mask;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Awake()
    {
        playerInRange = false;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerInRange = true;
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Input.mousePosition;
                mousePos = cam.ScreenToWorldPoint(mousePos);

                RaycastHit2D hit;
                hit = Physics2D.Raycast(mousePos, Vector2.down);
                if (hit.collider.name == name)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
            }
        }
    }
}