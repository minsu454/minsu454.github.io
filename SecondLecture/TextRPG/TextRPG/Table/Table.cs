using System.Xml.Linq;

namespace DataTable
{
    public class Table
    {
        public static readonly Dictionary<Type, Func<XElement, ITableData>> tableConstructorDic;
        public static readonly Type[] tableTypeArray;

        public static readonly string path = "../../../../Save/Table.xml";

        static Table()
        {
            tableTypeArray = new Type[]
            {
                typeof(SaveTable),
            };

            tableConstructorDic = new Dictionary<Type, Func<XElement, ITableData>>()
            {
                [typeof(SaveTable)] = (xml) => new SaveTable(xml),
            };
        }

        public class SaveTable : ITableData
        {
            public int ID { get { return id; } }

            public int id;
            public string name;
            public int jobType;
            public int level;
            public int gold;
            public int exp;
            public int hp;
            public string getItemList;
            public string equipItemList;

            public SaveTable(XElement xml)
            {
                id = int.Parse(xml.Attribute("Id")!.Value);
                name = xml.Attribute("Name")!.Value;
                jobType = int.Parse(xml.Attribute("JobType")!.Value);
                level = int.Parse(xml.Attribute("Level")!.Value);
                gold = int.Parse(xml.Attribute("Gold")!.Value);
                exp = int.Parse(xml.Attribute("Exp")!.Value);
                hp = int.Parse(xml.Attribute("Hp")!.Value);
                getItemList = xml.Attribute("getItemList")!.Value.Trim();
                equipItemList = xml.Attribute("equipItemList")!.Value.Trim();
            }

            public static XElement CreateXMLFile(XElement xml)
            {
                XElement file = xml;

                file.Add(new XAttribute("Id", 0));
                file.Add(new XAttribute("Name", ""));
                file.Add(new XAttribute("JobType", 0));
                file.Add(new XAttribute("Level", 1));
                file.Add(new XAttribute("Gold", 0));
                file.Add(new XAttribute("Exp", 0));
                file.Add(new XAttribute("Hp", 100));
                file.Add(new XAttribute("getItemList", "0 "));
                file.Add(new XAttribute("equipItemList", "0 0 "));

                return file;
            }

            public void SaveXMLFile(XDocument xml)
            {
                XElement element = xml.Root!.Element("SaveTable")!;

                element.Attribute("Id")!.Value = id.ToString();
                element.Attribute("Name")!.Value = name.ToString();
                element.Attribute("JobType")!.Value = jobType.ToString();
                element.Attribute("Level")!.Value = level.ToString();
                element.Attribute("Gold")!.Value = gold.ToString();
                element.Attribute("Exp")!.Value = exp.ToString();
                element.Attribute("Hp")!.Value = hp.ToString();
                element.Attribute("getItemList")!.Value = getItemList.ToString();
                element.Attribute("equipItemList")!.Value = equipItemList.ToString();

                xml.Save(path);
            }
        }
    }

    public static class Utility
    {
        public static void SaveXmlFile<T>(this T table, XDocument xml) where T : ITableData
        {
            table.SaveXMLFile(xml);
        }
    }
}
