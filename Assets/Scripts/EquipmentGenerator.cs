using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour
{
    [SerializeField] private List<Armor> armors;

    [SerializeField] private List<TMP_InputField> armorFields;

    [SerializeField] private TMP_InputField equipmentField;

    private Dictionary<int, string> weapons = new()
    {
        { 1, "Knife (Нож) - 1D6" },
        { 2, "Light Pistol (Лёгкий пистолет) - 1D6 + 1" },
        { 3, "Medium Pistol (Средний пистолет) - 2D6 + 1" },
        { 4, "Heavy Pistol (Тяжёлый пистолет) - 3D6" },
        { 5, "Heavy Pistol (Тяжёлый пистолет) - 3D6" },
        { 6, "Light SMG (Лёгкий пистолет-пулемёт) - 2D6 + 3" },
        { 7, "Light Assault Rifle (Лёгкая штурмовая винтовка) - 4D6 + 1" },
        { 8, "Medium Assault Rifle (Средняя штурмовая винтовка) - 5D6" },
        { 9, "Medium Assault Rifle (Средняя штурмовая винтовка) - 5D6" },
        { 10, "Heavy Assault Rifle (Тяжёлая штурмовая винтовка) - 6D6 + 2" },
    };

    public void Generate()
    {
        int roll = DiceRoller.RollD10();

        Role currentRole = RoleSelector.CurrentRole;

        if (currentRole == Role.Соло) roll += 3;
        else if (currentRole == Role.Коп || currentRole == Role.Номад) roll += 2;

        roll = Mathf.Min(roll, 10);

        Armor rolledArmor = armors[roll - 1];

        armorFields[0].text = rolledArmor.head.ToString();
        armorFields[1].text = rolledArmor.torso.ToString();
        armorFields[2].text = rolledArmor.rightHand.ToString();
        armorFields[3].text = rolledArmor.leftHand.ToString();
        armorFields[4].text = rolledArmor.rightLeg.ToString();
        armorFields[5].text = rolledArmor.leftLeg.ToString();

        equipmentField.text = rolledArmor.title + "\n";
        equipmentField.text += weapons[roll];
    }
}
