using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour {

    public GameObject showFloorPanelButton;
    public GameObject floorPannel;

    public Sprite floorIcon;
    public Sprite activeFloorIcon;

    [Header("Buttons")]
    public Button floor1Button;
    public Button floor2Button;

    [Header("Floors")]
    public GameObject floor1;
    public GameObject floor2;

 

    void Start () {
        showFloorPanelButton.GetComponent<Button>().onClick.AddListener(OpenFloorPanel);
        floorPannel.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(CloseFloorPanel);

        floor1Button.onClick.AddListener(ShowFloor1);
        floor2Button.onClick.AddListener(ShowFloor2);

        CloseFloorPanel();
	}

    private void OpenFloorPanel() {
        floorPannel.SetActive(true);
        showFloorPanelButton.SetActive(false);
    }

    private void CloseFloorPanel() {
        floorPannel.SetActive(false);
        showFloorPanelButton.SetActive(true);
    }

    private void ShowFloor1() {
        
        floor1.GetComponent<Renderer>().enabled = false;
        floor2.GetComponent<Renderer>().enabled = false;

        SetActiveFloor(floor1Button);
    }

    private void ShowFloor2() {
        
        floor1.GetComponent<Renderer>().enabled = true;
        floor2.GetComponent<Renderer>().enabled = true;

        SetActiveFloor(floor2Button);
    }

    private void SetActiveFloor(Button floorButton) {
        RemoveImages();

        Image image = floorButton.transform.GetChild(0).GetComponent<Image>();
        image.sprite = activeFloorIcon;

        floorButton.transform.GetChild(1).GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
    }

    private void RemoveImages() {
        floor1Button.transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f);
        floor2Button.transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f);

        floor1Button.transform.GetChild(0).GetComponent<Image>().sprite = floorIcon;
        floor2Button.transform.GetChild(0).GetComponent<Image>().sprite = floorIcon;
    }
}
