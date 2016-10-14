using UnityEngine;
using System.Collections;

public class MovePlane : MonoBehaviour
{
    public float speed = 0.005f;
    public Vector2 direction = new Vector2(-1, 0);

    private Vector3 exitBorder;
    private SpriteRenderer spriteRenderer;
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Находим границы камеры в World Space координатах
        var dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        exitBorder = Vector3.zero;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                exitBorder.x = rightBorder;
            }
            else
            {
                exitBorder.x = leftBorder;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                exitBorder.y = topBorder;
            }
            else
            {
                exitBorder.y = bottomBorder;

            }
        }
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (exitBorder.y == 0)
        {
            if (Mathf.Abs(transform.position.x + spriteRenderer.sprite.bounds.extents.x) > Mathf.Abs(exitBorder.x))
                Destroy(gameObject);
        }
        else
        {
            if (Mathf.Abs(transform.position.y + spriteRenderer.sprite.bounds.extents.y) > Mathf.Abs(exitBorder.y))
                Destroy(gameObject);
        }
    }    
}