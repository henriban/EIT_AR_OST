using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Texture[] Textures;
    private int _textureIndex = 0; // Use this for initialization
    private Slider _slider;

    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.maxValue = Textures.Length - 1;
        _slider.onValueChanged.AddListener(setTexture);
        setTexture(_textureIndex);
    }

    void setTexture(float index)
    {
        RenderSettings.skybox.SetTexture("_MainTex", Textures[(int) index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _textureIndex < Textures.Length - 1)
        {
            RenderSettings.skybox.SetTexture("_MainTex", Textures[++_textureIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _textureIndex > 0)
        {
            RenderSettings.skybox.SetTexture("_MainTex", Textures[--_textureIndex]);
        }
    }
}