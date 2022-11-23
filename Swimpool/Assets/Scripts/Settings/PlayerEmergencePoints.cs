using UnityEngine;

[CreateAssetMenu(fileName = "new PlayerEmergencePoints", menuName = "ScriptableObjects/PlayerEmergencePoints")]
public class PlayerEmergencePoints : ScriptableObject
{
    [SerializeField]
    private Vector3 MinAreaPoint;
    [SerializeField]
    private Vector3 MaxAreaPoint;
    [SerializeField]
    private Vector3 SwimPoint;

    public Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(MinAreaPoint.x, MaxAreaPoint.x),
           MinAreaPoint.y,
            Random.Range(MinAreaPoint.z, MaxAreaPoint.z));
    }

    public Vector3 GetSwimPointPosition() => SwimPoint;
}
