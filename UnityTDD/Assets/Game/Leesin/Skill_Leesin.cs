using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Skill_Leesin : MonoBehaviour
{
    Animator animator;
    [Header("SKILL")]
    public SonicWave prefabSonicWave;
    public float speed = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        CastSonicWave(transform.position, new Vector3(0,0,10));
    }

    public async void CastSonicWave(Vector3 posStart, Vector3 posDestination)
    {
        animator.Play("Skill_SonicWave");
        await Task.Delay(500);

        var objectSonicWave = Instantiate(prefabSonicWave, posStart, Quaternion.identity);
        var sonicWave = objectSonicWave.GetComponent<SonicWave>();

        var range = 10f;
        sonicWave.Move(posStart, posDestination, speed, range);
        //rdSonicWave.velocity = dir * speed;
       // 애니 발동
       // -이펙트 발동

        //- 투사체 생성
        //- 패시브버프(스킬 사용시 N초간 공속상승)
        //- 피격시 절대시야
        //- 피격시 물리 피해
    }
}
