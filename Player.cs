using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.1f;
    private bool isColliding = false;

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0f, zDirection);
        transform.position += moveDirection * speed;
        if (xDirection != 0)
        {
            // Flip sprite based on direction
            if (xDirection > 0)
            {
                // Moving right
                transform.localScale = new Vector3(1f, 1f, 1f); // Original scale
            }
            else
            {
                // Moving left
                transform.localScale = new Vector3(-1f, 1f, 1f); // Flip in the X-axis
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!isColliding)
            {
                StartCoroutine(FlashRed());
            }
        }
    }

    IEnumerator FlashRed()
    {
        isColliding = true;

      
        GetComponent<SpriteRenderer>().color = Color.red;

       
        yield return new WaitForSeconds(0.2f);

       
        GetComponent<SpriteRenderer>().color = Color.white;

        isColliding = false;
    }
}
