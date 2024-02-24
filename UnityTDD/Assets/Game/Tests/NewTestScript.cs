using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Debug.Log("OneTimeSetUp");
    }

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        Debug.Log("SetUp");
        yield return new EnterPlayMode();
        SceneManager.LoadScene("Test_Base");
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Debug.Log("TearDown");
        yield return new ExitPlayMode();
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator CastLeesinSonicWave()
    {
        CharacterManager character = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = character.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = character.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 5));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastSonicWave(myLeeSin.transform.position, enemyLeeSin.transform.position);
        var isHit = false;
        skillLeeSin.OnHitEnemySonic.AddListener(() =>
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
        CharacterManager character = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = character.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = character.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 5));

        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastSonicWave(myLeeSin.transform.position, new Vector3(-5,0,0));
        var isHit = false;
        skillLeeSin.OnHitEnemySonic.AddListener(() =>
        {
            isHit = true;
        });

        yield return new WaitForSeconds(5);
        // Use the Assert class to test conditions
        Assert.True(!isHit, "음파에 맞음");
    }

    [UnityTest]
    public IEnumerator CastLeesinSkillTempest()
    {
        CharacterManager characterManager = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 3));

        var isHit = false;
        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastTempest(myLeeSin.transform.position, characterManager);
        skillLeeSin.OnHitEnemyTempest.AddListener((ids) =>
        {
            if(ids.Length > 0)
            {
                isHit = true;
            }
        });

        yield return new WaitForSeconds(1);
        Assert.True(isHit, "퐁풍(Tempest에 맞음");

    }

    [UnityTest]
    public IEnumerator CastLeesinSkillTempestOut()
    {
        CharacterManager characterManager = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 9));

        var isHit = false;
        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        skillLeeSin.CastTempest(myLeeSin.transform.position, characterManager);
        skillLeeSin.OnHitEnemyTempest.AddListener((ids) =>
        {
            if (ids.Length > 0)
            {
                isHit = true;
            }
        });

        yield return new WaitForSeconds(1);
        // Use the Assert class to test conditions
        Assert.True(!isHit, "퐁풍(Tempest에 맞음");

    }

    [UnityTest]
    public IEnumerator CastLeesinSkillTempestAsync() => UniTask.ToCoroutine(async () =>
    {
        CharacterManager characterManager = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 3));

        var isHit = false;
        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        var ids = await skillLeeSin.CastTempest(myLeeSin.transform.position, characterManager);
        if(ids.Length > 0)
        {
            isHit = true;
        }
        await Task.Delay(1000);
        Assert.True(isHit, "Tempest에 맞음");
    });

    [UnityTest]
    public async Task CastLeesinSkillTempestAsync2()
    { 
        CharacterManager characterManager = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 3));

        var isHit = false;
        var skillLeeSin = myLeeSin.GetComponent<Skill_Leesin>();
        var ids = await skillLeeSin.CastTempest(myLeeSin.transform.position, characterManager);
        if (ids.Length > 0)
        {
            isHit = true;
        }
        await Task.Delay(1000);
        Assert.True(isHit, "Tempest에 맞음");
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
