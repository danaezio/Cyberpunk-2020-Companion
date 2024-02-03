using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CyberneticsGenerator : MonoBehaviour
{
    [SerializeField] private TMP_InputField field;

    public Dictionary<int, string> cyberImplants = new()
    {
        { 4, "Big Knucks (Большие Костяшки)" },
        { 5, "Rippers (Потрошители)" },
        { 6, "Vampires (Вампиры)" },
        { 7, "Slice n'dice (Мономолекулярная нить)" },
        { 8, "Reflex Boost (Kereznikov)" },
        { 9, "Reflex Boost (Sandevistan)" },
        { 10, "" },
        { 11, "infrared (Инфракрасная оптика)" },
        { 12, "Low lite™" },
        { 13, "Camera (Камера)" },
        { 14, "Dartgan (Дротикомёт)" },
        { 15, "Anti dazzle (Защита от ослепления)" },
        { 16, "Targeting scope (Прицельный видоискатель)" },
        { 21, "Med. Pistol (Средний Пистолет)" },
        { 22, "Light Pistol (Лёгкий Пистолет)" },
        { 23, "Med. Pistol (Средний Пистолет)" },
        { 24, "Light SMG (Лёгкий Пистолет-Пулемёт)" },
        { 25, "Very Heavy Pistol (Очень тяжёлый пистолет)" },
        { 26, "Heavy Pistol (Тяжёлый Пистолет)" },
        { 31, "Wearman®" },
        { 32, "Radio Link (Радио-коннектор)" },
        { 33, "Phon Splice (Телефонное соединение)" },
        { 34, "Amplified Hearing (Усиленный слух)" },
        { 35, "Sound Editing (Редактор звука)" },
        { 36, "Digital Recording link (Коннектор)" },
    };

    public void Generate()
    {
        List<int> rolls = RoleSelector.CurrentRole == Role.Соло
            ? DiceRoller.RollSixUniqueD10()
            : DiceRoller.RollThreeUniqueD10();

        while (rolls.Contains(1) || rolls.Contains(2) || rolls.Contains(3))
        {
            for (int i = 0; i < rolls.Count; i++)
            {
                if (rolls[i] == 1) rolls[rolls.IndexOf(1)] = DiceRoller.RollD6() + 10;
                if (rolls[i] == 2) rolls[rolls.IndexOf(2)] = DiceRoller.RollD6() + 20;
                if (rolls[i] == 3) rolls[rolls.IndexOf(3)] = DiceRoller.RollD6() + 30;
            }
        }

        string cyberImplantsText = String.Empty;

        foreach (int roll in rolls)
        {
            if (roll == 10) continue;
            cyberImplantsText += cyberImplants[roll] + "\n";
        }

        field.text = cyberImplantsText;
    }
}