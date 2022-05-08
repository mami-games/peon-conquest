using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    public Canvas ui;

    private void OnMouseDown()
    {
        Select();
    }

    public void Select()
    {
        TownDirector.Select(this);
        ApplySelectedAppearence();
    }

    public void Unselect()
    {
        ApplyUnselectedAppearence();
    }

    private void ApplySelectedAppearence()
    {
        gameObject.GetComponent<Renderer>().material = selectedMaterial;
    }

    private void ApplyUnselectedAppearence()
    {
        gameObject.GetComponent<Renderer>().material = defaultMaterial;
    }
}
