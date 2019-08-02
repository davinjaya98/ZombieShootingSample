using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public float shootRate;

    private Animator anim;
    private bool isShoot;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        //Shoot Animation
        if (Input.GetMouseButtonDown(0)) {
            isShoot = true;
            shootTimer = shootRate;
        }
        else if (Input.GetMouseButtonUp(0)) isShoot = false;
        else if (!Input.GetMouseButton(0)) isShoot = false;

        anim.SetBool("Shoot", isShoot);

        if(isShoot) {
            shootTimer += Time.deltaTime;
            if(shootTimer >= shootRate) {
                GameObject go = (GameObject)Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
                go.SetActive(true);
                shootTimer -= shootRate;
            }
        } 
    }
}
