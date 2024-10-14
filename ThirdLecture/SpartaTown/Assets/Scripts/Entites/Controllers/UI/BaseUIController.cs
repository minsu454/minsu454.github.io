using TMPro;
using UnityEngine;

public class BaseUIController : MonoBehaviour
{
    private TextMeshProUGUI entityNameTxt;

    protected virtual void Awake()
    {
        entityNameTxt = GetComponentInChildren<TextMeshProUGUI>();
    }
    /// <summary>
    /// 이름텍스트 변경해주는 함수
    /// </summary>
    public void ShowName(object args)
    {
        entityNameTxt.text = args.ToString();
    }
}
