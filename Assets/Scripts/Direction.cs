using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Direction : MonoBehaviour, IDragHandler
{
    private float _y;
    public Transform RotationTarget;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("ARmap");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var x = RotationTarget.localEulerAngles.y - (eventData.delta.x) / 10;
        _y += eventData.delta.y / 10;
        _y = Mathf.Clamp(_y, -90, 90);
        RotationTarget.localEulerAngles = new Vector3(_y, x, 0);
    }
}