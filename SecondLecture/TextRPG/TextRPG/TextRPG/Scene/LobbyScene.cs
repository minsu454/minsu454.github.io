using DataTable;

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
            int input = Input.InputKey(6, true);

            if (input == 0)
            {
                GameManager.Data.UpdateData(GameManager.player!.Parsing());
                Print.PrintScreenAndSleep("\n저장되었습니다!");

                return;
            }

            GameManager.Scene.OpenScene((SceneType)(1 << input + shiftCount));
        }

        #region PrintFormat
        private string lobbyFormat =
@$"{StartScene.startCommentFormat}이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점
4. 던전입장
5. 휴식하기
0. 저장하기

";
        #endregion
    }
}

