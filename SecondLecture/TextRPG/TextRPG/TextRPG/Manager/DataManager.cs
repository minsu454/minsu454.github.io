using System.Xml.Linq;
using DataTable;

namespace TextRPG
{
    public class DataManager
    {
        private static Dictionary<Type, ITableData> dataDic = new Dictionary<Type, ITableData>();

        public void Init()
        {
            XDocument? xDocument = null;
            try
            {
                xDocument = XDocument.Load(Table.path);
            }
            catch
            {
                return;
            }

            if (xDocument.Root == null)
                return;

            for (int i = 0; i < Table.tableTypeArray.Length; i++)
            {
                Type type = Table.tableTypeArray[i];

                var elements = xDocument.Root.Elements(type.Name);
                var constructor = Table.tableConstructorDic[type];

                foreach (var element in elements)
                {
                    var data = constructor(element);
                    dataDic.Add(type, data);
                }
            }
        }

        public T LoadData<T>() where T : ITableData
        {
            return (T)dataDic[typeof(T)];
        }

        public void UpdateData<T>(T table) where T : ITableData
        {
            if (!dataDic.ContainsKey(typeof(T)))
            {
                return;
            }

            dataDic[typeof(T)] = table;

            XDocument xDocument = new XDocument();
            xDocument = XDocument.Load(Table.path);
            
            table.SaveXmlFile(xDocument);
        }
    }
}
