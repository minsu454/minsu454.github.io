using DataTable;
using System.Text;
using System.Xml.Linq;

namespace TextRPG
{
    public class StartScene : BaseScene, IMainScene
    {
        private int shiftCount = 0;

        public override void Load()
        {
            bool isSave = GameManager.Data.LoadData<Table.SaveTable>().name != "" ? true : false;

            if (isSave) LoadID();
            else CreateID();

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        /// <summary>
        /// 아이디 생성 함수
        /// </summary>
        public void CreateID()
        {
            string name = InputName();

            Console.Clear();

            JobPrintScreen();
            JobType job = (JobType)Input.InputKey(Enum.GetValues(typeof(JobType)).Length);

            GameManager.player = new Player(name, JobFactory.CreateInfo(job));

            GameManager.Data.UpdateData(GameManager.player.Parsing());
        }

        /// <summary>
        /// 아이디 불러오는 함수
        /// </summary>
        public void LoadID()
        {
            LoadPrintScreen();
            int input = Input.InputKey(2);

            if (input == 1)
            {
                GameManager.player = new Player(GameManager.Data.LoadData<Table.SaveTable>());
            }
            else
            {
                Console.Clear();
                CreateID();
            }
        }

        #region PrintFormat
        public static string startCommentFormat =
@"스파르타 던전에 오신 여러분 환영합니다.
";
        private string setNameCommentFormat =
@"원하시는 이름을 설정해주세요.

";
        private string setNameChoiceCommentFormat =
@"1. 저장
2. 취소

";
        private string startSetJobCommentFormat =
@"원하시는 직업을 설정해주세요.

";
        private string LoadCommentFormat = 
@"저장된 데이터가 있습니다. 불러오시겠습니까?

1. 네
2. 아니오

";

        /// <summary>
        /// 이름 입력하는 함수
        /// </summary>
        private string InputName()
        {
            string name;
            int input;
            while (true)
            {
                Console.Clear();

                Print.PrintScreen(startCommentFormat + setNameCommentFormat);

                name = Console.ReadLine()!;
                Console.WriteLine();

                if (name == null)
                {
                    Print.PrintScreen(Input.inputErrorFormats);
                    continue;
                }

                Print.PrintScreen(setNameChoiceCommentFormat);

                input = Input.InputKey(2);

                if (input == 1)
                {
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// 직업 설정 스크린 함수
        /// </summary>
        private void JobPrintScreen()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(startCommentFormat);
            sb.Append(startSetJobCommentFormat);

            for (int i = 1; i < Enum.GetValues(typeof(JobType)).Length; i++)
            {
                sb.AppendLine($"{i}. {JobFactory.JobName((JobType)i)}");
            }

            sb.AppendLine();

            Print.PrintScreen(sb);
        }

        private void LoadPrintScreen()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(startCommentFormat + LoadCommentFormat);

            Print.PrintScreen(sb);
        }
        #endregion
    }
}
