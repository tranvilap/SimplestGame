using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private Transform pipeSpawnPosition;
    [SerializeField] private float pipeSpawnPositionYFactor;
    [SerializeField] private float spawnInterval;

    [SerializeField] private Text scoreUI;

    private float spawnTimer = 0;
    private float score;
    private bool isGameStarting = true;

    public static GameManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarting) return;

        spawnTimer += Time.deltaTime;
        score += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            SpawnPipe();
        }
    }

    public void GameStart()
    {
        isGameStarting = true;
        score = 0;
        spawnTimer = 0;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        scoreUI.text = score.ToString();
        scoreUI.gameObject.SetActive(true);
        isGameStarting = false;
    }

    private void SpawnPipe()
    {
        var newPipe = Instantiate(pipePrefab);
        var newPos = pipeSpawnPosition.position;
        newPos.y = Random.Range(-pipeSpawnPositionYFactor, pipeSpawnPositionYFactor);
        newPipe.transform.position = newPos;
    }


}
