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

    // �G�o���̃R���[�`��
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10, 0);
            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0,360f), 0) * distanceVector;

            //�G���o�����������ʒu������
            var spawnPosition = playerStatus.transform.position + spawnPositionFromPlayer;

            //�w����W�����ԋ߂�navmesh�̍��W��T��
            NavMeshHit navMeshHit;
            if(NavMesh.SamplePosition(spawnPosition, out navMeshHit, 10, NavMesh.AllAreas))
            {
                //enemyPrefab�𕡐��ANavMeshAgent�͕K��NavMesh��ɔz�u����
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            //10�b�ҋ@
            yield return new WaitForSeconds(10);

            if(playerStatus.Life <= 0)
            {
                break;
            }
        }
    }
}
