using System;
using System.Text;

namespace TextRPG
{
    public class InventoryScene : BaseScene
    {
        public override void Load()
        {
            Inventory();
            GameManager.player!.SetItemStat();

            GameManager.Scene.CloseScene();
        }

        /// <summary>
        /// 태초에 인벤토리 함수
        /// </summary>
        private void Inventory()
        {
            int input = -1;

            InventoryPrintScreen();
            input = Input.InputKey(2, true);

            if (input == 0)
                return;

            SeeEquip();
        }

        /// <summary>
        /// 장착 설정 함수
        /// </summary>
        private void SeeEquip()
        {
            int input = -1;
            int itemLength = GameManager.player!.getItemList.Count;

            while (true)
            {
                Console.Clear();
                InventoryPrintScreen(true);
                input = Input.InputKey(itemLength, true);

                if (input == 0)
                    break;

                ChangeEquip(GameManager.player!.getItemList[input - 1]);
            }
        }

        /// <summary>
        /// 장착 해주는 함수
        /// </summary>
        private void ChangeEquip(ItemType type)
        {
            if (type == ItemType.None)
                return;

            EquipType equipType = GameManager.Item.GetEquipType(type);

            GameManager.player!.equipItemList[(int)equipType - 1] = type;
        }

        #region PrintFormat
        private string inventoryFormat =
@$"인벤토리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]

";

        private string inventoryEquipFormat =
@$"인벤토리 - 장착 관리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]

";

        private string inventoryChoiceFormat =
@"1. 장착 관리
0. 나가기
";

        private string equipChoiceFormat =
@"0. 나가기
";

        /// <summary>
        /// 메인 스크린 함수
        /// </summary>
        private void InventoryPrintScreen(bool seeIndex = false)
        {
            StringBuilder sb = new StringBuilder();

            Player player = GameManager.player!;

            sb.Append(seeIndex ? inventoryEquipFormat : inventoryFormat);
            int i = 1;

            foreach (var type in player.getItemList)
            {
                var item = GameManager.Item.GetItem(type);
                ItemLanguage korean = item.Item1.korean;

                string equip = player!.equipItemList[(int)item.Item2 - 1] == type ? "[E]" : "   ";
                string index = seeIndex ? $"{i++}" : "";

                sb.AppendLine($"- {index} {equip} {korean.name} | {korean.stats} | {korean.explanation}");
            }

            sb.AppendLine();
            sb.Append(seeIndex ? equipChoiceFormat : inventoryChoiceFormat);
            sb.AppendLine();

            Print.PrintScreen(sb);
        }
        #endregion
    }
}
