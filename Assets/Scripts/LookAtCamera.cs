using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private GameObject mCamera;

    void Start() {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update () {
        transform.LookAt(transform.position + mCamera.transform.rotation * Vector3.forward, mCamera.transform.rotation * Vector3.forward);
	}
}
