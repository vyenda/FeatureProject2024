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
    // how much damage attack 2 does
    public int damage = 5;

    private void Start()
    {
        // starts the coroutine for Death2()
        StartCoroutine(Death2());
    }

    // destroys the game object once the time is up
    IEnumerator Death2()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
