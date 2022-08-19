using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SureSayac : MonoBehaviour
{
    public float zamanSayaci=60;
    int candy = 0;
    public UnityEngine.UI.Text TimeText, CandyText;

    // Start is called before the first frame update
    void Start()
    {
        CandyText.text = "Candy : " + candy;
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        TimeText.text = "Time : " + (int)zamanSayaci;//virgüllerden kurtarmak için int yaptık.
    }

    public void sekerSayisi()
    {
        candy += 1;
        CandyText.text = "Candy : " + candy;
    }
    

}
