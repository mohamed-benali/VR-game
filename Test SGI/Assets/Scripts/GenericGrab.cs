using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GenericGrab : MonoBehaviour, IPointerClickHandler
{   
    public GameObject myHand;
    bool inHands = false;
    public GameObject objectInHand;
    void Start()
    {
    }

    void Update()
    {   // Soltar objeto
        if ((Input.GetKey(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.Space)) && inHands) // boton B
        {

            // Dejar la pelota en el sitio
            objectInHand.transform.SetParent(null);
            objectInHand.transform.localPosition = myHand.transform.position;

            inHands = false;

        }

        // Objeto más grande
        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.P) ) && inHands) // Boton atras arriba
        {   
            if ((objectInHand.transform.localScale.x < 0.6f) && (objectInHand.transform.localScale.y < 0.6f) && (objectInHand.transform.localScale.z < 0.6f))
            {
                objectInHand.transform.localScale += new Vector3(0.07f, 0.07f, 0.07f);
                //inHands = false;
            }
        }
        // Objeto más pequeño
        if ((Input.GetKey(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.M)) && inHands) // Boton atras abajo
        {
            if ((objectInHand.transform.localScale.x > 0.2f) && (objectInHand.transform.localScale.y > 0.2f) && (objectInHand.transform.localScale.z > 0.2f))
            {
                objectInHand.transform.localScale -= new Vector3(0.07f, 0.07f, 0.07f);
                //inHands = false;
            }
        }
        // Rotaçaaoo
        if ((Input.GetKey(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.R)) && inHands) // boton B
        {

                objectInHand.transform.Rotate(new Vector3(1.0f, 1.0f, 1.0f));
        }
    }
    // Detectar el clickaaaasoo de los eventos ai too wapos
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!inHands)
        { // coger la pelota
            // Le adoptamos
            gameObject.transform.SetParent(myHand.transform);
            // Solo le damos en adopción si tiene 3 hijos
            if (gameObject.transform.parent.transform.childCount == 3) {
                
            gameObject.transform.localPosition = new Vector3(0f, -.6f, 0f);
                inHands = true;
                objectInHand = gameObject;
            }
            else {
                // si tiene más o menos de 3 hijos, no le adoptamos
                gameObject.transform.SetParent(null);
                    }
        }

    }
}
