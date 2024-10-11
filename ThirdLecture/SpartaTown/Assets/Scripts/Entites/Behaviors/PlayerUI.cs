using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        ShowName(Managers.Data.Name);
        Managers.Event.Subscribe(GameEventType.SetNewName, ShowName);
    }

    public void ShowName(object args)
    {
        text.text = args.ToString();
    }

    public void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.SetNewName, ShowName);
    }
}
