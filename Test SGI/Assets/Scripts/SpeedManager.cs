using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedManager : MonoBehaviour
{   
    public GameObject myHand;
    public bool UIbeingShowed;
    public PlayerMove playerMove; // Puesto en el inspector de Unity
    public TextMeshProUGUI speedText;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        this.UIbeingShowed = false;
        canvas = this.GetComponent<Canvas>();
        canvas.enabled = this.UIbeingShowed;


        speedText.text = "Speed: " + playerMove.getSpeed().ToString();
    }

    // Update is called once per frame
    void Update()
    {   //
        //print(myHand.transform.childCount);
        if ((Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.A)) && (myHand.transform.childCount == 2)) updateUI(); ; // Boton A
        if(UIbeingShowed && (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.B))) { // Boton B
            playerMove.increaseSpeed();
            writeSpeedText(playerMove.getSpeed());
        }
        if (UIbeingShowed && (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.D))) { // Boton D
            playerMove.decreaseSpeed();
            writeSpeedText(playerMove.getSpeed());
        }
    }

    void writeSpeedText(int speed)
    {
        speedText.text = "Speed: " + speed.ToString();
    }

    void updateUI()
    {
        this.UIbeingShowed = !this.UIbeingShowed;
        canvas.enabled = this.UIbeingShowed;
    }
}
