using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    NumberField scoreField;

    private void Start()
    {
        scoreField = GetComponentInChildren<NumberField>();
        if (!scoreField)
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");
    }

    protected override GameObject spawnObject()
    {
        GameObject LaserObject = base.spawnObject();  // base = super

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = LaserObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField).SetPointsToAdd(pointsToAdd);

        Vector3 laserRotation = transform.eulerAngles;
        InputMover IM = GetComponent<InputMover>();
        laserRotation.z = transform.eulerAngles.z - IM.StartingRotation;
        LaserObject.transform.eulerAngles = laserRotation;

        Mover laserMover;
        try
        {
            laserMover = LaserObject.GetComponent<Mover>();
            laserMover.velocity = RotateSpeed(laserMover.velocity, laserRotation.z);
        }
        catch (System.Exception)
        {
            Debug.LogError("Laser Object doesn't have 'Mover' component");
        }

        return LaserObject;
    }

    private Vector3 RotateSpeed(Vector3 speed, float rotationDegrees)
    {
        float radians = rotationDegrees * Mathf.Deg2Rad;
        float rotatedX = speed.x * Mathf.Cos(radians) - speed.y * Mathf.Sin(radians);
        float rotatedY = speed.x * Mathf.Sin(radians) + speed.y * Mathf.Cos(radians);
        speed = new Vector2(rotatedX, rotatedY);

        return speed;
    }
}
