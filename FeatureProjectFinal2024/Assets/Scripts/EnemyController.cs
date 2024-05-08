using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/* Author: Angeleen Arellano
 * Last Edited: 5/6/2024
 */
/// <summary>
/// Dummy for the Player.
/// </summary>
public class EnemyController : MonoBehaviour
{

    // enemies health
    public int health = 30;

    private void Update()
    {
        // runs death()
        death();
    }

    // sets the game obj false/"kills" enemy once it's reached 0 or below health
    public void death()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    // does damage to the enemy by subtracting the damage from enemy health
    public void takeDamage(int damage)
    {
        health -= damage;
    }

    // does damage to the enemy based on what attack is hitting/triggering it
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Attack1>() != null)
        {
            health -= other.GetComponent<Attack1>().damage;
        }

        if (other.GetComponent<Attack2>() != null)
        {
            health -= other.GetComponent<Attack2>().damage;
        }
    }
}
