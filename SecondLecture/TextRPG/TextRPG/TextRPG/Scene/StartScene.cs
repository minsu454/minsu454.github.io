using System.Text;

namespace TextRPG
{
    public class StartScene : BaseScene
    {
        public override void Load()
        {
            string name = InputName();

            Console.Clear();

            JobPrintScreen();
            JobType job = (JobType)Input.InputKey(Enum.GetValues(typeof(JobType)).Length);

            GameManager.player = new Player(name, JobFactory.CreateInfo(job));

            GameManager.scene.NextScene(SceneType.Lobby);
        }

        #region PrintFormat
        public static string startCommentFormats =
@"스파르타 던전에 오신 여러분 환영합니다.
";

        private string setNameCommentFormats =
@"원하시는 이름을 설정해주세요.

";

        private string setNameChoiceCommentFormats =
@"1. 저장
2. 취소

";

        private string startSetJobCommentFormats =
@"원하시는 직업을 설정해주세요.

";

        private string InputName()
        {
            string name;
            int input;
            while (true)
            {
                Console.Clear();

                Print.PrintScreen(startCommentFormats + setNameCommentFormats);

                name = Console.ReadLine()!;
                Console.WriteLine();

                if (name == null)
                {
                    Print.PrintScreen(Input.inputErrorFormats);
                    continue;
                }

                Print.PrintScreen(setNameChoiceCommentFormats);

                input = Input.InputKey(2);

                if (input == 1)
                {
                    break;
                }
            }

            return name;
        }

        private void JobPrintScreen()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(startCommentFormats);
            sb.Append(startSetJobCommentFormats);

            for (int i = 1; i < Enum.GetValues(typeof(JobType)).Length; i++)
            {
                sb.AppendLine($"{i}. {JobFactory.JobName((JobType)i)}");
            }

            sb.AppendLine();

            Print.PrintScreen(sb);
        }
        #endregion
    }
}
