using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject cameraPrefab;
    public float moveSpeed = 5f;
    public float rotataSpeed = 150f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
            
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotataSpeed;
        transform.Rotate(0, x, 0);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("Start local player");
        //transform.position = new Vector3(Random.Range(100, 400), 0, Random.Range(100, 400));
        transform.FindChild("Snake").GetComponent<MeshRenderer>().material.color = Color.blue;

        Debug.Log("Generating player camera");
        var camera = (GameObject) GameObject.Instantiate(cameraPrefab, transform.position + new Vector3(0, 30, 0), Quaternion.identity);
        camera.transform.Rotate(90, 0, 0);
        camera.GetComponent<CameraController>().player = gameObject;
    }
}
