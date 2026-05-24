using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float MaxHP = 200f;
    public float currentHP = 200f;
    public Slider HPBar;

    void Start()
    {
        SetMaxHP(MaxHP);
    }

    public void SetMaxHP(float maxHP)
    {
        MaxHP = maxHP;
        currentHP = maxHP;

        if (HPBar == null)
            return;

        HPBar.maxValue = MaxHP;
        HPBar.value = currentHP;
    }

    public void SetHP(float hp)
    {
        currentHP = Mathf.Clamp(hp, 0, MaxHP);

        if (HPBar != null)
            HPBar.value = currentHP;
    }
}
