using MyEngine.Objects.Components;
using MyEngine.Objects.Interfaces;

namespace MyEngine.Objects.GameObjects
{
    public class GameObject
    {
        public bool toDestroy = false;

        public List<ObjectComponent> components = new List<ObjectComponent>();

        public Action? OnDestroy;

        public void TryUpdateInput()
        {
            if (this is IHasInput input)
                input.UpdateInputValues();
        }

        public void TryUpdate()
        {
            if (this is IUpdateable updateable)
                updateable.Update();

            foreach (ObjectComponent component in components)
                component.Update();
        }

        public void TryRender()
        {
            if (this is IRenderable renderable)
                renderable.Render();

            foreach (ObjectComponent component in components)
                component.Render();
        }


    }
}
