using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image UIHealthFrame;
    public Image UIHealthBar;

    private Ruby ruby;
    // Start is called before the first frame update
    void Start()
    {
        ruby = GameObject.FindGameObjectWithTag("Player").GetComponent<Ruby>();
    }


    void Update()
    {
        UIHealthBar.fillAmount = (float)ruby.currentHP / (float)ruby.HP;
    }
}
