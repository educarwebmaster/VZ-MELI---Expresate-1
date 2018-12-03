using UnityEngine;

namespace VZ.Scripts.SIE {
	public class MOSTRAR_RECURSO_GUI : MonoBehaviour {
		public GENERAL_INTERFAZ General;
		public bool Activado = false;
	
		// Update is called once per frame
		void Update () {
			if(this.transform.parent.gameObject.activeSelf){
				if (!Activado)
				{
					General.Cerrar_visor_3d();
					General.Abrir_visor_3d();
				}
			}
		}
	}
}
