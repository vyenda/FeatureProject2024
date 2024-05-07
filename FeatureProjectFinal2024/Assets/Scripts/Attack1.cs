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
    // how much damage attack 1 does
    public int damage = 10;

    private void Start()
    {
        // starts the coroutine for Death1()
        StartCoroutine(Death1());
    }

    // destorys the game object once the time is up
    IEnumerator Death1()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
