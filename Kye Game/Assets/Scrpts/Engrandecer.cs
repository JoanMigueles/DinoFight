using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engrandecer : MonoBehaviour
{
    public float engrandecer;
    public float duracion;

    private Transform tr;
    private Vector3 sizeTr;
    private bool activado;

    private void Start()
    {
        tr = GetComponent<Transform>();
        sizeTr = tr.localScale;
        activado = false;
    }
    public void Activar()
    {
        CancelInvoke("Desactivar");
        if (tr.localScale == sizeTr)
        {
            tr.localScale *= engrandecer;
            activado = true;
        }
        Invoke("Desactivar", duracion);
    }
    private void Desactivar()
    {
        tr.localScale = sizeTr;
        activado = false;
    }
    public bool getGrande()
    {
        return activado;
    }
}
