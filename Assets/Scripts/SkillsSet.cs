using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills", order = 1)]
public class SkillsSet : ScriptableObject
{
    public List<string> skills;
}