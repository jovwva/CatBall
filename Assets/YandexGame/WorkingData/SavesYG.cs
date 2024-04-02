
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
        public LevelData[] levelsDataArray = 
            new LevelData[9]{
                new LevelData(1, 0, true),
                new LevelData(2, 0, false),
                new LevelData(3, 0, false),
                new LevelData(4, 0, false),
                new LevelData(5, 0, false),
                new LevelData(6, 0, false),
                new LevelData(7, 0, false),
                new LevelData(8, 0, false),
                new LevelData(9, 0, false),
            };
        public int moneyValue = 100;

        // Вы можете выполнить какие то действия при загрузке сохранений
        // public SavesYG()
        // {
        //     // Допустим, задать значения по умолчанию для отдельных элементов массива

        //     openLevels[1] = true;
        // }
    }
}
