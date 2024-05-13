using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script ha bisogno che in tale oggetto ci sia un characterController che non si può rimuovere
//Così nel getcomponent trova sempre qualcosa
[RequireComponent(typeof(CharacterController))]

public class Controller : MonoBehaviour
{
    //sono pubbliche solo le cose a cui altre classi possono accedere
    //se è privato nell' inspector non si vede
    private CharacterController _characterController;
    private Transform _transform;
    private Transform _cameraTransform;
    public float movementSpeed=1f;
    public float mouseXSpeed=20f;
    public float mouseYSpeed = 20f;
    public Vector2 mouseYClamp;
    public AudioSource helloAudio;
    public AudioSource jumpAudio;
    public AudioSource camminataAudio;
    //il personaggio deve cadere se non ha punti di appoggio
    public float fallingSpeed;
    //variabile che stabilisce se il personaggio può muoversi o no
    //quando c' è l' introduzione della storia non può
    int gioco=0;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
        //la camera è figlia dello studente per avere la visuale in prima persona
        //prendo il transform della camera
        _cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
        
    }
    //tenere traccia della rotazione
    private float currentMouseY;
    // Update is called once per frame
    //FPS controller gli assi sono quelli su build settings
    void Update()
    {
        gioco = PlayerPrefs.GetInt("gioco");
        
        if (gioco==1)
        {
            //il nome deve essere lo stesso del file che si vuole riprodurre
            //AudioManager.instance.PlaySFX("");
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");
            //ho fatto questo if altrimenti non suonava
            if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
            {
                camminataAudio.gameObject.SetActive(true);
                camminataAudio.Play();
            }
            //usiamo assi x e z perchè su Unity è Y up     
            Vector3 movement = new Vector3(movementX, 0f, movementY);
            //Normalize normalizza quel vettore
            if (movement.magnitude > 1f)
            {
                movement.Normalize();
            }
            //Time.deltaTime*movementSpeed è tra () così è più efficiente perchè si fa prodotto con il vettore una sola volta
            movement *= (Time.deltaTime * movementSpeed);
            
            //se non tocca niente deve cadere verso il basso
            if (!_characterController.isGrounded)
            {
                movement.y -= fallingSpeed * Time.deltaTime;
            }
            //il movimento deve essere locale non globale
            movement = _transform.TransformDirection(movement);
            _characterController.Move(movement);
            
            //movimento mouse
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            mouseX *= Time.deltaTime * mouseXSpeed;
            mouseY *= Time.deltaTime * mouseYSpeed;
            //una rotazione fatta sul charactercontroller e una sulla camera
            _transform.Rotate(Vector3.up, mouseX, Space.Self);
            currentMouseY += mouseY;
            currentMouseY = Mathf.Clamp(currentMouseY, mouseYClamp.x, mouseYClamp.y);
            //la rotazione del mouse deve avere un limite altrimenti vedo cose che non dovrei vedere
            _cameraTransform.localRotation = Quaternion.Euler(currentMouseY, 0f, 0f);
            //se premo c e v insieme parte l' animazione del saluto con l'audio
            if (Input.GetKeyDown(KeyCode.C) && Input.GetKeyDown(KeyCode.V))
            {
                helloAudio.gameObject.SetActive(true);
                helloAudio.Play();
                

            }

            //se premo J il personaggio salta, non può saltare più volte mentre è in aria
            //9.287883 è la posizione di base del giocatore
            //10.72256 è la posizione di quando sta sopra l' appoggio della cattedra
            if (Input.GetKeyDown(KeyCode.J) && (_transform.position.y == 9.287883f || _transform.position.y == 10.72256f))
            {


                float jumpForce = 7;
                //GetComponent<Rigidbody>().AddForce(Vector3.up*jumpForce);
                Vector3 saltovettore = Vector3.up * jumpForce;
                saltovettore = _transform.TransformDirection(saltovettore);
                _characterController.Move(saltovettore);
                jumpAudio.gameObject.SetActive(true);
                jumpAudio.Play();

            }
        }
        
       
    }
}
