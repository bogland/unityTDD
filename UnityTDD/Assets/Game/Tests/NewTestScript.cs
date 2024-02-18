using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator CastLeesinSonicWave()
    {
        Character character = new Character();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = character.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = character.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 5));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastSonicWave(myLeeSin.transform.position, enemyLeeSin.transform.position);
        var isHit = false;
        skillLeeSin.OnHitEnemy.AddListener(() =>
        {
            isHit = true;
        });

        yield return new WaitForSeconds(5);

        // Use the Assert class to test conditions
        Assert.True(isHit, "음파에 안맞음");

    }
    [UnityTest]
    public IEnumerator CastLeesinSonicWaveOtherDirection()
    {
        Character character = new Character();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = character.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = character.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 5));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastSonicWave(myLeeSin.transform.position, new Vector3(-5,0,0));
        var isHit = false;
        skillLeeSin.OnHitEnemy.AddListener(() =>
        {
            isHit = true;
        });

        yield return new WaitForSeconds(5);
        // Use the Assert class to test conditions
        Assert.True(!isHit, "음파에 맞음");

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var isTrue = true;
        Assert.AreEqual(true, isTrue);
        yield return null;
    }
}
