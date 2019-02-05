using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoyMovement : MonoBehaviour {

    [Header("Score Panel Controller")]
    public Text scoreTxt; 

    [Header("Physics Controller")]
	[SerializeField] private float speed = 2.0f;
    [SerializeField] private float gravity = 2.0f;

    [HideInInspector] public float jumpSpeed = 0.0f;
    [HideInInspector] public bool tenisPowerUp;

    public static bool gameStarted;
    public static float distanceTotal;

    private CharacterController controller;
    
    private float initialPosition;
    
    private Quaternion _playerRotation = Quaternion.identity;
    
    private Vector3 moveDirection = Vector3.zero;

    void Awake(){
        distanceTotal = 0;
    }

    void Start(){
        controller = GetComponent<CharacterController>();
        _playerRotation.eulerAngles = Vector3.zero;
        initialPosition = transform.position.y;
        tenisPowerUp = false;
        StartCoroutine(StartGame());
    }

    void Update(){
        if(!gameStarted){ return; }
        //When the player reach the limits, set a new position for him
        BoySetLimits();
        //Movement logic of the player
        BoyControllerMovement();
        //Set Physics to the player
        BoySetPhysics();
        //Set the score based on the distance of the player
        BoySetDistance();
    }

    void BoySetLimits(){
        if(transform.position.x < -1.295f){
            transform.position = new Vector3(1.284f, transform.position.y, 0);
        }
        else if(transform.position.x > 1.284f){
            transform.position = new Vector3(-1.295f, transform.position.y, 0);
        }
        
        if(transform.position.z > 0.022f || transform.position.z < 0.022f ){
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.022f);
        }
    }

    void BoyControllerMovement(){
        if(Input.GetAxis("Horizontal") < 0){
            _playerRotation.eulerAngles = new Vector3(0, 90, 0);
            transform.rotation = _playerRotation;
            // transform.Translate(0, 0, -Input.accelerometer.x*Time.deltaTime*speed);
            transform.Translate(0, 0, -Input.GetAxis("Horizontal")*Time.deltaTime);
        }
        else if(Input.GetAxis("Horizontal") > 0){
            _playerRotation.eulerAngles = new Vector3(0, -90, 0);
            transform.rotation = _playerRotation;
            transform.Translate(0, 0, Input.GetAxis("Horizontal")*Time.deltaTime);
        }
    }

    void BoySetPhysics(){
        if(controller.isGrounded){
            moveDirection = new Vector3(0, jumpSpeed, 0);
        }
        
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);
    }

    void BoySetDistance(){
        float tempDistance = Mathf.Round(transform.position.y - initialPosition);
        distanceTotal = (tempDistance > distanceTotal) ? tempDistance : distanceTotal;
        scoreTxt.text = distanceTotal.ToString();
    }

    //Collider logic
    void OnControllerColliderHit(ControllerColliderHit hit){
        try{
            jumpSpeed = tenisPowerUp ? GetComponent<BoyPowerUp>().powerUpTenis : hit.gameObject.GetComponent<Pillow>().JumpForce;
            try{
                if(!GetComponent<AudioSource>().isPlaying){
                    GetComponent<AudioSource>().Play();
                }
                hit.gameObject.GetComponent<Animator>().SetTrigger("Jump");
            }
            catch{}
        }
        catch{
            jumpSpeed = 0;
        }
    }

    IEnumerator StartGame(){
        gameStarted = false;
        yield return new WaitForSeconds(1.5f);
        gameStarted = true;
    }
}
