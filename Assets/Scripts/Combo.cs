using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{

    public static Combo instance; 
    public Text comboText;

    int combo = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        comboText.text = combo.ToString() + " STREAK";
    }

    // Update is called once per frame
    public void AddStreak() {
        combo += 1;
        comboText.text = combo.ToString() + " STREAK";
    }
}
