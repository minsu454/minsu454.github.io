using System.Text.RegularExpressions;

namespace TextRPG
{
    public class ItemManager
    {
        private readonly Dictionary<ItemType, Tuple<BaseItem, EquipType>> itemDic = new Dictionary<ItemType, Tuple<BaseItem, EquipType>>();//모든 아이템 저장해주는 Dictionary

        /// <summary>
        /// 생성 함수
        /// </summary>
        public void Init()
        {
            for (int i = 1; i < Enum.GetValues(typeof(ItemType)).Length; i++)
            {
                ItemType type = (ItemType)i;
                BaseItem item = ItemFactory.CreateItem(type);

                ItemLanguage korean = new ItemLanguage
                    (KoreanStringInterpolation(item.name!, 12),
                    KoreanStringInterpolation(item.explanation!, 50),
                    ItemFactory.ItemStat(item.attack, item.defense),
                    item.gold.ToString());

                item.korean = korean;

                itemDic.Add(type, new Tuple<BaseItem, EquipType>(item, ItemFactory.GetEquipType(type)));
            }
        }

        /// <summary>
        /// BaseItem 반환해주는 함수
        /// </summary>
        public BaseItem GetBaseItem(ItemType type)
        {
            if (!itemDic.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException($"item is {type}");
            }
            return itemDic[type].Item1;
        }

        /// <summary>
        /// BaseItem 반환해주는 함수
        /// </summary>
        public EquipType GetEquipType(ItemType type)
        {
            if (!itemDic.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException($"item is {type}");
            }
            return itemDic[type].Item2;
        }

        /// <summary>
        /// Item 반환해주는 함수
        /// </summary>
        public Tuple<BaseItem, EquipType> GetItem(ItemType type)
        {
            if (!itemDic.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException($"item is {type}");
            }
            return itemDic[type];
        }

        /// <summary>
        /// 한국어 줄 정렬하는 함수
        /// </summary>
        private string KoreanStringInterpolation(string name, int count)
        {
            int length = name.Replace(" ", "").Length;
            length += Regex.Matches(name, "").Count;

            if (count < length)
                throw new OverflowException($"string nameLength * 2 : {length}, count");

            while (length != count)
            {
                name += " ";
                length++;
            }

            return name;
        }
    }
}
