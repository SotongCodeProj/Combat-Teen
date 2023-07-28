using CombTeen.Constant;
using UnityEngine;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterSectionControl : MonoBehaviour
    {
        [SerializeField] private CharacterSectionView _characterSectionView;


        private ClassType _currentSelectedClass;
        private void Start()
        {
            _characterSectionView.OnChangeClass.AddListener(SetClassType);
        }

        private void SetClassType(int index)
        {
            _currentSelectedClass = (ClassType)index;
        }

        public string GetCharacterName()
        {
            return _characterSectionView.CharacterName;
        }

        public ClassType GetClassType()
        {
            return _currentSelectedClass;
        }

    }
}
