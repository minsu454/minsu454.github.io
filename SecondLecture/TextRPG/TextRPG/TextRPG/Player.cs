namespace TextRPG
{
    public class Player
    {
        public string name;         //플레이어 이름
        public int gold;            //플레이어 골드

        public BaseInfo info;       //플레이어 기본 정보

        public List<ItemType> getItemList = new List<ItemType>();       //가지고 있는 아이템 리스트
        public List<ItemType> equipItemList = new List<ItemType>();     //장착하고 있는 아이템 리스트

        public Player(string name, BaseInfo info)
        {
            this.name = name;
            this.info = info;

            equipItemList.Add(ItemType.None);
            equipItemList.Add(ItemType.None);

            gold = 10000;
        }

        public Player(int level, string name, BaseInfo info)
        {
            this.name = name;
            this.info = info;
        }

        /// <summary>
        /// 장착아이템 스텟 세팅해주는 함수
        /// </summary>
        public void SetItemStat()
        {
            info.itemAttack = 0;
            info.itemDefense = 0;

            for (int i = 0; i < equipItemList.Count; i++)
            {
                if (equipItemList[i] == ItemType.None)
                    continue;

                BaseItem item = GameManager.Item.GetBaseItem(equipItemList[i]);
                info.itemAttack += item.attack;
                info.itemDefense += item.defense;
            }
        }

        /// <summary>
        /// 체력 리셋시켜주는 함수
        /// </summary>
        public void ResetHp()
        {
            info.curHp = info.maxHp;
        }
    }
}
