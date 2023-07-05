try
{
    if (args.Length == 0)
    {
        Console.WriteLine("Usage: {0} <matrix>", Path.GetFileName(Environment.ProcessPath));
        return;
    }

    Console.WriteLine(Matrix.GetAreaCount(args[0]));
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
