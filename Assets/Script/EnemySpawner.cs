using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _emeny;
    [SerializeField] private Vector3[] _positions;

    private int _quantityPositions;

    private void Start()
    {
        _quantityPositions = _positions.Length;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float delayTime = 2;
        WaitForSeconds delay = new WaitForSeconds(delayTime);

        while (true)
        {
            int index = Random.Range(0, _quantityPositions);

            Enemy newEnemy = Instantiate(_emeny, _positions[index], Quaternion.identity);

            yield return delay;

            Destroy(newEnemy.gameObject);
        }
    }
}