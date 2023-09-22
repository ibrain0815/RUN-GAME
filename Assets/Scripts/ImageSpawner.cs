using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageSpawner : MonoBehaviour
{
    public GameObject ImagePrefab;
    public RunnerSpawner runnerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        runnerSpawner = FindAnyObjectByType<RunnerSpawner>();
        SpawnImage();

    }

    void SpawnImage()
    {
        for (int i = 0; i < runnerSpawner.RunnerPrefabs.Length; i++)
        {
            int childIndex = i;
            GameObject newImage = Instantiate(ImagePrefab, transform);
            newImage.GetComponent<Image>().sprite = runnerSpawner.runnerDatas[i].runnerImage;
            runnerSpawner.runnerPortraits.Add(newImage);
            newImage.SetActive(false);
           
        }
    }
}
