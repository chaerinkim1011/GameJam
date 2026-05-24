using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemySpawner : MonoBehaviour
{
    public EnemyMove enemyPrefab;
    public Transform player;
    public Vector2 spawnPosition = new Vector2(48f, -1.11f);
    public float spawnDelay = 3f;

    GameObject enemyTemplate;
    float spawnTimer;

    void Awake()
    {
        if (enemyPrefab == null)
            return;

        enemyTemplate = Instantiate(enemyPrefab.gameObject, spawnPosition, Quaternion.identity);
        enemyTemplate.SetActive(false);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer < spawnDelay)
            return;

        spawnTimer = 0f;

        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (enemyTemplate == null)
            return;

        GameObject enemyObject = Instantiate(enemyTemplate, spawnPosition, Quaternion.identity);
        enemyObject.SetActive(true);
        EnemyMove enemy = enemyObject.GetComponent<EnemyMove>();

        if (enemy != null && player != null)
            enemy.Player = player;
    }

    void OnDrawGizmos()
    {
        Vector3 position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(position, 0.5f);
        Gizmos.DrawLine(position + Vector3.left, position + Vector3.right);
        Gizmos.DrawLine(position + Vector3.down, position + Vector3.up);

#if UNITY_EDITOR
        Handles.Label(position + Vector3.up * 0.7f, "Enemy Spawn");
#endif
    }
}
