using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    public class StoreScene : BaseScene
    {
        public override void Load()
        {
            SeeStore();

            GameManager.Scene.CloseScene();
        }

        /// <summary>
        /// 태초 상점 함수
        /// </summary>
        private void SeeStore()
        {
            int input = -1;
            
            StorePrintScreen();
            input = Input.InputKey(2, true);

            if (input == 0)
                return;

            SeeBuy();
        }

        /// <summary>
        /// 구매창 함수
        /// </summary>
        private void SeeBuy()
        {
            int input = -1;
            int itemLength = Enum.GetValues(typeof(ItemType)).Length;

            while (input != 0)
            {
                Console.Clear();
                StorePrintScreen(true);
                input = Input.InputKey(itemLength, true);
                BuyItem((ItemType)input);
            }
        }

        /// <summary>
        /// 구매 해주는 함수
        /// </summary>
        private void BuyItem(ItemType type)
        {
            if (type == ItemType.None)
                return;

            if (GameManager.player!.getItemList.Contains(type))
            {
                Print.PrintScreenAndSleep("이미 구매한 아이템입니다.");
                return;
            }

            BaseItem item = GameManager.Item.GetBaseItem(type);
            Player player = GameManager.player;

            if (item.gold > player.gold)
            {
                Print.PrintScreenAndSleep("Gold 가 부족합니다.");
                return;
            }

            player.gold -= item.gold;
            player.getItemList.Add(type);
            Print.PrintScreenAndSleep("구매를 완료되었습니다.");
        }

        #region PrintFormat
        private string storeFormat =
@$"상점
필요한 아이템을 얻을 수 있는 상점입니다.

";
        private string storeChoiceFormat =
@"1. 아이템 구매
0. 나가기
";
        private string buyChoiceFormat =
@"0. 나가기
";

        /// <summary>
        /// 메인 스크린 함수
        /// </summary>
        private void StorePrintScreen(bool seeIndex = false)
        {
            StringBuilder sb = new StringBuilder();
            Player player = GameManager.player!;

            sb.Append(storeFormat);
            sb.AppendLine(
@$"[보유 골드]
{player.gold} G

[아이템 목록]
");
            for (int i = 1; i < Enum.GetValues(typeof(ItemType)).Length; i++)
            {
                ItemType type = (ItemType)i;

                BaseItem item = GameManager.Item.GetBaseItem(type);
                ItemLanguage korean = item.korean;

                string isHaveItem = (GameManager.player!.getItemList.Contains(type)) ? "구매완료" : $"{korean.gold}";
                string idx = seeIndex ? $"{i}" : "";

                sb.AppendLine($"- {idx} {korean.name} | {korean.stats} | {korean.explanation} | {isHaveItem} G");
            }

            sb.AppendLine();
            sb.Append(seeIndex ? buyChoiceFormat : storeChoiceFormat);
            sb.AppendLine();

            Print.PrintScreen(sb);
        }
        #endregion
    }
}
