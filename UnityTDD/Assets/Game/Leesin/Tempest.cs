using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tempest : MonoBehaviour
{
    public UnityEvent OnHitEnemy = new UnityEvent();

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("ĳ���Ϳ� ����");
            //GameObject.Destroy(gameObject);
            OnHitEnemy.Invoke();
        }

    }
}
