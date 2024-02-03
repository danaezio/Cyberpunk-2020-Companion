using UnityEngine;

public enum Role
{
    Соло = 0,
    Коп = 1,
    Нетраннер = 2,
    Корп = 3,
    Фиксер = 4,
    Техник = 5,
    Медтехник = 6,
    Номад = 7,
    Журналист = 8,
    Рокер = 9,
}

public class RoleSelector : MonoBehaviour
{
    public static Role CurrentRole { get; private set; } = Role.Соло;

    public void SelectRole(int roleID)
    {
        CurrentRole = (Role)roleID;
    }
}
