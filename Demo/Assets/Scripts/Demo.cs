using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Demo : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField] private Text _text;
#pragma warning restore 0649

    private void Start()
    {
        _text.text = IPhone.Generation.ToString();
    }
}
