using UnityEngine;


/// <summary>
/// Intended for use during production only
/// </summary>
public class PrototypeBuildingGenerator : MonoBehaviour
{
    [SerializeField] GameObject Building;

    public int Row = 10;
    public int Column = 10;

    public int DistanceBetweenHouses = 10;
    public int OffetFromOrigin = 10;

    private void Start()
    {
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                GameObject spawnedGameObject = Instantiate(Building, new Vector3(i * DistanceBetweenHouses + OffetFromOrigin, 0, j * DistanceBetweenHouses + OffetFromOrigin), Quaternion.identity, transform);
                spawnedGameObject.transform.localScale = spawnedGameObject.transform.localScale + new Vector3(1 * Random.Range(1.0f, 3.0f), Random.Range(3, 15), 1 * Random.Range(1.0f, 3.0f));
            }
        }
    }
}