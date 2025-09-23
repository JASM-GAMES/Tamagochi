using UnityEngine;

[CreateAssetMenu(fileName = "ConfigNecesidades", menuName = "Configs/Valores Necesidades")]
public class ConfigNecesidades : ScriptableObject
{
    [Header("Velocidad del tiempo")]
    public float velocidadTiempoBase = 1f;

    [Header("Necesidades por minuto (base)")]
    public float hambreBase = 0.5f;
    public float suenoBase = 0.2f;
    public float diversionBase = 0.4f;
    public float estresBase = 0.1f;
    public float socialBase = 0.4f;
}