using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Image retryBtn;

    private void OnEnable()
    {
        DOTween.To(() => 0f, x => retryBtn.color = new Color(retryBtn.color.r, retryBtn.color.g, retryBtn.color.b, x), 1f, 1f)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
