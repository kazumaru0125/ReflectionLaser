using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
    {
    public Transform startPoint;
    public float speed = 20f;
    public float lifeTime = 1f;
    public float beamLength = 1f; // ƒr[ƒ€‚Ì’·‚³

    private LineRenderer lineRenderer;
    private bool isFired = false;
    private Vector3 targetPoint;
    private Vector3 direction;
    private Vector3 currentHeadPos;
    private float timer = 0f;

    void Start()
        {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        }

    void Update()
        {
        if (Input.GetMouseButtonDown(1) && !isFired)
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                {
                targetPoint = hit.point;
                }
            else
                {
                targetPoint = ray.GetPoint(100f);
                }

            direction = (targetPoint - startPoint.position).normalized;
            currentHeadPos = startPoint.position;
            FireLaser();
            }

        if (isFired)
            {
            currentHeadPos += direction * speed * Time.deltaTime;
            Vector3 tailPos = currentHeadPos - direction * beamLength;

            lineRenderer.SetPosition(0, tailPos);
            lineRenderer.SetPosition(1, currentHeadPos);

            timer += Time.deltaTime;
            if (timer >= lifeTime)
                {
                isFired = false;
                lineRenderer.enabled = false;
                timer = 0f;
                }
            }
        }

    void FireLaser()
        {
        isFired = true;
        lineRenderer.enabled = true;
        timer = 0f;
        }
    }
