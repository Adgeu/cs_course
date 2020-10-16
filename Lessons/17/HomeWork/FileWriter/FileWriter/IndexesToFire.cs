using System;
using System.Collections.Generic;

namespace FileWriter
{
    /// <summary>
    /// Равномерно распределяет промежутки между вызовами события <see cref="FileWriterWithProgress.WritingPerformed"/>
    /// </summary>
    class IndexesToFire
    {
        /// <summary>
        /// Коллекция индексов, на которых нужно вызывать событие <see cref="FileWriterWithProgress.WritingPerformed"/>
        /// </summary>
        private Queue<int> _indexes = new Queue<int>();

        /// <summary>
        /// Возвращать ли индекс, округлённый вниз (или вверх, если _isFloor == false).
        /// </summary>
        private bool _isFloor = false;

        /// <summary>
        /// Промежуток, через который требуется вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/>
        /// (Используется для заполнения коллекции)
        /// </summary>
        float _indexRate;

        /// <summary>
        /// Следующий индекс, на котором нужно вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/>
        /// (Используется для заполнения коллекции)
        /// </summary>
        float _nextIndex;

        /// <summary>
        /// Создаёт новый объект <see cref="IndexesToFire"/>
        /// </summary>
        /// <param name="dataLength">Длина данных, для которых нужно равномерно распределить промежутки вызова события <see cref="FileWriterWithProgress.WritingPerformed"/></param>
        /// <param name="percentageToFireEvent">Промежуток, через который требуется вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/> (в процентах)</param>
        public IndexesToFire(int dataLength, float percentageToFireEvent)
        {         
            if (percentageToFireEvent != 0)
            {
                // Определяем промежуток и следующий индекс
                _nextIndex = _indexRate = percentageToFireEvent * dataLength;

                // Первый форматированный индекс
                var indexToFire = GetNextIndexForFillCollection();
                for (int i = 0; i < dataLength; i++)
                {
                    if (i == indexToFire)
                    {
                        _indexes.Enqueue(i);
                        // Следующий форматированный индекс
                        indexToFire = GetNextIndexForFillCollection();
                    }
                }
            }
            else
            {
                // Если процент равен 0, вызываем событие на каждом индексе
                for (int i = 0; i < dataLength; i++)
                    _indexes.Enqueue(i);
            }
        }

        /// <summary>
        /// Возвращаеи следующий индекс, на котором нужно вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/>
        /// (Используется для заполнения коллекции)
        /// </summary>
        /// <returns>Следующий индекс, на котором нужно вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/></returns>
        private int GetNextIndexForFillCollection()
        {
            // Чередование Floor и Ceiling
            _isFloor = !_isFloor;
            // Запоминаем текущий индекс
            var currentIndex = _nextIndex;
            // Вычисляем следующий индекс
            _nextIndex += _indexRate;

            return (int)(_isFloor ? MathF.Floor(currentIndex) : MathF.Ceiling(currentIndex)) - 1;
        }

        /// <summary>
        /// Возвращает следующий индекс, на котором нужно вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/>
        /// </summary>
        /// <returns>Следующий индекс, на котором нужно вызвать событие <see cref="FileWriterWithProgress.WritingPerformed"/></returns>
        public int GetNextIndex() =>
            _indexes.Count > 0 ? _indexes.Dequeue() : -1;
    }
}
