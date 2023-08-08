using MyEngine.Input;

namespace MyEngine.Objects.Interfaces
{
    interface IHasInput
    {
        public PlayerInput input { get; set; }

        public void UpdateInputValues()
        {
            UpdateKeyInput();
            UpdateVectorInput();
        }

        public void UpdateKeyInput()
            => input.UpdateKeyInput();
        public virtual void UpdateVectorInput()
        {

        }

    }
}
