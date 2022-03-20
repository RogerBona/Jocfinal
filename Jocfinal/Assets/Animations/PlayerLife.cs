using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    Animator animator;

    // variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isDeathHash;

    public Text txtCoins;

    bool dead = false;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!dead)
        {
            Debug.Log("Player collision trig");
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy trig");
                Die();
            }
            else if (collision.gameObject.CompareTag("Launcher"))
            {
                if(txtCoins.text == "Coins: 10"){
                    Debug.Log("Launcher trig");
                    SceneManager.LoadScene("Scene2");
                }
            }
            else if (collision.gameObject.CompareTag("Launcher2"))
            {
                Debug.Log("Launcher trig");
                SceneManager.LoadScene("Scene3");
            }
        }
    }

    void Die()
    {
        animator = GetComponent<Animator>();
        // set the parameter hash references
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isDeathHash = Animator.StringToHash("isDeath");
        animator.SetBool(isWalkingHash, false);
        animator.SetBool(isRunningHash, false);
        animator.SetBool(isJumpingHash, false);
        animator.SetBool(isDeathHash, true);
        Invoke(nameof(ReloadLevel), 2.0f);
        dead = true;
        deathSound.Play();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
