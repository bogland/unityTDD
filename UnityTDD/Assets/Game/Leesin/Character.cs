using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum eUnitType
{
    Me = 6,
    Enemy = 7,
    Friend = 8,
}
public class CharacterManager
{
    Dictionary<string, GameObject> dictCharacter = new Dictionary<string, GameObject>();
    public GameObject Spawn(eUnitType unitType, GameObject character,Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
    {
        var unit = GameObject.Instantiate(character, position, rotation);
        unit.layer = (int) unitType;
        
        Guid guid = Guid.NewGuid();
        dictCharacter.Add(guid.ToString(), unit);

        return unit;
    }

    public string[] FindCharactersInArea(Vector3 position, float range)
    {
        var charactersInArea = dictCharacter
            .Where(kv => kv.Value.layer == (int)eUnitType.Enemy)
            .Where(kv => IsInsideRange(kv.Value.transform.position, position, range))
            .Select(kv => kv.Key) 
            .ToArray();
        return charactersInArea;
    }

    bool IsInsideRange(Vector3 position, Vector3 center, float range)
    {
        // position���� center������ �Ÿ� ���
        float distance = Vector2.Distance(new Vector2(position.x, position.z), new Vector2(center.x, center.z));

        // �Ÿ��� range ���ϸ� �ȿ� �ִٰ� �Ǵ�
        return distance <= range;
    }
}
