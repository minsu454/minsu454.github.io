using System.Xml.Linq;
using DataTable;
using Microsoft.VisualBasic.FileIO;

namespace SaveXmlData
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isRun = true;

            Console.WriteLine("명령어를 보시려면 \"help\"를 입력해주세요 ");

            while (isRun)
            {
                string s = Console.ReadLine()!;

                switch (s)
                {
                    case "CREATE":
                    case "Create":
                    case "create":
                        Create();
                        break;
                    case "DELETE":
                    case "Delete":
                    case "delete":
                        Delete();
                        break;
                    case "RESET":
                    case "Reset":
                    case "reset":
                        Reset();
                        break;
                    case "HELP":
                    case "Help":
                    case "help":
                        Console.WriteLine("Create : xml 만들어해주는 명령어");
                        Console.WriteLine("Reset  : 저장된 xml리셋해주는 명령어");
                        Console.WriteLine("Reset  : 저장된 xml리셋해주는 명령어");
                        break;
                    case "BREAK":
                    case "Break":
                    case "break":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 명령어입니다. 다시 입력해주십시오.");
                        break;
                }
            }

        }

        /// <summary>
        /// xml파일 만들어주는 함수
        /// </summary>
        public static void Create()
        {
            if(File.Exists(Table.path))
            {
                Console.WriteLine("이미 파일이 존재합니다.");
                return;
            }

            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("Table"));

            XElement element = new XElement("SaveTable");
            var saveXml = Table.SaveTable.CreateXMLFile(element);

            xDocument.Root!.Add(saveXml);

            xDocument.Save(Table.path);

            Console.WriteLine("파일을 만들었습니다.");
        }

        /// <summary>
        /// xml파일 삭제해주는 함수
        /// </summary>
        public static void Delete()
        {
            if (!File.Exists(Table.path))
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
                return;
            }

            File.Delete(Table.path);
            Console.WriteLine("파일을 삭제했습니다.");
        }

        /// <summary>
        /// xml파일 리셋해주는 함수
        /// </summary>
        public static void Reset()
        {
            XDocument xDocument = new XDocument();

            try
            {
                xDocument = XDocument.Load(Table.path);
            }
            catch
            {
                Console.WriteLine("생성된 xml이 없습니다.");
                return;
            }

            Delete();
            Create();

            //Console.WriteLine("xml 데이터를 리셋했습니다.");
        }
    }
}
