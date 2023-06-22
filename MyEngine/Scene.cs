using MyEngine.GameObjects;
using MyEngine.Render;
using SFML.Graphics;

namespace MyEngine
{
    struct Scene
    {
        public List<GameObject> gameObjects;
        public RenderTarget target;
        public Camera camera;

        public Scene(List<GameObject> gameObjects, RenderTarget target, Camera camera)
        {
            this.gameObjects = gameObjects;
            this.target = target;
            this.camera = camera;
        }

        public void Add(GameObject gameObject)
            => gameObjects.Add(gameObject);

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].TryUpdate();

            CheckGameObjectsToDestroy();
        }

        public void Render()
        {
            camera.Render(gameObjects, target);
        }

        private void CheckGameObjectsToDestroy()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                if (gameObject.toDestroy)
                {
                    gameObjects.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
