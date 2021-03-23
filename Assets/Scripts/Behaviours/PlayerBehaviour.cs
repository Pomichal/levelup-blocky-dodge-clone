using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{

    public int score;
    public UnityEvent onScoreChanged = new UnityEvent();

    private bool horizontalPressed;
    private bool verticalPressed;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if(hor != 0 && !horizontalPressed)
        {
            Move(Vector3.right * 1.1f * hor);
            horizontalPressed = true;
        }

        if(hor == 0)
        {
            horizontalPressed = false;
        }

        if(ver != 0 && !verticalPressed)
        {
            Move(Vector3.forward * 1.1f * ver);
            verticalPressed = true;
        }
        if(ver == 0)
        {
            verticalPressed = false;
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction;

        float extreme = (int)(App.gameManager.gridSize / 2) * 1.1f;

        if(Mathf.Abs(newPosition.x) > extreme || Mathf.Abs(newPosition.z) > extreme)
        {
            return;
        }

        rb.MovePosition(transform.position + direction);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            ChangeScore(1);
            Destroy(other.gameObject);
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        onScoreChanged.Invoke();
    }
}
