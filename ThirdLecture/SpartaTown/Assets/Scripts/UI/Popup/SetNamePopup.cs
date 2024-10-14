using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetNamePopup : BaseLockPopup
{
    [SerializeField] private Image characterImage;      //현재 캐릭터 이미지 띄워줄 변수
    private TMP_InputField inputName;                   //현재 내 이름 띄워줄 변수

    public override void Init()
    {
        base.Init();

        inputName = GetComponentInChildren<TMP_InputField>();
        characterImage.sprite = Managers.Job.GetSprite(Managers.Data.Job);
    }

    /// <summary>
    /// 캐릭터 선택 팝업 띄워주는 함수
    /// </summary>
    public void ChoiceCharacterPopup()
    {
        Managers.Popup.CreatePopup(PopupType.SetCharacter);
    }

    public override void Close()
    {
        if (inputName.text.Length < 2)
        {
            return;
        }

        Managers.Event.Dispatch(GameEventType.SetNewName, inputName.text);
        base.Close();
    }
}
