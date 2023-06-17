using CombTeen.Gameplay.DataTransport;
using CombTeen.StartScene;
using TMPro;
using UnityEngine;

public class PrepareUnitView : MonoBehaviour
{
    [Header("Status")]
    public TMP_InputField Attack;
    public TMP_InputField Defense;
    public TMP_InputField Health;
    public TMP_InputField Speed;
    public TMP_InputField AP;

    [Header("Action")]
    public TMP_Dropdown AttackAction;
    public TMP_Dropdown DefenseAction;
    public TMP_Dropdown SkillAction;
    public TMP_Dropdown SupportAction;
    public TMP_Dropdown MoveAction;

    public void SetDefault(UnitDataControl.RandomStatValue characterData)
    {
        Attack.text = Random.Range(1, characterData.Attack + 1).ToString();
        Defense.text = Random.Range(1, characterData.Defense + 1).ToString();
        Health.text = Random.Range(15, characterData.Health + 1).ToString();
        Speed.text = Random.Range(1, characterData.Speed + 1).ToString();
        AP.text = Random.Range(3, characterData.Ap + 1).ToString();
    }

    public void RandomAction(int attack, int defense, int skill, int support, int move)
    {
        AttackAction.value = attack;
        DefenseAction.value = defense;
        SkillAction.value = skill;
        SupportAction.value = support;
        MoveAction.value = move;
    }

}
