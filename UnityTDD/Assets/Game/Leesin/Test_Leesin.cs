using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Leesin : MonoBehaviour
{
    Character character = new Character();
    // Start is called before the first frame update
    void Start()
    {
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = character.Spawn(UnitType.Me, characterLeesin);
        var enemyLeeSin = character.Spawn(UnitType.Enemy, characterLeesin,new Vector3(0,0,5));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastSonicWave(myLeeSin.transform.position, enemyLeeSin.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
