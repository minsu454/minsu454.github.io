using System.Text;

namespace TextRPG
{
    public class PlayerInfoScene : BaseScene
    {
        public override void Load()
        {
            PlayerInfoPrintScreen();

            Input.InputKey(1, true);

            GameManager.Scene.CloseScene();
        }

        #region PrintFormat
        private string playerInfoFormat =
@$"상태 보기
캐릭터의 정보가 표시됩니다.

";

        /// <summary>
        /// 플레이어 정보 스크린 함수
        /// </summary>
        private void PlayerInfoPrintScreen()
        {
            StringBuilder sb = new StringBuilder();
            Player player = GameManager.player!;

            int attack = player.info.itemAttack;
            int defense = player.info.itemDefense;

            string itemAttack = attack != 0 ? $"(+{attack})" : "";
            string itemDefense = defense != 0 ? $"(+{defense})" : "";

            sb.Append(playerInfoFormat);
            sb.AppendLine(
@$"Lv {player.info.level}
{player.name} ({JobFactory.JobName(player.info.job)})
공격력 : {player.info.TotalAttack} {itemAttack}
방어력 : {player.info.TotalDefense} {itemDefense}
체 력 : {player.info.curHp}
경험치 : {player.info.curExp} / {player.info.maxExp}
Gold : {player.gold} G

0. 나가기
");

            Print.PrintScreen(sb);
        }
        #endregion
    }
}

