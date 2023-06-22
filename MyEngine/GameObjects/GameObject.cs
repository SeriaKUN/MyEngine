﻿using MyEngine.GameObjects.Interfaces;

namespace MyEngine.GameObjects
{
    public abstract class GameObject
    {
        public bool toDestroy;

        public void TryUpdate()
        {
            if (this is IUpdateable updateable)
                updateable.Update();
        }

        public void TryRender()
        {
            if (this is IRenderable renderable)
                renderable.Render();
        }
    }
}
