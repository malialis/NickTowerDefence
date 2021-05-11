using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    [SerializeField] private float timeBetweenWaves = 5.0f;
    [SerializeField] private float spawnDelayTime = 0.25f;
    [SerializeField] private float countDown = 5.0f;
    public Text waveCountDownText;
    public Text waveIndexText;
    public GameObject waveIndexGO;

    [SerializeField] private int waveIndex = 0;
    [SerializeField] private int waveNumber = 0;


    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }


    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave is incoming");              

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelayTime);
        }

        waveIndex++;
        StartCoroutine(WaveAnnouncementText());

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private IEnumerator WaveAnnouncementText()
    {
        waveIndexGO.SetActive(true);
        waveIndexText.text = "Wave " + waveIndex + " is Coming";
        yield return new WaitForSeconds(3.0f);
        waveIndexGO.SetActive(false);

    }


}
