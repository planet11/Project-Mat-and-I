using UnityEngine;

public class PillowTrigger : MonoBehaviour
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

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(mousePos, Vector2.down);
                if (hit.collider.name == "Pillow")
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }

    }
}
