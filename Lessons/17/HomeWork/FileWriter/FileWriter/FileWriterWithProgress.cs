using System;
using System.IO;

namespace FileWriter
{
    class FileWriterEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public float Percentage { get; set; }
        public float CurrentPercent { get; set; }
        public int CurrentDataIndex { get; set; }
    }

    class FileWriterWithProgress
    {
        public event EventHandler<FileWriterEventArgs> WritingPerformed;
        public event EventHandler<FileWriterEventArgs> WritingCompleted;

        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
            if (percentageToFireEvent < 0f || percentageToFireEvent > 1f)
                throw new ArgumentException($"Значение \"percentageToFireEvent\" должно находится в промежутке [0;1]. Текущее значение: {percentageToFireEvent}");

            var indexesToFire = new IndexesToFire(data.Length, percentageToFireEvent);

            var currentPercent = 0f;

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                var indexToFire = indexesToFire.GetNextIndex();
                for (int i = 0; i < data.Length; i++)
                {
                    sw.Write(data[i]);
                    if (i == indexToFire)
                    {
                        WritingPerformed?.Invoke(this,
                            new FileWriterEventArgs
                            {
                                FileName = fileName,
                                Percentage = percentageToFireEvent,
                                CurrentPercent = (currentPercent += percentageToFireEvent) * 100,
                                CurrentDataIndex = i
                            }
                        );

                        indexToFire = indexesToFire.GetNextIndex();
                    }
                }
            }

            WritingCompleted?.Invoke(this,
                new FileWriterEventArgs
                {
                    FileName = fileName,
                    Percentage = 1f,
                    CurrentPercent = 100,
                    CurrentDataIndex = data.Length
                }
            );
        }
    }
}
