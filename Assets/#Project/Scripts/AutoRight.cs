
using Unity.VisualScripting;
using UnityEngine;

public class AutoRight : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void Start()
    {
    }
    void Update()
    {
        AutoRightMove();
    }

    void AutoRightMove()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
        
    }
}
