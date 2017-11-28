using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthDraging : MonoBehaviour {

    public LineRenderer leftLineRenderer;
    public LineRenderer rightLineRenderer;
    public float maxStrechProjectile=3.0f;

    private SpringJoint2D spring;
    private bool isClicked= false;


    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
    }
	// Use this for initialization
	void Start () {
        LineRendereSetup();

	}
	
	// Update is called once per frame
	void Update () {
        LineRendererUpdate();

    }

    void LineRendereSetup()
    {
        leftLineRenderer.SetPosition(0,leftLineRenderer.transform.position);
        rightLineRenderer.SetPosition(0,rightLineRenderer.transform.position);

        leftLineRenderer.sortingLayerName = "ForeGround";
        rightLineRenderer.sortingLayerName = "ForeGround";

        leftLineRenderer.sortingOrder = 4;
        rightLineRenderer.sortingOrder = 1;

    }


    void OnMouseDown()
    {
        spring.enabled = false;
        isClicked = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        isClicked = false;
    }

    void LineRendererUpdate()
    {
        leftLineRenderer.SetPosition(1,Input.mousePosition);
        rightLineRenderer.SetPosition(1,Input.mousePosition);
    }
}
