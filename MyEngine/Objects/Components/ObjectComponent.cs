using MyEngine.Objects.GameObjects;

namespace MyEngine.Objects.Components
{
    public class ObjectComponent
    {
        GameObject gameObject;

        public ObjectComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {

        }
    }
}
