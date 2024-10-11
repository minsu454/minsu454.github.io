using UnityEngine;

public class CharcterAnimController : AnimController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private const float magnitutedThreshold = 0.5f;

    private void Start()
    {
        controller.MoveEvent += Move;

        anim.runtimeAnimatorController = Managers.Job.GetAnimator(Managers.Data.job);
        Managers.Event.Subscribe(GameEventType.SetCharacter, ShowCharacter);
    }

    private void ShowCharacter(object args)
    {
        anim.runtimeAnimatorController = Managers.Job.GetAnimator((JobType)args);
    }

    private void Move(Vector2 vector)
    {
        anim.SetBool(isWalking, vector.magnitude > magnitutedThreshold);
    }

    private void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.SetCharacter, ShowCharacter);
    }
}
