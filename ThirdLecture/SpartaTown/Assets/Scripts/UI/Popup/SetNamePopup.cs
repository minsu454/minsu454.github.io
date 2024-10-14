using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetNamePopup : BaseLockPopup
{
    [SerializeField] private Image characterImage;
    private TMP_InputField inputName;

    public override void Init()
    {
        base.Init();

        inputName = GetComponentInChildren<TMP_InputField>();
        characterImage.sprite = Managers.Job.GetSprite(Managers.Data.Job);
    }

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
