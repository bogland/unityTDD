using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Leesin : MonoBehaviour
{
    CharacterManager characterManager = new CharacterManager();
    // Start is called before the first frame update
    void Start()
    {
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin,new Vector3(0,0,3));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        //skillLeeSin.CastSonicWave(myLeeSin.transform.position, enemyLeeSin.transform.position);


        skillLeeSin.CastTempest(myLeeSin.transform.position,characterManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

