using UnityEngine;

namespace Agava.IdleGame.Model
{
    public abstract class SavedObject<T> where T : class
    {
        private readonly string _guid;

        public SavedObject(string guid)
        {
            _guid = guid;
        }

        public bool HasSave => PlayerPrefs.HasKey(_guid);

        public void Save()
        {
            string jsonString = JsonUtility.ToJson(this as T);
            PlayerPrefs.SetString(_guid, jsonString);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(_guid) == false)
                return;

            string jsonString = PlayerPrefs.GetString(_guid);
            object loadedObject = JsonUtility.FromJson(jsonString, typeof(T));

            OnLoad(loadedObject as T);
        }

        protected abstract void OnLoad(T loadedObject);
    }
}