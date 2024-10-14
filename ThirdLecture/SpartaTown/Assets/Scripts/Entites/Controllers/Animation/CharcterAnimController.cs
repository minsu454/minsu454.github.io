using UnityEngine;

public class CharcterAnimController : AnimController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");     //Animator에 있는 isWalking변수의 해쉬 저장 변수
    private const float magnitutedThreshold = 0.5f;

    private void Start()
    {
        controller.MoveEvent += Move;

        anim.runtimeAnimatorController = Managers.Job.GetAnimator(Managers.Data.Job);
        Managers.Event.Subscribe(GameEventType.SetCharacter, ShowCharacter);
    }

    /// <summary>
    /// 캐릭터 바뀜으로 인해 애니메이터 재세팅해주는 함수
    /// </summary>
    private void ShowCharacter(object args)
    {
        anim.runtimeAnimatorController = Managers.Job.GetAnimator((JobType)args);
    }

    /// <summary>
    /// 움직임이 있으면 애니메이션 바꿔주는 함수
    /// </summary>
    private void Move(Vector2 vector)
    {
        anim.SetBool(isWalking, vector.magnitude > magnitutedThreshold);
    }

    private void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.SetCharacter, ShowCharacter);
    }
}
