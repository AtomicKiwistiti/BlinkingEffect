using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //This will get the Renderer of the object
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //This line will start the blinking, first value, 5, is the duration, and 0.5f is the frequency
            StartCoroutine(Blinking(5,0.5f));
        }
    }

    IEnumerator Blinking(float duration, float blinkFrequency)
    {
        bool b = true;
        //This make sure the blinking last only as long as the duration, (for exampel 5sec) or else, it will last longer (around 7 seconds) due to the "WaitForSeconds(blinkFrequency);"
        var endTime = Time.time + (duration-duration*blinkFrequency);
        while (Time.time < endTime)
        {
            //the if make it so that one iteration the object is visible, and the other, invisible
            if (b)
            {
                b = false;
            }
            else if (!b)
            {
                b = true;
            }
            rend.enabled = b;
            //"pauses" the function or else it will just go through the code and we won't see the change, see it as the part responsible for the blink frequency
            yield return new WaitForSeconds(blinkFrequency);
        }
        //makes sure that when the coroutine ends, object is visible
        rend.enabled = true;
        yield break;
    }
}
