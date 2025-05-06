using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego_vertical : MonoBehaviour

   {
    public float amplitud = 2f;        // Qué tan grande es el radio de movimiento
    public float velocidad = 2f;       // Velocidad de rotación
    public float fase = 0f;            // Desfase para posicionar en la cuerda
    public float intensidadCentro = 1f; // 1 en el centro, 0 en los extremos
    private Vector3 centro;
    public float incrementoVelocidad = 0.2f; // Velocidad aumenta por segundo
    private float velocidadActual;

    void Start()
    {
        velocidadActual = velocidad;
    }
    void LateUpdate()
    {
        
    transform.rotation = Quaternion.Euler(0, 0, 0);

    velocidadActual += incrementoVelocidad * Time.deltaTime; // Aumentar progresivamente

    float angulo = Time.timeSinceLevelLoad * velocidadActual + fase;
    float y = Mathf.Sin(angulo) * amplitud * intensidadCentro;
    float z = Mathf.Cos(angulo) * amplitud;
    float x = transform.localPosition.x;

    transform.localPosition = new Vector3(x, y, z);

    }
}