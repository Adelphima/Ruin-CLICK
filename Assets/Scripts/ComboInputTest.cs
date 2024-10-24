using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class ComboInputTest : MonoBehaviour
//{
//   public class UpCombo : MonoBehaviour; 

//    void Input.GetKeyDown (KeyCode k) {
//        Combo.instance.AddStreak();
//    } 
//}

public class ComboInputTest : MonoBehaviour
{
    // Assuming you have a Combo class with an instance and AddStreak method
    //public Combo combo; // Reference to your Combo class instance

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Combo.instance.AddStreak(); // Call AddStreak method when Up Arrow is pressed
        }
    }
}