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
            foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
            { 
                BaseItem? item = ItemFactory.CreateItem(type);

                if (item == null)
                    continue;

                ItemLanguage korean = new ItemLanguage
                    (StringExtentions.KoreanStringInterpolation(item.name!, 12),
                    StringExtentions.KoreanStringInterpolation(item.explanation!, 50),
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

        
    }
}
