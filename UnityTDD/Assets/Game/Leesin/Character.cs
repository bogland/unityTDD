using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Me = 6,
    Enemy = 7,
    Friend = 8,
}
public class Character
{
    public GameObject Spawn(UnitType unitType, GameObject character,Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
    {
        var unit = GameObject.Instantiate(character, position, rotation);
        unit.layer = (int) unitType;
        return unit;
    }
}
