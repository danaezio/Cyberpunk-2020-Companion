using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Armor", menuName = "Armor", order = 0)]
public class Armor : ScriptableObject
{
    [FormerlySerializedAs("name")] public string title;

    public int head;
    public int torso;
    public int rightHand;
    public int leftHand;
    public int rightLeg;
    public int leftLeg;
}