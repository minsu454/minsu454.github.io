using System;

/// <summary>
/// player input잠구는 팝업
/// </summary>
public class BaseLockPopup : BasePopup
{
    public override void Init()
    {
        base.Init();
        Managers.Event.Dispatch(GameEventType.LockInput, false);
    }

    public override void Close()
    {
        Managers.Event.Dispatch(GameEventType.LockInput, true);
        base.Close();
    }
}
