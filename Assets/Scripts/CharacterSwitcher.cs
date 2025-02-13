using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSwitcher : MonoBehaviour
{
    public static Action<Animator> OnSwitchCharacter;
    [SerializeField] private GameObject boyCharacter;
    [SerializeField] private GameObject girlCharacter;

    public void SwitchCharacter()
    {
        boyCharacter.SetActive(!boyCharacter.activeSelf);
        girlCharacter.SetActive(!girlCharacter.activeSelf);

        if(girlCharacter.activeInHierarchy)
        {
            OnSwitchCharacter?.Invoke(girlCharacter.GetComponent<Animator>());
        }
        if(boyCharacter.activeInHierarchy)
        {
            OnSwitchCharacter?.Invoke(boyCharacter.GetComponent<Animator>());
        }
        
    }
}
