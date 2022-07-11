namespace Mentorship
{
    class Program
    {

        static void Main(string[] args)
        {
            //Call(args);
            //only for testing
            //var fakeArg = @"-help -s C:\Users\mariana.novosad\source\repos\Mentorship\source -d C:\Users\mariana.novosad\source\repos\Mentorship\destination -f test.txt";

            //Parameters for testing
            //var fakeArg = @"--help -p C:\Users\mariana.novosad\source\repos\Mentorship\source -o C:\Users\mariana.novosad\source\repos\Mentorship\destination -u test.txt";

            //var fakeParameters = fakeArg.Split("-")
            //    .Where(x => !String.IsNullOrWhiteSpace(x))
            //    .ToDictionary((x => x.Split(" ")[0]), Parser.GetValue);

            var parser = new Parser();
            var commandManager = new CommandManager();

            var parameters = parser.Parse(args);

            commandManager.Check(parameters, args);
        }
    }
}

