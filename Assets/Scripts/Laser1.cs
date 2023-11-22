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
        ShootLaser();
    }

    void ShootLaser() {
        if (Physics2D.Raycast(m_transform.position, transform.right)){
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.right);
            Draw2DRay(laserbeam.position, _hit.point);
        }
        else {
            Draw2DRay(laserbeam.position, laserbeam.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
