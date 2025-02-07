using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mana : MonoBehaviour
{

    public UnityEvent<int, int> manaChanged;
    public int ManaRecover = 20;

    [SerializeField]
    private int _maxMana = 100;

    public int MaxMana
    {
        get
        {
            return _maxMana;
        }
        set
        {
            _maxMana = value;
        }
    }
    [SerializeField]
    public int _mana = 100;

    public int Maana
    {
        get
        {
            return _mana;
        }
        set
        {
            _mana = value;
            manaChanged?.Invoke(Maana, MaxMana);
            
            if (Maana >= MaxMana)
            {
                Maana = MaxMana;
            }
        }
    }
}
