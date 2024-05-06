using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Angeleen Arellano
 * Last Edited: 5/5/2024
 */
/// <summary>
/// Attack 2.
/// </summary>
public class Attack2 : MonoBehaviour
{
    public int damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        EnemyController health = collision.gameObject.GetComponent<EnemyController>();
        if (health != null)
        {
            health.takeDamage(damage);
        }
    }
}
