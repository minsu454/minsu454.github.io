using TMPro;
using UnityEngine;

public class NPCUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private InfoHandler infoHandler;

    private void Awake()
    {
        infoHandler = GetComponent<InfoHandler>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Start()
    {
        ShowName(infoHandler.SO.goName);
    }

    public void ShowName(object args)
    {
        text.text = args.ToString();
    }
}
