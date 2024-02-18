using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Skill_Leesin : MonoBehaviour
{
    Animator animator;
    [Header("SKILL")]
    public SonicWave prefabSonicWave;
    public float speed = 1f;
    public UnityEvent OnHitEnemy = new UnityEvent();

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        //CastSonicWave(transform.position, new Vector3(0,0,10));
    }

    public async void CastSonicWave(Vector3 posStart, Vector3 posDestination)
    {
        // 애니 발동
        transform.LookAt(posDestination);
        animator.Play("Skill_SonicWave");
        await Task.Delay(1500);

        // -이펙트 발동
        //- 투사체 생성
        var objectSonicWave = Instantiate(prefabSonicWave, posStart, Quaternion.identity);
        var sonicWave = objectSonicWave.GetComponent<SonicWave>();
        sonicWave.OnHitEnemy.AddListener(() =>
        {
            OnHitEnemy.Invoke();
        });

        var range = 10f;
        sonicWave.Move(posStart, posDestination, speed, range);

        //- 패시브버프(스킬 사용시 N초간 공속상승)
        //- 피격시 절대시야
        //- 피격시 물리 피해
    }
}
