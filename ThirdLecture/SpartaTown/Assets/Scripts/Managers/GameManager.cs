using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private Transform player;

    public Transform Player { get { return player; } } 

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Managers.Popup.CreatePopup(PopupType.LobbyMain);
    }
}
