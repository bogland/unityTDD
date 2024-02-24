using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
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
        Assert.True(isHit, "���Ŀ� �ȸ���");

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
        Assert.True(!isHit, "���Ŀ� ����");

    }

    [UnityTest]
    public IEnumerator CastLeesinSkillTempest()
    {
        //SceneManager.LoadScene("Test_Base");

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
        //skillLeeSin.CastSonicWave(myLeeSin.transform.position, new Vector3(-5, 0, 0));
        skillLeeSin.OnHitEnemySonic.AddListener(() =>
        {
            isHit = true;
        });

        yield return new WaitForSeconds(1);
        // Use the Assert class to test conditions
        Assert.True(isHit, "��ǳ(Tempest�� ����");

    }

    [UnityTest]
    public IEnumerator CastLeesinSkillTempestOut()
    {
        //SceneManager.LoadScene("Test_Base");

        CharacterManager characterManager = new CharacterManager();
        var characterLeesin = Resources.Load<GameObject>("Character_LeeSin");
        var myLeeSin = characterManager.Spawn(eUnitType.Me, characterLeesin);
        var enemyLeeSin = characterManager.Spawn(eUnitType.Enemy, characterLeesin, new Vector3(0, 0, 8));

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
        //skillLeeSin.CastSonicWave(myLeeSin.transform.position, new Vector3(-5, 0, 0));
        skillLeeSin.OnHitEnemySonic.AddListener(() =>
        {
            isHit = true;
        });

        yield return new WaitForSeconds(1);
        // Use the Assert class to test conditions
        Assert.True(!isHit, "��ǳ(Tempest�� ����");

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
