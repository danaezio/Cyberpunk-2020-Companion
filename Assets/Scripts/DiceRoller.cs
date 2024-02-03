using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class DiceRoller
{
    public static List<int> RollTwoD6()
    {
        List<int> rolls = new();
        for (int i = 0; i < 2; i++) rolls.Add(RollD6());
        return rolls;
    }
    
    public static List<int> RollThreeUniqueD10()
    {
        List<int> rolls = new();
        for (int i = 0; i < 3; i++) rolls.Add(RollD6());
        bool isUnique = rolls.Distinct().Count() == rolls.Count;
        if (isUnique) return rolls;
        return RollThreeUniqueD10();
    }

    public static List<int> RollSixUniqueD10()
    {
        List<int> rolls = new();
        for (int i = 0; i < 6; i++) rolls.Add(RollD10());
        bool isUnique = rolls.Distinct().Count() == rolls.Count;
        if (isUnique) return rolls;
        return RollSixUniqueD10();
    }

    public static int RollD5() => Random.Range(1, 6);
    public static int RollD6() => Random.Range(1, 7);
    public static int RollD9() => Random.Range(1, 10);
    public static int RollD10() => Random.Range(1, 11);
}