using System.Text;

namespace TextRPG
{
    public class RestScene : BaseScene
    {
        public override void Load()
        {
            RestPrintScreen();
            Input.InputKey(2, true);

            Print.PrintScreenAndSleep("\n한숨 쉬었더니 몸에 있는 상처들이 아물었습니다.");

            GameManager.player!.ResetHp();
            GameManager.Scene.CloseScene();
        }

        #region PrintFormat
        public static string restFormats =
@"휴식하기
 500 G 를 내면 체력을 회복할 수 있습니다. ";

        /// <summary>
        /// 던전 스크린 함수
        /// </summary>
        private void RestPrintScreen()
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