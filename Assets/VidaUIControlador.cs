using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VidaUIControlador : MonoBehaviour
{
    private Image imagenVida;
    private int vidaTotal = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //busca el objeto vida dentro del objeto contenedorVida para acceder a la imagen de vida
        imagenVida = transform.Find("Vida").GetComponent<Image>();

        //busca el script MovimientoJugador en el objeto actual y los superiores, luego usa el comportamiento getVida para inicializar la vida total
        //usar este codigo si solo se quiere usar una barra de vida interna al jugador
        //vidaTotal = GetComponentInParent<MovimientoJugador>().getVida();

        // busca el script bajo el tag de Player y asi poder acceder al script MovimientoJugador, luego usa el comportamiento getVida para inicializar la vida total 
        // usar este codigo si se quiere permitir tambien barras de vida externas al jugador
        vidaTotal = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoJugador>().getVida();
    }

    public void ActualizarVida( int vidaActual)
    {
        //modifica el valor de fillAmout de la imagen vida a un valor entre 0 y 1 inclusive
        imagenVida.fillAmount = (float)vidaActual / vidaTotal;
    }
}
