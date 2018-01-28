using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBehaviours : MonoBehaviour
{
    public Sprite[] Numbers;
    public GameObject Minutes;
    public GameObject FirstSecond;
    public GameObject SecondSecond;

    public int Seconds;
    public int AssignedMinutes;
    private float delta;
    private int count;

    private IEnumerator EndGameInSec()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(6f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		delta += Time.deltaTime;
        if(delta >= 1 )
        {
            Seconds -= 1;
            delta = 0;
            count -= 1;
            if (count<0)
            {
                count = 9;
            }
        }

        Clock();
	}

    void Clock()
    {
        if (Seconds <= 0)
        {
            Minutes.GetComponent<Image>().sprite = Numbers[0];
            FirstSecond.GetComponent<Image>().sprite = Numbers[0];
            SecondSecond.GetComponent<Image>().sprite = Numbers[0];
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
            StartCoroutine("EndGameInSec");
        }
        else
        {

            int resoult = Seconds / 60;
            Minutes.GetComponent<Image>().sprite = Numbers[resoult];

            int resoult2 = (Seconds % 60) / 10; //-*10
            FirstSecond.GetComponent<Image>().sprite = Numbers[resoult2];

            SecondSecond.GetComponent<Image>().sprite = Numbers[count];
        }

        
    }
}
