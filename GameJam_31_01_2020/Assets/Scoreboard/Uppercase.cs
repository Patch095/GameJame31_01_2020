using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uppercase : MonoBehaviour
{
    public InputField owner;
    public Text text;
    string baseString;
    string currentString;

    string inputName;

    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<InputField>();
        inputName = owner.textComponent.text;
        baseString = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        string newString = baseString + inputName;
        text.text = newString;
    }

    public void SetText()
    {
        string newName = owner.textComponent.text;

        if (newName.Length > 3)
        {
            char[] temp = new char[3];
            temp[0] = inputName[0];
            temp[1] = inputName[1];
            temp[2] = inputName[2];

            newName = new string(temp);
        }

        inputName = newName.ToUpper();
    }
}
