using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceItem : MonoBehaviour
{
    RaceEvent raceEvent;
    public string itemName;
    public GameObject[] fxPrefab;

    private void Awake()
    {
        raceEvent = GameManager.Instance.GetComponent<RaceEvent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") )
        {

                if (itemName == "sonic")
            {
                GameManager.Instance.itemSFX.Play();
                collision.gameObject.GetComponent<RunerControl>().rb.AddForce(Vector3.forward *50f,ForceMode.Impulse);
                Instantiate(fxPrefab[0], collision.transform.position + Vector3.up, Quaternion.Euler(180, 0, 0), collision.transform); //이펙트 인스턴스
                
            }
            if (itemName == "snail")
            {
                GameManager.Instance.itemSFX.Play();
                collision.gameObject.GetComponent<RunerControl>().currentSpd /= 2;
                Instantiate(fxPrefab[1], collision.transform.position + Vector3.up, Quaternion.Euler(180, 0, 0), collision.transform); //이펙트 인스턴스
                
            }

            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
