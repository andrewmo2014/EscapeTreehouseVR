using UnityEngine;
using System.Collections;

public class ToolboxController : MonoBehaviour {

    public enum ToolboxState
    {
        Idle,
        MovingDown,
        MovingUp
    }

    private bool activated;
    private bool isPlaying;

    public ToolboxState currentState = ToolboxState.Idle;
    private Vector3 origin;
    private Vector3 endPos;

    public float targetYPos;
    public float speed = 20.0f;

    public GameObject item;

    public Transform itemSpawn;

    public ButtonController buttonController;

	// Use this for initialization
	void Start () {

        activated = true;
        isPlaying = false;
        currentState = ToolboxState.Idle;
        origin = transform.position;
        endPos = new Vector3(origin.x, targetYPos, origin.z);

	}
	
	// Update is called once per frame
	void Update () {

        if ( Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().Play();
        }

        if (currentState == ToolboxState.Idle)
        {
            transform.position = origin;
        }

        if (currentState == ToolboxState.MovingDown)
        {
            if(isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
                isPlaying = true;
            }

            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, move);
            if (Vector3.Distance( transform.position, endPos) <= 0.1f)
            {
                transform.position = endPos;
                currentState = ToolboxState.MovingUp;
            }
        }

        if (currentState == ToolboxState.MovingUp)
        {
            float move = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, origin, move);
            if ( Vector3.Distance( transform.position, origin) <= 0.1f)
            {
                GetComponent<AudioSource>().Stop();
                isPlaying = false;

                transform.position = origin;
                currentState = ToolboxState.Idle;

                GameObject currentItem = (GameObject)Instantiate(item, itemSpawn.position, itemSpawn.rotation);

                buttonController.ActivateButton();
            }
        }



    }

    public void ActivatePulley( bool state)
    {
        currentState = (state) ? ToolboxState.MovingDown : ToolboxState.Idle;
    }

    public void SetItem( GameObject newItem)
    {
        item = newItem;
    }

}
