using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ManagerScript : MonoBehaviour {

    private GameObject hamburgerButton;

    private void Start()
    {
        hamburgerButton = GameObject.Find("SidemenyButton");
    }

	public void DisableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
        hamburgerButton.SetActive(true);
    }

    public void EnableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", true);
        hamburgerButton.SetActive(false);
    }

}
