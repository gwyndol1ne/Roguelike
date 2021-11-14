using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Roguelike
{
    [Serializable]
    class SaveAndLoad
    {
        private string[] saves;
        private bool[] emptySave;

        public SaveAndLoad()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SaveAndLoad saveAndLoad;
            using (FileStream fs = new FileStream("saves.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    saveAndLoad = (SaveAndLoad)formatter.Deserialize(fs);
                    saves = saveAndLoad.saves;
                    emptySave = saveAndLoad.emptySave;
                }
                else
                {
                    saves = new string[3] { "None", "None", "None" };
                    emptySave = new bool[3] { true, true, true };
                }

            }
        }

        public void Save(ref Player player,ref List<Entity> entities,ref List<Chest> chests)
        {
            List<string> saveMenuItems = new List<string>(saves);
            saveMenuItems.Add("Выйти");
            Menu saveMenu = new Menu(saveMenuItems);
            int choice = saveMenu.GetChoice(true);
            if (choice != saveMenuItems.Count - 1)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("saves.dat", FileMode.OpenOrCreate))
                {
                    saves[choice] = ("save" + choice + ".dat");
                    emptySave[choice] = false;
                    formatter.Serialize(fs, this);
                }
                using (FileStream fs = new FileStream(saves[choice], FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, player);
                    formatter.Serialize(fs, entities);
                    formatter.Serialize(fs, chests);
                }
            }
        }

        public bool Load(ref Player player, ref List<Entity> entities, ref List<Chest> chests)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<string> loadMenuItems = new List<string>();
            for (int i = 0; i < saves.Length; i++)
            {
                if (!emptySave[i])
                {
                    loadMenuItems.Add(saves[i]);
                }
            }
            loadMenuItems.Add("Выйти");
            Menu loadMenu = new Menu(loadMenuItems);
            int choice = loadMenu.GetChoice(true);
            if (choice == loadMenuItems.Count - 1)
            {
                return false;
            }
            using (FileStream fs = new FileStream(saves[choice], FileMode.OpenOrCreate))
            {
                player = (Player)formatter.Deserialize(fs);
                entities = (List<Entity>)formatter.Deserialize(fs);
                chests = (List<Chest>)formatter.Deserialize(fs);
            }
            return true;
        }
    }
}
