using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {


    public Material buttonON;
    public Material buttonOFF;

    public ToolboxController toolboxController;

    public bool buttonActive;

	// Use this for initialization
	void Start () {
        ActivateButton();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter( Collider col )
    {
        if( buttonActive )
        {
            buttonActive = false;
            GetComponent<MeshRenderer>().material = buttonOFF;
            toolboxController.currentState = ToolboxController.ToolboxState.MovingDown;
        }
    }

    public void ActivateButton()
    {
        buttonActive = true;
        GetComponent<MeshRenderer>().material = buttonON;
    }
}
