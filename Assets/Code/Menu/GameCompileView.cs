using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Environment;
using Code.Vehicle;
using Code.Vehicle.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu
{
    public class GameCompileView : MonoBehaviour
    {
        [SerializeField] private Transform motorbikeParent;
        [SerializeField] private Transform groundParent;
        [SerializeField] private Transform inputParent;

        [SerializeField] private InteractableElementWithTitle elementInstance;

        [SerializeField] private Button playButton;
        
        private List<InteractableElementWithTitle> _motorbikeElements = new List<InteractableElementWithTitle>();
        private List<InteractableElementWithTitle> _groundElements = new List<InteractableElementWithTitle>();
        private List<InteractableElementWithTitle> _inputElements = new List<InteractableElementWithTitle>();
        
        private const string MotorbikeUnique = "moto";
        private const string GroundUnique = "ground";
        private const string InputUnique = "input";
        
        public event Action<MotorbikeTypeSo> OnMotorbikePicked = delegate(MotorbikeTypeSo so) { };
        public event Action<GroundGenerationTypeSo> OnGroundPicked = delegate(GroundGenerationTypeSo so) { };
        public event Action<InputTypeSo> OnInputPicked = delegate(InputTypeSo so) { };
        
        public event Action OnPlayPressed = delegate { };
        
        private ReadOnlyCollection<MotorbikeTypeSo> _motorbikes;
        private ReadOnlyCollection<GroundGenerationTypeSo> _groundGenerations;
        private ReadOnlyCollection<InputTypeSo> _inputs;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayClicked);
        }
        private void PlayClicked() => OnPlayPressed?.Invoke();

        public void RedrawPlayButton(bool isAvailable)
        {
            playButton.interactable = isAvailable;
        }
        
        public void DrawView(ReadOnlyCollection<MotorbikeTypeSo> motorbikeVariants, ReadOnlyCollection<GroundGenerationTypeSo> groundGenerationVariants, ReadOnlyCollection<InputTypeSo> inputVariants)
        {
            _motorbikes = motorbikeVariants;
            _groundGenerations = groundGenerationVariants;
            _inputs = inputVariants;

            if (_motorbikeElements.Count == 0)
                InitMoto(motorbikeVariants);

            if (_groundElements.Count == 0)
                InitGround(groundGenerationVariants);

            if (_inputElements.Count == 0)
                InitInput(inputVariants);
        }

        public void ChangePick(MotorbikeTypeSo moto)
        {
            for (int i = 0; i < _motorbikes.Count; i++)
            {
                if (moto.Title == _motorbikes[i].Title)
                {
                    for (int j = 0; j < _motorbikeElements.Count; j++)
                    {
                        _motorbikeElements[j].ChangeIsPicked(i == j);
                    }
                    return;
                }
            }
        }

        public void ChangePick(GroundGenerationTypeSo ground)
        {
            for (int i = 0; i < _groundGenerations.Count; i++)
            {
                if (ground.Title == _groundGenerations[i].Title)
                {
                    for (int j = 0; j < _groundElements.Count; j++)
                    {
                        _groundElements[j].ChangeIsPicked(i == j);
                    }
                    return;
                }
            }
        }

        public void ChangePick(InputTypeSo input)
        {
            for (int i = 0; i < _inputs.Count; i++)
            {
                if (input.Title == _inputs[i].Title)
                {
                    for (int j = 0; j < _inputElements.Count; j++)
                    {
                        _inputElements[j].ChangeIsPicked(i == j);
                    }
                    return;
                }
            }
        }

        private void InitMoto(ReadOnlyCollection<MotorbikeTypeSo> motorbikeVariants)
        {
            for (int i = 0; i < motorbikeVariants.Count; i++)
            {
                var element = Instantiate(elementInstance, motorbikeParent);
                element.Construct(motorbikeVariants[i].Title, i, MotorbikeUnique);
                element.OnButtonPressed += OnButtonPressed;
                element.ChangeIsPicked(false);
                
                _motorbikeElements.Add(element);
            }
        }
        private void InitGround(ReadOnlyCollection<GroundGenerationTypeSo> groundGenerationVariants)
        {
            for (int i = 0; i < groundGenerationVariants.Count; i++)
            {
                var element = Instantiate(elementInstance, groundParent);
                element.Construct(groundGenerationVariants[i].Title, i, GroundUnique);
                element.OnButtonPressed += OnButtonPressed;
                element.ChangeIsPicked(false);
                
                _groundElements.Add(element);
            }
        }

        private void InitInput(ReadOnlyCollection<InputTypeSo> inputVariants)
        {
            for (int i = 0; i < inputVariants.Count; i++)
            {
                var element = Instantiate(elementInstance, inputParent);
                element.Construct(inputVariants[i].Title, i, InputUnique);
                element.OnButtonPressed += OnButtonPressed;
                element.ChangeIsPicked(false);
                
                _inputElements.Add(element);
            }
        }

        private void OnButtonPressed(string pickType, int index)
        {
            switch (pickType)
            {
                case MotorbikeUnique:
                    OnMotorbikePicked?.Invoke(_motorbikes[index]);
                    break;
                case GroundUnique:
                    OnGroundPicked?.Invoke(_groundGenerations[index]);
                    break;
                case InputUnique:
                    OnInputPicked?.Invoke(_inputs[index]);
                    break;
            }
        }

        private void OnDestroy()
        {
            foreach (var element in _motorbikeElements)
                if (element != null)
                    element.OnButtonPressed -= OnButtonPressed;
            foreach (var element in _groundElements)
                if (element != null)
                    element.OnButtonPressed -= OnButtonPressed;
            foreach (var element in _inputElements)
                if (element != null)
                    element.OnButtonPressed -= OnButtonPressed;
            
            if(playButton != null)
                playButton.onClick.RemoveAllListeners();
        }
    }
}
