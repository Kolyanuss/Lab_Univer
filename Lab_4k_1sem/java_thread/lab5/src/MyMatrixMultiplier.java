class MyMatrixMultiplier extends Thread {
    private int[][] matrix1;
    private int[][] matrix2;
    private int[][] matrixResult;
    private int i1;
    private int i2;
    private int vectorLength;

    public MyMatrixMultiplier(int[][] m1, int[][] m2, int[][] mRes, int i1, int i2) {
        this.matrix1 = m1;
        this.matrix2 = m2;
        this.matrixResult = mRes;
        this.i1 = i1;
        this.i2 = i2;
        vectorLength = m2.length;
    }

    private void vectorMiltiplier(int row, int col) {
        int sum = 0;
        for (int i = 0; i < vectorLength; ++i)
            sum += matrix1[row][i] * matrix2[i][col];
        matrixResult[row][col] = sum;
    }

    @Override
    public void run() {
        System.out.println("Потік " + getName() + " почато. Обчислення комірок з " + i1 + " до " + i2 + "...");

        int colCount = matrixResult[0].length;
        for (int index = i1; index < i2; ++index)
            vectorMiltiplier(index / colCount, index % colCount);

        System.out.println("Потік " + getName() + " закінчений.");
    }
}

