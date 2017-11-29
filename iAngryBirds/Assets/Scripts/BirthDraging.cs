using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthDraging : MonoBehaviour {

    public LineRenderer leftLineRenderer;
    public LineRenderer rightLineRenderer;
    public float maxStrechLimit=1.5f;
    public Transform SlingShot;

    private SpringJoint2D spring;
    private bool isClicked= false;
    private Ray mouseRay;
    private Rigidbody2D projectile;
    private Vector2 oldVelocity=new Vector2(10,10);


    void Awake()
    {
       
        spring = GetComponent<SpringJoint2D>();
        SlingShot = spring.connectedBody.transform;
        mouseRay = new Ray(SlingShot.position, Vector3.zero);
        projectile = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        
        LineRendereSetup();

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(projectile.velocity);
        if (isClicked)
        {
            LineRendererUpdate();
        }

        if (spring!=null)
        {
           
            if (!projectile.isKinematic && oldVelocity.sqrMagnitude>projectile.velocity.sqrMagnitude)
            {
                Destroy(spring);
                projectile.velocity = oldVelocity;
            }

            if (!isClicked)
            {
               // Debug.Log("step 2");
                oldVelocity = projectile.velocity;
            }
        }


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
        projectile.isKinematic = false;
        isClicked = false;
    }

    void LineRendererUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseToSligShot = mousePosition - SlingShot.position;
        if (mouseToSligShot.sqrMagnitude>maxStrechLimit*maxStrechLimit)
        {
            mouseRay.direction = mouseToSligShot;
            mousePosition = mouseRay.GetPoint(maxStrechLimit);

        }
        mousePosition.z = 0;
        transform.position = mousePosition;

       // leftLineRenderer.SetPosition(1,Input.mousePosition);
       // rightLineRenderer.SetPosition(1,Input.mousePosition);
    }
}
