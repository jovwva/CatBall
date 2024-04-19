using UnityEngine;

public class PlatfomBoom : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const string BOOM_KEY = "Boom";

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayAmim();
    }

    private void PlayAmim() => animator.SetTrigger(BOOM_KEY);
}
