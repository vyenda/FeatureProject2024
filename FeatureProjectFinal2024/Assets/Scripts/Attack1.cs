using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Angeleen Arellano
 * Last Edited: 5/5/2024
 */
/// <summary>
/// Attack 1.
/// </summary>
public class Attack1 : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController health = collision.gameObject.GetComponent<EnemyController>();
        if (health != null)
        {
            health.takeDamage(damage);
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        EnemyController health = gameObject.GetComponent<EnemyController>();
        if (health != null)
        {
            health.takeDamage(damage);
        }
    }
    */
}
