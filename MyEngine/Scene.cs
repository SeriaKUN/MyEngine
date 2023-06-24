using MyEngine.GameObjects;
using MyEngine.Render;
using SFML.Graphics;

namespace MyEngine
{
    public class Scene
    {
        public List<GameObject> gameObjects;
        public Camera camera;

        public Scene(List<GameObject> gameObjects, Camera camera)
        {
            this.gameObjects = gameObjects;
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
            camera.Render(gameObjects);
            Game.window.Display();
        }

        private void CheckGameObjectsToDestroy()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                if (gameObject.toDestroy)
                {
                    gameObject.OnDestroy?.Invoke();
                    gameObjects.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
