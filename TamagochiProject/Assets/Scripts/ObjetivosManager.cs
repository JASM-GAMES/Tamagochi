using System;
using UnityEngine;

public class ObjetivosManager : MonoBehaviour
{
    public GameManager gM;
    public ManagerUI UIM;

    public float barraEstudio;
    public float dificultad;

    public event Action<bool> AumentoDificultad;
    public void aumentarBarraEstudio(float estudio)
    {
        barraEstudio += estudio;
    }
    public void disminuirBarraEstudio(float estudio)
    {
        barraEstudio -= estudio;
    }
    public void Examen()
    {
        if (barraEstudio <= .5f)
        {
            UIM.activarMensajeReprobaste();
        }
        else if (barraEstudio > .5f)
        {
            UIM.activarMensajeAprobaste();
            dificultad = 1 - barraEstudio; // 👈 sigue igual
            Debug.Log("dificultad agregada: " + dificultad);

            AumentoDificultad?.Invoke(true);
            Debug.Log("se disparo el evento");
        }
    }
    public void IrUniversidad()
    {
        if (gM.universidadActivo)
        {
            UIM.activarPanelFadeOut();
            gM.horasActual = 20;
            barraEstudio += .2f;
        }
        else
        {
            UIM.activarPanelNoIrUniversidad();
        }
    }


}
