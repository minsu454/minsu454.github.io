using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtanOnComplete : MonoBehaviour
{
    /// <summary>
    /// Rtan1 애니메이션 완료시 호출하는 함수
    /// </summary>
    public void Rtan1AnimOnComplete()
    {
        TitleManager.Instance.StartSceneUI(false);
        TitleManager.Instance.rtan1Anim.SetBool("isMove", false);
    }

    /// <summary>
    /// Rtan2 애니메이션 완료시 호출하는 함수
    /// </summary>
    public void Rtan2ANimOnComplete()
    {
        TitleManager.Instance.StartSceneUI(true);
        TitleManager.Instance.rtan2Anim.SetBool("isMove", false);
    }
}
