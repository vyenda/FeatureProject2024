using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/* Author: Angeleen Arellano
 * Last Edited: 5/5/2024
 */
/// <summary>
/// Controls the player, specifically movement and attack.
/// 
/// 1. Movement (speed included) // DONE
/// 2. AOE attack including a jump (cooldown included)
/// -- Starts wth a pull, then player jumps up and comes back down dealing damage
/// -- No coroutines or waits done, but the pull is done
/// 3. Bigger AOE attack (cooldown included)
/// 4. Auto attack
/// </summary>

public class PlayerController : MonoBehaviour
{
    // movement speed of player
    public float speed = 10f;

    // damage that the player will do
    public int damage = 10;

    // cooldown until you can use the ability again
    public float cooldown;

    // first player ability
    public KeyCode ability1 = KeyCode.E;
    public int radius1 = 2;

    // second player ability
    public KeyCode ability2 = KeyCode.Q;
    public int radius2 = 5;

    // inputaction to tell which keys to press
    public FeatureProjectFinal2024 controls;

    // enemy rb and transform
    Rigidbody enemyBody;
    public Transform enemy;

    // distances/location for the pull mechanic
    public float pullRange;
    public float pullInt;
    public float distToEn;
    Vector3 pullForce;

    // the move direction for player across vector2
    Vector2 moveDir = Vector2.zero;

    // creating the rb for player
    public Rigidbody rb;

    // for movement
    private InputAction movement;
    // for firing/auto attacking
    private InputAction fire;

    // requirement for inputsystem
    private void OnEnable()
    {
        movement = controls.Player.Move;
        movement.Enable();

        fire = controls.Player.Fire;
        fire.Enable();
        // register fire method to the event
        fire.performed += Fire;
    }
    // requirement for inputsystem
    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    private void Awake()
    {
        // initializes the script
        controls = new FeatureProjectFinal2024();
    }

    // Start is called before the first frame update
    void Start()
    {
        // gets the rigidboy for the enemy
        enemyBody = enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // pulls the WASD value
        moveDir = movement.ReadValue<Vector2>();

        /*distToEn = Vector3.Distance(enemy.position, transform.position);
        if (distToEn < pullRange)
        {
            pullForce = (transform.position - enemy.position).normalized / distToEn * pullInt;
            enemyBody.AddForce(pullForce, ForceMode.Force);
        }
        */
    }

    private IEnumerator pullAttack()
    {
        distToEn = Vector3.Distance(enemy.position, transform.position);
        if (distToEn < pullRange)
        {
            pullForce = (transform.position - enemy.position).normalized / distToEn * pullInt;
            enemyBody.AddForce(pullForce, ForceMode.Force);
            yield return new WaitForSeconds(.1f);
        }
        yield return null;
    }

    /* NOTE: Will be for the particles of the first attack
    private IEnumerator attack1Particles()
    {
        yield return new WaitForSeconds(0.25f);
        attack1PartObj.SetActive(true);
        yield return new WaitForSeconds(5f);
        attack1PartObj.SetActive(false);
    }
    */

    /* NOTE: Will be for the particles of the second attack
    private IEnumerator attack2Particles()
    {
        yield return new WaitForSeconds(0.25f);
        attack2PartObj.SetActive(true);
        yield return new WaitForSeconds(15f);
        attack2PartObj.SetActive(false);
    }
    */

    private void FixedUpdate()
    {
        // adds movement and speed to the rigidbody
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        StartCoroutine(pullAttack());
        Debug.Log("pullAttack");
    }

}
