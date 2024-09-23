namespace TextRPG
{
    public class Player
    {
        public string name;         //플레이어 이름
        public int gold;            //플레이어 골드

        public BaseInfo info;       //플레이어 기본 정보

        public List<ItemType> getItemList = new List<ItemType>();
        public List<ItemType> equipItemList = new List<ItemType>();

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

        public void SetItemStat()
        {
            for (int i = 0; i < equipItemList.Count; i++)
            {
                if (equipItemList[i] == ItemType.None)
                    continue;

                BaseItem item = GameManager.Item.GetBaseItem(equipItemList[i]);
                info.itemAttack = item.attack;
                info.itemDefense = item.defense;
            }
        }
    }
}
