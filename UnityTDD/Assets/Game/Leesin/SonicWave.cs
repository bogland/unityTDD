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
            Debug.Log("�ִ� ��Ÿ��� �����߽��ϴ�.");
            Destroy();
            // �̵��� ���߰ų� �߰����� ������ ������ �� �ֽ��ϴ�.
            // ���⿡ �߰� �ڵ带 �ۼ��ϼ���.

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("ĳ���Ϳ� ����");
            GameObject.Destroy(gameObject);
            OnHitEnemy.Invoke();
        }

    }
}
