
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class AutoRight : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        AutoRightMove();
        InvertAtEnd();
        CheckCollision();

    }

    void AutoRightMove()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
        
    }

    void InvertAtEnd()
    {
        Vector2 point ;

        if (speed > 0 ){
            point = new(col.bounds.max.x + 0.01f, col.bounds.min.y);
        }
        else
        {
            point = new(col.bounds.min.x - 0.01f, col.bounds.min.y);
        }
        // Debug.DrawRay(origine, direction, Color.purple); // pour voir le vecteur
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, 0.05f);

        if (hit.collider == null)
        {
            speed = speed * -1;       
        }
    }
    private void CheckCollision()
    {

        Vector2 pointCheckOther;
        Vector2 direction;

        if (speed > 0)
        {
            pointCheckOther = new(col.bounds.max.x + 0.01f, col.bounds.min.y + 0.01f);
            direction = Vector2.right;
        }
        else
        {
            pointCheckOther = new(col.bounds.min.x - 0.01f, col.bounds.min.y + 0.01f);
            direction = Vector2.left;
        }

        Debug.DrawRay(pointCheckOther, direction * 0.01f, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(pointCheckOther, direction, 0.01f);
        if (hit.collider != null)
        {
            speed *= -1;
        }
    }

}
