using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelOutliner : MonoBehaviour
{
    [SerializeField] private GameObject modelNoOutline;
    [SerializeField] private GameObject modelOutline;

    void Start()
    {
        modelOutline.SetActive(false);
        modelNoOutline.SetActive(true);
    }

    void OnMouseOver()
    {
        Debug.Log("Entro");
        modelOutline.SetActive(true);
        modelNoOutline.SetActive(false);
    }

    void OnMouseExit()
    {
        Debug.Log("Salgo");
        modelOutline.SetActive(false);
        modelNoOutline.SetActive(true);
    }
}
