using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

    public GameObject diskPrefab;

    void Start () {
        for (int i = 0; i < 5000; i++)
        {
            GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
