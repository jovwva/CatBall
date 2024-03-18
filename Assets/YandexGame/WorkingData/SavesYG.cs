
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int      idSave;
        public bool     isFirstSession = true;
        public string   language = "ru";
        public bool     promptDone;

        // Ваши сохранения
        public List<LevelData> levelsDataList =
            new List<LevelData>(){
                    new LevelData(1, 0, true),
                    new LevelData(2, 0, false),
                    new LevelData(3, 0, false),
                    new LevelData(4, 0, false),
                    new LevelData(5, 0, false),
                };
        public List<ItemData> itemsStateList = 
            new List<ItemData>(){
                    new ItemData(0, ItemState.Selected),
                    new ItemData(1, ItemState.Purchased),
                    new ItemData(2, ItemState.Blocked), 
                };
        public int moneyValue = 100;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        // public SavesYG()
        // {
        //     // Допустим, задать значения по умолчанию для отдельных элементов массива

        //     openLevels[1] = true;
        // }
    }
}
