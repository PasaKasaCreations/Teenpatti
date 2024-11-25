using Tactix.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static Tactix.Input.GameInput;
using static UnityEngine.InputSystem.InputAction;

namespace ScriptableObjects.Input
{
    [CreateAssetMenu(fileName = "Input Reader", menuName = "Input/Input Reader")]
    public class InputReader : ScriptableObject, IGameplayActions
    {
        [Header("Input Reader")]
        private GameInput _gameInput;

        [field: Header("Gameplay Input Actions")]
        //public event UnityAction ...Event;

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Gameplay.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        public void EnableGameplayInput()
        {
            _gameInput.Gameplay.Enable();
        }

        public void DisableAllInputs()
        {
            _gameInput.Gameplay.Disable();
        }

        private void OnDisable()
        {
            _gameInput.Gameplay.RemoveCallbacks(this);
            _gameInput.Gameplay.Disable();
        }
    }
}
