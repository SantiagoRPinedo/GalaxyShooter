using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject enemigo;

    private float speed=6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        Movimiento();
    }

    //Funciones 
    private void Movimiento(){
        //mover par abajao
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //Verificar si se salio de la pantalla
        if (transform.position.y < -7.0f){
            SpawnEnemigo();
        }
    }
    private void SpawnEnemigo(){
        float posicionX =Random.Range(-8f, 8f);
        // Establecer la posición del objeto arriba de la pantalla en la posición aleatoria de x
        transform.position = new Vector3(posicionX, 8f , 0f);
    }

    /*Para la animacion de explosion*/
    

    //PARA LAS COLISIONES 
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collided width:" + other.name);
        
        if(other.tag =="Player"){
            //Acceder al jugador
            Player player = other.GetComponent<Player>(); //Da acceso a metodos y variables publicas
            if (player != null){
                player.vidas = player.vidas -1;
            }
        }else if(other.tag =="Laser"){
            Destroy(this.gameObject);
        }
    }
}
