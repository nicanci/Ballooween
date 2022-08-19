using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonOlusturma : MonoBehaviour
{
    public GameObject[] balonlar;

    private List<GameObject> balonlarlistesi = new List<GameObject>();

    float balonOlusturmaSuresi = 5f; //Balonların kaç saniye bir oluşmasını istediğimiz süre

    float zamansayaci=0f;
    

    SureSayac SSayacScripti;
    // Start is called before the first frame update
    private void Awake()
    {
        BalonlarıOlustur();
    }

    void Start()
    {
        StartCoroutine(RasgeleBalonOlustur());
        SSayacScripti = this.gameObject.GetComponent<SureSayac>();
    }

    // Update is called once per frame
    

    public void BalonlarıOlustur()
    {
        int sayi = 0;
        
        Vector3 lokasyon = new Vector3(Random.Range(-2.65f, 2.65f), -6, 0);
        
        
        {
            

            for (int i = 0; i <= balonlar.Length; i++)
            {
                //videoda obje=balon

                GameObject obje = Instantiate(balonlar[sayi], lokasyon, Quaternion.Euler(0, 0, 0)) as GameObject;
                obje.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 50f, 0));
                balonlarlistesi.Add(obje);


                balonlarlistesi[i].SetActive(false);

                sayi++;

                

                if (sayi == balonlar.Length)
                {

                    sayi = 0;
                    


                }

              

            }

            

        }
        

        
    }

    public void BalonKaristir()
    {
        for (int i = 0; i < balonlarlistesi.Count; i++)//count listedeki eleman sayısı
        {
            GameObject temp = balonlarlistesi[i];
            int rasgele = Random.Range(i, balonlarlistesi.Count);
            balonlarlistesi[i] = balonlarlistesi[rasgele];
            balonlarlistesi[rasgele] = temp;


        }
    }

    IEnumerator RasgeleBalonOlustur()

    {
        yield return new WaitForSeconds(Random.Range(1f, 2f)); //belli zaman aralıklı şeyler için yield kullanılıyor
        int sayi = Random.Range(0, balonlarlistesi.Count);

        while (true)
        {
            if (!balonlarlistesi[sayi].activeInHierarchy)
            {
                balonlarlistesi[sayi].SetActive(true);
                balonlarlistesi[sayi].transform.position = new Vector3(Random.Range(-2.65f, 2.65f), -6, 0);
                break;
            }

            else
            {
                sayi = Random.Range(0, balonlarlistesi.Count);

            }
        }

        StartCoroutine(RasgeleBalonOlustur());
    }

   
}