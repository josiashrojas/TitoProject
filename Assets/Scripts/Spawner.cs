using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject objetoPrefab;  // Asigna aquí tu prefab desde el Inspector
    public Transform puntoSpawn;     // Punto de aparición (puede ser la posición del spawner)
    public float intervalo = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnearObjeto", 0f, intervalo);
    }

    void SpawnearObjeto()
    {
        Instantiate(objetoPrefab, puntoSpawn.position, puntoSpawn.rotation);
    }
}
