using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Transform tr;
    // public 접근 제한자를 사용하면 Inspector 창에 노출이 된다.
    // 만약에 다른 클래스로부터의 접근은 제한하면서 Inspector 창에 노출시키고 싶으면 [[SerializeField] 속성을 사용한다.
    [SerializeField] private float speed = 1; // Inspector 창의 값이 초기화 값보다 우선순위이다.
    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // transform에 접근해서 좌표에 대한 데이터를 변경시켜도 되지만 굳이  Transform 멤버변수 tr 을 선언해서
        // Transform component를 대입한 후에 사용하는 이유는
        // 캐시 메모리 문제 때문 ( 캐시 : 임시로 연산이 용이하도록 생성한 메모리 )
        // transform을 사용하면 이 멤버변수를 호출 할 때 마다 gameObject에 접근해서 getComponent로 Transform 성분을 가져옴.
        // 하지만 Transform 멤버변수 tr에 한번 넣어두고 사용하면
        // tr 은 사용할 때마다 처음에 넣어줬던 Transform component 에 바로 접근하기 때문에
        // 동시에 아주 많은 게임오브젝트들의 Transform 컴포넌트를 써야 하면 그 때는 퍼포먼스에서 차이가 난다.

        tr = gameObject.GetComponent<Transform>(); // 제일 많이 사용하는 형태
        // transform.gameObject.GetComponent<Transform>();
        // tr = this.gameObject.GetComponent<Transform>();
        // tr = this.gameObject.transform;
        // tr = gameObject.transform;
    }

    // Update is called once per frame
    // Update는 매 프레임마다 호출 되는 함수
    void Update()
    {
        // Position
        // ========================================================================
        // 1 프레임당 z축 1씩 전진
        // 만약에 컴퓨터 사양이 달라서 하나는 60FPS, 다른 하나는 30FPS
        // -> 1초에 하나는 60만큼 전진하고, 다른 하나는 30만큼 전진
        // tr.position += new Vector3(0, 0, 1);

        // Time.deltaTime 은 직전 프레임과 현재 프레임 사이 걸린 시간
        // 즉, Time.deltaTime 을 곱해주면 기기 성능에 관계 없이 초당 같은 변화량을 가질 수 있다.
        // tr.position += new Vector3(0, 0, speed) * Time.deltaTime;

        // physics 관련 데이터를 처리할 때 자주 사용함.
        // tr.position += new Vector3(0, 0, 1) * Time.fixedDeltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h = " + h); // Z axis forward, backward
        Debug.Log($"v = {v}"); // X axis left, right

        // Z axis forward, backward
        // X axis left, right
        // Y axis up , down

        // tr.position += new Vector3(h, 0, v)* speed * Time.deltaTime;
        // 1프레임당 z축 1 * speed 전진
        // Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;
        // tr.Translate(movePos);
        // 동시에 여러축으로 움직였을 때 방향벡터의 크기가 1이 넘어가서 방향에 따라 속도가 일정하지 않다.
        // // Translate (이동함수) = 1프레임당 z축 1 * speed 전진 같은 말

        // Vector 방향과 크기를 모두 가지는 성질
        // 특히 Vector 크기가 1인 벡터를 단위백터(Unit Vector)라 한다.
        // 움직이고 싶은 방향에 대한 단위벡터 * 속도 로 물체를 움직임.
        Vector3 dir = new Vector3(h, 0, v).normalized;
        Vector3 moveVac = dir * speed * Time.deltaTime;
        // tr.Translate(moveVac);
        // 동시에 여러축으로 움직였을 때 방향벡터의 크기가 1이 넘어가니
        // normalized를 사용하여 다 일정하게 변경
        // tr.Translate(moveVac, Space.Self); // local 좌표계 기준 이동
        tr.Translate(moveVac, Space.World); // Global 좌표계 기준 이동

        // Rotation
        // ====================================================================================
        // tr.Rotate(new Vector3(0f, 30f, 0f)); // Y 축으로 30 radian 만큼 회전 하라. Degree 0~360 까지 나타내는 단위, Radian 0~2 pi(파이) 단위

        float r = Input.GetAxis("Mouse X");
        Vector3 rotateVec = Vector3.up * rotateSpeed * r * Time.deltaTime;
        tr.Rotate(rotateVec);
    }

    // FixedUpdate 는 고정 프레임마다 호출 되는 함수.
    //private void FixedUpdate()
    //{

    //}
}
