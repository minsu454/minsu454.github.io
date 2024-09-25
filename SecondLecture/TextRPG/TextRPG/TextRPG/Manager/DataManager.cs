using System.Xml.Linq;
using DataTable;

namespace TextRPG
{
    public class DataManager
    {
        //데이터 저장하는 Dictionary
        private static Dictionary<Type, ITableData> dataDic = new Dictionary<Type, ITableData>();

        /// <summary>
        /// 생성 함수
        /// </summary>
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

        /// <summary>
        /// 데이터 로드해주는 함수
        /// </summary>
        public T LoadData<T>() where T : ITableData
        {
            return (T)dataDic[typeof(T)];
        }

        /// <summary>
        /// 데이터 업데이트해주는 함수
        /// </summary>
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
