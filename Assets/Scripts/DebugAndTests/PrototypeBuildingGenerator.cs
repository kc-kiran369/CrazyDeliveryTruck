using UnityEngine;


/// <summary>
/// Intended for use during production only
/// </summary>
public class PrototypeBuildingGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Buildings;

    public int Row = 10;
    public int Column = 10;

    public int DistanceBetweenHouses = 50;
    public int OffetFromOrigin = 10;

    private void Start()
    {
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                GameObject spawnedGameObject = Instantiate(Buildings[Random.Range(0, Buildings.Length )], new Vector3(i * DistanceBetweenHouses + OffetFromOrigin, 0, j * DistanceBetweenHouses + OffetFromOrigin), Quaternion.identity, transform);
                spawnedGameObject.transform.localScale = Vector3.one * 10;
                spawnedGameObject.AddComponent<BoxCollider>();
            }
        }
    }
}