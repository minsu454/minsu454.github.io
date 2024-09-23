namespace TextRPG
{
    public class BaseScene
    {
        public BaseScene()
        {
            Init();
        }

        protected virtual void Init() { }
        public virtual void Load() {}
    }
}
