using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float gravityPower = .5f;

    // private static List<PlayerController> players;
    private static PlayerController me;

    public float moveSpeed;
    public float mouseSensitivity;
    private CharacterController controller;

    // public static List<PlayerController> GetPlayers()
    // {
    //     return this.players;
    // }

    public static Vector3 GetPos()
    {
        // PlayerController selected = players[Random.Range(0, players.Count)];
        // return selected.transform.position;
        return me.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        // if ( players == null )
        //     players = new List<PlayerController>();
        // players.Add(this);
        me = this;
        HandleInit();
    }

    void HandleInit()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 moveAxis = Vector3.zero;
        moveAxis.x = Input.GetAxis("Horizontal");
        moveAxis.z = Input.GetAxis("Vertical");
        //Transform Direction is transforming the moveAxis position based on the GameObject direction instead of the world;
        moveAxis = transform.TransformDirection(moveAxis);
        moveAxis.y -= gravityPower;
        controller.Move(moveAxis * this.moveSpeed * Time.deltaTime);

        Vector3 angles = transform.localEulerAngles;
        float angleV = Input.GetAxis("Mouse X");
        float angleH = Input.GetAxis("Mouse Y");
        //Y because left and right in mouse is rotate based on Y pivot
        angles.y += ( angleV * mouseSensitivity * Time.deltaTime);
        //X because up and down in mouse is rotate based on X pivot
        angles.x -= ( angleH * mouseSensitivity * Time.deltaTime);
        transform.localEulerAngles = angles;

        // Debug.Log(moveAxis);
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.GetComponent<EnemyController>()) UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
