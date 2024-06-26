﻿
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
            new LevelData[18]{
                new LevelData(1, 0, true),
                new LevelData(2, 0, false),
                new LevelData(3, 0, false),
                new LevelData(4, 0, false),
                new LevelData(5, 0, false),
                new LevelData(6, 0, false),
                new LevelData(7, 0, false),
                new LevelData(8, 0, false),
                new LevelData(9, 0, false),
                new LevelData(10, 0, false),
                new LevelData(11, 0, false),
                new LevelData(12, 0, false),
                new LevelData(13, 0, false),
                new LevelData(14, 0, false),
                new LevelData(15, 0, false),
                new LevelData(16, 0, false),
                new LevelData(17, 0, false),
                new LevelData(18, 0, false),
            };
        public ItemData[] itemDataArray =
            new ItemData[12]{
                new ItemData(0, ProductStatus.Selected),
                new ItemData(1, ProductStatus.CanBuy),
                new ItemData(2, ProductStatus.CanBuy),
                new ItemData(3, ProductStatus.CanBuy),
                new ItemData(4, ProductStatus.CanBuy),
                new ItemData(5, ProductStatus.CanBuy),

                new ItemData(6, ProductStatus.Selected),
                new ItemData(7, ProductStatus.CanBuy),
                new ItemData(8, ProductStatus.CanBuy),
                new ItemData(9, ProductStatus.CanBuy),
                new ItemData(10, ProductStatus.CanBuy),
                new ItemData(11, ProductStatus.CanBuy)
            };
        public int moneyValue = 100;
        public int colorId = 0;
        public int shapeId = 6;

        // Вы можете выполнить какие то действия при загрузке сохранений
        // public SavesYG()
        // {
        //     // Допустим, задать значения по умолчанию для отдельных элементов массива

        //     openLevels[1] = true;
        // }
    }
}
