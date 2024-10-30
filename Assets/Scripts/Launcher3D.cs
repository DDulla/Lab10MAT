using UnityEngine;

public class Launcher3D : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float launchForce = 30f;
    public LineRenderer trajectoryLine;
    public int trajectoryPoints = 30;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        DrawTrajectory();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = launchPoint.forward * launchForce;
    }

    private void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryPoints];
        Vector3 startPosition = launchPoint.position;
        Vector3 startVelocity = launchPoint.forward * launchForce;
        for (int i = 0; i < trajectoryPoints; i++)
        {
            float simulationTime = i / (float)trajectoryPoints;
            positions[i] = startPosition + startVelocity * simulationTime + 0.5f * Physics.gravity * Mathf.Pow(simulationTime, 2);
        }
        trajectoryLine.positionCount = trajectoryPoints;
        trajectoryLine.SetPositions(positions);
    }
}
