using AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Audio;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Score;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;


namespace Recursos.MELI.AI_MELI_11_MOD1_OJO_VELOZ.Scripts
{
    public class ActivityManager : MonoBehaviour
    {
        [SerializeField] [Header("Administrador de puntaje: ")]
        public ScoreManager ScoreManager;

        [Header("Administrador de audios")] [SerializeField]
        public FXAudio _FxAudio;


        [SerializeField] private NavegationManager _navegationManager;

        public int Intentos, Aciertos;
        private int correctas, incorrectas = 0;
        [SerializeField] Text AciertoText, IntentosText;

        public List<GameObject> listaFichas = new List<GameObject>();
        private Evaluador[] evaluadors;
        private float a;

        [SerializeField] List<GameObject> Totalfichas;


        public void AdicionarElementos(GameObject elemeto)
        {
            if (listaFichas.Count <= 3)
            {
                listaFichas.Add(elemeto);

                if (listaFichas.Count == 4)
                {
                    for (int k = 0; k < listaFichas.Count; k++)
                    {
                        listaFichas[k].gameObject.GetComponent<Evaluador>().verificado = true;
                        //listaFichas[k].gameObject.GetComponent<Evaluador>().enabled = false;
                    }

                    correctas++;
                    ScoreManager.IncreaseScore();
                    _FxAudio.PlayAudio(2);
                    AciertoText.text = correctas.ToString();
                    listaFichas.Clear();
                    GoToDesempeno();
                }

                if (listaFichas.Count > 1)
                {
                    for (int i = 0; i < listaFichas.Count; i++)
                    {
                        if (i < listaFichas.Count - 1)
                        {
                            if (listaFichas[i].gameObject.GetComponent<Evaluador>().Grupo ==
                                listaFichas[i + 1].gameObject.GetComponent<Evaluador>().Grupo)
                            {
                            }
                            else
                            {
                                EliminarElementos();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void EliminarElementos()
        {
            for (int k = 0; k < listaFichas.Count; k++)
            {
                listaFichas[k].gameObject.GetComponent<Evaluador>().seleccionado = false;
            }

            listaFichas.Clear();
            incorrectas++;
            _FxAudio.PlayAudio(1);
            IntentosText.text = incorrectas.ToString();
            listaFichas.Clear();
            GoToDesempeno();
        }

        public void GoToDesempeno()
        {
            

            
            if (correctas == Aciertos)
            {
                foreach (var elem in Totalfichas)
                {
                    elem.gameObject.GetComponent<Evaluador>().habilitado = false;
                }
                _navegationManager.Forward(2);
            }

            if (incorrectas == Intentos)
            {
                foreach (var elem in Totalfichas)
                {
                    elem.gameObject.GetComponent<Evaluador>().habilitado = false;
                }
                _navegationManager.Forward(2);
            }
        }
    }
}