using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatformController : MonoBehaviour
{
    [Header ("Color States")]
    public bool greenState = false;
    public bool blueState = false;
    public bool redState = false;
    public bool cyanState = false;
    public bool magentaState = false;
    public bool yellowState = false;
    public bool whiteState = false;

    [Header("Game Objects")]
    public GameObject blue;
    public GameObject red;
    public GameObject green;
	public GameObject cyan;
	public GameObject magenta;
	public GameObject yellow;
	public GameObject white;

    [Header("GameObj Layers")]
    public GameObject character;
    private GameObject moveLayerGreen;
    private GameObject moveLayerBlue;
    private GameObject moveLayerRed;
	private GameObject moveLayerCyan;
	private GameObject moveLayerMagenta;
	private GameObject moveLayerYellow;
	private GameObject moveLayerWhite;

    [Header ("Is Colliding")]
    public bool isCollidingGreen = false;
    public bool isCollidingBlue = false;
    public bool isCollidingRed = false;
	public bool isCollidingCyan = false;
	public bool isCollidingMagenta = false;
	public bool isCollidingYellow = false;
	public bool isCollidingWhite = false;

    // Use this for initialization

    void Start()
    {

        //10 = Invisible Platform Green
        //11 - Invisible Platform Blue
        //12 - Invisible Platform Red

        moveLayerGreen = GameObject.FindWithTag("Green");
        moveLayerBlue = GameObject.FindWithTag("Blue");
        moveLayerRed = GameObject.FindWithTag("Red");
        moveLayerCyan = GameObject.FindWithTag("Cyan");
        moveLayerMagenta = GameObject.FindWithTag("Magenta");
        moveLayerYellow = GameObject.FindWithTag("Yellow");
        moveLayerWhite = GameObject.FindWithTag("White");

        moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
        moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
    }

    void Update()
    {

        moveLayerGreen = GameObject.FindWithTag("Green");
        moveLayerBlue = GameObject.FindWithTag("Blue");
        moveLayerRed = GameObject.FindWithTag("Red");
        moveLayerCyan = GameObject.FindWithTag("Cyan");
        moveLayerMagenta = GameObject.FindWithTag("Magenta");
        moveLayerYellow = GameObject.FindWithTag("Yellow");
        moveLayerWhite = GameObject.FindWithTag("White");

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            if (greenState == true)
            {

                greenState = false;
                green.layer = 10;
                moveLayerGreen.layer = 10;
                //moveLayerGreen.GetComponent<Renderer>().enabled = false;
                moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);
            }
            else
            {
				if (isCollidingGreen == false)
                {
					if (!((isCollidingCyan == true && blueState == true) || (isCollidingYellow == true && redState == true) || (isCollidingWhite == true && magentaState == true)))
					{
						greenState = true;
						green.SetActive (true);
						green.layer = 8;
						moveLayerGreen.layer = 8;
						moveLayerGreen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
                    }
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C))
        {
            if (blueState == true)
            {

                blueState = false;
                blue.layer = 11;
                moveLayerBlue.layer = 11;
                moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);


            }

            else
            {
				if (isCollidingBlue == false)
				{
					if (!((isCollidingCyan == true && greenState == true) || (isCollidingMagenta == true && redState == true) || (isCollidingWhite == true && yellowState == true))) {
						//|| (isCollidingCyan == false && greenState == true) || (isCollidingMagenta == false && redState == true)
						blueState = true;
						blue.SetActive (true);
						blue.layer = 8;
						moveLayerBlue.layer = 8;
						moveLayerBlue.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
                    }
                }

            }
        }
		if (Input.GetKeyDown (KeyCode.J) || Input.GetKeyDown(KeyCode.Z)) {
			if (redState == true) {

				redState = false;
				red.layer = 12;
				moveLayerRed.layer = 12;
				moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .18f);

            } 
			else
			{
				if (isCollidingRed == false)
				{
					if (!((isCollidingYellow == true && greenState == true) || (isCollidingMagenta == true && blueState == true) || (isCollidingWhite == true && cyanState == true))) {
						//|| (isCollidingMagenta == false && blueState == true) || (isCollidingYellow == false && greenState == true)
						redState = true;
						red.SetActive (true);
						red.layer = 8;
						moveLayerRed.layer = 8;
						moveLayerRed.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
                    }
				}
			}
		}


			//Cores CMY +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			if (blueState == true && greenState == true)
			{
				
				cyanState = true;
				cyan.SetActive(true);
				cyan.layer = 8;
				moveLayerCyan.layer = 8;
				moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
        }

			else
			{
				cyanState = false;
				cyan.layer = 13;
				moveLayerCyan.layer = 13;
				moveLayerCyan.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        }




			if (redState == true && blueState == true) {
				magentaState = true;
				magenta.SetActive (true);
				magenta.layer = 8;
				moveLayerMagenta.layer = 8;
				moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);

        } 

			else {
				magentaState = false;
				magenta.layer = 14;
				moveLayerMagenta.layer = 14;
				moveLayerMagenta.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        }


			if (greenState == true && redState == true) {

				yellowState = true;
				yellow.SetActive (true);
				yellow.layer = 8;
				moveLayerYellow.layer = 8;
				moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
        } 

			else {
				yellowState = false;
				yellow.layer = 15;
				moveLayerYellow.layer = 15;
				moveLayerYellow.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        }

			if (greenState == true && blueState == true && redState == true) {
				whiteState = true;
				white.SetActive (true);
				white.layer = 8;
				moveLayerWhite.layer = 8;
				moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);

        } 

			else {
				whiteState = false;
				white.layer = 16;
				moveLayerWhite.layer = 16;
				moveLayerWhite.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, .08f);
        }
        }
    }


 
