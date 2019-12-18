using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
    //Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenLimitLeft = 15f;
    [SerializeField] float screenLimitRight = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //sem limite de tela
        //Vector2 paddlePos = new Vector2(mousePosition, transform.position.y);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        //Limite do paddle na tela + posição
        paddlePos.x = Mathf.Clamp((Input.mousePosition.x / Screen.width * screenWidthInUnits), screenLimitRight, screenLimitLeft);
        transform.position = paddlePos;

    }
}
