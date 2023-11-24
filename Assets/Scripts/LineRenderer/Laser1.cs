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
        //시간 맞춰서
        ShootLaser();

        //시간 맞춰서
        //Erase2DRay();
    }

    void ShootLaser() {
        Vector2 direction = transform.right; // 레이저 방향, 일단 오른쪽
        RaycastHit2D hit = Physics2D.Raycast(m_transform.position, direction);  //물리적 발사 (wall 닿으면 hit에 저장)   

        if ( hit ){ // 뭔가에 닿았으면 (아마 공)
            Draw2DRay(laserbeam.position, hit.point); // 닿은데까지만 그리기
            // 닿은 물체가 공이면 게임 오버
        }
        else { // 뭔가에 닿지 않으면
            Draw2DRay(laserbeam.position, laserbeam.transform.right * defDistanceRay);  // 지정 거리까지 그리기
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) { // linerenderer 그리는 함수
        m_lineRenderer.enabled = true; //linerenderer 활성화

        // startPos에서 endPos까지
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    void Erase2DRay() {
        m_lineRenderer.enabled = false; //linerenderer 비활성화
    }
}
