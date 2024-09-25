using DataTable;
using System.Reflection.Emit;
using System.Xml.Linq;

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

        public Player(Table.SaveTable table)
        {
            info = JobFactory.CreateInfo((JobType)table.jobType);

            name = table.name;
            info.level = table.level;
            gold = table.gold;
            info.curExp = table.exp;
            info.curHp = table.hp;

            int[] arr = Array.ConvertAll(table.getItemList.Trim().Split(" "), int.Parse);
            if (arr[0] != 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    getItemList.Add((ItemType)arr[i]);
                }
            }

            arr = Array.ConvertAll(table.equipItemList.Trim().Split(" "), int.Parse);
            for (int i = 0; i < arr.Length; i++)
            {
                equipItemList.Add((ItemType)arr[i]);
            }

            SetItemStat();
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

        /// <summary>
        /// 플레이어데이터 파싱해주는 함수
        /// </summary>
        public Table.SaveTable Parsing()
        {
            var table = GameManager.Data.LoadData<Table.SaveTable>();

            table.name = name;
            table.jobType = (int)info.job;
            table.level = info.level;
            table.gold = gold;
            table.exp = info.curExp;
            table.hp = info.curHp;

            string s = "";

            if (getItemList.Count != 0)
            {
                for (int i = 0; i < getItemList.Count; i++)
                {
                    s += $"{(int)getItemList[i]} ";
                }
                table.getItemList = s;
            }

            s = "";

            for (int i = 0; i < equipItemList.Count; i++)
            {
                s += $"{(int)equipItemList[i]} ";
            }
            table.equipItemList = s;

            return table;
        }
    }
}
