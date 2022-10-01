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
        private static List<Bitmap> SplitImage(Image img, int nx, int ny)
        {
            Image image = (Image)img.Clone();

            List <Bitmap> rezult = new List<Bitmap>();

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
            for (int j = 0; j < ny; j++)
            {
                for (int i = 0; i < nx; i++)
                {
                    // размеры тайла
                    w = x[i + 1] - x[i];
                    h = y[j + 1] - y[j];

                    // тайл
                    bmp = new Bitmap(w, h);

                    // рисуем
                    g = Graphics.FromImage(bmp);
                    g.DrawImage(image, new Rectangle(0, 0, w, h), new Rectangle(x[i], y[j], w, h), GraphicsUnit.Pixel);


                    rezult.Add(bmp);

                    g.Dispose();
                    //bmp.Dispose();
                }
            }
            image.Dispose();

            return rezult;
        }

        public static int[] GetArrFromImage(Image image, int sizeX, int sizeY)
        {
            var rezult = new int[sizeX * sizeY];
            var list = SplitImage(image, sizeX, sizeY);
            for (int k = 0; k < list.Count; k++)
            {
                rezult[k] = 0;
                for (int i = 0; i < list[k].Height; i++)
                {
                    for (int j = 0; j < list[k].Width; j++)
                    {
                        var curPixel = list[k].GetPixel(j, i);
                        if (curPixel.R <= 30 && curPixel.G <= 30 && curPixel.B <= 30)
                        {
                            rezult[k] = 1;
                            i = list[k].Height; // to break second for
                            break; // to break first for
                        }
                    }
                }
            }
            return rezult;
        }
    }
}
