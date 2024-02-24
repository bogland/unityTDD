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
            Debug.Log("캐릭터에 맞음");
            //GameObject.Destroy(gameObject);
            OnHitEnemy.Invoke();
        }

    }
}
