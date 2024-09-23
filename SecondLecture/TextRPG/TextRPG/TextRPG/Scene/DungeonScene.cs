using System.Text;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;

        public override void Load()
        {
            Thread.Sleep(1000);
            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        #region PrintFormat
        public static string restFormats =
@"휴식하기
 500 G 를 내면 체력을 회복할 수 있습니다. ";

        /// <summary>
        /// 던전 스크린 함수
        /// </summary>
        private void DungeonPrintScreen()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(restFormats);
            sb.Append(
@$"(보유 골드 : {GameManager.player!.gold} G)

1. 휴식하기
0. 나가기

");

            Print.PrintScreen(sb);
        }
        #endregion

    }

}
