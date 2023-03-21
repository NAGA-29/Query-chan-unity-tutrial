using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // 敵出現のコルーチン
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10, 0);
            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0,360f), 0) * distanceVector;

            //敵を出現させたい位置を決定
            var spawnPosition = playerStatus.transform.position + spawnPositionFromPlayer;

            //指定座標から一番近いnavmeshの座標を探す
            NavMeshHit navMeshHit;
            if(NavMesh.SamplePosition(spawnPosition, out navMeshHit, 10, NavMesh.AllAreas))
            {
                //enemyPrefabを複製、NavMeshAgentは必ずNavMesh上に配置する
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            //10秒待機
            yield return new WaitForSeconds(10);

            if(playerStatus.Life <= 0)
            {
                break;
            }
        }
    }
}
