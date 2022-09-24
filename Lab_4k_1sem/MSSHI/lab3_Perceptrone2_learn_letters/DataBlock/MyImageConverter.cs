using System.Drawing;
namespace DataBlock
{
    public static class MyImageConverter
    {
        /// <summary>
        /// Функція яка розрізає картинку на частини
        /// </summary>
        /// <param name="filename"> шлях до  файлу </param>
        /// <param name="nx"> кількість частин по X </param>
        /// <param name="ny"> кількість частин по Y </param>
        private static List<Bitmap> SplitImage(string filename, int nx, int ny)
        {
            List<Bitmap> rezult = new List<Bitmap>();

            Image image = Image.FromFile(filename);

            int w = image.Width;
            int h = image.Height;

            // координаты по X
            int[] x = new int[nx + 1];
            x[0] = 0;
            for (int i = 1; i <= nx; i++)
            {
                x[i] = w * i / nx;
            }

            // координаты по Y
            int[] y = new int[ny + 1];
            y[0] = 0;
            for (int i = 1; i <= ny; i++)
            {
                y[i] = h * i / ny;
            }

            // вспомогательные переменные
            Bitmap bmp;
            Graphics g;

            // режем
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    // размеры тайла
                    w = x[i + 1] - x[i];
                    h = y[j + 1] - y[j];

                    // тайл
                    bmp = new Bitmap(w, h);

                    // рисуем
                    g = Graphics.FromImage(bmp);
                    g.DrawImage(image, new Rectangle(0, 0, w, h), new Rectangle(x[i], y[j], w, h), GraphicsUnit.Pixel);

                    // сохраняем результат
                    //bmp.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("image{0}_{1}.png", i, j)), System.Drawing.Imaging.ImageFormat.Png);
                    rezult.Add(bmp);

                    // очистка памяти
                    g.Dispose();
                    bmp.Dispose();
                }
            }

            image.Dispose();

            return rezult;
        }

        public static int[] GetArrFromImage(string PathToImage, int sizeX = 6, int sizeY = 8)
        {
            var rezult = new int[sizeX*sizeY];
            var list = SplitImage(PathToImage, sizeX, sizeY);
            foreach (var item in list)
            {

            }

            return rezult;
        }
    }
}
