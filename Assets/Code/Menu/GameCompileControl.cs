using System.Collections.ObjectModel;
using Code.Environment;
using Code.Vehicle;
using Code.Vehicle.Input;
using UnityEngine;

namespace Code.Menu
{
    public class GameCompileControl : MonoBehaviour
    {
        private GameSetup _gameSetup;
        [SerializeField] private GameCompileView gameCompileView;

        private ReadOnlyCollection<MotorbikeTypeSo> MotorbikeVariants => _gameSetup.MotorbikeVariants;
        private ReadOnlyCollection<GroundGenerationTypeSo> GroundGenerationVariants => _gameSetup.GroundGenerationVariants;
        private ReadOnlyCollection<InputTypeSo> InputVariants => _gameSetup.InputVariants;
        
        private void Start()
        {
            _gameSetup = FindObjectOfType<GameSetup>();

            Subscribe();
            gameCompileView.DrawView(MotorbikeVariants, GroundGenerationVariants, InputVariants);
        }

        private void Subscribe()
        {
            gameCompileView.OnMotorbikePicked += OnMotorbikePicked;
            gameCompileView.OnGroundPicked += OnGroundPicked;
            gameCompileView.OnInputPicked += OnInputPicked;

            gameCompileView.OnPlayPressed += PlayPressed;
        }

        private void OnMotorbikePicked(MotorbikeTypeSo motorbikeTypeSo)
        {
            _gameSetup.PickMotorbike(motorbikeTypeSo);
            gameCompileView.ChangePick(motorbikeTypeSo);
            gameCompileView.RedrawPlayButton(_gameSetup.IsGameLoadAvailable);
        }
        private void OnGroundPicked(GroundGenerationTypeSo groundTypeSo)
        {
            _gameSetup.PickGroundGeneration(groundTypeSo);
            gameCompileView.ChangePick(groundTypeSo);
            gameCompileView.RedrawPlayButton(_gameSetup.IsGameLoadAvailable);
        }
        private void OnInputPicked(InputTypeSo inputTypeSo)
        {
            _gameSetup.PickInput(inputTypeSo);
            gameCompileView.ChangePick(inputTypeSo);
            gameCompileView.RedrawPlayButton(_gameSetup.IsGameLoadAvailable);
        }
        
        private void PlayPressed()
        {
            _gameSetup.TryLoadGame();
        }

        private void OnDestroy()
        {
            gameCompileView.OnMotorbikePicked -= OnMotorbikePicked;
            gameCompileView.OnGroundPicked -= OnGroundPicked;
            gameCompileView.OnInputPicked -= OnInputPicked;
        }
    }
}
