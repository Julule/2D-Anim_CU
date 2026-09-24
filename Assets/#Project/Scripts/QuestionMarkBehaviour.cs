using UnityEngine;

public class QuestionMarkBehaviour : MonoBehaviour
{
    private const string ANIMATION_ROTATE = "Rotate";
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bing");
        bool rotate = !animator.GetBool(ANIMATION_ROTATE); // on inverse l'état de l'animation
        animator.SetBool(ANIMATION_ROTATE, rotate);
    }
}
