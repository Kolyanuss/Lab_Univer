namespace DataBlock
{
    public static class DataForLearn
    {
        public static int[] num0 = new int[48]
        {
            0,0,0,0,0,0,
            0,1,1,1,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,1,1,1,0,
            0,0,0,0,0,0
        };
        public static int[] num1 = new int[48]
        {
            0,0,0,0,0,0,
            0,0,0,0,1,0,
            0,0,0,1,1,0,
            0,0,1,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,0,0
        };
        public static int[] num2 = new int[48]
        {
            0,0,1,1,0,0,
            0,1,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,1,0,0,
            0,0,1,0,0,0,
            0,1,0,0,0,0,
            0,1,1,1,1,0,
            0,0,0,0,0,0
        };
        public static int[] num3 = new int[48]
        {
            0,0,0,0,0,0,
            0,1,1,1,1,0,
            0,0,0,0,0,1,
            0,0,0,0,0,1,
            0,0,0,1,1,0,
            0,0,0,0,0,1,
            0,1,0,0,0,1,
            0,0,1,1,1,0
        };
        public static int[] num4 = new int[48]
        {
            0,0,0,0,0,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,1,1,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0
        };
        public static int[] num5 = new int[48]
        {
            0,1,1,1,1,0,
            0,1,0,0,0,0,
            0,1,0,0,0,0,
            0,1,1,1,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,1,1,1,1,0,
            0,0,0,0,0,0
        };
        public static int[] num6 = new int[48]
        {
            0,0,0,0,0,0,
            0,1,1,1,1,0,
            0,1,0,0,0,0,
            0,1,0,0,0,0,
            0,1,1,1,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,1,1,1,0
        };
        public static int[] num7 = new int[48]
        {
            0,0,0,0,0,0,
            1,1,1,1,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,1,1,1,
            0,0,0,1,0,0,
            0,0,0,1,0,0
        };
        public static int[] num8 = new int[48]
        {
            0,0,1,1,0,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,0,1,1,0,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,0,1,1,0,0
        };
        public static int[] num9 = new int[48]
        {
            0,1,1,1,1,0,
            0,1,0,0,1,0,
            0,1,0,0,1,0,
            0,1,1,1,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,0,0,0,1,0,
            0,1,1,1,1,0
        };

        public static List<Tuple<int[], bool>> NumForLearn = new List<Tuple<int[], bool>>()
        {
            new Tuple<int[], bool>(num0,true),
            new Tuple<int[], bool>(num1,false),
            new Tuple<int[], bool>(num2,true),
            new Tuple<int[], bool>(num3,false),
            new Tuple<int[], bool>(num4,true),
            new Tuple<int[], bool>(num5,false),
            new Tuple<int[], bool>(num6,true),
            new Tuple<int[], bool>(num7,false),
            new Tuple<int[], bool>(num8,true),
            new Tuple<int[], bool>(num9,false),
        };
    }
}