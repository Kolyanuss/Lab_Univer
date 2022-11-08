import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;

class Main {
    private static void printMatrix(FileWriter fileWriter, int[][] matrix) throws IOException {
        boolean hasNegative = false;
        int maxValue = 0;

        for (int[] row : matrix) {
            for (int element : row) {
                int temp = element;
                if (element < 0) {
                    hasNegative = true;
                    temp = -temp;
                }
                if (temp > maxValue)
                    maxValue = temp;
            }
        }
        int len = Integer.toString(maxValue).length() + 1;
        if (hasNegative)
            ++len;

        String formatString = "%" + len + "d";


        for (int[] row : matrix) {
            for (int element : row)
                fileWriter.write(String.format(formatString, element));

            fileWriter.write("\n");
        }
    }

    private static int[][] multiplyMatrix(int[][] firstMatrix,
                                          int[][] secondMatrix) {
        int rowCount = firstMatrix.length;
        int colCount = secondMatrix[0].length;
        int sumLength = secondMatrix.length;
        int[][] result = new int[rowCount][colCount];

        for (int row = 0; row < rowCount; ++row) {
            for (int col = 0; col < colCount; ++col) {
                int sum = 0;
                for (int i = 0; i < sumLength; ++i)
                    sum += firstMatrix[row][i] * secondMatrix[i][col];
                result[row][col] = sum;
            }
        }
        return result;
    }

    private static int[][] multiplyMatrixMT(int[][] firstMatrix, int[][] secondMatrix, int threadCount) {
        assert threadCount > 0;

        int rowCount = firstMatrix.length;
        int colCount = secondMatrix[0].length;
        int[][] result = new int[rowCount][colCount];

        int cellsForThread = (rowCount * colCount) / threadCount;
        int firstIndex = 0;
        MyMatrixMultiplier[] multiplierThreads = new MyMatrixMultiplier[threadCount];

        for (int threadIndex = threadCount - 1; threadIndex >= 0; --threadIndex) {
            int lastIndex = firstIndex + cellsForThread;  // Індекс останньої обчислюваної комірки.
            if (threadIndex == 0) {
                lastIndex = rowCount * colCount;
            }
            multiplierThreads[threadIndex] = new MyMatrixMultiplier(firstMatrix, secondMatrix, result, firstIndex, lastIndex);
            multiplierThreads[threadIndex].start();
            firstIndex = lastIndex;
        }
        try {
            for (MyMatrixMultiplier multiplierThread : multiplierThreads)
                multiplierThread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        return result;
    }

    public static void main(String[] args) {
        int matrix1Row = 100;
        int matrix1Col = 200;
        int matrix2Row = matrix1Col;
        int matrix2Col = 50;
        // створення матриць
        int[][] matrix1 = new int[matrix1Row][matrix1Col];
        int[][] matrix2 = new int[matrix2Row][matrix2Col];

        // заповнюю матриці рандомними числами
        Random random = new Random();

        for (int row = 0; row < matrix1.length; ++row)
            for (int col = 0; col < matrix1[row].length; ++col)
                matrix1[row][col] = random.nextInt(100);

        for (int row = 0; row < matrix2.length; ++row)
            for (int col = 0; col < matrix2[row].length; ++col)
                matrix2[row][col] = random.nextInt(100);

        // множення матриць
        int[][] resultMatrixMT = multiplyMatrixMT(matrix1, matrix2, Runtime.getRuntime().availableProcessors());
        int[][] resultMatrix = multiplyMatrix(matrix1, matrix2);

        for (int row = 0; row < matrix1Row; ++row) {
            for (int col = 0; col < matrix2Col; ++col) {
                if (resultMatrixMT[row][col] != resultMatrix[row][col]) {
                    System.out.println("Помилка в багатопотоковому обчисленні!");
                    return;
                }
            }
        }
        // друк у файл
        String fileName = "result.txt";
        try (FileWriter fileWriter = new FileWriter(fileName, false)) {
            fileWriter.write("Перша матриця:\n");
            printMatrix(fileWriter, matrix1);
            fileWriter.write("\nДруга матриця:\n");
            printMatrix(fileWriter, matrix2);
            fileWriter.write("\nВихідна матриця:\n");
            printMatrix(fileWriter, resultMatrixMT);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
