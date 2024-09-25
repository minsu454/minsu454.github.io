using static DataTable.Table;
using System.Xml.Linq;

namespace DataTable
{
    public interface ITableData
    {
        public int ID { get; }
        public void SaveXMLFile(XDocument xml);
    }
}
