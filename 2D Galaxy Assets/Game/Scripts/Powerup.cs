using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private float _speed= 3.0f;
    [SerializeField]
    private int powerupID; //0=disparo triple, 1= speedbost, 2= escudo

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collided width:" + other.name);
        
        if(other.tag =="Player"){
            //Acceder al jugador
            Player player = other.GetComponent<Player>(); //Da acceso a metodos y variables publicas
            if (player != null){
                if (powerupID == 0){
                    //Cambiar el booleando del disparo triple a verdadero
                    player.TripleShootPowerUpOn();
                }else if (powerupID == 1){
                    //Habilitar velocidad 
                    player.SpeedPowerUpOn();
                }else if (powerupID == 2){
                    //Habilitar escudo 
                }
            }
            //Destruir al jugador
            Destroy(this.gameObject);
        }
    }

}
