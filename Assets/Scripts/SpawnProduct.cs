using UnityEngine;

public class SpawnProduct : MonoBehaviour {

    public GameObject product1;
    public GameObject product2;

    public GameObject imageTarget;

    void Start() {

        GameObject newObject = Instantiate(product1, new Vector3(0 , 0, 0), Quaternion.identity);
        //Instantiate(product2, new Vector3(1, 1, 1), Quaternion.identity);

        //newObject.transform.parent = imageTarget.transform;
        newObject.transform.SetParent(imageTarget.transform);
    }
}
