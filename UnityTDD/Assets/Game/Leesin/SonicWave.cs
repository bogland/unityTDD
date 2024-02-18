using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SonicWave : MonoBehaviour
{
    public UnityEvent OnHitEnemy = new UnityEvent();
    Vector3 posStart;
    Vector3 posDestination;
    Rigidbody rigidbody;
    float range;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 posStart, Vector3 posDestination, float speed, float range)
    {
        this.posStart = posStart;
        this.posDestination = posDestination;
        this.range = range;

        transform.position = posStart;
        var dir = (posDestination - posStart).normalized;
        rigidbody.velocity = dir * speed;
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(posStart, transform.position) > range)
        {
            Debug.Log("최대 사거리에 도달했습니다.");
            Destroy();
            // 이동을 멈추거나 추가적인 동작을 수행할 수 있습니다.
            // 여기에 추가 코드를 작성하세요.

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("캐릭터에 맞음");
            GameObject.Destroy(gameObject);
            OnHitEnemy.Invoke();
        }

    }
}
