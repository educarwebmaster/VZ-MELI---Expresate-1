using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resource.LIBRO_F.AI_MELI_MOD1_LABERINTO_OCULAR.Scripts
{
    public class PerformanceManager : MonoBehaviour
    {
        public int QualityLevel, SceneLevel;
        public bool AR;

        private void Start() {
            //Asigna el limite max de FPS
            Application.targetFrameRate = 300;
            //Ajusta la calidad grafica segun index
            QualitySettings.SetQualityLevel(QualityLevel);
        }


        private void OnEnable() {
            if (AR) {
                RestartLevel(SceneLevel);
            }
        }

        /// <summary>
        /// Ajusta la calidad grafica de acuerdo al  quality settigns
        /// </summary>
        /// <param name="index"></param>
        public void LoadPerformanceSettigns(int index) {
            QualitySettings.SetQualityLevel(index);
        }

        public void RestartLevel(int index) {
            SceneManager.LoadScene(index);
        }

        public void Resume() {
            if (Time.timeScale == 1f)
                Time.timeScale = 0f;
            else if (Time.timeScale == 0f)
                Time.timeScale = 1f;
        }
    }
}