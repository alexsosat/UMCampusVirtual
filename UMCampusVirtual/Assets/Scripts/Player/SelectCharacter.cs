using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCharacter : MonoBehaviour
{
    private static int _characterIndex = 0;
    
    private static string _userName;

    public void setCharacter(int index)
    {
        _characterIndex = index;
    }

    public int getCharacter()
    {
        return _characterIndex;
    }

    public void SetUserName(TMP_InputField userNameField)
    {
        _userName = userNameField.text;
    }

    public string GetUserName()
    {
        return _userName;
    }

}
