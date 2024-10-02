namespace TextRPG
{
    public class SceneManager
    {
        private readonly Dictionary<SceneType, BaseScene> sceneDic = new Dictionary<SceneType, BaseScene>();//모든 씬들 저장해주는 Dictionary
        private Stack<SceneType> sceneDepthStack = new Stack<SceneType>();                                  //씬들 보여주는 DepthStack

        /// <summary>
        /// 생성 함수
        /// </summary>
        public void Init()
        {
            foreach (SceneType type in Enum.GetValues(typeof(SceneType)))
            {
                BaseScene? scene = SceneFactory.CreateScene(type);

                if (scene == null)
                    continue;

                sceneDic.Add(type, scene);
            }

            sceneDepthStack.Push(SceneType.Start);
        }

        /// <summary>
        /// 씬 로드해주는 함수
        /// </summary>
        public void LoadScene()
        {
            sceneDic[sceneDepthStack.Peek()].Load();
        }

        /// <summary>
        /// 씬들 열어주는 함수
        /// </summary>
        public void OpenScene(SceneType scene)
        {
            if (!sceneDic.TryGetValue(scene, out BaseScene? baseScene))
            {
                throw new IndexOutOfRangeException($"sceneDic[{scene}]");
            }

            if (baseScene as IMainScene != null)
            {
                sceneDepthStack.Clear();
            }

            sceneDepthStack.Push(scene);
        }

        /// <summary>
        /// 씬들 닫는 함수
        /// </summary>
        public void CloseScene()
        {
            if (sceneDic[sceneDepthStack.Peek()] as IMainScene != null)
            {
                throw new ArgumentNullException($"{sceneDepthStack.Peek()} is cannot IMainScene Casting");
            }

            sceneDepthStack.Pop();
        }
    }
}
