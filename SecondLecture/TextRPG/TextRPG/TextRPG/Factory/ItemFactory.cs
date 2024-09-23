namespace TextRPG
{
    public static class ItemFactory
    {
        /// <summary>
        /// Item생성자 리턴해주는 함수
        /// </summary>
        public static BaseItem CreateItem(ItemType type)
        {
            BaseItem item;

            switch (type)
            {
                case ItemType.CommonArmor:
                    item = new CommonArmor();
                    break;
                case ItemType.RareArmor:
                    item = new RareArmor();
                    break;
                case ItemType.EpicArmor:
                    item = new EpicArmor();
                    break;
                case ItemType.LegendaryArmor:
                    item = new LegendaryArmor();
                    break;
                case ItemType.CommonSword:
                    item = new CommonSword();
                    break;
                case ItemType.RareSword:
                    item = new RareSword();
                    break;
                case ItemType.EpicSword:
                    item = new EpicSword();
                    break;
                case ItemType.LegendarySword:
                    item = new LegendarySword();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"item is {type}");
            }

            return item;
        }

        /// <summary>
        /// 아이템 이름 한국어로 리턴해주는 함수
        /// </summary>
        public static string ItemName(ItemType type)
        {
            string name;

            switch (type)
            {
                case ItemType.CommonArmor:
                    name = "일반 갑옷";
                    break;
                case ItemType.RareArmor:
                    name = "레어 갑옷";
                    break;
                case ItemType.EpicArmor:
                    name = "에픽 갑옷";
                    break;
                case ItemType.LegendaryArmor:
                    name = "레전드리 갑옷";
                    break;
                case ItemType.CommonSword:
                    name = "일반 검";
                    break;
                case ItemType.RareSword:
                    name = "레어 검";
                    break;
                case ItemType.EpicSword:
                    name = "에픽 검";
                    break;
                case ItemType.LegendarySword:
                    name = "레전드리 검";
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Item is {type}");
            }

            return name;
        }

        /// <summary>
        /// 아이템 스텟 한국어로 리턴해주는 함수
        /// </summary>
        public static string ItemStat(int attack, int defense)
        {
            string stat = "";

            if (attack != 0)
            {
                stat = $"공격력 +{attack,3}";
            }
            else if (defense != 0)
            {
                stat = $"방어력 +{defense,3}";
            }

            return stat;
        }

        public static EquipType GetEquipType(ItemType type)
        {
            switch (type)
            {
                case ItemType.CommonArmor:
                case ItemType.RareArmor:
                case ItemType.EpicArmor:
                case ItemType.LegendaryArmor:
                    return EquipType.Armor;
                case ItemType.CommonSword:
                case ItemType.RareSword:
                case ItemType.EpicSword:
                case ItemType.LegendarySword:
                    return EquipType.Sword;
            }

            return EquipType.None;
        }
    }
}
