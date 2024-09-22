using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class SceneManager
    {
        private Dictionary<SceneType, BaseScene> sceneDic = new Dictionary<SceneType, BaseScene>();

        private SceneType curScene;

        public void Init()
        {
            for (int i = 1; i < Enum.GetValues(typeof(SceneType)).Length; i++)
            {
                SceneType type = (SceneType)i;
                BaseScene scene = SceneFactory.CreateScene(type);

                sceneDic.Add(type, scene);
            }

            curScene = SceneType.Start;
        }

        public void LoadScene()
        {
            sceneDic[curScene].Load();
        }

        public void NextScene(SceneType curScene)
        {
            this.curScene = curScene;
        }
    }
}
