using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class CliccaOggetti : MonoBehaviour
{
    //Script che gestisce gli oggetti nel minigioco dove bisogna cliccarli prima che cadano
    //Associato ai prefab della scena RaccogliOggetti
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private float zSpawnPos = -0.8f;
    //punteggio diverso a seconda dell' oggetto
    public int punteggio = 0;
    public GameManager GameManager;
    //aggiungo degli effetti di particelle per indicare che l' oggetto è stato colpito
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        //applico forza verticale perchè voglio che gli oggetti vadano verso l' alto
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        //rotazione degli oggetti
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //posizione degli oggetti
        transform.position = RandomSpawnPos();
        //cerco il gamemanager con il tag
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos,zSpawnPos);

    }
    
    //quando clicco l'oggetto viene distrutto
    private void OnMouseDown()
    {
        Debug.Log("Mouse");

        //se la partita è finita(timer a 0) non posso più agire sugli oggetti e cambiare il punteggio
        if(GameManager.timer > 0 && GameManager.vinto == false && GameManager.perso == false)
        {
            
            Destroy(gameObject);
            //la posizione è la stessa di dove si trovava l' oggetto
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.AggiornaPunti(punteggio);
        }
       
    }
    /*se l' oggetto non si vede più nello schermo viene tolto dalla memoria
    il collider di LimiteY lo ho allargato anche sulle z inferiori a 0(cambiando la visuale
    degli assi) perchè alcuni oggetti andavano lì e non venivano distrutti
    */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    

}



