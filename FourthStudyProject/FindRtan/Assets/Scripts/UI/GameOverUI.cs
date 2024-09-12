using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Image retryBtn;      //retry버튼

    private void OnEnable()
    {
        StartDoTween();
    }

    /// <summary>
    /// dotween실행 함수(color.a)
    /// </summary>
    private void StartDoTween()
    {
        DOTween.To(() => 0f, x => retryBtn.color = new Color(retryBtn.color.r, retryBtn.color.g, retryBtn.color.b, x), 1f, 1f)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
