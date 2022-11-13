using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu]
public class GameManagerSO : ScriptableObject
{
    public GameObjectVariable[] hazards;
    //public Vector3Variable spawnValues; // não funcionou vector 3
    public IntVariable hazardCount;
    public FloatVariable spawnWait;
    public FloatVariable startWait;
    public FloatVariable waveWait;
    private BoolVariable gameOver;
    private BoolVariable restart;
    private IntVariable score;
}
