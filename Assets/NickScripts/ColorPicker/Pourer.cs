using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pourer : MonoBehaviour, Clickable
{
    private float pourProgress;
    private bool mouseHeld;
    private Vector3 initialMousePosition;
    private Vector3 currentMousePosition;
    private Vector3 startPosition;
    private float xDistance;
    private float yDistance;
    private bool isPouring;
    private Color liquidColor;
    private GameObject corner;
    private float pourFactor = 2;
    [SerializeField] GameObject liquidSprite;
    [SerializeField] Vector3 finalPosition;
    [SerializeField] float rotateAmount;
    [SerializeField] int maxMouseDrag;
    [SerializeField] Bucket bucket;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        xDistance = finalPosition.x - startPosition.x;
        yDistance = finalPosition.y - startPosition.y;
        bucket.setNeededAmount(.7f);
        corner = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            OnRelease();
        }

        if(mouseHeld) {
            OnHeld();
        }
    }

    void OnHeld() {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pourProgress = (currentMousePosition.x-initialMousePosition.x)/maxMouseDrag;
        Pour();
    }

    void Pour() {

        if(pourProgress > 1) {
            pourProgress = 1;
        } else if (pourProgress < 0) {
            pourProgress = 0;
        }
        Vector3[] corners = GetCorners();

        liquidSprite.transform.position = new Vector2(corner.transform.position.x,
                                                      corner.transform.position.y-2);

        transform.position = new Vector3((startPosition.x+(xDistance*pourProgress)),
                                          startPosition.y+(yDistance*pourProgress), 0);
        transform.eulerAngles = new Vector3(0, 0, rotateAmount*pourProgress);


        if(pourProgress >= .4) {
            bucket.fill((pourProgress-.4f)*pourFactor*Time.deltaTime);
            liquidSprite.SetActive(true);
        } else {
            liquidSprite.SetActive(false);
        }
    }

    public void OnClick() {
        Debug.Log("Click");
        mouseHeld = true;
        isPouring = true;
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnRelease() {
        mouseHeld = false;
        isPouring = false;
        transform.position = startPosition;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public bool IsPouring() {
        return isPouring;
    }

    public void SetLiquidColor(Color color) {
        liquidSprite.GetComponent<SpriteRenderer>().color = color;
    }

    public Vector3[] GetCorners() {
        Vector3 topRight = GetComponent<Renderer>().transform.TransformPoint(GetComponent<Renderer>().bounds.max);
        Vector3 topLeft = GetComponent<Renderer>().transform.TransformPoint(new Vector3(GetComponent<Renderer>().bounds.max.x, GetComponent<Renderer>().bounds.min.y, 0));
        Vector3 botLeft = GetComponent<Renderer>().transform.TransformPoint(GetComponent<Renderer>().bounds.min);
        Vector3 botRight = GetComponent<Renderer>().transform.TransformPoint(new Vector3(GetComponent<Renderer>().bounds.min.x, GetComponent<Renderer>().bounds.max.y, 0));
        return new Vector3[] { topRight, topLeft, botLeft, botRight };
    }
}
