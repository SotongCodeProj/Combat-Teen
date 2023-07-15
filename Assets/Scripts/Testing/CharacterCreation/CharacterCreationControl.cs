using CombTeen.Esential.PlayerData.GeneralInfo;
using UnityEngine;
using static CombTeen.Constant.ClassConstant;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterCreationControl : MonoBehaviour
    {
        public CharGeneralInfoView _generalInfoView;
        public ClassSelectorView _classSelectorView;
        public IPlayerGeneralInfo CharacterGeneralInfo => new PlayerGeneralInfo(_generalInfoView.GetName());

        #region  HoldData
        private ClassType _selectedClass;
        #endregion

        private void Awake() {
            _classSelectorView.OnSelectClass.AddListener(SetSelectedClass);
        }

        public void SetSelectedClass(ClassType classType){
            _selectedClass = classType;
        }

        public void CretaeCharacter()
        {
            Debug.Log($"Character Name : {CharacterGeneralInfo.PlayerName}");
            Debug.Log($"Character Class : {_selectedClass}");
        }

        private void OnDestroy() {
            _classSelectorView.OnSelectClass.RemoveListener(SetSelectedClass);
        }
    }
}