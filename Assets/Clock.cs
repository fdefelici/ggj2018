using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public int Seconds;
    public GameObject Minutes;
    public GameObject FirstSeconds;
    public GameObject SecondSeconds;
    public Numbers Numbers;
    public int MinutesAssigned;

    private int value;
    private float delta;
    private float delta2;

    private List<Sprite> sprites;

    void Start()
    {
        sprites = new List<Sprite>();
        sprites.Add(Numbers.zero);
        sprites.Add(Numbers.one);
        sprites.Add(Numbers.two);
        sprites.Add(Numbers.three);
        sprites.Add(Numbers.four);
        sprites.Add(Numbers.five);
        sprites.Add(Numbers.six);
        sprites.Add(Numbers.seven);
        sprites.Add(Numbers.eight);
        sprites.Add(Numbers.nine);

        delta2 = 0;

        Minutes.SetActive(true);
        FirstSeconds.SetActive(true);
        SecondSeconds.SetActive(true);


    }

    void Update()
    {
        SpriteMinutes();
        SpriteSeconds();

        delta += Time.deltaTime;
        if(delta >= 1)
        {
            if (delta2 <= 0)
            {
                delta2 = 10;
            }
            Seconds -= 1;
            delta = 0;
            delta2 -= 1;         
        }

        if(Seconds == 0)
        {

        }

    }

    void SpriteMinutes ()
    {
        int result = Seconds / 60;
        
        Minutes.GetComponent<Image>().sprite = sprites[result];
        
    }

    void SpriteSeconds()
    {
        int result = (Seconds % 60) / 10;

        FirstSeconds.GetComponent<Image>().sprite = sprites[result];

        SecondSeconds.GetComponent<Image>().sprite = sprites[(int)delta2];
    }



}
