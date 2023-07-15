using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace CombTeen.Testing.CharacterCreation
{
    public interface ICharGeneralInfoView
    {
        public string GetName();
    }
    public class CharGeneralInfoView : MonoBehaviour, ICharGeneralInfoView
    {
        [SerializeField] private TMP_InputField _nameInputField;

        public string GetName()
        {
            return _nameInputField.text;
        }
    }
}