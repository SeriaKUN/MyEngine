using SFML.System;
using SFML.Graphics;
using MyEngine.Enums;

namespace MyEngine.Render
{
    public class Animator
    {
        Texture[] frames;
        MyEngineSprite sprite;

        public float frameToRender = 0;
        public bool paused = false;
        public ActionAfterAnimationEnd actionAfterAnimationEnd = ActionAfterAnimationEnd.StopRenderingAnimation;
        public bool isReverse = false;
        public float animationPlaySpeed = 1;

        public bool isLastFrame
            => ((int)frameToRender == frames.Length - 1 && !isReverse) || ((int)frameToRender == 0 && isReverse);

        public Animator(Texture[] frames, MyEngineSprite sprite, float animationPlaySpeed = 1, float frameToRender = 0, bool paused = false, bool isReverse = false)
        {
            this.frames = frames;
            this.frameToRender = frameToRender;
            this.paused = paused;
            this.sprite = sprite;
            sprite.sprite.Texture = frames[(int)frameToRender];
            this.isReverse = isReverse;
            this.animationPlaySpeed = animationPlaySpeed;
        }

        public Animator(Animator animator)
        {
            frames = new Texture[animator.frames.Length];
            for (int i = 0; i < animator.frames.Length; i++)
            {
                frames[i] = new Texture(animator.frames[i]);
            }
            frameToRender = animator.frameToRender;
            paused = animator.paused;
            sprite = new MyEngineSprite(animator.sprite);
            animationPlaySpeed = animator.animationPlaySpeed;
            actionAfterAnimationEnd = animator.actionAfterAnimationEnd;
            isReverse = animator.isReverse;
        }

        public static Animator newAnimation(string[] framesPaths, float animationPlaySpeed = 1, bool toRender = true, Vector2f position = new Vector2f(), float frameToRender = 0, bool paused = false, bool isReverse = false)
        {
            Texture[] frames = new Texture[framesPaths.Length];

            for (int i = 0; i < framesPaths.Length; i++)
            {
                using (FileStream stream = new FileStream(framesPaths[i], FileMode.Open))
                {
                    frames[i] = new Texture(stream);

                    stream.Close();
                }
            }

            Animator animatedSprite = new Animator(frames, new MyEngineSprite(frames[(int)frameToRender], position, toRender), animationPlaySpeed, frameToRender, paused, isReverse);
            return animatedSprite;
        }

        public void TryRender(Camera camera)
        {
            if (frameToRender < frames.Length && frameToRender >= 0)
                sprite.sprite.Texture = frames[(int)frameToRender];

            sprite.TryRender(camera);

            if (isLastFrame)
            {
                switch (actionAfterAnimationEnd)
                {
                    case ActionAfterAnimationEnd.StopRenderingAnimation:
                        sprite.toRender = false;
                        break;

                    case ActionAfterAnimationEnd.PlayInReverse:
                        isReverse = !isReverse;
                        break;

                    case ActionAfterAnimationEnd.RestartAnimation:
                        frameToRender = 0;
                        break;
                }

            }

            if (paused)
                return;

            frameToRender += isReverse ? -animationPlaySpeed : animationPlaySpeed;
        }

        public void Start()
        {
            frameToRender = 0;
            sprite.toRender = true;
            paused = false;
        }
    }
}
