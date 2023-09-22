using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSpawner : MonoBehaviour
{
    public GameObject togglePrefab;
    public RunnerSpawner runnerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        runnerSpawner = FindAnyObjectByType<RunnerSpawner>();
        SpawnToggle();
    }

   void SpawnToggle()
    {
        for (int i = 0; i < runnerSpawner.RunnerPrefabs.Length; i++)
        {
            int childIndex = i;
            GameObject newToggle = Instantiate(togglePrefab, transform); //ÇÁ¸®Æé ¼ÒÈ¯
            newToggle.GetComponent<Image>().sprite = runnerSpawner.runnerDatas[i].runnerImage;
            newToggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate { runnerSpawner.ToggleSpawnIndexArray(childIndex); });
        }
    }
    

}
