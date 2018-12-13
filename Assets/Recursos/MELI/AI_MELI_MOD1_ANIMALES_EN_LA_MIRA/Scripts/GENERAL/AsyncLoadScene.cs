//This script lets you load a Scene asynchronously. It uses an asyncOperation to calculate the progress and outputs the current progress to Text (could also be used to make progress bars).

//Attach this script to a GameObject
//Create a Button (Create>UI>Button) and a Text GameObject (Create>UI>Text) and attach them both to the Inspector of your GameObject
//In Play Mode, press your Button to load the Scene, and the Text changes depending on progress. Press the space key to activate the Scene.
//Note: The progress may look like it goes straight to 100% if your Scene doesn’t have a lot to load.

using System.Collections;
using Recursos.MELI.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Navegation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Resource.LIBRO_C.AI_MELI_MOD1_ANIMALES_EN_LA_MIRA.Scripts.GENERAL {
    public class AsyncLoadScene : MonoBehaviour {
        public Button MButton;
        [SerializeField] private NavegationManager _navegationManager;

        void Start() {
            //Call the LoadButton() function when the user clicks this Button
            MButton.onClick.AddListener(LoadButton);
        }

        void LoadButton() {
            //Start loading the Scene asynchronously and output the progress bar
            StartCoroutine(LoadScene());
        }

        public IEnumerator LoadScene() {
            yield return null;

            //Begin to load the Scene you specify
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
            //Don't let the Scene activate until you allow it to
            asyncOperation.allowSceneActivation = false;
            Debug.Log("Pro :" + asyncOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone) {
                //Output the current progress


                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f) {
                    //Change the Text to show the Scene is ready

                    //Wait to you press the space key to activate the Scene
                    if (Input.GetKeyDown(KeyCode.Space) || _navegationManager.LoadedScene)
                        //Activate the Scene
                        asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}