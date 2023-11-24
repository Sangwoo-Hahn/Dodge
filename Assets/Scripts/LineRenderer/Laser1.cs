using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserbeam;
    public LineRenderer m_lineRenderer;
    Transform m_transform;


    private void Awake() {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        //�ð� ���缭
        ShootLaser();

        //�ð� ���缭
        //Erase2DRay();
    }

    void ShootLaser() {
        Vector2 direction = transform.right; // ������ ����, �ϴ� ������
        RaycastHit2D hit = Physics2D.Raycast(m_transform.position, direction);  //������ �߻� (wall ������ hit�� ����)   

        if ( hit ){ // ������ ������� (�Ƹ� ��)
            Draw2DRay(laserbeam.position, hit.point); // ������������ �׸���
            // ���� ��ü�� ���̸� ���� ����
        }
        else { // ������ ���� ������
            Draw2DRay(laserbeam.position, laserbeam.transform.right * defDistanceRay);  // ���� �Ÿ����� �׸���
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) { // linerenderer �׸��� �Լ�
        m_lineRenderer.enabled = true; //linerenderer Ȱ��ȭ

        // startPos���� endPos����
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    void Erase2DRay() {
        m_lineRenderer.enabled = false; //linerenderer ��Ȱ��ȭ
    }
}
