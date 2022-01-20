using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Transform tr;
    // public ���� �����ڸ� ����ϸ� Inspector â�� ������ �ȴ�.
    // ���࿡ �ٸ� Ŭ�����κ����� ������ �����ϸ鼭 Inspector â�� �����Ű�� ������ [[SerializeField] �Ӽ��� ����Ѵ�.
    [SerializeField] private float speed = 1; // Inspector â�� ���� �ʱ�ȭ ������ �켱�����̴�.
    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // transform�� �����ؼ� ��ǥ�� ���� �����͸� ������ѵ� ������ ����  Transform ������� tr �� �����ؼ�
        // Transform component�� ������ �Ŀ� ����ϴ� ������
        // ĳ�� �޸� ���� ���� ( ĳ�� : �ӽ÷� ������ �����ϵ��� ������ �޸� )
        // transform�� ����ϸ� �� ��������� ȣ�� �� �� ���� gameObject�� �����ؼ� getComponent�� Transform ������ ������.
        // ������ Transform ������� tr�� �ѹ� �־�ΰ� ����ϸ�
        // tr �� ����� ������ ó���� �־���� Transform component �� �ٷ� �����ϱ� ������
        // ���ÿ� ���� ���� ���ӿ�����Ʈ���� Transform ������Ʈ�� ��� �ϸ� �� ���� �����ս����� ���̰� ����.

        tr = gameObject.GetComponent<Transform>(); // ���� ���� ����ϴ� ����
        // transform.gameObject.GetComponent<Transform>();
        // tr = this.gameObject.GetComponent<Transform>();
        // tr = this.gameObject.transform;
        // tr = gameObject.transform;
    }

    // Update is called once per frame
    // Update�� �� �����Ӹ��� ȣ�� �Ǵ� �Լ�
    void Update()
    {
        // Position
        // ========================================================================
        // 1 �����Ӵ� z�� 1�� ����
        // ���࿡ ��ǻ�� ����� �޶� �ϳ��� 60FPS, �ٸ� �ϳ��� 30FPS
        // -> 1�ʿ� �ϳ��� 60��ŭ �����ϰ�, �ٸ� �ϳ��� 30��ŭ ����
        // tr.position += new Vector3(0, 0, 1);

        // Time.deltaTime �� ���� �����Ӱ� ���� ������ ���� �ɸ� �ð�
        // ��, Time.deltaTime �� �����ָ� ��� ���ɿ� ���� ���� �ʴ� ���� ��ȭ���� ���� �� �ִ�.
        // tr.position += new Vector3(0, 0, speed) * Time.deltaTime;

        // physics ���� �����͸� ó���� �� ���� �����.
        // tr.position += new Vector3(0, 0, 1) * Time.fixedDeltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h = " + h); // Z axis forward, backward
        Debug.Log($"v = {v}"); // X axis left, right

        // Z axis forward, backward
        // X axis left, right
        // Y axis up , down

        // tr.position += new Vector3(h, 0, v)* speed * Time.deltaTime;
        // 1�����Ӵ� z�� 1 * speed ����
        // Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;
        // tr.Translate(movePos);
        // ���ÿ� ���������� �������� �� ���⺤���� ũ�Ⱑ 1�� �Ѿ�� ���⿡ ���� �ӵ��� �������� �ʴ�.
        // // Translate (�̵��Լ�) = 1�����Ӵ� z�� 1 * speed ���� ���� ��

        // Vector ����� ũ�⸦ ��� ������ ����
        // Ư�� Vector ũ�Ⱑ 1�� ���͸� ��������(Unit Vector)�� �Ѵ�.
        // �����̰� ���� ���⿡ ���� �������� * �ӵ� �� ��ü�� ������.
        Vector3 dir = new Vector3(h, 0, v).normalized;
        Vector3 moveVac = dir * speed * Time.deltaTime;
        // tr.Translate(moveVac);
        // ���ÿ� ���������� �������� �� ���⺤���� ũ�Ⱑ 1�� �Ѿ��
        // normalized�� ����Ͽ� �� �����ϰ� ����
        // tr.Translate(moveVac, Space.Self); // local ��ǥ�� ���� �̵�
        tr.Translate(moveVac, Space.World); // Global ��ǥ�� ���� �̵�

        // Rotation
        // ====================================================================================
        // tr.Rotate(new Vector3(0f, 30f, 0f)); // Y ������ 30 radian ��ŭ ȸ�� �϶�. Degree 0~360 ���� ��Ÿ���� ����, Radian 0~2 pi(����) ����

        float r = Input.GetAxis("Mouse X");
        Vector3 rotateVec = Vector3.up * rotateSpeed * r * Time.deltaTime;
        tr.Rotate(rotateVec);
    }

    // FixedUpdate �� ���� �����Ӹ��� ȣ�� �Ǵ� �Լ�.
    //private void FixedUpdate()
    //{

    //}
}
