using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animation anim;
    private Collider col;
    private AudioSource audio;

    // private string walkAnim;
    // private string deathAnim;
    // private string idleAnim;

    //This is a native function to handle innate collision logic
    public void Hurt()
    {
        audio.Play();
        anim.Play("zombie_death_standing");
        
        enabled = false;
        
        col.enabled = false;
        //To disabled the enemies navigation logic
        agent.enabled = false;

        //Trigger the gain kill score function in gamecontroller class
        GameController.GainKillScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        // foreach(AnimationState state in anim) {
        //     Debug.Log(state.name);
        // }
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = PlayerController.GetPos();
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.GetComponent<BulletController>()) 
        {
            // anim.Play("zombie_death_standing");
            //Bullet destroy
            Destroy(col.gameObject);
            //Zombie destroy
            // Destroy(gameObject);
            // Debug.Log("Enter");
        }
    }
}
