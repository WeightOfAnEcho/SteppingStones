using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Finale : MonoBehaviour
{

    public BT_WaterList check; // a public variable for the button press script
    public Animator finaleAnim;
    public BT_ScreenShaker shake;
    public bool towerAnimated = false;
    public GameObject dustPoof;
    public BT_DynamicCamera dynamicCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check.waterPresent == true) // check if the water is flowing (boolean from the button press script variable)
        {
            StartCoroutine("WaitFor", 11); // Start coroutine for delay - requires int value to be passed
        }
    }

    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);
        

        if(towerAnimated == false)
        {
            AnimateTower();
        }

    }

    IEnumerator WaitForMonument(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);

        AnimateTower();
    }

    void AnimateTower()
    {
        finaleAnim.SetBool("TriggerRaise", true);
        shake.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(dustPoof, transform.position, transform.rotation);
        dynamicCamera.camera_move_enabled = true;
        gameObject.SetActive(false);
    }



}
