using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] float distanciaDeteccion = 0.1f;
    [SerializeField] int fuerza = 100;
    [SerializeField] Transform posPies;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update () {
            if (Input.GetKeyDown("space") && EstoyEnsuelo())
            {
                rb.AddForce(new Vector3(0, 1, 0.25f) * fuerza);
            }
            else if (Input.GetKeyDown("z") && EstoyEnsuelo())
            {
                rb.AddForce(new Vector3(-1, 1, 0) * fuerza);
            }
            else if (Input.GetKeyDown("x") && EstoyEnsuelo())
            {
                rb.AddForce(new Vector3(1, 1, 0) * fuerza);
            }
    }

    private bool EstoyEnsuelo()
    {
        int layerIndex = LayerMask.GetMask("Terreno");
        bool enSuelo = false;
        //ALTERNATIVA CON CHECKSPHERE
        enSuelo = Physics.CheckSphere(
            posPies.position,
            distanciaDeteccion,
            layerIndex);
        Debug.Log("Esto en suelo (CheckSphere)?:" + enSuelo);
        //ALTERNATIVA CON OVERLAPSPHERE
        /*
        Collider[] cols = Physics.OverlapSphere(
            posPies.position,
            distanciaDeteccion,
            layerIndex);
        if (cols.Length > 0) enSuelo = true;
        Debug.Log("Estoy en suelo (OveralpSphere)?:" + enSuelo);
        */
        return enSuelo;
    }
}
