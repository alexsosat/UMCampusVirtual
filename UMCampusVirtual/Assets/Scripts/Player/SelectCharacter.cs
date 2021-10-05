using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public static int characterIndex = 0;

    public void setCharacter(int index)
    {
        characterIndex = index;
    }

    public int getCharacter()
    {
        return characterIndex;
    }
}
