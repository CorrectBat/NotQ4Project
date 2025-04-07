using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryItem : MonoBehaviour, Clickable
{
    private bool isHeld;
    private Vector3 offset;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if(isHeld) {
            Drag();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            OnRelease();
        }
    }

    void Drag() {
        rigidbody.MovePosition(offset+Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnClick() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.GetComponent<Rigidbody2D>().gravityScale = 0;
        isHeld = true;
        rigidbody.excludeLayers = LayerMask.GetMask("Shelf");
        rigidbody.includeLayers = LayerMask.GetMask("Line");
    }

    public void OnRelease() {
        isHeld = false;
        transform.GetComponent<Rigidbody2D>().gravityScale = 1;
        rigidbody.includeLayers = LayerMask.GetMask("Shelf");
        rigidbody.excludeLayers = LayerMask.GetMask("Line");
    }
}
