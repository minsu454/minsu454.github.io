using TMPro;
using UnityEngine;

public class NPCUI : BaseUIController
{  
    private InfoHandler infoHandler;        //npc 기본정보

    protected override void Awake()
    {
        base.Awake();
        infoHandler = GetComponent<InfoHandler>();
    }

    public void Start()
    {
        ShowName(infoHandler.SO.goName);
    }
}
