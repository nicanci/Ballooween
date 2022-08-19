using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonKontrol : MonoBehaviour
{
    public GameObject[] Animations;
    private List<GameObject> AnimasyonListesi = new List<GameObject>();
    int sayi_;
    SureSayac SureSayacScripti;

    void Start()
    {
        SureSayacScripti = GameObject.Find("_Scripts").GetComponent<SureSayac>();//suresayac sckriptine ulaşmak için yazıldı
    }

    public void OnMouseDown()
    {
        int sayi_ = Random.Range(0, Animations.Length); //rastgele animasyon çıkması için yazıldı

        GameObject go= Instantiate(Animations[sayi_], transform.position, transform.rotation) as GameObject;

        Destroy(this.gameObject);

        Destroy(go, 0.555f);

        if (GameObject.FindWithTag("Candy"))
        {
            SureSayacScripti.sekerSayisi();//sadece şekerleri sayması için hazırlandı
        }

    }

    private void OnTriggerEnter2D(Collider2D cll)
    {
        if (cll.tag == "BalonTemizleyici")
        {
            Destroy(gameObject);
        }
    }
}
