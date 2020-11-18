namespace SirilDotNet
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
            // Launch Siril
            string sirilExe = new[]
            {
                @"C:\Program Files\SiriL\bin\siril.exe",
                @"C:\Program Files (x86)\SiriL\bin\siril.exe"
            }.First(path => File.Exists(path));
            Process process = Process.Start(sirilExe, "-p");
            Console.WriteLine($"Launched PID { process.Id }");

            // Connect to the input named pipe
            var inputStream = new NamedPipeClientStream(
                ".",
                "siril_command.in",
                PipeDirection.Out,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            inputStream.Connect();

            // Connect to the output named pipe
            var outputStream = new NamedPipeClientStream(
                ".",
                "siril_command.out",
                PipeDirection.In,
                PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
            outputStream.Connect();

            // Write the commands (from arguments) to the input stream and read the output stream
            using (var inputWriter = new StreamWriter(inputStream))
            {
                foreach (string arg in args)
                {
                    inputWriter.WriteLine(arg);
                    inputWriter.Flush();
                }

                using (var outputReader = new StreamReader(outputStream))
                {
                    // Aggressively read the stream to avoid missing output if the pipe closes abruptly
                    while (!outputReader.EndOfStream)
                    {
                        Console.Write((char)outputReader.Read());
                    }
                }
            }
        }
    }
}
