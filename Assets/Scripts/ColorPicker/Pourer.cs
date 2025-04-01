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

        transform.position = new Vector3((startPosition.x+(xDistance*pourProgress)),
                                          startPosition.y+(yDistance*pourProgress), 0);
        transform.eulerAngles = new Vector3(0, 0, rotateAmount*pourProgress);

        if(pourProgress >= .26) {
            bucket.fill((pourProgress-.26f)*Time.deltaTime);
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
        liquidColor = color;
    }
}
