using UnityEngine;

public class CharcterAnimController : AnimController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private const float magnitutedThreshold = 0.5f;

    private void Start()
    {
        controller.MoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        anim.SetBool(isWalking, vector.magnitude > magnitutedThreshold);
    }
}
