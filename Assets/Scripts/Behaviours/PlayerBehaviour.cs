using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{

    public int score;
    public UnityEvent onScoreChanged = new UnityEvent();

    private bool horizontalPressed;
    private bool verticalPressed;

    private Rigidbody rb;

    private Vector2 startPosition;

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

        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector2 swipe = (Vector2)Input.mousePosition - startPosition;

            if(swipe.magnitude > 200)
            {
                float angle = Vector2.SignedAngle(Vector2.right, swipe);
                if(angle > 0 && angle < 90)
                {
                    Move(Vector3.right * 1.1f);
                }
                else if(angle > -180 && angle < -90)
                {
                    Move(-Vector3.right * 1.1f);
                }
                else if(angle > 90 && angle < 180)
                {
                    Move(Vector3.forward * 1.1f);
                }
                else if(angle < 0 && angle > -90)
                {
                    Move(-Vector3.forward * 1.1f);
                }
            }
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
        if(other.CompareTag("Obstacle"))
        {
            App.gameManager.GameOver();
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        onScoreChanged.Invoke();
    }
}
