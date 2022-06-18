using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityAction<Bullet> OnDeactivated;
    [SerializeField] private Rigidbody rigidbody;

    public void Shoot(Vector3 position, Vector3 direction, float speed)
    {
        rigidbody.velocity = Vector3.zero;
        transform.forward = direction;
        rigidbody.AddForce(direction * speed,ForceMode.VelocityChange);
        Destroy(gameObject,3f);
        // StartCoroutine(Deactivate());
    }

    // private IEnumerator Deactivate()
    // {
    //     yield return new WaitForSeconds(3);
    //     OnDeactivated?.Invoke(this);
    // }
}
