using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SkillsGenerator : MonoBehaviour
{
    [SerializeField] private TMP_InputField skillsField;

    [SerializeField] private List<SkillsSet> skillsSets;

    [SerializeField] private Animator veryRareTitleAnim;

    [SerializeField]
    private List<string> techAdditionalSkills = new()
    {
        "Технология (вертолет)",
        "Технология (самолет)",
        "Технология (ави)",
        "Технология (оружие)",
        "Электронная безопасность",
    };

    public void Generate()
    {
        // Input
        int skillPull = 26;
        int currentRole = (int)RoleSelector.CurrentRole;
        string[] skillsSet = new string[10];
        skillsSets[currentRole].skills.CopyTo(skillsSet);
        string mainSkillName = skillsSet[0];
        List<int> skillsPoints = new()
        {
            5,
            1,
            1,
            1,
            1,
            1,
            1,
            1,
            1,
            1
        };
        if (RoleSelector.CurrentRole == Role.Техник)
        {
            SetTechSkills(skillsSet);
        }
        List<int> excludedSkillsIndexes = new();

        // Process
        while (skillPull > 0)
        {
            if (excludedSkillsIndexes.Count >= 10)
            {
                excludedSkillsIndexes.Clear();
                for (int i = 0; i < skillsPoints.Count; i++)
                {
                    if (skillsPoints[i] >= 10) excludedSkillsIndexes.Add(skillsPoints[i]);
                }
                veryRareTitleAnim.SetTrigger("01");
                continue;
            }

            int skillIndex = Random.Range(0, skillsPoints.Count);
            if (excludedSkillsIndexes.Contains(skillIndex)) continue;

            int roll;

            if (skillIndex == 0) roll = DiceRoller.RollD5();
            else roll = DiceRoller.RollD9();

            roll = Mathf.Min(roll, skillPull);

            if (skillsPoints[skillIndex] + roll > 10)
            {
                roll = 10 - skillsPoints[skillIndex];
            }

            skillsPoints[skillIndex] += roll;

            skillPull -= roll;

            excludedSkillsIndexes.Add(skillIndex);
        }

        // Output
        string skillsSetText = string.Empty;
        for (int i = 0; i < skillsSet.Length; i++)
        {
            if (i == 0) skillsSetText += $"<b>{skillsSet[i]} : {skillsPoints[i]}</b>, ";
            else if (i == skillsSet.Length - 1) skillsSetText += $"{skillsSet[i]} : {skillsPoints[i]}.";
            else skillsSetText += $"{skillsSet[i]} : {skillsPoints[i]}, ";
        }
        skillsField.text = skillsSetText;
    }

    private void SetTechSkills(string[] techSkillSet)
    {
        string[] techAdditionalSkillsArray = new string[5];
        this.techAdditionalSkills.CopyTo(techAdditionalSkillsArray);
        List<string> techAdditionalSkills = techAdditionalSkillsArray.ToList();

        for (int i = 1; i < 4; i++)
        {
            int skillsCount = techAdditionalSkills.Count;
            techSkillSet[^i] = techAdditionalSkills[Random.Range(0, skillsCount)];
            techAdditionalSkills.Remove(techSkillSet[^i]);
        }
    }
}