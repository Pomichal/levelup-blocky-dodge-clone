using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private bool horizontalPressed;
    private bool verticalPressed;

    void Update()
    {
        // TODO player movement (with arrow keys)

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

        // TODO: check
        transform.position += direction;
    }
}
