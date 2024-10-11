using TMPro;
using UnityEngine.UI;

public class SetNamePopup : BasePopup
{
    private TMP_InputField inputName;

    public override void Init()
    {
        inputName = GetComponentInChildren<TMP_InputField>();
    }

    public override void Close()
    {
        Managers.Event.Dispatch(GameEventType.SetNewName, inputName.text);
        base.Close();
    }
}
