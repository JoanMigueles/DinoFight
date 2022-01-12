using UnityEngine;

public class SpawneableFruits : MonoBehaviour
{
    public float cooldown;
    public GameObject[] fruitPrefabs;

    private bool[] posUsing;

    private Vector3[] spawnPoints;

    void Start()
    {
        InitSpawns();
    }

    private void SpawnFruit()
    {
        if (transform.childCount < 21)
        {
            int fruit = Random.Range(0, 5);
            GameObject go = Instantiate(fruitPrefabs[fruit], transform);
            int pos = Random.Range(0, 20 - transform.childCount);
            bool encontrado = false;
            int i = 0; int realPos = 0;
            while (!encontrado)
            {
                if (posUsing[i] == false)
                {
                    if (realPos == pos)
                    {
                        go.transform.position = spawnPoints[i];
                        encontrado = true;
                        posUsing[i] = true;
                    }
                    realPos++;
                }
                i++;
            }
        }
    }

    private void InitSpawns()
    {
        posUsing = new bool[21];
        for (int i = 0; i < 21; ++i) posUsing[i] = false;

        spawnPoints = new Vector3[21];
        spawnPoints[0] = new Vector3(-7.6f, 0.4f, 1f);
        spawnPoints[1] = new Vector3(-6.8f, -0.4f, 1f);
        spawnPoints[2] = new Vector3(-6f, 1.2f, 1f);
        spawnPoints[3] = new Vector3(-6f, -1.2f, 1f);
        spawnPoints[4] = new Vector3(-4.4f, 1.2f, 1f);
        spawnPoints[5] = new Vector3(-4.4f, -1.2f, 1f);
        spawnPoints[6] = new Vector3(-3.6f, -2.8f, 1f);
        spawnPoints[7] = new Vector3(-2.8f, -3.6f, 1f);
        spawnPoints[8] = new Vector3(-2f, 2f, 1f);
        spawnPoints[9] = new Vector3(0.4f, 2.7f, 1f);
        spawnPoints[10] = new Vector3(0.4f, -1.2f, 1f);
        spawnPoints[11] = new Vector3(0.4f, 0.4f, 1f);
        spawnPoints[12] = new Vector3(2f, 0.4f, 1f);
        spawnPoints[13] = new Vector3(2f, -2f, 1f);
        spawnPoints[14] = new Vector3(2.8f, -2f, 1f);
        spawnPoints[15] = new Vector3(-0.4f, -2f, 1f);
        spawnPoints[16] = new Vector3(4.4f, -1.3f, 1f);
        spawnPoints[17] = new Vector3(4.4f, -2.8f, 1f);
        spawnPoints[18] = new Vector3(6f, -1.3f, 1f);
        spawnPoints[19] = new Vector3(6f, -2.8f, 1f);
        spawnPoints[20] = new Vector3(7.6f, -2.8f, 1f);
    }

    public void LiberaPosicion(Vector3 pos)
    {
        for(int i = 0; i < 21; i++)
        {
            if (pos == spawnPoints[i]) posUsing[i] = false;
        }
    }

    public void IniciarJuego()
    {
        InvokeRepeating("SpawnFruit", cooldown, cooldown);
    }

    public void PararJuego()
    {
        CancelInvoke("SpawnFruit");
        for(int i =0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
