using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Author: Angeleen Arellano
 * Last Edited: 5/5/2024
 */
/// <summary>
/// Dummy for the Player.
/// </summary>
public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    // enemies health
    public int health = 20;

    // destorys/"kills" enemy once it's reached 0 or below health
    public void death()
    { 
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
