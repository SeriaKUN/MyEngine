using SFML.System;
using SFML.Graphics;

namespace MyEngine.Render
{
    class MyEngineSprite
    {
        public Sprite sprite = new Sprite();

        public Vector2f position = new Vector2f(0, 0);

        public bool toRender = true;

        public Vector2f SpritePosition
        {
            get
                => sprite.Position;

            set
                => sprite.Position = value;
        }

        public int Width
            => (int)sprite.Texture.Size.X;

        public int Height
            => (int)sprite.Texture.Size.Y;

        public MyEngineSprite(Vector2f position, Texture texture, bool toRender = true)
        {
            this.position = position;
            sprite.Texture = texture;
            this.toRender = toRender;
        }

        public MyEngineSprite(MyEngineSprite agarioSprite)
        {
            sprite = new Sprite(agarioSprite.sprite);
            position = agarioSprite.position;
            toRender = agarioSprite.toRender;
        }

        public MyEngineSprite()
        {

        }

        public static MyEngineSprite newSprite(Vector2f position, string path, bool toRender = true)
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            MyEngineSprite sprite = new MyEngineSprite(position, new Texture(stream), toRender);

            stream.Close();

            return sprite;
        }

        public virtual void TryRender(Camera camera)
        {
            if (!toRender)
                return;

            if (isRendered(camera))
                Render(camera);
        }

        public bool isRendered(Camera camera)
            => new IntRect((Vector2i)position - new Vector2i((int)(Width * 0.5f), (int)(Height * 0.5f)), new Vector2i(Width, Height)).Intersects((IntRect)camera.rectangle);

        public void Render(Camera camera)
        {
            SpritePosition = position - new Vector2f(Width * 0.5f, Height * 0.5f) - camera.center + new Vector2f(camera.size.X * 0.5f, camera.size.Y * 0.5f);
            camera.renderTarget.Draw(sprite);
        }
    }
}
