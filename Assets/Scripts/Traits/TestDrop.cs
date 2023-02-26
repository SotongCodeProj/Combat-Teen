using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using System.Linq;
public class TestDrop : MonoBehaviour
{
    public SkillTable skillTable;
    public List<Trait> traitUses;
    public List<Skill> SkillUses;

    [SerializeField] List<TableData> dropPosibility;
    private void Awake()
    {
        foreach (var item in skillTable.AllAvaiableSkills)
        {
            bool skilEquiped = false;
            bool traitEquiped = true;

            skilEquiped = item.RequiredSkill == null ? true:
            SkillUses.Contains(item.RequiredSkill);

            for (int i = 0; i < item.RequiredTraits.Length; i++)
            {
                if (!traitUses.Contains(item.RequiredTraits[i]))
                {
                    traitEquiped = false;
                    break;
                }
            }

            if (skilEquiped && traitEquiped) dropPosibility.Add(item);
        }
    }
    [Button]
    private void CallDropRate()
    {
        int rng = Random.Range(0, 10);
        if (rng > 4)
        {
            Debug.Log("Drop Skill");
        }
    }
}
