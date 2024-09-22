namespace TextRPG
{
    public class LobbyScene : BaseScene
    {
        public override void Load()
        {
            Print.PrintScreen(lobbyFormat);
            int input = Input.InputKey(3);


        }

        #region PrintFormat
        private string lobbyFormat =
@$"{StartScene.startCommentFormats}이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점

";
        #endregion
    }
}

