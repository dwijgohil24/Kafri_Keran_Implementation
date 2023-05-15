using System;
using System.Drawing;
using System.IO;


//Implementation of Algorithm - 1.

public class KafriKeranAlgorithm
{
    public static void Main()
    {
        // Example usage
        string secretImagePath = "C:\\Users\\dwijg\\Downloads/dwij_insert.png";
        string randomGrid1Path = "C:\\Users\\dwijg\\Downloads/grid1.png";
        string randomGrid2Path = "C:\\Users\\dwijg\\Downloads/grid2.png";
        string retrievedImagePath = "C:\\Users\\dwijg\\Downloads/retrived_image.png";

        GenerateRandomGrids(secretImagePath, randomGrid1Path, randomGrid2Path);

        Bitmap retrievedImage = RetrieveImage(randomGrid1Path, randomGrid2Path);
        SaveImage(retrievedImage, retrievedImagePath);

        Console.WriteLine("Random grids generated and original image retrieved successfully!");
        Console.ReadLine();
    }

    public static void GenerateRandomGrids(string secretImagePath, string randomGrid1Path, string randomGrid2Path)
    {
        // Load secret image
        Bitmap secretImage = new Bitmap(secretImagePath);
        int rows = secretImage.Height;
        int cols = secretImage.Width;

        // Create random grids
        int[,] randomGrid1 = new int[rows, cols];
        int[,] randomGrid2 = new int[rows, cols];

        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                randomGrid1[i, j] = fran(random); // Generate random bit 0 or 1

                Color pixelColor = secretImage.GetPixel(j, i);
                int pixelValue = pixelColor.R; // Assuming grayscale image

                if (pixelValue == 0) // Assuming black represents 0
                {
                    randomGrid2[i, j] = randomGrid1[i, j];
                }
                else
                {
                    randomGrid2[i, j] = 1 - randomGrid1[i, j]; // Complement of randomGrid1
                }
            }
        }

        // Save random grids as images
        SaveGridAsImage(randomGrid1, randomGrid1Path);
        SaveGridAsImage(randomGrid2, randomGrid2Path);
    }

    public static int fran(Random random)
    {
        return random.Next(2); // Returns random bit 0 or 1
    }

    public static void SaveGridAsImage(int[,] grid, string imagePath)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        Bitmap image = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int pixelValue = grid[i, j] == 0 ? 0 : 255; // Assuming black and white image

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                image.SetPixel(j, i, pixelColor);
            }
        }

        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }

    public static Bitmap RetrieveImage(string randomGrid1Path, string randomGrid2Path)
    {
        Bitmap randomGrid1 = new Bitmap(randomGrid1Path);
        Bitmap randomGrid2 = new Bitmap(randomGrid2Path);

        int rows = randomGrid1.Height;
        int cols = randomGrid1.Width;

        Bitmap retrievedImage = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)


            {
                Color pixelColor1 = randomGrid1.GetPixel(j, i);
                Color pixelColor2 = randomGrid2.GetPixel(j, i);
                int pixelValue = (pixelColor1.R == pixelColor2.R) ? 0 : 255; // Retrieve pixel value based on grid 1 and grid 2

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                retrievedImage.SetPixel(j, i, pixelColor);
            }
        }

        return retrievedImage;
    }

    public static void SaveImage(Bitmap image, string imagePath)
    {
        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }
}

// Implementation of algorithm - 2

/*public class KafriKeranAlgorithm
{
    public static void Main()
    {
        // Example usage
        string secretImagePath = "C:\\Users\\dwijg\\Downloads/dwij_insert.png";
        string randomGrid1Path = "C:\\Users\\dwijg\\Downloads/grid1.png";
        string randomGrid2Path = "C:\\Users\\dwijg\\Downloads/grid2.png";
        string retrievedImagePath = "C:\\Users\\dwijg\\Downloads/retrived_image.png";

        GenerateRandomGrids(secretImagePath, randomGrid1Path, randomGrid2Path);

        Bitmap retrievedImage = RetrieveImage(randomGrid1Path, randomGrid2Path);
        SaveImage(retrievedImage, retrievedImagePath);

        Console.WriteLine("Random grids generated and original image retrieved successfully!");
    }

    public static void GenerateRandomGrids(string secretImagePath, string randomGrid1Path, string randomGrid2Path)
    {
        // Load secret image
        Bitmap secretImage = new Bitmap(secretImagePath);
        int rows = secretImage.Height;
        int cols = secretImage.Width;

        // Create random grids
        int[,] randomGrid1 = new int[rows, cols];
        int[,] randomGrid2 = new int[rows, cols];

        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                randomGrid1[i, j] = fran(random); // Generate random bit 0 or 1
                randomGrid2[i, j] = fran(random); // Generate random bit 0 or 1

                Color pixelColor = secretImage.GetPixel(j, i);
                int pixelValue = pixelColor.R; // Assuming grayscale image

                if (pixelValue == 0) // Assuming black represents 0
                {
                    randomGrid2[i, j] = randomGrid1[i, j];
                }
            }
        }

        // Save random grids as images
        SaveGridAsImage(randomGrid1, randomGrid1Path);
        SaveGridAsImage(randomGrid2, randomGrid2Path);
    }

    public static int fran(Random random)
    {
        return random.Next(2); // Returns random bit 0 or 1
    }

    public static void SaveGridAsImage(int[,] grid, string imagePath)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        Bitmap image = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int pixelValue = grid[i, j] == 0 ? 0 : 255; // Assuming black and white image

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                image.SetPixel(j, i, pixelColor);
            }
        }

        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }

    public static Bitmap RetrieveImage(string randomGrid1Path, string randomGrid2Path)
    {
        Bitmap randomGrid1 = new Bitmap(randomGrid1Path);
        Bitmap randomGrid2 = new Bitmap(randomGrid2Path);

        int rows = randomGrid1.Height;
        int cols = randomGrid1.Width;

        Bitmap retrievedImage = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Color pixelColor1 = randomGrid1.GetPixel(j, i);
                Color pixelColor2 = randomGrid2.GetPixel(j, i);

                int pixelValue;

                if (pixelColor2.R == 0)
                {
                    pixelValue = pixelColor1.R;
                }
                else
                {
                    pixelValue = fran(new Random()); // Generate random bit 0 or 1
                }

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                retrievedImage.SetPixel(j, i, pixelColor);
            }
        }

        return retrievedImage;
    }

    public static void SaveImage(Bitmap image, string imagePath)
    {
        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }
}*/

// Implementation of algorithm - 3.

/*public class KafriKeranAlgorithm
{
    public static void Main()
    {
        // Example usage
        string secretImagePath = "C:\\Users\\dwijg\\Downloads/dwij_insert.png";
        string randomGrid1Path = "C:\\Users\\dwijg\\Downloads/grid1.png";
        string randomGrid2Path = "C:\\Users\\dwijg\\Downloads/grid2.png";
        string retrievedImagePath = "C:\\Users\\dwijg\\Downloads/retrived_image.png";

        GenerateRandomGrids(secretImagePath, randomGrid1Path, randomGrid2Path);

        Bitmap retrievedImage = RetrieveImage(randomGrid1Path, randomGrid2Path);
        SaveImage(retrievedImage, retrievedImagePath);

        Console.WriteLine("Random grids generated and original image retrieved successfully!");
    }

    public static void GenerateRandomGrids(string secretImagePath, string randomGrid1Path, string randomGrid2Path)
    {
        // Load secret image
        Bitmap secretImage = new Bitmap(secretImagePath);
        int rows = secretImage.Height;
        int cols = secretImage.Width;

        // Create random grids
        int[,] randomGrid1 = new int[rows, cols];
        int[,] randomGrid2 = new int[rows, cols];

        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                randomGrid1[i, j] = fran(random); // Generate random bit 0 or 1
                randomGrid2[i, j] = fran(random); // Generate random bit 0 or 1

                Color pixelColor = secretImage.GetPixel(j, i);
                int pixelValue = pixelColor.R; // Assuming grayscale image

                if (pixelValue == 0) // Assuming black represents 0
                {
                    randomGrid2[i, j] = randomGrid1[i, j];
                }
            }
        }

        // Save random grids as images
        SaveGridAsImage(randomGrid1, randomGrid1Path);
        SaveGridAsImage(randomGrid2, randomGrid2Path);
    }

    public static int fran(Random random)
    {
        return random.Next(2); // Returns random bit 0 or 1
    }

    public static void SaveGridAsImage(int[,] grid, string imagePath)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        Bitmap image = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int pixelValue = grid[i, j] == 0 ? 0 : 255; // Assuming black and white image

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                image.SetPixel(j, i, pixelColor);
            }
        }

        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }

    public static Bitmap RetrieveImage(string randomGrid1Path, string randomGrid2Path)
    {
        Bitmap randomGrid1 = new Bitmap(randomGrid1Path);
        Bitmap randomGrid2 = new Bitmap(randomGrid2Path);

        int rows = randomGrid1.Height;
        int cols = randomGrid1.Width;

        Bitmap retrievedImage = new Bitmap(cols, rows);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Color pixelColor1 = randomGrid1.GetPixel(j, i);
                Color pixelColor2 = randomGrid2.GetPixel(j, i);

                int pixelValue;

                if (pixelColor2.R == 0)
                {
                    pixelValue = pixelColor1.R;
                }
                else
                {
                    pixelValue = fran(new Random()); // Generate random bit 0 or 1
                }

                Color pixelColor = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                retrievedImage.SetPixel(j, i, pixelColor);
            }
        }

        return retrievedImage;
    }

    public static void SaveImage(Bitmap image, string imagePath)
    {
        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
    }
}*/

