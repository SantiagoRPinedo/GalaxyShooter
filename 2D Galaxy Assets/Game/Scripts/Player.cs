using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour//herencia de MonoBehavior
{
    //VARIABLES
    [SerializeField]
    private GameObject laserPrefab;// Objeto para usar el prefab en el jugador
    [SerializeField]
    private GameObject tripleShootPrefab;// Objeto para usar el prefab en el jugador
    [SerializeField]
    private float timeShoot = 0.25f; //es el tiempo que dura un disparo

    public float speed = 5.0f;
    private float nextShoot = 0.0f;//para contar desde cero hasta el proximo disparo

    public bool tripleShoot = false;
    public int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // El codigo en Update se ejecuta una vez por frame
    void Update()
    {
        Movimiento();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Disparar();
        }
    }

    //FUNCIONES
    private void Movimiento(){
        float horizontalInput= Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Vector3(1,0,0) * 1 * speed
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);//Time.deltaTime nos da el tiempo en fps para el juego
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        //RESTRINGIR EN Y
        if (transform.position.y > 0){
            transform.position = new Vector3(transform.position.x,0,0);//(Posicion de x , posision de y , posicion de z)               
        }else if(transform.position.y < -4.2f){
            transform.position = new Vector3(transform.position.x , -4.2f , 0);//(Posicion de x , posision de y , posicion de z)                            
        }
        //RESTRINGIR POSISION EN X
        if (transform.position.x > 9.5f){
            transform.position = new Vector3((-9.24f) , transform.position.y , 0); //(Posicion de x , posision de y , posicion de z)    
        }else if(transform.position.x < -9.24f){
            transform.position = new Vector3((9.5f) , transform.position.y ,0);//(Posicion de x , posision de y , posicion de z)                    
        }
    }

    private void Disparar(){  
        if (Time.time > nextShoot){
            if (tripleShoot){ 
                //Si se puede disparar Crear el laser
                Instantiate(tripleShootPrefab, transform.position,Quaternion.identity);
                nextShoot = Time.time + timeShoot;// para que se sume el tiempo que dura el disparo y se bloquee por ese tiempo
            }else{
                //Si se puede disparar Crear el laser
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f,0) ,Quaternion.identity);//se coloca la posicion del jugador con transform.position y se le suma el desplazamiento en y
                nextShoot = Time.time + timeShoot;// para que se sume el tiempo que dura el disparo y se bloquee por ese tiempo
            }
        }
    }


    /*----------PARA LOS POWER UPS---------------*/
    //Inicio de sistema de COUNT DOWN
    public void TripleShootPowerUpOn(){
        tripleShoot =true;
        StartCoroutine(TripleShootPowerDownRoutine());
    }

    public IEnumerator TripleShootPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        tripleShoot = false;
    }
    //Fin de sistema de COUNT DOWN

    public void SpeedPowerUpOn(){
        speed = 15.0f;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public IEnumerator SpeedPowerDownRoutine(){
        yield return new WaitForSeconds(10.0f);
        speed = 5.0f;
    }
}


