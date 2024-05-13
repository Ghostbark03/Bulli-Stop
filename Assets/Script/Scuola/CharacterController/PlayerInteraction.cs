using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //capisce se il mirino al centro dello schermo sta toccando un oggetto(Raycast)
    //metodo statico può essere chiamato senza istanza 
    //Ray= combinazione punto di origine e direzione
    [SerializeField] private Camera _camera;
    public float rayCastDistance=5f;
    private void Start()
    {
        //all' inizio il puntatore del mouse è bloccato e non visibile
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        //prendo in input Vector3 anche se la z viene ignorata dato che lo schermo è bidirezionale
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //RaycastHit ha informazioni riguardo ciò che il mirino colpisce
        if(Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayCastDistance))
            {
                //stampo nome dell' oggetto colpito
                Debug.Log(hitInfo.collider.gameObject.name);
            }
        }
        
    }
}
