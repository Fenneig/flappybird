using Flappybird.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Menus
{
    public class DifficultChooseMenu : MonoBehaviour
    {
        public void OnChooseDifficult(DifficultSettings settings)
        {
            Difficult.Current = settings;
            SceneManager.LoadScene("LoadingScene");
        }
    }
}