using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatsGenerator : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> fields;
    [SerializeField] private TMP_InputField runField;
    [SerializeField] private TMP_InputField jumpField;
    [SerializeField] private TMP_InputField healthField;
    [SerializeField] private TMP_InputField reputationField;

    public void Generate()
    {
        foreach (TMP_InputField field in fields)
        {
            List<int> rolls = DiceRoller.RollTwoD6();
            while (rolls.Sum() > 10) rolls = DiceRoller.RollTwoD6();
            field.text = rolls.Sum().ToString();
        }

        int bodyType = int.Parse(fields[^1].text);
        int run = bodyType * 3;
        float jump = run / 4f;
        jump = Convert.ToSingle(Math.Round(jump, 1));
        runField.text = run.ToString();
        jumpField.text = jump.ToString();
        healthField.text = (bodyType * 5f).ToString();

        int reputation = 0;
        bool fair = false;
        while (!fair)
        {
            reputation = DiceRoller.RollD10();

            if (reputation > 5)
            {
                int confirmationCount;
                confirmationCount = reputation switch
                {
                    10 => 2,
                    >= 8 => 1,
                    _ => 0
                };

                if (confirmationCount == 0)
                {
                    if (DiceRoller.RollD10() > 5) fair = true;
                }

                bool confirmed = true;  
                for (int i = 0; i < confirmationCount; i++)
                {
                    if (DiceRoller.RollD10() != 10)
                    {
                        confirmed = false;
                        break;
                    }
                }
                if (confirmed == false) continue;
                fair = true;
                Debug.Log(confirmationCount switch
                {
                    0 => "Крутой",
                    1 => "Очень крутой",
                    2 => "Самый крутой",
                    _ => ""
                });
            }
            else fair = true;
        }

        reputationField.text = reputation.ToString();
    }
}