using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunerControl : MonoBehaviour
{
    //public float startSpd = 1, maxSpd = 10f, accel = 2;
    [SerializeField] RunnerData runnerData;
    public RunnerData RunnerData { set { runnerData = value; } get { return runnerData; } }

    public Rigidbody rb;
    Animator anim;
    public float currentSpd = 1;
    public bool isMove = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentSpd = runnerData.startSpd;
    }


    //void FixedUpdate()
    //{
    //    if (isMove)
    //    {
    //        rb.MovePosition(transform.position + transform.forward * currentSpd * Time.deltaTime);
    //        Accelator();
    //        Debug.Log(Time.deltaTime);
    //    }
    //}

    void Update()
    {
        if (isMove)
        {
            rb.MovePosition(transform.position + transform.forward * currentSpd * Time.deltaTime);
            Accelator();
            //Debug.Log(Time.deltaTime);
        }
    }

    void Accelator()
    {
        if (currentSpd < runnerData.maxSpd) currentSpd += runnerData.accel * Time.deltaTime;
        else if (currentSpd > runnerData.maxSpd) currentSpd = runnerData.maxSpd;
    }
    [ContextMenu("Run")]
    public void Run()
    {
        isMove = true;
        anim.SetBool("isRun", true);


    }

    [ContextMenu("Stop")]

    public void StopRun()
    {
        currentSpd = runnerData.startSpd;
        isMove = false;
        anim.SetBool("isRun", false);
        anim.SetBool("isWin", false);
    }

    [ContextMenu("Win")]
    public void Win()
    {
        anim.SetBool("isWin", true);
    }
}
