using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Camera myCamera; 
    public int speed =1; // Velocidad de movimiento

    public int speedStep;

    public float toggleAngle = 30.0f;

    public int maxSpeed = 5;
    //public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main; // Nuestra camara va a ser la camara principal
        this.speed = 1;
        this.speedStep = 2;
        maxSpeed = 5;

    }

    public void increaseSpeed()
    {
        //this.speed += speedStep;
        if (this.speed + speedStep > maxSpeed) this.speed = maxSpeed;
        else this.speed = this.speed + speedStep;


    }

    public void decreaseSpeed()
    {
        if (this.speed - speedStep < 1) this.speed = 1;
        else this.speed = this.speed - speedStep;
    }

    public int getSpeed()
    {
        return speed;
    }

    /**
     * Se mueve en la direccion en la que mira la camara, obviando el eje Y (vertical) para que no vuele.
     */
    void movePlayer(float deltaTime)
    {
        Vector3 direction = myCamera.transform.forward;
        //Debug.Log("Direction before " + direction); // Va bien para debugar
        //direction.y = 0; // No mover verticalmente
        //Debug.Log("Direction after " + direction);
        this.transform.Translate(direction * deltaTime * this.speed); // Moverse en la dirccion que mira la camara
    }




    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        // Cuando tenga el aparato, la letra se va a sustituir con el boton el mando.
        // He hecho la implementacion de moverse con 1 boton. 
        // Se mueve en la direccion en la que mira la camara, anulando el eje Y, para que solo se mueva por el camino.
        // Lo he hecho asi porque no se cuantos botones tendra el mando que nos daran. Y para que yo pueda hacer cosas es imprescindible 
        // poder probarlo. Si el cacharro que nos dan tiene joystick sera muy facil moverse en las 4 direcciones como dijimos.
        if (Input.GetKey(KeyCode.H) ) this.movePlayer(deltaTime);

        // Leaning
        if (myCamera.transform.eulerAngles.x >= toggleAngle && myCamera.transform.eulerAngles.x < 90.0f)
        {
            this.movePlayer(deltaTime*2);
        }

            //if (Input.GetButton("Fire1") ) this.movePlayer(deltaTime);

            // En modo VR 
            if (Input.GetKey(KeyCode.JoystickButton0)) this.movePlayer(deltaTime);        // Boton C
        //if (Input.GetKey(KeyCode.JoystickButton1)) this.movePlayer(deltaTime);        // Boton A
        // 
        //if (Input.GetKey(KeyCode.JoystickButton2)) this.movePlayer(deltaTime);        // Boton B
        //if (Input.GetKey(KeyCode.JoystickButton3)) this.movePlayer(deltaTime);        // Boton D
        //
        //if (Input.GetKey(KeyCode.JoystickButton6)) this.movePlayer(deltaTime);    // Boton Atras (Abajo)
        //if (Input.GetKey(KeyCode.JoystickButton7)) this.movePlayer(deltaTime);    // Boton Atras (Arriba)


        //if (Input.GetKey(KeyCode.JoystickButton4)) increaseSpeed(); ;        // Boton B
        //if (Input.GetKey(KeyCode.JoystickButton3)) decreaseSpeed(); ;        // Boton D
    }

    public void TeleportPlayer()
    {
        //this.player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }
}
