namespace SirilCmd
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Pipes;
    using System.Linq;
    using System.Security.Principal;

    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("siril");
            if (processes.Any())
            {
                Console.WriteLine($"Found PID { string.Join(", ", processes.Select(process => process.Id)) }");
            }
            else
            {
                Process process = Process.Start(@"C:\Program Files (x86)\SiriL\bin\siril.exe", "-p");
                Console.WriteLine($"Launched PID { process.Id }");
            }

            var inputStream = new NamedPipeClientStream(
                ".",
                "siril_command.in",
                PipeDirection.Out,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            inputStream.Connect();

            var outputStream = new NamedPipeClientStream(
                ".",
                "siril_command.out",
                PipeDirection.In,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            outputStream.Connect();

            using (var inputWriter = new StreamWriter(inputStream))
            {
                foreach (string arg in args)
                {
                    inputWriter.WriteLine(arg);
                    inputWriter.Flush();
                }

                using (var outputReader = new StreamReader(outputStream))
                {
                    while (!outputReader.EndOfStream)
                    {
                        Console.Write((char)outputReader.Read());
                    }
                }
            }
        }
    }
}
