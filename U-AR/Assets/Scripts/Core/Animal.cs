using Core.Interfaces;
using UnityEngine;

namespace Core
{
    public class Animal : MonoBehaviour, ISavable
    {
        #region STATS

        [System.Serializable]
        public enum AnimalType
        {
            Chicken,
            Pig,
            Cow,
            Sheep,
        }
        
        [System.Serializable]
        public class Stats
        {
            private string _id = "";
            public string Id
            {
                get => _id;
                internal set => _id = value;
            }

            private string _name = "Animal";
            public string Name
            {
                get => _name;
                internal set
                {
                    if (_name == value) return;
                    if (value.Length <= 0) return;
                    _name = value;
                    SetDirty(true);
                }
            }
            
            private AnimalType _type = AnimalType.Chicken;
            public AnimalType Type
            {
                get => _type;
                internal set
                {
                    if (_type == value) return;
                    _type = value;
                    SetDirty(true);
                }
            }
            
            
            [SerializeField]
            private Color _color = Color.white;
            public Color Color
            {
                get => _color;
                internal set
                {
                    if (_color == value) return;
                    _color = value;
                    SetDirty(true);
                }
            }
            [SerializeField]
            [Range(0f, 100f)]
            private int _stamina;
            public int Stamina
            {
                get => _stamina;
                internal set
                {
                    if (_stamina == value) return;
                    if (value < 0f || value > 100f) return;
                    _stamina = value;
                    SetDirty(true);
                }
            }
            [SerializeField]
            [Range(0f, 100f)]
            private int _speed;
            public int Speed
            {
                get => _speed;
                internal set
                {
                    if (_speed == value) return;
                    if (value < 0f || value > 100f) return;
                    _speed = value;
                    SetDirty(true);
                }
            }
            [SerializeField]
            [Range(0f, 100f)]
            private int _style;
            public int Style
            {
                get => _style;
                internal set
                {
                    if (_style == value) return;
                    if (value < 0f || value > 100f) return;
                    _style = value;
                    SetDirty(true);
                }
            }
            [SerializeField]
            [Range(0f, 100f)]
            private int _poise;
            public int Poise
            {
                get => _poise;
                internal set
                {
                    if (_poise == value) return;
                    if (value < 0f || value > 100f) return;
                    _poise = value;
                    SetDirty(true);
                }
            }
            [SerializeField]
            [Range(0f, 100f)]
            private int _constitution;
            public int Constitution
            {
                get => _constitution;
                internal set
                {
                    if (_constitution == value) return;
                    if (value < 0f || value > 100f) return;
                    _constitution = value;
                    SetDirty(true);
                }
            }

            public bool Dirty { get; private set; } //Set to true if stats have changed and have not been saved
            public void SetDirty(bool dirty) => Dirty = dirty;
        }

        [SerializeField] private Stats stats;
        public Stats GetStats () => stats;

        #endregion

        #region HELPER_FUNCTIONS

        

        #endregion
        
        #region GAME_LOOP
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                print("S");
                SaveManager.SaveGame();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                print("L");
                SaveManager.LoadGame();
            }
        }
        #endregion

        #region ISAVEABLE
        public void Save()
        {
            stats.SetDirty(false);
            string data = JsonUtility.ToJson(stats);
        }

        public void Load()
        {
            stats.SetDirty(false);
            // stats = JsonUtility.FromJson<Stats>();
        }
        #endregion
    }
}
