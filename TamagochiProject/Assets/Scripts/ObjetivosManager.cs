using UnityEngine;

public class ObjetivosManager : MonoBehaviour
{
    public GameManager gM;
    public ManagerUI UIM;

    public float barraEstudio;

    public void aumentarBarraEstudio()
    {
        barraEstudio += 10;
    }
}
