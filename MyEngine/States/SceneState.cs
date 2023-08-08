using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.States
{
    class SceneState : State
    {
        public Scene scene;

        public SceneState(Scene scene)
        {
            this.scene = scene;
        }

        public override void Input()
            => scene.Input();

        public override void Render()
            => scene.Render();

        public override void Update()
            => scene.Update();
    }
}
