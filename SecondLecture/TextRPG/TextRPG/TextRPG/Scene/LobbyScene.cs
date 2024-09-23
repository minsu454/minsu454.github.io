namespace TextRPG
{
    public class LobbyScene : BaseScene, IMainScene
    {
        private int shiftCount;

        protected override void Init()
        {
            shiftCount = 1;
        }

        public override void Load()
        {
            Print.PrintScreen(lobbyFormat);
            int input = Input.InputKey(5);

            GameManager.Scene.OpenScene((SceneType)(1 << input + shiftCount));
        }

        #region PrintFormat
        private string lobbyFormat =
@$"{StartScene.startCommentFormats}이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점
4. 던전입장
5. 휴식하기

";
        #endregion
    }
}

