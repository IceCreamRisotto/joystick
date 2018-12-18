using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analogy : MonoBehaviour {

    public RectTransform handle;
    public RectTransform rect;
    private bool dragging = false;


    public float speed = 6;
    public Transform obj;

    private Animator animator;

    private void Awake()
    {
        animator = GameObject.Find("chicken").GetComponent<Animator>();
    }

    private void Update()
    {
        Drog();
    }

    public void StartDrag() {
        dragging = true;
        animator.SetBool("run",true);
    }

    public void Drog() {//執行拖曳中
        if (!dragging) { return; }
        Vector2 newPos = (Vector2)Input.mousePosition - rect.anchoredPosition;
        Vector2 pos = Vector2.ClampMagnitude(newPos, 42f);
        handle.anchoredPosition = pos;

        //物體移動
        Vector2 dir = (pos / 42f) * speed * Time.deltaTime;
        state(newPos);//物體轉向

        animator.speed = newPos.magnitude / 42f;

        obj.Translate(dir);
    }

    public void StopDrag() {
        dragging = false;
        handle.anchoredPosition = Vector2.zero;
        animator.SetBool("run", false);
        animator.speed = 1f;
    }

    private void state(Vector2 newPos){//物體轉向
        if(newPos.x>0f)
        obj.transform.localScale = new Vector3(-1f, 1f, 1f);//右
        else
        obj.transform.localScale = new Vector3(1f, 1f, 1f);//左
    }
}
