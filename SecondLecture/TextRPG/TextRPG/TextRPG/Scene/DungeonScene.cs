﻿using System.Numerics;
using System.Text;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;

        public override void Load()
        {

            DungeonPrintScreen();
            int input = Input.InputKey(4, true);

            if (input != 0) InDungeon((DunGeonType)input);

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        public void InDungeon(DunGeonType type)
        {
            GameManager.DunGeon.InDunGeon(type, out bool isClear, out int minusHp, out int clearGold);
            Console.Clear();

            if (isClear)
            {
                ClearPrintScreen(type, minusHp, clearGold);
            }
            else
            {
                FailPrintScreen(type, minusHp);
            }

            Input.InputKey(1, true);
        }

        #region PrintFormat
        private string dunGeonFormat =
@$"던전입장
이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

";
        private string clearFormat =
@"던전 클리어
축하합니다!!
";
        private string failFormat =
@"던전 실패
아쉽습니다..
";

        /// <summary>
        /// 던전 스크린 함수
        /// </summary>
        private void DungeonPrintScreen()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(dunGeonFormat);
            
            for (int i = 1; i < Enum.GetValues(typeof(DunGeonType)).Length; i++)
            {
                BaseDunGeon dungeon = GameManager.DunGeon.GetDunGeon((DunGeonType)i);
                sb.AppendLine($"{i}. {dungeon.name} | 방어력 {dungeon.recommendDefense.ToString("D2")} 이상 권장");
            }

            sb.AppendLine("\n0. 나가기\n");

            Print.PrintScreen(sb);
        }

        private void ClearPrintScreen(DunGeonType type, int minusHp, int clearGold)
        {
            StringBuilder sb = new StringBuilder();
            Player player = GameManager.player!;

            int curhp = player.info.curHp - minusHp;

            GameOver(curhp);

            sb.Append(clearFormat);
            sb.Append(
$@"{GameManager.DunGeon.GetDunGeon(type).name}을 클리어 하였습니다.

[탐험 결과]
체력 {player.info.curHp} -> {curhp}
Gold {player.gold} G -> {player.gold + clearGold}");

            sb.AppendLine("\n0. 나가기\n");

            player.info.curHp = curhp;
            player.gold += clearGold;

            Print.PrintScreen(sb);
        }

        private void FailPrintScreen(DunGeonType type, int minusHp)
        {
            StringBuilder sb = new StringBuilder();
            Player player = GameManager.player!;

            int curhp = player.info.curHp - minusHp;

            GameOver(curhp);

            sb.Append(failFormat);
            sb.Append(
$@"{GameManager.DunGeon.GetDunGeon(type).name}을 클리어 실패하였습니다.

[탐험 결과]
체력 {player.info.curHp} -> {curhp}
");

            sb.AppendLine("\n0. 나가기\n");

            player.info.curHp = curhp;

            Print.PrintScreen(sb);
        }

        private void GameOver(int curhp)
        {
            if (0 >= curhp)
            {
                while (true)
                {
                    Print.PrintScreenAndSleep("\nGameOver");
                }
                
            }
        }
        #endregion

    }

}
