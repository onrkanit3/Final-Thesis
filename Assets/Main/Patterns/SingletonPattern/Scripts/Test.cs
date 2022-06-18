using UnityEngine;

namespace Main.Scripts.SingletonPattern
{
    public class Test : MonoBehaviour
    {
        private UIManager UIManager;
        private void Awake()
        {
            #region Singleton Usage Methods
            //
            // AudioManagerWithGenericSingleton.Instance.PlayAudio();
            // AudioManagerWithoutGenericSingleton.Instance.PlayAudio();

            #endregion
        
        }

        private void Update()
        {
            Initialize();
        }

        [ContextMenu("Initialize")]
        private void Initialize()
        {
            #region Singleton Performance Compare

            #region Bad Performance

            UIManager = FindObjectOfType<UIManager>();
            UIManager.FillUpBar(Random.Range(0,100));

            #endregion

            #region Better Performance

            // UIManager.Instance.FillUpBar(Random.Range(0,100));

            #endregion

            #endregion
        }
    }
}
