using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _emeny;
    [SerializeField] private Vector3[] _positions;

    private int _quantityPositions;

    private void Start()
    {
        _quantityPositions = _positions.Length;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int index = Random.Range(0, _quantityPositions);

        GameObject newEnemy = Instantiate(_emeny, _positions[index], Quaternion.identity);

        yield return new WaitForSeconds(2);

        Destroy(newEnemy);
        StartCoroutine(Spawn());
    }
}