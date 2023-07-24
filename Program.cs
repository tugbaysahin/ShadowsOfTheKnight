class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int W, H, N, X0, Y0, Hb, Wb;

        InitializeGame(out inputs, out W, out H, out N, out X0, out Y0, out Hb, out Wb);

        while (ConstraintChecks(W, H, N, X0, Y0) == false)
        {
            InitializeGame(out inputs, out W, out H, out N, out X0, out Y0, out Hb, out Wb);
        }

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            Console.Error.WriteLine($"bombDir : {bombDir}");
            SetNextCoordinate(bombDir, ref X0, ref Y0, ref W, ref H, ref Wb, ref Hb);
            Console.Error.WriteLine($"XO: {X0} YO: {Y0} W: {W} H: {H} WB: {Wb} HB: {Hb}");
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // the location of the next window Batman should jump to.
            Console.WriteLine($"{X0} {Y0}");
        }
    }

    private static void SetNextCoordinate(string? bombDir, ref int x0, ref int y0, ref int w, ref int h, ref int wb, ref int hb)
    {
        if (bombDir == "U")
        {
            h = y0;
            y0 += Convert.ToInt32(Math.Floor((double)(((double)hb - (double)y0) / 2)));
        }
        if (bombDir == "UR")
        {
            h = y0;
            wb = x0;
            y0 += Convert.ToInt32(Math.Floor((double)(((double)hb - y0) / 2)));
            x0 += Convert.ToInt32(Math.Ceiling((double)((double)(w - x0) / 2)));
        }
        if (bombDir == "R")
        {
            wb = x0;
            x0 += Convert.ToInt32(Math.Ceiling((double)((double)(w - x0) / 2)));
        }
        if (bombDir == "DR")
        {
            hb = y0;
            wb = x0;
            y0 += Convert.ToInt32(Math.Ceiling((double)((double)(h - y0) / 2)));
            x0 += Convert.ToInt32(Math.Ceiling((double)((double)(w - x0) / 2)));
        }
        if (bombDir == "D")
        {
            hb = y0;
            y0 += Convert.ToInt32(Math.Ceiling((double)((double)(h - y0) / 2)));
        }
        if (bombDir == "DL")
        {
            w = x0;
            hb = y0;
            y0 += Convert.ToInt32(Math.Ceiling((double)((double)(h - y0) / 2)));
            x0 += Convert.ToInt32(Math.Floor((double)((double)(wb - x0) / 2)));
        }
        if (bombDir == "L")
        {
            w = x0;
            x0 += Convert.ToInt32(Math.Floor((double)((double)(wb - x0) / 2)));
        }
        if (bombDir == "UL")
        {
            h = y0;
            w = x0;
            y0 += Convert.ToInt32(Math.Floor((double)((double)(hb - y0) / 2)));
            x0 += Convert.ToInt32(Math.Floor((double)((double)(wb - x0) / 2)));
        }
    }

    private static bool ConstraintChecks(int w, int h, int n, int x0, int y0)
    {
        return (1 <= w && w <= 10000) &
                (1 <= h && h <= 10000) &
                (2 <= n && n <= 100) &
                (0 <= x0 && x0 < w) &
                (0 <= y0 && y0 < h);
    }

    private static void InitializeGame(out string[] inputs, out int W, out int H, out int N, out int X0, out int Y0, out int hb, out int wb)
    {
        inputs = Console.ReadLine().Split(' ');
        W = int.Parse(inputs[0]);
        H = int.Parse(inputs[1]);
        N = int.Parse(Console.ReadLine());
        inputs = Console.ReadLine().Split(' ');
        X0 = int.Parse(inputs[0]);
        Y0 = int.Parse(inputs[1]);
        hb = 0;
        wb = 0;
    }
}