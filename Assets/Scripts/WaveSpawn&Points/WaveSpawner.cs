using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    /*    [SerializeField]*/
    private TextMeshProUGUI waveCountdownText;

    private float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    private void Awake() {
        waveCountdownText = FindObjectOfType<TextMeshProUGUI>();
    }


    private void Update() {
        WaveIncomingTime();

    }

    private void WaveIncomingTime() {
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
