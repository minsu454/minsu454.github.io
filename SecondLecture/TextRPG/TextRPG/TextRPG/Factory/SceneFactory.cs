namespace TextRPG
{
    public static class SceneFactory
    {
        public static BaseScene CreateScene(SceneType type)
        {
            BaseScene scene;
            switch (type)
            {
                case SceneType.Start:
                    scene = new StartScene();
                    break;
                case SceneType.Lobby:
                    scene = new LobbyScene();
                    break;
                case SceneType.PlayerInfo:
                    scene = new PlayerInfoScene();
                    break;
                case SceneType.Inventory:
                    scene = new InventoryScene();
                    break;
                case SceneType.Store:
                    scene = new StoreScene();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Scene is {type}");
            }
            return scene;
        }
    }
}
